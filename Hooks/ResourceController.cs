using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x020009B5 RID: 2485
    // public partial class ResourceController
    // {
    //     // Token: 0x06005B6F RID: 23407 RVA: 0x0015CED0 File Offset: 0x0015B0D0
    //     public ResourceController()
    //     {
    //         this.resources = new Resource[Enum.GetNames(typeof(ResourceKind)).Length];
    //         base..ctor();
    //         this.goldCap = new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 5000.0, null), null, null);
    //         this.slimeCoinCap = new Multiplier();
    //         this.gold = new Gold(() => this.goldCap.Value());
    //         this.gold.isTrackGain = true;
    //         this.slimeCoin = new SlimeCoin(() => this.slimeCoinCap.Value());
    //         this.slimeCoin.isTrackGain = true;
    //         this.slimeCoinEfficiency = new Multiplier();
    //         this.slimeCoinInterest = new Multiplier(() => 0.5, () => 0.0);
    //         for (int i = 0; i < this.resources.Length; i++)
    //         {
    //             this.resources[i] = new Resource((ResourceKind)i);
    //             this.resources[i].isTrackGain = true;
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(ResourceController), MethodType.Constructor)]
    public static class ResourceController_Constructor
    {
        public static void Postfix(ResourceController __instance)
        {
            __instance.slimeCoin = new SlimeCoin(() => double.MaxValue);
            __instance.slimeCoin.isTrackGain = true;
        }
    }
}