using System;
using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    //
    // // Token: 0x020005F9 RID: 1529
    // public partial class UpgradeController
    // {
    // 	// Token: 0x060031CE RID: 12750 RVA: 0x00137E84 File Offset: 0x00136084
    // 	public UpgradeController()
    // 	{
    // 		this.resourceUpgrades = new ResourceUpgrade[Parameter.resourceUpgradeTier];
    // 		this.basicStatsUpgrades = new BasicStatsUpgrade[Enum.GetNames(typeof(BasicStatsKind)).Length];
    // 		this.goldCapUpgrades = new GoldCapUpgrade[Enum.GetNames(typeof(ResourceKind)).Length];
    // 		this.generalUpgradeList = new List<UPGRADE>();
    // 		this.sb1List = new List<UPGRADE>();
    // 		this.sb2List = new List<UPGRADE>();
    // 		this.sb3List = new List<UPGRADE>();
    // 		this.slimebankUpgradeList = new List<UPGRADE>();
    // 		this.upgradeList = new List<UPGRADE>();
    // 		this.goldcapMultipliers = new Multiplier[Enum.GetNames(typeof(ResourceKind)).Length];
    // 		base..ctor();
    // 		this.costReduction = new Multiplier(() => 0.99, () => 0.0);
    // 		this.costReductionFromGuildAbility = new Multiplier(() => 0.99, () => 0.0);
    // 		this.costReductionFromGuildSuperAbility = new Multiplier(() => 0.99, () => 0.0);
    // 		this.costReductionFromWA = new Multiplier(() => 0.99, () => 0.0);
    // 		this.costReductionFromMissionMilestone = new Multiplier(() => 0.99, () => 0.0);
    // 		this.resourceMultiplier = new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 1.0, null), null, null);
    // 		this.statsMultiplier = new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 1.0, null), null, null);
    // 		this.goldcapMultiplier = new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 1.0, null), null, null);
    // 		for (int i = 0; i < this.goldcapMultipliers.Length; i++)
    // 		{
    // 			this.goldcapMultipliers[i] = new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 1.0, null), null, null);
    // 		}
    // 		this.resourceCostIncrementPerLevelReduction = new Multiplier(() => 0.9, () => 0.0);
    // 		this.resourceGainTierFactor = new Multiplier(() => 5.0, () => 0.0);
    // 		for (int j = 0; j < this.resourceUpgrades.Length; j++)
    // 		{
    // 			this.resourceUpgrades[j] = new ResourceUpgrade(j);
    // 		}
    // 		for (int k = 0; k < this.basicStatsUpgrades.Length; k++)
    // 		{
    // 			int num = k;
    // 			this.basicStatsUpgrades[k] = new BasicStatsUpgrade((BasicStatsKind)num);
    // 		}
    // 		this.goldGainUpgrade = new GoldGainUpgrade();
    // 		this.expGainUpgrade = new ExpGainUpgrade();
    // 		for (int l = 0; l < this.goldCapUpgrades.Length; l++)
    // 		{
    // 			int num2 = l;
    // 			this.goldCapUpgrades[l] = new GoldCapUpgrade((ResourceKind)num2);
    // 		}
    // 		this.equipmentInventoryUpgrade = new EquipmentInventoryUpgrade();
    // 		this.generalUpgradeList.AddRange(this.resourceUpgrades);
    // 		this.generalUpgradeList.AddRange(this.basicStatsUpgrades);
    // 		this.generalUpgradeList.Add(this.goldGainUpgrade);
    // 		this.generalUpgradeList.Add(this.expGainUpgrade);
    // 		this.generalUpgradeList.AddRange(this.goldCapUpgrades);
    // 		this.generalUpgradeList.Add(this.equipmentInventoryUpgrade);
    // 		this.sb1List.Add(new SB_SlimeCoinCap());
    // 		this.sb1List.Add(new SB_SlimeCoinCap2());
    // 		this.sb1List.Add(new SB_SlimeCoinEfficiency());
    // 		this.sb1List.Add(new SB_UpgradeCostReduction());
    // 		this.sb1List.Add(new SB_ResourceBooster());
    // 		this.sb1List.Add(new SB_StatsBooster());
    // 		this.sb1List.Add(new SB_GoldCapBooster());
    // 		this.sb2List.Add(new SB_GoldGain());
    // 		this.sb2List.Add(new SB_MysteriousWaterGain());
    // 		this.sb2List.Add(new SB_SPD());
    // 		this.sb2List.Add(new SB_FireRes());
    // 		this.sb2List.Add(new SB_IceRes());
    // 		this.sb2List.Add(new SB_ThunderRes());
    // 		this.sb2List.Add(new SB_LightRes());
    // 		this.sb2List.Add(new SB_DarkRes());
    // 		this.sb3List.Add(new SB_DebuffRes());
    // 		this.sb3List.Add(new SB_SkillProf());
    // 		this.sb3List.Add(new SB_EquipmentProf());
    // 		this.sb3List.Add(new SB_MaterialFinder());
    // 		this.sb3List.Add(new SB_ShopTimer());
    // 		this.sb3List.Add(new SB_CritDamage());
    // 		this.sb3List.Add(new SB_ResearchPower());
    // 		this.slimebankUpgradeList.AddRange(this.sb1List);
    // 		this.slimebankUpgradeList.AddRange(this.sb2List);
    // 		this.slimebankUpgradeList.AddRange(this.sb3List);
    // 		for (int m = 0; m < Enum.GetNames(typeof(ResourceKind)).Length; m++)
    // 		{
    // 			GameController.game.statsCtrl.ResourceGain((ResourceKind)m).RegisterMultiplier(new MultiplierInfo(MultiplierKind.Upgrade, MultiplierType.Add, () => this.ResourceGain(false, 0), null));
    // 		}
    // 		UPGRADE[][] array = new UPGRADE[7][];
    // 		int num3 = 0;
    // 		UPGRADE[] array2 = this.resourceUpgrades;
    // 		array[num3] = array2;
    // 		int num4 = 1;
    // 		array2 = this.basicStatsUpgrades;
    // 		array[num4] = array2;
    // 		array[2] = new UPGRADE[] { this.goldGainUpgrade };
    // 		array[3] = new UPGRADE[] { this.expGainUpgrade };
    // 		int num5 = 4;
    // 		array2 = this.goldCapUpgrades;
    // 		array[num5] = array2;
    // 		array[5] = this.slimebankUpgradeList.ToArray();
    // 		array[6] = new UPGRADE[] { this.equipmentInventoryUpgrade };
    // 		this.upgrades = array;
    // 		this.upgradeList.AddRange(this.generalUpgradeList);
    // 		this.upgradeList.AddRange(this.slimebankUpgradeList);
    // 		this.availableQueue = new Multiplier();
    // 	}
    // }

    [HarmonyPatch(typeof(UpgradeController), MethodType.Constructor)]
    public class UpgradeController_Constructor
    {
        public static void Postfix(UpgradeController __instance)
        {
            Func<double> maxValue = () => double.MaxValue;

            __instance.availableQueue = new Multiplier(() => 900.0, () => 900.0);

            __instance.goldcapMultiplier =
                new Multiplier(new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 1), maxValue,
                    maxValue);

            for (var i = 0; i < __instance.goldcapMultipliers.Length; i++)
                __instance.goldcapMultipliers[i] = new Multiplier(
                    new MultiplierInfo(MultiplierKind.Base, MultiplierType.Add, () => 1), maxValue, maxValue);
        }
    }
}