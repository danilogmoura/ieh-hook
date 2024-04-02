using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x02000599 RID: 1433
    // public partial class TownController
    // {
    //     // Token: 0x06002D60 RID: 11616 RVA: 0x00119AC4 File Offset: 0x00117CC4
    //     public void ProgressResaerch(double deltaTime)
    //     {
    //         for (int i = 0; i < this.buildings.Length; i++)
    //         {
    //             this.buildings[i].Update(deltaTime);
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(TownController), "ProgressResaerch", typeof(double))]
    public class TownController_ProgressResaerch
    {
        public static bool Prefix(TownController __instance, ref double deltaTime)
        {
            deltaTime = 1_000_000;
            return true;
        }
    }
}