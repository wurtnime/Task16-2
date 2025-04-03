using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator25
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

        public static double RowSum(double[,] matrix, int rowIndex)
        {
            int cols = matrix.GetLength(1);
            double sum = 0;
            for (int i = 0; i < cols; i++)
                sum += matrix[rowIndex, i];
            return sum;
        }

        public static void ProcessMatrices(ref List<double[,]> matricesA, ref List<double[,]> matricesB)
        {
            List<double[,]> movedMatrices = new List<double[,]>();

            foreach (var matrix in matricesA)
            {
                double firstRowSum = RowSum(matrix, 0);
                double lastRowSum = RowSum(matrix, matrix.GetLength(0) - 1);

                if (firstRowSum > lastRowSum)
                    movedMatrices.Add(matrix);
            }

            matricesA = matricesA.Except(movedMatrices).ToList();
            matricesB.AddRange(movedMatrices);
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
            string file1 = "matrices25_1.txt";
            string file2 = "matrices25_2.txt";

            int m = 3, n = 3; 
            var matricesA = ReadMatrices(file1, m, n);
            var matricesB = ReadMatrices(file2, m, n);

            ProcessMatrices(ref matricesA, ref matricesB);

            WriteMatrices(file1, matricesA);
            WriteMatrices(file2, matricesB);

            PrintMatrices("Первый файл (после обработки):", matricesA);
            PrintMatrices("Второй файл (после добавления):", matricesB);
        }
    }
}
