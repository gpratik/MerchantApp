using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Core
{
    public class Constants
    {        

        public static Dictionary<char, int> ValidSymbols = new Dictionary<char, int>
                                {
                                    {'I', 1},{'V', 5},{'X', 10},{'L', 50},{'C', 100},{'D', 500},{'M', 1000}
                                };
        public static Dictionary<string, char> ValidSymbolAliases = new Dictionary<string, char>
                                {
                                    {"GLOB", 'I'},{"PROK", 'V'},{"PISH", 'X'},{"TEGJ", 'L'}
                                };        
        public static Dictionary<string, double> ValidMetalValues = new Dictionary<string, double>
                                {
                                    {"SILVER",17 }, { "GOLD",14450}, { "IRON",195.5}
                                };
    }
}
