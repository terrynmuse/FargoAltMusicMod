using Terraria;
using Terraria.ModLoader;

namespace TerryMusicMod
{
	public class TerryMusicSystem : ModSystem
	{
		public static string nowPlayingString = null;
        public static int lastFullVolumeSong = -1;

        public override void PostUpdateEverything()
        {
            if (!Main.dedServ && !Main.gameMenu)
            {
                if (Main.musicFade[Main.curMusic] == 1f && lastFullVolumeSong != Main.curMusic)
                {
                    lastFullVolumeSong = Main.curMusic;
                    //Main.NewText($"{Main.curMusic} {lastFullVolumeSong} {Main.musicFade[Main.curMusic]} {nowPlayingString}");
                    Main.NewText($"Now Playing: {nowPlayingString}", 255, 51, 153);
                }
            }

            nowPlayingString = null;
        }
	}
}