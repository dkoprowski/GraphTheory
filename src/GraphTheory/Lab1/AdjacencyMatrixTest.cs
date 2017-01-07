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

                var graph = new Lab1.AdjacencyMatrix(5);

                graph.AddEdge(1, 5);
                graph.AddEdge(1, 2);
                graph.AddEdge(2, 3);
                graph.AddEdge(2, 5);
                graph.AddEdge(3, 4);
                graph.AddEdge(4, 5);


                graph.PrintAdjacency();
                Console.WriteLine();
                Console.WriteLine(graph.VertexDegree(1));
                Console.WriteLine(graph.VertexDegree(3));
                Console.WriteLine(graph.VertexDegree(5));
                Console.WriteLine("minimal deg: " + graph.MinimalDegree);

                for (int i = 1; i <= graph.Order; i++)
                {
                    Console.Write("Neighbours [" + i + "]: ");
                    graph.Neighbours(i).ForEach(_ => Console.Write(_ + "; "));
                    Console.WriteLine();
                }
                graph.PrintVerticesDegrees();
                Console.ReadKey();

            }
        }
    }
}
