using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator22
    {
        public static List<double[,]> ReadMatrices(string filePath, int size)
        {
            var matrices = new List<double[,]>();
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i += size)
            {
                double[,] matrix = new double[size, size];
                for (int j = 0; j < size; j++)
                {
                    var values = lines[i + j].Split().Select(double.Parse).ToArray();
                    for (int k = 0; k < size; k++)
                        matrix[j, k] = values[k];
                }
                matrices.Add(matrix);
            }
            return matrices;
        }

        public static void WriteMatrices(string filePath, List<double[,]> matrices)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var matrix in matrices)
                {
                    int size = matrix.GetLength(0);
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                            writer.Write(matrix[i, j] + " ");
                        writer.WriteLine();
                    }
                }
            }
        }

        public static double Determinant(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 1) return matrix[0, 0];

            double det = 0;
            for (int i = 0; i < n; i++)
            {
                double[,] minor = new double[n - 1, n - 1];
                for (int j = 1; j < n; j++)
                    for (int k = 0, col = 0; k < n; k++)
                        if (k != i) minor[j - 1, col++] = matrix[j, k];

                det += (i % 2 == 0 ? 1 : -1) * matrix[0, i] * Determinant(minor);
            }
            return det;
        }

        public static double[,] InverseMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double det = Determinant(matrix);
            if (det == 0) return null;

            double[,] adj = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double[,] minor = new double[n - 1, n - 1];
                    for (int x = 0, row = 0; x < n; x++)
                    {
                        if (x == i) continue;
                        for (int y = 0, col = 0; y < n; y++)
                        {
                            if (y == j) continue;
                            minor[row, col++] = matrix[x, y];
                        }
                        row++;
                    }
                    adj[j, i] = (i + j) % 2 == 0 ? 1 : -1 * Determinant(minor);
                }
            }

            double[,] inverse = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    inverse[i, j] = adj[i, j] / det;

            return inverse;
        }

        public static void PrintMatrices(List<double[,]> matrices)
        {
            foreach (var matrix in matrices)
            {
                int size = matrix.GetLength(0);
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        Console.Write($"{matrix[i, j]:F2} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public static void ProcessTask()
        {
            string file1 = "matrices22_1.txt";
            string file2 = "matrices22_2.txt";
            string file3 = "matrices22_3.txt";

            int size = 3;
            var matrices = ReadMatrices(file1, size);
            var inverseMatrices = new List<double[,]>();
            var nonInvertibleMatrices = new List<double[,]>();

            foreach (var matrix in matrices)
            {
                double[,] inv = InverseMatrix(matrix);
                if (inv != null)
                    inverseMatrices.Add(inv);
                else
                    nonInvertibleMatrices.Add(matrix);
            }

            WriteMatrices(file2, inverseMatrices);
            WriteMatrices(file3, nonInvertibleMatrices);

            Console.WriteLine("Обратимые матрицы:");
            PrintMatrices(inverseMatrices);
            Console.WriteLine("Необратимые матрицы:");
            PrintMatrices(nonInvertibleMatrices);
        }
    }
}
