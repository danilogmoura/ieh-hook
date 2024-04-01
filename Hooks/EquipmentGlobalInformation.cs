using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    //
    // // Token: 0x02000324 RID: 804
    // public partial class EquipmentGlobalInformation
    // {
    //     // Token: 0x06001E0F RID: 7695 RVA: 0x000AD5B0 File Offset: 0x000AB7B0
    //     public double RequiredProficiency(HeroKind heroKind, long level)
    //     {
    //         double num = Math.Pow(3.0, (double)this.rarity) * (1.0 + 1.5 * (double)this.rarity) * 300.0 * (double)(level * (long)(1 + this.rarity) + 1L);
    //         num /= 2.0;
    //         if (this.rarity >= EquipmentRarity.Epic)
    //         {
    //             num *= 10000.0 * Math.Pow(10.0, (double)level / 10.0);
    //         }
    //         if (level <= 10L)
    //         {
    //             return num;
    //         }
    //         return num * Math.Pow(2.0, (double)(level - 10L));
    //     }
    // }
    [HarmonyPatch(typeof(EquipmentGlobalInformation), "RequiredProficiency", typeof(HeroKind), typeof(long))]
    public class EquipmentGlobalInformation_RequiredProficiency
    {
        public static void Postfix(EquipmentGlobalInformation __instance, HeroKind heroKind, long level,
            ref double __result)
        {
            __result = 0;
        }
    }
}