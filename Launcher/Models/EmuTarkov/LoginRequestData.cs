namespace Launcher
{
	public struct LoginRequestData
	{
		string email;
		string password;

		public LoginRequestData(string email, string password)
		{
			this.email = email;
			this.password = password;
		}
	}
}
