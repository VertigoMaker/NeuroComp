using System;
using System.Collections.Generic;
using NeuronNetwork.Neurons;
using NeuronNetwork.Initialize;
using NeuronNetwork.NeuronNetworks;
using NeuronNetwork.Functions;

namespace NeuronNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            NeuronNNInitializer nn_init = NeuronNNInitializer.GetInstance();
            List<BaseNeuron> base_neurons = new List<BaseNeuron>();
            double [] array = { 1, 1 };
            base_neurons.Add(new BaseNeuron(array, new LinearFunction()));
            base_neurons.Add(new BaseNeuron(array, new LogisticFunction()));
            base_neurons.Add(new BaseNeuron(array, new SignatureFunction()));
            base_neurons.Add(new BaseNeuron(array, new ThresholdFunction()));
            nn_init.WriteNeurons(base_neurons).GetAwaiter().GetResult();
            Console.ReadKey();*/
            
            //Стартуем
            NeuronNNInitializer nn_init = NeuronNNInitializer.GetInstance();
            List<BaseNeuron> neurons = nn_init.ReadNeurons().GetAwaiter().GetResult();
            
            //Ввод
            Console.WriteLine("Какой тип сети? 1 - полносвязная, 2 - слоистая.");
            int network_type = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Сколько итераций?");
            int count = Convert.ToInt32(Console.ReadLine());

            IBaseNN nn;

            //Логика
            switch (network_type)
            {                
                case 1:
                    nn = new ConvolutionalNN(neurons);
                    break;                
                default:                    
                    throw new Exception("Недопустимое значение, характеризующее тип сети.");
                    
            }
            //
            for (int i = 1; i < count; i++)
            {
                Console.WriteLine($"Итерация №{i}:");
                nn.GetOutput().ForEach(output => { 
                    Console.WriteLine(output.ToString());
                    
                });
                
                Console.WriteLine($"Конец итерации №{i}" + Environment.NewLine);

            }

            // Сохраняем итоги
            nn_init.WriteNeurons(neurons).GetAwaiter().GetResult();
            Console.WriteLine("Готово.");
            Console.ReadLine();
            
        }



    }
}
