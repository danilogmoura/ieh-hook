using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using System.Runtime.CompilerServices;
    //
    // // Token: 0x0200048B RID: 1163
    // public partial class QUEST
    // {
    //     // Token: 0x06002674 RID: 9844 RVA: 0x000D30C0 File Offset: 0x000D12C0
    //     public bool CanClaim()
    //     {
    //         if (!this.isAccepted)
    //         {
    //             return false;
    //         }
    //         if (this.isCleared)
    //         {
    //             return false;
    //         }
    //         for (int i = 0; i < this.clearConditions.Count; i++)
    //         {
    //             if (!this.clearConditions[i]())
    //             {
    //                 return false;
    //             }
    //         }
    //         if (this.type == QuestType.Bring)
    //         {
    //             foreach (KeyValuePair<MaterialKind, double> keyValuePair in this.bringRequiredMaterials)
    //             {
    //                 if (this.TargetMaterial(keyValuePair.Key).value < keyValuePair.Value)
    //                 {
    //                     return false;
    //                 }
    //             }
    //             foreach (KeyValuePair<ResourceKind, double> keyValuePair2 in this.bringRequiredResources)
    //             {
    //                 if (this.TargetResource(keyValuePair2.Key).value < keyValuePair2.Value)
    //                 {
    //                     return false;
    //                 }
    //             }
    //         }
    //         return (this.type != QuestType.Defeat || this.DefeatTargetMonsterDefeatedNum() >= this.defeatRequredDefeatNum()) && (this.type != QuestType.Capture || this.CaptureTargetMonsterCapturedNum() >= this.captureRequiredNum()) && (this.type != QuestType.AreaComplete || this.AreaCompletedNum() >= this.areaRequredCompletedNum());
    //     }
    // }
    [HarmonyPatch(typeof(QUEST), "CanClaim")]
    public static class QUEST_CanClaim
    {
        public static void Postfix(QUEST __instance, ref bool __result)
        {
            if (__instance.kind == QuestKind.General)
            {
                __result = true;
            }
        }
    }
}