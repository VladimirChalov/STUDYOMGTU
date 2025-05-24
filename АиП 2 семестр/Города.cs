using System;
using System.Linq;

class GraphDiameterCalculator
{
    static void Main()
    {
        Console.WriteLine("Введите количество городов и дорог (N M):");
        var input = Console.ReadLine().Split();
        int cityCount = int.Parse(input[0]);
        int roadCount = int.Parse(input[1]);

        int[,] pathLengths = InitializePathMatrix(cityCount);

        Console.WriteLine($"Введите {roadCount} дорог (I J L):");
        for (int i = 0; i < roadCount; i++)
        {
            var roadData = Console.ReadLine().Split();
            int cityA = int.Parse(roadData[0]) - 1;
            int cityB = int.Parse(roadData[1]) - 1;
            int length = int.Parse(roadData[2]);

            pathLengths[cityA, cityB] = length;
            pathLengths[cityB, cityA] = length;
        }

        ComputeAllPairsShortestPaths(ref pathLengths, cityCount);

        int maxDistance = FindGraphDiameter(pathLengths, cityCount);
        Console.WriteLine($"Наибольшее расстояние между городами: {maxDistance}");
    }

    static int[,] InitializePathMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = i == j ? 0 : int.MaxValue / 3;
            }
        }
        return matrix;
    }

    static void ComputeAllPairsShortestPaths(ref int[,] distances, int size)
    {
        for (int k = 0; k < size; k++)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (distances[i, k] + distances[k, j] < distances[i, j])
                    {
                        distances[i, j] = distances[i, k] + distances[k, j];
                    }
                }
            }
        }
    }

    static int FindGraphDiameter(int[,] distances, int size)
    {
        int maxDistance = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (distances[i, j] > maxDistance)
                {
                    maxDistance = distances[i, j];
                }
            }
        }
        return maxDistance;
    }
}