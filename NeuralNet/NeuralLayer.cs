using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    // Represents a layer in a neural net.
    internal class NeuralLayer : List<Neuron>
    {
        // Apply learning to each neuron in the layer
        public void ApplyLearning()
        {
            foreach (Neuron neuron in this)
                neuron.ApplyLearning();
        }

        // Pulse each neuron in the layer
        public void Pulse()
        {
            foreach (Neuron neuron in this)
                neuron.Pulse();
        }
    }
}
