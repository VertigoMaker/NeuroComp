using System;
using Neuron.Neurons;
using Neuron.Functions;

namespace Neuron
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число входных значений");

            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вводите входные значения через Enter");
            double[] input_array = new double[count];
            double[] weight_array = new double[count];

            for(int i = 0;i<count;i++)
            {
                input_array[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Выберите функцию: 1 - Линейная, 2 - Логистическая, 3 - Пороговая, 4 - Сигнатурная");
            
            //Нужен enum или словарь
            int function_number = Convert.ToInt32(Console.ReadLine());

            //Колхоз
            BaseFunction function = new LinearFunction();

            switch(function_number)
            {
                case 1:
                    function = new LinearFunction();
                    break;
                case 2:
                    function = new LogisticFunction();
                    break;
                case 3:
                    function = new ThresholdFunction();
                    break;
                case 4:
                    function = new SignatureFunction();
                    break;
            }


            BaseNeuron neuron = new BaseNeuron(input_array,function);
            Console.WriteLine($"Итог: {neuron.CalculateOutput()}");
            Console.ReadLine();
            
        }
    }
}
