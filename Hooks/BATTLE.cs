using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using System.Runtime.CompilerServices;
    // using UnityEngine;
    //
    // // Token: 0x02000022 RID: 34
    // public partial class BATTLE : RANGE
    // {
    //     // Token: 0x0600010D RID: 269 RVA: 0x00016D24 File Offset: 0x00014F24
    //     public void Update(float deltaTime)
    //     {
    //         if (!this.isAlive)
    //         {
    //             return;
    //         }
    //         if (!this.isHero || !this.battleCtrl.isSuperDungeon || !this.battleCtrl.superDungeonCtrl.IsDodge() || GameController.game.sdgCtrl.unlockFlexibleDodge.IsUnlocked())
    //         {
    //             this.UpdateMove(deltaTime);
    //             this.UpdateSkillCooltime(deltaTime);
    //             this.UpdateTriggerSkill();
    //         }
    //         this.UpdateCheckDefeated();
    //         this.Regenerate(deltaTime);
    //     }
    // }

    // [HarmonyPatch(typeof(BATTLE), "Update")]
    public static class BATTLE_Update
    {
        private static void Prefix(BATTLE __instance, ref float deltaTime)
        {
            deltaTime *= 1_000;
        }
    }


    // using System;
    // using System.Collections.Generic;
    // using System.Runtime.CompilerServices;
    // using UnityEngine;
    //
    // // Token: 0x02000022 RID: 34
    // public partial class BATTLE : RANGE
    // {
    //     // Token: 0x060000FE RID: 254 RVA: 0x00016A69 File Offset: 0x00014C69
    //     private void UpdateCheckDefeated()
    //     {
    //         if (this.isAlive && this.currentHp.value <= 0.0)
    //         {
    //             this.DeadAction();
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(BATTLE), "UpdateCheckDefeated")]
    public static class BATTLE_UpdateCheckDefeated
    {
        private static void Prefix(BATTLE __instance)
        {
            if (!__instance.isHero && __instance.isAlive)
                __instance.DeadAction();
        }
    }
}