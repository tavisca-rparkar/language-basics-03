using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public class CalorieIndexCounter : INutritionSelector
    {
        Nutrition[] INutritionSelector.ComputeIndexes(Nutrition[] nutritions, string diet)
        {
            List<Nutrition> indexTrack = new List<Nutrition>();

            if (diet.Equals("T"))
            {
                int maxCalorie = nutritions.Select(x => x.Calories).ToArray().Max();
                for (int i = 0; i < nutritions.Length; i++)
                {
                    if (nutritions[i].Calories == maxCalorie)
                    {
                        indexTrack.Add(nutritions[i]);
                    }
                }
            }
            else
            {
                int minCalorie = nutritions.Select(x => x.Calories).ToArray().Min();
                for (int i = 0; i < nutritions.Length; i++)
                {
                    if (nutritions[i].Calories == minCalorie)
                    {
                        indexTrack.Add(nutritions[i]);
                    }
                }
            }

            return indexTrack.ToArray();
        }
    }
}
