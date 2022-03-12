using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NeuronNetwork.Neurons;

namespace NeuronNetwork.NeuronNetworks
{
    class ConvolutionalNN : IBaseNN
    {
        public List<BaseNeuron> _neurons { get; set; }

        public ConvolutionalNN(List<BaseNeuron> neurons)
        {
            _neurons = neurons;
        }

        public List<double> GetOutput()
        {
            return _neurons.Select(neuron => neuron.CalculateOutput()).ToList();
        }

    }
}
