namespace DriverMatching.Models;

/// <summary>
/// Представляет водителя и расстояние до заказа.
/// </summary>
public class DriverDistance
{
    public Driver Driver { get; set; }
    public double Distance { get; set; }

    public DriverDistance(Driver driver, double distance)
    {
        Driver = driver;
        Distance = distance;
    }

    public override string ToString() => $"{Driver} - Distance: {Distance:F2}";
}