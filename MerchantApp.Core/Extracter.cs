using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Core
{
    public class Extracter
    {
        public static string[] CleanQuestionString(string inputString)
        {
            List<string> validSymbols = new List<string>();
            var inputSymbols = inputString.ToUpper().Split(' ');
            foreach (string inputSymbol in inputSymbols)
            {
                if (Constants.ValidSymbolAliases.ContainsKey(inputSymbol))
                    validSymbols.Add(inputSymbol);

                if (Constants.ValidMetalValues.ContainsKey(inputSymbol))
                    validSymbols.Add(inputSymbol);

            }
            return validSymbols.ToArray();
        }

        public static string GetSymbolString(string[] inputArray)
        {
            string strSymbolString = string.Empty;
            foreach (string inputSymbol in inputArray)
            {
                if (Constants.ValidSymbolAliases.ContainsKey(inputSymbol))
                    strSymbolString = strSymbolString + Constants.ValidSymbolAliases[inputSymbol].ToString();
            }
            return strSymbolString;
        }

        public static double GetMetalValue(string[] symbolStringRaw)
        {
            double metalValue = 1; //metal value should not affect result
            foreach (string inputSymbol in symbolStringRaw)
            {
                if (Constants.ValidMetalValues.ContainsKey(inputSymbol))
                    metalValue = metalValue * Constants.ValidMetalValues[inputSymbol];
            }
            return metalValue;
        }
    }
}
