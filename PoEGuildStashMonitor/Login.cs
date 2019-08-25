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
    public partial class Login : Form
    {
        public static string PoeSessID { get; private set; }
        public static string GuildID { get; private set; }

        public Login()
        {
            InitializeComponent();
            UpdateButton();
        }

        private void UpdateButton()
        {
            LoginButton.Enabled = !string.IsNullOrWhiteSpace(PoeSessID) && !string.IsNullOrWhiteSpace(GuildID);
        }

        private void TextField_TextChanged(object sender, EventArgs e)
        {
            PoeSessID = ((TextBox)sender).Text;
            UpdateButton();
        }

        private void GuildIDText_TextChanged(object sender, EventArgs e)
        {
            GuildID = ((TextBox)sender).Text;
            UpdateButton();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DataLoader gsm = new DataLoader();
            gsm.ShowDialog();
        }
    }
}