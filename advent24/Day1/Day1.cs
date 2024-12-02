using BenchmarkDotNet.Attributes;

namespace advent24.Day1;

public class Day1 {
    public Day1() {
        Run();
    }

    /// <summary>
    ///  | Method | Mean     | Error   | StdDev   |
    ///  |------- |---------:|--------:|---------:|
    ///  | Run    | 433.2 us | 8.45 us | 13.89 us | 
    /// </summary>
    [Benchmark]
    public void Run() {
        var input = File.ReadAllLines("Day1/input.txt");
        var col1 = new int[input.Length];
        var col2 = new int[input.Length];
        var dict = new Dictionary<int, int>();

        for (var index = 0; index < input.Length; index++) {
            var line = input[index];
            var parts = line.Split("   ");
            col1[index] = int.Parse(parts[0]);
            col2[index] = int.Parse(parts[1]);
        }

        Array.Sort(col1);
        Array.Sort(col2);

        int dist = 0;
        for (var index = 0; index < col1.Length; index++) {
            var key = col1[index];
            var value = col2[index];
            dist += Math.Abs(key - value);
            dict.TryAdd(value, 0);
            dict[value]++;
        }

        int simScore = 0;
        for (var i = 0; i < col1.Length; i++) {
            var key = col1[i];

            if (dict.TryGetValue(key, out var count)) {
                simScore += key * count;
            }
        }

        //Console.WriteLine($"Day 1: dist = {dist}");
        //Console.WriteLine($"Day 1: simScore = {simScore}");
    }
}
