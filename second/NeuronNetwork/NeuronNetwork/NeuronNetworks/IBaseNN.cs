using System;
using System.Collections.Generic;
using System.Text;
using NeuronNetwork.Neurons;


namespace NeuronNetwork.NeuronNetworks
{
    interface IBaseNN
    {
        public List<BaseNeuron> _neurons { get; set; }
        public List<double> GetOutput();
    }
}
