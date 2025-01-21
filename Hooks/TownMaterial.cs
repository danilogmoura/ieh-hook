using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x020005E0 RID: 1504
    // public partial class TownMaterial : NUMBER
    // {
    //     // Token: 0x17000B95 RID: 2965
    //     // (get) Token: 0x06003122 RID: 12578 RVA: 0x00136A3F File Offset: 0x00134C3F
    //     // (set) Token: 0x06003123 RID: 12579 RVA: 0x00136A57 File Offset: 0x00134C57
    //     public override double value
    //     {
    //         get
    //         {
    //             return Main.main.SR.townMaterials[(int)this.kind];
    //         }
    //         set
    //         {
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(TownMaterial), "value", MethodType.Getter)]
    public static class TownMaterial_value
    {
        private static bool Prefix(TownMaterial __instance, ref double __result)
        {
            __result = double.MaxValue;
            return false;
        }
    }
}