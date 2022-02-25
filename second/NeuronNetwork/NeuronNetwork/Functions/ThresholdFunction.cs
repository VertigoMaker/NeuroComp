using System;
using System.Collections.Generic;
using System.Text;

namespace NeuronNetwork.Functions
{
    class ThresholdFunction : BaseFunction
    {
        public double Calculate(double input)
        {
            if (input >= 0)
            {
                return 1;
            }
            return 0;
        }

    }
}
