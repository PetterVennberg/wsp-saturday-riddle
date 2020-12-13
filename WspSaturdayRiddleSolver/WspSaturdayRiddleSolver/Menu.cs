using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WspSaturdayRiddleSolver
{
    class Menu
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Analyze WSP Saturday Riddle");
            Console.WriteLine("2. Exit");

            Console.Write("\nSelection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Solver.Run(5);
                    break;

                case "2":
                    break;

                default:
                    break;
            }
        }
    }
}
