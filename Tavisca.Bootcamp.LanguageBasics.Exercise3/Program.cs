using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        private static int[] results;
        private const string max = "max";
        private const string min = "min";
        private static Nutrition nutrition;

        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            nutrition = new Nutrition(protein, carbs, fat);
            var result = SelectMeals(dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(string[] dietPlans)
        {
            int[] indexTrack;
            string diet;
            bool flag;
            results = new int[dietPlans.Length];

            for(int i=0; i<dietPlans.Length; i++)
            {
                diet = dietPlans[i];
                flag = false;
                indexTrack = new int[]{ };

                if (diet.Length == 0)
                {
                    results[i] = 0;
                }
                else
                {
                    for (int j = 0; j < diet.Length; j++)
                    {
                        switch (diet[j])
                        {
                            case 'P':
                                indexTrack = ComputeIndexes(nutrition.protein, indexTrack, max);
                                break;
                            case 'p':
                                indexTrack = ComputeIndexes(nutrition.protein, indexTrack, min);
                                break;
                            case 'C':
                                indexTrack = ComputeIndexes(nutrition.carbs, indexTrack, max);
                                break;
                            case 'c':
                                indexTrack = ComputeIndexes(nutrition.carbs, indexTrack, min);
                                break;
                            case 'F':
                                indexTrack = ComputeIndexes(nutrition.fat, indexTrack, max);
                                break;
                            case 'f':
                                indexTrack = ComputeIndexes(nutrition.fat, indexTrack, min);
                                break;
                            case 'T':
                                indexTrack = ComputeIndexes(nutrition.calories, indexTrack, max);
                                break;
                            case 't':
                                indexTrack = ComputeIndexes(nutrition.calories, indexTrack, min);
                                break;
                        }

                        flag = CheckIfPerfectMeal(indexTrack, i);

                        if(flag==true)
                        {
                            break;
                        }
                    }
                    if(flag == false)
                    {
                        results[i] = indexTrack.Min();
                    }
                }
            }
            return results;
        }

        private static int[] ComputeIndexes(int[] nutrition, int[] currentIndex, string intake)
        {
            int value;
            if (currentIndex.Count() == 0)
            {
                currentIndex = new int[nutrition.Length];
                for(int i=0; i<nutrition.Length; i++)
                {
                    currentIndex[i] = i;
                }
            }

            if (intake == max)
            {
                value = MaxNutritionValue(nutrition, currentIndex);
            }
            else
            {
                value = MinNutritionValue(nutrition, currentIndex);
            }

            return UpdateIndexes(nutrition, currentIndex, value);
        }

        private static bool CheckIfPerfectMeal(int[] indexTrack, int dietPlanIndex)
        {
            if (indexTrack.Count() == 1)
            {
                results[dietPlanIndex] = indexTrack[0];
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int MaxNutritionValue(int[] nutrition, int[] currentIndex)
        {
            int value = nutrition.Min();
            for (int i = 0; i < currentIndex.Length; i++)
            {
                if (nutrition[currentIndex[i]] > value)
                {
                    value = nutrition[currentIndex[i]];
                }
            }
            return value;
        }

        private static int MinNutritionValue(int[] nutrition, int[] currentIndex)
        {
            int value = nutrition.Max();
            for (int i = 0; i < currentIndex.Length; i++)
            {
                if (nutrition[currentIndex[i]] < value)
                {
                    value = nutrition[currentIndex[i]];
                }
            }
            return value;
        }

        private static int[] UpdateIndexes(int[] nutrition, int[] currentIndex, int value)
        {
            List<int> tempIndex = new List<int>();

            for (int i = 0; i < currentIndex.Length; i++)
            {
                if (nutrition[currentIndex[i]] == value)
                {
                    tempIndex.Add(currentIndex[i]);
                }
            }
            return tempIndex.ToArray();
        }
    }
}
