namespace App3Sharp;

public class GasContainer : Container
{
    public double Pressure { get; set; } // Тиск у контейнері (в атмосферах)

    public GasContainer(double height, double depth, double width, double mass, double maxPayload, double pressure)
        : base(height, depth, width, mass, maxPayload, "G")
    {
        Pressure = pressure;
    }

    public override void LoadCargo(double mass)
    {
        if (CurrentCargo + mass > MaxPayload)
            throw new Exception("OverfillException: Cargo exceeds container capacity.");
        CurrentCargo += mass;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Pressure: {Pressure} atm");
    }
}