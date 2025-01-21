using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using System.Runtime.CompilerServices;
    // using UnityEngine;
    //
    // // Token: 0x02000024 RID: 36
    // public partial class BATTLE : RANGE
    // {
    //     // Token: 0x060000F7 RID: 247 RVA: 0x00016150 File Offset: 0x00014350
    //     public virtual void Activate()
    //     {
    //         this.isAlive = true;
    //         this.move.Initialize();
    //         if (this.isHero && this.battleCtrl.isSuperDungeon && this.battleCtrl.superDungeonCtrl.currentSD != null && this.battleCtrl.superDungeonCtrl.currentSD.modifierCtrl.HPModifier() < 1.0)
    //         {
    //             this.currentHp.ChangeValue(this.hp * this.battleCtrl.superDungeonCtrl.currentSD.modifierCtrl.HPModifier(), true);
    //         }
    //         else
    //         {
    //             this.currentHp.ChangeValue(this.hp, true);
    //         }
    //         if (!this.isHero && this.battleCtrl.isSuperDungeon && this.battleCtrl.superDungeonCtrl.currentSD != null && this.battleCtrl.superDungeonCtrl.currentSD.modifierCtrl.unlockMobCastFull.IsUnlocked())
    //         {
    //             this.currentMp.ChangeValue(this.mp, true);
    //         }
    //         else
    //         {
    //             this.currentMp.ChangeValue(0.0, true);
    //         }
    //         this.ResetCooltime();
    //         this.CureDebuff();
    //     }
    // }

    [HarmonyPatch(typeof(BATTLE), "Activate")]
    public static class BATTLE_Activate
    {
        private static void Postfix(BATTLE __instance)
        {
            switch (__instance.isHero)
            {
                case false:
                    __instance.currentHp.ChangeValue(10.0, true);
                    break;
                case true:
                    __instance.currentHp.ChangeValue(double.MaxValue, true);
                    __instance.currentMp.ChangeValue(double.MaxValue, true);
                    break;
            }
        }
    }
}