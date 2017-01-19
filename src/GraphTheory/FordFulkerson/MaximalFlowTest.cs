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
            Console.WriteLine("\n----- No path graph -----");
            Console.WriteLine(edmondsKarp.MaximumFlow(NoPathMatrix(), 0, 4));

            Console.WriteLine("\n Simple graph: s --7--> v1 --100--> t");
            Console.WriteLine("Result: "+edmondsKarp.MaximumFlow(SimpleMatrix(), 0, 2));

            Console.WriteLine("\n----- Cormen graph -----");
            Console.WriteLine("Result: "+ edmondsKarp.MaximumFlow(CormenMatrix(), 0, 5));

            Console.WriteLine("\n----- Custom graph -----");
            Console.WriteLine("Result: "+ edmondsKarp.MaximumFlow(YoutubeMatrix(), 0, 5));


       //     Console.WriteLine("Result: "+ edmondsKarp.MaximumFlow(Testtest(), 6, 7));
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

        private static WeightedDiAdjacencyMatrix NoPathMatrix()
        {
            var matrix = new WeightedDiAdjacencyMatrix(5);
            matrix.AddEdge(1, 2, 5f);

            matrix.AddEdge(2, 3, 7f);

            matrix.AddEdge(3, 2, 2f);

            matrix.AddEdge(4, 5, 15f);

            return matrix;
        }

        private static WeightedDiAdjacencyMatrix SimpleMatrix()
        {
            var matrix = new WeightedDiAdjacencyMatrix(3);
            matrix.AddEdge(1, 2, 7f);

            matrix.AddEdge(2, 3, 100f);

            return matrix;
        }

        private static WeightedDiAdjacencyMatrix Testtest()
        {
            var matrix = new WeightedDiAdjacencyMatrix(8);

            matrix.AddEdge(7, 2, 1f);
            matrix.AddEdge(7, 4, 1f);
            matrix.AddEdge(7, 6, 1f);

            matrix.AddEdge(2, 1, 1f);
            matrix.AddEdge(2, 3, 1f);

            matrix.AddEdge(4, 3, 1f);
            matrix.AddEdge(4, 5, 1f);

            matrix.AddEdge(6, 1, 1f);
            matrix.AddEdge(6, 5, 1f);

            matrix.AddEdge(1, 8, 1f);
            matrix.AddEdge(3, 8, 1f);
            matrix.AddEdge(5, 8, 1f);

            return matrix;
        }
    }
}
