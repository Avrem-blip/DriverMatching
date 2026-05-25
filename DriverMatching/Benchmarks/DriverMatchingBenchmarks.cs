using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using DriverMatching.Algorithms;
using DriverMatching.Models;

namespace DriverMatching.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(warmupCount: 3, targetCount: 5)]
public class DriverMatchingBenchmarks
{
    private List<Driver> _drivers = null!;
    private Order _order = null!;

    private SimpleSortingAlgorithm _simpleSortingAlgorithm = null!;
    private HeapBasedAlgorithm _heapBasedAlgorithm = null!;
    private QuickSelectAlgorithm _quickSelectAlgorithm = null!;
    private PartialSortAlgorithm _partialSortAlgorithm = null!;

    [Params(1000, 10000, 100000)]
    public int DriverCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(42);
        _drivers = new List<Driver>();

        for (int i = 0; i < DriverCount; i++)
        {
            _drivers.Add(new Driver(i, random.Next(1000), random.Next(1000)));
        }

        _order = new Order(500, 500);

        _simpleSortingAlgorithm = new SimpleSortingAlgorithm();
        _heapBasedAlgorithm = new HeapBasedAlgorithm();
        _quickSelectAlgorithm = new QuickSelectAlgorithm();
        _partialSortAlgorithm = new PartialSortAlgorithm();
    }

    [Benchmark]
    public List<DriverDistance> SimpleSorting()
    {
        return _simpleSortingAlgorithm.FindClosestDrivers(_drivers, _order, 5);
    }

    [Benchmark]
    public List<DriverDistance> HeapBased()
    {
        return _heapBasedAlgorithm.FindClosestDrivers(_drivers, _order, 5);
    }

    [Benchmark]
    public List<DriverDistance> QuickSelect()
    {
        return _quickSelectAlgorithm.FindClosestDrivers(_drivers, _order, 5);
    }

    [Benchmark]
    public List<DriverDistance> PartialSort()
    {
        return _partialSortAlgorithm.FindClosestDrivers(_drivers, _order, 5);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<DriverMatchingBenchmarks>();
    }
}