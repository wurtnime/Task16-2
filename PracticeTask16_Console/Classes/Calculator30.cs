using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator30
    {
        private string inputFile1;
        private string inputFile2;
        private string outputFile;

        public Calculator30(string inputFile1, string inputFile2, string outputFile)
        {
            this.inputFile1 = inputFile1;
            this.inputFile2 = inputFile2;
            this.outputFile = outputFile;
        }

        public void ProcessMatrices()
        {
            string[] lines1 = File.ReadAllLines(inputFile1);
            string[] lines2 = File.ReadAllLines(inputFile2);

            int[][][] matrices1 = ParseMatrices(lines1);
            int[][][] matrices2 = ParseMatrices(lines2);

            for (int i = 0; i < Math.Min(matrices1.Length, matrices2.Length); i++)
            {
                if (matrices1[i][0][0] == 5)
                {
                    ReplaceDiagonals(matrices1[i], matrices2[i]);
                }
            }

            File.WriteAllLines(outputFile, matrices1.Select(MatrixToString));

            Console.WriteLine("Содержимое первого файла:");
            Console.WriteLine(File.ReadAllText(inputFile1));

            Console.WriteLine("Содержимое второго файла:");
            Console.WriteLine(File.ReadAllText(inputFile2));

            Console.WriteLine("Содержимое выходного файла:");
            Console.WriteLine(File.ReadAllText(outputFile));
        }

        private int[][][] ParseMatrices(string[] lines)
        {
            return lines
                .Select(line => line.Split(';')
                .Select(row => row.Split().Select(int.Parse).ToArray())
                .ToArray()).ToArray();
        }

        private void ReplaceDiagonals(int[][] matrix1, int[][] matrix2)
        {
            int size = matrix1.Length;
            for (int i = 0; i < size; i++)
            {
                matrix1[i][i] = matrix2[i][i];
                matrix1[i][size - 1 - i] = matrix2[i][size - 1 - i];
            }
        }

        private string MatrixToString(int[][] matrix)
        {
            return string.Join(";", matrix.Select(row => string.Join(" ", row)));
        }
    }
}
