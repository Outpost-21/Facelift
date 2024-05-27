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
    public class BrowTypeDef : FaceFeatureDef
    {
        public GenderedGraphic neutral;
        public GenderedGraphic happy;
        public GenderedGraphic sad;
        public GenderedGraphic angry;

        public override Graphic GraphicFor(Pawn pawn)
        {
            if (noGraphic)
            {
                return null;
            }
            return GraphicDatabase.Get<Graphic_Multi>(GetTextureForPawn(pawn.gender, GetMood(pawn)), shaderType?.Shader ?? ShaderDatabase.Cutout, Vector2.one, GetColorOne(pawn), GetColorTwo(pawn));
        }

        public string GetTextureForPawn(Gender gender, MoodType mood)
        {
            switch (mood)
            {
                case MoodType.Happy:
                    if (happy == null) { mood = MoodType.Neutral; };
                    break;
                case MoodType.Sad:
                    if (sad == null) { mood = MoodType.Neutral; };
                    break;
                case MoodType.Angry:
                    if (angry == null) { mood = MoodType.Neutral; };
                    break;
                default:
                    break;
            }
            switch (mood)
            {
                case MoodType.Happy:
                    return gender == Gender.Female && !happy.texPathFemale.NullOrEmpty() ? happy.texPathFemale : happy.texPath;
                case MoodType.Sad:
                    return gender == Gender.Female && !sad.texPathFemale.NullOrEmpty() ? sad.texPathFemale : sad.texPath;
                case MoodType.Angry:
                    return gender == Gender.Female && !angry.texPathFemale.NullOrEmpty() ? angry.texPathFemale : angry.texPath;
                default:
                    return gender == Gender.Female && !neutral.texPathFemale.NullOrEmpty() ? neutral.texPathFemale : neutral.texPath;
            }
        }
    }
}
