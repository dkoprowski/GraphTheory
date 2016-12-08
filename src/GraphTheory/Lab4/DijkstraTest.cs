using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphTheory.Lab3;
namespace GraphTheory.Lab4
{
    public class DijkstraTest
    {
        public static void Run()
        {
            var graph = GetSlidesGraph();

            graph.PrintAdjacency();

            var dijkstra = new Dijkstra();
            var matrix = dijkstra.RunDijkstraAlg(graph, 1);
            Console.Write(matrix.Length);
        }      

        private static WeightedDiAdjacencyMatrix GetSlidesGraph()
        {
            /* dijkrstra.png
             * 's' = 1
             * 'a' = 2
             * 'b' = 3
             * 'c' = 4
             * 'd' = 5
             * 'e' = 6
             */
            var graph = new WeightedDiAdjacencyMatrix(6);
            graph.AddDuplexEdge(1, 3, 2f);
            graph.AddDuplexEdge(1, 5, 1f);
            graph.AddDuplexEdge(1, 4, 2f);

            graph.AddDuplexEdge(3, 4, 1f);
            graph.AddDuplexEdge(3, 5, 1f);
            graph.AddDuplexEdge(3, 2, 1f);

            graph.AddDuplexEdge(2, 5, 3f);
            graph.AddDuplexEdge(2, 6, 1f);

            graph.AddDuplexEdge(4, 5, 2f);

            graph.AddDuplexEdge(5, 6, 4f);

            return graph;
        }
    }
}
