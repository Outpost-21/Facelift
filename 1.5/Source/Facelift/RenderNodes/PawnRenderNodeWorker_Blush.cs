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
    public class PawnRenderNodeWorker_Blush : PawnRenderNodeWorker_FlipWhenCrawling
	{
		public override bool CanDrawNow(PawnRenderNode node, PawnDrawParms parms)
		{
			if (base.CanDrawNow(node, parms) && parms.pawn.Spawned && IsNude(parms.pawn))
			{
				if (!(parms.facing != Rot4.North))
				{
					return parms.flipHead;
				}
				return true;
			}
			return false;
		}

		public bool IsNude(Pawn pawn)
        {
			return pawn.needs?.mood?.thoughts?.situational?.cachedThoughts?.Any(th => th.def == ThoughtDefOf.Naked) ?? false;
        }
	}
}
