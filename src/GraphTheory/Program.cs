using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var graph = new Lab1.AdjacencyMatrix(6);
            
            graph.AddEdge(1, 1);
            graph.AddEdge(1, 5);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);
            graph.AddEdge(4, 6);

            graph.PrintAdjacency();
            Console.WriteLine();
            Console.WriteLine(graph.VertexDegree(1));
            Console.WriteLine(graph.VertexDegree(3));
            Console.WriteLine(graph.VertexDegree(5));

            graph.PrintVerticesDegrees();
            Console.ReadKey();
        }
    }
}
