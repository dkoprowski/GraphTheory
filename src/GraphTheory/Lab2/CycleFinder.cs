using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphTheory.Lab1;

namespace GraphTheory.Lab2
{
    public class CycleFinder
    {
        public List<int> GetAnyCycle(AdjacencyMatrix graph)
        {
            if (graph.MinimalDegree >= 2)
            {
                RecursiveFindCycle(1, new int[graph.Order], new List<int>(), graph);
            }
            else
            {
                Console.WriteLine("Error! Graph's minimal degree should be at least equal 2");
                return null;
            }

            return null;
        }

        private List<int> RecursiveFindCycle(int vertex, int[] verticesVisitCount, List<int> path, AdjacencyMatrix graph)
        {
            path.Add(vertex);
            verticesVisitCount[vertex - 1] += 1;
            foreach (var item in verticesVisitCount)
            {
                if (item > 2)
                    return ExtractCycle(path, graph);
            }

            foreach (var item in graph.Neighbours(vertex))
            {
                if (path.Count < 2)
                    RecursiveFindCycle(item, verticesVisitCount, new List<int>(path), graph);
                else if (path[path.Count - 2] != item)
                    RecursiveFindCycle(item, verticesVisitCount, new List<int>(path), graph);
            }

            return null;
        }

        private List<int> ExtractCycle(List<int> path, AdjacencyMatrix graph)
        {
            int cycleVertex = path.Last();
            for (int i = path.Count-2; i >= 0; i--)
            {
                if(cycleVertex == path[i])
                {
                    var cycle = path.GetRange(i, path.Count - i);

                    if(cycle.Count > graph.Degree)
                    cycle.ForEach(_ => Console.Write(_ + ":"));
                    Console.WriteLine();
                    return path.GetRange(i, path.Count - i);
                }
            }

            return null;
        }
    }
}
