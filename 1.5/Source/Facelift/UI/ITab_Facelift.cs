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
    public class ITab_Facelift : ITab
    {
        public static readonly Vector2 WinSize = new Vector2(480f, 510f);

        public Vector2 optionsScrollPosition;
        public float optionsViewRectHeight;

        public bool CanControlPawn
        {
            get
            {
                if (SelPawn == null) { return false; }
                if (SelPawn.Downed || SelPawn.InMentalState) { return false; }
                if (SelPawn.Faction != Faction.OfPlayer) { return false; }

                return true;
            }
        }

        public override bool IsVisible => base.IsVisible && SelPawn.RaceProps.Humanlike && FaceliftUtil.GetFaceliftExtension(SelPawn) != null && (CanControlPawn || DebugSettings.godMode);

        public ITab_Facelift()
        {
            this.size = WinSize;
            this.labelKey = "Facelift.Facelift";
        }

        public override void FillTab()
        {
            Rect inRect = new Rect(0f, 0f, size.x, size.y).ContractedBy(16f);

            bool flag = optionsViewRectHeight > inRect.height;
            Rect viewRect = new Rect(inRect.x, inRect.y, inRect.width - (flag ? 26f : 0f), optionsViewRectHeight);
            Widgets.BeginScrollView(inRect, ref optionsScrollPosition, viewRect);
            Listing_Standard listing = new Listing_Standard();
            Rect rect = new Rect(viewRect.x, viewRect.y, viewRect.width, 999999f);
            listing.Begin(rect);
            // ============================ CONTENTS ================================
            DoContents(listing);
            // ======================================================================
            optionsViewRectHeight = listing.CurHeight;
            listing.End();
            Widgets.EndScrollView();
        }



        public void DoContents(Listing_Standard ls)
        {
            DefModExt_Facelift modExt = FaceliftUtil.GetFaceliftExtension(SelPawn);
            ls.Label(SelPawn.Name.ToStringFull);
            ls.GapLine();
            FaceData data = FaceliftUtil.GetDataForPawn(SelPawn);
            foreach(KeyValuePair<LayerDef, FaceFeatureDef> layerkvp in data.faceFeatures)
            {
                if(ls.ButtonTextLabeled(layerkvp.Key.LabelCap, layerkvp.Value.LabelCap))
                {
                    Find.WindowStack.Add(new FloatMenu(GetDropdownOptionsForLayerTags(modExt, layerkvp.Key).ToList()));
                }
            }
        }

        public IEnumerable<FloatMenuOption> GetDropdownOptionsForLayerTags(DefModExt_Facelift modExt, LayerDef layer)
        {
            foreach(FaceFeatureDef def in FaceliftUtil.GetCompatibleLayerDefs(SelPawn, modExt, layer))
            {
                yield return new FloatMenuOption(def.LabelCap, delegate () { FaceliftUtil.GetDataForPawn(SelPawn).SetDefForLayer(layer, def); });
            }
            yield break;
        }
    }
}
