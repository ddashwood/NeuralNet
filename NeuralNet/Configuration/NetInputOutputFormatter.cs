using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Configuration
{
    /// <summary>
    /// Represents an object that can convert neural network signals (doubles
    /// from 0-1) into something human-readable that's applicable for the
    /// specific neural net task
    /// </summary>
    public class NetInputOutputFormatter
    {
        /// <summary>
        /// Converts input data to a string.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The input value, converted to text in the appropriate format.</returns>
        public virtual string InputToString(double input)
        {
            return $"{input:0.000}";
        }

        /// <summary>
        /// Converts a string into a double that can be used as input to the neural network.
        /// </summary>
        /// <param name="s">The string to be converted.</param>
        /// <param name="result">A doulbe that can be used as input to the nueral network.</param>
        /// <returns>True if successful, otherwise false</returns>
        public virtual bool TryParse(string s, out double result)
        {
            result = 0d;

            if (!double.TryParse(s, out result))
                return false;

            if (result < 0d || result > 1d)
            {
                result = 0d;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Converts output data to a string.
        /// </summary>
        /// <param name="output">The input value.</param>
        /// <returns>The output value, converted to text in the appropriate format.</returns>
        public virtual string OutputToString(double output)
        {
            return $"{output:0.000}";
        }
    }
}
