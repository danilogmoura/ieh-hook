using System;
using HarmonyLib;

namespace IEHHook.Hooks
{
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

            __result = 10_000;

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

    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    //
    // // Token: 0x0200007A RID: 122
    // public partial class AREA
    // {
    //     // Token: 0x06000748 RID: 1864 RVA: 0x0003B63C File Offset: 0x0003983C
    //     public virtual double TownMaterialRewardNum(HeroKind heroKind)
    //     {
    //         return Math.Floor((1.0 + (double)this.level.value * this.areaCtrl.townMaterialGainPerDifficultyMultiplier.Value()) * (1.0 + this.areaCtrl.townMaterialGainBonus.Value() + this.areaCtrl.townMaterialGainBonusClass[(int)heroKind].Value()) * GameController.game.townCtrl.townMaterialGainMultiplier[(int)heroKind].Value());
    //     }
    // }

    [HarmonyPatch(typeof(AREA), "TownMaterialRewardNum", typeof(HeroKind))]
    public static class AREA_TownMaterialRewardNum
    {
        private static bool Prefix(AREA __instance, HeroKind heroKind, ref double __result)
        {
            __result = double.MaxValue;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    //
    // // Token: 0x0200007A RID: 122
    // public partial class AREA
    // {
    //     // Token: 0x17000136 RID: 310
    //     // (get) Token: 0x06000744 RID: 1860 RVA: 0x0003B605 File Offset: 0x00039805
    //     public Func<double> rewardExp
    //     {
    //         get
    //         {
    //             return new Func<double>(this.RewardExp);
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(AREA), "rewardExp", MethodType.Getter)]
    public static class AREA_rewardExp
    {
        private static bool Prefix(AREA __instance, ref Func<double> __result)
        {
            __result = () => double.MaxValue;
            return false;
        }
    }
}