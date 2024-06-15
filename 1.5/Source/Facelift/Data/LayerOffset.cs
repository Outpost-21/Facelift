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
    public class LayerOffset : IEquatable<LayerOffset>
    {
        public LayerDef layer;

        public Vector2 offset;

        public LayerDef Layer => layer;

        public Vector2 Offset => offset;

        public LayerOffset(LayerDef layerDef, Vector2 vector2)
        {
            this.layer = layerDef;
            this.offset = vector2;
        }

        public bool Equals(LayerOffset other)
        {
            return this == other;
        }
    }
}
