using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator28
    {
        public static List<double[,]> ReadMatrices(string filePath, int m, int n)
        {
            var matrices = new List<double[,]>();
            var lines = File.ReadAllLines(filePath);
            int index = 0;

            while (index < lines.Length)
            {
                double[,] matrix = new double[m, n];

                for (int i = 0; i < m; i++)
                {
                    var values = lines[index++].Split().Select(double.Parse).ToArray();
                    for (int j = 0; j < n; j++)
                        matrix[i, j] = values[j];
                }

                matrices.Add(matrix);
                if (index < lines.Length && lines[index] == "-----") index++;
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

        public static bool HasEqualMainDiagonals(double[,] matrix)
        {
            int size = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
            double diagValue = matrix[0, 0];

            for (int i = 1; i < size; i++)
            {
                if (matrix[i, i] != diagValue)
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
            string file1 = "matrices28_1.txt";
            string file2 = "matrices28_2.txt";

            int m = 3, n = 3;

            var matrices1 = ReadMatrices(file1, m, n);
            var matrices2 = ReadMatrices(file2, m, n);

            var matchingMatrices = matrices1.Where(HasEqualMainDiagonals).ToList();
            matrices2.AddRange(matchingMatrices);

            WriteMatrices(file2, matrices2);

            PrintMatrices("Первый файл:", matrices1);
            PrintMatrices("Второй файл после добавления:", matrices2);
        }
    }
}
