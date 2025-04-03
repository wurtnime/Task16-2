using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PracticeTask16_Console
{

    class Program
    {
        static void Main()
        {

            Console.Write("Практическая работа №16\nВведите номер задания: ");

            int sw = Convert.ToInt32(Console.ReadLine());
            switch (sw)
            {

                case 16:
                    Calculator16.ProcessTask();
                    break;

                case 17:
                    Calculator17.ProcessTask();
                    break;

                case 18:
                    Calculator18.ProcessTask();
                    break;

                case 19:
                    Calculator19.ProcessTask();
                    break;

                case 20:
                    Calculator20.ProcessTask();
                    break;

                case 21:
                    Calculator21.ProcessTask();
                    break;

                case 22:
                    Calculator22.ProcessTask();
                    break;

                case 23:
                    Calculator23.ProcessTask();
                    break;

                case 24:
                    Calculator24.ProcessTask();
                    break;

                case 25:
                    Calculator25.ProcessTask();
                    break;

                case 26:
                    Calculator26.ProcessTask();
                    break;

                case 27:
                    Calculator27.ProcessTask();
                    break;

                case 28:
                    Calculator28.ProcessTask();
                    break;

                case 29:
                    Calculator29 calculator = new Calculator29("matrices29_1.txt", "matrices29_2.txt");
                    calculator.ProcessMatrices();
                    break;

                case 30:
                    Calculator30 calculator30 = new Calculator30("matrices30_1.txt", "matrices30_2.txt", "matrices30_3.txt");
                    calculator30.ProcessMatrices();
                    break;

                default:
                    break;
            }
        }
    }
}