using System;
using System.Collections.Generic;
using System.Text;

namespace IntCode
{
    class Parameter
    {
        public string mode;
        public int index;
        public int value;

        public Parameter(string _mode, int _value)
        {
            mode = _mode;
            value = _value;
        }
    }
}
