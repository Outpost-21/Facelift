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
                LogUtil.LogWarning($"DefModExt_Facelift is returning null for head type: {pawn?.story?.headType?.defName ?? "None"}");
            }
            return modExt;
        }

        //public static BrowTypeDef GenerateBrowDef(Pawn pawn)
        //{
        //    DefModExt_Facelift modExt = GetFaceliftExtension(pawn);
        //    if(modExt == null) { return FaceliftDefOf.Facelift_Brow_None; }
        //    return GetCompatibleBrowDefs(pawn, modExt)?.RandomElement() ?? FaceliftDefOf.Facelift_Brow_None;
        //}

        //public static EyeTypeDef GenerateEyesDef(Pawn pawn)
        //{
        //    DefModExt_Facelift modExt = GetFaceliftExtension(pawn);
        //    if (modExt == null) { return FaceliftDefOf.Facelift_Eyes_None; }
        //    return GetCompatibleEyeDefs(pawn, modExt)?.RandomElement() ?? FaceliftDefOf.Facelift_Eyes_None;
        //}

        //public static GlassesTypeDef GenerateGlassesDef(Pawn pawn)
        //{
        //    DefModExt_Facelift modExt = GetFaceliftExtension(pawn);
        //    if (modExt == null) { return FaceliftDefOf.Facelift_Glasses_None; }
        //    return GetCompatibleGlassesDefs(pawn, modExt)?.RandomElement() ?? FaceliftDefOf.Facelift_Glasses_None;
        //}

        //public static MouthTypeDef GenerateMouthDef(Pawn pawn)
        //{
        //    DefModExt_Facelift modExt = GetFaceliftExtension(pawn);
        //    if (modExt == null) { return FaceliftDefOf.Facelift_Mouth_None; }
        //    return GetCompatibleMouthDefs(pawn, modExt)?.RandomElement() ?? FaceliftDefOf.Facelift_Mouth_None;
        //}

        //public static SkinDecorTypeDef GenerateSkinDecorDef(Pawn pawn)
        //{
        //    DefModExt_Facelift modExt = GetFaceliftExtension(pawn);
        //    if (modExt == null) { return FaceliftDefOf.Facelift_Decor_None; }
        //    return GetCompatibleSkinDecorDefs(pawn, modExt)?.RandomElement() ?? FaceliftDefOf.Facelift_Decor_None;
        //}

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

        //public static List<BrowTypeDef> GetCompatibleBrowDefs(Pawn pawn, DefModExt_Facelift modExt)
        //{
        //    List<BrowTypeDef> results = new List<BrowTypeDef>();
        //    foreach (BrowTypeDef def in DefDatabase<BrowTypeDef>.AllDefs)
        //    {
        //        if (def.canGenerateNormally && (def.gender == null || def.gender == Gender.None || def.gender == pawn.gender) && modExt.IsHeadCompatibleWithFeature(def))
        //        {
        //            results.Add(def);
        //        }
        //    }
        //    return results;
        //}

        //public static List<EyeTypeDef> GetCompatibleEyeDefs(Pawn pawn, DefModExt_Facelift modExt)
        //{
        //    List<EyeTypeDef> results = new List<EyeTypeDef>();
        //    foreach (EyeTypeDef def in DefDatabase<EyeTypeDef>.AllDefs)
        //    {
        //        if (def.canGenerateNormally && (def.gender == null || def.gender == Gender.None || def.gender == pawn.gender) && modExt.IsHeadCompatibleWithFeature(def))
        //        {
        //            results.Add(def);
        //        }
        //    }
        //    return results;
        //}

        //public static List<GlassesTypeDef> GetCompatibleGlassesDefs(Pawn pawn, DefModExt_Facelift modExt)
        //{
        //    List<GlassesTypeDef> results = new List<GlassesTypeDef>();
        //    foreach (GlassesTypeDef def in DefDatabase<GlassesTypeDef>.AllDefs)
        //    {
        //        if (def.canGenerateNormally && (def.gender == null || def.gender == Gender.None || def.gender == pawn.gender) && modExt.IsHeadCompatibleWithFeature(def))
        //        {
        //            results.Add(def);
        //        }
        //    }
        //    return results;
        //}

        //public static List<MouthTypeDef> GetCompatibleMouthDefs(Pawn pawn, DefModExt_Facelift modExt)
        //{
        //    List<MouthTypeDef> results = new List<MouthTypeDef>();
        //    foreach(MouthTypeDef def in DefDatabase<MouthTypeDef>.AllDefs)
        //    {
        //        if(def.canGenerateNormally && (def.gender == null || def.gender == Gender.None || def.gender == pawn.gender) && modExt.IsHeadCompatibleWithFeature(def))
        //        {
        //            results.Add(def);
        //        }
        //    }
        //    return results;
        //}

        //public static List<SkinDecorTypeDef> GetCompatibleSkinDecorDefs(Pawn pawn, DefModExt_Facelift modExt)
        //{
        //    List<SkinDecorTypeDef> results = new List<SkinDecorTypeDef>();
        //    foreach (SkinDecorTypeDef def in DefDatabase<SkinDecorTypeDef>.AllDefs)
        //    {
        //        if (def.canGenerateNormally  && (def.gender == null || def.gender == Gender.None || def.gender == pawn.gender) && modExt.IsHeadCompatibleWithFeature(def))
        //        {
        //            results.Add(def);
        //        }
        //    }
        //    return results;
        //}

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
