using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphTheory.Lab3;
using GraphTheory.FordFulkerson;
namespace GraphTheory.MaximalMatching
{
    public class MaximalMatching
    {
        public bool IsGraphBipartite(WeightedDiAdjacencyMatrix graph, out List<int> redVerts, out List<int> blueVerts)
        {
            for (int i = 0; i < graph.Order; i++)
            {
                Console.Write("Neighbours[" + (i + 1) + "]\t");
                graph.Neighbours(i + 1).ForEach(_ => Console.Write(_+ " "));
                Console.WriteLine();
            }

            var blueVertices = new List<int>();
            var redVertices = new List<int>();
            var verticesQueue = new Queue<int>();
            redVerts = redVertices;
            blueVerts = blueVertices;

            for (int i = 0; i < graph.Order; i++)
            {
                if (blueVertices.Contains(i) || redVertices.Contains(i))
                    continue;

                redVertices.Add(i + 1);
                verticesQueue.Enqueue(i);

                while (verticesQueue.Count > 0)
                {
                    var vertex = verticesQueue.Dequeue();
                    var vertexLabel = vertex + 1;
                    var neighbours = graph.Neighbours(vertexLabel);
                    foreach (var item in neighbours)
                    {
                        if (redVertices.Contains(item) && redVertices.Contains(vertexLabel))
                            return false;

                        if (blueVertices.Contains(item) && blueVertices.Contains(vertexLabel))
                            return false;

                        if (blueVertices.Contains(item) || redVertices.Contains(item))
                            continue;

                        if (redVertices.Contains(vertexLabel))
                        {
                            blueVertices.Add(item);
                        }
                        else
                        {
                            redVertices.Add(item);
                        }

                        verticesQueue.Enqueue(item - 1);
                    }
                }

            }
            Console.Write("\nRed:\t");
            redVertices.ForEach(v => Console.Write((v) + " "));
            Console.WriteLine();
            Console.Write("Blue:\t");
            blueVertices.ForEach(v => Console.Write((v) + " "));
            Console.WriteLine();

            return true;
        }

        public void ComputeMaximalMatching(WeightedDiAdjacencyMatrix graph)
        {
            List<int> redVerticles = null;
            List<int> blueVerticles = null;
            if (!IsGraphBipartite(graph, out redVerticles, out blueVerticles))
            {
                Console.WriteLine("Graph is not Bipartite!");
                return;
            }

            WeightedDiAdjacencyMatrix diGraph = new WeightedDiAdjacencyMatrix(graph.Order + 2);

            int S = 1;
            int T = graph.Order + 2;

            for (int i = 1; i <= graph.Order; i++)
            {
                var neighbours = graph.Neighbours(i);
                foreach (var item in neighbours)
                {
                    if (blueVerticles.Contains(i))
                    {
                        diGraph.AddEdge(i+1, item+1, 1f);
                    }
                }
            }

            blueVerticles.ForEach(blue => diGraph.AddEdge(S, blue+1, 1f));
            redVerticles.ForEach(red => diGraph.AddEdge(red+1, T, 1f));

            Console.WriteLine("Residual network S=0; T="+(T-1));
            for (int i = 0; i < diGraph.Order; i++)
            {
                Console.Write("Neighbours[" + (i) + "]\t");
                diGraph.Neighbours(i + 1).ForEach(_ => Console.Write((_-1)+ " "));
                Console.WriteLine();
            }

            Console.WriteLine("To read result remove S-> and ->T. Then substract 1 from each middle N->N:");
            var edmondsKarp = new EdmondsKarp();
            edmondsKarp.MaximumFlow(diGraph, S-1, T-1);
        }
    }
}
