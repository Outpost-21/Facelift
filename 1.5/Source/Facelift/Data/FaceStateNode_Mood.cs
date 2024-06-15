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
    public class FaceStateNode_Mood : FaceStateNode
    {
        public LayerDef layerDef;

        public bool hide = false;

        public MoodType moodType = MoodType.Neutral;
    }
}
