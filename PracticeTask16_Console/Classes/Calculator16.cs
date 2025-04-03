using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Calculator16
{
    public static List<int[,]> ReadMatrices(string filePath, int m, int n)
    {
        var matrices = new List<int[,]>();
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i += m)
        {
            int[,] matrix = new int[m, n];
            for (int j = 0; j < m; j++)
            {
                var values = lines[i + j].Split().Select(int.Parse).ToArray();
                for (int k = 0; k < n; k++)
                    matrix[j, k] = values[k];
            }
            matrices.Add(matrix);
        }
        return matrices;
    }

    public static void WriteMatrices(string filePath, List<int[,]> matrices)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var matrix in matrices)
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        writer.Write(matrix[i, j] + " ");
                    writer.WriteLine();
                }
            }
        }
    }

    public static int Determinant(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        if (n != matrix.GetLength(1))
            throw new InvalidOperationException("Определитель можно вычислить только для квадратных матриц!");

        if (n == 2)
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        int det = 0;
        for (int i = 0; i < n; i++)
        {
            int[,] subMatrix = new int[n - 1, n - 1];
            for (int j = 1; j < n; j++)
            {
                int columnIndex = 0;
                for (int k = 0; k < n; k++)
                {
                    if (k == i) continue;
                    subMatrix[j - 1, columnIndex++] = matrix[j, k];
                }
            }
            det += matrix[0, i] * Determinant(subMatrix) * (i % 2 == 0 ? 1 : -1);
        }
        return det;
    }

    public static void PrintMatrices(List<int[,]> matrices)
    {
        foreach (var matrix in matrices)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    public static void ProcessTask()
    {
        string file1 = "matrices16_1.txt";
        string file2 = "matrices16_2.txt";

        int m = 3, n = 3;
        var matrices1 = ReadMatrices(file1, m, n);
        var matrices2 = ReadMatrices(file2, m, n);

        foreach (var matrix in matrices1)
        {
            if (Determinant(matrix) == 5)
                matrices2.Add(matrix);
        }

        WriteMatrices(file2, matrices2);

        Console.WriteLine("Содержимое первого файла:");
        PrintMatrices(matrices1);

        Console.WriteLine("Содержимое второго файла:");
        PrintMatrices(matrices2);
    }
}