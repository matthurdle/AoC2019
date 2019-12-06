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
            string fileContent = File.ReadAllText(@"D:\Users\matth\github-repos\AoC2019\input.txt");
            //string fileContent = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9";
            //string fileContent = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1";
            //string fileContent = "3,9,8,9,10,9,4,9,99,-1,8";
            //string fileContent = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";
            //string fileContent = "3,3,1108,-1,8,3,4,3,99";

            string[] cmdArray = fileContent.Split(',');

            //int result = 0;
            
            int[] intArray = Array.ConvertAll(cmdArray, int.Parse);

            IntCode program = new IntCode();
                  
            program.run(intArray);

            Console.ReadLine();
        }


    }
}
