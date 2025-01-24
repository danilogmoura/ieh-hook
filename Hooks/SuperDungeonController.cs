using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    //
    // // Token: 0x02000248 RID: 584
    // public partial class SuperDungeonController
    // {
    //     // Token: 0x06001730 RID: 5936 RVA: 0x0008D40C File Offset: 0x0008B60C
    //     public double TotalTopazGain(long floorReached)
    //     {
    //         double num = 0.0;
    //         int num2 = (int)this.currentArea.SuperDungeonMaxFloorReached(this.heroKind, false);
    //         while ((long)num2 < floorReached)
    //         {
    //             num += this.TopazGain((long)num2);
    //             num2++;
    //         }
    //         return num;
    //     }
    // }

    [HarmonyPatch(typeof(SuperDungeonController), "TotalTopazGain", typeof(long))]
    public static class SuperDungeonController_TotalTopazGain
    {
        private static bool Prefix(SuperDungeonController __instance, long floorReached, ref double __result)
        {
            __result = double.MaxValue;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    //
    // // Token: 0x02000248 RID: 584
    // public partial class SuperDungeonController
    // {
    //     // Token: 0x06001732 RID: 5938 RVA: 0x0008D47C File Offset: 0x0008B67C
    //     public double TotalRubyGain(long floorReached)
    //     {
    //         double num = 0.0;
    //         int num2 = (int)this.currentArea.SuperDungeonMaxFloorReached(this.heroKind, false) + 1;
    //         while ((long)num2 <= floorReached)
    //         {
    //             num += this.RubyGain((long)num2);
    //             num2++;
    //         }
    //         return num;
    //     }
    // }

    [HarmonyPatch(typeof(SuperDungeonController), "TotalRubyGain", typeof(long))]
    public static class SuperDungeonController_TotalRubyGain
    {
        private static bool Prefix(SuperDungeonController __instance, long floorReached, ref double __result)
        {
            __result = double.MaxValue;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    //
    // // Token: 0x02000248 RID: 584
    // public partial class SuperDungeonController
    // {
    //     // Token: 0x06001734 RID: 5940 RVA: 0x0008D4E8 File Offset: 0x0008B6E8
    //     public double TotalPieceOfRubyGain(long floorReached)
    //     {
    //         double num = 0.0;
    //         int num2 = 1;
    //         while ((long)num2 <= Math.Min(floorReached, (long)((int)this.currentArea.SuperDungeonMaxFloorReached(this.heroKind, false))))
    //         {
    //             num += this.PieceOfRubyGain((long)num2);
    //             num2++;
    //         }
    //         return num;
    //     }
    // }

    [HarmonyPatch(typeof(SuperDungeonController), "TotalPieceOfRubyGain", typeof(long))]
    public static class SuperDungeonController_TotalPieceOfRubyGain
    {
        private static bool Prefix(SuperDungeonController __instance, long floorReached, ref double __result)
        {
            __result = double.MaxValue;
            return false;
        }
    }

    // using System;
    // using System.Collections.Generic;
    // using System.Threading.Tasks;
    //
    // // Token: 0x02000248 RID: 584
    // public partial class SuperDungeonController
    // {
    //     // Token: 0x0600172E RID: 5934 RVA: 0x0008D274 File Offset: 0x0008B474
    //     public void GetLoot(bool isClear, CHALLENGE_SUPERDUNGEON sd = null, bool isDie = false)
    //     {
    //         long num = (long)(isClear ? 100 : (this.battleCtrl.areaBattle.currentWave / 10));
    //         double num2 = (isDie ? this.sdgCtrl.lootGainOnDie.Value() : 1.0);
    //         if (num2 == 0.0)
    //         {
    //             return;
    //         }
    //         this.sdgCtrl.dungeonCoinPermanent.Increase(this.dungeonCoin.value * num2, false);
    //         if (num2 == 1.0)
    //         {
    //             this.sdgCtrl.topaz.Increase(this.TotalTopazGain(num), false);
    //         }
    //         if (num2 == 1.0)
    //         {
    //             this.sdgCtrl.ruby.Increase(this.TotalRubyGain(num), false);
    //         }
    //         this.sdgCtrl.pieceOfRuby.Increase(this.TotalPieceOfRubyGain(num) * num2, false);
    //         if (isClear && num2 == 1.0)
    //         {
    //             this.sdgCtrl.motherStone.Increase(this.TotalMotherStoneGain(num), false);
    //         }
    //         if (!isDie)
    //         {
    //             this.SetMaxFloorReached(num, sd);
    //         }
    //         if (isClear && sd != null)
    //         {
    //             sd.modifierCtrl.ClearAction();
    //         }
    //     }
    // }

    [HarmonyPatch(typeof(SuperDungeonController), "GetLoot", typeof(bool), typeof(CHALLENGE_SUPERDUNGEON),
        typeof(bool))]
    public static class SuperDungeonController_GetLoot
    {
        private static void Postfix(SuperDungeonController __instance, bool isClear, CHALLENGE_SUPERDUNGEON sd,
            bool isDie)
        {
            // dungeonCoin
            __instance.sdgCtrl.dungeonCoinPermanent.Increase(double.MaxValue);
        }
    }
}