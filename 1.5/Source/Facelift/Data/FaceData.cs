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

        public FaceStateDef faceState;

        public Dictionary<LayerDef, FaceFeatureDef> faceFeatures = new Dictionary<LayerDef, FaceFeatureDef>();

        public void SetDefForLayer(LayerDef layer, FaceFeatureDef featureDef)
        {
            if (faceFeatures.ContainsKey(layer))
            {
                faceFeatures[layer] = featureDef;
                pawn.Drawer.renderer.SetAllGraphicsDirty();
            }
        }

        public Graphic GetGraphicForLayer(LayerDef layer)
        {
            if (layer == null) { return null; }
            if (!faceFeatures.ContainsKey(layer))
            {
                faceFeatures.Add(layer, FaceliftUtil.GenerateLayerDef(pawn, layer));
            }
            return faceFeatures[layer].GraphicFor(pawn);
        }

        public Vector3 GetOffsetForLayer(LayerDef layer)
        {
            if (layer == null) { return Vector3.zero; }
            if (!faceFeatures.ContainsKey(layer))
            {
                faceFeatures.Add(layer, FaceliftUtil.GenerateLayerDef(pawn, layer));
            }
            return faceFeatures[layer].offset.ToVector3();
        }

        public void ExposeData()
        {
            Scribe_References.Look(ref pawn, "pawn");
            Scribe_Collections.Look(ref faceFeatures, "faceFeatures", LookMode.Value);
        }
    }
}
