using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextAnalyser
{
    class WordIterator : Iterator
    {
        private FileContent File { get; set; }
        private int LastIterator { get; set; }
        private int TextLength { get; set; }


        public WordIterator(FileContent file)
        {
            File = file;
            LastIterator = -1;
            TextLength = File.Content.Length;
        }

        public bool HasNext()
        {
            return (LastIterator < TextLength-1);
        }
        public string MoveNext()
        {
            string nextWord;
            int whiteSpaceIndex;
            while (HasNext())
            {
                LastIterator++;
                whiteSpaceIndex = Helper.GetNextWhiteSpaceIndex(File.Content, LastIterator);
                nextWord = File.Content.Substring(LastIterator, whiteSpaceIndex - LastIterator);
                LastIterator += nextWord.Length;
                if (nextWord.Length > 0)
                return nextWord.ToLower();

            }

            return null;

        }
    }
}
