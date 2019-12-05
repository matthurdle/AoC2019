using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
  class IntCode
    {
        public int mainIterator;
        public int opCode;
        public int positionOne;
        public int valueOne;
        public int positionTwo;
        public int valueTwo;
        public int savePosition;
        public int result;

        public IntCode()
        {
            mainIterator = 0;
            opCode = 0;
            positionOne = 0;
            valueOne = 0;
            positionTwo = 0;
            valueTwo = 0;
            savePosition = 0;
            result = 0;
        }
        public int run(int[] intArray, int noun, int verb)
        {
            bool keepRunning = true;

            intArray[1] = noun;
            intArray[2] = verb;

            while (keepRunning)
            {
                opCode = intArray[mainIterator];

                if (opCode != 99)
                {
                    positionOne = intArray[mainIterator + 1];
                    valueOne = intArray[positionOne];

                    positionTwo = intArray[mainIterator + 2];
                    valueTwo = intArray[positionTwo];

                    savePosition = intArray[mainIterator + 3];

                    if (opCode == 1)
                    {
                        result = valueOne + valueTwo;
                    }
                    else if (opCode == 2)
                    {
                        result = valueOne * valueTwo;
                    }
                    else
                    {
                        Console.WriteLine("Bad Opcode!");
                    }

                    intArray[savePosition] = result;
                    mainIterator += 4;

                }
                else
                {
                    keepRunning = false;
                }
            }

            return intArray[0];
        }
    }
}
