using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WspSaturdayRiddleSolver
{
    class Solver
    {
        public static void Run(int numberOfCollections)
        {
            List<House> houses = CreateHouses(numberOfCollections);
            List<string> owners = ImportOwners();
            List<string> colors = ImportColors();
            List<string> drinks = ImportDrinks();
            List<string> pets = ImportPets();
            List<string> newspapers = ImportNewspapers();

            List<House> possibleCombinations = GetPossibleCombinations(houses, owners, colors, drinks, pets, newspapers);

            AnalyzeData(possibleCombinations);

        }

        private static List<House> CreateHouses(int numberOfCollections)
        {
            List<House> houses = new List<House>();

            for (int i = 0; i < numberOfCollections; i++)
            {
                houses.Add(new House() { Postition = i });
            }

            return houses;
        }

        private static List<string> ImportOwners()
        {
            return new List<string>()
            {
                "Pär",
                "Emma",
                "Anton",
                "Henrik",
                "Gustav"

            };
        }

        private static List<string> ImportColors()
        {
            return new List<string>()
            {
                "Red",
                "White",
                "Purple",
                "Green",
                "Blue"

            };
        }

        private static List<string> ImportDrinks()
        {
            return new List<string>()
            {
                "Vodka",
                "Beer",
                "Milk",
                "Green Tea",
                "Coffe"

            };
        }

        private static List<string> ImportPets()
        {
            return new List<string>()
            {
                "Dogs",
                "Horse",
                "Eagle",
                "Tiger",
                "Goldfish"

            };
        }

        private static List<string> ImportNewspapers()
        {
            return new List<string>()
            {
                "Expressen",
                "Nyheter24",
                "Svenska Dagbladet",
                "Dagens Nyheter",
                "Aftonbladet"

            };
        }

        private static List<House> GetPossibleCombinations(List<House> houses, List<string> owners, List<string> colors, List<string> drinks, List<string> pets, List<string> newspapers)
        {
            double count = Math.Pow(houses.Count, 6);
            List<House> possibleConbinations = new List<House>();

            for (int i = 0; i < count; i++)
            {
                possibleConbinations.Add(new House());
            }

            foreach (House possibleCombination in possibleConbinations)
            {
                foreach (House house in houses)
                {
                    foreach (string owner in owners)
                    {
                        foreach (string color in colors)
                        {
                            foreach (string drink in drinks)
                            {
                                foreach (string pet in pets)
                                {
                                    foreach (string newspaper in newspapers)
                                    {
                                        possibleCombination.Postition = house.Postition;
                                        possibleCombination.Owner = owner;
                                        possibleCombination.Color = color;
                                        possibleCombination.OwnerDrinks = drink;
                                        possibleCombination.OwnersPet = pet;
                                        possibleCombination.ReadsNewsPaper = newspaper;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return possibleConbinations;
        }

        private static void AnalyzeData(List<House> possibleCombinations)
        {
            Console.ReadLine();
        }

        //private static List<House> ImportAbsoluteInputParameters()
        //{
        //    List<House> inputParameters = new List<House>
        //    {

        //        // 1
        //        new House() { Owner = "Pär", Color = "Red" },
        //        // 2
        //        new House() { Owner = "Emma", OwnersPet = "Dogs" },
        //        // 3
        //        new House() { Owner = "Gustav", OwnerDrinks = "Vodka"},
        //        // 4
        //        new House() { Color = "White" },
        //        // 5
        //        new House() { Color = "Green", OwnerDrinks = "Coffe" },
        //        // 6
        //        new House() { ReadsNewsPaper = "Nyheter24", OwnersPet = "Eagle" },
        //        // 7
        //        new House() { Color = "Purple", ReadsNewsPaper = "Aftonbladet" },
        //        // 8
        //        new House() { Postition = 2, OwnerDrinks = "Milk" },
        //        // 9
        //        new House() { Owner = "Henrik", Postition = 0 },
        //        // 10
        //        new House() { ReadsNewsPaper = "Expressen" },
        //        new House() { OwnersPet = "Tiger" },
        //        // 11
        //        new House() { OwnersPet = "Horse" },
        //        // 12
        //        new House() { ReadsNewsPaper = "Dagen Nyheter", OwnerDrinks = "Beer" },
        //        // 13
        //        new House() { Owner = "Anton", ReadsNewsPaper = "Svenska Dagbladet" },
        //        // 14
        //        new House() { Color = "Blue" },
        //        // 15
        //        new House() { OwnerDrinks = "Green Tea" },

        //    };



        //    return inputParameters;
        //}

        //private static void AnalyzeAbsoluteParameters(List<House> inputParameters)
        //{
        //    // Position
        //    //foreach (House parameter in inputParameters)
        //    //{
        //    //    if (parameter.Postition != null)
        //    //    {
        //    //        List<House> matchingInput = inputParameters.Where(i => i.Postition == parameter.Postition).ToList();

        //    //        if (matchingInput.Count() > 0)
        //    //        {
        //    //            parameter
        //    //        }
        //    //    }
        //    //}

        //}
        
        //private static void AnalyzeRelationalInput()
        //{
        //    // 4
        //    // 10
        //    // 11
        //    // 14
        //    // 15
        //}


    }
}
