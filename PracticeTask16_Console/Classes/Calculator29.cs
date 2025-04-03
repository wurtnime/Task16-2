using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask16_Console
{
    internal class Calculator29
    {
        private string inputFile;
        private string outputFile;

        public Calculator29(string inputFile, string outputFile)
        {
            this.inputFile = inputFile;
            this.outputFile = outputFile;
        }

        public void ProcessMatrices()
        {
            string[] lines = File.ReadAllLines(inputFile);
            int[][][] matrices = ParseMatrices(lines);
            var validMatrices = matrices.Where(m => ScalarProductOfDiagonals(m) > 15).ToArray();

            File.WriteAllLines(outputFile, validMatrices.Select(MatrixToString));

            Console.WriteLine("Содержимое первого файла:");
            Console.WriteLine(File.ReadAllText(inputFile));

            Console.WriteLine("Содержимое второго файла:");
            Console.WriteLine(File.ReadAllText(outputFile));
        }

        private int[][][] ParseMatrices(string[] lines)
        {
            return lines
                .Select(line => line.Split(';')
                .Select(row => row.Split().Select(int.Parse).ToArray())
                .ToArray()).ToArray();
        }

        private int ScalarProductOfDiagonals(int[][] matrix)
        {
            int size = matrix.Length;
            int product = 0;
            for (int i = 0; i < size; i++)
            {
                product += matrix[i][i] * matrix[i][size - 1 - i];
            }
            return product;
        }

        private string MatrixToString(int[][] matrix)
        {
            return string.Join(";", matrix.Select(row => string.Join(" ", row)));
        }
    }
}
