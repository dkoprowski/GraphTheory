using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory.Lab2
{
    public class CycleFinderTests
    {
        public static void Run()
        {
            var tests = new CycleFinderTests();
            tests.OneCycleGraph();
            tests.FewCyclesGraph();
        }

        public void OneCycleGraph()
        {
            Console.WriteLine("---------------------------------------");
            var graph = new Lab1.AdjacencyMatrix(4);

            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            for (int i = 1; i <= graph.Order; i++)
            {
                Console.Write("Neighbours [" + i + "]: ");
                graph.Neighbours(i).ForEach(_ => Console.Write(_ + "; "));
                Console.WriteLine();
            }

            var finder = new CycleFinder();
            finder.GetAnyCycle(graph);

            Console.ReadKey();
        }

        public void FewCyclesGraph()
        {
            Console.WriteLine("---------------------------------------");
            var graph = new Lab1.AdjacencyMatrix(5);

            graph.AddEdge(1, 5);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);

            for (int i = 1; i <= graph.Order; i++)
            {
                Console.Write("Neighbours [" + i + "]: ");
                graph.Neighbours(i).ForEach(_ => Console.Write(_ + "; "));
                Console.WriteLine();
            }

            var finder = new CycleFinder();
            finder.GetAnyCycle(graph);

            Console.ReadKey();
        }
    }
}
