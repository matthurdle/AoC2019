using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    class PasswordFinder
    {
        List<int> goodPasswords;
        int passwordCount;
        string strPasswordRange;
        int startPassword;
        int endPassword;

        public PasswordFinder(string _passwordRange)
        {
            goodPasswords = new List<int>();
            passwordCount = 0;
            strPasswordRange = _passwordRange;
            startPassword = 0;
            endPassword = 0;
            parsePasswordRange();
        }

        public void parsePasswordRange()
        {
            string[] intPasswordRange = strPasswordRange.Split('-');
            startPassword = int.Parse(intPasswordRange[0]);
            endPassword = int.Parse(intPasswordRange[1]);

            getPasswordCountFromRange();
        }

        public void getPasswordCountFromRange()
        {
            for (int i = startPassword; i <= endPassword; i++)
            {
                if (checkPassword(i))
                {
                    passwordCount++;
                    goodPasswords.Add(i);
                }
            }
        }

        public bool checkPassword(int passwordToCheck)
        {
            // Ensure it's a six digit number
            if (Math.Ceiling(Math.Log10(passwordToCheck)) == 6)
            {
                //Ensure at least two adjacent digits are the same
                if (checkAdjacency(passwordToCheck))
                {
                    //Make sure digits never decrease
                    if (checkValueOrder(passwordToCheck))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool checkValueOrder(int passwordToCheck)
        {
            string password = passwordToCheck.ToString();

            for (int i = 0; i < password.Length - 1; i++)
            {
                double thisNum = Char.GetNumericValue(password[i]);
                double nextNum = Char.GetNumericValue(password[i + 1]);

                if (thisNum > nextNum)
                {
                    return false;
                }
            }

            return true;
        }

        public bool checkAdjacency(int passwordToCheck)
        {
            string password = passwordToCheck.ToString();
            int adjCount = 0;
            Dictionary<char, int> adjTracker = new Dictionary<char, int>();

            for (int i = 0; i < password.Length - 1; i++)
            {
                char thisChar = password[i];
                char nextChar = password[i + 1];

                if (thisChar == nextChar)
                {
                    adjCount++;
                    if (adjTracker.ContainsKey(thisChar))
                    {
                        adjTracker[thisChar]++;
                    }
                    else
                    {
                        adjTracker.TryAdd(thisChar, adjCount);
                    }
                }
                else
                {
                    adjCount = 0;
                }
            }

            foreach (KeyValuePair<char, int> kv in adjTracker)
            {
                if (kv.Value == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
