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
    public class PawnRenderNodeWorker_Mouth : PawnRenderNodeWorker_FlipWhenCrawling
	{
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
