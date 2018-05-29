using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using System;
using TextCounterLibrary;

namespace TextCounterBenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchMarkTest>();

            Console.ReadLine();
        }
    }

    [SimpleJob(launchCount: 1, warmupCount: 2, targetCount: 10)]
    public class BenchMarkTest
    {
        [Params(@"C:\Projects\CSharp\BenchMarkTextCounter\Medium.txt", @"C:\Projects\CSharp\BenchMarkTextCounter\Small.txt")]
        public string FileRoot { get; set; }

        [Benchmark]
        public void ProcessFile()
        {
            ITextCounterManager ITextManager = new TextCounterManager();

            var result = ITextManager.ProcessFile(FileRoot);
        }
    }
   
}
