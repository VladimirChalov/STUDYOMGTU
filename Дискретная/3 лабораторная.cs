using System;
namespace Omgtu
{
    class Program
    {
        static void Main()
        {
            int[,] graph = new int[,]
            {
                {0, 1, 0, 0, 0},
                {1, 0, 1, 1, 0},
                {0, 1, 0, 0, 0},
                {0, 0, 1, 0, 1},
                {0, 1, 0, 1, 0}
            };

            int V = graph.GetLength(0);
            int time = 0;

            bool[] visited = new bool[V];
            int[] disc = new int[V];
            int[] low = new int[V];
            int[] pt = new int[V];

            for (int i = 0; i < V; i++)
            {
                pt[i] = -1;
                visited[i] = false;
                disc[i] = -1;
                low[i] = -1;
            }

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    int usel = 0;
                    visited[i] = true;
                    disc[i] = low[i] = time++;

                    for (int u = 0; u < V; u++)
                    {
                        if (graph[i, u] == 1)
                        {
                            if (!visited[u])
                            {
                                pt[u] = i;
                                usel++;

                                visited[u] = true;
                                disc[u] = low[u] = time++;

                                for (int v = 0; v < V; v++)
                                {
                                    if (graph[u, v] == 1)
                                    {
                                        if (!visited[v]) 
                                        {
                                            pt[v] = u;
                                            continue;
                                        }
                                        else if (v != pt[u])
                                        {
                                            low[u] = Math.Min(low[u], disc[v]);
                                        }
                                    }
                                }

                                low[i] = Math.Min(low[i], low[u]);

                                if ((pt[i] == -1 && usel > 1) || (pt[i] != -1 && low[u] >= disc[i]))
                                {
                                    Console.WriteLine($"Мост: ({i}, {u})");
                                }
                            }
                            else if (u != pt[i])
                            {
                                low[i] = Math.Min(low[i], disc[u]);
                            }
                        }
                    }
                }
            }
        }
    }
}

