
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantApp.Core
{
    public class RepeatSymbolRule : IRuleProcessor
    {
        private readonly List<Regex> Regexes = new List<Regex>()
                        {
                            new Regex("([I,X,C,M])\\1{3,}"),// 3 times repeat 
                            new Regex("([D,L,V])\\1{1,}") //more than 1 time repeat                                          
                        };
        public RepeatSymbolRule(List<Regex> regexes = null)
        {
            if(regexes != null)
            {
                Regexes = regexes;
            }
        }
        public string Process(string input)
        {
            foreach(Regex regx in Regexes)
            {
                Match match = regx.Match(input);
                if (match.Success)
                {
                    Console.WriteLine("Rule :" + this.GetType().Name + " voilated");
                    return string.Empty;
                }

            }
            return input;
        }
    }
}
