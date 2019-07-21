using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public class CarbIndexCounter : INutritionSelector
    {
        Nutrition[] INutritionSelector.ComputeIndexes(Nutrition[] nutritions, string diet)
        {
            List<Nutrition> indexTrack = new List<Nutrition>();

            if (diet.Equals("C"))
            {
                int maxCarb = nutritions.Select(x => x.Carbs).ToArray().Max();
                for (int i = 0; i < nutritions.Length; i++)
                {
                    if (nutritions[i].Carbs == maxCarb)
                    {
                        indexTrack.Add(nutritions[i]);
                    }
                }
            }
            else
            {
                int minCarb = nutritions.Select(x => x.Carbs).ToArray().Min();
                for (int i = 0; i < nutritions.Length; i++)
                {
                    if (nutritions[i].Carbs == minCarb)
                    {
                        indexTrack.Add(nutritions[i]);
                    }
                }
            }

            return indexTrack.ToArray();
        }
    }
}

