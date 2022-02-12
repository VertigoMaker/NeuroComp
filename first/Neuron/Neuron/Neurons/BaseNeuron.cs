using System;
using System.Collections.Generic;
using System.Text;
using Neuron.Functions;

namespace Neuron.Neurons
{
    class BaseNeuron
    {
        double[] _inputVector;
        double[] _weightVector;
        double _bias = 0;
        Random random = new Random();

        BaseFunction _function;
        double _output;


        public BaseNeuron(double[] input_vector, BaseFunction function)
        {
            _inputVector = input_vector;
            _weightVector = RandomizeWeights(_inputVector.Length);
            _bias = random.NextDouble();
            _function = function;
        }

        private double[] ModifyInput()
        {
            double[] result = new double[_weightVector.Length];
            for(int i = 0;i<_weightVector.Length;i++)
            {
                result[i] = _inputVector[i] * _weightVector[i];
            }
            return result;
        }
        private double Summarize(double[] modified_input)
        {
            double sum = 0;
            for(int i=0;i<modified_input.Length;i++)
            {
                sum += modified_input[i];
            }
            if(_bias != 0)
            {
                sum += _bias;
            }
            return sum;
        }
        public double CalculateOutput()
        {
            _output = _function.Calculate(Summarize(ModifyInput()));
            return _output;
        }
        private double[] RandomizeWeights(int length)
        {
            double[] result = new double[length];
            for(int i = 0;i<0;i++)
            {
                result[i] = random.NextDouble();
            }
            return result;
        }
    }
}
