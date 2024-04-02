using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x020000DD RID: 221
    // public partial class DUNGEON : AREA
    // {
    //     // Token: 0x060009C8 RID: 2504 RVA: 0x00047B48 File Offset: 0x00045D48
    //     public override double TownMaterialRewardNum(HeroKind heroKind)
    //     {
    //         return Math.Floor((Math.Pow(this.averageMonsterLevel, 1.35) + this.averageMonsterLevel * 4.0 + this.areaCtrl.townMaterialGainBonus.Value() + this.areaCtrl.townMaterialGainBonusClass[(int)heroKind].Value()) * this.areaCtrl.townMaterialDungeonRewardMultiplier.Value() * GameController.game.townCtrl.townMaterialGainMultiplier[(int)heroKind].Value());
    //     }
    // }

    [HarmonyPatch(typeof(DUNGEON), "TownMaterialRewardNum", typeof(HeroKind))]
    public class DUNGEON_TownMaterialRewardNum
    {
        public static void Postfix(DUNGEON __instance, HeroKind heroKind, ref double __result)
        {
            __result *= 10;
        }
    }
}