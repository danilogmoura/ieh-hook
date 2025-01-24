using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x02000045 RID: 69
    // public partial class MonsterGlobalInformation
    // {
    // 	// Token: 0x0600046F RID: 1135 RVA: 0x00027310 File Offset: 0x00025510
    // 	public double Hp(long level, double difficulty, bool isPet, HeroKind heroKind, bool isSuperDungeon)
    // 	{
    // 		if (this.color == MonsterColor.Metal)
    // 		{
    // 			return MonsterParameter.monsterStats[(int)this.species][this.colorId][0] * (double)level;
    // 		}
    // 		double num = MonsterParameter.monsterStats[(int)this.species][this.colorId][0];
    // 		if (isPet)
    // 		{
    // 			num *= (double)(this.pet.Level() + 1L) + 1.0 * Math.Pow((double)this.pet.Level() / 5.0, 2.0);
    // 			num *= 1.0 + 0.05 * (double)this.pet.loyalty.value;
    // 			num *= Math.Pow(2.0, Math.Floor((double)this.pet.Level() / 50.0));
    // 			num *= GameController.game.monsterCtrl.petStatsMultiplier.Value();
    // 			num *= GameController.game.statsCtrl.BasicStats(heroKind, BasicStatsKind.HP).Mul();
    // 			if (this.isLogStats[(int)heroKind] && num >= 1.0)
    // 			{
    // 				num = MonsterParameter.monsterStats[(int)this.species][this.colorId][0] + Math.Log(num, Multiplier.logBase);
    // 			}
    // 			num += GameController.game.statsCtrl.BasicStats(heroKind, BasicStatsKind.HP).After();
    // 		}
    // 		else
    // 		{
    // 			num *= 1.0 + (double)(level - 1L) / 2.0 + 1.0 * Math.Pow((double)level / 5.0, 2.0) + 2.5 * Math.Pow((double)level / 10.0, 3.0) + 5.0 * Math.Pow((double)level / 20.0, 4.0) + 25.0 * Math.Pow((double)level / 40.0, 5.0) + 100.0 * Math.Pow((double)level / 80.0, 8.0) + 1000.0 * Math.Pow((double)level / 120.0, 10.0) + 50000.0 * Math.Pow((double)level / 200.0, 15.0) + 250000.0 * Math.Pow((double)level / 300.0, 20.0);
    // 			num *= 0.5 + 0.75 * (double)level / 100.0;
    // 			if (level >= 100L)
    // 			{
    // 				num *= Math.Pow(2.0, (double)(level - 100L) / 200.0);
    // 			}
    // 			if (level >= 400L)
    // 			{
    // 				num *= Math.Pow(3.0, (double)(level - 400L) / 100.0);
    // 				if (level >= 500L)
    // 				{
    // 					num *= Math.Pow(5.0, (double)(level - 500L) / 100.0);
    // 				}
    // 				if (level >= 600L)
    // 				{
    // 					num *= Math.Pow(10.0, (double)(level - 600L) / 100.0);
    // 				}
    // 				if (!isSuperDungeon && level >= 1500L)
    // 				{
    // 					num *= Math.Pow(10.0, (double)(level - 1500L) / 10.0);
    // 				}
    // 				if (level >= 2000L)
    // 				{
    // 					num *= Math.Pow(100000.0, (double)(level - 2000L) / 100.0);
    // 				}
    // 				if (this.species == MonsterSpecies.ChallengeBoss)
    // 				{
    // 					if (isSuperDungeon)
    // 					{
    // 						num *= Math.Pow(3.0, (double)(level - 400L) / 100.0);
    // 					}
    // 					else
    // 					{
    // 						num *= Math.Pow(5.0, (double)(level - 400L) / 100.0);
    // 					}
    // 				}
    // 			}
    // 			if (this.species == MonsterSpecies.ChallengeBoss)
    // 			{
    // 				num *= 3.0;
    // 			}
    // 			num *= Math.Pow(10.0, difficulty / 10.0);
    // 		}
    // 		return num;
    // 	}
    // }

    [HarmonyPatch(typeof(MonsterGlobalInformation), "Hp", typeof(long), typeof(double), typeof(bool), typeof(HeroKind),
        typeof(bool))]
    public static class MonsterGlobalInformation_Hp
    {
        private static bool Prefix(MonsterGlobalInformation __instance, long level, double difficulty, bool isPet,
            HeroKind heroKind, bool isSuperDungeon, ref double __result)
        {
            __result = double.MinValue;
            return false;
        }
    }

    // using System;
    //
    // // Token: 0x0200007B RID: 123
    // public partial class MonsterGlobalInformation
    // {
    //     // Token: 0x060009E0 RID: 2528 RVA: 0x00070700 File Offset: 0x0006E900
    //     public double Atk(long level, double difficulty, bool isPet, HeroKind heroKind)
    //     {
    //         if (this.color == MonsterColor.Metal)
    //         {
    //             return MonsterParameter.monsterStats[(int)this.species][this.colorId][2] * (double)level;
    //         }
    //         double num = MonsterParameter.monsterStats[(int)this.species][this.colorId][2] * 3.0;
    //         if (isPet)
    //         {
    //             num *= 1.0 + (double)this.pet.Level() * 0.75;
    //             num *= 1.0 + 0.05 * (double)this.pet.loyalty.value;
    //             num *= Math.Pow(2.0, Math.Floor((double)this.pet.Level() / 50.0));
    //             num *= GameController.game.monsterCtrl.petStatsMultiplier.Value();
    //             num *= GameController.game.statsCtrl.BasicStats(heroKind, BasicStatsKind.ATK).Mul();
    //             num *= GameController.game.statsCtrl.heroes[(int)heroKind].summonPetATKMATKMultiplier.Value();
    //             if (this.isLogStats[(int)heroKind] && num >= 1.0)
    //             {
    //                 num = MonsterParameter.monsterStats[(int)this.species][this.colorId][2] + Math.Log(num, Multiplier.logBase);
    //             }
    //             num += GameController.game.statsCtrl.BasicStats(heroKind, BasicStatsKind.ATK).After();
    //         }
    //         else
    //         {
    //             num *= 2.0 + (double)level * 0.25 + 10.0 * Math.Pow((double)level / 100.0, 3.0) + 50.0 * Math.Pow((double)level / 250.0, 5.0);
    //             if (level >= 400L)
    //             {
    //                 num *= Math.Pow(3.0, (double)(level - 400L) / 100.0);
    //             }
    //             if (level >= 500L)
    //             {
    //                 num *= Math.Pow(5.0, (double)(level - 500L) / 100.0);
    //             }
    //             if (level >= 1000L)
    //             {
    //                 num *= Math.Pow(10.0, (double)(level - 1000L) / 100.0);
    //             }
    //             if (level >= 2000L)
    //             {
    //                 num *= Math.Pow(100.0, (double)(level - 2000L) / 100.0);
    //             }
    //         }
    //         return num * Math.Pow(2.0, difficulty / 10.0);
    //     }
    // }

    [HarmonyPatch(typeof(MonsterGlobalInformation), "Atk", typeof(long), typeof(double), typeof(bool),
        typeof(HeroKind))]
    public static class MonsterGlobalInformation_Atk
    {
        private static bool Prefix(MonsterGlobalInformation __instance, long level, double difficulty, bool isPet,
            HeroKind heroKind, ref double __result)
        {
            __result = double.MinValue;
            return false;
        }
    }

    // using System;
    //
    // // Token: 0x0200007B RID: 123
    // public partial class MonsterGlobalInformation
    // {
    //     // Token: 0x060009E2 RID: 2530 RVA: 0x00070C50 File Offset: 0x0006EE50
    //     public double Def(long level, double difficulty, bool isPet, HeroKind heroKind)
    //     {
    //         if (this.color == MonsterColor.Metal)
    //         {
    //             return MonsterParameter.monsterStats[(int)this.species][this.colorId][4];
    //         }
    //         double num = MonsterParameter.monsterStats[(int)this.species][this.colorId][4];
    //         if (isPet)
    //         {
    //             num *= (double)this.pet.Level();
    //             num *= 1.0 + 0.05 * (double)this.pet.loyalty.value;
    //             num *= Math.Pow(2.0, Math.Floor((double)this.pet.Level() / 50.0));
    //             num *= GameController.game.monsterCtrl.petStatsMultiplier.Value();
    //             num *= GameController.game.statsCtrl.BasicStats(heroKind, BasicStatsKind.DEF).Mul();
    //             if (this.isLogStats[(int)heroKind] && num >= 1.0)
    //             {
    //                 num = MonsterParameter.monsterStats[(int)this.species][this.colorId][4] + Math.Log(num, Multiplier.logBase);
    //             }
    //             num += GameController.game.statsCtrl.BasicStats(heroKind, BasicStatsKind.DEF).After();
    //         }
    //         else
    //         {
    //             num *= (double)level + 10.0 * Math.Pow((double)level / 100.0, 3.0) + 50.0 * Math.Pow((double)level / 250.0, 5.0);
    //             if (level >= 400L)
    //             {
    //                 num *= Math.Pow(2.0, (double)(level - 400L) / 100.0);
    //             }
    //             if (level >= 1000L)
    //             {
    //                 num *= Math.Pow(10.0, (double)(level - 1000L) / 100.0);
    //             }
    //         }
    //         return num * Math.Pow(2.0, difficulty / 10.0);
    //     }
    // }

    [HarmonyPatch(typeof(MonsterGlobalInformation), "Def", typeof(long), typeof(double), typeof(bool),
        typeof(HeroKind))]
    public static class MonsterGlobalInformation_Def
    {
        private static bool Prefix(MonsterGlobalInformation __instance, long level, double difficulty, bool isPet,
            HeroKind heroKind, ref double __result)
        {
            __result = double.MinValue;
            return false;
        }
    }

    // using System;
    //
    // // Token: 0x0200007B RID: 123
    // public partial class MonsterGlobalInformation
    // {
    //     // Token: 0x060009EE RID: 2542 RVA: 0x000719F4 File Offset: 0x0006FBF4
    //     public float Range(bool isPet, HeroKind heroKind)
    //     {
    //         float num = 80f;
    //         if (this.species == MonsterSpecies.Mimic)
    //         {
    //             num = 10000f;
    //         }
    //         else if (this.species == MonsterSpecies.Treant)
    //         {
    //             switch (this.color)
    //             {
    //                 case MonsterColor.Normal:
    //                     num = 100f;
    //                     break;
    //                 case MonsterColor.Blue:
    //                     num = 120f;
    //                     break;
    //                 case MonsterColor.Yellow:
    //                     num = 150f;
    //                     break;
    //                 case MonsterColor.Red:
    //                     num = 200f;
    //                     break;
    //                 case MonsterColor.Green:
    //                     num = 250f;
    //                     break;
    //                 case MonsterColor.Purple:
    //                     num = 300f;
    //                     break;
    //                 case MonsterColor.Boss:
    //                     num = 300f;
    //                     break;
    //                 case MonsterColor.Metal:
    //                     num = 300f;
    //                     break;
    //             }
    //         }
    //         else
    //         {
    //             switch (this.AttackElement())
    //             {
    //                 case Element.Physical:
    //                     num = 80f;
    //                     break;
    //                 case Element.Fire:
    //                     num = 200f;
    //                     break;
    //                 case Element.Ice:
    //                     num = 100f;
    //                     break;
    //                 case Element.Thunder:
    //                     num = 250f;
    //                     break;
    //                 case Element.Light:
    //                     num = 300f;
    //                     break;
    //                 case Element.Dark:
    //                     num = 80f;
    //                     break;
    //                 default:
    //                     num = 80f;
    //                     break;
    //             }
    //         }
    //         if (isPet)
    //         {
    //             num *= (float)(GameController.game.skillCtrl.skillRangeMultiplier[(int)heroKind].Mul() + GameController.game.skillCtrl.skillRangeMultiplier[(int)heroKind].After());
    //         }
    //         return num;
    //     }
    // }

    [HarmonyPatch(typeof(MonsterGlobalInformation), "Range", typeof(bool), typeof(HeroKind))]
    public static class MonsterGlobalInformation_Range
    {
        private static bool Prefix(MonsterGlobalInformation __instance, bool isPet, HeroKind heroKind,
            ref float __result)
        {
            __result = float.MinValue;
            return false;
        }
    }

    // using System;
    //
    // // Token: 0x0200007B RID: 123
    // public partial class MonsterGlobalInformation
    // {
    //     // Token: 0x060009E3 RID: 2531 RVA: 0x00070E4C File Offset: 0x0006F04C
    //     public double MDef(long level, double difficulty, bool isPet, HeroKind heroKind)
    //     {
    //         if (this.color == MonsterColor.Metal)
    //         {
    //             return MonsterParameter.monsterStats[(int)this.species][this.colorId][5];
    //         }
    //         double num = MonsterParameter.monsterStats[(int)this.species][this.colorId][5];
    //         if (isPet)
    //         {
    //             num *= (double)this.pet.Level();
    //             num *= 1.0 + 0.05 * (double)this.pet.loyalty.value;
    //             num *= Math.Pow(2.0, Math.Floor((double)this.pet.Level() / 50.0));
    //             num *= GameController.game.monsterCtrl.petStatsMultiplier.Value();
    //             num *= GameController.game.statsCtrl.BasicStats(heroKind, BasicStatsKind.MDEF).Mul();
    //             if (this.isLogStats[(int)heroKind] && num >= 1.0)
    //             {
    //                 num = MonsterParameter.monsterStats[(int)this.species][this.colorId][5] + Math.Log(num, Multiplier.logBase);
    //             }
    //             num += GameController.game.statsCtrl.BasicStats(heroKind, BasicStatsKind.MDEF).After();
    //         }
    //         else
    //         {
    //             num *= (double)level + 10.0 * Math.Pow((double)level / 100.0, 3.0) + 50.0 * Math.Pow((double)level / 250.0, 5.0);
    //             if (level >= 400L)
    //             {
    //                 num *= Math.Pow(2.0, (double)(level - 400L) / 100.0);
    //             }
    //             if (level >= 1000L)
    //             {
    //                 num *= Math.Pow(10.0, (double)(level - 1000L) / 100.0);
    //             }
    //         }
    //         return num * Math.Pow(2.0, difficulty / 10.0);
    //     }
    // }

    [HarmonyPatch(typeof(MonsterGlobalInformation), "MDef", typeof(long), typeof(double), typeof(bool),
        typeof(HeroKind))]
    public static class MonsterGlobalInformation_MDef
    {
        private static bool Prefix(MonsterGlobalInformation __instance, long level, double difficulty, bool isPet,
            HeroKind heroKind, ref double __result)
        {
            __result = double.MinValue;
            return false;
        }
    }
}