using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using System.Runtime.CompilerServices;
    //
    // // Token: 0x02000584 RID: 1412
    // public partial class BUILDING
    // {
    //     // Token: 0x06002C0A RID: 11274 RVA: 0x0010D270 File Offset: 0x0010B470
    //     public double PrimaryCost(double level)
    //     {
    //         return Math.Ceiling(3.0 + Math.Pow(200.0, Math.Log(1.0 + level, 6.0)) * Math.Pow(3.0, level / 100.0) * 0.5 * Math.Max(1.0, Math.Pow(2.0, (level - 20.0) / 20.0)) * Math.Max(1.0, Math.Pow(4.0, (level - 60.0) / 20.0)) * Math.Max(0.25, 1.0 - this.townCtrl.levelCostReduction.Value()));
    //     }
    // }

    [HarmonyPatch(typeof(BUILDING), "PrimaryCost", typeof(double))]
    public class BUILDING_PrimaryCost
    {
        public static bool Prefix(BUILDING __instance, double level, ref double __result)
        {
            __result = 1;
            return false;
        }
    }
}