using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    //
    // // Token: 0x0200033A RID: 826
    // public partial class PotionController
    // {
    // 	// Token: 0x06001EBD RID: 7869 RVA: 0x000B692C File Offset: 0x000B4B2C
    // 	public void Start()
    // 	{
    // 		this.globalInformations.Add(new NullPotion());
    // 		this.potions.Add(new MinorHealthPotion());
    // 		this.potions.Add(new ChilledHealthPotion());
    // 		this.potions.Add(new MinorRegenerationPoultice());
    // 		this.potions.Add(new ChilledRegenerationPoultice());
    // 		this.potions.Add(new MinorManaRegenerationPoultice());
    // 		this.potions.Add(new MinorResourcePoultice());
    // 		this.potions.Add(new SlickShoeSolution());
    // 		this.potions.Add(new SlickerShoeSolution());
    // 		this.potions.Add(new SlightlyStickSalve());
    // 		this.potions.Add(new CoolHeadOintment());
    // 	}
    // }

    [HarmonyPatch(typeof(PotionController), "Start")]
    public static class PotionController_Start
    {
        public static void Postfix(PotionController __instance)
        {
            for (var i = 0; i < __instance.trapCooltimeReduction.Length; i++)
            {
                __instance.trapCooltimeReduction[i] = new Multiplier(() => 0.1, () => 0.1);
                __instance.trapCooltimeReduction[i]
                    .RegisterMultiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 10.0));
            }
        }
    }
}