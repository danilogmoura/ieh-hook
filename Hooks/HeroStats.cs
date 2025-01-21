using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x02000069 RID: 105
    // public partial class HeroStats
    // {
    //     // Token: 0x060005FC RID: 1532 RVA: 0x000347B0 File Offset: 0x000329B0
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

    [HarmonyPatch(typeof(HeroStats), "AbilityStats", typeof(BasicStatsKind))]
    public static class HeroStats_AbilityStats
    {
        private static bool Prefix(HeroStats __originalMethod, BasicStatsKind kind, ref double __result)
        {
            __result = double.MaxValue;
            return false;
        }
    }
}