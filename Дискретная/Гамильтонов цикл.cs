using System;

public class Graph
{
    public int[,] Matrix;
    public int VertexCount;
    public int[] BestPath;
    public int BestCost = int.MaxValue;
    public bool[] Visited;

    public Graph(int[,] matrix)
    {
        if (matrix == null)
            throw new ArgumentNullException(nameof(matrix));
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new ArgumentException("Матрица должна быть квадратной");

        Matrix = matrix;
        VertexCount = matrix.GetLength(0);
        Visited = new bool[VertexCount];
        BestPath = new int[VertexCount + 1];
    }

    public void FindHamiltonianCycle(int level, int currentCost, int[] currentPath, int bound)
    {
        if (level == VertexCount)
        {
            ProcessCompletePath(currentPath, currentCost);
            return;
        }

        for (int vertex = 0; vertex < VertexCount; vertex++)
        {
            if (CanVisitVertex(currentPath[level - 1], vertex))
            {
                int newCost = currentCost + Matrix[currentPath[level - 1], vertex];
                int newBound = UpdateBound(level, currentPath[level - 1], vertex, bound);

                if (IsPromisingPath(newCost, newBound))
                {
                    currentPath[level] = vertex;
                    Visited[vertex] = true;

                    FindHamiltonianCycle(level + 1, newCost, currentPath, newBound);

                    Visited[vertex] = false;
                }
            }
        }
    }

    private bool CanVisitVertex(int fromVertex, int toVertex)
    {
        return Matrix[fromVertex, toVertex] != 0 && !Visited[toVertex];
    }

    private void ProcessCompletePath(int[] path, int cost)
    {
        int returnCost = Matrix[path[VertexCount - 1], path[0]];
        if (returnCost != 0)
        {
            int totalCost = cost + returnCost;
            if (totalCost < BestCost)
            {
                Array.Copy(path, BestPath, VertexCount);
                BestPath[VertexCount] = path[0];
                BestCost = totalCost;
            }
        }
    }

    private int UpdateBound(int level, int currentVertex, int nextVertex, int currentBound)
    {
        return level == 1
            ? currentBound - (MinEdgeCost(currentVertex) + MinEdgeCost(nextVertex)) / 2
            : currentBound - MinEdgeCost(currentVertex) / 2;
    }

    private bool IsPromisingPath(int cost, int bound)
    {
        return cost + bound < BestCost;
    }

    private int MinEdgeCost(int vertex)
    {
        int min = int.MaxValue;
        for (int i = 0; i < VertexCount; i++)
        {
            if (Matrix[vertex, i] != 0 && Matrix[vertex, i] < min)
            {
                min = Matrix[vertex, i];
            }
        }
        return min;
    }

    public int CalculateInitialBound()
    {
        int bound = 0;
        for (int i = 0; i < VertexCount; i++)
        {
            bound += MinEdgeCost(i);
        }
        return bound == 0 ? 0 : bound / 2;
    }
}

public class Program
{
    public static void Main()
    {
        int[,] graph = {
            {0, 15, 15, 20},
            {10, 0, 88, 29},
            {9, 35, 0, 44},
            {27, 29, 32, 0}
        };

        try
        {
            Graph solver = new Graph(graph);

            int[] currentPath = new int[solver.VertexCount + 1];
            currentPath[0] = 0;
            solver.Visited[0] = true;
            int initialBound = solver.CalculateInitialBound();

            solver.FindHamiltonianCycle(1, 0, currentPath, initialBound);

            if (solver.BestCost != int.MaxValue)
            {
                Console.WriteLine("Найден гамильтонов цикл:");
                Console.WriteLine("Маршрут: " + string.Join(" → ", solver.BestPath));
                Console.WriteLine("Суммарный вес: " + solver.BestCost);
            }
            else
            {
                Console.WriteLine("Гамильтонов цикл не найден");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}













