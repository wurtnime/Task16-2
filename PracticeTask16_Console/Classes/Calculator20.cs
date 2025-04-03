using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator20
    {
        public static List<int[,]> ReadMatrices(string filePath, int n)
        {
            var matrices = new List<int[,]>();
            var lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i += n)
            {
                int[,] matrix = new int[n, n];
                for (int j = 0; j < n; j++)
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
                    int n = matrix.GetLength(0);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                            writer.Write(matrix[i, j] + " ");
                        writer.WriteLine();
                    }
                }
            }
        }

        public static int[,] IdentityMatrix(int n)
        {
            int[,] identity = new int[n, n];
            for (int i = 0; i < n; i++)
                identity[i, i] = 1;
            return identity;
        }

        public static void PrintMatrices(List<int[,]> matrices)
        {
            foreach (var matrix in matrices)
            {
                int n = matrix.GetLength(0);
                for (int i = 0; i < n; i++)
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
            string file1 = "matrices20_1.txt";
            string file2 = "matrices20_2.txt";

            int n = 3;
            var matrices1 = ReadMatrices(file1, n);
            var matrices2 = ReadMatrices(file2, n);

            int k = matrices1.Count, l = matrices2.Count;

            if (k > l)
            {
                for (int i = 0; i < k - l; i++)
                    matrices2.Insert(0, IdentityMatrix(n));
            }
            else if (l > k)
            {
                for (int i = 0; i < l - k; i++)
                    matrices1.Insert(0, IdentityMatrix(n));
            }

            WriteMatrices(file1, matrices1);
            WriteMatrices(file2, matrices2);

            Console.WriteLine("Содержимое первого файла:");
            PrintMatrices(matrices1);

            Console.WriteLine("Содержимое второго файла:");
            PrintMatrices(matrices2);
        }
    }
}
