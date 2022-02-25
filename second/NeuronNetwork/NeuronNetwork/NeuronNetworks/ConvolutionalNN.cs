using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NeuronNetwork.Neurons;

namespace NeuronNetwork.NeuronNetworks
{
    class ConvolutionalNN
    {
        public List<BaseNeuron> _neurons { get; set; }

        public ConvolutionalNN(List<BaseNeuron> neurons)
        {
            _neurons = neurons;
        }

        public double[] GetOutput()
        {
            return _neurons.Select(neuron => neuron.CalculateOutput()).ToArray();
        }

    }
}
