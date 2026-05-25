using DriverMatching.Models;

namespace DriverMatching.Algorithms;

/// <summary>
/// Алгоритм 3: QuickSelect
/// Использует метод разделения (partition) для поиска k-ого элемента
/// Временная сложность: O(n) в среднем, O(n²) в худшем случае
/// Пространственная сложность: O(k) + O(log n) для рекурсии
/// </summary>
public class QuickSelectAlgorithm : IDriverMatchingAlgorithm
{
    private Random _random = new Random();

    public List<DriverDistance> FindClosestDrivers(List<Driver> drivers, Order order, int count = 5)
    {
        if (drivers == null || drivers.Count == 0)
            return new List<DriverDistance>();

        // Вычисляем расстояния
        var driverDistances = drivers
            .Select(driver => new DriverDistance(
                driver,
                CalculateDistance(driver.X, driver.Y, order.X, order.Y)
            ))
            .ToList();

        int actualCount = Math.Min(count, driverDistances.Count);
        
        // Используем QuickSelect для разделения
        QuickSelect(driverDistances, 0, driverDistances.Count - 1, actualCount - 1);

        // Берём первые count элементов и сортируем
        var result = driverDistances.Take(actualCount).ToList();
        result.Sort((a, b) => a.Distance.CompareTo(b.Distance));
        return result;
    }

    private void QuickSelect(List<DriverDistance> list, int left, int right, int kIndex)
    {
        if (left == right)
            return;

        int pivotIndex = Partition(list, left, right);

        if (kIndex == pivotIndex)
            return;
        else if (kIndex < pivotIndex)
            QuickSelect(list, left, pivotIndex - 1, kIndex);
        else
            QuickSelect(list, pivotIndex + 1, right, kIndex);
    }

    private int Partition(List<DriverDistance> list, int left, int right)
    {
        // Случайно выбираем опорный элемент
        int randomIndex = left + _random.Next(right - left + 1);
        (list[randomIndex], list[right]) = (list[right], list[randomIndex]);

        double pivot = list[right].Distance;
        int i = left;

        for (int j = left; j < right; j++)
        {
            if (list[j].Distance < pivot)
            {
                (list[i], list[j]) = (list[j], list[i]);
                i++;
            }
        }

        (list[i], list[right]) = (list[right], list[i]);
        return i;
    }

    private double CalculateDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}