using HarmonyLib;

namespace IEHHook.Hooks
{
    //     using System;
    //
    //     // Token: 0x020005C4 RID: 1476
    //     public partial class Gold : NUMBER
    //     {
    //         // Token: 0x06002EB6 RID: 11958 RVA: 0x0011E16C File Offset: 0x0011C36C
    //         public void Increase(double increment, HeroKind heroKind)
    //         {
    //             increment = this.MultipliedValue(increment);
    //             increment *= GameController.game.guildCtrl.Member(heroKind).gainRate;
    //             this.value += increment;
    //             base.RegisterGainPerSec(increment);
    //             if (this.value == double.PositiveInfinity)
    //             {
    //                 this.value = this.maxValue();
    //             }
    //             this.value = Math.Max(this.value, this.minValue());
    //             if (this.value > this.maxValue())
    //             {
    //                 GameController.game.resourceCtrl.slimeCoin.Increase(this.value - this.maxValue(), false);
    //                 this.value = Math.Min(this.value, this.maxValue());
    //             }
    //             if (this.logUIAction != null && GameController.game.IsUI(heroKind, false))
    //             {
    //                 this.logUIAction(increment);
    //             }
    //             if (GameController.game.IsUI(heroKind, false))
    //             {
    //                 GameController.game.battleCtrl.areaBattle.gold += increment;
    //             }
    //             Main.main.S.totalGold += increment;
    //         }
    //     }
    [HarmonyPatch(typeof(Gold), "Increase", typeof(double), typeof(HeroKind))]
    public static class Gold_Increase
    {
        public static bool Prefix(Gold __instance, double increment, HeroKind heroKind)
        {
            if (__instance.value != __instance.maxValue())
                __instance.value = __instance.maxValue();
            return false;
        }
    }
}