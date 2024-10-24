using MonoMod.Cil;
using System;
using Terraria.ModLoader;

namespace DashTimingConfig
{
    public class DashTimingConfig : Mod
    {
        public override void Load()
        {
            base.Load();
            Terraria.IL_Player.DoCommonDashHandle += IL_Player_DoCommonDashHandle;
        }

        private static void IL_Player_DoCommonDashHandle(ILContext il)
        {
            var mod = ModContent.GetInstance<DashTimingConfig>();
            try
            {
                ILCursor cursor = new(il);
                cursor.TryGotoNext(MoveType.After, instr => instr.MatchLdcI4(15));
                cursor.EmitDelegate(ModifyDashTime);
                cursor.TryGotoNext(MoveType.After, instr => instr.MatchLdcI4(-15));
                cursor.EmitDelegate(ModifyDashTime);
            }
            catch (Exception e)
            {
                MonoModHooks.DumpIL(mod, il);
            }
        }

        private static int ModifyDashTime(int dashTime)
        {
            int sign = Math.Sign(dashTime);
            return ModContent.GetInstance<DashTimingConfigConfig>().DashTime * sign;
        }
    }
}
