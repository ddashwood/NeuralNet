using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet.Configuration;

namespace NeuralNetTypes
{
    internal class NeuralNetSquareFormatter : NetInputOutputFormatter
    {
        public sealed override string InputToString(double input)
        {
            return $"{input * 10:0.0}";
        }

        public sealed override string OutputToString(double output)
        {
            return $"{output * 100:0.00}";
        }

        public override bool TryParse(string s, out double result)
        {
            result = 0d;

            if (!double.TryParse(s, out result))
                return false;

            result /= 10; // User types a number from 0-10, we convert it to 0-1

            if (result < 0d || result > 1d)
            {
                result = 0d;
                return false;
            }

            return true;
        }
    }
}
