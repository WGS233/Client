using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Launcher
{
	public partial class Main : Form
	{
		private LauncherConfig launcherConfig;
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
			launcherConfig = JsonHandler.LoadLauncherConfig();
			monitor = new ProcessMonitor("EscapeFromTarkov", 1000, aliveCallback: null, exitCallback: GameExitCallback);
			serverManager = new ServerManager(launcherConfig.Servers);
			gameStarter = new GameStarter();

			selectedServer = serverManager.GetServer(0);

			if (selectedServer == null)
			{
				MessageBox.Show("No servers available");
			}
			else
			{
				RequestHandler.ChangeBackendUrl(selectedServer.backendUrl);

				// ShowLoginView();
				HideLoginView();
				ShowRegisterView();
			}
		}

		private void ShowLoginView()
		{
			LoginEmailLabel.Visible = true;
			LoginPasswordLabel.Visible = true;

			LoginEmail.Visible = true;
			LoginPassword.Visible = true;

			LoginEmail.Text = launcherConfig.Email;
			LoginPassword.Text = launcherConfig.Password;
		}

		private void HideLoginView()
		{
			LoginEmailLabel.Visible = false;
			LoginPasswordLabel.Visible = false;

			LoginEmail.Visible = false;
			LoginPassword.Visible = false;
		}

		private void ShowRegisterView()
		{
			RegisterEmailLabel.Visible = true;
			RegisterPasswordLabel.Visible = true;
			RegisterEditionLabel.Visible = true;

			RegisterEmail.Visible = true;
			RegisterPassword.Visible = true;
			RegisterEdition.Visible = true;
			RegisterButton.Visible = true;

			RegisterEmail.Text = launcherConfig.Email;
			RegisterPassword.Text = launcherConfig.Password;

			// refresh editions as user might switch servers
			RegisterEdition.Items.Clear();

			foreach (String edition in selectedServer.editions)
			{
				RegisterEdition.Items.Add(edition);
			}

			if (RegisterEdition.Items.Count == 0)
			{
				RegisterEdition.Items.Add("No edition available");
				RegisterButton.Enabled = false;
			}

			RegisterEdition.SelectedIndex = 0;
		}

		private void HideRegisterView()
		{
			RegisterEmailLabel.Visible = false;
			RegisterPasswordLabel.Visible = false;
			RegisterEditionLabel.Visible = false;

			RegisterEmail.Visible = false;
			RegisterPassword.Visible = false;
			RegisterEdition.Visible = false;
			RegisterButton.Visible = false;
		}

		private void ShowServerView()
		{
			foreach (Server server in serverManager.AvailableServers)
			{
				// code here
			}
		}

		private void GameExitCallback(ProcessMonitor monitor)
		{
			monitor.Stop();
			Show();
		}

		private void LoginEmail_TextChanged(object sender, EventArgs e)
		{
			launcherConfig.Email = LoginEmail.Text;
			JsonHandler.SaveLauncherConfig(launcherConfig);
		}

		private void LoginPassword_TextChanged(object sender, EventArgs e)
		{
			launcherConfig.Password = LoginPassword.Text;
			JsonHandler.SaveLauncherConfig(launcherConfig);
		}

		private void StartGame_Click(object sender, EventArgs e)
		{
			LoginRequestData loginData = new LoginRequestData(launcherConfig.Email, launcherConfig.Password);
			int status = gameStarter.LaunchGame(selectedServer, loginData);

            switch (status)
            {
                case 1:
                    monitor.Start();

                    if (launcherConfig.MinimizeToTray)
                    {
                        TrayIcon.Visible = true;
                        Hide();
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
			Show();
			WindowState = FormWindowState.Normal;
		}

		private void Main_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Normal)
			{
				TrayIcon.Visible = false;
			}
		}
	}
}
