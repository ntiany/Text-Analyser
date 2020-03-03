using System;
using System.Diagnostics;
using System.Text;

namespace TextAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string filename = "test_malville_moby.txt";
            FileContent file = new FileContent(filename);
            Iterator chars = file.CharIterator();
            Iterator words = file.WordIterator();
            StatisticalAnalysis statForChars = new StatisticalAnalysis(chars);
            StatisticalAnalysis statForWords = new StatisticalAnalysis(words);
            bool notQuitted = true;
            string answer;
            int occurency = 0;
            bool valid;
            string[] wordsToCheck;
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
                    View.Print($"Executed in {watch.ElapsedMilliseconds} ms \n");
                }
                else if (answer == "3")
                {
                    watch.Start();
                    View.Print($"There are {statForChars.DictionarySize()} unique characters and {statForChars.Size()} characters altogether");
                    watch.Stop();
                    View.Print($"Executed in {watch.ElapsedMilliseconds} ms\n");
                }
                else if (answer == "4")
                {
                    View.Print("Provide words after space");
                    wordsToCheck = Console.ReadLine().Split(" ");
                    watch.Start();
                    View.Print($"These words were repeated {statForWords.CountOf(wordsToCheck)} times \n");
                    watch.Stop();
                    View.Print($"Executed in {watch.ElapsedMilliseconds} ms \n");
                }
                else if (answer == "5")
                {
                    View.Print("The full dictionary of words: ");
                    watch.Start();
                    View.Print(statForWords.Occurencies);
                    watch.Stop();
                    View.Print($"Executed in {watch.ElapsedMilliseconds} ms \n");
                }

                else if (answer == "6")
                {
                    View.Print("The full dictionary of chars: ");
                    watch.Start();
                    View.Print(statForChars.Occurencies);
                    watch.Stop();
                    View.Print($"Executed in {watch.ElapsedMilliseconds} ms \n");
                }

                else if (answer == "7")
                {
                    View.Print("Provide occurency: ");
                    valid = false;
                    while (!valid)
                    {
                        answer = Console.ReadLine();
                        try
                        {
                            occurency = int.Parse(answer);
                            valid = true;
                        }
                        catch
                        {
                            View.Print("Wrong input. Try again");
                        }
                            
                    }
                    watch.Start();
                    View.Print(statForWords.OccurMoreThan(occurency));
                    watch.Stop();
                    View.Print($"Executed in {watch.ElapsedMilliseconds} ms \n");



                }

                else if (answer == "8")
                {
                    notQuitted = true;
                    View.Print("Goodbye!");
                }


                else
                {
                    View.Print("wrong command - try again \n");
                }

                watch.Reset();

            }
            Console.ReadKey();

        }
    }
}
