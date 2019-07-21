using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public class IndexCounterFactory
    {
        public static INutritionSelector GetIndexCounter(string diet)
        {
            switch (diet.ToLower())
            {
                case "p":
                    return new ProteinIndexCounter();
                case "c":
                    return new CarbIndexCounter();
                case "f":
                    return new FatIndexCounter();
                case "t":
                    return new CalorieIndexCounter();
                default:
                    throw new Exception("Unexpected character provided in request...");
            }
        }
    }
}
