using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public class FatIndexCounter : INutritionSelector
    {
        Nutrition[] INutritionSelector.ComputeIndexes(Nutrition[] nutritions, string diet)
        {
            List<Nutrition> indexTrack = new List<Nutrition>();

            if (diet.Equals("F"))
            {
                int maxFat = nutritions.Select(x => x.Fat).ToArray().Max();
                for (int i = 0; i < nutritions.Length; i++)
                {
                    if (nutritions[i].Fat == maxFat)
                    {
                        indexTrack.Add(nutritions[i]);
                    }
                }
            }
            else
            {
                int minFat = nutritions.Select(x => x.Fat).ToArray().Min();
                for (int i = 0; i < nutritions.Length; i++)
                {
                    if (nutritions[i].Fat == minFat)
                    {
                        indexTrack.Add(nutritions[i]);
                    }
                }
            }

            return indexTrack.ToArray();
        }
    }
}
