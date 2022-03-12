using System;
using System.Collections.Generic;
using System.Text;
using NeuronNetwork.Neurons;
using NeuronNetwork.Functions;

namespace NeuronNetwork.Initialize
{
    class BaseNeuronDto
    {
        public BaseNeuron _base_neuron { get; set; }
        public int _function_type { get; set; }
        public BaseNeuronDto()
        {

        }
        public BaseNeuronDto(BaseNeuron bn)
        {
            _base_neuron = bn;
            if (_base_neuron._function is LinearFunction)
                _function_type = 1;
            else if (_base_neuron._function is LogisticFunction)
                _function_type = 2;
            else if (_base_neuron._function is SignatureFunction)
                _function_type = 3;
            else if (_base_neuron._function is ThresholdFunction)
                _function_type = 4;
        }
        public void SetNeuronFunction()
        {
            switch (_function_type)
            {
                case 1:
                    _base_neuron._function = new LinearFunction();
                    break;
                case 2:
                    _base_neuron._function = new LogisticFunction();
                    break;
                case 3:
                    _base_neuron._function = new SignatureFunction();
                    break;
                case 4:
                    _base_neuron._function = new ThresholdFunction();
                    break;
                default:
                    string msg = $"Неверное значение function_type: {_function_type}";
                    throw new Exception(msg);
            }
        }
    }
}