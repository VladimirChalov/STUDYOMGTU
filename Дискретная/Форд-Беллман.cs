using System;
using System.Collections.Generic;

namespace Omgtu
{

    class Graph
    {
        public int V;
        public List<Edge> edges;

        public Graph(int vertices)
        {
            V = vertices;
            edges = new List<Edge>();
        }

        public void AddEdge(int u, int v, int w)
        {
            edges.Add(new Edge(u, v, w));
        }

        public void Ford_Bellman(int src)
        {
            int[] dist = new int[V];
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[src] = 0;

            for (int i = 1; i <= V - 1; i++)
            {
                foreach (var edge in edges)
                {
                    if (dist[edge.Source] != int.MaxValue && dist[edge.Source] + edge.Weight < dist[edge.Destination])
                    {
                        dist[edge.Destination] = dist[edge.Source] + edge.Weight;
                    }
                }
            }

            foreach (var edge in edges)
            {
                if (dist[edge.Source] != int.MaxValue && dist[edge.Source] + edge.Weight < dist[edge.Destination])
                {
                    Console.WriteLine("Граф содержит отрицательный цикл");
                    return;
                }
            }

            PrintDistances(dist);
        }

        public void PrintDistances(int[] dist)
        {
            Console.WriteLine("Расстояние от вершины до источника:");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine($"{i}\t\t{dist[i]}");
            }
        }

        public class Edge
        {
            public int Source { get; }
            public int Destination { get; }
            public int Weight { get; }

            public Edge(int source, int destination, int weight)
            {
                Source = source;
                Destination = destination;
                Weight = weight;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(5);
            g.AddEdge(0, 1, -1);
            g.AddEdge(0, 2, 4);
            g.AddEdge(1, 2, 3);
            g.AddEdge(1, 3, 2);
            g.AddEdge(1, 4, 2);
            g.AddEdge(3, 2, 5);
            g.AddEdge(3, 1, 1);
            g.AddEdge(4, 3, -3);

            g.Ford_Bellman(0);

            Console.WriteLine("\nСписок рёбер графа:");
            foreach (var edge in g.edges)
            {
                Console.WriteLine($"({edge.Source} -> {edge.Destination}, вес: {edge.Weight})");
            }
        }
    }
}
