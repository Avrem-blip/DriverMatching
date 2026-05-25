namespace DriverMatching.Models;

/// <summary>
/// Представляет водителя такси на карте.
/// </summary>
public class Driver
{
    /// <summary>
    /// Уникальный идентификатор водителя.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// X координата на карте (0 <= X < N).
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Y координата на карте (0 <= Y < M).
    /// </summary>
    public int Y { get; set; }

    public Driver(int id, int x, int y)
    {
        Id = id;
        X = x;
        Y = y;
    }

    public override string ToString() => $"Driver(Id={Id}, X={X}, Y={Y})";
}