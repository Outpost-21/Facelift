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
    public class GenderedGraphic
    {
        public string texPath;
        public string texPathFemale;


        public Graphic GenderedTex
        {
            get
            {
                if (texPath.NullOrEmpty()) { return null; }
                return GraphicDatabase.Get<Graphic_Single>(texPath);
            }
        }

        public Graphic GenderedTexFemale
        {
            get
            {
                if (texPathFemale.NullOrEmpty())
                {
                    return GenderedTex;
                }
                return GraphicDatabase.Get<Graphic_Single>(texPathFemale);
            }
        }

        public Graphic GraphicForGender(Gender gender)
        {
            if (gender == Gender.Female)
            {
                return GenderedTexFemale;
            }
            return GenderedTex;
        }
    }
}
