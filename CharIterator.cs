using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class CharIterator : Iterator
    {
        private FileContent File { get; set; }
        private int LastIndex { get; set; }
        private long TextLength { get; set; }

        public CharIterator(FileContent file)
        {
            File = file;
            LastIndex = -1;
            TextLength = File.Content.Length;
        }

        public bool HasNext()
        {
            return (LastIndex < TextLength-1 && Helper.HasNonWhiteChar(File.Content, LastIndex + 1));
        }
        public string MoveNext()
        {
            while (HasNext())
            {
                LastIndex++;
                if (!Char.IsWhiteSpace(File.Content[LastIndex]))
                    return File.Content[LastIndex].ToString().ToLower();

            }

            return null;
        }
    }
}
