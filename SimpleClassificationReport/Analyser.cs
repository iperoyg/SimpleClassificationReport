using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassificationReport
{
    public static class Analyser
    {

        public static Report Analyse(List<InputData> input)
        {
            var labels = input.Select(i => i.ExpectedLabel).Distinct().ToList();
            var confusionMatrixDict = new Dictionary<string, SimpleConfusionMatrix>();
            foreach (var label in labels)
            {
                // label = classe alvo
                var cm = new SimpleConfusionMatrix()
                {
                    // True positives => A classe esperada é a mesma que a classe rotulada e que a classe alvo
                    TruePositive = input.Count(i => i.ExpectedLabel == label && i.Label == label),
                    // True negative => A classe esperada e a classe rotulada são diferentes da classe alvo
                    TrueNegative = input.Count(i => i.ExpectedLabel != label && i.Label != label),
                    // False Positive => A classe esperada é diferente da alvo e a classe rotulada é igual a alvo.
                    FalsePositive = input.Count(i => i.ExpectedLabel != label && i.Label == label),
                    // False Negative => A classe esperada é igual a alvo e a classe rotulada é diferente da alvo.
                    FalseNegative = input.Count(i => i.ExpectedLabel == label && i.Label != label)
                };
                confusionMatrixDict.Add(label, cm);
            }

            
            var trueSetIntersetPredictSetTotal = confusionMatrixDict.Select(cm => cm.Value.TruePositive).Sum();
            var trueSetUnionPredictSetTotal = input.Count + confusionMatrixDict.Select(cm => cm.Value.FalsePositive).Sum();
            var hammingScore = trueSetIntersetPredictSetTotal/ trueSetUnionPredictSetTotal;

            return new Report
            {
                ConfusionMatrixDictionary = confusionMatrixDict,
                HammingScore = hammingScore,
                InputData = input
            };

        }

    }
}
