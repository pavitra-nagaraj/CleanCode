using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace PredictionEngine
{
    public class PredictionEngine
    {
        private ILanguageModelAlgo lagAlgo;
        public PredictionEngine(ILanguageModelAlgo lagAlgo)
        {
            this.lagAlgo = lagAlgo;
        }
 
        public string predict(string input)
        {
            var words = input.Trim().Split(" ");
            var lastWord = words[^1];
 
            if (input.EndsWith(" "))
            {
                return lagAlgo.predictUsingBigram(lastWord);
            }
            else
            {
                return lagAlgo.predictUsingMonogram(lastWord);
            }
        }
    }
}