using System;
using System.Collections.Generic;
using System.Linq;

public class KruskalAlgorithm
{
    public static int Kruskal(int[][] graph)
    {
        List<(int Source, int Destination, int Weight)> edges = new List<(int, int, int)>();

        for (int i = 0; i < graph.Length; i++)
        {
            for (int j = i + 1; j < graph.Length; j++)
            {
                if (graph[i][j] != 0)
                {
                    edges.Add((i, j, graph[i][j]));
                }
            }
        }

        if (edges.Count == 0)
            return 0;

        var sortedEdges = edges.OrderBy(e => e.Weight).ToList();

        int[] componentLabels = new int[graph.Length];
        for (int i = 0; i < componentLabels.Length; i++)
            componentLabels[i] = i;

        int totalWeight = 0;
        List<(int, int)> resultEdges = new List<(int, int)>();


        foreach (var edge in sortedEdges)
        {
            int u = edge.Source;
            int v = edge.Destination;

            if (componentLabels[u] != componentLabels[v])
            {
                totalWeight += edge.Weight;
                resultEdges.Add((u, v));
                int oldLabel = componentLabels[u];
                int newLabel = componentLabels[v];

                for (int k = 0; k < componentLabels.Length; k++)
                {
                    if (componentLabels[k] == oldLabel)
                        componentLabels[k] = newLabel;
                }
            }
        }

        Console.WriteLine("Рёбра минимального остовного дерева:");
        foreach (var edge in resultEdges)
        {
            Console.WriteLine($"({edge.Item1}, {edge.Item2})");
        }

        return totalWeight;
    }

    public static void Main(string[] args)
    {
        int[][] graph = new int[][]
        {
            new int[] { 0, 7, 9, 0, 0, 14 },
            new int[] { 7, 0, 10, 15, 0, 0 },
            new int[] { 9, 10, 0, 11, 0, 2 },
            new int[] { 0, 15, 11, 0, 6, 0 },
            new int[] { 0, 0, 0, 6, 0, 9 },
            new int[] { 14, 0, 2, 0, 9, 0 }
        };

        int totalWeight = Kruskal(graph);
        Console.WriteLine($"Общий вес минимального остовного дерева: {totalWeight}");
    }
}













