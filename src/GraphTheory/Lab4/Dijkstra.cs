using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphTheory.Lab3;


namespace GraphTheory.Lab4
{
    public class Dijkstra
    {
        public float[] RunDijkstraAlg(WeightedDiAdjacencyMatrix graph, int vertex)
        {
            vertex -= 1;
            var shortestPathsMatrix = new float[graph.Order];
            shortestPathsMatrix[vertex] = 0f;
            var neighbours = graph.Neighbours(vertex+1);
            var verticleToCheck = new List<int>();
            for (int i = 1; i <= graph.Order; i++)
            {
                if (i == vertex+1)
                    continue;

                verticleToCheck.Add(i-1);

                if (neighbours.Contains(i))
                    shortestPathsMatrix[i-1] = graph.GetEdge(vertex, i-1).Weight;
                else
                    shortestPathsMatrix[i-1] = float.PositiveInfinity;
            }

            Console.WriteLine("Dijkstra:");
            PrintValues(shortestPathsMatrix);

            while (verticleToCheck.Count > 0)
            {
                var minIndex = IndexOfMinElement(shortestPathsMatrix, verticleToCheck);
                verticleToCheck.Remove(minIndex);

                foreach (var item in verticleToCheck)
                {
                    shortestPathsMatrix[item] = Math.Min(shortestPathsMatrix[item], shortestPathsMatrix[minIndex] + Weight(minIndex, item, graph));
                }
                PrintValues(shortestPathsMatrix);
            }

            return shortestPathsMatrix;
        }

        private int IndexOfMinElement(float [] array, List<int> verticles)
        {
            int minIndex = verticles[0];
            for (int i = 0; i < verticles.Count; i++)
            {
                if (array[verticles[i]] < array[minIndex])
                    minIndex = verticles[i];
            }

            return minIndex;
        }

        private float Weight(int vertexA, int vertexB, WeightedDiAdjacencyMatrix graph)
        {
            var edge = graph.GetEdge(vertexA, vertexB);
            if (edge == null)
                return float.PositiveInfinity;
            else
                return edge.Weight;
        }

        private void PrintValues(float[] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if(float.IsInfinity(matrix[i]))
                    Console.Write("~ ");
                else
                    Console.Write(matrix[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
