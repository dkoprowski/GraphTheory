using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory.Lab3
{
    public class WeightedDiGraphTest
    {        
        public static void Run()
        {
            Console.WriteLine("---------------------------------------");

            var graph = new WeightedDiAdjacencyMatrix(5);
            graph.AddEdge(2, 1, 1f);
            graph.AddEdge(1, 4, 1f);
            graph.AddEdge(4, 5, 1f);
            graph.AddEdge(1, 3, 1f);
            graph.AddEdge(3, 2, 1f);
            //graph.PrintAdjacency();


            var kosaraju = new Kosaraju();
            kosaraju.PrintSCCs(graph);


            Console.ReadKey();
        }        
    }
}
