namespace Launcher
{
	public class Account
	{
		private LauncherConfig launcherConfig;
		public AccountInfo SelectedAccount { get; private set; }

		public Account(LauncherConfig launcherConfig)
		{
			this.launcherConfig = launcherConfig;
			SelectedAccount = null;
		}

		public string Login(string email, string password)
		{
			LoginRequestData data = new LoginRequestData(email, password);
			string loginErrmsg = RequestHandler.GetEmptyResponse(RequestHandler.RequestLogin, data);
			ResponseData<AccountInfo> getResponseData = null;

			if (loginErrmsg != null)
			{
				return loginErrmsg;
			}

			try
			{
				getResponseData = RequestHandler.RequestAccount(data);

				if (getResponseData == null)
				{
					return RequestHandler.InvalidError;
				}

				if (getResponseData.err > 0)
				{
					return getResponseData.errmsg;
				}
			}
			catch
			{
				return RequestHandler.ConnectionError;
			}

			launcherConfig.Email = email;
			launcherConfig.Password = password;
			JsonHandler.SaveLauncherConfig(launcherConfig);

			SelectedAccount = getResponseData.data;
			return null;
		}

		public string Register(string email, string password, string edition)
		{
			RegisterRequestData registerData = new RegisterRequestData(email, password, edition);
			LoginRequestData loginData = new LoginRequestData(email, password);
			string registerErrmsg = RequestHandler.GetEmptyResponse(RequestHandler.RequestRegister, registerData);
			string loginErrmsg = RequestHandler.GetEmptyResponse(RequestHandler.RequestLogin, loginData);

			if (registerErrmsg != null)
			{
				return registerErrmsg;
			}

			if (loginErrmsg != null)
			{
				return loginErrmsg;
			}

			return null;
		}

		public string Remove()
		{
			LoginRequestData data = new LoginRequestData(SelectedAccount.email, SelectedAccount.password);
			string errmsg = RequestHandler.GetEmptyResponse(RequestHandler.RequestRemove, data);

			if (errmsg != null)
			{
				return errmsg;
			}

			launcherConfig.Email = "";
			launcherConfig.Password = "";
			JsonHandler.SaveLauncherConfig(launcherConfig);

			SelectedAccount = null;
			return null;
		}

		public string ChangeEmail(string email)
		{
			ChangeRequestData data = new ChangeRequestData(SelectedAccount.email, SelectedAccount.password, email);
			string errmsg = RequestHandler.GetEmptyResponse(RequestHandler.RequestChangeEmail, data);

			if (errmsg != null)
			{
				return errmsg;
			}

			launcherConfig.Email = email;
			JsonHandler.SaveLauncherConfig(launcherConfig);

			SelectedAccount.email = email;
			return null;
		}

		public string ChangePassword(string password)
		{
			ChangeRequestData data = new ChangeRequestData(SelectedAccount.email, SelectedAccount.password, password);
			string errmsg = RequestHandler.GetEmptyResponse(RequestHandler.RequestChangePassword, data);

			if (errmsg != null)
			{
				return errmsg;
			}

			launcherConfig.Password = password;
			JsonHandler.SaveLauncherConfig(launcherConfig);

			SelectedAccount.password = password;
			return null;
		}

		public string Wipe(string edition)
		{
			RegisterRequestData data = new RegisterRequestData(SelectedAccount.email, SelectedAccount.password, edition);
			string errmsg = RequestHandler.GetEmptyResponse(RequestHandler.RequestWipe, data);

			if (errmsg != null)
			{
				return errmsg;
			}

			SelectedAccount.edition = edition;
			return null;
		}
	}
}
