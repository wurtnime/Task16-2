using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator21
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
                    int m = matrix.GetLength(0), n = matrix.GetLength(1);
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                            writer.Write(matrix[i, j] + " ");
                        writer.WriteLine();
                    }
                }
            }
        }

        public static int DiagonalDifference(int[,] matrix)
        {
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            int mainDiag = 0, secDiag = 0;
            for (int i = 0; i < Math.Min(m, n); i++)
            {
                mainDiag += matrix[i, i];
                secDiag += matrix[i, n - i - 1];
            }
            return Math.Abs(mainDiag - secDiag);
        }

        public static int[,] InverseMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            int[,] inverse = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    inverse[j, i] = matrix[i, j];
            return inverse;
        }

        public static void PrintMatrices(List<int[,]> matrices)
        {
            foreach (var matrix in matrices)
            {
                int m = matrix.GetLength(0), n = matrix.GetLength(1);
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                        Console.Write(matrix[i, j] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public static void ProcessTask()
        {
            string file1 = "matrices21_1.txt";
            string file2 = "matrices21_2.txt";

            int m = 3, n = 3;
            var matrices = ReadMatrices(file1, m, n);
            var evenDifferenceMatrices = new List<int[,]>();

            for (int i = 0; i < matrices.Count; i++)
            {
                if (DiagonalDifference(matrices[i]) % 2 == 0)
                {
                    evenDifferenceMatrices.Add(matrices[i]);
                    matrices[i] = InverseMatrix(matrices[i]);
                }
            }

            WriteMatrices(file1, matrices);
            WriteMatrices(file2, evenDifferenceMatrices);

            Console.WriteLine("Содержимое первого файла:");
            PrintMatrices(matrices);

            Console.WriteLine("Содержимое второго файла:");
            PrintMatrices(evenDifferenceMatrices);
        }
    }
}
