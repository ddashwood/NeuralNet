using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Configuration
{
    /// <summary>
    /// Represents a task for the neural network to carry out.
    /// This is an abstract class.
    /// Extend this class to create a task for the neural network to perform.
    /// Override the abstract properties to set the parameters for the task.
    /// </summary>
    public abstract class NeuralNetTask
    {
        private const int IterationsPerUpdate = 100;
        private NeuralNetwork net;
        private bool trained;

        /// <summary>
        /// Initialises a new instance of the NeuralNetTask class, using protected properties
        /// to get the required parameters.
        /// </summary>
        protected NeuralNetTask(NetInputOutputFormatter formatter = null)
        {
            net = new NeuralNetwork(InputNeuronCount, HiddenNeuronCount, OutputNeuronCount, LearningRate);
            InputOutputFormatter = formatter??new NetInputOutputFormatter();
            trained = false;
        }

        /// <summary>
        /// Initialises a new instance of the NeuralNetTask class.
        /// </summary>
        /// <param name="inputNeuronCount">The number of input neurons.</param>
        /// <param name="hiddenNeuronCount">The number of hidden nuerons.</param>
        /// <param name="outputNeuronCount">The number of output neurons.</param>
        /// <param name="learningRate">The learning rate.</param>
        protected NeuralNetTask(int inputNeuronCount, int hiddenNeuronCount,
            int outputNeuronCount, double learningRate, NetInputOutputFormatter formatter = null)
        {
            net = new NeuralNetwork(inputNeuronCount, hiddenNeuronCount, outputNeuronCount, learningRate);
            InputNeuronCount = inputNeuronCount;
            HiddenNeuronCount = hiddenNeuronCount;
            OutputNeuronCount = outputNeuronCount;
            LearningRate = learningRate;
            InputOutputFormatter = formatter??new NetInputOutputFormatter();
            trained = false;
        }

        /// <summary>
        /// Occurs when there is a message to display to the user.
        /// </summary>
        public event MessageEventHandler Message;

        /// <summary>
        /// Gets the number of input neurons.
        /// </summary>
        public virtual int InputNeuronCount { get; private set; }
        /// <summary>
        /// Gets the number of hidden neurons.
        /// </summary>
        protected virtual int HiddenNeuronCount { get; private set; }
        /// <summary>
        /// Gets the number of output neurons.
        /// </summary>
        public virtual int OutputNeuronCount { get; private set; }
        
        /// <summary>
        /// Gets the set of inputs for training.
        /// </summary>
        protected abstract double[][] Input { get; }
        /// <summary>
        /// Gets the set of desired results for training.
        /// </summary>
        protected abstract double[][] Output { get; }
        /// <summary>
        /// Gets the maximum allowable error in the outputs. Used to
        /// determine when training is complete.
        /// </summary>
        protected abstract double MaxError { get; }
        /// <summary>
        /// Gets the learning rate for this task.
        /// </summary>
        protected virtual double LearningRate { get; private set; }

        /// <summary>
        /// Gets a description of the task
        /// </summary>
        public virtual string Description
        {
            get { return Descriptions.TaskDescription; }
        }

        /// <summary>
        /// Gets an object for formatting input and output
        /// </summary>
        public NetInputOutputFormatter InputOutputFormatter { get; private set; }

        /// Raise an event containing the message
        private void SendMessage(string message)
        {
            Message?.Invoke(this, new MessageEventArgs(message));
        }

        /// <summary>
        /// Train the network to perofrm the task
        /// </summary>
        /// <param name="maxIterationsThousands">The maximum iterations, in thousands.
        /// If not specified, training will continue indefinitely until the desired accuracy is reached
        /// </param>
        public void Train(long? maxIterationsThousands = null)
        {
            long count = 0;
            bool done;
            string values;

            do
            {
                count++; // The count needs to be multiplied by 100 to get the number of iterations so far

                // Train the network 100 times.
                // Each time, the Train method will iterate through each set of inputs and outputs
                for (int i = 0; i < IterationsPerUpdate; i++)
                    net.Train(Input, Output);

                // See if we are sufficiently accurate
                done = CheckResults(out values);
                // Send a message showing the current output values for each set of input values
                SendMessage($"After {count * IterationsPerUpdate} iterations:");
                SendMessage(values);
            } while (!done && (!maxIterationsThousands.HasValue || count * IterationsPerUpdate < maxIterationsThousands*1000));

            if (done)
                SendMessage($"{count * IterationsPerUpdate} iterations to train");
            else
                SendMessage("Maximum iterations reached");

            trained = true;
        }

        /// <summary>
        /// Sends inputs to a trained neural network and gets it to calculate the outputs.
        /// </summary>
        /// <param name="inputs">An arry of input data.</param>
        /// <returns>An array of output data.</returns>
        public double[] Calculate(double[] inputs)
        {
            if (!trained) throw new ApplicationException("The network must be trained before it can be used");

            for (int i = 0; i < InputNeuronCount; i++)
            {
                if (inputs[i] < 0 || inputs[i] > 1) throw new ApplicationException("Inputs must be between 0 and 1");
                net.InputLayer[i].OutputSignal.Output = inputs[i];
            }

            net.Pulse();

            double[] outputs = new double[OutputNeuronCount];
            for (int i = 0; i < OutputNeuronCount; i++)
            {
                outputs[i] = net.OutputLayer[i].OutputSignal.Output;
            }

            return outputs;
        }


        // Checks whether the outputs are close enough to the desired outputs.
        // Whilst iterating through the training data, we also build a message for the user
        // showing the current set of outputs for each set of inputs
        private bool CheckResults(out string message)
        {
            // Assume success. If we find any data point that is not accurate enough,
            // we will change this to false.
            bool success = true;

            // Used to build the message for the user
            StringBuilder thisMessage = new StringBuilder();

            // For each set of training data
            for (int i = 0; i < Input.Length; i++)
            {
                if (i > 0) thisMessage.Append(", ");
                thisMessage.Append("(");

                // Set inputs, and add the inputs to the message
                for (int j = 0; j < InputNeuronCount; j++)
                {
                    net.InputLayer[j].OutputSignal.Output = Input[i][j];

                    if (j != 0) thisMessage.Append(",");
                    thisMessage.Append(InputOutputFormatter.InputToString(Input[i][j]));
                }

                // Pulse
                net.Pulse();

                thisMessage.Append("=>");

                // Check outputs, and add the outputs to the message
                for (int j = 0; j < OutputNeuronCount; j++)
                {
                    double actual = net.OutputLayer[j].OutputSignal.Output;
                    double desired = Output[i][j];
                    if (Math.Abs(actual - desired) > MaxError) success = false;

                    if (j != 0) thisMessage.Append(",");
                    thisMessage.Append(InputOutputFormatter.OutputToString(actual));
                }

                thisMessage.Append(")");
            }

            message = thisMessage.ToString();
            return success;
        }
    }

    /// <summary>
    /// Represents event data, including a message.
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        internal MessageEventArgs(string message)
        {
            Message = message;
        }

        /// <summary>
        /// The message.
        /// </summary>
        public string Message { get; private set; }
    }

    /// <summary>
    /// Represents the event handler for an event that passes a message.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event arguments.</param>
    public delegate void MessageEventHandler(object sender, MessageEventArgs e);
}
