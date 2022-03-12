using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using NeuronNetwork.Neurons;
using NeuronNetwork.NeuronNetworks;


namespace NeuronNetwork.Initialize
{
    class NeuronNNInitializer
    {
        private static NeuronNNInitializer _instance;
        private NeuronNNInitializer()
        {

        }
        public static NeuronNNInitializer GetInstance()
        {
            if (_instance is null)
                _instance = new NeuronNNInitializer();
            return _instance;
        }

        public async Task WriteNeurons(List<BaseNeuron> neurons)
        {
            using FileStream createStream = File.Create("../../../Output/NeuronList.json");
            List<BaseNeuronDto> result_neurons = new List<BaseNeuronDto>();

            foreach(BaseNeuron bn in neurons)
            {
                result_neurons.Add(new BaseNeuronDto(bn));
            }

            await JsonSerializer.SerializeAsync(createStream, result_neurons);
            await createStream.DisposeAsync();
            Console.WriteLine("[JSON] Входные данные сохранены.");
        }
        public async Task<List<BaseNeuron>> ReadNeurons()
        {
            using FileStream createStream = File.OpenRead("../../../Input/NeuronList.json");
            List<BaseNeuronDto> json_neurons = await JsonSerializer.DeserializeAsync<List<BaseNeuronDto>>(createStream);
            await createStream.DisposeAsync();

            List<BaseNeuron> result_neurons = new List<BaseNeuron>();

            foreach(BaseNeuronDto bnd in json_neurons)
            { 
                try
                {
                    bnd.SetNeuronFunction();
                    result_neurons.Add(bnd._base_neuron);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            Console.WriteLine("[JSON] Входные данные считаны.");
            return result_neurons;
        }
    }
}
