namespace App3Sharp;

public class RefrigeratedContainer : Container
{
    public double CargoMass { get; set; } // Маса вантажу
    public double MaxCargoWeight { get; set; } // Максимальна вага вантажу в холодильнику

    public RefrigeratedContainer(double height, double depth, double width, double mass, double maxPayload, double cargoMass)
        : base(height, depth, width, mass, maxPayload, "C")
    {
        CargoMass = cargoMass;
        MaxCargoWeight = maxPayload;
    }

    public override void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaxCargoWeight)
            throw new Exception("OverfillException: Cargo exceeds container capacity.");
        CargoMass += mass;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Cargo Mass: {CargoMass} kg, Max Cargo Weight: {MaxCargoWeight} kg");
    }
}