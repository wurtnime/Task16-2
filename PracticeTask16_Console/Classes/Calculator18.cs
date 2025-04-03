using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator18
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
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                            writer.Write(matrix[i, j] + " ");
                        writer.WriteLine();
                    }
                }
            }
        }

        public static int SumNegativeOdd(int[,] matrix)
        {
            return matrix.Cast<int>().Where(x => x < 0 && x % 2 != 0).Sum();
        }

        public static int[,] IdentityMatrix(int size)
        {
            int[,] identity = new int[size, size];
            for (int i = 0; i < size; i++)
                identity[i, i] = 1;
            return identity;
        }

        public static void ProcessTask()
        {
            string file1 = "matrices18.txt";
            string file2 = "odd_sums_matrices.txt";

            int m = 3, n = 3;
            var matrices = ReadMatrices(file1, m, n);
            var oddSumMatrices = new List<int[,]>();
            var updatedMatrices = new List<int[,]>();

            foreach (var matrix in matrices)
            {
                if (SumNegativeOdd(matrix) % 2 != 0)
                    oddSumMatrices.Add(matrix);
                else
                    updatedMatrices.Add(IdentityMatrix(m));
            }

            WriteMatrices(file1, updatedMatrices);
            WriteMatrices(file2, oddSumMatrices);

            Console.WriteLine("Обновленный исходный файл и новый файл с матрицами:");
        }
    }
}
