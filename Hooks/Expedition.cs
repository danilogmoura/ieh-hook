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
    public static class ExpeditionProgressPatch
    {
        public static void Prefix(Expedition __instance, ref double deltaTime)
        {
            deltaTime *= 1_000;
        }
    }
}