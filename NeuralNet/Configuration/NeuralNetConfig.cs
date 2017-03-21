using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NeuralNet.Configuration
{
    /// <summary>
    /// Represents all of the configuration options for a neural network
    /// </summary>
    public class NeuralNetConfig
    {
        public double[][] Input { get; set; }
        public double[][] Output { get; set; }
        public int InputNeuronCount { get; set; }
        public int HiddenNeuronCount { get; set; }
        public int OutputNeuronCount { get; set; }
        public double MaxError { get; set; }
        public double LearningRate { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        private string formatterClass;
        private string formatterAssembly;
        internal NetInputOutputFormatter formatter;

        public string FormatterAssembly
        {
            get { return formatterAssembly; }
            set
            {
                formatterAssembly = value;
                if (FormatterClass != null && FormatterClass != "")
                    GetFormatter();
            }
        }
        public string FormatterClass
        {
            get { return formatterClass; }
            set
            {
                formatterClass = value;
                if (formatterAssembly != null && formatterAssembly != "")
                    GetFormatter();
            }
        }

        private void GetFormatter()
        {
            Assembly.Load(FormatterAssembly);
            formatter = (NetInputOutputFormatter)Activator.CreateInstance(FormatterAssembly, FormatterClass).Unwrap();
        }
    }
}

