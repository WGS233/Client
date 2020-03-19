namespace Launcher
{
	public static class RequestHandler
	{
		private static Request request = new Request();

		public static void ChangeBackendUrl(string url)
		{
			request.ChangeBackendUrl(url);
		}

		public static string Login(LoginRequestData data)
		{
			return request.Send("/launcher/profile/login", Json.Serialize(data));
		}

		public static string Register(RegisterRequestData data)
		{
			return request.Send("/launcher/profile/register", Json.Serialize(data));
		}

		public static string Remove(LoginRequestData data)
		{
			return request.Send("/launcher/profile/remove", Json.Serialize(data));
		}

		public static string Get(LoginRequestData data)
		{
			return request.Send("/launcher/profile/get", Json.Serialize(data));
		}

		public static string ChangeEmail(ChangeRequestData data)
		{
			return request.Send("/launcher/profile/change/email", Json.Serialize(data));
		}

		public static string ChangePassword(ChangeRequestData data)
		{
			return request.Send("/launcher/profile/change/password", Json.Serialize(data));
		}

		public static string Wipe(RegisterRequestData data)
		{
			return request.Send("/launcher/profile/change/wipe", Json.Serialize(data));
		}
	}
}
