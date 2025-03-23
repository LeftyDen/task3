namespace App3Sharp;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; } 

    public GasContainer(double height, double depth, double width, double tareWeight, double maxPayload, double pressure)
        : base(height, depth, width, tareWeight, maxPayload, "G")
    {
        Pressure = pressure;
    }

    public override void LoadCargo(double mass)
    {
        if (CurrentCargo + mass > MaxPayload)
        {
            Notification();
            throw new Exception("OverfillException: Cargo exceeds container capacity.");
        }

        CurrentCargo += mass;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Pressure: {Pressure} atm");
    }

    public void Notification()
    {
        Console.WriteLine("Overload exeption in Gas Happened ");
    }
    
    
}