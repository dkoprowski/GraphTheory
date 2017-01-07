using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphTheory.Lab3;
namespace GraphTheory.FordFulkerson
{
    public class MaximalFlowTest
    {
        public static void Run()
        {
            var edmondsKarp = new EdmondsKarp();
            Console.WriteLine( edmondsKarp.MaximumFlow(CormenMatrix(), 0, 5));
            Console.WriteLine( edmondsKarp.MaximumFlow(YoutubeMatrix(), 0, 5));
        }

        private  static WeightedDiAdjacencyMatrix CormenMatrix()
        {
            var matrix = new WeightedDiAdjacencyMatrix(6);
            matrix.AddEdge(1, 2, 16f);
            matrix.AddEdge(1, 3, 13f);

            matrix.AddEdge(2, 3, 10f);
            matrix.AddEdge(2, 4, 12f);

            matrix.AddEdge(3, 2, 4f);
            matrix.AddEdge(3, 5, 14f);

            matrix.AddEdge(4, 3, 9f);
            matrix.AddEdge(4, 6, 20f);

            matrix.AddEdge(5, 4, 7f);
            matrix.AddEdge(5, 6, 4f);

            return matrix;
        }
        //https://www.youtube.com/watch?v=Tl90tNtKvxs#t=291.549803
        private static WeightedDiAdjacencyMatrix YoutubeMatrix()
        {
            var matrix = new WeightedDiAdjacencyMatrix(6);
            matrix.AddEdge(1, 2, 10f);
            matrix.AddEdge(1, 4, 10f);

            matrix.AddEdge(2, 4, 2f);
            matrix.AddEdge(2, 5, 8f);
            matrix.AddEdge(2, 3, 4f);

            matrix.AddEdge(3, 6, 10f);

            matrix.AddEdge(4, 5, 9f);

            matrix.AddEdge(5, 3, 6f);
            matrix.AddEdge(5, 6, 10f);


            return matrix;
        }
    }
}
