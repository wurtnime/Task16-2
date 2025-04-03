using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator27
    {
        public static List<(double[,], double[,])> ReadMatricesPairs(string filePath, int m, int n, int l)
        {
            var pairs = new List<(double[,], double[,])>();
            var lines = File.ReadAllLines(filePath);
            int index = 0;

            while (index < lines.Length)
            {
                double[,] matrixA = new double[m, n];
                double[,] matrixB = new double[m, l];

                for (int i = 0; i < m; i++)
                {
                    var values = lines[index++].Split().Select(double.Parse).ToArray();
                    for (int j = 0; j < n; j++)
                        matrixA[i, j] = values[j];
                }

                for (int i = 0; i < m; i++)
                {
                    var values = lines[index++].Split().Select(double.Parse).ToArray();
                    for (int j = 0; j < l; j++)
                        matrixB[i, j] = values[j];
                }

                pairs.Add((matrixA, matrixB));
                if (index < lines.Length && lines[index] == "-----") index++;
            }

            return pairs;
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

        public static bool IsFirstColumnMatching(double[,] matrixA, double[,] matrixB)
        {
            int rows = matrixA.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                if (matrixA[i, 0] != matrixB[i, 0])
                    return false;
            }
            return true;
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
            string file1 = "matrices27_1.txt";
            string file2 = "matrices27_2.txt";
            string file3 = "matrices27_3.txt";

            int m = 3, n = 3, l = 2;

            var matrixPairs = ReadMatricesPairs(file1, m, n, l);
            var matricesB = ReadMatricesPairs(file2, m, n, l);

            var matchingMatrices = new List<double[,]>();

            foreach (var (matrixA, matrixB) in matrixPairs)
            {
                if (IsFirstColumnMatching(matrixA, matrixB))
                    matchingMatrices.Add(matrixA);
            }

            WriteMatrices(file3, matchingMatrices);

            Console.WriteLine("Первый файл:");
            foreach (var (matrixA, matrixB) in matrixPairs)
            {
                PrintMatrix(matrixA);
                Console.WriteLine("----------------------");
                PrintMatrix(matrixB);
                Console.WriteLine("======================");
            }

            PrintMatrices("Третий файл (совпадающие матрицы):", matchingMatrices);
        }
    }
}
