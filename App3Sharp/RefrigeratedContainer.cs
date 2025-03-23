namespace App3Sharp;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    public double temperature { get; set; } // Маса вантажу

    public RefrigeratedContainer(double height, double depth, double width, double tareWeight, double maxPayload, double temperature)
        : base(height, depth, width,  tareWeight, maxPayload, "C")
    {
        this.temperature = temperature;

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
        Console.WriteLine($"Cargo Mass: {CurrentCargo} kg, Max Cargo Weight: {MaxPayload} kg, Temperature: {temperature} C");
    }
    public void Notification()
    {
        Console.WriteLine("Overload exeption in Frige Happened ");
    }
}