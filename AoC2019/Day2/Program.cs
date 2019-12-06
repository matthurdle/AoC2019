using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileContent = File.ReadAllText(@"C:\Users\matt.hurdle\source\repos\AoC2019\AoC2019\input.txt");
            string[] cmdArray = fileContent.Split(',');

            int result = 0;
            
            int[] intArray = Array.ConvertAll(cmdArray, int.Parse);

            IntCode program = new IntCode();
                  
            result = program.run(intArray);

            Console.ReadLine();
        }


    }
}
