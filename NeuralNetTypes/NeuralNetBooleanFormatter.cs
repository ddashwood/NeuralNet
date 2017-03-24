using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet.Configuration;

namespace NeuralNetTypes
{
    class NeuralNetBooleanFormatter : NetInputOutputFormatter
    {
        private const double high = 0.9, low = 0.1, maxError = 0.1;

        public sealed override string InputToString(double input)
        {
            return HighOrLow(input);
        }

        public override bool TryParse(string s, out double result)
        {
            if (s.Trim().ToUpper() == "H")
            {
                result = high;
                return true;
            }
            if (s.Trim().ToUpper() == "L")
            {
                result = low;
                return true;
            }
            return base.TryParse(s, out result);
        }

        public sealed override string OutputToString(double output)
        {
            return $"{base.OutputToString(output)} [{HighOrLow(output)}]";
        }

        private string HighOrLow(double number)
        {
            // Check if the number is within the maximum error
            // If it is, return a capital H or L
            if (Math.Abs(number - high) <= maxError)
                return "H";
            if (Math.Abs(number - low) <= maxError)
                return "L";

            // Otherwise, return a lower case letter
            return (number >= 0.5 ? "h" : "l");
        }
    }
}
