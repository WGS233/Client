using System;
using System.Windows.Forms;

namespace Launcher
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			AssemblyLoader assemblyLoader = new AssemblyLoader("EscapeFromTarkov_Data/Managed/");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
		}
	}
}
