using UnityEngine;

namespace EmuLib.Hooks
{
	public class Loader
	{
		public static GameObject HookObject
		{
			get
			{
				GameObject result = GameObject.Find("EmuTarkov");

				if (result == null)
				{
					result = new GameObject("EmuTarkov");
					Object.DontDestroyOnLoad(result);
				}

				return result;
			}
		}

		public static void Load()
		{
			HookObject.GetOrAddComponent<EmuInstance>();
		}
	}
}
