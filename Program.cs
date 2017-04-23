using System;
using System.Diagnostics;

namespace NotifyPropertyOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var option1 = new OptionInSetter();
            var option2 = new OptionWithComparer();

            option1.PropertyChanged += (sender, e) => { };
            option2.PropertyChanged += (sender, e) => { };

            option1.Var1 = -1;
            option1.Var2 = "Hello World";
            option2.Var1 = -1;
            option2.Var2 = "Hello World";

            TestOption(option1);
            TestOption(option2);
        }

        static void TestOption(IOption option)
        {
            var watch = new Stopwatch();
            watch.Start();
            
            for (int i = 0; i < 100000; i++) {
                option.Var1 = i;
                option.Var2 = $"abc{i}";
            }

            watch.Stop();
            Console.WriteLine($"Time Elapsed (ms): {watch.ElapsedMilliseconds}");
        }
    }
}

/* Results: 
 * Time Elapsed (ms): 24
 * Time Elapsed (ms): 27 */