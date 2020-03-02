using System;
using System.Diagnostics;

namespace TextAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "test.txt";
            FileContent file = new FileContent(filename);
            Iterator chars = file.CharIterator();
            Iterator words = file.WordIterator();
            StatisticalAnalysis statForChars = new StatisticalAnalysis(chars);
            StatisticalAnalysis statForWords = new StatisticalAnalysis(words);
            bool notQuitted = true;
            string answer;
            var watch = new Stopwatch();

            while (notQuitted)
            { 
                View.Print($"You are currently viewing file {filename}. What do you want to do?");
                View.PrintMenu();
                answer = Console.ReadLine();
                Console.Clear();
                if (answer == "1")
                {
                    View.Print("Provide file path with an extension: ");
                    filename = Console.ReadLine();
                    watch.Start();
                    file = new FileContent(filename);
                    chars = file.CharIterator();
                    words = file.WordIterator();
                    statForChars = new StatisticalAnalysis(chars);
                    statForWords = new StatisticalAnalysis(words);
                    watch.Stop();
                    View.Print($"Executed in {watch.ElapsedMilliseconds} ms\n");
                }
                else if (answer == "2")
                {
                    watch.Start();
                    View.Print($"There are {statForWords.DictionarySize()} unique words and {statForWords.Size()} words altogether");
                    watch.Stop();
                    View.Print($"Executed in {watch.ElapsedMilliseconds} ms");
                }
                else if (answer == "3")
                {
                    watch.Start();
                    View.Print($"There are {statForChars.DictionarySize()} unique characters and {statForChars.Size()} characters altogether");
                    watch.Stop();
                    View.Print($"Executed in {watch.ElapsedMilliseconds} ms\n");
                }
                else
                {
                    View.Print("Not ready yet");
                }


            }
            Console.ReadKey();

        }
    }
}
