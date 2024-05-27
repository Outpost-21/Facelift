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
    public class PawnRenderNode_FaceFeature : PawnRenderNode
    {
        public DefModExt_Facelift modExt;

        public new PawnRenderNodeProperties_FaceFeature Props => (PawnRenderNodeProperties_FaceFeature)props;

        public PawnRenderNode_FaceFeature(Pawn pawn, PawnRenderNodeProperties props, PawnRenderTree tree) : base(pawn, props, tree)
        {
            if (modExt == null)
            {
                modExt = pawn.story?.headType?.GetModExtension<DefModExt_Facelift>();
            }
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
            if(modExt != null && modExt.allowedLayers.Contains(Props.layerDef))
            {
                return FaceliftUtil.GetDataForPawn(pawn).GetGraphicForLayer(Props.layerDef);
            }
            return base.GraphicFor(pawn);
        }
    }
}
