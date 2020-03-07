using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextAnalyser
{
    class WordIterator : Iterator
    {
        private FileContent File { get; set; }
        private int LastIndex { get; set; }
        private int TextLength { get; set; }


        public WordIterator(FileContent file)
        {
            File = file;
            LastIndex = -1;
            TextLength = File.Content.Length;
        }

        public bool HasNext()
        {
            return (LastIndex < TextLength-1 && Helper.HasNonWhiteChar(File.Content, LastIndex+1));
        }
        public string MoveNext()
        {
            string nextWord;
            int whiteSpaceIndex;
            while (HasNext())
            {
                LastIndex++;
                whiteSpaceIndex = Helper.GetNextWhiteCharIndex(File.Content, LastIndex);
                nextWord = File.Content.Substring(LastIndex, whiteSpaceIndex - LastIndex);
                LastIndex += nextWord.Length;
                if (nextWord.Length > 0)
                return nextWord.ToLower();

            }

            return null;

        }
    }
}
