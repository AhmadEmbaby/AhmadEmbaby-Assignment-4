using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace SessionsArrays
{
    [MemoryDiagnoser]
    public class StringBenchmark
    {
        // Part 21 & 22 &23 &24


        [Params(10, 100, 500)]
        public int Iterations;   

        [Benchmark]
        public void StringConcatenation()
        {
            string report = "";

            for (int i = 0; i < Iterations; i++)
            {
                report += "Session " + i;
            }
        }

        [Benchmark]
        public void StringBuilderConcatenation()
        {
            StringBuilder report = new StringBuilder();

            for (int i = 0; i < Iterations; i++)
            {
                report.Append("Session " + i);
            }
        }
    }
}