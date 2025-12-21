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
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ OST 214";
                    break;

                case MusicID.TownNight:
                    i = GetMusic("BlueArchive198");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ OST 198";
                    break;

                case MusicID.OverworldDay:
                case MusicID.AltOverworldDay:
                    if (config.DreamMusic)
                    {
                        i = GetMusic("TranceMusicForRacingGame");
                        TerryMusicSystem.nowPlayingString = "He Is Just Very Lucky ~ Trance Music For Racing Game";
                    }
                    else
                    {
                        i = GetMusic("MischievousStep");
                        TerryMusicSystem.nowPlayingString = "Blue Archive ~ Mischievous Step";
                    }
                    break;

                case MusicID.Night:
                    i = GetMusic("BeneathTheMask");
                    TerryMusicSystem.nowPlayingString = "Persona 5 ~ Beneath the Mask";
                    break;

                case MusicID.WindyDay:
                    if (config.CopyrightMode)
                    {
                        i = GetMusic("FoolishDays");
                        TerryMusicSystem.nowPlayingString = "Blue Archive ~ Foolish Days";
                    }
                    else
                    {
                        i = GetMusic("LiteralClownMusic");
                        TerryMusicSystem.nowPlayingString = "Actual Literal Clown Music";
                    }
                    break;

                case MusicID.Underground:
                case MusicID.AltUnderground:
                    i = GetMusic("SlipperySteps");
                    TerryMusicSystem.nowPlayingString = "Kirby's Return to Dream Land ~ Slippery Steps";
                    break;

                case MusicID.Desert:
                case MusicID.UndergroundDesert:
                    i = GetMusic("RockStar");
                    TerryMusicSystem.nowPlayingString = "Kirby 64 ~ Rock Star";
                    break;

                case MusicID.Snow:
                case MusicID.Ice:
                    i = GetMusic("FrozenHillside");
                    TerryMusicSystem.nowPlayingString = "Kirby Air Ride ~ Frozen Hillside";
                    break;

                case MusicID.Jungle:
                case MusicID.JungleNight:
                    if (config.ItsBrin)
                    {
                        i = GetMusic("MattMVSNewZeldaForestTempleMusicITSBRIN");
                        TerryMusicSystem.nowPlayingString = "Matt MVS ~ New Zelda Forest Temple Music (IT'S BRIN)";
                    }
                    else
                    {
                        goto case MusicID.JungleUnderground;
                    }
                    break;

                case MusicID.JungleUnderground:
                    i = GetMusic("Brinstar");
                    TerryMusicSystem.nowPlayingString = "Super Metroid ~ Brinstar";
                    break;

                case MusicID.TheHallow:
                    i = GetMusic("SkyHighBridge");
                    TerryMusicSystem.nowPlayingString = "Rabi-Ribi ~ Sky High Bridge";
                    break;

                case MusicID.UndergroundHallow:
                    i = GetMusic("WarpDestination");
                    TerryMusicSystem.nowPlayingString = "Rabi-Ribi ~ Warp Destination";
                    break;

                case MusicID.Corruption:
                    i = GetMusic("WorldOfNothing");
                    TerryMusicSystem.nowPlayingString = "Super Paper Mario ~ World of Nothing";
                    break;

                case MusicID.UndergroundCorruption:
                    i = GetMusic("RiverTwygzBed");
                    TerryMusicSystem.nowPlayingString = "Super Paper Mario ~ River Twygz Bed";
                    break;

                case MusicID.Crimson:
                    i = GetMusic("ZeroMissionTourianKassil");
                    TerryMusicSystem.nowPlayingString = "Metroid Zero Mission ~ Tourian (Arranged by Kassil)";
                    break;

                case MusicID.UndergroundCrimson:
                    i = GetMusic("SuperMetroidTourian");
                    TerryMusicSystem.nowPlayingString = "Super Metroid ~ Tourian";
                    break;

                case MusicID.Ocean:
                    i = GetMusic("WateryGraves");
                    TerryMusicSystem.nowPlayingString = "Plants vs Zombies ~ Watery Graves";
                    break;

                case MusicID.OceanNight:
                    i = GetMusic("LowerSector4Kassil");
                    TerryMusicSystem.nowPlayingString = "Metroid Fusion ~ Lower Sector 4 (Arranged by Kassil)";
                    break;

                case MusicID.Space:
                case MusicID.SpaceDay:
                    if (config.CopyrightMode)
                    {
                        i = GetMusic("AuroraPalace");
                        TerryMusicSystem.nowPlayingString = "Rabi-Ribi ~ Aurora Palace";
                    }
                    else
                    {
                        i = GetMusic("ShadyShady");
                        TerryMusicSystem.nowPlayingString = "Sakuzyo ~ ShadyShady";
                    }
                    break;

                case MusicID.Hell:
                    i = GetMusic("TheOnlyThingTheyFearIsYou");
                    TerryMusicSystem.nowPlayingString = "DOOM Eternal ~ The Only Thing They Fear Is You";
                    break;

                case MusicID.Mushrooms:
                    i = GetMusic("AfterSchoolDessert");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ After School Dessert";
                    break;

                case MusicID.Dungeon:
                    i = GetMusic("CastleBleck");
                    TerryMusicSystem.nowPlayingString = "Super Paper Mario ~ Castle Bleck";
                    break;

                case MusicID.Temple:
                    i = GetMusic("WanderingGhosts");
                    TerryMusicSystem.nowPlayingString = "Castlevania Symphony of the Night ~ Wandering Ghosts";
                    break;

                case MusicID.Rain:
                case MusicID.MorningRain:
                    i = GetMusic("UnfamiliarPlace");
                    TerryMusicSystem.nowPlayingString = "Rabi-Ribi ~ Unfamiliar Place";
                    break;

                case MusicID.Monsoon:
                    i = GetMusic("BlueArchive202");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ OST 202";
                    break;

                case MusicID.Graveyard:
                    i = GetMusic("GestaltAngst");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ Gestalt Angst";
                    break;

                case MusicID.Eerie:
                    i = GetMusic("StepOfTerror");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ Step of Terror";
                    break;

                case MusicID.Sandstorm:
                    i = GetMusic("EndlessCarnival");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ Endless Carnival";
                    break;

                case MusicID.Shimmer:
                    i = GetMusic("SongOfTheAncientsDuet");
                    TerryMusicSystem.nowPlayingString = "NieR ~ Song of the Ancients (Duet)";
                    break;

                case MusicID.GoblinInvasion:
                    i = GetMusic("CamelliaGoldenWeekCombat");
                    TerryMusicSystem.nowPlayingString = "Zenless Zone Zero ~ Camellia Golden Week (Combat)";
                    break;

                case MusicID.TheTowers:
                    i = GetMusic("OurOath");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ Our Oath";
                    break;

                case MusicID.SlimeRain:
                    i = GetMusic("UnwelcomeSchool");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ Unwelcome School";
                    break;

                case MusicID.Boss1:
                    i = GetMusic("XNautFortress");
                    TerryMusicSystem.nowPlayingString = "Paper Mario TTYD ~ X-Naut Fortress";
                    break;

                case MusicID.Boss2:
                    i = GetMusic("DemetoriNecrofantasia");
                    TerryMusicSystem.nowPlayingString = "Demetori ~ Necrofantasia";
                    break;

                case MusicID.Boss3:
                    if (Main.invasionType == InvasionID.SnowLegion)
                        goto case MusicID.SlimeRain;
                    i = GetMusic("DiverseSystemNightmareParadiseAbridged");
                    TerryMusicSystem.nowPlayingString = "Diverse System ~ Nightmare Paradise (Abridged)";
                    break;

                case MusicID.Boss4:
                    i = GetMusic("Chokmah232");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ OST 232 (Chokmah)";
                    break;

                case MusicID.Boss5:
                    i = GetMusic("RegnumCaelorumEtGehennaVerumCurNonAudimus");
                    TerryMusicSystem.nowPlayingString = "Regnum Caelorum Et Gehenna ~ Verum Cur Non Audimus";
                    break;

                case MusicID.Deerclops:
                    i = GetMusic("NoHesitation");
                    TerryMusicSystem.nowPlayingString = "Jujutsu Kaisen ~ No Hesitation (Abridged)";
                    break;

                case MusicID.QueenSlime:
                    i = GetMusic("DededeDrumDashDeluxeCROWNED");
                    TerryMusicSystem.nowPlayingString = "Dedede's Drum Dash Deluxe ~ C-R-O-W-N-E-D";
                    break;

                case MusicID.Plantera:
                    i = GetMusic("Gekkasakuya");
                    TerryMusicSystem.nowPlayingString = "Magia Record ~ Gekkasakuya";
                    break;

                case MusicID.EmpressOfLight:
                    i = GetMusic("BorderOfLifeResurrectionButterfly");
                    TerryMusicSystem.nowPlayingString = "Touhou PCB ~ Border of Life / Resurrection Butterfly";
                    break;

                case MusicID.DukeFishron:
                    i = GetMusic("CannonBallMythos");
                    TerryMusicSystem.nowPlayingString = "Megaman Zero ~ Cannon Ball (Mythos)";
                    break;

                case MusicID.LunarBoss:
                    i = GetMusic("FuryOfSet");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ FURY OF SET";
                    break;

                case MusicID.PirateInvasion:
                    i = GetMusic("DanDanInvader");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ DAN! DAN!! INVADER!!!";
                    break;

                case MusicID.Eclipse:
                    i = GetMusic("RaisiKTheBattleThunderblunder777");
                    TerryMusicSystem.nowPlayingString = "Raisi K. ~ The Battle (Theme of Thunderblunder777)";
                    break;

                case MusicID.PumpkinMoon:
                    i = GetMusic("KoyoiWaHalloweenNight");
                    TerryMusicSystem.nowPlayingString = "HoloCure ~ Koyoi Wa Halloween Night!";
                    break;

                case MusicID.FrostMoon:
                    i = GetMusic("TtydBattleChapter7");
                    TerryMusicSystem.nowPlayingString = "Paper Mario The Thousand Year Door ~ Combat (Chapter 7)";
                    break;

                case MusicID.OldOnesArmy:
                    i = GetMusic("OperationDOTABATA");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ Operation DOTABATA";
                    break;

                case MusicID.MartianMadness:
                    i = GetMusic("SystemInterior");
                    TerryMusicSystem.nowPlayingString = "Rabi-Ribi ~ System Interior";
                    break;

                case MusicID.Title:
                case MusicID.MenuMusic:
                case MusicID.Credits:
                    i = GetMusic("ConstantModerato");
                    TerryMusicSystem.nowPlayingString = "Blue Archive ~ Constant Moderato";
                    break;
            }
            if (TerryMusicMod.Instance.moddedMusicDict.ContainsKey(i))
            {
                var tuple = TerryMusicMod.Instance.moddedMusicDict[i];
                //Main.NewText($"get! {i} {tuple.ToString()}");
                i = GetMusic(tuple.Item1);
                TerryMusicSystem.nowPlayingString = tuple.Item2;
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
