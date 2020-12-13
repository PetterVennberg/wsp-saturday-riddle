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
            List<House> houses = ImportHouses();
            List<string> owners = ImportOwners();
            List<string> colors = ImportColors();
            List<string> drinks = ImportDrinks();
            List<string> pets = ImportPets();
            List<string> newspapers = ImportNewspapers();

            List<House> possibleCombinations = GetPossibleHouseCombinations(houses, owners, colors, drinks, pets, newspapers);

            AnalyzeHouseData(possibleCombinations);
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

        private static List<House> GetPossibleHouseCombinations(List<House> houses, List<string> owners, List<string> colors, List<string> drinks, List<string> pets, List<string> newspapers)
        {
            List<House> possibleCombinations = new List<House>();
            
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
                                    House possibleCombination = new House
                                    {
                                        Adress = house.Adress,
                                        Owner = owner,
                                        Color = color,
                                        OwnerDrinks = drink,
                                        OwnersPet = pet,
                                        ReadsNewsPaper = newspaper
                                    };

                                    possibleCombinations.Add(possibleCombination);

                                }
                            }
                        }
                    }
                }
            }

            return possibleCombinations;
        }

        private static void AnalyzeHouseData(List<House> possibleCombinations)
        {
            // Run Absolute 
            VerifyAbsoluteConditions(possibleCombinations);

            // WIP Need to find assesment if true
            while (true)
            {
                RelCondition4(possibleCombinations);
                RelCondition10(possibleCombinations);
                RelCondition11(possibleCombinations);
                RelCondition14(possibleCombinations);
                RelCondition15(possibleCombinations);

            }
            
            
        }

        private static void VerifyAbsoluteConditions(List<House> possibleCombinations)
        {
            AbsCondition1(possibleCombinations);
            AbsCondition2(possibleCombinations);
            AbsCondition3(possibleCombinations);
            AbsCondition5(possibleCombinations);
            AbsCondition6(possibleCombinations);
            AbsCondition7(possibleCombinations);
            AbsCondition8(possibleCombinations);
            AbsCondition9(possibleCombinations);
            AbsCondition12(possibleCombinations);
            AbsCondition13(possibleCombinations);
        }

        private static void AbsCondition1(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.Owner.Equals("Pär") && !h.Color.Equals("Red"));
            possibleCombinations.RemoveAll(h => !h.Owner.Equals("Pär") && h.Color.Equals("Red"));
        }

        private static void AbsCondition2(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.Owner.Equals("Emma") && !h.OwnersPet.Equals("Dogs"));
            possibleCombinations.RemoveAll(h => !h.Owner.Equals("Emma") && h.OwnersPet.Equals("Dogs"));
        }

        private static void AbsCondition3(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.Owner.Equals("Gustav") && !h.OwnerDrinks.Equals("Vodka"));
            possibleCombinations.RemoveAll(h => !h.Owner.Equals("Gustav") && h.OwnerDrinks.Equals("Vodka"));
        }

        private static void RelCondition4(List<House> possibleCombinations)
        {
            // Filter green
            int highestAdressForWhite = possibleCombinations.Where(h => h.Color.Equals("White")).Max(h => h.Adress);

            List<House> invalidGreenHouses = possibleCombinations.Where(h => h.Color.Equals("Green") && h.Adress >= highestAdressForWhite).ToList();

            foreach (House house in invalidGreenHouses)
            {
                possibleCombinations.Remove(house);
            }

            // Filter white
            int lowestAdressForGreen = possibleCombinations.Where(h => h.Color.Equals("Green")).Min(h => h.Adress);

            List<House> invalidWhiteHouses = possibleCombinations.Where(h => h.Color.Equals("White") && h.Adress <= lowestAdressForGreen).ToList();

            foreach (House house in invalidWhiteHouses)
            {
                possibleCombinations.Remove(house);
            }
        }

        private static void AbsCondition5(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.Color.Equals("Green") && !h.OwnerDrinks.Equals("Coffe"));
            possibleCombinations.RemoveAll(h => !h.Color.Equals("Green") && h.OwnerDrinks.Equals("Coffe"));
        }

        private static void AbsCondition6(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.ReadsNewsPaper.Equals("Nyheter24") && !h.OwnersPet.Equals("Eagle"));
            possibleCombinations.RemoveAll(h => !h.ReadsNewsPaper.Equals("Nyheter24") && h.OwnersPet.Equals("Eagle"));
        }

        private static void AbsCondition7(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.ReadsNewsPaper.Equals("Aftonbladet") && !h.Color.Equals("Purple"));
            possibleCombinations.RemoveAll(h => !h.ReadsNewsPaper.Equals("Aftonbladet") && h.Color.Equals("Purple"));
        }

        private static void AbsCondition8(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.Adress.Equals(3) && !h.OwnerDrinks.Equals("Milk"));
            possibleCombinations.RemoveAll(h => !h.Adress.Equals(3) && h.OwnerDrinks.Equals("Milk"));
        }

        private static void AbsCondition9(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.Adress.Equals(1) && !h.Owner.Equals("Henrik"));
            possibleCombinations.RemoveAll(h => !h.Adress.Equals(1) && h.Owner.Equals("Henrik"));
        }

        private static void RelCondition10(List<House> possibleCombinations)
        {
            PetAndNewspaperAsNeighbours(possibleCombinations, "Tiger", "Expressen");
        }

        private static void RelCondition11(List<House> possibleCombinations)
        {
            PetAndNewspaperAsNeighbours(possibleCombinations, "Horse", "Aftonbladet");
        }

        private static void AbsCondition12(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.ReadsNewsPaper.Equals("Dagens Nyheter") && !h.OwnerDrinks.Equals("Beer"));
            possibleCombinations.RemoveAll(h => !h.ReadsNewsPaper.Equals("Dagens Nyheter") && h.OwnerDrinks.Equals("Beer"));
        }

        private static void AbsCondition13(List<House> possibleCombinations)
        {
            possibleCombinations.RemoveAll(h => h.ReadsNewsPaper.Equals("Svenska Dagbladet") && !h.Owner.Equals("Anton"));
            possibleCombinations.RemoveAll(h => !h.ReadsNewsPaper.Equals("Svenska Dagbladet") && h.Owner.Equals("Anton"));
        }

        private static void RelCondition14(List<House> possibleCombinations)
        {
            string owner = "Henrik";
            string color = "Blue";

            int firstHouseForHenrik = possibleCombinations.Where(h => h.Owner.Equals(owner)).Min(h => h.Adress);
            int lastHouseForHenrik = possibleCombinations.Where(h => h.Owner.Equals(owner)).Max(h => h.Adress);

            int firstBlueHouse = possibleCombinations.Where(h => h.Color.Equals(color)).Min(h => h.Adress);
            int lastBlueHouse = possibleCombinations.Where(h => h.Color.Equals(color)).Max(h => h.Adress);

            if (lastHouseForHenrik > lastBlueHouse + 1)
            {
                possibleCombinations.RemoveAll(h => h.Owner.Equals(owner) && h.Adress == lastHouseForHenrik);
            }

            if (lastBlueHouse > lastHouseForHenrik + 1)
            {
                possibleCombinations.RemoveAll(h => h.OwnersPet.Equals(color) && h.Adress == lastBlueHouse);
            }

            if (firstHouseForHenrik < firstBlueHouse - 1)
            {
                possibleCombinations.RemoveAll(h => h.Owner.Equals(owner) && h.Adress == firstHouseForHenrik);
            }

            if (firstBlueHouse < firstHouseForHenrik - 1)
            {
                possibleCombinations.RemoveAll(h => h.OwnersPet.Equals(color) && h.Adress == firstBlueHouse);
            }
        }

        private static void RelCondition15(List<House> possibleCombinations)
        {
            string newspaper = "Expressen";
            string drink = "Green Tea";

            int firstHouseWithExpressen = possibleCombinations.Where(h => h.ReadsNewsPaper.Equals(newspaper)).Min(h => h.Adress);
            int lastHouseWithExpressen = possibleCombinations.Where(h => h.ReadsNewsPaper.Equals(newspaper)).Max(h => h.Adress);

            int firstHouseWithGreenTea = possibleCombinations.Where(h => h.OwnerDrinks.Equals(drink)).Min(h => h.Adress);
            int lastHouseWithGreenTea = possibleCombinations.Where(h => h.OwnerDrinks.Equals(drink)).Max(h => h.Adress);

            if (lastHouseWithExpressen > lastHouseWithGreenTea + 1)
            {
                possibleCombinations.RemoveAll(h => h.ReadsNewsPaper.Equals(newspaper) && h.Adress == lastHouseWithExpressen);
            }

            if (lastHouseWithGreenTea > lastHouseWithExpressen + 1)
            {
                possibleCombinations.RemoveAll(h => h.OwnerDrinks.Equals(drink) && h.Adress == lastHouseWithGreenTea);
            }

            if (firstHouseWithExpressen < firstHouseWithGreenTea - 1)
            {
                possibleCombinations.RemoveAll(h => h.ReadsNewsPaper.Equals(newspaper) && h.Adress == firstHouseWithExpressen);
            }

            if (firstHouseWithGreenTea < firstHouseWithExpressen - 1)
            {
                possibleCombinations.RemoveAll(h => h.OwnerDrinks.Equals(drink) && h.Adress == firstHouseWithGreenTea);
            }
        }

        private static void PetAndNewspaperAsNeighbours(List<House> possibleCombinations, string pet, string newspaper)
        {
            int firstHouseWithNewspaper = possibleCombinations.Where(h => h.ReadsNewsPaper.Equals(newspaper)).Min(h => h.Adress);
            int lastHouseWithNewspaper = possibleCombinations.Where(h => h.ReadsNewsPaper.Equals(newspaper)).Max(h => h.Adress);

            int firstHouseWithPet = possibleCombinations.Where(h => h.OwnersPet.Equals(pet)).Min(h => h.Adress);
            int lastHouseWithPet = possibleCombinations.Where(h => h.OwnersPet.Equals(pet)).Max(h => h.Adress);

            if (lastHouseWithPet > lastHouseWithNewspaper + 1)
            {
                possibleCombinations.RemoveAll(h => h.ReadsNewsPaper.Equals(newspaper) && h.Adress == lastHouseWithPet);
            }

            if (lastHouseWithNewspaper > lastHouseWithPet + 1)
            {
                possibleCombinations.RemoveAll(h => h.OwnersPet.Equals(pet) && h.Adress == lastHouseWithNewspaper);
            }

            if (firstHouseWithPet < firstHouseWithNewspaper - 1)
            {
                possibleCombinations.RemoveAll(h => h.ReadsNewsPaper.Equals(newspaper) && h.Adress == firstHouseWithPet);
            }

            if (firstHouseWithNewspaper < firstHouseWithPet - 1)
            {
                possibleCombinations.RemoveAll(h => h.OwnersPet.Equals(pet) && h.Adress == firstHouseWithNewspaper);
            }
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
