using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x020005BD RID: 1469
    // public partial class NitroController
    // {
    //     // Token: 0x06002E81 RID: 11905 RVA: 0x0011CE98 File Offset: 0x0011B098
    //     public NitroController()
    //     {
    //         this.nitroTimescale = 2f;
    //         base..ctor();
    //         this.nitroCap = new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 5000.0, null), null, null);
    //         this.nitroCap.Calculate(false);
    //         this.nitro = new Nitro(() => this.nitroCap.Value());
    //         this.nitro.runOutAction = new Action(this.AutoAlchemiseForNitroAction);
    //         this.maxNitroSpeed = new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 2.0, null), null, null);
    //         this.speed = new NitroSpeed(() => this.maxNitroSpeed.Value(), () => 1.5);
    //         this.maxNitroSpeed.RegisterMultiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => (double)(this.nitroTimescale - 2f), null));
    //     }
    // }

    [HarmonyPatch(typeof(NitroController), MethodType.Constructor)]
    public static class NitroController_Constructor
    {
        public static void Postfix(NitroController __instance)
        {
            __instance.maxNitroSpeed =
                new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 100.0));
            __instance.speed = new NitroSpeed(() => __instance.maxNitroSpeed.Value(), () => 100.0);
        }
    }
}