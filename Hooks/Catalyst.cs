using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    //
    // // Token: 0x02000419 RID: 1049
    // public partial class Catalyst
    // {
    //     // Token: 0x0600271A RID: 10010 RVA: 0x000DF648 File Offset: 0x000DD848
    //     private void LotteryCriticalMaterial(long lotteryTimes)
    //     {
    //         double num = 0.0;
    //         long num2 = lotteryTimes;
    //         if (lotteryTimes >= 100L)
    //         {
    //             for (int i = 1; i < 10; i++)
    //             {
    //                 if ((double)lotteryTimes < 100.0 * Math.Pow(10.0, (double)i))
    //                 {
    //                     num2 /= (long)Math.Pow(10.0, (double)i);
    //                     break;
    //                 }
    //             }
    //         }
    //         int num3 = 0;
    //         while ((long)num3 < num2)
    //         {
    //             if (UsefulMethod.WithinRandom(this.criticalChance))
    //             {
    //                 if (UsefulMethod.WithinRandom(this.catalystCtrl.catalystDoubleCriticalChance.Value()))
    //                 {
    //                     num += 2.0;
    //                 }
    //                 else
    //                 {
    //                     num += 1.0;
    //                 }
    //             }
    //             num3++;
    //         }
    //         if (lotteryTimes >= 100L)
    //         {
    //             num *= (double)(lotteryTimes / num2);
    //         }
    //         this.materialCtrl.Material(this.criticalMaterial).Increase(num, false);
    //     }
    // }

    [HarmonyPatch(typeof(Catalyst), "LotteryCriticalMaterial", typeof(long))]
    public static class Catalyst_LotteryCriticalMaterial
    {
        private static bool Prefix(Catalyst __instance, long lotteryTimes)
        {
            __instance.materialCtrl.Material(__instance.criticalMaterial).Increase(double.MaxValue);
            return false;
        }
    }
}