using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x0200054B RID: 1355
    // public partial class SKILL
    // {
    //     // Token: 0x06002A41 RID: 10817 RVA: 0x000F1E14 File Offset: 0x000F0014
    //     private double RankCost(long rank)
    //     {
    //         double num = this.initCost * Math.Pow(this.baseCost, (double)rank);
    //         if (rank >= 50L)
    //         {
    //             num *= 1000000.0;
    //         }
    //         if (rank >= 60L)
    //         {
    //             num *= 1000000000.0;
    //         }
    //         if (rank >= 80L)
    //         {
    //             num *= 1000000000000000.0;
    //         }
    //         if (rank >= 110L)
    //         {
    //             num *= 1E+24;
    //         }
    //         if (rank >= 150L)
    //         {
    //             num *= 1E+36;
    //         }
    //         num *= GameController.game.skillCtrl.skillRankCostFactors[(int)this.heroKind].Value();
    //         if (double.IsInfinity(num))
    //         {
    //             return 1E+302;
    //         }
    //         return num;
    //     }
    // }

    [HarmonyPatch(typeof(SKILL), "RankCost", typeof(long))]
    public class SKILL_RankCost
    {
        public static void Postfix(SKILL __instance, long rank, ref double __result)
        {
            __result = 1.0;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x0200054B RID: 1355
    // public partial class SKILL
    // {
    //     // Token: 0x06002A6B RID: 10859 RVA: 0x000F25D8 File Offset: 0x000F07D8
    //     public double RequiredProficiency(long level)
    //     {
    //         double num = Math.Floor(5.0 * (1.0 + this.profDifficulty * 0.75) * (double)(1L + level) * Math.Pow(3.0, (double)level / 100.0) / Math.Max(0.1, this.initInterval));
    //         if (level >= 250L)
    //         {
    //             num *= Math.Pow(10.0, ((double)level - 250.0) / 25.0);
    //         }
    //         if (level >= 300L)
    //         {
    //             num *= Math.Pow(2.0, ((double)level - 300.0) / 25.0);
    //         }
    //         if (level >= 400L)
    //         {
    //             num *= Math.Pow(4.0, ((double)level - 400.0) / 25.0);
    //         }
    //         if (level >= 550L)
    //         {
    //             num *= Math.Pow(8.0, ((double)level - 550.0) / 25.0);
    //         }
    //         if (level >= 750L)
    //         {
    //             num *= Math.Pow(16.0, ((double)level - 750.0) / 25.0);
    //         }
    //         if (level >= 900L)
    //         {
    //             num *= Math.Pow(32.0, ((double)level - 900.0) / 25.0);
    //         }
    //         return num;
    //     }
    // }

    [HarmonyPatch(typeof(SKILL), "RequiredProficiency", typeof(long))]
    public class SKILL_RequiredProficiency
    {
        public static void Postfix(SKILL __instance, long level, ref double __result)
        {
            __result = 0.0;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000591 RID: 1425
    // public partial class SKILL
    // {
    //     // Token: 0x06002E0B RID: 11787 RVA: 0x0010DFAA File Offset: 0x0010C1AA
    //     public virtual double ConsumeMpBase(HeroKind heroKind)
    //     {
    //         if (this.type == SkillType.Buff)
    //         {
    //             return 0.0;
    //         }
    //         return this.initMpConsume + this.incrementMpConsume * (double)this.Level(heroKind);
    //     }
    // }

    [HarmonyPatch(typeof(SKILL), "ConsumeMpBase", typeof(HeroKind))]
    public class SKILL_ConsumeMpBase
    {
        public static void Postfix(SKILL __instance, HeroKind heroKind, ref double __result)
        {
            __result = 0.0;
        }
    }
}