namespace Launcher
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.StartGame = new System.Windows.Forms.Button();
			this.EmailLabel = new System.Windows.Forms.Label();
			this.LoginEmail = new System.Windows.Forms.TextBox();
			this.LoginPassword = new System.Windows.Forms.TextBox();
			this.PasswordLabel = new System.Windows.Forms.Label();
			this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.Background = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
			this.SuspendLayout();
			// 
			// StartGame
			// 
			this.StartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.StartGame.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
			this.StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StartGame.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StartGame.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.StartGame.Location = new System.Drawing.Point(405, 391);
			this.StartGame.Name = "StartGame";
			this.StartGame.Size = new System.Drawing.Size(151, 38);
			this.StartGame.TabIndex = 1;
			this.StartGame.Text = "Start";
			this.StartGame.UseVisualStyleBackColor = false;
			this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
			// 
			// EmailLabel
			// 
			this.EmailLabel.AutoSize = true;
			this.EmailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.EmailLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EmailLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.EmailLabel.Location = new System.Drawing.Point(333, 160);
			this.EmailLabel.Name = "EmailLabel";
			this.EmailLabel.Size = new System.Drawing.Size(48, 21);
			this.EmailLabel.TabIndex = 2;
			this.EmailLabel.Text = "Email";
			// 
			// LoginEmail
			// 
			this.LoginEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.LoginEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginEmail.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.LoginEmail.Location = new System.Drawing.Point(387, 157);
			this.LoginEmail.Name = "LoginEmail";
			this.LoginEmail.Size = new System.Drawing.Size(230, 29);
			this.LoginEmail.TabIndex = 3;
			this.LoginEmail.TextChanged += new System.EventHandler(this.LoginEmail_TextChanged);
			// 
			// LoginPassword
			// 
			this.LoginPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.LoginPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.LoginPassword.Location = new System.Drawing.Point(387, 202);
			this.LoginPassword.Name = "LoginPassword";
			this.LoginPassword.Size = new System.Drawing.Size(230, 29);
			this.LoginPassword.TabIndex = 5;
			this.LoginPassword.TextChanged += new System.EventHandler(this.LoginPassword_TextChanged);
			// 
			// PasswordLabel
			// 
			this.PasswordLabel.AutoSize = true;
			this.PasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.PasswordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.PasswordLabel.Location = new System.Drawing.Point(305, 205);
			this.PasswordLabel.Name = "PasswordLabel";
			this.PasswordLabel.Size = new System.Drawing.Size(76, 21);
			this.PasswordLabel.TabIndex = 4;
			this.PasswordLabel.Text = "Password";
			// 
			// TrayIcon
			// 
			this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
			this.TrayIcon.Text = "EmuTarkov Launcher";
			this.TrayIcon.Visible = true;
			this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
			// 
			// Background
			// 
			this.Background.BackgroundImage = global::Launcher.Properties.Resources.bg_1;
			this.Background.Image = global::Launcher.Properties.Resources.bg_alpha;
			this.Background.InitialImage = null;
			this.Background.Location = new System.Drawing.Point(0, -2);
			this.Background.Name = "Background";
			this.Background.Size = new System.Drawing.Size(728, 451);
			this.Background.TabIndex = 0;
			this.Background.TabStop = false;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 441);
			this.Controls.Add(this.LoginPassword);
			this.Controls.Add(this.PasswordLabel);
			this.Controls.Add(this.LoginEmail);
			this.Controls.Add(this.EmailLabel);
			this.Controls.Add(this.StartGame);
			this.Controls.Add(this.Background);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(736, 480);
			this.MinimumSize = new System.Drawing.Size(736, 480);
			this.Name = "Main";
			this.Text = "EmuTarkov Launcher";
			this.Resize += new System.EventHandler(this.Main_Resize);
			((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox LoginEmail;
        private System.Windows.Forms.TextBox LoginPassword;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.NotifyIcon TrayIcon;
		private System.Windows.Forms.PictureBox Background;
	}
}

