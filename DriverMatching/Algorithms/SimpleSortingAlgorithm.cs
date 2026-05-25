using DriverMatching.Models;

namespace DriverMatching.Algorithms;

/// <summary>
/// Алгоритм 1: Простая сортировка
/// Временная сложность: O(n log n)
/// Пространственная сложность: O(n)
/// </summary>
public class SimpleSortingAlgorithm : IDriverMatchingAlgorithm
{
    public List<DriverDistance> FindClosestDrivers(List<Driver> drivers, Order order, int count = 5)
    {
        if (drivers == null || drivers.Count == 0)
            return new List<DriverDistance>();

        // Вычисляем расстояния до всех водителей
        var driverDistances = drivers
            .Select(driver => new DriverDistance(
                driver,
                CalculateDistance(driver.X, driver.Y, order.X, order.Y)
            ))
            .ToList();

        // Сортируем по расстоянию и берём первые count
        return driverDistances
            .OrderBy(dd => dd.Distance)
            .Take(count)
            .ToList();
    }

    private double CalculateDistance(int x1, int y1, int x2, int y2)
    {
        // Евклидово расстояние
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}