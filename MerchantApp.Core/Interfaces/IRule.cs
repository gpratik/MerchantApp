using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp.Core
{
    public interface IRuleProcessor
    {
        string Process(string input);
    }
}
