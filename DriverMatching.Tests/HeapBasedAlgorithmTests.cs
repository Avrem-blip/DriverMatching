using NUnit.Framework;
using DriverMatching.Algorithms;
using DriverMatching.Models;

namespace DriverMatching.Tests;

[TestFixture]
public class HeapBasedAlgorithmTests
{
    private HeapBasedAlgorithm _algorithm = null!;

    [SetUp]
    public void Setup()
    {
        _algorithm = new HeapBasedAlgorithm();
    }

    [Test]
    public void FindClosestDrivers_WithEmptyList_ReturnsEmptyList()
    {
        var drivers = new List<Driver>();
        var order = new Order(5, 5);

        var result = _algorithm.FindClosestDrivers(drivers, order);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void FindClosestDrivers_WithSingleDriver_ReturnsThatDriver()
    {
        var drivers = new List<Driver> { new Driver(1, 0, 0) };
        var order = new Order(0, 0);

        var result = _algorithm.FindClosestDrivers(drivers, order, 1);

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Driver.Id, Is.EqualTo(1));
    }

    [Test]
    public void FindClosestDrivers_WithMultipleDrivers_ReturnsFiveClosest()
    {
        var drivers = new List<Driver>
        {
            new Driver(1, 0, 0),
            new Driver(2, 1, 1),
            new Driver(3, 2, 2),
            new Driver(4, 10, 10),
            new Driver(5, 3, 3),
            new Driver(6, 100, 100)
        };
        var order = new Order(0, 0);

        var result = _algorithm.FindClosestDrivers(drivers, order, 5);

        Assert.That(result.Count, Is.EqualTo(5));
        Assert.That(result[0].Driver.Id, Is.EqualTo(1));
    }

    [Test]
    public void FindClosestDrivers_ResultsAreSorted_ByDistanceAscending()
    {
        var drivers = new List<Driver>
        {
            new Driver(1, 10, 10),
            new Driver(2, 1, 1),
            new Driver(3, 5, 5),
            new Driver(4, 2, 2),
            new Driver(5, 3, 3)
        };
        var order = new Order(0, 0);

        var result = _algorithm.FindClosestDrivers(drivers, order, 5);

        for (int i = 0; i < result.Count - 1; i++)
        {
            Assert.That(result[i].Distance, Is.LessThanOrEqualTo(result[i + 1].Distance));
        }
    }

    [Test]
    public void FindClosestDrivers_CountLessThanDriversCount_ReturnsOnlyCount()
    {
        var drivers = new List<Driver>
        {
            new Driver(1, 0, 0),
            new Driver(2, 1, 1),
            new Driver(3, 2, 2),
            new Driver(4, 3, 3),
            new Driver(5, 4, 4),
            new Driver(6, 5, 5)
        };
        var order = new Order(0, 0);

        var result = _algorithm.FindClosestDrivers(drivers, order, 3);

        Assert.That(result.Count, Is.EqualTo(3));
    }
}