using HarmonyLib;
using MelonLoader;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x02000062 RID: 98
    // public partial class HeroStats
    // {
    //     // Token: 0x060005C2 RID: 1474 RVA: 0x00032238 File Offset: 0x00030438
    //     public double AbilityStats(BasicStatsKind kind)
    //     {
    //         double num = Parameter.stats[(int)this.heroKind][(int)kind];
    //         switch (kind)
    //         {
    //             case BasicStatsKind.HP:
    //                 num *= (double)this.Ability(AbilityKind.Vitality).Point();
    //                 break;
    //             case BasicStatsKind.MP:
    //                 num *= (double)(this.Ability(AbilityKind.Agility).Point() + this.Ability(AbilityKind.Intelligence).Point()) / 2.0;
    //                 break;
    //             case BasicStatsKind.ATK:
    //                 num *= (double)this.Ability(AbilityKind.Strength).Point();
    //                 break;
    //             case BasicStatsKind.MATK:
    //                 num *= (double)this.Ability(AbilityKind.Intelligence).Point();
    //                 break;
    //             case BasicStatsKind.DEF:
    //                 num *= (double)(this.Ability(AbilityKind.Vitality).Point() + this.Ability(AbilityKind.Strength).Point()) / 2.0;
    //                 break;
    //             case BasicStatsKind.MDEF:
    //                 num *= (double)(this.Ability(AbilityKind.Vitality).Point() + this.Ability(AbilityKind.Intelligence).Point()) / 2.0;
    //                 break;
    //             case BasicStatsKind.SPD:
    //                 num *= (double)this.Ability(AbilityKind.Agility).Point();
    //                 break;
    //         }
    //         return num;
    //     }
    // }

    [HarmonyPatch(typeof(HeroStats), "AbilityStats")]
    public static class HeroStats_AbilityStats
    {
        private static void Postfix(HeroStats __instance, BasicStatsKind kind, ref double __result)
        {
            var num = Parameter.stats[(int)__instance.heroKind][(int)kind];
            switch (kind)
            {
                case BasicStatsKind.HP:
                case BasicStatsKind.MP:
                case BasicStatsKind.ATK:
                case BasicStatsKind.MATK:
                case BasicStatsKind.DEF:
                case BasicStatsKind.MDEF:
                case BasicStatsKind.SPD:
                    num *= 1_000_000;
                    break;
                default:
                    MelonLogger.Msg("ArgumentOutOfRangeException: " + kind);
                    break;
            }

            __result = num;
        }
    }
}