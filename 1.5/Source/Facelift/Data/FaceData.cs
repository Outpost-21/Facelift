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
    public class FaceData : IExposable
    {
        public Pawn pawn;

        public Dictionary<LayerDef, FaceFeatureDef> faceFeatures = new Dictionary<LayerDef, FaceFeatureDef>();

        public Graphic GetGraphicForLayer(LayerDef layer)
        {
            if (layer == null) { return null; }
            if (!faceFeatures.ContainsKey(layer))
            {
                faceFeatures.Add(layer, FaceliftUtil.GenerateLayerDef(pawn, layer));
            }
            return faceFeatures[layer].GraphicFor(pawn);
        }

        //public Graphic BrowGraphic
        //{
        //    get
        //    {
        //        if(BrowTypeDef == null)
        //        {
        //            BrowTypeDef = FaceliftUtil.GenerateBrowDef(pawn);
        //        }
        //        return BrowTypeDef.GraphicFor(pawn);
        //    }
        //}

        //public Graphic EyesGraphic
        //{
        //    get
        //    {
        //        if (EyeTypeDef == null)
        //        {
        //            EyeTypeDef = FaceliftUtil.GenerateEyesDef(pawn);
        //        }
        //        return EyeTypeDef.GraphicFor(pawn);
        //    }
        //}

        //public Graphic MouthGraphic
        //{
        //    get
        //    {
        //        if (MouthTypeDef == null)
        //        {
        //            MouthTypeDef = FaceliftUtil.GenerateMouthDef(pawn);
        //        }
        //        return MouthTypeDef.GraphicFor(pawn);
        //    }
        //}

        //public Graphic DecorGraphic
        //{
        //    get
        //    {
        //        if (SkinDecorTypeDef == null)
        //        {
        //            SkinDecorTypeDef = FaceliftUtil.GenerateSkinDecorDef(pawn);
        //        }
        //        return SkinDecorTypeDef.GraphicFor(pawn);
        //    }
        //}

        //public Graphic GlassesGraphic
        //{
        //    get
        //    {
        //        if (GlassesTypeDef == null)
        //        {
        //            GlassesTypeDef = FaceliftUtil.GenerateGlassesDef(pawn);
        //        }
        //        return GlassesTypeDef.GraphicFor(pawn);
        //    }
        //}

        public void ExposeData()
        {
            Scribe_References.Look(ref pawn, "pawn");
            Scribe_Collections.Look(ref faceFeatures, "faceFeatures");
        }
    }
}
