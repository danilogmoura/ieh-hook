using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x02000433 RID: 1075
    // public class Essence : NUMBER
    // {
    //     // Token: 0x060027CB RID: 10187 RVA: 0x000E2AFA File Offset: 0x000E0CFA
    //     public override string Name()
    //     {
    //         return Localized.localized.EssenceName(this.kind);
    //     }
    //
    //     // Token: 0x060027CC RID: 10188 RVA: 0x000E2B0C File Offset: 0x000E0D0C
    //     public Essence(EssenceKind kind)
    //         : base(null, null)
    //     {
    //         this.kind = kind;
    //     }
    //
    //     // Token: 0x17000A5D RID: 2653
    //     // (get) Token: 0x060027CD RID: 10189 RVA: 0x000E2B1D File Offset: 0x000E0D1D
    //     // (set) Token: 0x060027CE RID: 10190 RVA: 0x000E2B35 File Offset: 0x000E0D35
    //     public override double value
    //     {
    //         get
    //         {
    //             return Main.main.SR.essences[(int)this.kind];
    //         }
    //         set
    //         {
    //             Main.main.SR.essences[(int)this.kind] = value;
    //         }
    //     }
    //
    //     // Token: 0x0400100A RID: 4106
    //     public EssenceKind kind;
    // }

    [HarmonyPatch(typeof(Essence), "value", MethodType.Getter)]
    public static class EssenceValueGetterPatch
    {
        private static bool Prefix(Essence __instance, ref double __result)
        {
            __result = double.MaxValue;
            return false;
        }
    }
}