﻿using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    //
    // // Token: 0x02000073 RID: 115
    // public partial class AREA
    // {
    //     // Token: 0x060006D9 RID: 1753 RVA: 0x00037E90 File Offset: 0x00036090
    //     public virtual double TownMaterialRewardNum(HeroKind heroKind)
    //     {
    //         return Math.Floor((1.0 + (double)this.level.value * this.areaCtrl.townMaterialGainPerDifficultyMultiplier.Value()) * (1.0 + this.areaCtrl.townMaterialGainBonus.Value() + this.areaCtrl.townMaterialGainBonusClass[(int)heroKind].Value()) * GameController.game.townCtrl.townMaterialGainMultiplier[(int)heroKind].Value());
    //     }
    // }

    [HarmonyPatch(typeof(AREA), "TownMaterialRewardNum", typeof(HeroKind))]
    public class AREA_TownMaterialRewardNum
    {
        public static void Postfix(AREA __instance, HeroKind heroKind, ref double __result)
        {
            __result *= 10;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    //
    // // Token: 0x02000073 RID: 115
    // public partial class AREA
    // {
    //     // Token: 0x060006E5 RID: 1765 RVA: 0x000383FE File Offset: 0x000365FE
    //     public double ClearCount(HeroKind heroKind)
    //     {
    //         if (this.isDungeon)
    //         {
    //             return this.areaCtrl.dungeonClearCountBonusClass[(int)heroKind].Value();
    //         }
    //         return this.areaCtrl.clearCountBonusClass[(int)heroKind].Value() * this.clearCountMultiplier.Value();
    //     }
    // }

    [HarmonyPatch(typeof(AREA), "ClearCount", typeof(HeroKind))]
    public class AREA_ClearCount
    {
        public static bool Prefix(AREA __instance, HeroKind heroKind, ref double __result)
        {
            if (__instance.isDungeon)
                __result = __instance.areaCtrl.dungeonClearCountBonusClass[(int)heroKind].Value();

            __result = __instance.areaCtrl.clearCountBonusClass[(int)heroKind].Value() *
                       __instance.clearCountMultiplier.Value() * 60_000;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    //
    // // Token: 0x02000073 RID: 115
    // public partial class AREA
    // {
    //     // Token: 0x0600070A RID: 1802 RVA: 0x00039930 File Offset: 0x00037B30
    //     public int MaxWaveNum()
    //     {
    //         if (this.isChallenge)
    //         {
    //             return this.wave.Count;
    //         }
    //         if (this.isDungeon)
    //         {
    //             return AREA.defaultMaxWaveNumDungeon + Math.Max(0, ((int)this.level.value + 1) * (int)this.level.value * 50);
    //         }
    //         return AREA.defaultMaxWaveNum + Math.Max(0, (int)this.level.value * 20 - (int)this.decreaseMaxWaveNum.Value());
    //     }
    // }

    [HarmonyPatch(typeof(AREA), "MaxWaveNum")]
    public class AREA_MaxWaveNum
    {
        public static void Postfix(AREA __instance, ref int __result)
        {
            if (!__instance.isChallenge && !__instance.isDungeon)
                __result = AREA.defaultMaxWaveNum;
        }
    }
}