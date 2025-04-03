using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator26
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

        public static List<double[,]> MultiplyMatrices(List<double[,]> matrices, double k)
        {
            var result = new List<double[,]>();

            foreach (var matrix in matrices)
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                double[,] newMatrix = new double[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        newMatrix[i, j] = matrix[i, j] * k;
                }

                result.Add(newMatrix);
            }

            return result;
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
            string file1 = "matrices26_1.txt";
            string file2 = "matrices26_2.txt";
            string file3 = "matrices26_3.txt";

            int m = 3, n = 3;
            double multiplier = 2; 

            var matricesA = ReadMatrices(file1, m, n);
            var matricesB = ReadMatrices(file2, m, n);

            var resultMatrices = MultiplyMatrices(matricesA, multiplier);

            WriteMatrices(file3, resultMatrices);

            PrintMatrices("Первый файл:", matricesA);
            PrintMatrices("Второй файл (умножение матрицы):", resultMatrices);
        }
    }
}
