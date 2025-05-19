
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static (int[,] ProcessedMatrix, int UpdatedCost) ProcessMatrix(int[,] matrix, int cost)
    {
        int minSum = 0;
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        int[,] processedRows = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            int minValue = matrix[i, 0];
            for (int j = 1; j < columns; j++)
            {
                if (matrix[i, j] < minValue && matrix[i, j] != int.MaxValue)
                {
                    minValue = matrix[i, j];
                }
            }

            if (minValue < int.MaxValue && minValue > 0)
            {
                minSum += minValue;
                Console.WriteLine($"Строка: {minValue}");
                for (int j = 0; j < columns; j++)
                {
                    processedRows[i, j] = matrix[i, j] != int.MaxValue ? matrix[i, j] - minValue : int.MaxValue;
                }
            }
            else
            {
                for (int j = 0; j < columns; j++)
                {
                    processedRows[i, j] = matrix[i, j];
                }
            }
        }

        int[,] processedColumns = new int[rows, columns];

        for (int j = 0; j < columns; j++)
        {
            int minValue = processedRows[0, j];
            for (int i = 1; i < rows; i++)
            {
                if (processedRows[i, j] < minValue && processedRows[i, j] != int.MaxValue)
                {
                    minValue = processedRows[i, j];
                }
            }

            if (minValue < int.MaxValue && minValue > 0)
            {
                minSum += minValue;
                for (int i = 0; i < rows; i++)
                {
                    processedColumns[i, j] = processedRows[i, j] != int.MaxValue ? processedRows[i, j] - minValue : int.MaxValue;
                }
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    processedColumns[i, j] = processedRows[i, j];
                }
            }
        }

        Console.WriteLine(minSum);
        PrintMatrix(processedColumns);
        return (processedColumns, cost + minSum);
    }

    static (int Row, int Column, int Cost) FindMaxZeroEdge(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        (int Row, int Column, int Cost) edge = (0, 0, -1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] == 0)
                {
                    int rowCost = int.MaxValue;
                    for (int colIndex = 0; colIndex < columns; colIndex++)
                    {
                        if (colIndex != j && matrix[i, colIndex] < rowCost)
                        {
                            rowCost = matrix[i, colIndex];
                        }
                    }

                    int columnCost = int.MaxValue;
                    for (int rowIndex = 0; rowIndex < rows; rowIndex++)
                    {
                        if (rowIndex != i && matrix[rowIndex, j] < columnCost)
                        {
                            columnCost = matrix[rowIndex, j];
                        }
                    }

                    int crossCost = rowCost + columnCost;
                    Console.WriteLine($"Текущий 0: ({i}, {j}) - {crossCost}");
                    if (crossCost > edge.Cost)
                    {
                        edge = (i, j, crossCost);
                    }
                }
            }
        }
        return edge;
    }

    static (List<int> Path, int Cost) SolveTSP(int[,] matrix, List<int> path, int cost)
    {
        int n = matrix.GetLength(0);

        if (path.Count == n - 1)
        {
            int start = path[0];
            int end = path[path.Count - 1];
            if (matrix[end, start] != int.MaxValue)
            {
                return (path, cost + matrix[end, start]);
            }
            return (new List<int>(), int.MaxValue);
        }

        var (newMatrix, newCost) = ProcessMatrix(matrix, cost);
        var edge = FindMaxZeroEdge(newMatrix);
        Console.WriteLine($"Выбранный 0: ({edge.Row}, {edge.Column}) - {edge.Cost}");

        if (edge.Row == -1 || edge.Column == -1)
        {
            return (path, cost);
        }

        int[,] updatedMatrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                updatedMatrix[i, j] = (j == edge.Column) ? int.MaxValue : newMatrix[i, j];
            }
        }

        for (int i = 0; i < n; i++)
        {
            updatedMatrix[i, edge.Column] = int.MaxValue;
            updatedMatrix[edge.Row, i] = int.MaxValue;
        }

        Console.WriteLine($"Стоимость: {newCost}");
        var newPath = new List<int>(path) { edge.Column };
        return SolveTSP(updatedMatrix, newPath, newCost);
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] == int.MaxValue ? "∞" : matrix[i, j].ToString());
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int[,] matrix = new int[,]
        {
            { int.MaxValue, 27, 43, 16, 30, 26 },
            { 7, int.MaxValue, 16, 1, 30, 25 },
            { 20, 13, int.MaxValue, 35, 5, 0 },
            { 21, 16, 25, int.MaxValue, 18, 18 },
            { 12, 46, 27, 48, int.MaxValue, 5 },
            { 23, 5, 5, 9, 5, int.MaxValue }
        };

        ProcessMatrix(matrix, 0);
    }
}
