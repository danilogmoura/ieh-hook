using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x02000393 RID: 915
    // public partial class Expedition
    // {
    //     // Token: 0x060021CC RID: 8652 RVA: 0x000C0780 File Offset: 0x000BE980
    //     public void Progress(double deltaTime)
    //     {
    //         if (!this.isStarted)
    //         {
    //             return;
    //         }
    //         if (this.isFinished)
    //         {
    //             return;
    //         }
    //         this.progress.Increase(deltaTime, false);
    //         this.globalInfo.totalTime += deltaTime;
    //         this.GetExp(deltaTime);
    //         this.GetMove(deltaTime);
    //         this.globalInfo.GetExp(deltaTime, this.PetNum());
    //     }
    // }

    [HarmonyPatch(typeof(Expedition), "Progress")]
    public static class Expedition_ProgressPatch
    {
        public static void Prefix(Expedition __instance, ref double deltaTime)
        {
            deltaTime *= 1_000;
        }
    }


    // using System;
    //
    // // Token: 0x020003B7 RID: 951
    // public partial class Expedition
    // {
    //     // Token: 0x0600238F RID: 9103 RVA: 0x000D11F2 File Offset: 0x000CF3F2
    //     public double ExpGainPerSec()
    //     {
    //         return this.globalInfo.PetExpGainPerSec();
    //     }
    // }

    [HarmonyPatch(typeof(Expedition), "ExpGainPerSec")]
    public static class Expedition_ExpGainPerSec
    {
        public static bool Prefix(Expedition __instance, ref double __result)
        {
            __result = __instance.globalInfo.PetExpGainPerSec() * 1_000;
            return false;
        }
    }

    // using System;
    //
    // // Token: 0x020003B7 RID: 951
    // public partial class Expedition
    // {
    //     // Token: 0x06002380 RID: 9088 RVA: 0x000D0EC0 File Offset: 0x000CF0C0
    //     public double RequiredGold()
    //     {
    //         return 5000.0 * Math.Max(1.0, Math.Pow((double)this.PetNum(), 2.0)) * (1.0 + Math.Pow((double)this.timeId.value, 2.0)) * Math.Pow(2.0, (double)Math.Max(0L, this.timeId.value - 3L));
    //     }
    // }

    [HarmonyPatch(typeof(Expedition), "RequiredGold")]
    public static class Expedition_RequiredGold
    {
        public static bool Prefix(Expedition __instance, ref double __result)
        {
            __result = 0.0;
            return false;
        }
    }
}