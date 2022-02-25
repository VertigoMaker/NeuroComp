using System;
using System.Collections.Generic;
using System.Text;

namespace NeuronNetwork.Functions
{
    class SignatureFunction : BaseFunction
    {
        public double Calculate(double input)
        {
            if (input > 0)
            {
                return 1;
            }
            else return -1;
        }
    }
}
