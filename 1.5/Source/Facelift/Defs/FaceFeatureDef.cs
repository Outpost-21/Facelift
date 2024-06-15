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
    public class FaceFeatureDef : Def
    {
        public bool noGraphic = false;

        public Color colorOne = Color.white;
        public PartColorType colorOneType = PartColorType.Custom;
        public Color colorTwo = Color.white;
        public PartColorType colorTwoType = PartColorType.Custom;

        public string texPath;
        public string texPathFemale;

        public string iconTexPath;

        public ShaderTypeDef shaderType;

        public List<GeneDef> requiredGenes = new List<GeneDef>();
        public List<GeneDef> incompatibleGenes = new List<GeneDef>();

        public Gender? gender;

        public LayerDef layerDef;

        public List<string> allowedTags = new List<string>();

        public bool canGenerateNormally = true;

        public float commonality = 100f;

        public string customCatgegory;

        public Vector2 offset = Vector2.zero;

        [Unsaved]
        public Texture2D iconTexture;

        public override void PostLoad()
        {
            base.PostLoad();
            if(iconTexPath != null)
            {
                LongEventHandler.ExecuteWhenFinished(delegate { iconTexture = ContentFinder<Texture2D>.Get(iconTexPath); });
            }
        }

        public virtual Graphic GraphicFor(Pawn pawn)
        {
            if (noGraphic)
            {
                return null;
            }
            return GraphicDatabase.Get<Graphic_Multi>(GetTextureForGender(pawn.gender), shaderType?.Shader ?? ShaderDatabase.Cutout, Vector2.one, GetColorOne(pawn), GetColorTwo(pawn));
        }

        public Color GetColorOne(Pawn pawn)
        {
            switch (colorOneType)
            {
                case PartColorType.Hair:
                    return pawn.story.HairColor;
                case PartColorType.Skin:
                    return pawn.story.SkinColor;
                default:
                    return colorOne;
            }
        }

        public Color GetColorTwo(Pawn pawn)
        {
            switch (colorTwoType)
            {
                case PartColorType.Hair:
                    return pawn.story.HairColor;
                case PartColorType.Skin:
                    return pawn.story.SkinColor;
                default:
                    return colorTwo;
            }
        }

        public virtual string GetTextureForGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Female:
                    return texPathFemale.NullOrEmpty() ? texPath : texPathFemale;
                default:
                    return texPath;
            }
        }

        public MoodType GetMood(Pawn pawn)
        {
            if (pawn.Drafted)
            {
                return MoodType.Angry;
            }
            if (!pawn.Downed && pawn.mindState.mentalBreaker.BreakMinorIsImminent)
            {
                return MoodType.Sad;
            }
            if (!pawn.Downed && pawn.mindState.mentalBreaker.BreakMajorIsImminent || pawn.mindState.mentalBreaker.BreakExtremeIsImminent)
            {
                return MoodType.Angry;
            }
            if(!pawn.Downed && pawn.needs?.mood.thoughts.TotalMoodOffset() > 10f)
            {
                return MoodType.Happy;
            }
            return MoodType.Neutral;
        }
    }
}
