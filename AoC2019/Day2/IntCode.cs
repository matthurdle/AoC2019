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
            fullOpCode = fullOpCode.PadLeft(5, '0');
        }

        public void run(int[] intArray)
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
                            Parameter addNum1 = new Parameter(fullOpCode.Substring(2, 1), intArray[mainIterator + 1]);
                            Parameter addNum2 = new Parameter(fullOpCode.Substring(1, 1), intArray[mainIterator + 2]);
                            Parameter addNum3 = new Parameter(fullOpCode.Substring(0, 1), intArray[mainIterator + 3]);

                            //PARAM 1
                            if (addNum1.mode == "0")
                            {
                                //positional
                                addNum1.index = addNum1.value;
                                addNum1.value = intArray[addNum1.index];
                            }
                            else
                            {
                                //immediate
                                addNum1.index = mainIterator + 1;
                            }

                            //PARAM 2
                            if (addNum2.mode == "0")
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
                            Parameter inputNum1 = new Parameter(fullOpCode.Substring(2, 1), intArray[mainIterator + 1]);

                            if (inputNum1.mode == "0")
                            {
                                int input = int.Parse(Console.ReadLine());
                                inputNum1.index = inputNum1.value;
                                intArray[inputNum1.index] = input;
                            }
                            else
                            {
                                int input = int.Parse(Console.ReadLine());
                                inputNum1.index = mainIterator + 1;
                                inputNum1.value = input;

                                intArray[inputNum1.index] = input;
                            }

                            mainIterator += 2;
                            break;
                        case "04":
                            //output -- 1 parameter (outputLocation)
                            Parameter outputParam = new Parameter(fullOpCode.Substring(2, 1), intArray[mainIterator + 1]);

                            if (outputParam.mode == "0")
                            {
                                Console.WriteLine(intArray[outputParam.value]);
                            }
                            else
                            {
                                Console.WriteLine(intArray[mainIterator + 1]);
                            }
                            mainIterator += 2;
                            break;
                        case "05":
                            //Jump-If-True - 2 parameters (param to check, param to jump to)
                            Parameter jit1 = new Parameter(fullOpCode.Substring(2, 1), intArray[mainIterator + 1]);
                            Parameter jit2 = new Parameter(fullOpCode.Substring(1, 1), intArray[mainIterator + 2]);

                            if(jit1.mode == "0")
                            {
                                //positional
                                jit1.index = jit1.value;
                                jit1.value = intArray[jit1.index];
                            }
                            else
                            {
                                //immediate
                                jit1.index = mainIterator + 1;
                            }

                            if(jit2.mode == "0")
                            {
                                jit2.index = jit2.value;
                                jit2.value = intArray[jit2.index];
                            }
                            else
                            {
                                jit2.index = mainIterator + 3;
                            }

                            if(jit1.value != 0)
                            {
                                mainIterator = jit2.value;
                            }
                            else
                            {
                                mainIterator += 3;
                            }

                            break;
                        case "06":
                            //Jump-If-False - 2 params (param to check, param to jump to)
                            Parameter jif1 = new Parameter(fullOpCode.Substring(2, 1), intArray[mainIterator + 1]);
                            Parameter jif2 = new Parameter(fullOpCode.Substring(1, 1), intArray[mainIterator + 2]);

                            if (jif1.mode == "0")
                            {
                                //positional
                                jif1.index = jif1.value;
                                jif1.value = intArray[jif1.index];
                            }
                            else
                            {
                                //immediate
                                jif1.index = mainIterator + 1;
                            }

                            if (jif2.mode == "0")
                            {
                                jif2.index = jif2.value;
                                jif2.value = intArray[jif2.index];
                            }
                            else
                            {
                                jif2.index = mainIterator + 2;
                            }

                            if (jif1.value == 0)
                            {
                                mainIterator = jif2.value;
                            }
                            else
                            {
                                mainIterator += 3;
                            }
                            break;
                        case "07":
                            //less than - 3 parameters (value 1, value 2, storage location)
                            // if value one < value two, then store a 1 in storage location
                            // if not, store a 0 in storage location
                            Parameter ltNum1 = new Parameter(fullOpCode.Substring(2, 1), intArray[mainIterator + 1]);
                            Parameter ltNum2 = new Parameter(fullOpCode.Substring(1, 1), intArray[mainIterator + 2]);
                            Parameter ltNum3 = new Parameter(fullOpCode.Substring(0, 1), intArray[mainIterator + 3]);

                            //PARAM 1
                            if (ltNum1.mode == "0")
                            {
                                //positional
                                ltNum1.index = ltNum1.value;
                                ltNum1.value = intArray[ltNum1.index];
                            }
                            else
                            {
                                //immediate
                                ltNum1.index = mainIterator + 1;
                                ltNum1.value = intArray[ltNum1.index];
                            }

                            //PARAM 2
                            if (ltNum2.mode == "0")
                            {
                                //positional
                                ltNum2.index = ltNum2.value;
                                ltNum2.value = intArray[ltNum2.index];
                            }
                            else
                            {
                                //immediate
                                ltNum2.index = mainIterator + 2;
                                ltNum2.value = intArray[ltNum2.index];
                            }

                            //PARAM 3
                            if (ltNum3.mode == "0")
                            {
                                //positional
                                ltNum3.index = ltNum3.value;
                                ltNum3.value = intArray[ltNum3.index];

                            }
                            else
                            {
                                //immediate
                                ltNum3.index = mainIterator + 3;
                                ltNum3.value = intArray[ltNum3.index];
                            }

                            if (ltNum1.value < ltNum2.value)
                            {
                                intArray[ltNum3.index] = 1;
                            }
                            else
                            {
                                intArray[ltNum3.index] = 0;
                            }

                            mainIterator += 4;
                            break;
                        case "08":
                            //Equals - 3 params
                            Parameter eqNum1 = new Parameter(fullOpCode.Substring(2, 1), intArray[mainIterator + 1]);
                            Parameter eqNum2 = new Parameter(fullOpCode.Substring(1, 1), intArray[mainIterator + 2]);
                            Parameter eqNum3 = new Parameter(fullOpCode.Substring(0, 1), intArray[mainIterator + 3]);

                            //PARAM 1
                            if (eqNum1.mode == "0")
                            {
                                //positional
                                eqNum1.index = eqNum1.value;
                                eqNum1.value = intArray[eqNum1.index];
                            }
                            else
                            {
                                //immediate
                                eqNum1.index = mainIterator + 1;
                                eqNum1.value = intArray[eqNum1.index];
                            }

                            //PARAM 2
                            if (eqNum2.mode == "0")
                            {
                                //positional
                                eqNum2.index = eqNum2.value;
                                eqNum2.value = intArray[eqNum2.index];
                            }
                            else
                            {
                                //immediate
                                eqNum2.index = mainIterator + 2;
                                eqNum2.value = intArray[eqNum2.index];
                            }

                            //PARAM 3
                            if (eqNum3.mode == "0")
                            {
                                //positional
                                eqNum3.index = eqNum3.value;
                                eqNum3.value = intArray[eqNum3.index];

                            }
                            else
                            {
                                //immediate
                                eqNum3.index = mainIterator + 3;
                                eqNum3.value = intArray[eqNum3.index];
                            }

                            if (eqNum1.value == eqNum2.value)
                            {
                                intArray[eqNum3.index] = 1;
                            }
                            else
                            {
                                intArray[eqNum3.index] = 0;
                            }

                            mainIterator += 4;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    keepRunning = false;
                }

                //int a = 3;

                //return intArray[0];
            }
        }
    }
}