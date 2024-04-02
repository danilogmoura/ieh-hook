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
}