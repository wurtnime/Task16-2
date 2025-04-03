using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator24
    {
        public static List<double[,]> ReadMatrices(string filePath, int rows, int cols)
        {
            var matrices = new List<double[,]>();
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i += rows)
            {
                double[,] matrix = new double[rows, cols];
                for (int j = 0; j < rows; j++)
                {
                    var values = lines[i + j].Split().Select(double.Parse).ToArray();
                    for (int k = 0; k < cols; k++)
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
                    WriteMatrix(writer, matrix);
                    writer.WriteLine("----------------------");
                }
            }
        }

        private static void WriteMatrix(StreamWriter writer, double[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    writer.Write(matrix[i, j] + " ");
                writer.WriteLine();
            }
        }

        public static void SwapEvenMatrices(ref List<double[,]> matricesA, ref List<double[,]> matricesB, out List<double[,]> remaining)
        {
            int minCount = Math.Min(matricesA.Count, matricesB.Count);
            for (int i = 1; i < minCount; i += 2)
            {
                (matricesA[i], matricesB[i]) = (matricesB[i], matricesA[i]);
            }

            remaining = matricesA.Count > matricesB.Count ? matricesA.Skip(minCount).ToList() : matricesB.Skip(minCount).ToList();
        }

        public static void PrintMatrices(string label, List<double[,]> matrices)
        {
            Console.WriteLine(label);
            foreach (var matrix in matrices)
            {
                PrintMatrix(matrix);
                Console.WriteLine("----------------------");
            }
        }

        private static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{matrix[i, j],6:F2} ");
                Console.WriteLine();
            }
        }

        public static void ProcessTask()
        {
            string file1 = "matrices24_1.txt";
            string file2 = "matrices24_2.txt";
            string file3 = "matrices24_3.txt";

            int m = 3, n = 3;
            var matricesA = ReadMatrices(file1, m, n);
            var matricesB = ReadMatrices(file2, m, n);

            SwapEvenMatrices(ref matricesA, ref matricesB, out var remaining);

            WriteMatrices(file1, matricesA);
            WriteMatrices(file2, matricesB);
            WriteMatrices(file3, remaining);

            PrintMatrices("Первый файл (после замены):", matricesA);
            PrintMatrices("Второй файл (после замены):", matricesB);
            PrintMatrices("Третий файл (остатки):", remaining);
        }
    }
}
