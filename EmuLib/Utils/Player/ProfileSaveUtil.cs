using EFT;
using EmuLib.Utils.HTTP;

namespace EmuLib.Utils.Player
{
	internal static class ProfileSaveUtil
	{
		public static void SaveProfileProgress(EFT.Profile profileData, ExitStatus exitStatus, string session, bool isPlayerScav)
		{
			SaveProfileRequest request = new SaveProfileRequest { exit = exitStatus.ToString().ToLower(), profile = profileData, isPlayerScav = isPlayerScav };
			string requestData = request.ToJson();

			new HttpUtils.Create(session).Post("/OfflineRaidSave", requestData, true);
		}
	}

	public class SaveProfileRequest
	{
		public string exit = "left";
		public Profile profile;
		public bool isPlayerScav;
	}
}