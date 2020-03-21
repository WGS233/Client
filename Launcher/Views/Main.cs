using System;
using System.Windows.Forms;

namespace Launcher
{
	public partial class Main : Form
	{
		private LauncherConfig launcherConfig;
		private ProcessMonitor monitor;
		private ServerManager serverManager;
		private Account accountManager;
		private GameStarter gameStarter;

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
			accountManager = new Account(launcherConfig);
			gameStarter = new GameStarter();

			ShowServerSelectView();
		}

		private void ShowServerSelectView()
		{
			ServerLabel.Visible = true;

			ServerList.Visible = true;
			ConnectButton.Visible = true;

			// refresh editions as user might switch servers
			ServerList.Items.Clear();

			foreach (ServerInfo server in serverManager.AvailableServers)
			{
				ServerList.Items.Add(server.name);
			}

			if (ServerList.Items.Count == 0)
			{
				ServerList.Enabled = false;
				ConnectButton.Enabled = false;
			}
			else
			{
				ServerList.SelectedIndex = 0;
			}
		}

		private void HideServerSelectView()
		{
			ServerLabel.Visible = false;

			ServerList.Visible = false;
			ConnectButton.Visible = false;
		}

		private void ShowLoginView()
		{
			LoginEmailLabel.Visible = true;
			LoginPasswordLabel.Visible = true;

			LoginEmail.Visible = true;
			LoginPassword.Visible = true;
			LoginButton.Visible = true;
			RegisterInsteadButton.Visible = true;

			LoginEmail.Text = launcherConfig.Email;
			LoginPassword.Text = launcherConfig.Password;
		}

		private void HideLoginView()
		{
			LoginEmailLabel.Visible = false;
			LoginPasswordLabel.Visible = false;
			LoginButton.Visible = false;
			RegisterInsteadButton.Visible = false;

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
			LoginInsteadButton.Visible = true;

			RegisterEmail.Text = launcherConfig.Email;
			RegisterPassword.Text = launcherConfig.Password;

			// refresh editions as user might switch servers
			RegisterEdition.Items.Clear();

			foreach (String edition in serverManager.SelectedServer.editions)
			{
				RegisterEdition.Items.Add(edition);
			}

			if (RegisterEdition.Items.Count == 0)
			{
				RegisterEdition.Enabled = false;
				RegisterButton.Enabled = false;
			}
			else
			{
				RegisterEdition.SelectedIndex = 0;
			}
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
			LoginInsteadButton.Visible = false;
		}

		private void ShowProfileView()
		{
			StartGame.Visible = true;
		}

		private void HideProfileView()
		{
			StartGame.Visible = false;
		}

		private void ConnectButton_Click(object sender, EventArgs e)
		{
			serverManager.SelectServer(ServerList.SelectedIndex);
			RequestHandler.ChangeBackendUrl(serverManager.SelectedServer.backendUrl);

			if (launcherConfig.Email == "" || launcherConfig.Password == "")
			{
				ShowRegisterView();
				return;
			}

			HideServerSelectView();
			ShowLoginView();
		}

		private void LoginButton_Click(object sender, EventArgs e)
		{
			int status = accountManager.Login(LoginEmail.Text, LoginPassword.Text);

			switch (status)
			{
				case 1:
					HideLoginView();
					ShowProfileView();
					break;

				case -1:
					MessageBox.Show("Wrong email and/or password");
					return;

				case -2:
					MessageBox.Show("Cannot establish a connection to the server");
					return;
			}
		}

		private void RegisterButton_Click(object sender, EventArgs e)
		{
			int status = accountManager.Register(RegisterEmail.Text, RegisterPassword.Text, (string)RegisterEdition.SelectedItem);

			switch (status)
			{
				case 1:
					HideRegisterView();
					ShowProfileView();
					break;

				case -1:
					MessageBox.Show("Account already exists");
					return;

				case -2:
					MessageBox.Show("Cannot establish a connection to the server");
					return;

				case -3:
					MessageBox.Show("Wrong email and/or password");
					return;
			}
		}

		private void RegisterInsteadButton_Click(object sender, EventArgs e)
		{
			HideLoginView();
			ShowRegisterView();
		}

		private void LoginInsteadButton_Click(object sender, EventArgs e)
		{
			HideRegisterView();
			ShowLoginView();
		}

		private void StartGame_Click(object sender, EventArgs e)
		{
			int status = gameStarter.LaunchGame(serverManager.SelectedServer, accountManager.SelectedAccount);

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
                    MessageBox.Show("The launcher is not running from the game directory");
                    return;

                default:
                    MessageBox.Show("Unexpected error");
                    return;
            }
		}

		private void GameExitCallback(ProcessMonitor monitor)
		{
			monitor.Stop();
			Show();
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
