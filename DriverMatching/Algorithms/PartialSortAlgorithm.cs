using DriverMatching.Models;

namespace DriverMatching.Algorithms;

/// <summary>
/// Алгоритм 4: Partial Sort с использованием LINQ
/// Временная сложность: O(n log k)
/// Пространственная сложность: O(n)
/// </summary>
public class PartialSortAlgorithm : IDriverMatchingAlgorithm
{
    public List<DriverDistance> FindClosestDrivers(List<Driver> drivers, Order order, int count = 5)
    {
        if (drivers == null || drivers.Count == 0)
            return new List<DriverDistance>();

        // Вычисляем расстояния и сортируем с помощью LINQ
        var result = drivers
            .Select(driver => new DriverDistance(
                driver,
                CalculateDistance(driver.X, driver.Y, order.X, order.Y)
            ))
            .OrderBy(dd => dd.Distance)
            .Take(count)
            .ToList();

        return result;
    }

    private double CalculateDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}