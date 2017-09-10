using MerchantApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApp
{
    class Program
    {
       //Comments are intentionally not included : will update when free time available
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("The conversion between intergalactic units and roman numerals");
                Console.WriteLine("Merchant's Guide: Enter valid string to process.");
                string strInput = Console.ReadLine();
                                
                string[] cleanQuestion = Extracter.CleanQuestionString(strInput);
                if (cleanQuestion.Length < 1) throw new Exception(); //Avoid unnesessary execution further
                else
                {
                    //Proceessor is not complete (partially solved)
                    Processor processor = new Processor();
                    double ans = processor.Solve(cleanQuestion);
                    Console.WriteLine(string.Format("{0} is {1} credits", string.Join(" ", cleanQuestion), ans.ToString()));
                }
            }
            catch
            {
                Console.WriteLine("I have no idea what you are talking about");
            }
            Console.Read();
        }
        
    }

}
