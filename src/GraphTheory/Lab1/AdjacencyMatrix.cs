using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GraphTheory.Lab1
{
    public class AdjacencyMatrix
    {
        public int Degree
        {
            get
            {
                int degree = VertexDegree(1);
                for (int i = 1; i <= matrix.Count; i++)
                {
                    if (degree < VertexDegree(i))
                        degree = VertexDegree(i);
                }
                return degree;
            }
        }
        public int MinimalDegree
        {
            get
            {
                int minimalDegree = VertexDegree(1);
                for (int i = 1; i <= matrix.Count; i++)
                {
                    if (minimalDegree > VertexDegree(i))
                        minimalDegree = VertexDegree(i);
                }
                return minimalDegree;
            }
        }
        public int MaximalDegree
        {
            get
            {
                int maximalDegree = VertexDegree(1);
                for (int i = 1; i <= matrix.Count; i++)
                {
                    if (maximalDegree < VertexDegree(i))
                        maximalDegree = VertexDegree(i);
                }
                return maximalDegree;
            }
        }
        /// <summary>
        /// Number of verticles in graph
        /// </summary>
        public int Order { get { return matrix.Count; } }

        protected List<List<int>> matrix;

        public AdjacencyMatrix()
        {
            matrix = new List<List<int>>();
        }

        public AdjacencyMatrix(int verticleCount)
        {
            matrix = new List<List<int>>();
            for (int i = 0; i < verticleCount; i++)
            {
                AddVertex();
            }
        }

        public void PrintAdjacency()
        {
            Console.WriteLine("Adjacency Matrix:");

            foreach (var item in matrix)
            {
                foreach (var field in item)
                {
                    Console.Write(field + " ");
                }
                Console.WriteLine();
            }
        }

        public virtual int AddVertex()
        {
            matrix.Add(Enumerable.Repeat(0, matrix.Count).ToList());
            foreach (var item in matrix)
            {
                item.Add(0);
            }

            return matrix.Count;
        }

        public void RemoveVertex(int vertex)
        {
            vertex -= 1;
            matrix.Remove(matrix[vertex]);
            foreach (var item in matrix)
            {
                item.RemoveAt(vertex);
            }
        }

        public void AddEdge(int vertexA, int vertexB)
        {
            vertexA -= 1;
            vertexB -= 1;
            int val = 1;
            if (vertexA == vertexB)
                val = 2;
            matrix[vertexA][vertexB] = matrix[vertexB][vertexA] += val;
        }

        public void RemoveEdge(int vertexA, int vertexB)
        {
            vertexA -= 1;
            vertexB -= 1;
            int val = 1;
            if (vertexA == vertexB)
                val = 2;

            if (matrix[vertexA][vertexB] <= 0)
            {
                Console.WriteLine("There is no such edge [" + (vertexA + 1) + ";" + (vertexB + 1) + "]");
                return;
            }
            matrix[vertexA][vertexB] = matrix[vertexB][vertexA] -= val;
        }

        public int VertexDegree(int vertex)
        {
            return matrix[vertex - 1].Sum();
        }

        public bool IsEdge(int vertexA, int vertexB)
        {
            return matrix[vertexA][vertexB] > 0;
        }
        public void PrintVerticesDegrees()
        {
            var odd = OddVerticles();
            Console.WriteLine("\nOdd==" + odd.Count + "; Even==" + (Order - odd.Count));
        }

        private Dictionary<int, int> OddVerticles()
        {
            var degrees = new Dictionary<int, int>();
            for (int i = 1; i <= matrix.Count; i++)
            {
                degrees.Add(i, VertexDegree(i));
            }

            var items = from pair in degrees
                        orderby pair.Value descending
                        select pair;

            var odd = new Dictionary<int, int>();

           // int oddCount = 0;
            foreach (var item in items)
            {
                if (item.Value % 2 != 0)
                    odd.Add(item.Key, item.Value);                
            }

            return odd;
        }
        public List<int> Neighbours(int vertex)
        {
            var neighbours = new List<int>();

            for (int i = 0; i < matrix[vertex - 1].Count; i++)
            {
                if (matrix[vertex - 1][i] > 0)
                    neighbours.Add(i + 1);
            }
            return neighbours;
        }

        private bool IsConnected()
        {
            bool[] visited = new bool[Order];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            DFSUtil(0, visited);

            foreach (var item in visited)
            {
                if (!item)
                    return false;
            }
            return true;
        }

        private int IsEulerian()
        {
            // Check if all non-zero degree vertices are connected
            if (!IsConnected())
                return 0;

            // Count vertices with odd degree
            int odd = OddVerticles().Count;

            // If count is more than 2, then graph is not Eulerian
            if (odd > 2)
                return 0;

            // If odd count is 2, then semi-eulerian.
            // If odd count is 0, then eulerian
            // Note that odd count can never be 1 for undirected graph
            return (odd == 2) ? 1 : 2;
        }

        public void PrintIsEulerian()
        {
            var eulerian = IsEulerian();
            switch (eulerian)
            {
                case 1:
                    Console.WriteLine("Graph is Semi-Eulerian (has an Eulerian path)");
                    break;
                case 2:
                    Console.WriteLine("Graph is Eulerian (has an Eulerian circut)");
                    break;
                default: Console.WriteLine("Graph non eulerian");
                    break;
            }
        }

        private void DFSUtil(int vert, bool[] visited)
        {
            visited[vert] = true;

            var neighbours = Neighbours(vert + 1);
            foreach (var item in neighbours)
            {
                if (!visited[item - 1])
                    DFSUtil(item - 1, visited);
            }
        }
    }
}
