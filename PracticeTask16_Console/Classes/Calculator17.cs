using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PracticeTask16_Console
{
    public class Calculator17
    {
        public static List<int[,]> ReadMatrices(string filePath, int rows, int cols)
        {
            var matrices = new List<int[,]>();
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i += rows)
            {
                int[,] matrix = new int[rows, cols];
                for (int j = 0; j < rows; j++)
                {
                    var values = lines[i + j].Split().Select(int.Parse).ToArray();
                    for (int k = 0; k < cols; k++)
                        matrix[j, k] = values[k];
                }
                matrices.Add(matrix);
            }
            return matrices;
        }

        public static List<int[]> ReadVectors(string filePath, int length)
        {
            return File.ReadAllLines(filePath)
                       .Select(line => line.Split().Select(int.Parse).ToArray())
                       .ToList();
        }

        public static void WriteResults(string filePath, List<int> results)
        {
            File.WriteAllLines(filePath, results.Select(r => r.ToString()));
        }

        public static int ScalarProduct(int[,] matrix, int[] vector)
        {
            int sum = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1) - 1;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    sum += matrix[i, j] * vector[j];

            return sum;
        }

        public static void ProcessTask()
        {
            string file1 = "matrices17.txt";
            string file2 = "vectors17.txt";
            string file3 = "results17.txt";

            int rows = 3, cols = 4;
            var matrices = ReadMatrices(file1, rows, cols);
            var vectors = ReadVectors(file2, cols - 1);

            List<int> results = new List<int>();
            for (int i = 0; i < matrices.Count; i++)
                results.Add(ScalarProduct(matrices[i], vectors[i]));

            WriteResults(file3, results);

            Console.WriteLine("Результаты скалярных произведений:");
            results.ForEach(Console.WriteLine);
        }
    }
}