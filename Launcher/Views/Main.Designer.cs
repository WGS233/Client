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
			this.LoginEmailLabel = new System.Windows.Forms.Label();
			this.LoginEmail = new System.Windows.Forms.TextBox();
			this.LoginPassword = new System.Windows.Forms.TextBox();
			this.LoginPasswordLabel = new System.Windows.Forms.Label();
			this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.Background = new System.Windows.Forms.PictureBox();
			this.RegisterEdition = new System.Windows.Forms.ComboBox();
			this.RegisterEditionLabel = new System.Windows.Forms.Label();
			this.RegisterPassword = new System.Windows.Forms.TextBox();
			this.RegisterPasswordLabel = new System.Windows.Forms.Label();
			this.RegisterEmail = new System.Windows.Forms.TextBox();
			this.RegisterEmailLabel = new System.Windows.Forms.Label();
			this.RegisterButton = new System.Windows.Forms.Button();
			this.LoginButton = new System.Windows.Forms.Button();
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
			this.StartGame.Visible = false;
			this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
			// 
			// LoginEmailLabel
			// 
			this.LoginEmailLabel.AutoSize = true;
			this.LoginEmailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.LoginEmailLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginEmailLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.LoginEmailLabel.Location = new System.Drawing.Point(333, 148);
			this.LoginEmailLabel.Name = "LoginEmailLabel";
			this.LoginEmailLabel.Size = new System.Drawing.Size(48, 21);
			this.LoginEmailLabel.TabIndex = 2;
			this.LoginEmailLabel.Text = "Email";
			this.LoginEmailLabel.Visible = false;
			// 
			// LoginEmail
			// 
			this.LoginEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.LoginEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginEmail.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.LoginEmail.Location = new System.Drawing.Point(387, 145);
			this.LoginEmail.Name = "LoginEmail";
			this.LoginEmail.Size = new System.Drawing.Size(230, 29);
			this.LoginEmail.TabIndex = 3;
			this.LoginEmail.Visible = false;
			this.LoginEmail.TextChanged += new System.EventHandler(this.LoginEmail_TextChanged);
			// 
			// LoginPassword
			// 
			this.LoginPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.LoginPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.LoginPassword.Location = new System.Drawing.Point(387, 190);
			this.LoginPassword.Name = "LoginPassword";
			this.LoginPassword.Size = new System.Drawing.Size(230, 29);
			this.LoginPassword.TabIndex = 5;
			this.LoginPassword.Visible = false;
			this.LoginPassword.TextChanged += new System.EventHandler(this.LoginPassword_TextChanged);
			// 
			// LoginPasswordLabel
			// 
			this.LoginPasswordLabel.AutoSize = true;
			this.LoginPasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.LoginPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginPasswordLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.LoginPasswordLabel.Location = new System.Drawing.Point(305, 193);
			this.LoginPasswordLabel.Name = "LoginPasswordLabel";
			this.LoginPasswordLabel.Size = new System.Drawing.Size(76, 21);
			this.LoginPasswordLabel.TabIndex = 4;
			this.LoginPasswordLabel.Text = "Password";
			this.LoginPasswordLabel.Visible = false;
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
			// RegisterEdition
			// 
			this.RegisterEdition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.RegisterEdition.DropDownHeight = 107;
			this.RegisterEdition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegisterEdition.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.RegisterEdition.FormattingEnabled = true;
			this.RegisterEdition.IntegralHeight = false;
			this.RegisterEdition.ItemHeight = 21;
			this.RegisterEdition.Location = new System.Drawing.Point(387, 227);
			this.RegisterEdition.Name = "RegisterEdition";
			this.RegisterEdition.Size = new System.Drawing.Size(230, 29);
			this.RegisterEdition.TabIndex = 6;
			this.RegisterEdition.Visible = false;
			// 
			// RegisterEditionLabel
			// 
			this.RegisterEditionLabel.AutoSize = true;
			this.RegisterEditionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.RegisterEditionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegisterEditionLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.RegisterEditionLabel.Location = new System.Drawing.Point(323, 231);
			this.RegisterEditionLabel.Name = "RegisterEditionLabel";
			this.RegisterEditionLabel.Size = new System.Drawing.Size(58, 21);
			this.RegisterEditionLabel.TabIndex = 7;
			this.RegisterEditionLabel.Text = "Edition";
			this.RegisterEditionLabel.Visible = false;
			// 
			// RegisterPassword
			// 
			this.RegisterPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.RegisterPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegisterPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.RegisterPassword.Location = new System.Drawing.Point(387, 182);
			this.RegisterPassword.Name = "RegisterPassword";
			this.RegisterPassword.Size = new System.Drawing.Size(230, 29);
			this.RegisterPassword.TabIndex = 11;
			this.RegisterPassword.Visible = false;
			// 
			// RegisterPasswordLabel
			// 
			this.RegisterPasswordLabel.AutoSize = true;
			this.RegisterPasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.RegisterPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegisterPasswordLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.RegisterPasswordLabel.Location = new System.Drawing.Point(305, 185);
			this.RegisterPasswordLabel.Name = "RegisterPasswordLabel";
			this.RegisterPasswordLabel.Size = new System.Drawing.Size(76, 21);
			this.RegisterPasswordLabel.TabIndex = 10;
			this.RegisterPasswordLabel.Text = "Password";
			this.RegisterPasswordLabel.Visible = false;
			// 
			// RegisterEmail
			// 
			this.RegisterEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.RegisterEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegisterEmail.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.RegisterEmail.Location = new System.Drawing.Point(387, 137);
			this.RegisterEmail.Name = "RegisterEmail";
			this.RegisterEmail.Size = new System.Drawing.Size(230, 29);
			this.RegisterEmail.TabIndex = 9;
			this.RegisterEmail.Visible = false;
			// 
			// RegisterEmailLabel
			// 
			this.RegisterEmailLabel.AutoSize = true;
			this.RegisterEmailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.RegisterEmailLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegisterEmailLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.RegisterEmailLabel.Location = new System.Drawing.Point(333, 140);
			this.RegisterEmailLabel.Name = "RegisterEmailLabel";
			this.RegisterEmailLabel.Size = new System.Drawing.Size(48, 21);
			this.RegisterEmailLabel.TabIndex = 8;
			this.RegisterEmailLabel.Text = "Email";
			this.RegisterEmailLabel.Visible = false;
			// 
			// RegisterButton
			// 
			this.RegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.RegisterButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
			this.RegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RegisterButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RegisterButton.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.RegisterButton.Location = new System.Drawing.Point(405, 391);
			this.RegisterButton.Name = "RegisterButton";
			this.RegisterButton.Size = new System.Drawing.Size(151, 38);
			this.RegisterButton.TabIndex = 12;
			this.RegisterButton.Text = "Register";
			this.RegisterButton.UseVisualStyleBackColor = false;
			this.RegisterButton.Visible = false;
			this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
			// 
			// LoginButton
			// 
			this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginButton.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.LoginButton.Location = new System.Drawing.Point(405, 391);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(151, 38);
			this.LoginButton.TabIndex = 13;
			this.LoginButton.Text = "Login";
			this.LoginButton.UseVisualStyleBackColor = false;
			this.LoginButton.Visible = false;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 441);
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.RegisterButton);
			this.Controls.Add(this.RegisterPassword);
			this.Controls.Add(this.RegisterPasswordLabel);
			this.Controls.Add(this.RegisterEmail);
			this.Controls.Add(this.RegisterEmailLabel);
			this.Controls.Add(this.RegisterEditionLabel);
			this.Controls.Add(this.RegisterEdition);
			this.Controls.Add(this.LoginPassword);
			this.Controls.Add(this.LoginPasswordLabel);
			this.Controls.Add(this.LoginEmail);
			this.Controls.Add(this.LoginEmailLabel);
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
        private System.Windows.Forms.Label LoginEmailLabel;
        private System.Windows.Forms.TextBox LoginEmail;
        private System.Windows.Forms.TextBox LoginPassword;
        private System.Windows.Forms.Label LoginPasswordLabel;
        private System.Windows.Forms.NotifyIcon TrayIcon;
		private System.Windows.Forms.PictureBox Background;
		private System.Windows.Forms.ComboBox RegisterEdition;
		private System.Windows.Forms.Label RegisterEditionLabel;
		private System.Windows.Forms.TextBox RegisterPassword;
		private System.Windows.Forms.Label RegisterPasswordLabel;
		private System.Windows.Forms.TextBox RegisterEmail;
		private System.Windows.Forms.Label RegisterEmailLabel;
		private System.Windows.Forms.Button RegisterButton;
		private System.Windows.Forms.Button LoginButton;
	}
}

