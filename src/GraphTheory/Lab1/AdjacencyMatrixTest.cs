using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory.Lab1
{
    class AdjacencyMatrixTest
    {
        public static void Run()
        {
            {

                var graph = new Lab1.AdjacencyMatrix(7);

                graph.AddEdge(1, 5);
                graph.AddEdge(1, 2);
                graph.AddEdge(2, 3);
                graph.AddEdge(2, 5);
                graph.AddEdge(3, 4);
                graph.AddEdge(4, 5);

                graph.PrintAdjacency();
                Console.WriteLine();
                Console.WriteLine("VertexDegree(1) = " + graph.VertexDegree(1));
                Console.WriteLine("VertexDegree(3) = " + graph.VertexDegree(3));
                Console.WriteLine("VertexDegree(5) = " + graph.VertexDegree(5));
                Console.WriteLine("minimal deg: " + graph.MinimalDegree);
                Console.WriteLine("maximal deg: " + graph.MaximalDegree);

                for (int i = 1; i <= graph.Order; i++)
                {
                    Console.Write("Neighbours [" + i + "]: ");
                    graph.Neighbours(i).ForEach(_ => Console.Write(_ + "; "));
                    Console.WriteLine();
                }
                graph.PrintVerticesDegrees();
                graph.PrintIsEulerian();

                Console.WriteLine("\nRemoving 1-5 edge");
                graph.RemoveEdge(1, 5);
                graph.PrintAdjacency();


                Console.WriteLine("\nRemoving 5 vertex");
                graph.RemoveVertex(5);
                graph.PrintAdjacency();

                Console.ReadKey();

            }
        }
    }
}
