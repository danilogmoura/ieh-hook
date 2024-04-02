using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x020005BD RID: 1469
    // public partial class NitroController
    // {
    //     // Token: 0x06002E83 RID: 11907 RVA: 0x0011CFC4 File Offset: 0x0011B1C4
    //     public void SwitchActive(bool isActive)
    //     {
    //         if (isActive && this.nitro.value < 1.0)
    //         {
    //             isActive = false;
    //         }
    //         this.isActive = isActive;
    //         if (isActive)
    //         {
    //             this.nitro.Decrease(this.nitroConsumption, false);
    //             this.lastTime = Main.main.allTimeRealtime;
    //             this.maxNitroSpeed.Calculate(false);
    //             this.speed.CheckMaxAndMin();
    //             Main.main.ChangeTimeScale((float)this.speed.value);
    //         }
    //         else
    //         {
    //             Main.main.ChangeTimeScale(1f);
    //         }
    //         if (this.switchUIAction != null)
    //         {
    //             this.switchUIAction();
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(NitroController), "SwitchActive", typeof(bool))]
    public static class NitroController_SwitchActive
    {
        public static bool Prefix(NitroController __instance, bool isActive)
        {
            __instance.maxNitroSpeed = new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add,
                () => 20.0));
            __instance.speed = new NitroSpeed(() => __instance.maxNitroSpeed.Value(), () => 15.0);
            __instance.maxNitroSpeed.RegisterMultiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add,
                () => __instance.nitroTimescale - 2f));

            return true;
        }
    }
}