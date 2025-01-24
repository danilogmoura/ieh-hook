using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x0200020E RID: 526
    // public partial class SDGem
    // {
    //     // Token: 0x06001530 RID: 5424 RVA: 0x00082F68 File Offset: 0x00081168
    //     public SDGem(SDGemRitualController sdGemRitualCtrl)
    //     {
    //         this.sdGemRitualCtrl = sdGemRitualCtrl;
    //         this.extraMaxLevel = new Multiplier();
    //         this.level = new SDGemLevel(this);
    //         this.level.maxValue = () => this.maxLevel + (long)this.extraMaxLevel.Value();
    //         this.exp = new SDGemExp(this, new Func<long, double>(this.RequiredExp), this.level);
    //         this.unlock = new Unlock(false);
    //         this.motherStoneAssigned = new SDGemMotherStoneAssigned(this);
    //     }
    // }

    [HarmonyPatch(typeof(SDGem), MethodType.Constructor, typeof(SDGemRitualController))]
    public class SDGem_RequiredExp
    {
        public static void Postfix(SDGem __instance, SDGemRitualController sdGemRitualCtrl)
        {
            __instance.exp = new SDGemExp(__instance, l => 1, __instance.level);
        }
    }
}