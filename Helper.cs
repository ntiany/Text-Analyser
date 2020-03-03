using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    static class Helper
    {
        public static int GetNextWhiteCharIndex(string text, int index)
        {
            while (index < text.Length)
            {
                if (Char.IsWhiteSpace(text[index]))
                    return index;
                else
                    index++;
            }

            return text.Length;
        }

        public static bool HasNonWhiteChar(string text, int index)
        {
            while (index < text.Length)
            {
                if (!Char.IsWhiteSpace(text[index]))
                    return true;
                else
                    index++;
            }

            return false;
        }
    }           
}
