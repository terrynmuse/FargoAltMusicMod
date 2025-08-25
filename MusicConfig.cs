using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [DefaultValue(true)]
        public bool DreamMusic;

        [DefaultValue(true)]
        public bool ItsBrin;

        [DefaultValue(true)]
        public bool MutantFtwZzz;
    }
}
