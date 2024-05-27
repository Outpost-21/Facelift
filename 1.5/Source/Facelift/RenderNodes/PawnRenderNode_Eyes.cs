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
    public class PawnRenderNode_Eyes : PawnRenderNode_FaceFeature
    {
        public PawnRenderNode_Eyes(Pawn pawn, PawnRenderNodeProperties props, PawnRenderTree tree) : base(pawn, props, tree)
        {
        }

        public override GraphicMeshSet MeshSetFor(Pawn pawn)
        {
            if (modExt != null && modExt.allowedLayers.Contains(Props.layerDef))
            {
                return FaceliftUtil.GetHumanlikeFacialFeatureSetForPawn(pawn);
            }
            return base.MeshSetFor(pawn);
        }

        public override Graphic GraphicFor(Pawn pawn)
        {
            if (pawn.story?.headType == null)
            {
                return null;
            }
            if (modExt != null && modExt.allowedLayers.Contains(Props.layerDef))
            {
                return FaceliftUtil.GetDataForPawn(pawn).GetGraphicForLayer(Props.layerDef);
            }
            return base.GraphicFor(pawn);
        }
    }
}
