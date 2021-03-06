using System;
using System.Collections.Generic;
using System.Text;

namespace NeuronNetwork.Functions
{
    class LogisticFunction : BaseFunction
    {
        public double Calculate(double input)
        {
            return 1 / (1 + Math.Exp(input));
        }
    }
}
