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

    [SimpleJob(launchCount: 1, warmupCount: 2, targetCount: 5, invocationCount:1)]
    public class BenchMarkTest
    {
        [Params(@"C:\Personal\CSharp\BenchMarkTextCounter\SampleFiles\Small.txt", @"C:\Personal\CSharp\BenchMarkTextCounter\SampleFiles\Medium.txt", @"C:\Personal\CSharp\BenchMarkTextCounter\SampleFiles\Large.txt")]
        public string FileRoot { get; set; }

        [Benchmark]
        public void ProcessFile()
        {
            //vars
            ITextCounterManager ITextManager = new TextCounterManager();

            var result = ITextManager.ProcessFile(FileRoot);
        }

        [Benchmark]
        public void ProcessFileRefactor()
        {
            //vars
            ITextCounterManager ITextManager = new TextCounterManagerRefactor();

            var result = ITextManager.ProcessFile(FileRoot);
        }
    }
   
}
