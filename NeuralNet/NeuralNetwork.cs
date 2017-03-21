using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    // Represents a neural network.
    // Initially, the network will be set with random weight factors.
    // It can then be trained using back propogation.
    internal class NeuralNetwork
    {
        private double learningRate;
        private Random rand;

        public NeuralLayer InputLayer { get; set; }
        public NeuralLayer HiddenLayer { get; set; }
        public NeuralLayer OutputLayer { get; set; }

        // Create a neural net, optionally specifying a seed for the Random object.
        // This can be useful for using the same seed repeatedly to get repeated
        //identical results.
        public NeuralNetwork(int inputNeuronCount, int hiddenNeuronCount, int outputNeuronCount, double learningRate, int? randomSeed = null)
        {
            rand = randomSeed.HasValue ? new Random(randomSeed.Value) : new Random();

            this.learningRate = learningRate;

            InputLayer = new NeuralLayer();
            HiddenLayer = new NeuralLayer();
            OutputLayer = new NeuralLayer();

            // Create the neurons for each layer
            for (int i = 0; i < inputNeuronCount; i++)
                InputLayer.Add(new Neuron(0)); // Input neurons do not have a bias

            for (int i = 0; i < hiddenNeuronCount; i++)
                HiddenLayer.Add(new Neuron(rand.NextDouble())); // A random bias, will be improved during training

            for (int i = 0; i < outputNeuronCount; i++)
                OutputLayer.Add(new Neuron(rand.NextDouble())); // A random bias, will be improved during training

            // Wire up the input layer to the hidden layer
            for (int i = 0; i < hiddenNeuronCount; i++)
                for (int j = 0; j < inputNeuronCount; j++)
                    HiddenLayer[i].InputSignals.Add(InputLayer[j].OutputSignal, new NeuralFactor(CalcInitWeight(inputNeuronCount)));

            // Wire up the hidden layer to the output layer
            for (int i = 0; i < outputNeuronCount; i++)
                for (int j = 0; j < hiddenNeuronCount; j++)
                    OutputLayer[i].InputSignals.Add(HiddenLayer[j].OutputSignal, new NeuralFactor(CalcInitWeight(hiddenNeuronCount)));
        }


        // Apply learning to each layer in the network
        public void ApplyLearning()
        {
            HiddenLayer.ApplyLearning();
            OutputLayer.ApplyLearning();
        }

        // Pulse each layer in the network
        public void Pulse()
        {
            HiddenLayer.Pulse();
            OutputLayer.Pulse();
        }

        // Train the net using an array of sets of inputs,
        // and an array of sets of desired outputs
        public void Train(double[][] inputs, double[][] desiredResults)
        {
            for (int i = 0; i < inputs.Length; i++)
                Train(inputs[i], desiredResults[i]);
        }

        #region Private methods
        // Pick a random weight for an input signal, between
        // -1/sqrt(c) and 1/sqrt(c) where c is the number of input neurons
        // <returns>A random weight</returns>
        private double CalcInitWeight(int inputNeuronCount)
        {
            double initWeight = rand.NextDouble() / Math.Sqrt(inputNeuronCount);
            initWeight = (initWeight * 2) - initWeight;
            return initWeight;
        }

        // Apply back propogation to the network
        private void BackPropogation(double[] desiredResults)
        {
            // Output layer errors
            for (int i = 0; i < OutputLayer.Count; i++)
            {
                double temp = OutputLayer[i].OutputSignal.Output;
                OutputLayer[i].Error = (desiredResults[i] - temp) * temp * (1.0 - temp);
            }

            // Hidden layer errors
            foreach (Neuron hiddenNode in HiddenLayer)
            {
                double error = 0;

                foreach (Neuron outputNode in OutputLayer)
                {
                    error += outputNode.Error * outputNode.InputSignals[hiddenNode.OutputSignal].Weight * hiddenNode.OutputSignal.Output * (1.0 - hiddenNode.OutputSignal.Output);
                }
                hiddenNode.Error = error;
            }

            // Adjust output layer weight change
            foreach (Neuron outputNode in OutputLayer)
            {
                foreach (Neuron hiddenNode in HiddenLayer)
                    outputNode.InputSignals[hiddenNode.OutputSignal].Delta += learningRate * outputNode.Error * hiddenNode.OutputSignal.Output;

                outputNode.Bias.Delta += learningRate * outputNode.Error * outputNode.Bias.Weight;
            }

            // Adjust hidden layer weight change
            foreach (Neuron hiddenNode in HiddenLayer)
            {
                foreach (Neuron inputNode in InputLayer)
                    hiddenNode.InputSignals[inputNode.OutputSignal].Delta += learningRate * hiddenNode.Error * inputNode.OutputSignal.Output;

                hiddenNode.Bias.Delta += learningRate * hiddenNode.Error * hiddenNode.Bias.Weight;
            }
        }

        // Train the net using a single set of inputs and desired outputs
        private void Train(double[] input, double[] desiredResult)
        {
            if (input.Length != InputLayer.Count)
                throw new ArgumentException($"Expeted {InputLayer.Count} inputs");
            if (desiredResult.Length != OutputLayer.Count)
                throw new ArgumentException($"Expected {OutputLayer.Count} outputs");

            // Set the input nodes
            for (int i = 0; i < InputLayer.Count; i++)
            {
                Neuron neuron = InputLayer[i];
                neuron.OutputSignal.Output = input[i];
            }

            // Then pulse, and learn
            Pulse();
            BackPropogation(desiredResult);
            ApplyLearning();
        }
        #endregion

    }
}
