using System.Linq;
using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using System.Runtime.CompilerServices;
    // using UnityEngine;
    //
    // // Token: 0x0200002F RID: 47
    // public partial class BATTLE_CONTROLLER
    // {
    //     // Token: 0x060001DC RID: 476 RVA: 0x0001BD74 File Offset: 0x00019F74
    //     public void Update(float deltaTime)
    //     {
    //         this.deltaTime = deltaTime;
    //         if (this.isPaused)
    //         {
    //             return;
    //         }
    //         if (this.isTryingRaid)
    //         {
    //             return;
    //         }
    //         if (!this.isActiveBattle)
    //         {
    //             return;
    //         }
    //         for (int i = 0; i < this.heroesList.Count; i++)
    //         {
    //             this.heroesList[i].Update(deltaTime);
    //         }
    //         this.superDungeonCtrl.Update((double)deltaTime);
    //         for (int j = 0; j < this.monstersList.Count; j++)
    //         {
    //             this.monstersList[j].Update(deltaTime);
    //         }
    //         this.timecount += (double)deltaTime;
    //         if (this.hero.isAlive && this.areaBattle.CurrentArea().IsTimeOver(this))
    //         {
    //             bool flag = false;
    //             CHALLENGE_SUPERDUNGEON challenge_SUPERDUNGEON = null;
    //             if (this.isSuperDungeon)
    //             {
    //                 this.superDungeonCtrl.GetLoot(false, null, true);
    //                 flag = GameControllerUI.gameUI.superDungeonBattleCtrlUI.IsAutoLeaveAndRetry(true);
    //                 challenge_SUPERDUNGEON = this.superDungeonCtrl.currentSD;
    //                 if (Main.main.S.currentSDRun > 0.0)
    //                 {
    //                     Main.main.S.currentSDRunFailed += 1.0;
    //                 }
    //                 Main.main.S.totalSDRunFailed += 1.0;
    //             }
    //             this.areaBattle.QuitCurrentArea(true, false, flag, challenge_SUPERDUNGEON);
    //         }
    //         if (this.hero.isAlive && (double)this.hero.HpPercent() < 0.5)
    //         {
    //             GameController.game.inventoryCtrl.ConsumePotion(PotionConsumeConditionKind.HpHalf, this.hero, this.isSimulated, 1L);
    //         }
    //         this.timecountForSec += (double)deltaTime;
    //         if (this.timecountForSec >= 1.0)
    //         {
    //             this.UpdatePerSec();
    //             this.timecountForSec = 0.0;
    //             this.totalDamage.ChangeCountGainperSec();
    //         }
    //         this.UpdateAttack();
    //         this.UpdateDropGenerator(deltaTime);
    //         this.areaBattle.Update(deltaTime);
    //     }
    // }

    [HarmonyPatch(typeof(BATTLE_CONTROLLER), "Update", typeof(float))]
    public static class BATTLE_CONTROLLER_Update
    {
        private static void Postfix(BATTLE_CONTROLLER __instance, float deltaTime)
        {
            __instance.hero.currentHp.ChangeValue(double.MaxValue);
            __instance.hero.currentMp.ChangeValue(double.MaxValue);
            __instance.hero.totalDamage = double.MaxValue;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using System.Runtime.CompilerServices;
    // using UnityEngine;
    //
    // // Token: 0x0200005B RID: 91
    // public partial class BATTLE_CONTROLLER
    // {
    //     // Token: 0x06000596 RID: 1430 RVA: 0x00068438 File Offset: 0x00066638
    //     public void InitializeAttack()
    //     {
    //         for (int i = 0; i < GameController.game.skillCtrl.skillsOneDimensionArray.Length; i++)
    //         {
    //             for (int j = 0; j < GameController.game.skillCtrl.skillsOneDimensionArray[i].AttackList(this).Count; j++)
    //             {
    //                 GameController.game.skillCtrl.skillsOneDimensionArray[i].AttackList(this)[j].Disable();
    //             }
    //         }
    //         for (int k = 0; k < this.heroesList.Count; k++)
    //         {
    //             for (int l = 0; l < this.heroesList[k].attack.Count; l++)
    //             {
    //                 this.heroesList[k].attack[l].Disable();
    //             }
    //         }
    //         for (int m = 0; m < this.monstersList.Count; m++)
    //         {
    //             for (int n = 0; n < this.monstersList[m].attack.Count; n++)
    //             {
    //                 this.monstersList[m].attack[n].Disable();
    //             }
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(BATTLE_CONTROLLER), "InitializeAttack")]
    public static class BATTLE_CONTROLLER_InitializeAttack
    {
        private static bool Prefix(BATTLE_CONTROLLER __instance)
        {
            foreach (var t in GameController.game.skillCtrl.skillsOneDimensionArray)
                for (var j = 0; j < t.AttackList(__instance).Count; j++)
                    t.AttackList(__instance)[j].Disable();

            foreach (var t in __instance.heroesList.SelectMany(t1 => t1.attack)) t.Disable();

            return false;
        }
    }
}