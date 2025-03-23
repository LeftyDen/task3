namespace App3Sharp;

public class LiquidContainer : Container,  IHazardNotifier
{
    public bool IsHazardous { get; set; } 

    public LiquidContainer(double height, double depth, double width, double tareWeight, double maxPayload, bool isHazardous)
        : base(height, depth, width,  tareWeight, maxPayload, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double mass)
    {
        // Якщо вантаж небезпечний, дозволяється заповнити лише 50% від максимальної вантажопідйомності
        double maxAllowed = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (CurrentCargo + mass > maxAllowed)
        {
            Notification();
            throw new Exception("OverfillException: Cargo exceeds container capacity.");
        }

        CurrentCargo += mass;
    }
    public void Notification()
    {
        Console.WriteLine("Overload exeption in Gallon Happened ");
    }
}
