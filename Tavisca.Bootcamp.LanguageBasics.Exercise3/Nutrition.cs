using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public class Nutrition
    {
        public int Protein { get; }
        public int Carbs { get; }
        public int Fat { get; }
        public int Calories
        {
            get
            {
                return CalculateCalories();
            }
        }
        public int Index { get;  }

        public Nutrition(int protein, int carbs, int fat, int index)
        {
            this.Protein = protein;
            this.Carbs = carbs;
            this.Fat = fat;
            this.Index = index;
        }

        public int CalculateCalories()
        {
           return (5 * this.Protein) + (5 * this.Carbs) + (9 * this.Fat);
        }
    }
}
