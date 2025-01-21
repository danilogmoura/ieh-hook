using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using System.Runtime.CompilerServices;
    //
    // // Token: 0x02000496 RID: 1174
    // public partial class QuestController
    // {
    //     // Token: 0x060026DC RID: 9948 RVA: 0x000D8224 File Offset: 0x000D6424
    //     public void ClaimFavorite(HeroKind heroKind)
    //     {
    //         if (GameController.game.battleCtrls[(int)heroKind].isActiveBattle)
    //         {
    //             for (int i = 0; i < this.generalQuests[(int)heroKind].Length; i++)
    //             {
    //                 if (this.generalQuests[(int)heroKind][i].isFavorite)
    //                 {
    //                     this.generalQuests[(int)heroKind][i].Claim();
    //                 }
    //             }
    //         }
    //     }
    // }
    [HarmonyPatch(typeof(QuestController), "ClaimFavorite", typeof(HeroKind))]
    public static class QuestController_ClaimFavorite
    {
        public static void Postfix(QuestController __instance, HeroKind heroKind)
        {
            var quests = Traverse.Create(__instance).Field("generalQuests").GetValue<QUEST[][]>();

            if (!GameController.game.battleCtrls[(int)heroKind].isActiveBattle) return;

            for (var i = 0; i < quests[(int)heroKind].Length; i++)
            {
                quests[(int)heroKind][i].isFavorite = true;
                quests[(int)heroKind][i].Claim();
            }
        }
    }
}