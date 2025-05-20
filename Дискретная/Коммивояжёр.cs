using System;
using System.Collections.Generic;

public class LittleAlgorithm
{
    private readonly int[,] _initialCostMatrix;
    private readonly int _matrixSize;
    private List<int> _optimalRoute;
    private int _minimalCost = int.MaxValue;

    public LittleAlgorithm(int[,] costMatrix)
    {
        _initialCostMatrix = (int[,])costMatrix.Clone();
        _matrixSize = costMatrix.GetLength(0);
    }

    public (List<int> route, int cost) FindOptimalRoute()
    {
        _optimalRoute = new List<int>();
        var currentRoute = new List<int> { 0 };

        var processingMatrix = (int[,])_initialCostMatrix.Clone();
        int initialReductionCost = ReduceCostMatrix(processingMatrix);

        ExploreRightBranch(processingMatrix, currentRoute, initialReductionCost);

        if (_optimalRoute.Count > 0)
        {
            _optimalRoute.Add(_optimalRoute[0]);
        }

        return (_optimalRoute, _minimalCost);
    }

    private void ExploreRightBranch(int[,] currentMatrix, List<int> currentRoute, int accumulatedCost)
    {
        if (currentRoute.Count == _matrixSize)
        {
            int returnCost = currentMatrix[currentRoute[^1], currentRoute[0]];
            if (returnCost != int.MaxValue)
            {
                int totalCost = accumulatedCost + returnCost;
                if (totalCost < _minimalCost)
                {
                    _minimalCost = totalCost;
                    _optimalRoute = new List<int>(currentRoute);
                }
            }
            return;
        }

        var reducedCostMatrix = (int[,])currentMatrix.Clone();
        int reductionValue = ReduceCostMatrix(reducedCostMatrix);
        int costLowerBound = accumulatedCost + reductionValue;

        if (costLowerBound >= _minimalCost) return;

        int lastNode = currentRoute[^1];
        for (int nextNode = 0; nextNode < _matrixSize; nextNode++)
        {
            if (reducedCostMatrix[lastNode, nextNode] != int.MaxValue && !currentRoute.Contains(nextNode))
            {
                var updatedMatrix = (int[,])reducedCostMatrix.Clone();
                updatedMatrix[nextNode, lastNode] = int.MaxValue;

                for (int k = 0; k < _matrixSize; k++)
                {
                    if (k != nextNode) updatedMatrix[lastNode, k] = int.MaxValue;
                }

                var newRoute = new List<int>(currentRoute) { nextNode };
                ExploreRightBranch(updatedMatrix, newRoute, accumulatedCost + reductionValue + currentMatrix[lastNode, nextNode]);
            }
        }
    }

    private int ReduceCostMatrix(int[,] matrix)
    {
        int totalReduction = 0;

        for (int i = 0; i < _matrixSize; i++)
        {
            if (IsRowRedundant(matrix, i)) continue;

            int minValue = int.MaxValue;
            for (int j = 0; j < _matrixSize; j++)
                if (matrix[i, j] < minValue) minValue = matrix[i, j];

            if (minValue != int.MaxValue && minValue != 0)
            {
                totalReduction += minValue;
                for (int j = 0; j < _matrixSize; j++)
                    if (matrix[i, j] != int.MaxValue) matrix[i, j] -= minValue;
            }
        }

        for (int j = 0; j < _matrixSize; j++)
        {
            if (IsColumnRedundant(matrix, j)) continue;

            int minValue = int.MaxValue;
            for (int i = 0; i < _matrixSize; i++)
                if (matrix[i, j] < minValue) minValue = matrix[i, j];

            if (minValue != int.MaxValue && minValue != 0)
            {
                totalReduction += minValue;
                for (int i = 0; i < _matrixSize; i++)
                    if (matrix[i, j] != int.MaxValue) matrix[i, j] -= minValue;
            }
        }

        return totalReduction;
    }

    private bool IsRowRedundant(int[,] matrix, int row)
    {
        for (int j = 0; j < _matrixSize; j++)
            if (matrix[row, j] != int.MaxValue) return false;
        return true;
    }

    private bool IsColumnRedundant(int[,] matrix, int col)
    {
        for (int i = 0; i < _matrixSize; i++)
            if (matrix[i, col] != int.MaxValue) return false;
        return true;
    }
}

public class Program
{
    public static void DisplayCostMatrix(int[,] matrix, int infinitySymbol)
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                Console.Write(matrix[i, j] == int.MaxValue ? "INF " : $"{matrix[i, j]} ");
            Console.WriteLine();
        }
    }

    public static void Main()
    {
        const int INF = 999;
        Console.WriteLine("Укажите размер матрицы стоимости:");
        int matrixSize = Convert.ToInt32(Console.ReadLine());
        int[,] costMatrix = new int[matrixSize, matrixSize];

        Console.WriteLine("При вводе используйте 999 для обозначения бесконечно высокой стоимости (отсутствие пути)");

        for (int i = 0; i < matrixSize; i++)
        {
            Console.WriteLine($"Введите значения стоимости для строки {i + 1}:");
            for (int j = 0; j < matrixSize; j++)
            {
                int value = Convert.ToInt32(Console.ReadLine());
                costMatrix[i, j] = value == INF ? int.MaxValue : value;
            }
        }

        DisplayCostMatrix(costMatrix, INF);
        var solution = new LittleAlgorithm(costMatrix);
        var (route, cost) = solution.FindOptimalRoute();

        Console.WriteLine("Оптимальный маршрут: " + string.Join(" → ", route));
        Console.WriteLine("Минимальная стоимость: " + cost);
    }
}











