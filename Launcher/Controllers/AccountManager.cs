namespace Launcher
{
	public class AccountManager
	{
		private LauncherConfig launcherConfig;
		public AccountInfo SelectedAccount { get; private set; }

		public AccountManager(LauncherConfig launcherConfig)
		{
			this.launcherConfig = launcherConfig;
			SelectedAccount = null;
		}

		public int LoginAccount(string email, string password)
		{
			LoginRequestData loginData = new LoginRequestData(email, password);
			string accountId = "";
			string accountJson = "";

			try
			{
				accountId = RequestHandler.RequestLogin(loginData);
				accountJson = RequestHandler.RequestAccount(loginData);

				if (accountId == "0")
					return -1;
			}
            catch
            {
                return -2;
            }

			SelectedAccount = Json.Deserialize<AccountInfo>(accountJson);

			launcherConfig.Email = email;
			launcherConfig.Password = password;
			JsonHandler.SaveLauncherConfig(launcherConfig);

			return 1;
		}

		public int RegisterAccount(string email, string password, string edition)
		{
			RegisterRequestData registerData = new RegisterRequestData(email, password, edition);
			string registerStatus = "";

			try
			{
				registerStatus = RequestHandler.RequestRegister(registerData);

				if (registerStatus != "OK")
					return -1;
			}
			catch
			{
				return -2;
			}

			int loginStatus = LoginAccount(email, password);
			
			if (loginStatus != 1)
			{
				switch (loginStatus)
				{
					case -1:
						return -3;

					case -2:
						return -2;
				}
			}

			return 1;
		}
	}
}
