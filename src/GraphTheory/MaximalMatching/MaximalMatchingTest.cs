using GraphTheory.Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory.MaximalMatching
{
    public class MaximalMatchingTest
    {
        public static void Run()
        {
            var maximalMatching = new MaximalMatching();

            Console.WriteLine("\n ");
            maximalMatching.ComputeMaximalMatching(CormenMatrix());
            Console.WriteLine("---------------------------------------------");
            maximalMatching.ComputeMaximalMatching(Cycled5Matrix());
            Console.WriteLine("---------------------------------------------");
            maximalMatching.ComputeMaximalMatching(Cycled6Matrix());
            Console.WriteLine("---------------------------------------------");

        }

        private static WeightedDiAdjacencyMatrix CormenMatrix()
        {
            var matrix = new WeightedDiAdjacencyMatrix(6);
            matrix.AddDuplexEdge(1, 4, 1f);

            matrix.AddDuplexEdge(2, 4, 1f);

            matrix.AddDuplexEdge(3, 5, 1f);

            matrix.AddDuplexEdge(5, 2, 1f);

            matrix.AddDuplexEdge(6, 2, 1f);


            return matrix;
        }

        private static WeightedDiAdjacencyMatrix Cycled6Matrix()
        {
            var matrix = new WeightedDiAdjacencyMatrix(6);
            matrix.AddDuplexEdge(1, 2, 1f);

            matrix.AddDuplexEdge(2, 3, 1f);

            matrix.AddDuplexEdge(3, 4, 1f);

            matrix.AddDuplexEdge(4, 5, 1f);

            matrix.AddDuplexEdge(5, 6, 1f);

            matrix.AddDuplexEdge(6, 1, 1f);


            return matrix;
        }

        private static WeightedDiAdjacencyMatrix Cycled5Matrix()
        {
            var matrix = new WeightedDiAdjacencyMatrix(5);
            matrix.AddDuplexEdge(1, 2, 1f);

            matrix.AddDuplexEdge(2, 3, 1f);

            matrix.AddDuplexEdge(3, 4, 1f);

            matrix.AddDuplexEdge(4, 5, 1f);

            matrix.AddDuplexEdge(5, 1, 1f);

            return matrix;
        }
    }
}
