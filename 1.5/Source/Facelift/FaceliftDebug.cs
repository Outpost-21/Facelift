using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using LudeonTK;

namespace Facelift
{
    public static class FaceliftDebug
    {
        [DebugAction("Facelift", "Regenerate Face", false, false, false, false, 0, false, actionType = DebugActionType.ToolMap, allowedGameStates = AllowedGameStates.PlayingOnMap, displayPriority = 1000)]
        public static void RegenerateFace()
        {
            foreach(Thing thing in Find.CurrentMap.thingGrid.ThingsAt(UI.MouseCell()).ToList())
            {
                if(thing is Pawn pawn)
                {
                    FaceData data = FaceliftUtil.GetDataForPawn(pawn);
                    if(data != null)
                    {
                        data.faceFeatures.Clear();
                    }
                    pawn.Drawer.renderer.SetAllGraphicsDirty();
                    PortraitsCache.SetDirty(pawn);
                    PortraitsCache.PortraitsCacheUpdate();
                }
            }
        }
    }
}
