using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using UnityEngine;
    //
    // // Token: 0x02000066 RID: 102
    // public partial class MaterialGenerator : DROP_GENERATOR
    // {
    //     // Token: 0x060005A9 RID: 1449 RVA: 0x000322BB File Offset: 0x000304BB
    //     public override void Get()
    //     {
    //         GameController.game.materialCtrl.Material(this.kind).Increase(this.num, this.heroKind);
    //         this.Initialize();
    //     }
    // }

    [HarmonyPatch(typeof(MaterialGenerator), "Get")]
    public static class MaterialGenerator_Get
    {
        private static bool Prefix(MaterialGenerator __instance)
        {
            if (GameController.game.materialCtrl.Material(__instance.kind).value >= double.MaxValue) return false;

            GameController.game.materialCtrl.Material(__instance.kind).Increase(double.MaxValue, __instance.heroKind);
            return false;
        }
    }

    // using System;
    // using UnityEngine;
    //
    // // Token: 0x02000066 RID: 102
    // public partial class MaterialGenerator : DROP_GENERATOR
    // {
    //     // Token: 0x060005AA RID: 1450 RVA: 0x000322EC File Offset: 0x000304EC
    //     public void AutoGet()
    //     {
    //         if (!this.isAutoGetTriggered)
    //         {
    //             return;
    //         }
    //         for (int i = 0; i < this.tempAutoGetMaterialNum.Length; i++)
    //         {
    //             if (this.tempAutoGetMaterialNum[i] > 0.0)
    //             {
    //                 GameController.game.materialCtrl.Material((MaterialKind)i).Increase(this.tempAutoGetMaterialNum[i], this.heroKind);
    //                 this.Initialize();
    //             }
    //             this.tempAutoGetMaterialNum[i] = 0.0;
    //         }
    //         this.isAutoGetTriggered = false;
    //     }
    // }

    [HarmonyPatch(typeof(MaterialGenerator), "AutoGet")]
    public static class MaterialGenerator_AutoGet
    {
        private static void Postfix(MaterialGenerator __instance)
        {
            if (GameController.game.materialCtrl.Material(__instance.kind).value < double.MaxValue)
                GameController.game.materialCtrl.Material(__instance.kind)
                    .Increase(double.MaxValue, __instance.heroKind);
        }
    }
}