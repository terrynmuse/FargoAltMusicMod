using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerryMusicMod
{
    public class MusicSystem : ModSystem
    {
        public static int GetMusic(string name) => MusicLoader.GetMusicSlot(TerryMusicMod.Instance, $"Music/{name}");

        private const BindingFlags UniversalBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        public override void Load()
        {
            MonoModHooks.Add(Update, Update_Detour);
        }

        public static int OverrideMusicID(int i)
        {
            if (Main.gameMenu)
                return i;
            int old = i;
            var config = MusicConfig.Instance;
            switch (i)
            {
                case MusicID.TownDay:
                    i = GetMusic("Natsucore214");
                    break;

                case MusicID.TownNight:
                    i = GetMusic("BlueArchive198");
                    break;

                case MusicID.OverworldDay:
                case MusicID.AltOverworldDay:
                    if (config.DreamMusic)
                    {
                        i = GetMusic("TranceMusicForRacingGame");
                    }
                    else
                    {
                        i = GetMusic("MischievousStep");
                    }
                    break;

                case MusicID.Night:
                    i = GetMusic("BeneathTheMask");
                    break;

                case MusicID.WindyDay:
                    i = GetMusic("LiteralClownMusic");
                    break;

                case MusicID.Underground:
                case MusicID.AltUnderground:
                    i = GetMusic("SlipperySteps");
                    break;

                case MusicID.Desert:
                case MusicID.UndergroundDesert:
                    i = GetMusic("RockStar");
                    break;

                case MusicID.Snow:
                case MusicID.Ice:
                    i = GetMusic("FrozenHillside");
                    break;

                case MusicID.Jungle:
                case MusicID.JungleNight:
                    if (config.ItsBrin)
                        i = GetMusic("MattMVSNewZeldaForestTempleMusicITSBRIN");
                    else
                        goto case MusicID.JungleUnderground;
                    break;

                case MusicID.JungleUnderground:
                    i = GetMusic("Brinstar");
                    break;

                case MusicID.TheHallow:
                    i = GetMusic("SkyHighBridge");
                    break;

                case MusicID.UndergroundHallow:
                    i = GetMusic("WarpDestination");
                    break;

                case MusicID.Corruption:
                    i = GetMusic("WorldOfNothing");
                    break;

                case MusicID.UndergroundCorruption:
                    i = GetMusic("RiverTwygzBed");
                    break;

                case MusicID.Crimson:
                    i = GetMusic("ZeroMissionTourianKassil");
                    break;

                case MusicID.UndergroundCrimson:
                    i = GetMusic("SuperMetroidTourian");
                    break;

                case MusicID.Ocean:
                    i = GetMusic("WateryGraves");
                    break;

                case MusicID.OceanNight:
                    i = GetMusic("LowerSector4Kassil");
                    break;

                case MusicID.Space:
                case MusicID.SpaceDay:
                    i = GetMusic("ShadyShady");
                    break;

                case MusicID.Hell:
                    i = GetMusic("TheOnlyThingTheyFearIsYou");
                    break;

                case MusicID.Mushrooms:
                    i = GetMusic("AfterSchoolDessert");
                    break;

                case MusicID.Dungeon:
                    i = GetMusic("CastleBleck");
                    break;

                case MusicID.Temple:
                    i = GetMusic("WanderingGhosts");
                    break;

                case MusicID.Rain:
                case MusicID.MorningRain:
                    i = GetMusic("UnfamiliarPlace");
                    break;

                case MusicID.Monsoon:
                    i = GetMusic("BlueArchive202");
                    break;

                case MusicID.Graveyard:
                    i = GetMusic("GestaltAngst");
                    break;

                case MusicID.Eerie:
                    i = GetMusic("StepOfTerror");
                    break;

                case MusicID.Sandstorm:
                    i = GetMusic("EndlessCarnival");
                    break;

                case MusicID.GoblinInvasion:
                    i = GetMusic("CamelliaGoldenWeekCombat");
                    break;

                case MusicID.Boss3:
                    if (Main.invasionType == InvasionID.SnowLegion)
                        i = GetMusic("UnwelcomeSchool");
                    break;

                case MusicID.PirateInvasion:
                    i = GetMusic("DanDanInvader");
                    break;

                case MusicID.Eclipse:
                    i = GetMusic("RaisiKTheBattleThunderblunder777");
                    break;

                case MusicID.PumpkinMoon:
                    i = GetMusic("KoyoiWaHalloweenNight");
                    break;

                case MusicID.FrostMoon:
                    i = GetMusic("TtydBattleChapter7");
                    break;

                case MusicID.OldOnesArmy:
                    i = GetMusic("OperationDOTABATA");
                    break;

                case MusicID.MartianMadness:
                    i = GetMusic("SystemInterior");
                    break;
            }
            if (i >= Main.musicFade.Length)
                return old;
            return i;
        }

        private static readonly MethodInfo Update = typeof(LegacyAudioSystem).GetMethod("Update", UniversalBindingFlags);
        public delegate void Orig_Update(LegacyAudioSystem self);
        internal static void Update_Detour(Orig_Update orig, LegacyAudioSystem self)
        {
            Main.newMusic = OverrideMusicID(Main.newMusic);
            orig(self);
        }
    }
}
