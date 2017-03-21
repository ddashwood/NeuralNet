using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    internal class Neuron
    {
        public NeuralFactor Bias { get; set; }
        public double Error { get; set; }
        public Dictionary<NeuronSignal, NeuralFactor> InputSignals { get; } = new Dictionary<NeuronSignal, NeuralFactor>();
        public NeuronSignal OutputSignal { get; set; } = new NeuronSignal();

        public Neuron(double bias)
        {
            Bias = new NeuralFactor(bias);
        }

        // Apply any deltas that were calculated during back-propogation.
        // The input signals and the bias are all checked for deltas to be applied
        public void ApplyLearning()
        {
            foreach (KeyValuePair<NeuronSignal, NeuralFactor> m in InputSignals)
                m.Value.ApplyWeightChange();

            Bias.ApplyWeightChange();
        }

        // Pulse the neuron - process the input signals, and calculate
        // the output signal
        public void Pulse()
        {
            double output = 0;

            foreach (KeyValuePair<NeuronSignal, NeuralFactor> item in InputSignals)
                output += item.Key.Output * item.Value.Weight;

            output += Bias.Weight;

            OutputSignal.Output = Sigmoid(output);
        }

        // Produce a "flattened" value between -1 and +1 based on the input
        private static double Sigmoid(double value)
        {
            return 1 / (1 + Math.Exp(-value));
        }
    }
}
