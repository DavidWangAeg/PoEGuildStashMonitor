using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PoEGuildStashMonitor
{
    public class UserData
    {
        public string AccountName;
        public List<string> Transactions;
    }

    public class CachedData
    {
        public string LastFetchedEpochTime;
        public UserData[] userData;
    }

    public class UserDataCache
    {
        private static UserDataCache instance;
        public static UserDataCache Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDataCache();
                }

                return instance;
            }
        }


        public long LastFetchedEpoch { get; private set; } = 0;
        private Dictionary<string, UserData> userDataMap;

        public void LoadData(string filePath)
        {
            string data = File.ReadAllText(filePath);

            try
            {
                CachedData loadedData = JsonConvert.DeserializeObject<CachedData>(data);

                if (!string.IsNullOrEmpty(loadedData?.LastFetchedEpochTime))
                {
                    this.LastFetchedEpoch = long.Parse(loadedData.LastFetchedEpochTime);
                }

                if (loadedData?.userData != null)
                {
                    foreach(UserData user in loadedData?.userData)
                    {
                        if (!userDataMap.ContainsKey(user.AccountName))
                        {
                            userDataMap[user.AccountName] = user;
                        }
                        else
                        {
                            // TODO: Log duplicates
                        }
                    }
                }
            }
            catch(Exception e)
            {
                // TODO: Add logging
            }
        }

        public void SaveData(string filePath)
        {
            UserData[] userList = this.userDataMap.Values.ToArray();
            string data = JsonConvert.SerializeObject(userList);
            File.WriteAllText(filePath, data);
        }
    }
}