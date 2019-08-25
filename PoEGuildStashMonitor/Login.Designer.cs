namespace PoEGuildStashMonitor
{
    partial class Login
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
            this.TextField = new System.Windows.Forms.TextBox();
            this.PoesessidLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.GuildIDLabel = new System.Windows.Forms.Label();
            this.GuildIDText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextField
            // 
            this.TextField.Location = new System.Drawing.Point(106, 12);
            this.TextField.Name = "TextField";
            this.TextField.Size = new System.Drawing.Size(369, 20);
            this.TextField.TabIndex = 0;
            this.TextField.TextChanged += new System.EventHandler(this.TextField_TextChanged);
            // 
            // PoesessidLabel
            // 
            this.PoesessidLabel.AutoSize = true;
            this.PoesessidLabel.Location = new System.Drawing.Point(12, 15);
            this.PoesessidLabel.Name = "PoesessidLabel";
            this.PoesessidLabel.Size = new System.Drawing.Size(68, 13);
            this.PoesessidLabel.TabIndex = 1;
            this.PoesessidLabel.Text = "POESESSID";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(216, 130);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // GuildIDLabel
            // 
            this.GuildIDLabel.AutoSize = true;
            this.GuildIDLabel.Location = new System.Drawing.Point(12, 51);
            this.GuildIDLabel.Name = "GuildIDLabel";
            this.GuildIDLabel.Size = new System.Drawing.Size(42, 13);
            this.GuildIDLabel.TabIndex = 4;
            this.GuildIDLabel.Text = "GuildID";
            // 
            // GuildIDText
            // 
            this.GuildIDText.Location = new System.Drawing.Point(106, 48);
            this.GuildIDText.Name = "GuildIDText";
            this.GuildIDText.Size = new System.Drawing.Size(369, 20);
            this.GuildIDText.TabIndex = 3;
            this.GuildIDText.TextChanged += new System.EventHandler(this.GuildIDText_TextChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 178);
            this.Controls.Add(this.GuildIDLabel);
            this.Controls.Add(this.GuildIDText);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PoesessidLabel);
            this.Controls.Add(this.TextField);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextField;
        private System.Windows.Forms.Label PoesessidLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label GuildIDLabel;
        private System.Windows.Forms.TextBox GuildIDText;
    }
}

