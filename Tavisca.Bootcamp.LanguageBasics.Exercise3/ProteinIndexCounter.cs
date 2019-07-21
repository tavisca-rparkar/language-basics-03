using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public class ProteinIndexCounter : INutritionSelector
    {
        Nutrition[] INutritionSelector.ComputeIndexes(Nutrition[] nutritions, string diet)
        {
            List<Nutrition> indexTrack = new List<Nutrition>();

            if(diet.Equals("P"))
            {
                int maxProtein = nutritions.Select(x => x.Protein).ToArray().Max();
                for(int i=0; i<nutritions.Length; i++)
                {
                    if(nutritions[i].Protein == maxProtein)
                    {
                        indexTrack.Add(nutritions[i]);
                    }
                }
            }
            else
            {
                int minProtein = nutritions.Select(x => x.Protein).ToArray().Min();
                for (int i = 0; i < nutritions.Length; i++)
                {
                    if (nutritions[i].Protein == minProtein)
                    {
                        indexTrack.Add(nutritions[i]);
                    }
                }
            }

            return indexTrack.ToArray();
        }
    }
}
