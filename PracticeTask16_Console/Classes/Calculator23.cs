using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator23
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

        public static void WriteMatrices(string filePath, List<(double[,], double[,], double[,])> data)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var (matrix1, matrix2, result) in data)
                {
                    writer.WriteLine("Матрица 1:");
                    WriteMatrix(writer, matrix1);
                    writer.WriteLine("Матрица 2:");
                    WriteMatrix(writer, matrix2);
                    writer.WriteLine("Результат умножения:");
                    WriteMatrix(writer, result);
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

        public static double[,] MultiplyMatrices(double[,] A, double[,] B)
        {
            int m = A.GetLength(0), n = A.GetLength(1), l = B.GetLength(1);
            double[,] C = new double[m, l];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < l; j++)
                    for (int k = 0; k < n; k++)
                        C[i, j] += A[i, k] * B[k, j];
            return C;
        }

        public static void PrintMatrices(List<(double[,], double[,], double[,])> data)
        {
            foreach (var (matrix1, matrix2, result) in data)
            {
                Console.WriteLine("Матрица 1:");
                PrintMatrix(matrix1);
                Console.WriteLine("Матрица 2:");
                PrintMatrix(matrix2);
                Console.WriteLine("Результат умножения:");
                PrintMatrix(result);
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
            string file1 = "matrices23_1.txt";
            string file2 = "matrices23_2.txt";
            string file3 = "matrices23_3.txt";

            int m = 3, n = 2, l = 3;
            var matricesA = ReadMatrices(file1, m, n);
            var matricesB = ReadMatrices(file2, n, l);

            var resultData = new List<(double[,], double[,], double[,])>();
            for (int i = 0; i < matricesA.Count; i++)
            {
                var resultMatrix = MultiplyMatrices(matricesA[i], matricesB[i]);
                resultData.Add((matricesA[i], matricesB[i], resultMatrix));
            }

            WriteMatrices(file3, resultData);
            PrintMatrices(resultData);
        }
    }
}
