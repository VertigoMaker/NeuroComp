using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using NeuronNetwork.Neurons;
using NeuronNetwork.Functions;
using System.IO;
using System.Text.Json;

namespace NeuronNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseNeuron> neurons = ReadNeurons().GetAwaiter().GetResult();

            foreach(BaseNeuron neuron in neurons)
            {
                //neuron.RandomWeights();
                neuron._function = new LinearFunction();
                Console.WriteLine(neuron.CalculateOutput());
            }

            WriteNeurons(neurons).GetAwaiter().GetResult();
            Console.WriteLine("Готово.");
            Console.ReadLine();
        }


        static async Task WriteNeurons(List<BaseNeuron> neurons)
        {
            using FileStream createStream = File.Create("../../../Output/NeuronList.json");
            await JsonSerializer.SerializeAsync(createStream, neurons);
            await createStream.DisposeAsync();
            Console.WriteLine("[JSON] Входные данные сохранены");
        }
        static async Task<List<BaseNeuron>> ReadNeurons()
        {
            using FileStream createStream = File.OpenRead("../../../Input/NeuronList.json");
            List<BaseNeuron> result_neurons = await JsonSerializer.DeserializeAsync<List<BaseNeuron>>(createStream);
            await createStream.DisposeAsync();
            Console.WriteLine("[JSON] Входные данные считаны");
            return result_neurons;
        }
    }
}
