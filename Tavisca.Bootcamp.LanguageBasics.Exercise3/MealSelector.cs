using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class MealSelector
    {
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] results = new int[dietPlans.Length];
            var nutritions = GetNutritions(protein, carbs, fat);

            for (int dietCounter = 0; dietCounter < dietPlans.Length; dietCounter++)
            {
                string diet = dietPlans[dietCounter];

                if (string.IsNullOrWhiteSpace(diet))
                {
                    results[dietCounter] = 0;
                }
                else
                {
                    int index = GetIndexForDietPlan(nutritions, results, dietCounter, diet);
                    results[dietCounter] = index;
                }
            }
            return results;
        }

        private static int GetIndexForDietPlan(Nutrition[] nutritions, int[] results, int dietCounter, string diet)
        {
            List<int> indexTrack = new List<int>();
            Nutrition[] nutritionArray = nutritions;
            for (int dietFactor = 0; dietFactor < diet.Length; dietFactor++)
            {
                Nutrition[] indexes = GetNutritionForDiet(nutritionArray, diet[dietFactor].ToString());

                if (indexes.Length == 1)
                {
                    indexTrack.Add(indexes[0].Index);
                    break;
                }
                else
                {
                    nutritionArray = new Nutrition[indexes.Length];
                    nutritionArray = indexes;
                }

                if(dietFactor == diet.Length-1)
                {
                    indexTrack.AddRange(indexes.Select(x => x.Index));
                }
            }
            return indexTrack.Min();
        }

        private static Nutrition[] GetNutritionForDiet(Nutrition[] nutritionArray, string diet)
        {
            var counter = IndexCounterFactory.GetIndexCounter(diet);
            var indexes = counter.ComputeIndexes(nutritionArray, diet);
            return indexes;
        }
        private static Nutrition[] GetNutritions(int[] protein, int[] carbs, int[] fat)
        {
            var nutrition = new Nutrition[protein.Length];

            for (int counter = 0; counter < protein.Length; counter++)
            {
                nutrition[counter] = new Nutrition(protein[counter], carbs[counter], fat[counter], counter);
            }

            return nutrition;
        }
    }
}
