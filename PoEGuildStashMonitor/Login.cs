using PoEGuildStashMonitor.Core;
using PoEGuildStashMonitor.GuildStash;
using System;
using System.Windows.Forms;

namespace PoEGuildStashMonitor
{
    public partial class Login : Form
    {
        private string poeSessID;
        private string guildId;

        public Login(string guildId = "")
        {
            InitializeComponent();
            this.guildId = guildId;
            GuildIDText.Text = guildId;
            UpdateButton();
        }

        private void UpdateButton()
        {
            LoginButton.Enabled = !string.IsNullOrWhiteSpace(poeSessID) && !string.IsNullOrWhiteSpace(guildId);
        }

        private void TextField_TextChanged(object sender, EventArgs e)
        {
            poeSessID = ((TextBox)sender).Text;
            UpdateButton();
        }

        private void GuildIDText_TextChanged(object sender, EventArgs e)
        {
            guildId = ((TextBox)sender).Text;
            UpdateButton();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Authentication.Instance.AuthenticatePoessid(poeSessID);
            LogDataManager.Instance.GuildID = guildId;

            Close();
        }
    }
}