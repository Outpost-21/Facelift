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
    public class GameComp_FacialData : GameComponent
    {
        public static Dictionary<Pawn, FaceData> _globalFacialData = new Dictionary<Pawn, FaceData>();

        public GameComp_FacialData(Game game)
        {

        }

        public static FaceData GetFaceDataForPawn(Pawn pawn)
        {
            if (_globalFacialData.NullOrEmpty()) { _globalFacialData = new Dictionary<Pawn, FaceData>(); }
            if (_globalFacialData.ContainsKey(pawn))
            {
                return _globalFacialData[pawn];
            }
            else
            {
                GenerateFacialDataForPawn(pawn);
                return _globalFacialData[pawn];
            }
        }

        public static void GenerateFacialDataForPawn(Pawn pawn)
        {
            if (_globalFacialData.ContainsKey(pawn)) { LogUtil.LogWarning("Attempting to generate face data for pawn which already has face data, skipping."); return; }
            _globalFacialData.Add(pawn, new FaceData() { pawn = pawn });
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref _globalFacialData, "_globalFacialData", LookMode.Deep);
        }
    }
}
