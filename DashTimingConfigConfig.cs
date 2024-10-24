using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace DashTimingConfig
{
    public class DashTimingConfigConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(15)]
        [Range(2, 30)]
        public int DashTime;
    }
}
