using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantApp.Core;

namespace MerchantApp.Tests
{
    [TestClass]
    public class MerchantApp
    {
        [TestMethod]
        public void Test_ValidSymbolValues()
        {
            Assert.AreEqual(1.0, (double)Constants.ValidSymbols['I']);
            Assert.AreEqual(5.0, (double)Constants.ValidSymbols['V']);
            Assert.AreEqual(10.0, (double)Constants.ValidSymbols['X']);
            Assert.AreEqual(50.0, (double)Constants.ValidSymbols['L']);
            Assert.AreEqual(100.0, (double)Constants.ValidSymbols['C']);
            Assert.AreEqual(500.0, (double)Constants.ValidSymbols['D']); ;
            Assert.AreEqual(1000.0, (double)Constants.ValidSymbols['M']);
        }

        [TestMethod]
        public void Test_ValidMetalValues()
        {
            Assert.AreEqual(14450.0, (double)Constants.ValidMetalValues["GOLD"]);
            Assert.AreEqual(195.5, (double)Constants.ValidMetalValues["IRON"]);
            Assert.AreEqual(17.0, (double)Constants.ValidMetalValues["SILVER"]);
        }

        [TestMethod]
        public void Test_ValidInputSolvers()
        {
            Processor processor = new Processor();
            string inputValid1 = "how much is pish tegj glob glob ?";
            double resultValid1 = 42.0;

            string inputValid2 = "how many Credits is glob prok Silver ?";
            double resultValid2 = 68.0;

            Assert.AreEqual(resultValid1, processor.Solve(Extracter.CleanQuestionString(inputValid1)));
            Assert.AreEqual(resultValid2, processor.Solve(Extracter.CleanQuestionString(inputValid2)));
        }
        [TestMethod]
        public void Test_InValidInputSolvers()
        {
            Processor processor = new Processor();
            string inputValid1 = "how much is pish tegj glob glob glob glob ?"; //more than 3 repeat
            double resultValid1 = 0.0;

            string inputValid2 = "how many Credits is tegj tegj prok Silver ?"; //more than 1 repeat
            double resultValid2 = 0.0;

            string inputValid3 = "how many woods you want ok ?"; //nothing cool
            double resultValid3 = 0.0;

            Assert.AreEqual(resultValid1, processor.Solve(Extracter.CleanQuestionString(inputValid1)));
            Assert.AreEqual(resultValid2, processor.Solve(Extracter.CleanQuestionString(inputValid2)));
            Assert.AreEqual(resultValid3, processor.Solve(Extracter.CleanQuestionString(inputValid3)));

        }

        [TestMethod]
        public void Test_ValidAddSubstractRule()
        {
            AddSubstractorRule rule = new AddSubstractorRule();
            string inputValid1 = "MCMXLIV";
            double resultValid1 = 1944.0;
            double result1 = Convert.ToDouble(rule.Process(inputValid1));

            string inputValid2 = "MMVI";
            double resultValid2 = 2006.0;
            double result2 = Convert.ToDouble(rule.Process(inputValid2));

            Assert.AreEqual(resultValid1, result1);
            Assert.AreEqual(resultValid2, result2);
        }


        [TestMethod]
        public void Test_RepeatSymbolRule()
        {
            RepeatSymbolRule rule = new RepeatSymbolRule();
            string inputValid1 = "MMMMXLIV"; //3 times repeat rule
            double resultValid1 = 0.0;
            double result1 = Convert.ToDouble(rule.Process(inputValid1) == string.Empty ? "0.0" : rule.Process(inputValid1));

            string inputValid2 = "LMLLVI"; // 1 time repeat rule
            double resultValid2 = 0.0;
            double result2 = Convert.ToDouble(rule.Process(inputValid2) == string.Empty? "0.0" : rule.Process(inputValid2));

            Assert.AreEqual(resultValid1, result1);
            Assert.AreEqual(resultValid2, result2);

        }


    }
}
