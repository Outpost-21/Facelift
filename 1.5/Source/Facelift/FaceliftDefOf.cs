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
    [DefOf]
    public static class FaceliftDefOf
    {
        static FaceliftDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(FaceliftDefOf));
        }
    }
}
