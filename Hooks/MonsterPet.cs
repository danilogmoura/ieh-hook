using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x02000046 RID: 70
    // public partial class MonsterPet
    // {
    //     // Token: 0x060004A6 RID: 1190 RVA: 0x00029AB3 File Offset: 0x00027CB3
    //     public double BaseTamingPointGainPerCapture()
    //     {
    //         return this.TPGByLevel() + this.TPGByDefeat() + this.TPGByCapture();
    //     }
    // }

    [HarmonyPatch(typeof(MonsterPet), "BaseTamingPointGainPerCapture")]
    public static class MonsterPet_BaseTamingPointGainPerCapture
    {
        private static bool Prefix(MonsterPet __instance, ref double __result)
        {
            __result = 1e200;
            return false;
        }
    }
}