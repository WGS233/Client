using System;
using System.Diagnostics;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace Launcher
{
	public partial class Main : Form
	{
		private ProcessMonitor monitor;

		public Main()
		{
			InitializeComponent();
			InitializeLauncher();
		}

		private void InitializeLauncher()
		{
			// load configs
			Globals.LauncherConfig = Json.Load<LauncherConfig>(Globals.LauncherConfigFile);
			Globals.ClientConfig = Json.Load<ClientConfig>(Globals.ClientConfigFile);

			// set input
			EmailInput.Text = Globals.LauncherConfig.Email;
			PasswordInput.Text = Globals.LauncherConfig.Password;
			UrlInput.Text = Globals.LauncherConfig.BackendUrl;

			// setup monitor
			monitor = new ProcessMonitor("EscapeFromTarkov", MonitorCallback);
		}

		private void MonitorCallback(ProcessMonitor monitor)
		{
			// stop monitoring
			monitor.Stop();

			// show window
			this.Show();
		}

		private void EmailInput_TextChanged(object sender, EventArgs e)
		{
			// set and save input
			Globals.LauncherConfig.Email = EmailInput.Text;
			Json.Save<LauncherConfig>(Globals.LauncherConfigFile, Globals.LauncherConfig);
		}

		private void PasswordInput_TextChanged(object sender, EventArgs e)
		{
			// set and save input
			Globals.LauncherConfig.Password = PasswordInput.Text;
			Json.Save<LauncherConfig>(Globals.LauncherConfigFile, Globals.LauncherConfig);
		}

		private void UrlInput_TextChanged(object sender, EventArgs e)
		{
			// set and save input
			Globals.LauncherConfig.BackendUrl = UrlInput.Text;
			Json.Save<LauncherConfig>(Globals.LauncherConfigFile, Globals.LauncherConfig);
		}

		private void StartGame_Click(object sender, EventArgs e)
		{
            int status = GameStarter.LaunchGame();

            switch (status)
            {
                case 1:
                    monitor.Start();

                    if (Globals.LauncherConfig.MinimizeToTray)
                    {
                        TrayIcon.Visible = true;
                        this.Hide();
                    }
                    break;

                case -1:
                    MessageBox.Show("Cannot establish a connection to the server");
                    return;

                case -2:
                    MessageBox.Show("Wrong email and/or password");
                    return;

                case -3:
                    MessageBox.Show("The launcher is not running from the game directory");
                    return;

                default:
                    MessageBox.Show("Unexpected error");
                    return;
            }
		}

		private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void Main_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				TrayIcon.Visible = false;
			}
		}
	}
}
