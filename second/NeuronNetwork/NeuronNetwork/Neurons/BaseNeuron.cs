using System;
using System.Collections.Generic;
using System.Text.Json;
using NeuronNetwork.Functions;

namespace NeuronNetwork.Neurons
{
    class BaseNeuron
    {
        public double[] _inputVector { get; set; }
        public double[] _weightVector { get; set; }
        public  double _bias { get; set; }
        Random random = new Random();

        public BaseFunction _function;
        double _output;


        public BaseNeuron()
        {

        }
        public BaseNeuron(double[] input_vector, BaseFunction function)
        {
            _inputVector = input_vector;
            _weightVector = RandomizeWeights(_inputVector.Length);
            _bias = random.NextDouble();
            _function = function;
        }

        public void RandomWeights()
        {
            _weightVector = RandomizeWeights(_inputVector.Length);
            _bias = random.NextDouble();
        }
        private double[] ModifyInput()
        {
            double[] result = new double[_weightVector.Length];
            for (int i = 0; i < _weightVector.Length; i++)
            {
                result[i] = _inputVector[i] * _weightVector[i];
            }
            return result;
        }
        private double Summarize(double[] modified_input)
        {
            double sum = 0;
            for (int i = 0; i < modified_input.Length; i++)
            {
                sum += modified_input[i];
            }
            if (_bias != 0)
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
            for (int i = 0; i < length; i++)
            {
                double random_double = random.NextDouble();
                result[i] = random_double == 0 ? random_double + 1 : random_double;
            }
            return result;
        }
    }
}