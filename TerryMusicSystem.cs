using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using TerryMusicMod.UI;

namespace TerryMusicMod
{
	public class TerryMusicSystem : ModSystem
	{
		public static string nowPlayingString = null;
        public static int lastFullVolumeSong = -1;
        public static Color TextColor => new Color(255, 160, 230);

        public override void PostUpdateEverything()
        {
            if (!Main.dedServ && !Main.gameMenu)
            {
                if (Main.musicFade[Main.curMusic] == 1f && lastFullVolumeSong != Main.curMusic)
                {
                    lastFullVolumeSong = Main.curMusic;
                    //Main.NewText($"{Main.curMusic} {lastFullVolumeSong} {Main.musicFade[Main.curMusic]} {nowPlayingString}");
                    if (MusicConfig.Instance.NotifyNowPlaying)
                    {
                        InGameNotificationsTracker.Clear();
                        InGameNotificationsTracker.AddNotification(new NowPlayingNotif($"Now Playing: {nowPlayingString}"));
                    }
                    else
                    {
                        Main.NewText($"Now Playing: {nowPlayingString}", 255, 51, 153);
                    }
                }
            }

            nowPlayingString = null;
        }
	}
}