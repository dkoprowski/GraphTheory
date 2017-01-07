using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteOptions();            
        }


        static void WriteOptions()
        {
            Console.WriteLine("\nChoose an algorithm:");
            Console.WriteLine("Type [1] for AdjacencyMatrix");
            Console.WriteLine("Type [2] for CycleFinder");
            Console.WriteLine("Type [3] for WeightedDiGraph");
            Console.WriteLine("Type [4] for Dijkstra");
            Console.WriteLine("Type [5] for Graph Cut problem");
            Console.WriteLine("Type [exit] or [q] to finish program");

            GetResponse();
        }

        static void GetResponse()
        {
            string choosedOption = Console.ReadLine();
            Console.WriteLine("-----------------------------------");

            switch (choosedOption)
            {
                case "1":
                    Lab1.AdjacencyMatrixTest.Run();
                    break;
                case "2":
                    Lab2.CycleFinderTests.Run();
                    break;
                case "3":
                    Lab3.WeightedDiGraphTest.Run();
                    break;
                case "4":
                    Lab4.DijkstraTest.Run();
                    break;
                case "5":
                    FordFulkerson.MaximalFlowTest.Run();
                    break;
                default:
                    Console.WriteLine("I don't understand. Try something from list below: ");
                    break;
                case "exit":
                    return;
                case "q":
                    return;
            }
            Console.WriteLine("-----------------------------------");
            WriteOptions();
        }
    }
}
