using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace NeuralNet.Configuration
{
    /// <summary>
    /// Represents a factory that makes configured neural networks.
    /// Each instance of this class is a factory that makes networks with
    /// a specific configuration. The configuration file is specified
    /// in the constructor.
    /// </summary>
    public class ConfiguredNeuralNetFactory
    {
        private NeuralNetConfig config;

        /// <summary>
        /// Creates an instance of the class, which represents a factory
        /// for a specific configuration file.
        /// </summary>
        /// <param name="filename">The configuration file.</param>
        public ConfiguredNeuralNetFactory(string filename)
        {
            // Load the configuration file
            XmlSerializer ser = new XmlSerializer(typeof(NeuralNetConfig));

            using (StreamReader sr = new StreamReader(filename))
            {
                config = (NeuralNetConfig)ser.Deserialize(sr);
            }
        }

        /// <summary>
        /// The short description of the type of neural net which this
        /// factory generates
        /// </summary>
        public string ShortDescription => config.ShortDescription;

        /// <summary>
        /// Creates a neural network task based on the configuration
        /// of this instane of the factory.
        /// </summary>
        /// <returns>The neural network task.</returns>
        public NeuralNetTask CreateNeuralNet()
        {
            return new ConfiguredNeuralNet(config);
        }
    }
}
