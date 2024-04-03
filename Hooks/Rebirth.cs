using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using MelonLoader;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    //
    // // Token: 0x02000525 RID: 1317
    // public partial class Rebirth
    // {
    // 	// Token: 0x060028DF RID: 10463 RVA: 0x000E22E0 File Offset: 0x000E04E0
    // 	private void ResetSave()
    // 	{
    // 		GameController.game.areaCtrl.areaClearedNums[(int)this.heroKind] = 0.0;
    // 		GameController.game.statsCtrl.Exp(this.heroKind).ChangeValue(0.0, false);
    // 		GameController.game.statsCtrl.HeroLevel(this.heroKind).ChangeValue(0L);
    // 		GameController.game.statsCtrl.ResetAbilityPoint(this.heroKind, false);
    // 		for (int i = 0; i < GameController.game.questCtrl.QuestArray(QuestKind.General, this.heroKind).Length; i++)
    // 		{
    // 			GameController.game.questCtrl.QuestArray(QuestKind.General, this.heroKind)[i].isAccepted = false;
    // 			GameController.game.questCtrl.QuestArray(QuestKind.General, this.heroKind)[i].isCleared = false;
    // 		}
    // 		GameController.game.statsCtrl.MovedDistance(this.heroKind, true).ChangeValue(0.0, false);
    // 		if (GameController.game.potionCtrl.unlockTrapCooltimeResetOnRebirth.IsUnlocked())
    // 		{
    // 			GameController.game.potionCtrl.GlobalInfo(PotionKind.ThrowingNet).ResetCooldown(this.heroKind);
    // 			GameController.game.potionCtrl.GlobalInfo(PotionKind.FireRope).ResetCooldown(this.heroKind);
    // 			GameController.game.potionCtrl.GlobalInfo(PotionKind.IceRope).ResetCooldown(this.heroKind);
    // 			GameController.game.potionCtrl.GlobalInfo(PotionKind.ThunderRope).ResetCooldown(this.heroKind);
    // 			GameController.game.potionCtrl.GlobalInfo(PotionKind.LightRope).ResetCooldown(this.heroKind);
    // 			GameController.game.potionCtrl.GlobalInfo(PotionKind.DarkRope).ResetCooldown(this.heroKind);
    // 		}
    // 		if (this.tier < 1)
    // 		{
    // 			return;
    // 		}
    // 		long num = 0L;
    // 		if (this.rebirthCtrl.Rebirth(this.heroKind, 2).rebirthNum > 0L)
    // 		{
    // 			this.rebirthCtrl.Rebirth(this.heroKind, 2).additionalAbilityPoint.Calculate(false);
    // 			num = (long)this.rebirthCtrl.Rebirth(this.heroKind, 2).additionalAbilityPoint.Value();
    // 		}
    // 		for (int j = 0; j < GameController.game.skillCtrl.SkillArray(this.heroKind).Length; j++)
    // 		{
    // 			GameController.game.skillCtrl.SkillArray(this.heroKind)[j].proficiency.ChangeValue(0.0, false);
    // 			if (j == 0)
    // 			{
    // 				GameController.game.skillCtrl.SkillArray(this.heroKind)[j].level.ChangeValue(num);
    // 			}
    // 			else
    // 			{
    // 				GameController.game.skillCtrl.SkillArray(this.heroKind)[j].level.ChangeValue(0L);
    // 			}
    // 		}
    // 		if (this.tier < 2)
    // 		{
    // 			return;
    // 		}
    // 		for (int k = 0; k < GameController.game.equipmentCtrl.globalInformations.Length; k++)
    // 		{
    // 			if (!GameController.game.equipmentCtrl.globalInformations[k].isArtifact)
    // 			{
    // 				GameController.game.equipmentCtrl.globalInformations[k].proficiencies[(int)this.heroKind].ChangeValue(0.0, false);
    // 				GameController.game.equipmentCtrl.globalInformations[k].levels[(int)this.heroKind].ChangeValue(0L);
    // 				GameController.game.equipmentCtrl.globalInformations[k].levels[(int)this.heroKind].isMaxedThisRebirth = false;
    // 			}
    // 		}
    // 	}
    // }

    [HarmonyPatch(typeof(Rebirth), "ResetSave")]
    public class Rebirth_ResetSave
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var found = false;
            var codes = new List<CodeInstruction>(instructions);

            for (var i = 0; i < codes.Count; i++)
                if (codes[i].opcode == OpCodes.Callvirt && codes[i].operand is MethodInfo methodInfo &&
                    methodInfo.Name == "set_isAccepted")
                {
                    codes[i - 1].opcode = OpCodes.Ldc_I4_1;
                    found = true;
                }

            if (found is false)
                MelonLogger.Error("Cannot find <Callvirt set_isAccepted> in Rebirth.ResetSave");

            return instructions;
        }
    }
}