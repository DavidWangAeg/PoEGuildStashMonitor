namespace PoEGuildStashMonitor
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.userDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userDataBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.UserList = new System.Windows.Forms.ListBox();
            this.StatusBar = new System.Windows.Forms.Label();
            this.SyncButton = new System.Windows.Forms.Button();
            this.LastFetchTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // userDataBindingSource
            // 
            this.userDataBindingSource.DataSource = typeof(PoEGuildStashMonitor.GuildStash.Schema.UserData);
            // 
            // userDataBindingSource1
            // 
            this.userDataBindingSource1.DataSource = typeof(PoEGuildStashMonitor.GuildStash.Schema.UserData);
            // 
            // UserList
            // 
            this.UserList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserList.FormattingEnabled = true;
            this.UserList.ItemHeight = 16;
            this.UserList.Location = new System.Drawing.Point(411, 12);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(538, 516);
            this.UserList.TabIndex = 0;
            // 
            // StatusBar
            // 
            this.StatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusBar.Location = new System.Drawing.Point(12, 560);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(937, 54);
            this.StatusBar.TabIndex = 1;
            this.StatusBar.Text = "Status Bar";
            // 
            // SyncButton
            // 
            this.SyncButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SyncButton.Location = new System.Drawing.Point(15, 492);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(390, 55);
            this.SyncButton.TabIndex = 2;
            this.SyncButton.Text = "Sync Changes";
            this.SyncButton.UseVisualStyleBackColor = true;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // LastFetchTime
            // 
            this.LastFetchTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LastFetchTime.Location = new System.Drawing.Point(15, 12);
            this.LastFetchTime.Name = "LastFetchTime";
            this.LastFetchTime.Size = new System.Drawing.Size(390, 28);
            this.LastFetchTime.TabIndex = 3;
            this.LastFetchTime.Text = "Last Fetched: ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 623);
            this.Controls.Add(this.LastFetchTime);
            this.Controls.Add(this.SyncButton);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.UserList);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.userDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource userDataBindingSource;
        private System.Windows.Forms.BindingSource userDataBindingSource1;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.Label StatusBar;
        private System.Windows.Forms.Button SyncButton;
        private System.Windows.Forms.Label LastFetchTime;
    }
}