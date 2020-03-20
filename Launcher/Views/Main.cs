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
		private ServerManager serverManager;
		private GameStarter gameStarter;
		private Server selectedServer;

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

			// setup controllers
			monitor = new ProcessMonitor("EscapeFromTarkov", 1000, null, GameExitCallback);
			serverManager = new ServerManager();
			gameStarter = new GameStarter();

			// set remote end point
			selectedServer = serverManager.GetServer(0);
			RequestHandler.ChangeBackendUrl(selectedServer.backendUrl);

			// show initial screen
			ShowLoginView();
		}

		private void ShowLoginView()
		{
			// enable input
			LoginEmail.Visible = true;
			LoginPassword.Visible = true;

			// set input
			LoginEmail.Text = Globals.LauncherConfig.Email;
			LoginPassword.Text = Globals.LauncherConfig.Password;
		}

		private void HideLoginView()
		{
			LoginEmail.Visible = false;
			LoginPassword.Visible = false;
		}

		private void GameExitCallback(ProcessMonitor monitor)
		{
			// stop monitoring
			monitor.Stop();

			// show window
			this.Show();
		}

		private void LoginEmail_TextChanged(object sender, EventArgs e)
		{
			// set and save input
			Globals.LauncherConfig.Email = LoginEmail.Text;
			Json.Save<LauncherConfig>(Globals.LauncherConfigFile, Globals.LauncherConfig);
		}

		private void LoginPassword_TextChanged(object sender, EventArgs e)
		{
			// set and save input
			Globals.LauncherConfig.Password = LoginPassword.Text;
			Json.Save<LauncherConfig>(Globals.LauncherConfigFile, Globals.LauncherConfig);
		}

		private void StartGame_Click(object sender, EventArgs e)
		{
            int status = gameStarter.LaunchGame(selectedServer);

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
                    MessageBox.Show("Wrong email and/or password");
                    return;

				case -2:
					MessageBox.Show("Cannot establish a connection to the server");
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
