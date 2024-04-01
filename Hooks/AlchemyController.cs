using HarmonyLib;
using MelonLoader;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    //
    // // Token: 0x020003C0 RID: 960
    // public partial class AlchemyController
    // {
    //     // Token: 0x0600233C RID: 9020 RVA: 0x000C46C5 File Offset: 0x000C28C5
    //     public bool CanExpandMysteriousWater()
    //     {
    //         return !this.mysteriousWaterExpandedCapNum.IsMaxed() && this.mysteriousWater.IsMaxed();
    //     }
    // }
    [HarmonyPatch(typeof(AlchemyController), "CanExpandMysteriousWater")]
    public static class AlchemyController_CanExpandMysteriousWater
    {
        public static bool Prefix(AlchemyController __instance, ref bool __result)
        {
            __result = !__instance.mysteriousWaterExpandedCapNum.IsMaxed();
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    //
    // // Token: 0x020003C0 RID: 960
    // public partial class AlchemyController
    // {
    //     // Token: 0x0600233A RID: 9018 RVA: 0x000C4699 File Offset: 0x000C2899
    //     public void Update(float deltaTime)
    //     {
    //         this.ProgressMysteriousWater(deltaTime);
    //         this.catalystCtrl.Update(deltaTime);
    //     }
    // }
    [HarmonyPatch(typeof(AlchemyController), "Update", typeof(float))]
    public static class AlchemyController_ProgressMysteriousWater
    {
        public static bool Prefix(AlchemyController __instance, ref float deltaTime)
        {
            MelonLogger.Msg(deltaTime);
            deltaTime = 10000;
            return true;
        }
    }
}