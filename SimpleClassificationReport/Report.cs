using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassificationReport
{
    public class Report
    {
        public Dictionary<string,SimpleConfusionMatrix> ConfusionMatrixDictionary { get; set; }
        public double HammingScore { get; set; }
        public List<InputData> InputData{ get; set; }

        public (double, double, double, double) PRAFScore
        {
            get => (
                Math.Round(ConfusionMatrixDictionary.Sum(cm => cm.Value.Precision / (double) ConfusionMatrixDictionary.Keys.Count),2),
                Math.Round(ConfusionMatrixDictionary.Sum(cm => cm.Value.Recall / (double)ConfusionMatrixDictionary.Keys.Count), 2),
                Math.Round(ConfusionMatrixDictionary.Sum(cm => cm.Value.Accuracy / (double)ConfusionMatrixDictionary.Keys.Count), 2),
                Math.Round(ConfusionMatrixDictionary.Sum(cm => cm.Value.FScore / (double)ConfusionMatrixDictionary.Keys.Count),2)
                );
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Total Examples: {InputData.Count}\n");
            sb.Append($"Total Classes: {ConfusionMatrixDictionary.Keys.Count}\n");
            sb.Append($"---------------------------------------------------------\n");
            sb.Append($"Hamming Score: {Math.Round(HammingScore,2)}\n");
            (var precision, var recall, var accuracy, var fscore) = PRAFScore;
            sb.Append($"Precision: {precision}\n");
            sb.Append($"Recall: {recall}\n");
            sb.Append($"Accuracy: {accuracy}\n");
            sb.Append($"FScore: {fscore}\n\n");
            foreach (var cm in ConfusionMatrixDictionary)
            {

                sb.Append($"---------------------------------------------------------\n");
                sb.Append($"Label: {cm.Key}\n");
                sb.Append($"\t{cm.Value.TruePositive}\t{cm.Value.FalsePositive}\n");
                sb.Append($"\t{cm.Value.FalseNegative}\t{cm.Value.TrueNegative}\n");
                sb.Append($"Resume: {cm.Value.ToString()}\n");
                sb.Append($"---------------------------------------------------------\n\n");

            }
            return sb.ToString();
        }

    }
}
