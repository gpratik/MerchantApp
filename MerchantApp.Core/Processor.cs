using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Core
{
    public class Processor
    {
        private readonly List<IRuleProcessor> _lstRules = new List<IRuleProcessor>()
                            {
                                new RepeatSymbolRule(),
                                new AddSubstractorRule()
                            };
        public Processor(List<IRuleProcessor> lstRules = null)
        {
            if (lstRules != null)
                _lstRules = lstRules;

        }
        public double Solve(string[] symbolStringRaw)
        {
            double problemResult = 0;
            string symbolString = Extracter.GetSymbolString(symbolStringRaw);
            double metalValue = Extracter.GetMetalValue(symbolStringRaw);
            foreach(IRuleProcessor irp in _lstRules)
            {
                var result = irp.Process(symbolString);
                if (string.IsNullOrEmpty(result))
                    return 0;
                if (double.TryParse(result, out problemResult))
                {
                    problemResult = double.Parse(result);
                    if (problemResult > 0)
                    {
                        //Include Metal values
                        return problemResult * metalValue;
                    }
                }
            }
            return problemResult;

        }
    }
}
