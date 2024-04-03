using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Threading;
    // using Cysharp.Threading.Tasks;
    // using TMPro;
    // using UnityEngine;
    // using UnityEngine.UI;
    //
    // // Token: 0x02000697 RID: 1687
    // public partial class IEH1PlayerBonusUI : MonoBehaviour
    // {
    // 	// Token: 0x06003831 RID: 14385 RVA: 0x00219514 File Offset: 0x00217714
    // 	private async void CheckBonus()
    // 	{
    // 		this.openButton.interactable = false;
    // 		this.quitButton.interactable = false;
    // 		this.tempStr = "";
    // 		if (!this.isChecked)
    // 		{
    // 			if (this.isTrying)
    // 			{
    // 				this.quitButton.interactable = true;
    // 				return;
    // 			}
    // 			this.isTrying = true;
    // 			this.receivedText.text = Localized.localized.IEH1PlayerBonusString(2, "");
    // 			if (!SteamManager.Initialized)
    // 			{
    // 				this.receivedText.text = Localized.localized.IEH1PlayerBonusString(3, "");
    // 				this.openButton.interactable = true;
    // 				this.quitButton.interactable = true;
    // 				return;
    // 			}
    // 			this.isTryAchiv = true;
    // 			this.TimeoutAchiv();
    // 			int num = await GameController.game.getAchievementInfoIEH1.AchievementsAchievedCount();
    // 			this.checkedAchievementNum = num;
    // 			this.isTryAchiv = false;
    // 			if (GameController.game.getOwnerShipIEH1DLC_IEH2SupportPack == null)
    // 			{
    // 				GameController.game.getOwnerShipIEH1DLC_IEH2SupportPack = new GetOwnerShip("F6724F6EF14E3AE95B7B7F14E53BEEC3", "1580930");
    // 			}
    // 			else if (!GameController.game.getOwnerShipIEH1DLC_IEH2SupportPack.isGotInfo)
    // 			{
    // 				GameController.game.getOwnerShipIEH1DLC_IEH2SupportPack.Initialize();
    // 				this.isTryDLC = true;
    // 				this.TimeoutDLC();
    // 				await UniTask.WaitUntil(() => GameController.game.getOwnerShipIEH1DLC_IEH2SupportPack.isGotInfo, PlayerLoopTiming.Update, default(CancellationToken));
    // 				this.isTryDLC = false;
    // 			}
    // 			this.isPurchasedDLC = GameController.game.getOwnerShipIEH1DLC_IEH2SupportPack.isOwn;
    // 			if (this.checkedAchievementNum < 1)
    // 			{
    // 				this.tempStr += Localized.localized.IEH1PlayerBonusString(4, "");
    // 			}
    // 			this.isTrying = false;
    // 			this.isChecked = true;
    // 		}
    // 		if (!Main.main.S.isReceivedIEH1DLCIEH2SupportPack && this.isPurchasedDLC)
    // 		{
    // 			this.tempStr = string.Concat(new string[]
    // 			{
    // 				this.tempStr,
    // 				Localized.localized.SettingMenuString(4, ""),
    // 				":\n<color=green><sprite=\"EpicCoin\" index=0> 5500 ",
    // 				Localized.localized.Basic(BasicWord.EpicCoin),
    // 				"\n",
    // 				Localized.localized.IEH1PlayerBonusString(5, ""),
    // 				"</color>\n\n"
    // 			});
    // 			GameController.game.epicStoreCtrl.epicCoin.Increase(5500.0, false);
    // 			Main.main.S.isReceivedIEH1DLCIEH2SupportPack = true;
    // 		}
    // 		int num2 = this.checkedAchievementNum + (int)GameController.game.epicStoreCtrl.Item(EpicStoreKind.BribesForIEH1).purchasedNum.value;
    // 		int num3 = Math.Min(num2, IEH1PlayerBonusUI.ReceivableNumTalisman()) - Main.main.S.receivedIEH1Achievement;
    // 		if (num3 > 0)
    // 		{
    // 			if (!GameController.game.inventoryCtrl.CanCreatePotion(PotionKind.AscendedFromIEH1, (long)num3))
    // 			{
    // 				this.tempStr += Localized.localized.IEH1PlayerBonusString(6, UsefulMethod.tDigit((double)(1 + num3 / 10), 0, false, null, false, false, false));
    // 			}
    // 			else
    // 			{
    // 				this.tempStr = string.Concat(new string[]
    // 				{
    // 					this.tempStr,
    // 					Localized.localized.SettingMenuString(4, ""),
    // 					":\n<color=green>",
    // 					UsefulMethod.tDigit((double)num3, 0, false, null, false, false, false),
    // 					" ",
    // 					Localized.localized.Basic(BasicWord.Talisman),
    // 					" [ ",
    // 					Localized.localized.PotionName(PotionKind.AscendedFromIEH1),
    // 					" ]"
    // 				});
    // 				GameController.game.inventoryCtrl.CreatePotion(PotionKind.AscendedFromIEH1, (long)num3, false, true);
    // 				Main.main.S.receivedIEH1Achievement += num3;
    // 			}
    // 		}
    // 		else if (num2 > 0)
    // 		{
    // 			this.tempStr += Localized.localized.IEH1PlayerBonusString(7, "");
    // 		}
    // 		this.receivedText.text = this.tempStr;
    // 		this.quitButton.interactable = true;
    // 		this.openButton.interactable = true;
    // 	}
    // }

    [HarmonyPatch(typeof(IEH1PlayerBonusUI), "CheckBonus")]
    public static class IEH1PlayerBonusUI_CheckBonus
    {
        private static bool Prefix(IEH1PlayerBonusUI __instance)
        {
            Traverse.Create(__instance).Field("isTrying").SetValue(false);
            Traverse.Create(__instance).Field("isChecked").SetValue(true);
            Traverse.Create(__instance).Field("isPurchasedDLC").SetValue(true);
            Main.main.S.isReceivedIEH1DLCIEH2SupportPack = false;

            return true;
        }
    }
}