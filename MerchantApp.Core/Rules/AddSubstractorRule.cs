
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Core
{
    public class AddSubstractorRule : IRuleProcessor
    {

        public string Process(string input)
        {
            double sum = 0;
            try
            {
                var inputSymbols = input.ToUpper().ToCharArray();
                var validSymbolList = new List<int>();
                foreach (char inputSymbol in inputSymbols)
                {
                    validSymbolList.Add(Constants.ValidSymbols[inputSymbol]);
                }

                for (int i = 0; i < inputSymbols.Length; i++)
                {
                    if (i < inputSymbols.Length - 1 && validSymbolList[i + 1] > validSymbolList[i])
                    {
                        sum = sum + (validSymbolList[i + 1] - validSymbolList[i]);
                        i++; //SKIP NEXT ITEM
                    }
                    else
                        sum = sum + validSymbolList[i];
                }
            }
            catch
            {
                Console.WriteLine("Rule :" + this.GetType().Name + " failed");
                sum = 0;
                //skip metal value when exception
            }
            return sum.ToString();
        }
    }
}
