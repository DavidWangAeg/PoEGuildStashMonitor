using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEGuildStashMonitor.GuildStash.Schema
{
    public class UserData
    {
        public string name;
        public int score;

        public override string ToString()
        {
            return $"{name}: {score}";
        }
    }

    public class CachedData
    {
        public long minEntryId;
        public long maxEntryId;
        public long minEpoch;
        public long maxEpoch;
        public UserData[] users;
    }
}
