using System;

namespace Launcher
{
	public class LauncherConfig
	{
		public string[] Servers;
		public string Email;
		public string Password;
		public string GamePath;
		public bool MinimizeToTray;

		public LauncherConfig()
		{
			Servers = new string[1] { "https://127.0.0.1" };
			Email = "";
			Password = "";
			GamePath = Environment.CurrentDirectory;
			MinimizeToTray = true;
		}
	}
}
