namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x020002B7 RID: 695
    // public partial class EpicStoreController
    // {
    //     // Token: 0x06001B1C RID: 6940 RVA: 0x0008EBAC File Offset: 0x0008CDAC
    //     public void CheckHack()
    //     {
    //         double num = (Main.main.S.epicCoin + Main.main.S.epicCoinConsumed) * 162464.0;
    //         Debug.Log(UsefulMethod.tDigit(num, 0, false, null, false, false, false));
    //         Debug.Log(UsefulMethod.tDigit(Main.main.S.wasd, 0, false, null, false, false, false));
    //         if (Math.Floor(num) > Math.Floor(Main.main.S.wasd))
    //         {
    //             Main.main.S.epicCoin = 0.0;
    //             Main.main.S.epicCoinConsumed = 0.0;
    //             Main.main.S.wasd = 0.0;
    //         }
    //     }
    // }

    // [HarmonyPatch(typeof(EpicStoreController), "CheckHack")]
    // public static class EpicStoreController_CheckHack
    // {
    //     private static bool Prefix()
    //     {
    //         return false;
    //     }
    // }
}