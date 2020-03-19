namespace Launcher
{
	public struct RegisterRequestData
	{
		string email;
		string password;
		string edition;

		public RegisterRequestData(string email, string password, string edition)
		{
			this.email = email;
			this.password = password;
			this.edition = edition;
		}
	}
}
