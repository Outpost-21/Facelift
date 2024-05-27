using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Facelift
{
    public class FaceliftSettings : ModSettings
    {
        public bool verboseLogging = false;

        public override void ExposeData()
        {
            base.ExposeData();
        }
    }
}
