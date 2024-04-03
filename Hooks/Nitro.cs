using HarmonyLib;

namespace IEHHook.Hooks
{
    //     using System;
    //
    //     // Token: 0x020005BF RID: 1471
    //     public partial class Nitro : NUMBER
    //     {
    //         // Token: 0x06002E92 RID: 11922 RVA: 0x0011D348 File Offset: 0x0011B548
    //         public override void Decrease(double decrement, bool isPreventCheckMaxAndMin = false)
    //         {
    //             this.value -= decrement;
    //             Main.main.S.nitroConsumed += decrement;
    //             if (double.IsInfinity(this.value))
    //             {
    //                 this.value = this.maxValue();
    //             }
    //             if (double.IsNaN(this.value))
    //             {
    //                 this.value = this.minValue();
    //             }
    //             this.value = Math.Max(this.value, this.minValue());
    //             if (this.value < this.minValue() + 1.0 && this.runOutAction != null)
    //             {
    //                 this.runOutAction();
    //             }
    //         }
    //     }
    
    [HarmonyPatch(typeof(Nitro), "Decrease", typeof(double), typeof(bool))]
    public static class Nitro_Decrease
    {
        public static bool Prefix(Nitro __instance, double decrement, bool isPreventCheckMaxAndMin)
        {
            Main.main.S.nitroConsumed += decrement;

            if (__instance.value != __instance.maxValue())
                __instance.value = __instance.maxValue();
            return false;
        }
    }
}