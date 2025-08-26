using System.ComponentModel;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;

namespace TerryMusicMod
{
    public class MusicConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static MusicConfig Instance => ModContent.GetInstance<MusicConfig>();

        [DefaultValue(true)]
        public bool NowPlaying;

        [DefaultValue(2)]
        [DrawTicks]
        public NowPlayingID NowPlayingEnum;

        [DefaultValue(true)]
        public bool DreamMusic;

        [DefaultValue(true)]
        public bool ItsBrin;

        [DefaultValue(true)]
        public bool MutantFtwZzz;
    }
}
