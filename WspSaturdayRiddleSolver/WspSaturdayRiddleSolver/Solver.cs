using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WspSaturdayRiddleSolver
{
    class Solver
    {
        public static void Run()
        {
            int numberOfPossibleStreetCombinations = 120;
            List<House> houses = ImportHouses();
            List<string> owners = ImportOwners();
            List<string> colors = ImportColors();
            List<string> drinks = ImportDrinks();
            List<string> pets = ImportPets();
            List<string> newspapers = ImportNewspapers();

            List<House> possibleCombinations = GetPossibleHouseCombinations(numberOfPossibleStreetCombinations, houses, owners, colors, drinks, pets, newspapers);

        }

        private static List<House> ImportHouses()
        {
            List<House> houses = new List<House>();

            for (int i = 0; i < 5; i++)
            {
                houses.Add(new House() { Adress = i + 1 });
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

        private static List<House> GetPossibleHouseCombinations(int numberOfPossibleStreetCombinations, List<House> houses, List<string> owners, List<string> colors, List<string> drinks, List<string> pets, List<string> newspapers)
        {
            List<House> possibleCombinations = new List<House>();
            
            foreach (House house in houses)
            {
                for (int i = 0; i < 120; i++)
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
                                        House possibleCombination = new House
                                        {
                                            OnStreet = i + 1,
                                            Adress = house.Adress,
                                            Owner = owner,
                                            Color = color,
                                            OwnerDrinks = drink,
                                            OwnersPet = pet,
                                            ReadsNewsPaper = newspaper
                                        };

                                        if (AbsoluteConditionsAreMet(possibleCombination))
                                        {
                                            possibleCombinations.Add(possibleCombination);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return possibleCombinations;
        }

        private static bool AbsoluteConditionsAreMet(House house)
        {
            if (
                        Condition1(house) ||
                        Condition2(house) ||
                        Condition3(house) ||
                        Condition5(house) ||
                        Condition6(house) ||
                        Condition7(house) ||
                        Condition8(house) ||
                        Condition9(house) ||
                        Condition12(house) ||
                        Condition13(house)
                   )
            {
                return true;
            }

            return false;
        }

        private static bool Condition1(House house)
        {
            if (house.Owner.Equals("Pär") &&
                house.Color.Equals("Red"))
            {
                return true;
            }

            return false;
        }
                                     
        private static bool Condition2(House house)
        {
            if (house.Owner.Equals("Emma") &&
                house.OwnersPet.Equals("Dogs"))
            {
                return true;
            }

            return false;
        }
                                     
        private static bool Condition3(House house)
        {
            if (house.Owner.Equals("Gustav") &&
                house.OwnerDrinks.Equals("Vodka"))
            {
                return true;
            }

            return false;
        }

        private static bool Condition5(House house)
        {
            if (house.Color.Equals("Green") &&
                house.OwnerDrinks.Equals("Coffe"))
            {
                return true;
            }

            return false;
        }

        private static bool Condition6(House house)
        {
            if (house.ReadsNewsPaper.Equals("Nyheter24") &&
                house.OwnersPet.Equals("Eagle"))
            {
                return true;
            }

            return false;
        }

        private static bool Condition7(House house)
        {
            if (house.Color.Equals("Purple") &&
                house.ReadsNewsPaper.Equals("Aftonbladet"))
            {
                return true;
            }

            return false;
        }

        private static bool Condition8(House house)
        {
            if (house.Adress.Equals(3) &&
                house.OwnerDrinks.Equals("Milk"))
            {
                return true;
            }

            return false;
        }

        private static bool Condition9(House house)
        {
            if (house.Adress.Equals(1) &&
                house.Owner.Equals("Henrik"))
            {
                return true;
            }

            return false;
        }

        private static bool Condition12(House house)
        {
            if (house.ReadsNewsPaper.Equals("Dagens Nyheter") &&
                house.OwnerDrinks.Equals("Beer"))
            {
                return true;
            }

            return false;
        }

        private static bool Condition13(House house)
        {
            if (house.ReadsNewsPaper.Equals("Svenska Dagbladet") &&
                house.Owner.Equals("Anton"))
            {
                return true;
            }

            return false;
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
