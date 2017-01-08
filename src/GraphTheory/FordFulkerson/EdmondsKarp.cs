using GraphTheory.Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphTheory.FordFulkerson
{
    //Implemented with pseudocode: http://eduinf.waw.pl/inf/alg/001_search/0146.php#P2
    public class EdmondsKarp
    {
        public float? MaximumFlow(WeightedDiAdjacencyMatrix graph, int s, int t)
        {
            bool noPath = false;
            float fMax = 0f;
            var nettoMatrix = new WeightedDiAdjacencyMatrix(graph.Order);
            var predecesors = new int[graph.Order];
            var cfp = new float[graph.Order];
            Queue<int> bfsVertex = new Queue<int>();
            int iteration = 0;
            while (true)
            {
                for (int i = 0; i < predecesors.Length; i++)
                {
                    predecesors[i] = -1;
                }
                predecesors[s] = -2;
                cfp[s] = float.PositiveInfinity;
                while (bfsVertex.Count > 0)
                {
                    bfsVertex.Dequeue();
                }
                bfsVertex.Enqueue(s);
                Console.WriteLine("\n> iteration "+iteration);
                while (bfsVertex.Count > 0)
                {
                    noPath = true;
                    bool breakWhile = false;
                    var x = bfsVertex.Dequeue();
                    foreach (var y in graph.Neighbours(x + 1))
                    {
                        var nettoValue = 0f;
                        if(nettoMatrix.IsEdgeByLabels(x+1,y))
                            nettoValue = nettoMatrix.GetEdgeByLabels(x + 1, y).Weight;

                        var residualCapacity = graph.GetEdgeByLabels(x + 1, y).Weight - nettoValue;

                        /*
                         * Jezeli wierzcholek byl odwiedzony lub jego przepustowosc rezydualna wynosi 0
                         * to nie obliczamy dla niego CFP 
                         */
                        if (residualCapacity == 0f || predecesors[y - 1] != -1)
                            continue;

                        predecesors[y - 1] = x;
                        cfp[y - 1] = Math.Min(cfp[x], residualCapacity);

                        if ((y - 1) == t)
                        {
                            ShowPath(predecesors, t);
                            noPath = false;
                            breakWhile = true;
                            break;
                        }
                        bfsVertex.Enqueue(y - 1);
                    }
                    if (breakWhile)
                        break;
                }
                if (noPath)
                {
                    if (iteration == 0)
                    {
                        Console.WriteLine("ERROR: NO PATH");
                        return null;
                    }

                    return fMax;
                }

                fMax += cfp[t];

                var ny = t;
                Console.WriteLine("Operating with "+ cfp[t]);
                while (ny != s)
                {
                    var x = predecesors[ny];

                    if (!nettoMatrix.IsEdgeByLabels(x + 1, ny + 1))
                        nettoMatrix.AddEdge(x + 1, ny + 1, 0f);
                    nettoMatrix.GetEdgeByLabels(x + 1, ny + 1).Weight += cfp[t];

                    if (!nettoMatrix.IsEdgeByLabels(ny + 1, x + 1))
                        nettoMatrix.AddEdge(ny + 1, x + 1, 0f);

                    nettoMatrix.GetEdgeByLabels(ny + 1, x + 1).Weight -= cfp[t];

                    Console.WriteLine("nettoValue(" + (x + 1) + "," + (ny + 1) + ") == " + nettoMatrix.GetEdgeByLabels(x + 1, ny + 1).Weight);
                   // Console.WriteLine("nettoValue(" + (ny + 1) + "," + (x + 1) + ") == " + nettoMatrix.GetEdgeByLabels(ny + 1, x + 1).Weight);
                   // Console.WriteLine("~~");

                    ny = x;
                }
                iteration++;
            }
            return fMax;
        }

        private void ShowPath(int[] predecesors, int pathFrom)
        {
            var path = new Stack<int>();
            path.Push(pathFrom);
            while(path.Peek() != 0)
            {
                path.Push(predecesors[path.Peek()]);
            }

            while (path.Count > 0)
            {
                if (path.Count == 1)
                    Console.WriteLine(" " + (path.Pop()+1));
                else
                    Console.Write((path.Pop()+1) + " -> ");
            }
            Console.WriteLine();

        }
    }
}
