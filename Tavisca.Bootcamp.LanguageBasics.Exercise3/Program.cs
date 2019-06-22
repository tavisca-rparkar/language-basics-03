using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
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
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            int[] calories = new int[protein.Length], results = new int[dietPlans.Length], index_track;
            string diet;
            Boolean flag;
            for(int i=0; i<protein.Length; i++)
            {
                calories[i] = (5 * protein[i]) + (5 * carbs[i]) + (9 * fat[i]);
            }

            for(int i=0; i<dietPlans.Length; i++)
            {
                diet = dietPlans[i];
                flag = false;
                index_track = new int[]{ };

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
                                index_track = ComputeIndexes(protein, index_track, "max");
                                if (index_track.Count() == 1)
                                {
                                    results[i] = index_track[0];
                                    flag = true;
                                }
                                break;
                            case 'p':
                                index_track = ComputeIndexes(protein, index_track, "min");
                                if (index_track.Count() == 1)
                                {
                                    results[i] = index_track[0];
                                    flag = true;
                                }
                                break;
                            case 'C':
                                index_track = ComputeIndexes(carbs, index_track, "max");
                                if (index_track.Count() == 1)
                                {
                                    results[i] = index_track[0];
                                    flag = true;
                                }
                                break;
                            case 'c':
                                index_track = ComputeIndexes(carbs, index_track, "min");
                                if (index_track.Count() == 1)
                                {
                                    results[i] = index_track[0];
                                    flag = true;
                                }
                                break;
                            case 'F':
                                index_track = ComputeIndexes(fat, index_track, "max");
                                if (index_track.Count() == 1)
                                {
                                    results[i] = index_track[0];
                                    flag = true;
                                }
                                break;
                            case 'f':
                                index_track = ComputeIndexes(fat, index_track, "min");
                                if (index_track.Count() == 1)
                                {
                                    results[i] = index_track[0];
                                    flag = true;
                                }
                                break;
                            case 'T':
                                index_track = ComputeIndexes(calories, index_track, "max");
                                if (index_track.Count() == 1)
                                {
                                    results[i] = index_track[0];
                                    flag = true;
                                }
                                break;
                            case 't':
                                index_track = ComputeIndexes(calories, index_track, "min");
                                if (index_track.Count() == 1)
                                {
                                    results[i] = index_track[0];
                                    flag = true;
                                }
                                break;
                        }
                        if(flag==true)
                        {
                            break;
                        }
                    }
                    if(flag == false)
                    {
                        results[i] = index_track.Min();
                    }
                }
            }
            return results;
            throw new NotImplementedException();
        }

        public static int[] ComputeIndexes(int[] nutrition, int[] current_index, string intake)
        {
            int value=0;
            List<int> temp_index = new List<int>();

            if (current_index.Count() == 0)
            {
                current_index = new int[nutrition.Length];
                for(int i=0; i<nutrition.Length; i++)
                {
                    current_index[i] = i;
                }
            }

            if (intake == "max")
            {
                value = nutrition.Min();
                for (int i = 0; i < current_index.Length; i++)
                {
                    if (nutrition[current_index[i]] > value)
                    {
                        value = nutrition[current_index[i]];
                    }
                }
            }
            else if (intake == "min")
            {
                value = nutrition.Max();
                for (int i = 0; i < current_index.Length; i++)
                {
                    if (nutrition[current_index[i]] < value)
                    {
                        value = nutrition[current_index[i]];
                    }
                }
            }

            for (int i=0; i<current_index.Length; i++)
            {
                if(nutrition[current_index[i]] == value)
                {
                    temp_index.Add(current_index[i]);
                }
            }
            return temp_index.ToArray();
        }
    }
}
