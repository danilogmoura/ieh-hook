using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x020001D0 RID: 464
    // public partial class Battle_Octobaddie : CHALLENGE_BATTLE
    // {
    // 	// Token: 0x0600125A RID: 4698 RVA: 0x000731C8 File Offset: 0x000713C8
    // 	public override void UpdateTriggerSkill()
    // 	{
    // 		if (!this.isFirstReverseGravity)
    // 		{
    // 			this.StartReverseGravity();
    // 			this.isFirstReverseGravity = true;
    // 		}
    // 		if (!this.isDestroyedProtect)
    // 		{
    // 			this.ReverseGravity();
    // 			if (this.sliderPercent <= 0.0)
    // 			{
    // 				this.FinishReverseGravity();
    // 			}
    // 		}
    // 		if (!base.isMpCharged)
    // 		{
    // 			return;
    // 		}
    // 		switch (this.currentAttackColor)
    // 		{
    // 		case AttackColor.Blue:
    // 			this.attack[0].LoopAttack(this, 1f, 0.1f, false, 2f, 1.0, false);
    // 			if (GameController.game.IsUI(this.battleCtrl.heroKind, false) && this.animationEffectUIAction != null)
    // 			{
    // 				this.animationEffectUIAction(this.attack[0], AnimationEffectKind.OctoInkExplosion);
    // 			}
    // 			break;
    // 		case AttackColor.Green:
    // 			this.StartReverseGravity();
    // 			break;
    // 		case AttackColor.Yellow:
    // 			this.InkBulletCornerAttack();
    // 			break;
    // 		case AttackColor.Red:
    // 			this.attack[11].NormalAttack(this, 60, 1.0, 0);
    // 			this.attack[12].NormalAttack(this, 60, 1.0, 0);
    // 			if (GameController.game.IsUI(this.battleCtrl.heroKind, false) && this.particleEffectUIAction != null)
    // 			{
    // 				this.particleEffectUIAction(this.attack[11], ParticleEffectKind.OctoWaterExplosion);
    // 			}
    // 			break;
    // 		case AttackColor.Purple:
    // 			this.InkBulletRandomAttack();
    // 			break;
    // 		case AttackColor.Gray:
    // 			this.InkBulletTrackingAttack();
    // 			break;
    // 		}
    // 		this.currentMp.ChangeValue(0.0, false);
    // 		this.targetPosition = this.battleCtrl.hero.move.position;
    // 		float num = global::UnityEngine.Random.Range(0f, 1f);
    // 		if (this.isDestroyedProtect && (double)base.HpPercent() < 0.5 && num <= 0.05f)
    // 		{
    // 			this.currentAttackColor = AttackColor.Green;
    // 			return;
    // 		}
    // 		if (num <= 0.25f)
    // 		{
    // 			this.currentAttackColor = AttackColor.Blue;
    // 			return;
    // 		}
    // 		if (num <= 0.45f)
    // 		{
    // 			this.currentAttackColor = AttackColor.Gray;
    // 			return;
    // 		}
    // 		if (num <= 0.7f)
    // 		{
    // 			this.currentAttackColor = AttackColor.Yellow;
    // 			return;
    // 		}
    // 		if (num <= 0.9f)
    // 		{
    // 			this.currentAttackColor = AttackColor.Red;
    // 			return;
    // 		}
    // 		this.currentAttackColor = AttackColor.Purple;
    // 	}
    // }

    [HarmonyPatch(typeof(Battle_Octobaddie), "UpdateTriggerSkill")]
    public static class Battle_Octobaddie_UpdateTriggerSkill
    {
        public static void Postfix(Battle_Octobaddie __instance)
        {
            __instance.currentAttackColor = AttackColor.Green;
            Traverse.Create(__instance).Field("isDestroyedProtect").SetValue(true);
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x020001D0 RID: 464
    // public partial class Battle_Octobaddie : CHALLENGE_BATTLE
    // {
    //     // Token: 0x06001257 RID: 4695 RVA: 0x00071D1C File Offset: 0x0006FF1C
    //     public override void Activate()
    //     {
    //         base.Activate();
    //         this.currentAttackColor = AttackColor.Blue;
    //         this.targetPosition = Parameter.HeroInitPosition(1f);
    //         this.isFirstReverseGravity = false;
    //         this.attackedCount = 0.0;
    //         this.isDestroyedProtect = false;
    //         this.regenProtectCount = 0;
    //     }
    // }

    [HarmonyPatch(typeof(Battle_Octobaddie), "Activate")]
    public static class Battle_Octobaddie_Activate
    {
        public static void Postfix(Battle_Octobaddie __instance)
        {
            __instance.currentAttackColor = AttackColor.Green;
            Traverse.Create(__instance).Field("isDestroyedProtect").SetValue(true);
        }
    }
}