using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class CharIterator : Iterator
    {
        private FileContent File { get; set; }
        private int LastIterator { get; set; }
        private long TextLength { get; set; }

        public CharIterator(FileContent file)
        {
            File = file;
            LastIterator = -1;
            TextLength = File.Content.Length;
        }

        public bool HasNext()
        {
            return (LastIterator < TextLength-1 && Helper.HasNonWhiteChar(File.Content, LastIterator + 1));
        }
        public string MoveNext()
        {
            while (HasNext())
            {
                LastIterator++;
                if (!Char.IsWhiteSpace(File.Content[LastIterator]))
                    return File.Content[LastIterator].ToString().ToLower();

            }

            return null;
        }
    }
}
