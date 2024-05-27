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
    public class MouthTypeDef : FaceFeatureDef
    {
        public GenderedGraphic open;
        public GenderedGraphic closed;

        public override string GetTextureForGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Female:
                    return closed.texPathFemale.NullOrEmpty() ? closed.texPath : closed.texPathFemale;
                default:
                    return closed.texPath;
            }
        }
    }
}
