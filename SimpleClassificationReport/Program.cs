using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassificationReport
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {

            var inputList = new List<InputData>();
            for (int i = 0; i < 10000; i++)
            {
                var rc = RandomClass("ABCDEFG");
                inputList.Add(new InputData
                {
                    Confidence = random.NextDouble(),
                    Example = RandomString(random.Next(20, 40)),
                    ExpectedLabel = rc,
                    Label = random.Next(10) < 2 ? rc : RandomClass("ABCDEFG")
                });
            }
            var report = Analyser.Analyse(inputList);

            Console.WriteLine(report.ToString());
            Console.ReadKey();

        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomClass(string chars)
        {
            return new string(Enumerable.Repeat(chars, 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
