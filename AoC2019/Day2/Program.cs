using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            //100 * cmdArray[1] + cmdArray[2] = 19690720

            string fileContent = File.ReadAllText(@"C:\Users\matt.hurdle\source\repos\AoC2019\AoCDay2\input.txt");
            string[] cmdArray = fileContent.Split(',');

            int result = 0;

            foreach (int noun in Enumerable.Range(0, 100))
            {
                foreach (int verb in Enumerable.Range(0, 100))
                {
                    int[] intArray = Array.ConvertAll(cmdArray, int.Parse);

                    IntCode program = new IntCode();
                    Console.WriteLine("Noun: " + noun);
                    Console.WriteLine("Verb: " + verb);
                    result = program.run(intArray, noun, verb);

                    if (result == 19690720)
                    {
                        Console.WriteLine("Correct Parameters Found!");
                        Console.WriteLine("Noun = " + noun);
                        Console.WriteLine("Verb = " + verb);
                        Console.WriteLine("Result = " + result);
                        Console.ReadLine();
                        return;
                    }
                }
            }

            Console.ReadLine();
        }


    }
}
