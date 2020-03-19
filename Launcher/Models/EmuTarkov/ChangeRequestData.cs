namespace Launcher
{
	public struct ChangeRequestData
	{
		string email;
		string password;
		string change;

		public ChangeRequestData(string email, string password, string change)
		{
			this.email = email;
			this.password = password;
			this.change = change;
		}
	}
}
