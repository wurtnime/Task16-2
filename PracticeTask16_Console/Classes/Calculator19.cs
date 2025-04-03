using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator19
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

        public static void SwapEvenMatrices(ref List<int[,]> list1, ref List<int[,]> list2)
        {
            int minCount = Math.Min(list1.Count, list2.Count);
            for (int i = 1; i < minCount; i += 2)
                (list1[i], list2[i]) = (list2[i], list1[i]);
        }

        public static void ProcessTask()
        {
            string file1 = "matrices19_1.txt";
            string file2 = "matrices19_2.txt";

            int m = 3, n = 3;
            var matrices1 = ReadMatrices(file1, m, n);
            var matrices2 = ReadMatrices(file2, m, n);

            SwapEvenMatrices(ref matrices1, ref matrices2);

            WriteMatrices(file1, matrices1);
            WriteMatrices(file2, matrices2);
        }
    }
}
