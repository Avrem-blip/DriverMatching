namespace DriverMatching.Models;

/// <summary>
/// Представляет заказ такси.
/// </summary>
public class Order
{
    /// <summary>
    /// X координата заказа на карте.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Y координата заказа на карте.
    /// </summary>
    public int Y { get; set; }

    public Order(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"Order(X={X}, Y={Y})";
}