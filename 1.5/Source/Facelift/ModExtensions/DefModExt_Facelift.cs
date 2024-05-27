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
    public class DefModExt_Facelift : DefModExtension
    {
        public List<LayerDef> allowedLayers = new List<LayerDef>();

        public List<string> allowedTags = new List<string>();
    }
}
