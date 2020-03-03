using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    static class View
    {
        static public void Print(string toPrint)
        {
            Console.WriteLine(toPrint);
        }

        static public void Print(List<string> toPrint)
        {
            foreach (string value in toPrint)
                Console.WriteLine(value);
        }

        static public void Print(ISet<string> toPrint)
        {
            foreach (string value in toPrint)
                Console.WriteLine(value);
        }

        static public void Print(Dictionary<string, int> toPrint)
        {
            foreach (KeyValuePair<string, int> pair in toPrint)
                Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        static public void PrintMenu()
        {
            Console.WriteLine(" 1) Change file for analyse \n 2) Check word statistics \n 3) Check char statistics \n " +
                "4) Check occurencies of chosen words \n 5) Check occurencies of all words  \n 6) Check occurencies of all chars \n 7) Check words occuring more times than provided number" +
                "\n 8) Quit");
        }
    }
}
