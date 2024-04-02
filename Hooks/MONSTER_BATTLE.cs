using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000023 RID: 35
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x1700003E RID: 62
    //     // (get) Token: 0x0600011E RID: 286 RVA: 0x00016E48 File Offset: 0x00015048
    //     public override double hp
    //     {
    //         get
    //         {
    //             return this.globalInformation.Hp(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind, this.battleCtrl.isSuperDungeon) * (double)(1 + 4 * Convert.ToInt16(this.isMutant));
    //         }
    //     }
    // }
    [HarmonyPatch(typeof(MONSTER_BATTLE), "get_hp")]
    public static class MONSTER_BATTLE_hp
    {
        private static void Postfix(MONSTER_BATTLE __instance, ref double __result)
        {
            __result = 1;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000023 RID: 35
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x1700003F RID: 63
    //     // (get) Token: 0x0600011F RID: 287 RVA: 0x00016E99 File Offset: 0x00015099
    //     public override double mp
    //     {
    //         get
    //         {
    //             return this.globalInformation.Mp(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind);
    //         }
    //     }
    // }
    [HarmonyPatch(typeof(MONSTER_BATTLE), "get_mp")]
    public static class MONSTER_BATTLE_mp
    {
        private static void Postfix(MONSTER_BATTLE __instance, ref double __result)
        {
            __result = 1;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000023 RID: 35
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x17000042 RID: 66
    //     // (get) Token: 0x06000122 RID: 290 RVA: 0x00016F5C File Offset: 0x0001515C
    //     public override double def
    //     {
    //         get
    //         {
    //             return base.DebuffFactor(Debuff.DefDown) * this.globalInformation.Def(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind) * (double)(1 + Convert.ToInt16(this.isMutant));
    //         }
    //     }
    // }
    [HarmonyPatch(typeof(MONSTER_BATTLE), "get_def")]
    public static class MONSTER_BATTLE_def
    {
        private static void Postfix(MONSTER_BATTLE __instance, ref double __result)
        {
            __result = 1;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000023 RID: 35
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x17000043 RID: 67
    //     // (get) Token: 0x06000123 RID: 291 RVA: 0x00016FA8 File Offset: 0x000151A8
    //     public override double mdef
    //     {
    //         get
    //         {
    //             return base.DebuffFactor(Debuff.MdefDown) * this.globalInformation.MDef(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind) * (double)(1 + Convert.ToInt16(this.isMutant));
    //         }
    //     }
    // }
    [HarmonyPatch(typeof(MONSTER_BATTLE), "get_mdef")]
    public static class MONSTER_BATTLE_mdef
    {
        private static void Postfix(MONSTER_BATTLE __instance, ref double __result)
        {
            __result = 1;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000023 RID: 35
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x1700004D RID: 77
    //     // (get) Token: 0x0600012D RID: 301 RVA: 0x000171AB File Offset: 0x000153AB
    //     public override double debuffResistance
    //     {
    //         get
    //         {
    //             return this.globalInformation.DebuffResistance(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind);
    //         }
    //     }
    // }
    [HarmonyPatch(typeof(MONSTER_BATTLE), "get_debuffResistance")]
    public static class MONSTER_BATTLE_debuffResistance
    {
        private static void Postfix(MONSTER_BATTLE __instance, ref double __result)
        {
            __result = 1;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000023 RID: 35
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x17000057 RID: 87
    //     // (get) Token: 0x06000140 RID: 320 RVA: 0x00017779 File Offset: 0x00015979
    //     public double gainFactor
    //     {
    //         get
    //         {
    //             return GameController.game.guildCtrl.Member(this.battleCtrl.heroKind).gainRate;
    //         }
    //     }
    // }
    [HarmonyPatch(typeof(MONSTER_BATTLE), "get_gainFactor")]
    public static class MONSTER_BATTLE_gainFactor
    {
        private static void Postfix(MONSTER_BATTLE __instance, ref double __result)
        {
            __result *= 100;
        }
    }
}