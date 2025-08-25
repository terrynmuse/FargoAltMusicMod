using Terraria.ModLoader;

namespace TerryMusicMod
{
	public class TerryMusicMod : Mod
	{
		internal static TerryMusicMod Instance;
		public override void Load()
		{
			Instance = this;
		}
		public override void Unload()
		{
			Instance = null;
		}
	}
}