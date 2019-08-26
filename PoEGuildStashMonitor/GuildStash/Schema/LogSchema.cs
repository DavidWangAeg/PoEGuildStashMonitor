using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEGuildStashMonitor.GuildStash.Schema
{
    public class Account
    {
        public string name;
        public string realm;
    }

    public class Entry
    {
        public long id;
        public long time;
        public string league;
        public string item;
        public string action;
        public Account account;
    }

    public class LogResult
    {
        public Entry[] entries;
    }
}