using Terraria.ModLoader;

namespace FargoAltMusicMod
{
	public class FargoAltMusicMod : Mod
	{
		internal static FargoAltMusicMod Instance;
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