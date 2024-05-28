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
    public static class FaceliftUtil
    {
        public static FaceData GetDataForPawn(Pawn pawn)
        {
            return GameComp_FacialData.GetFaceDataForPawn(pawn);
        }

        public static DefModExt_Facelift GetFaceliftExtension(Pawn pawn)
        {
            DefModExt_Facelift modExt = pawn?.story?.headType?.GetModExtension<DefModExt_Facelift>();
            if(modExt == null)
            {
                LogUtil.LogMessage($"Debug: DefModExt_Facelift is returning null for head type: {pawn?.story?.headType?.defName ?? "None"}\nIt likely just isn't compatible, if it's retuning None then it's an issue with the pawn having no head, which is fine.");
            }
            return modExt;
        }

        public static FaceFeatureDef GenerateLayerDef(Pawn pawn, LayerDef layer)
        {
            DefModExt_Facelift modExt = GetFaceliftExtension(pawn);
            if (modExt == null) { return layer.defaultFeature; }
            return GetCompatibleLayerDefs(pawn, modExt, layer)?.RandomElement() ?? layer.defaultFeature;
        }

        public static List<FaceFeatureDef> GetCompatibleLayerDefs(Pawn pawn, DefModExt_Facelift modExt, LayerDef layer)
        {
            List<FaceFeatureDef> results = new List<FaceFeatureDef>();
            foreach (FaceFeatureDef def in DefDatabase<FaceFeatureDef>.AllDefs)
            {
                if (def.layerDef != layer) { continue; }
                if (!def.canGenerateNormally) { continue; }
                if (def.gender != null && def.gender != Gender.None && def.gender != pawn.gender) { continue; }
                if (modExt.IsHeadCompatibleWithFeature(def))
                {
                    results.Add(def);
                }
            }
            return results;
        }

        public static bool IsHeadCompatibleWithFeature(this DefModExt_Facelift modExt, FaceFeatureDef feature)
        {
            if (feature.allowedTags.NullOrEmpty()) { return true; }
            if (feature.allowedTags.Any(mat => modExt.allowedTags.Contains(mat))) { return true; }
            return false;
        }

        public static GraphicMeshSet GetHumanlikeFacialFeatureSetForPawn(Pawn pawn, float wFactor = 1f, float hFactor = 1)
        {
            Vector2 vector = HumanlikeMeshPoolUtility.HumanlikeHeadWidthForPawn(pawn) * new Vector2(wFactor, hFactor);
            if (pawn.ageTracker.CurLifeStage.headSizeFactor.HasValue)
            {
                vector *= pawn.ageTracker.CurLifeStage.headSizeFactor.Value;
            }
            return MeshPool.GetMeshSetForSize(vector.x, vector.y);
        }
    }
}
