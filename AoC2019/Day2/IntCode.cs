using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntCode
{
  class IntCode
    {
        public int mainIterator;
        public string fullOpCode;
        public string commandCode;
        public int positionOne;
        public int valueOne;
        public int positionTwo;
        public int valueTwo;
        public int savePosition;
        public int result;

        public IntCode()
        {
            mainIterator = 0;
            fullOpCode = "0";
            commandCode = "0";
            positionOne = 0;
            valueOne = 0;
            positionTwo = 0;
            valueTwo = 0;
            savePosition = 0;
            result = 0;
        }

        public void padOpCode()
        {
            fullOpCode = fullOpCode.PadLeft((5 - (fullOpCode.Length-1)), '0');
        }

        public int run(int[] intArray)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                fullOpCode = intArray[mainIterator].ToString();
                padOpCode();
                commandCode = fullOpCode.Substring(3, 2);
                if (commandCode != "99")
                {
                    switch (commandCode)
                    {
                        case "01":
                            //add -- 3 parameters (num1, num2, saveLocation)
                            Parameter addNum1 = new Parameter(fullOpCode.Substring(2,1) ,intArray[mainIterator + 1]);
                            Parameter addNum2 = new Parameter(fullOpCode.Substring(1, 1), intArray[mainIterator + 2]);
                            Parameter addNum3 = new Parameter(fullOpCode.Substring(0, 1), intArray[mainIterator + 3]);

                            //PARAM 1
                            if(addNum1.mode == "0")
                            {
                                //positional
                                addNum1.index = addNum1.value;
                                addNum1.value = intArray[addNum1.index];
                            }
                            else
                            {
                                //immediate
                                addNum1.index = mainIterator+1;
                            }

                            //PARAM 2
                            if(addNum2.mode == "0")
                            {
                                //positional
                                addNum2.index = addNum2.value;
                                addNum2.value = intArray[addNum2.index];
                            }
                            else
                            {
                                //immediate
                                addNum2.index = mainIterator + 2;
                            }

                            //PARAM 3
                            if (addNum3.mode == "0")
                            {
                                //positional
                                addNum3.index = addNum3.value;
                                addNum3.value = intArray[addNum3.index];

                                intArray[addNum3.index] = addNum1.value + addNum2.value;
                            }
                            else
                            {
                                //immediate
                                addNum3.index = mainIterator + 3;
                            }

                            mainIterator += 4;
                            break;
                        case "02":
                            //multiply -- 3 parameters (num1, num2, saveLocation)
                            Parameter multNum1 = new Parameter(fullOpCode.Substring(2, 1), intArray[mainIterator + 1]);
                            Parameter multNum2 = new Parameter(fullOpCode.Substring(1, 1), intArray[mainIterator + 2]);
                            Parameter multNum3 = new Parameter(fullOpCode.Substring(0, 1), intArray[mainIterator + 3]);

                            //PARAM 1
                            if (multNum1.mode == "0")
                            {
                                //positional
                                multNum1.index = multNum1.value;
                                multNum1.value = intArray[multNum1.index];
                            }
                            else
                            {
                                //immediate
                                multNum1.index = mainIterator + 1;
                            }

                            //PARAM 2
                            if (multNum2.mode == "0")
                            {
                                //positional
                                multNum2.index = multNum2.value;
                                multNum2.value = intArray[multNum2.index];
                            }
                            else
                            {
                                //immediate
                                multNum2.index = mainIterator + 2;
                            }

                            //PARAM 3
                            if (multNum3.mode == "0")
                            {
                                //positional
                                multNum3.index = multNum3.value;
                                multNum3.value = intArray[multNum3.index];

                                intArray[multNum3.index] = multNum1.value * multNum2.value;
                            }
                            else
                            {
                                //immediate
                                multNum3.index = mainIterator + 3;
                            }
                            mainIterator += 4;
                            break;
                        case "03":
                            //input -- 1 parameter (saveLocation)
                            mainIterator += 2;
                            break;
                        case "04":
                            //output -- 1 parameter (outputLocation
                            mainIterator += 2;
                            break;
                        default:
                            break;
                    }
                } 
                else
                {
                    keepRunning = false;
                }

                int a = 3;

                
            //    if (opCode != 99)
            //    {
            //        positionOne = intArray[mainIterator + 1];
            //        valueOne = intArray[positionOne];

            //        positionTwo = intArray[mainIterator + 2];
            //        valueTwo = intArray[positionTwo];

            //        savePosition = intArray[mainIterator + 3];

            //        if (opCode == 1)
            //        {
            //            result = valueOne + valueTwo;
            //        }
            //        else if (opCode == 2)
            //        {
            //            result = valueOne * valueTwo;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Bad Opcode!");
            //        }

            //        intArray[savePosition] = result;
            //        mainIterator += 4;

            //    }
            //    else
            //    {
            //        keepRunning = false;
            //    }
            }

            return intArray[0];
        }
    }
}
