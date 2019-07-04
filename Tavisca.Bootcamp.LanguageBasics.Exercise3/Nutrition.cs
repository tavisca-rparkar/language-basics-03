using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Nutrition
    {
        public int[] protein, carbs, fat, calories;

        public Nutrition(int[] protein, int[] carbs, int[] fat)
        {
            this.protein = protein;
            this.carbs = carbs;
            this.fat = fat;
            calories = new int[this.protein.Length];
            CalculateCalories();
        }

        private void CalculateCalories()
        {
            for (int i = 0; i < protein.Length; i++)
            {
                calories[i] = (5 * protein[i]) + (5 * carbs[i]) + (9 * fat[i]);
            }
        }
    }
}
