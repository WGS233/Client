using System;

namespace Launcher
{
	public class LauncherConfig
	{
		public string[] Servers;
		public string Email;
		public string Password;
		public string GamePath;
		public string BackendUrl;
		public bool MinimizeToTray;

		public LauncherConfig()
		{
			Servers[0] = "https://127.0.0.1";
			Email = "user@emutarkov.com";
			Password = "password";
			GamePath = Environment.CurrentDirectory;
			MinimizeToTray = true;
		}
	}
}
