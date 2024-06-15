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
    public abstract class FaceStateTreeNode
    {
        public List<FaceStateNode> subNodes = new List<FaceStateNode>();
    }
}
