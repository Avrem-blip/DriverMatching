using DriverMatching.Models;

namespace DriverMatching.Algorithms;

/// <summary>
/// Алгоритм 2: На основе кучи (Heap)
/// Использует приоритетную очередь для эффективного поиска k ближайших элементов
/// Временная сложность: O(n log k)
/// Пространственная сложность: O(k)
/// </summary>
public class HeapBasedAlgorithm : IDriverMatchingAlgorithm
{
    public List<DriverDistance> FindClosestDrivers(List<Driver> drivers, Order order, int count = 5)
    {
        if (drivers == null || drivers.Count == 0)
            return new List<DriverDistance>();

        // Используем приоритетную очередь как максимальную кучу
        var maxHeap = new PriorityQueue<DriverDistance, double>();

        foreach (var driver in drivers)
        {
            double distance = CalculateDistance(driver.X, driver.Y, order.X, order.Y);
            var driverDistance = new DriverDistance(driver, distance);

            if (maxHeap.Count < count)
            {
                // Добавляем в очередь с отрицательным приоритетом (для максимальной кучи)
                maxHeap.Enqueue(driverDistance, -distance);
            }
            else if (maxHeap.Count > 0)
            {
                var peekElement = maxHeap.Peek();
                // Если текущее расстояние меньше максимума в куче
                if (distance < -peekElement.Priority)
                {
                    maxHeap.Dequeue();
                    maxHeap.Enqueue(driverDistance, -distance);
                }
            }
        }

        // Извлекаем элементы из кучи
        var result = new List<DriverDistance>();
        while (maxHeap.Count > 0)
        {
            result.Add(maxHeap.Dequeue());
        }

        // Сортируем по расстоянию в порядке возрастания
        result.Reverse();
        result.Sort((a, b) => a.Distance.CompareTo(b.Distance));
        return result;
    }

    private double CalculateDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}