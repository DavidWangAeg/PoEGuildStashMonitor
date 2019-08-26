using PoEGuildStashMonitor.Core;
using PoEGuildStashMonitor.GuildStash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoEGuildStashMonitor
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            Shown += OnShown;

            Authentication.Instance.IsAuthenticatedChanged += OnIsAuthedChanged;
        }

        private void OnShown(object sender, EventArgs args)
        {
            // Show auth screen for first time
            OnIsAuthedChanged(false);
        }

        private async void SyncButton_Click(object sender, EventArgs e)
        {
            SyncButton.Enabled = false;

            Action<long, long, int> logFunc = (toTime, fromTime, count) =>
            {
                string label = $"Syncing {DateTimeOffset.FromUnixTimeSeconds(fromTime).ToLocalTime()} - {DateTimeOffset.FromUnixTimeSeconds(toTime).ToLocalTime()}. {count} results processed.";
                UpdateStatus(label);
            };

            await LogDataManager.Instance.SyncEntriesToCurrent(logFunc);
            UserList.DataSource = LogDataManager.Instance.GetSortedUserData();
            SyncButton.Enabled = true;
        }

        private void UpdateStatus(string text)
        {
            StatusBar.Text = text;
        }

        private void OnIsAuthedChanged(bool authed)
        {
            if (!authed)
            {
                Login login = new Login(LogDataManager.Instance.GuildID);
                login.ShowDialog();
            }
        }
    }
}
