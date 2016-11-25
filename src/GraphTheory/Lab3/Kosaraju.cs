using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/* Materialy:
 * http://www.geeksforgeeks.org/strongly-connected-components/
 */
namespace GraphTheory.Lab3
{


    public class Kosaraju
    {
        public void PrintSCCs(WeightedDiAdjacencyMatrix matrix)
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[matrix.Order];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            for (int i = 0; i < matrix.Order; i++)
                if (visited[i] == false)
                    FillOrder(i, visited, stack, matrix);

            var transposed = matrix.Transpose();
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;


            while(stack.Count > 0)
            {
                int vert = stack.Pop();

                // Print Strongly connected component of the popped vertex
                if (visited[vert] == false)
                {
                    DFSUtil(vert, visited, transposed);
                    Console.WriteLine();
                }
            }

        }
        private void FillOrder(int v, bool[] visited, Stack<int> stack, WeightedDiAdjacencyMatrix matrix)
        {
            // Mark the current node as visited and print it
            visited[v] = true;

            // Recur for all the vertices adjacent to this vertex
            var neighbours = matrix.Neighbours(v + 1);
            foreach (var item in neighbours)
            {
                if (!visited[item - 1])
                    FillOrder(item - 1, visited, stack, matrix);
            }

            // All vertices reachable from v are processed by now,
            // push v to Stack
               stack.Push(v);
        }

        private void DFSUtil(int vert, bool[] visited, WeightedDiAdjacencyMatrix matrix)
        {
            visited[vert] = true;
            Console.Write(vert + " ");

            var neighbours = matrix.Neighbours(vert + 1);
            foreach (var item in neighbours)
            {
                if (!visited[item - 1])
                    DFSUtil(item - 1, visited, matrix);
            }
        }
    }
}
