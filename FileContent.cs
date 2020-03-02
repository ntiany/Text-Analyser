using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAnalyser
{
    class FileContent : IterableText
    {
        public string Content { get; private set; }
        private string Path { get; set; }

        public FileContent(string path)
        {
            Path = path;
            Content = File.ReadAllText(path);
        }

        public Iterator CharIterator()
        {
            Iterator iterator = new CharIterator(this);
            return iterator;
        }

        public Iterator WordIterator()
        {
            Iterator iterator = new WordIterator(this);
            return iterator;
        }

        public string GetFileName()
        {
            string filename = Path.Substring(Path.LastIndexOf('\\') + 1);
            return filename;
        }
    }
}
