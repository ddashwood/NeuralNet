using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Configuration
{
    /// Represents a fully configured neural network
    internal class ConfiguredNeuralNet : NeuralNetTask
    {
        private NeuralNetConfig config;

        public ConfiguredNeuralNet(NeuralNetConfig config)
            :base(config.InputNeuronCount, config.HiddenNeuronCount,
                 config.OutputNeuronCount, config.LearningRate, config.formatter)
        {
            this.config = config;
        }

        // The virtual/abstract properties from NeuralNetTask
        public override int InputNeuronCount => config.InputNeuronCount;
        public override int OutputNeuronCount => config.OutputNeuronCount;
        protected override int HiddenNeuronCount => config.HiddenNeuronCount;
        protected override double[][] Input => config.Input;
        protected override double[][] Output => config.Output;
        protected override double MaxError => config.MaxError;
        protected override double LearningRate => config.LearningRate;
        public override string Description => config.Description;
    }
}
