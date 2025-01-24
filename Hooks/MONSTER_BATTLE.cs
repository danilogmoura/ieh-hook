using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000025 RID: 37
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x17000040 RID: 64
    //     // (get) Token: 0x06000127 RID: 295 RVA: 0x00017670 File Offset: 0x00015870
    //     public override double hp
    //     {
    //         get
    //         {
    //             return this.globalInformation.Hp(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind, this.battleCtrl.isSuperDungeon) * (double)(1 + 4 * Convert.ToInt16(this.isMutant));
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(MONSTER_BATTLE), "hp", MethodType.Getter)]
    public static class MONSTER_BATTLE_hp_get
    {
        private static bool Prefix(BATTLE __instance, ref double __result)
        {
            __result = 1.0;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000025 RID: 37
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x17000041 RID: 65
    //     // (get) Token: 0x06000128 RID: 296 RVA: 0x000176C1 File Offset: 0x000158C1
    //     public override double mp
    //     {
    //         get
    //         {
    //             return this.globalInformation.Mp(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind);
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(MONSTER_BATTLE), "mp", MethodType.Getter)]
    public static class MONSTER_BATTLE_mp_get
    {
        private static bool Prefix(BATTLE __instance, ref double __result)
        {
            __result = 1.0;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000025 RID: 37
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x17000042 RID: 66
    //     // (get) Token: 0x06000129 RID: 297 RVA: 0x000176EC File Offset: 0x000158EC
    //     public override double atk
    //     {
    //         get
    //         {
    //             return base.DebuffFactor(Debuff.AtkDown) * this.globalInformation.Atk(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind) * (double)(1 + Convert.ToInt16(this.isMutant));
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(MONSTER_BATTLE), "atk", MethodType.Getter)]
    public static class MONSTER_BATTLE_atk_get
    {
        private static bool Prefix(BATTLE __instance, ref double __result)
        {
            __result = 1.0;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000025 RID: 37
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x17000043 RID: 67
    //     // (get) Token: 0x0600012A RID: 298 RVA: 0x00017738 File Offset: 0x00015938
    //     public override double matk
    //     {
    //         get
    //         {
    //             return base.DebuffFactor(Debuff.MatkDown) * this.globalInformation.MAtk(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind) * (double)(1 + Convert.ToInt16(this.isMutant));
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(MONSTER_BATTLE), "matk", MethodType.Getter)]
    public static class MONSTER_BATTLE_matk_get
    {
        private static bool Prefix(BATTLE __instance, ref double __result)
        {
            __result = 1.0;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000025 RID: 37
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x17000044 RID: 68
    //     // (get) Token: 0x0600012B RID: 299 RVA: 0x00017784 File Offset: 0x00015984
    //     public override double def
    //     {
    //         get
    //         {
    //             return base.DebuffFactor(Debuff.DefDown) * this.globalInformation.Def(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind) * (double)(1 + Convert.ToInt16(this.isMutant));
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(MONSTER_BATTLE), "def", MethodType.Getter)]
    public static class MONSTER_BATTLE_def_get
    {
        private static bool Prefix(BATTLE __instance, ref double __result)
        {
            __result = 1.0;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using UnityEngine;
    //
    // // Token: 0x02000025 RID: 37
    // public partial class MONSTER_BATTLE : BATTLE
    // {
    //     // Token: 0x17000045 RID: 69
    //     // (get) Token: 0x0600012C RID: 300 RVA: 0x000177D0 File Offset: 0x000159D0
    //     public override double mdef
    //     {
    //         get
    //         {
    //             return base.DebuffFactor(Debuff.MdefDown) * this.globalInformation.MDef(this.level, this.difficulty, this.isPet, this.battleCtrl.heroKind) * (double)(1 + Convert.ToInt16(this.isMutant));
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(MONSTER_BATTLE), "mdef", MethodType.Getter)]
    public static class MONSTER_BATTLE_mdef_get
    {
        private static bool Prefix(BATTLE __instance, ref double __result)
        {
            __result = 1.0;
            return false;
        }
    }
}