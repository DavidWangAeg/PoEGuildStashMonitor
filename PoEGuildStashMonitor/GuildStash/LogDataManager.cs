using Newtonsoft.Json;
using PoEGuildStashMonitor.Core;
using PoEGuildStashMonitor.GuildStash.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PoEGuildStashMonitor.GuildStash
{
    public class LogDataManager : Singleton<LogDataManager>
    {
        private const int SyncDelayMs = 100;
        private const int MaxFetchDurationSeconds = 7 * 24 * 60 * 60; // 14 days in seconds
        private static int CompareUserData(UserData a, UserData b)
        {
            return a.score.CompareTo(b.score);
        }

        public event Action<UserData> UserScoreThresholdExceeded;
        public event Action UserDataChanged;

        private CachedData cachedData = null;

        private Dictionary<string, UserData> userDataMap = new Dictionary<string, UserData>();
        private List<UserData> userDataList = new List<UserData>();

        public string GuildID { get; set; } = "";
        public DateTimeOffset LastFetchTime { get; private set; }

        public IReadOnlyList<UserData> GetSortedUserData()
        {
            userDataList.Sort(CompareUserData);
            return userDataList;
        }

        public async Task SyncEntriesToCurrent(Action<long, long, int> processedCallback)
        {
            EnsureCachedData();

            long epochNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            long currentEpoch = epochNow;
            long currentId = 0;

            long fetchUntilEpoch = Math.Max(currentEpoch - MaxFetchDurationSeconds, cachedData.maxEpoch);
            long minId = cachedData.minEntryId;
            long maxId = cachedData.maxEntryId;

            int totalAdded = 0;
            while (currentEpoch > fetchUntilEpoch)
            {
                await Task.Delay(SyncDelayMs);

                string epoch = currentEpoch.ToString();
                string id = currentId == 0 ? "" : currentId.ToString();

                string result = await PoeHttpClient.Instance.GetHistoryAsync(GuildID, epoch, id);
                var log = JsonConvert.DeserializeObject<LogResult>(result);

                int added = ProcessLog(log, minId, maxId);
                totalAdded += added;

                if (added != 0)
                {
                    Entry last = log.entries[log.entries.Length - 1];

                    currentEpoch = last.time;
                    currentId = last.id;
                }
                else
                {
                    currentEpoch = fetchUntilEpoch;
                }

                processedCallback(epochNow, currentEpoch, totalAdded);
            }
        }

        public int ProcessLog(LogResult result, long minId, long maxId)
        {
            EnsureCachedData();
            int processed = 0;
            if (result?.entries != null)
            {
                foreach(Entry e in result.entries)
                {
                    // Skip if id falls into range that has already been parsed
                    if (e.id >= minId && e.id <= maxId)
                    {
                        continue;
                    }

                    UserData user = null;
                    if (!userDataMap.ContainsKey(e.account.name))
                    {
                        user = new UserData() { name = e.account.name, score = 0 };
                        userDataMap[e.account.name] = user;
                        userDataList.Add(user);
                    }
                    else
                    {
                        user = userDataMap[e.account.name];
                    }

                    if (e.action == "added")
                    {
                        ++user.score;
                    }
                    else
                    {
                        --user.score;
                    }

                    ++processed;
                }

                if (result.entries.Length > 0)
                {
                    // Newest items are listed first
                    Entry newest = result.entries[0];
                    Entry oldest = result.entries[result.entries.Length - 1];

                    if (newest.id > cachedData.maxEntryId)
                    {
                        cachedData.maxEntryId = newest.id;
                        cachedData.maxEpoch = newest.time;
                    }

                    if (oldest.id < cachedData.minEntryId)
                    {
                        cachedData.minEntryId = oldest.id;
                        cachedData.minEpoch = oldest.time;
                    }
                }
            }

            if (processed > 0)
            {
                UserDataChanged?.Invoke();
            }

            return processed;
        }

        public void LoadData(string filePath)
        {
            string data = File.ReadAllText(filePath);

            try
            {
                cachedData = JsonConvert.DeserializeObject<CachedData>(data);

                if (cachedData?.users != null)
                {
                    foreach (UserData user in cachedData.users)
                    {
                        if (!userDataMap.ContainsKey(user.name))
                        {
                            userDataMap[user.name] = user;
                        }
                        else
                        {
                            // TODO: Log duplicates
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // TODO: Add logging
            }
        }

        public void SaveData(string filePath)
        {
            EnsureCachedData();
            cachedData.users = this.userDataMap.Values.ToArray();
            string data = JsonConvert.SerializeObject(cachedData);
            File.WriteAllText(filePath, data);
        }

        private void EnsureCachedData()
        {
            if (cachedData == null)
            {
                cachedData = new CachedData()
                {
                    minEntryId = long.MaxValue,
                    maxEntryId = long.MinValue,
                    users = new UserData[0]
                };
            }
        }
    }
}