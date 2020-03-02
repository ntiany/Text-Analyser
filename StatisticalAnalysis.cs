using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalyser
{
    class StatisticalAnalysis
    {
        private Iterator StatisticalIterator { get; set; }
        public Dictionary<string, int> Occurencies { get; private set; }
        public StatisticalAnalysis(Iterator iterator)
        {
            StatisticalIterator = iterator;
            Occurencies = new Dictionary<string, int>();
            CountOccurencies();
        }

        private void CountOccurencies()
        {
            string next;
            while (StatisticalIterator.HasNext())
            {
                next = StatisticalIterator.MoveNext();
                if (Occurencies.ContainsKey(next))
                {
                    Occurencies[next] += 1;
                }
                else
                {
                    Occurencies[next] = 1;
                }
            }
        }

        public int CountOf(params string[] words)
        {
            int occurencies = 0;
            foreach (string word in words)
            {
                occurencies += Occurencies[word];
            }

            return occurencies;

        }

        public int DictionarySize()
        {
            return Occurencies.Count;
        }

        public int Size()
        {
            int occurencies = 0;
            foreach (KeyValuePair<string, int> record in Occurencies)
            {
                occurencies += record.Value;
            }
            return occurencies;
        }

        public ISet<string> OccurMoreThan(int times)
        {

            return new HashSet<string>(Occurencies.Where(x => x.Value > times).Select(x => x.Key));
        }
    }
}

