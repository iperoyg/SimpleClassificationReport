using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassificationReport
{
    public class SimpleConfusionMatrix
    {
        public double TruePositive { get; set; }
        public double TrueNegative { get; set; }
        public double FalsePositive { get; set; }
        public double FalseNegative { get; set; }

        public double Total { get => TruePositive + TrueNegative + FalsePositive + FalseNegative; }
        public double Precision { get => Math.Round(TruePositive / (TruePositive + FalsePositive),2); }
        public double Recall { get => Math.Round(TruePositive / (TruePositive + FalseNegative), 2); }
        public double Accuracy { get => Math.Round((TruePositive + TrueNegative) / (Total), 2); }
        public double FScore { get => Math.Round(( 2 * TruePositive ) / (2 * TruePositive + FalsePositive + FalseNegative), 2); }

        public override string ToString()
        {
            return $"P: {Precision}; R: {Recall}; A: {Accuracy}; F: {FScore}\n";
        }
    }
}
