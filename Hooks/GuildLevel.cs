using HarmonyLib;

namespace IEHHook.Hooks
{
    // using System;
    //
    // // Token: 0x020003A9 RID: 937
    // public partial class GuildLevel : INTEGER
    // {
    //     // Token: 0x0600228D RID: 8845 RVA: 0x000C3160 File Offset: 0x000C1360
    //     public override void Increase(long increment)
    //     {
    //         base.Increase(increment);
    //         GameController.game.guildCtrl.abilityPointLeft.Increase((double)increment, false);
    //         int num = 0;
    //         while ((long)num < increment)
    //         {
    //             checked
    //             {
    //                 GameController.game.guildCtrl.accomplishGuildLevels[(int)((IntPtr)Math.Max(0L, unchecked(this.value - (long)num)))].RegisterTime();
    //             }
    //             num++;
    //         }
    //         if (this.logUIAction != null)
    //         {
    //             this.logUIAction();
    //         }
    //         Main.main.S.maxGuildLevel = Math.Max(Main.main.S.maxGuildLevel, this.value);
    //     }
    // }

    [HarmonyPatch(typeof(GuildLevel), "Increase")]
    public static class GuildLevelIncreasePatch
    {
        public static void Prefix(GuildLevel __instance, ref long increment)
        {
            increment *= 10_000L;
        }
    }
}