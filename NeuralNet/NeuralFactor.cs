using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    // Represents the weight of an input into a neuron
    internal class NeuralFactor
    {
        // Create a NeuralFactor class that represents
        // the weight of an input into a neuron
        public NeuralFactor(double weight)
        {
            Weight = weight;
            Delta = 0;
        }

        public double Weight { get; set; }
        public double Delta { get; set; }

        // Apply the delta to the factor's weight
        public void ApplyWeightChange ()
        {
            Weight += Delta;
            Delta = 0;
        }
    }
}
