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
    public class PawnRenderNodeWorker_FaceFeature : PawnRenderNodeWorker_FlipWhenCrawling
	{
        public override Vector3 ScaleFor(PawnRenderNode node, PawnDrawParms parms)
		{
			if (node is PawnRenderNode_FaceFeature faceNode)
			{
				if (faceNode.modExt != null && !faceNode.modExt.layerOffsets.NullOrEmpty())
				{
					LayerOffset offset = faceNode.modExt.layerOffsets.Find(lo => lo.layer == faceNode.Props.layerDef);
					if (offset != null)
					{
						return offset.Offset.ToVector3() + FaceliftUtil.GetDataForPawn(parms.pawn).GetOffsetForLayer(faceNode.Props.layerDef);
					}
				}
			}
			return base.ScaleFor(node, parms);
        }

        public override Vector3 OffsetFor(PawnRenderNode node, PawnDrawParms parms, out Vector3 pivot)
        {
			if(node is PawnRenderNode_FaceFeature faceNode)
            {
				if(faceNode.modExt != null && !faceNode.modExt.layerOffsets.NullOrEmpty())
                {
					LayerOffset offset = faceNode.modExt.layerOffsets.Find(lo => lo.layer == faceNode.Props.layerDef);
					if(offset != null)
                    {
						pivot = PivotFor(node, parms);
						return offset.Offset.ToVector3() + FaceliftUtil.GetDataForPawn(parms.pawn).GetOffsetForLayer(faceNode.Props.layerDef);
                    }
                }
            }
            return base.OffsetFor(node, parms, out pivot);
        }

        public override bool CanDrawNow(PawnRenderNode node, PawnDrawParms parms)
		{
			if (base.CanDrawNow(node, parms) && parms.pawn.Spawned)
			{
				if (!(parms.facing != Rot4.North))
				{
					return parms.flipHead;
				}
				return true;
			}
			return false;
		}
	}
}
