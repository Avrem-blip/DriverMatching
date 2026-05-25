using DriverMatching.Models;

namespace DriverMatching.Algorithms;

/// <summary>
/// Интерфейс для алгоритмов поиска ближайших водителей.
/// </summary>
public interface IDriverMatchingAlgorithm
{
    /// <summary>
    /// Находит 5 ближайших водителей к заказу.
    /// </summary>
    /// <param name="drivers">Список всех водителей</param>
    /// <param name="order">Координаты заказа</param>
    /// <param name="count">Количество ближайших водителей (по умолчанию 5)</param>
    /// <returns>Отсортированный список ближайших водителей с расстояниями</returns>
    List<DriverDistance> FindClosestDrivers(List<Driver> drivers, Order order, int count = 5);
}