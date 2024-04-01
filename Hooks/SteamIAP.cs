using System;
using HarmonyLib;
using MelonLoader;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using System.Net.Http;
    // using System.Threading;
    // using System.Threading.Tasks;
    // using Cysharp.Threading.Tasks;
    // using Newtonsoft.Json.Linq;
    // using Steamworks;
    // using UnityEngine;
    // using UnityEngine.UI;
    //
    // // Token: 0x0200001B RID: 27
    // public partial class SteamIAP
    // {
    // 	// Token: 0x06000085 RID: 133 RVA: 0x00009D44 File Offset: 0x00007F44
    // 	private async void Buy()
    // 	{
    // 		SteamIAP.isTxn = true;
    // 		SteamIAP.isShowBlackImage = true;
    // 		SteamIAP.isPurchaseApprovedBySteam = 0;
    // 		CSteamID steamID = SteamUser.GetSteamID();
    // 		ulong id = steamID.m_SteamID;
    // 		SteamApps.GetCurrentGameLanguage();
    // 		Debug.Log(JObject.Parse(await (await SteamIAP.httpClient.GetAsync("https://partner.steam-api.com/ISteamMicroTxn/GetUserInfo/v2/?key=" + SteamIAP.SteamWebAPIKey + "&steamid=" + id.ToString()).AsUniTask(true)).Content.ReadAsStringAsync())["response"]["params"]["currency"].ToString());
    // 		int num = global::UnityEngine.Random.Range(1, int.MaxValue);
    // 		FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(new Dictionary<string, string>
    // 		{
    // 			{
    // 				"key",
    // 				SteamIAP.SteamWebAPIKey
    // 			},
    // 			{
    // 				"orderid",
    // 				num.ToString()
    // 			},
    // 			{
    // 				"steamid",
    // 				id.ToString()
    // 			},
    // 			{
    // 				"appid",
    // 				SteamIAP.appId
    // 			},
    // 			{
    // 				"itemcount",
    // 				1.ToString()
    // 			},
    // 			{ "language", "en" },
    // 			{ "currency", "USD" },
    // 			{ "itemid[0]", this.itemId },
    // 			{
    // 				"qty[0]",
    // 				1.ToString()
    // 			},
    // 			{ "amount[0]", this.amount },
    // 			{ "description[0]", this.description }
    // 		});
    // 		Debug.Log(formUrlEncodedContent);
    // 		try
    // 		{
    // 			await SteamIAP.httpClient.PostAsync("https://partner.steam-api.com/ISteamMicroTxn/InitTxn/v3/", formUrlEncodedContent);
    // 		}
    // 		catch (TaskCanceledException)
    // 		{
    // 			SteamIAP.isPurchaseApprovedBySteam = -1;
    // 		}
    // 		this.CheckCountSec();
    // 		await UniTask.WaitUntil(() => SteamIAP.isPurchaseApprovedBySteam != 0, PlayerLoopTiming.Update, default(CancellationToken));
    // 		if (SteamIAP.isPurchaseApprovedBySteam == -1)
    // 		{
    // 			SteamIAP.isTxn = false;
    // 			SteamIAP.isShowBlackImage = false;
    // 			ConfirmUI confirm = new ConfirmUI(GameControllerUI.gameUI.popupCtrlUI.defaultConfirm);
    // 			confirm.SetUI("Failed.\nPlease try again after a while.");
    // 			confirm.okButton.onClick.RemoveAllListeners();
    // 			confirm.okButton.onClick.AddListener(delegate
    // 			{
    // 				confirm.Hide();
    // 			});
    // 		}
    // 		else
    // 		{
    // 			if (SteamIAP.isPurchaseApprovedBySteam == 1)
    // 			{
    // 				this.OnApproved();
    // 			}
    // 			SteamIAP.isTxn = false;
    // 			SteamIAP.isShowBlackImage = false;
    // 		}
    // 	}
    // }

    [HarmonyPatch(typeof(SteamIAP), "Buy")]
    public static class SteamIAP_Buy
    {
        private static void Postfix(SteamIAP __instance)
        {
            SteamIAP.isPurchaseApprovedBySteam = 1;

            try
            {
                Traverse.Create(__instance).Method("OnApproved").GetValue();
            }
            catch (Exception e)
            {
                MelonLogger.Msg(e.Message);
                throw;
            }

            SteamIAP.isTxn = false;
            SteamIAP.isShowBlackImage = false;
        }
    }

    //     using System;
    //     using System.Net.Http;
    //     using System.Threading;
    //     using Cysharp.Threading.Tasks;
    //     using Steamworks;
    //     using UnityEngine;
    //     using UnityEngine.UI;
    //
    //     // Token: 0x0200001B RID: 27
    //     public partial class SteamIAP
    //     {
    //         // Token: 0x06000086 RID: 134 RVA: 0x00009D7C File Offset: 0x00007F7C
    //         private async void CheckCountSec()
    //         {
    //             for (int i = 0; i < 10; i++)
    //             {
    //                 await UniTask.Delay(1000, false, PlayerLoopTiming.Update, default(CancellationToken));
    //                 if (SteamIAP.isPurchaseApprovedBySteam != 0)
    //                 {
    //                     return;
    //                 }
    //             }
    //             if (SteamIAP.isPurchaseApprovedBySteam == 0)
    //             {
    //                 GameControllerUI.gameUI.epicStorUI.inAppFailedText.gameObject.SetActive(true);
    //             }
    //             for (int i = 0; i < 120; i++)
    //             {
    //                 await UniTask.Delay(1000, false, PlayerLoopTiming.Update, default(CancellationToken));
    //                 if (SteamIAP.isPurchaseApprovedBySteam != 0)
    //                 {
    //                     return;
    //                 }
    //             }
    //             SteamIAP.isShowBlackImage = false;
    //         }
    //     }
    [HarmonyPatch(typeof(SteamIAP), "CheckCountSec")]
    public static class SteamIAP_CheckCountSec
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}