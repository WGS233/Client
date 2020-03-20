using System;
using System.IO;

namespace Launcher
{
	public static class JsonHandler
	{
		private static string filepath;

		static JsonHandler()
		{
			filepath = Environment.CurrentDirectory;
		}

		public static LauncherConfig LoadLauncherConfig()
		{
			return Json.Load<LauncherConfig>(Path.Combine(filepath, "launcher.config.json"));
		}

		public static void SaveLauncherConfig(LauncherConfig data)
		{
			Json.Save<LauncherConfig>(Path.Combine(filepath, "launcher.config.json"), data);
		}

		public static ClientConfig LoadClientConfig()
		{
			return Json.Load<ClientConfig>(Path.Combine(filepath, "client.config.json"));
		}

		public static void SaveClientConfig(ClientConfig data)
		{
			Json.Save<ClientConfig>(Path.Combine(filepath, "client.config.json"), data);
		}
	}
}
