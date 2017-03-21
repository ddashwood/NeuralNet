using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet.Configuration;

namespace NeuralNetTypes
{
    /// <summary>
    /// Represents a neural network that squares numbers between 0 - 10
    /// </summary>
    public class NeuralNetSquare : NeuralNetTask
    {
        public NeuralNetSquare() :base (new NeuralNetSquareFormatter())
        { }

        public override int InputNeuronCount
        {
            get { return 1; }
        }


        protected override int HiddenNeuronCount
        {
            get { return 10; }
        }

        public override int OutputNeuronCount
        {
            get { return 1; }
        }

        private double[][] input = new double[][]
        {
            new double[] {0.1},
            new double[] {0.2},
            new double[] {0.3},
            new double[] {0.4},
            new double[] {0.5},
            new double[] {0.6},
            new double[] {0.7},
            new double[] {0.8},
            new double[] {0.9}
        };

        protected sealed override double[][] Input
        {
            get { return input; }
        }

        private double[][] output = new double[][]
        {
            new double[] {0.01},
            new double[] {0.04},
            new double[] {0.09},
            new double[] {0.16},
            new double[] {0.25},
            new double[] {0.36},
            new double[] {0.49},
            new double[] {0.64},
            new double[] {0.81}
        };
        protected sealed override double[][] Output
        {
            get { return output; }
        }

        protected sealed override double MaxError
        {
            get { return 0.002; }
        }

        protected override double LearningRate
        {
            get { return 0.7; }
        }

        public sealed override string Description
        {
            get { return Descriptions.SquareDescription; }
        }
    }
}
