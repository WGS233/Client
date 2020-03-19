namespace Launcher
{
	public static class RequestHandler
	{
		private static Request request = new Request();

		public static string GetBackendUrl()
		{
			return request.url;
		}

		public static void ChangeBackendUrl()
		{
			request.url = Globals.LauncherConfig.Servers[Globals.LauncherConfig.Backend];
		}

		public static string RequestConnect()
		{
			return request.Send("/launcher/server/connect", "{}");
		}

		public static string RequestEditions()
		{
			return request.Send("/launcher/server/editions", "{}");
		}

		public static string RequestLogin(LoginRequestData data)
		{
			return request.Send("/launcher/profile/login", Json.Serialize(data));
		}

		public static string RequestRegister(RegisterRequestData data)
		{
			return request.Send("/launcher/profile/register", Json.Serialize(data));
		}

		public static string RequestRemove(LoginRequestData data)
		{
			return request.Send("/launcher/profile/remove", Json.Serialize(data));
		}

		public static string RequestGet(LoginRequestData data)
		{
			return request.Send("/launcher/profile/get", Json.Serialize(data));
		}

		public static string RequestChangeEmail(ChangeRequestData data)
		{
			return request.Send("/launcher/profile/change/email", Json.Serialize(data));
		}

		public static string RequestChangePassword(ChangeRequestData data)
		{
			return request.Send("/launcher/profile/change/password", Json.Serialize(data));
		}

		public static string RequestWipe(RegisterRequestData data)
		{
			return request.Send("/launcher/profile/change/wipe", Json.Serialize(data));
		}
	}
}
