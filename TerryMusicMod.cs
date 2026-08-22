using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace TerryMusicMod
{
	public class TerryMusicMod : Mod
	{
		internal static TerryMusicMod Instance;
        public int ChampionsSlot = 0;
		public override void Load()
		{
			Instance = this;
		}
		public override void Unload()
		{
			Instance = null;
		}

		public Dictionary<int, Tuple<string, string>> moddedMusicDict = new Dictionary<int, Tuple<string, string>>();

        void TryMapMusic(int musicId, string newMusicIdPath, string newMusicName)
        {
            if (musicId == 0)
                return;
            moddedMusicDict.Add(musicId, new Tuple<string, string>(newMusicIdPath, newMusicName));
        }

        public override void PostSetupContent()
        {
            if (MusicConfig.Instance.OverrideModdedMusicBoxes && ModLoader.TryGetMod("FargowiltasMusic", out Mod musicMod))
            {
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Baron"),
                    "BREISXVsZeroDecisiveBattle2",
                    "BREIS ~ X Vs Zero Decisive Battle 2"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Baron2"),
                    "BREISXVsZeroDecisiveBattle2",
                    "BREIS ~ X Vs Zero Decisive Battle 2"
                );
                // Store the combined Champions slot for special-casing in the
                // music override logic. Do NOT map it to a single song here;
                // instead `MusicSystem.OverrideMusicID` will inspect which
                // champion is active and choose the correct internal track.
                ChampionsSlot = MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Champions");
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Laevateinn_P1"),
                    "Showdown",
                    "Project Wingman ~ Showdown"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Laevateinn_P2"),
                    "Showdown",
                    "Project Wingman ~ Showdown"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/LieFlightNoCum"),
                    "SEQUELcolonyKizuato",
                    "SEQUEL colony ~ Kizuato"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/PlatinumStar"),
                    "SuddenDeath",
                    "Rabi-Ribi ~ Sudden Death"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/SteelRed"),
                    "SupremeRulersCoronationOVERLORD",
                    "Kirby RTDL Deluxe ~ Supreme Ruler's Coronation - OVERLORD"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Strawberry_Sparkly_Sunrise"),
                    "UsagiFlap",
                    "Blue Archive ~ Usagi Flap"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/Storia"),
                    "BattleTrialsGlory",
                    "Zenless Zone Zero ~ Battle Trials (Glory)"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/TrojanSquirrel"),
                    "HoloCureSuspect",
                    "HoloCure ~ Suspect"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/WillChampion"),
                    "MamoruKunHasBeenCursedWillForce",
                    "Mamoru-kun Wa Norowarete Shimatta! ~ Will Force"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/rePrologue"),
                    "SupremeRulersCoronationOVERLORD",
                    "Kirby RTDL Deluxe ~ Supreme Ruler's Coronation - OVERLORD"
                );
                TryMapMusic(
                    MusicLoader.GetMusicSlot(musicMod, "Assets/Music/ShiftingSands"),
                    "ShiftingSandLand",
                    "Super Mario 64 ~ Shifting Sand Land"
                );
            }
        }
	}
}