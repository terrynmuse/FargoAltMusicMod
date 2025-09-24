using System.Linq;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Events;
using static Terraria.Main;
using Microsoft.CodeAnalysis;
using System;

namespace TerryMusicMod
{
    static class MusicUtils
    {
        private static Mod souls = null;
        private static bool checkedSouls = false;
        public static Mod Souls
        {
            get
            {
                if (!checkedSouls)
                {
                    checkedSouls = true;
                    if (ModLoader.HasMod("FargowiltasSouls"))
                        souls = ModLoader.GetMod("FargowiltasSouls");
                }
                return souls;
            }
        }
        public static NPC FindClosestBoss(int type)
        {
            float num = 99999;
            NPC closestNPC = null;
            foreach (NPC npc in npc.Where(n => n != null && n.active && n.type == type))
            {
                if (npc.BossMusicRange() && npc.Distance(LocalPlayer.Center) < num)
                {
                    num = npc.Distance(LocalPlayer.Center);
                    closestNPC = npc;
                }
            }
            return closestNPC;
        }

        public static NPC FindClosestSoulsBoss(string name)
        {
            if (MusicUtils.Souls == null)
                return null;
            return FindClosestBoss(Souls.Find<ModNPC>(name).Type);
        }

        public static bool ZoneShallow(this Player player) => player.ZoneDirtLayerHeight || player.ZoneOverworldHeight;

        public static bool ZoneUnderground(this Player player) => player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight;

        public static bool BossMusicRange(this NPC npc)
        {
            int range = 5500;
            Rectangle value = new Rectangle((int)(npc.position.X + (float)(npc.width / 2)) - range, (int)(npc.position.Y + (float)(npc.height / 2)) - range, range * 2, range * 2);
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            return (rectangle.Intersects(value));
        }

        public static NPC FirstPillarInRange()
        {
            int[] pillarTypes = [
                NPCID.LunarTowerSolar,
                NPCID.LunarTowerVortex,
                NPCID.LunarTowerNebula,
                NPCID.LunarTowerStardust,
            ];
            return Main.npc.FirstOrDefault(npc => npc.active && pillarTypes.Contains(npc.type) && BossMusicRange(npc), null);
        }

    }

    public class VanillaMusic : ModSystem
    {
        public static int Current = 0;
        // This is the entire vanilla music choice method. Edited to update CurrentVanillaMusic rather than Main.curMusic.
        #region Vanilla Music Update
        public override void PostUpdateEverything()
        {
            return;
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            bool flag7 = false;
            bool flag8 = false;
            bool flag9 = false;
            bool flag10 = false;
            bool flag11 = false;
            bool flag12 = false;
            bool flag13 = false;
            bool flag14 = false;
            bool flag15 = false;
            bool flag16 = false;
            bool flag17 = false;
            bool flag18 = LocalPlayer.townNPCs > 2f;
            bool flag19 = slimeRain;
            if (Main.SceneMetrics.ShadowCandleCount > 0 || LocalPlayer.inventory[LocalPlayer.selectedItem].type == 5322)
            {
                flag18 = false;
            }
            float num = 0f;
            /*
            for (int i = 0; i < maxMusic; i++)
            {
                if (musicFade[i] > num)
                {
                    num = musicFade[i];
                    if (num == 1f)
                    {
                        lastMusicPlayed = i;
                    }
                }
            }
            */
            /*
            if (lastMusicPlayed == 50)
            {
                musicNoCrossFade[51] = true;
            }
            */
            if (!showSplash)
            {
                Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle((int)screenPosition.X, (int)screenPosition.Y, screenWidth, screenHeight);
                int num2 = 5000;
                for (int j = 0; j < 200; j++)
                {
                    if (!npc[j].active)
                    {
                        continue;
                    }
                    num2 = 5000;
                    int num3 = 0;
                    switch (npc[j].type)
                    {
                        case 13:
                        case 14:
                        case 15:
                        case 127:
                        case 128:
                        case 129:
                        case 130:
                        case 131:
                            num3 = 1;
                            break;
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 111:
                        case 471:
                            num3 = 11;
                            break;
                        case 113:
                        case 114:
                        case 125:
                        case 126:
                            num3 = 2;
                            break;
                        case 134:
                        case 135:
                        case 136:
                        case 143:
                        case 144:
                        case 145:
                        case 266:
                            num3 = 3;
                            break;
                        case 212:
                        case 213:
                        case 214:
                        case 215:
                        case 216:
                        case 491:
                            num3 = 8;
                            break;
                        case 245:
                            num3 = 4;
                            break;
                        case 222:
                            num3 = 5;
                            break;
                        case 262:
                        case 263:
                        case 264:
                            num3 = 6;
                            break;
                        case 381:
                        case 382:
                        case 383:
                        case 385:
                        case 386:
                        case 388:
                        case 389:
                        case 390:
                        case 391:
                        case 395:
                        case 520:
                            num3 = 9;
                            break;
                        case 398:
                            num3 = 7;
                            break;
                        case 422:
                        case 493:
                        case 507:
                        case 517:
                            num3 = 10;
                            break;
                        case 439:
                            num3 = 4;
                            break;
                        case 438:
                            if (npc[j].ai[1] == 1f)
                            {
                                num2 = 1600;
                                num3 = 4;
                            }
                            break;
                        case 657:
                            num3 = 13;
                            break;
                        case 636:
                            num3 = 14;
                            break;
                        case 370:
                            num3 = 15;
                            break;
                        case 668:
                            num3 = 16;
                            break;
                    }
                    if (NPCID.Sets.BelongsToInvasionOldOnesArmy[npc[j].type])
                    {
                        num3 = 12;
                    }
                    if (num3 == 0 && npc[j].boss)
                    {
                        num3 = 1;
                    }
                    if (remixWorld && getGoodWorld && (npc[j].type == 127 || npc[j].type == 134 || npc[j].type == 125 || npc[j].type == 126))
                    {
                        num3 = 17;
                    }
                    if (num3 == 0)
                    {
                        continue;
                    }
                    Rectangle value = new Rectangle((int)(npc[j].position.X + (float)(npc[j].width / 2)) - num2, (int)(npc[j].position.Y + (float)(npc[j].height / 2)) - num2, num2 * 2, num2 * 2);
                    if (rectangle.Intersects(value))
                    {
                        switch (num3)
                        {
                            case 1:
                                flag = true;
                                break;
                            case 2:
                                flag3 = true;
                                break;
                            case 3:
                                flag4 = true;
                                break;
                            case 4:
                                flag5 = true;
                                break;
                            case 5:
                                flag6 = true;
                                break;
                            case 6:
                                flag7 = true;
                                break;
                            case 7:
                                flag8 = true;
                                break;
                            case 8:
                                flag9 = true;
                                break;
                            case 9:
                                flag10 = true;
                                break;
                            case 10:
                                flag11 = true;
                                break;
                            case 11:
                                flag12 = true;
                                break;
                            case 12:
                                flag13 = true;
                                break;
                            case 13:
                                flag14 = true;
                                break;
                            case 14:
                                flag15 = true;
                                break;
                            case 15:
                                flag16 = true;
                                break;
                            case 16:
                                flag2 = true;
                                break;
                            case 17:
                                flag17 = true;
                                break;
                        }
                        break;
                    }
                }
            }
            _ = (screenPosition.X + (float)(screenWidth / 2)) / 16f;

            if (musicVolume == 0f)
            {
                Current = 0;
                return;
            }
            if (gameMenu)
            {
                if (netMode != 2)
                {
                    if (WorldGen.drunkWorldGen)
                    {
                        if (WorldGen.remixWorldGen)
                        {
                            Current = 70;
                        }
                        else
                        {
                            Current = 60;
                        }
                    }
                    else if (WorldGen.remixWorldGen)
                    {
                        Current = 8;
                    }
                    else if (menuMode == 3000)
                    {
                        Current = 89;
                    }
                    else if (WorldGen.tenthAnniversaryWorldGen)
                    {
                        Current = 11;
                    }
                    /* these are just menu musics anyway so wont ever be relevant
                    else if (playOldTile)
                    {
                        Current = 6;
                    }
                    else if (!_isAsyncLoadComplete)
                    {
                        Current = 50;
                    }
                    */
                    else if (!audioSystem.IsTrackPlaying(50))
                    {
                        Current = 51;
                        /*
                        if (musicNoCrossFade[51])
                        {
                            musicFade[51] = 1f;
                        }
                        */
                    }
                }
                else
                {
                    Current = 0;
                }
                return;
            }
            float num4 = (float)maxTilesX / 4200f;
            num4 *= num4;
            float num5 = (float)((double)((screenPosition.Y + (float)(screenHeight / 2)) / 16f - (65f + 10f * num4)) / (worldSurface / 5.0));
            if (CreditsRollEvent.IsEventOngoing)
            {
                Current = 89;
            }
            else if (player[myPlayer].happyFunTorchTime)
            {
                Current = 13;
            }
            else if (flag8)
            {
                Current = 38;
            }
            else if (flag17)
            {
                Current = 81;
            }
            else if (flag10)
            {
                Current = 37;
            }
            else if (flag11)
            {
                Current = 34;
            }
            else if (flag7)
            {
                Current = 24;
            }
            else if (flag15)
            {
                Current = 57;
            }
            else if (flag16)
            {
                Current = 58;
            }
            else if (flag3)
            {
                Current = 12;
            }
            else if (flag)
            {
                Current = 5;
            }
            else if (flag4)
            {
                Current = 13;
            }
            else if (flag5)
            {
                Current = 17;
            }
            else if (flag6)
            {
                Current = 25;
            }
            else if (flag14)
            {
                Current = 56;
            }
            else if (flag2)
            {
                Current = 90;
            }
            else if (flag9)
            {
                Current = 35;
            }
            else if (flag12)
            {
                Current = 39;
            }
            else if (flag13)
            {
                Current = 41;
            }
            else if (eclipse && !remixWorld && (double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2))
            {
                Current = 27;
            }
            else if (eclipse && remixWorld && (double)player[myPlayer].position.Y > rockLayer * 16.0)
            {
                Current = 27;
            }
            else if (flag19 && !player[myPlayer].ZoneGraveyard && (!bloodMoon || dayTime) && (double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2))
            {
                Current = 48;
            }
            else if (remixWorld && bloodMoon && !player[myPlayer].ZoneCrimson && !player[myPlayer].ZoneCorrupt && (double)player[myPlayer].position.Y > rockLayer * 16.0 && player[myPlayer].position.Y <= (float)(UnderworldLayer * 16))
            {
                Current = 2;
            }
            else if (remixWorld && bloodMoon && player[myPlayer].position.Y > (float)(UnderworldLayer * 16) && (double)(player[myPlayer].Center.X / 16f) > (double)maxTilesX * 0.37 + 50.0 && (double)(player[myPlayer].Center.X / 16f) < (double)maxTilesX * 0.63)
            {
                Current = 2;
            }
            else if (player[myPlayer].ZoneShimmer)
            {
                Current = 91;
            }
            else if (flag18 && dayTime && ((cloudAlpha == 0f && !_shouldUseWindyDayMusic) || (double)player[myPlayer].position.Y >= worldSurface * 16.0 + (double)(screenHeight / 2)) && !player[myPlayer].ZoneGraveyard)
            {
                Current = 46;
            }
            else if (flag18 && !dayTime && ((!bloodMoon && cloudAlpha == 0f) || (double)player[myPlayer].position.Y >= worldSurface * 16.0 + (double)(screenHeight / 2)) && !player[myPlayer].ZoneGraveyard)
            {
                Current = 47;
            }
            else if (player[myPlayer].ZoneSandstorm)
            {
                Current = 40;
            }
            else if (player[myPlayer].position.Y > (float)(UnderworldLayer * 16))
            {
                Current = 36;
            }
            else if (num5 < 1f)
            {
                Current = (dayTime ? 42 : 15);
            }
            else if (tile[(int)(player[myPlayer].Center.X / 16f), (int)(player[myPlayer].Center.Y / 16f)].WallType == 87)
            {
                Current = 26;
            }
            else if (player[myPlayer].ZoneDungeon)
            {
                Current = 23;
            }
            else if ((bgStyle == 9 && (double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2)) || undergroundBackground == 2)
            {
                Current = 29;
            }
            else if (player[myPlayer].ZoneCorrupt)
            {
                if (player[myPlayer].ZoneCrimson && Main.SceneMetrics.BloodTileCount > Main.SceneMetrics.EvilTileCount)
                {
                    if ((double)player[myPlayer].position.Y > worldSurface * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 33;
                    }
                    else
                    {
                        Current = 16;
                    }
                }
                else if ((double)player[myPlayer].position.Y > worldSurface * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 10;
                }
                else
                {
                    Current = 8;
                }
            }
            else if (player[myPlayer].ZoneCrimson)
            {
                if ((double)player[myPlayer].position.Y > worldSurface * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 33;
                }
                else
                {
                    Current = 16;
                }
            }
            else if (player[myPlayer].ZoneMeteor)
            {
                Current = 2;
            }
            else if (player[myPlayer].ZoneGraveyard)
            {
                Current = 53;
            }
            else if (player[myPlayer].ZoneJungle)
            {
                if (remixWorld)
                {
                    if ((double)player[myPlayer].position.Y > rockLayer * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 7;
                    }
                    else if (newMusic == 7 && (double)player[myPlayer].position.Y > (rockLayer - 50.0) * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 7;
                    }
                    else if ((double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = (dayTime ? 42 : 15);
                    }
                    else
                    {
                        Current = 54;
                    }
                }
                else if ((double)player[myPlayer].position.Y > rockLayer * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 54;
                }
                else if (newMusic == 54 && (double)player[myPlayer].position.Y > (rockLayer - 50.0) * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 54;
                }
                else if (_shouldUseStormMusic && (double)player[myPlayer].position.Y < worldSurface * 16.0 + (double)(screenHeight / 2))
                {
                    Current = 52;
                }
                else if (dayTime)
                {
                    Current = 7;
                }
                else
                {
                    Current = 55;
                }
            }
            else if (player[myPlayer].ZoneSnow)
            {
                if ((double)player[myPlayer].position.Y > worldSurface * 16.0 + (double)(screenHeight / 2))
                {
                    if (remixWorld && (double)player[myPlayer].position.Y > rockLayer * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 14;
                    }
                    else
                    {
                        Current = 20;
                    }
                }
                else if (remixWorld)
                {
                    Current = (dayTime ? 42 : 15);
                }
                else
                {
                    Current = 14;
                }
            }
            else if ((double)player[myPlayer].position.Y >= worldSurface * 16.0 + (double)(screenHeight / 2) && (remixWorld || !WorldGen.oceanDepths((int)(screenPosition.X + (float)(screenWidth / 2)) / 16, (int)(screenPosition.Y + (float)(screenHeight / 2)) / 16)))
            {
                if (player[myPlayer].ZoneHallow)
                {
                    if (remixWorld && (double)player[myPlayer].position.Y >= rockLayer * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 9;
                    }
                    else
                    {
                        Current = 11;
                    }
                }
                else if (player[myPlayer].ZoneUndergroundDesert)
                {
                    if ((double)player[myPlayer].position.Y >= worldSurface * 16.0 + (double)(screenHeight / 2))
                    {
                        Current = 61;
                    }
                    else
                    {
                        Current = 21;
                    }
                }
                else
                {
                    int ugMusicHolder = ugMusic;
                    if (ugMusicHolder == 0)
                    {
                        ugMusicHolder = 4;
                    }
                    if (!audioSystem.IsTrackPlaying(4) && !audioSystem.IsTrackPlaying(31))
                    {
                        /*
                        if (musicFade[4] == 1f)
                        {
                            musicFade[31] = 1f;
                        }
                        if (musicFade[31] == 1f)
                        {
                            musicFade[4] = 1f;
                        }
                        */
                        switch (rand.Next(2))
                        {
                            case 0:
                                ugMusicHolder = 4;
                                //musicFade[31] = 0f;
                                break;
                            case 1:
                                ugMusicHolder = 31;
                                // musicFade[4] = 0f;
                                break;
                        }
                    }
                    Current = ugMusicHolder;
                    if (remixWorld && (double)(player[myPlayer].position.Y / 16f) > rockLayer && player[myPlayer].position.Y / 16f < (float)(maxTilesY - 350))
                    {
                        if (cloudAlpha > 0f)
                        {
                            Current = 19;
                        }
                        else if (player[myPlayer].ZoneDesert)
                        {
                            Current = 21;
                        }
                        else if (_shouldUseWindyDayMusic)
                        {
                            Current = 44;
                        }
                    }
                }
            }
            else if (dayTime && player[myPlayer].ZoneHallow)
            {
                if (_shouldUseStormMusic)
                {
                    Current = 52;
                }
                else if (cloudAlpha > 0f && !gameMenu)
                {
                    Current = 19;
                }
                else if (_shouldUseWindyDayMusic && !remixWorld)
                {
                    Current = 44;
                }
                else
                {
                    Current = 9;
                }
            }
            else if (_shouldUseStormMusic)
            {
                if (bloodMoon)
                {
                    Current = 2;
                }
                else
                {
                    Current = 52;
                }
            }
            else if (WorldGen.oceanDepths((int)(screenPosition.X + (float)(screenWidth / 2)) / 16, (int)(screenPosition.Y + (float)(screenHeight / 2)) / 16))
            {
                if (bloodMoon)
                {
                    Current = 2;
                }
                else if (flag18)
                {
                    if (dayTime)
                    {
                        Current = 46;
                    }
                    else
                    {
                        Current = 47;
                    }
                }
                else
                {
                    Current = (dayTime ? 22 : 43);
                }
            }
            else if (player[myPlayer].ZoneDesert)
            {
                if ((double)player[myPlayer].position.Y >= worldSurface * 16.0)
                {
                    int num6 = (int)(player[myPlayer].Center.X / 16f);
                    int num7 = (int)(player[myPlayer].Center.Y / 16f);
                    if (WorldGen.InWorld(num6, num7) && (WallID.Sets.Conversion.Sandstone[tile[num6, num7].WallType] || WallID.Sets.Conversion.HardenedSand[tile[num6, num7].WallType]))
                    {
                        Current = 61;
                    }
                    else
                    {
                        Current = 21;
                    }
                }
                else
                {
                    Current = 21;
                }
            }
            else if (remixWorld)
            {
                Current = (dayTime ? 42 : 15);
            }
            else if (dayTime)
            {
                if (cloudAlpha > 0f && !gameMenu)
                {
                    if (time < 10800.0)
                    {
                        Current = 59;
                    }
                    else
                    {
                        Current = 19;
                    }
                }
                else
                {
                    int dayMusicHolder = dayMusic;
                    if (dayMusic == 0)
                    {
                        dayMusicHolder = 1;
                    }
                    if (!audioSystem.IsTrackPlaying(1) && !audioSystem.IsTrackPlaying(18))
                    {
                        if (rand.Next(2) == 0)
                        {
                            dayMusicHolder = 1;
                        }
                        else
                        {
                            dayMusicHolder = 18;
                        }
                    }
                    Current = dayMusic;
                    if (_shouldUseWindyDayMusic && !remixWorld)
                    {
                        Current = 44;
                    }
                }
            }
            else if (!dayTime)
            {
                if (bloodMoon)
                {
                    Current = 2;
                }
                else if (cloudAlpha > 0f && !gameMenu)
                {
                    Current = 19;
                }
                else
                {
                    Current = 3;
                }
            }
            if (((double)(screenPosition.Y / 16f) < worldSurface + 10.0 || remixWorld) && pumpkinMoon)
            {
                Current = 30;
            }
            if (((double)(screenPosition.Y / 16f) < worldSurface + 10.0 || remixWorld) && snowMoon)
            {
                Current = 32;
            }
        }
        #endregion
    }
    abstract class MusicEffect : ModSceneEffect
    {
        public abstract string MusicName { get; }
        public int timer;
        public const int IMMERSIVE_SONG_TIME = 120;
        public override int Music => MusicLoader.GetMusicSlot(Mod, $"Music/{MusicName}");
        public override bool IsSceneEffectActive(Player player)
        {
            return Active(player);
        }
        public override float GetWeight(Player player) => 0.6f;
        public abstract bool MyMusicConfig { get; }
        public abstract NPC TryGetActiveNPC { get; }
        public abstract string DisplayMusicName { get; }
        public virtual bool Active(Player player)
        {
            if (!MyMusicConfig)
                return false;
            NPC npc = TryGetActiveNPC;
            if (npc != null)
                timer = MusicConfig.Instance.ImmersiveBossSongs ? MusicEffect.IMMERSIVE_SONG_TIME : 6;
            if (timer > 0)
            {
                if (!MusicConfig.Instance.ImmersiveBossSongs || (npc == null && !(Main.LocalPlayer.active && Main.LocalPlayer.dead)))
                    timer--;
                TerryMusicSystem.nowPlayingString = DisplayMusicName;
                return true;
            }
            return false;
        }
    }
    #region Bosses


    class TrojanSquirrel : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "HoloCureSuspect";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideTrojanSquirrelTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("TrojanSquirrel");
        public override string DisplayMusicName => "HoloCure ~ Suspect";
    }

    class KingSlime : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "rePrologue";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideKingSlimeTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.KingSlime);
        public override string DisplayMusicName => "Sakuzyo ~ rePrologue";
    }

    class EyeOfCthulhu : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "XNautFortress";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideEyeOfCthulhuTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.EyeofCthulhu);
        public override string DisplayMusicName => "Paper Mario TTYD ~ X-Naut Fortress";
    }

    class CursedCoffin : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "ShiftingSandLand";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideCursedCoffinTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("CursedCoffin");
        public override string DisplayMusicName => "Super Mario 64 ~ Shifting Sand Land";
    }

    class EaterOfWorlds : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "LastBattleBallosMix";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideEaterOfWorldsTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.EaterofWorldsHead);
        public override string DisplayMusicName => "DM Dokuro ~ Last Battle (Ballos Mix)";
    }

    class Brain : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "MotherBrain";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideBrainOfCthulhuTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.BrainofCthulhu);
        public override string DisplayMusicName => "Super Metroid ~ Mother Brain";
    }

    class QueenBee : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "RegnumCaelorumEtGehennaVerumCurNonAudimus";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideQueenBeeTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.QueenBee);
        public override string DisplayMusicName => "Regnum Caelorum Et Gehenna ~ Verum Cur Non Audimus";
    }

    class Skeletron : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "BadToTheBone";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideSkeletronTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.SkeletronHead);
        public override string DisplayMusicName => "George Thorogood ~ Bad to the Bone";
    }

    class Deerclops : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "NoHesitation";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideDeerclopsTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.Deerclops);
        public override string DisplayMusicName => "Jujutsu Kaisen ~ No Hesitation (Abridged)";
    }

    class Devi : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override string MusicName => "UsagiFlap";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideDevianttTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("DeviBoss");
        public override string DisplayMusicName => "Blue Archive ~ Usagi Flap";
    }

    class WallOfFlesh : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "DemetoriNecrofantasia";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideWallOfFleshTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.WallofFlesh);
        public override string DisplayMusicName => "Demetori ~ Necrofantasia";
    }

    class Dreadnautilus : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "BloodStainedFaith";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideDreadnautilusTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.BloodNautilus);
        public override string DisplayMusicName => "Blue Archive ~ Blood Stained Faith";
    }

    class QueenSlime : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "DededeDrumDashDeluxeCROWNED";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideQueenSlimeTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.QueenSlimeBoss);
        public override string DisplayMusicName => "Dedede's Drum Dash Deluxe ~ C-R-O-W-N-E-D";
    }

    class Baron : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "BREISXVsZeroDecisiveBattle2";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideBanishedBaronTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("BanishedBaron");
        public override string DisplayMusicName => "BREIS ~ X Vs Zero Decisive Battle 2";
    }

    class SkeletronPrime : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "PACHAD";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideSkeletronPrimeTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.SkeletronPrime);
        public override string DisplayMusicName => "Blue Archive ~ PACHAD";
    }

    class Twins : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "SoundAveStormRider";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideTwinsTheme;
        public override NPC TryGetActiveNPC
        {
            get
            {
                var reti = MusicUtils.FindClosestBoss(NPCID.Retinazer);
                var spaz = MusicUtils.FindClosestBoss(NPCID.Spazmatism);
                return reti ?? spaz;
            }
        }
        public override string DisplayMusicName => "Sound Ave ~ Storm Rider";
    }

    class Destroyer : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "DiverseSystemNightmareParadiseAbridged";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideDestroyerTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.TheDestroyer);
        public override string DisplayMusicName => "Diverse System ~ Nightmare Paradise (Abridged)";
    }

    class Lifelight : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override string MusicName => "SEQUELcolonyKizuato";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideLifelightTheme && MusicUtils.Souls != null;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss(
            MusicUtils.Souls.Version >= Version.Parse("1.8") ? "Lifelight" : "LifeChallenger");
        public override string DisplayMusicName => "SEQUEL colony ~ Kizuato";
    }

    class Plantera : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "Gekkasakuya";
        public override bool MyMusicConfig => MusicConfig.Instance.OverridePlanteraTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.Plantera);
        public override string DisplayMusicName => "Magia Record ~ Gekkasakuya";
    }

    class Golem : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "MEGALOVANIA";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideGolemTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.Golem);
        public override string DisplayMusicName => "UNDERTALE ~ MEGALOVANIA";
    }

    class Betsy : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "BetterCallSaul";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideBetsyTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.DD2Betsy);
        public override string DisplayMusicName => "Better Call Saul ~ Intro";
    }

    class Fishron : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "CannonBallMythos";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideDukeFishronTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.DukeFishron);
        public override string DisplayMusicName => "Megaman Zero ~ Cannon Ball (Mythos)";
    }

    class EmpressofLight : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "BorderOfLifeResurrectionButterfly";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideEmpressOfLightTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.HallowBoss);
        public override string DisplayMusicName => "Touhou PCB ~ Border of Life / Resurrection Butterfly";
    }

    class Cultist : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;
        public override string MusicName => "Chokmah232";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideLunaticCultistTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.CultistBoss);
        public override string DisplayMusicName => "Blue Archive ~ The Eruption";
    }

    class Pillars : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "OurOath";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideLunarPillarsTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FirstPillarInRange();
        public override string DisplayMusicName => "Blue Archive ~ Our Oath";
    }

    class MoonLord : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override string MusicName => "FuryOfSet";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideMoonLordTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestBoss(NPCID.MoonLordCore);
        public override string DisplayMusicName => "Blue Archive ~ FURY OF SET";
    }

    class TimberChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "StardustSong";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideTimberChampionTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("TimberChampion");
        public override string DisplayMusicName => "HoloCure ~ Stardust Song";
    }

    class TerraChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "AriaLastBattle";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideTerraChampionTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("TerraChampion");
        public override string DisplayMusicName => "Castlevania Aria of Sorrow ~ Last Battle";
    }

    class NatureChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "MasahiroAokiFrostbite";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideNatureChampionTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("NatureChampion");
        public override string DisplayMusicName => "Masahiro Aoki ~ Frostbite";
    }

    class LifeChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "conciliation";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideLifeChampionTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("LifeChampion");
        public override string DisplayMusicName => "BlazBlue ~ conciliation";
    }

    class ShadowChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "ProteusRidley3";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideShadowChampionTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("ShadowChampion");
        public override string DisplayMusicName => "Metroid Samus Returns ~ Proteus Ridley 3";
    }

    class EarthChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "Pompey";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideEarthChampionTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("EarthChampion");
        public override string DisplayMusicName => "Zenless Zone Zero ~ Pompey";
    }

    class SpiritChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "SketchesOfPain";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideSpiritChampionTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("SpiritChampion");
        public override string DisplayMusicName => "The Binding of Isaac ~ Sketches of Pain";
    }

    class WillChampion : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;
        public override string MusicName => "MamoruKunHasBeenCursedWillForce";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideWillChampionTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("WillChampion");
        public override string DisplayMusicName => "Mamoru-kun Wa Norowarete Shimatta! ~ Will Force";
    }

    class Eridanus : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override string MusicName => "SuddenDeath";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideEridanusTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("CosmosChampion");
        public override string DisplayMusicName => "Rabi-Ribi ~ Sudden Death";
    }

    class Abom : MusicEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override string MusicName => "Showdown";
        public override bool MyMusicConfig => MusicConfig.Instance.OverrideAbominationnTheme;
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("AbomBoss");
        public override string DisplayMusicName => "Project Wingman ~ Showdown";
    }

    class Mutant : MusicEffect
    {
        public override SceneEffectPriority Priority => (SceneEffectPriority)9;
        private bool useAltMusic => MusicConfig.Instance.MutantFtwZzz &&
            (MusicUtils.Souls.Version >= Version.Parse("1.8") ? (bool)MusicUtils.Souls.Call("MasochistMode") : Main.getGoodWorld);
        public override string MusicName => useAltMusic ? "BattleTrialsGlory" : "SupremeRulersCoronationOVERLORD";
        public override bool MyMusicConfig => (MusicUtils.Souls != null) && (MusicConfig.Instance.OverrideMutantTheme || useAltMusic);
        public override NPC TryGetActiveNPC => MusicUtils.FindClosestSoulsBoss("MutantBoss");
        public override string DisplayMusicName =>
            useAltMusic ? "Zenless Zone Zero ~ Battle Trials (Glory)" : "Kirby RTDL Deluxe ~ Supreme Ruler's Coronation - OVERLORD";
    }
    #endregion
}
