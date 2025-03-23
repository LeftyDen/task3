namespace App3Sharp;

public class LiquidContainer : Container
{
    public bool IsHazardous { get; set; } // Вказує, чи є вантаж небезпечним

    public LiquidContainer(double height, double depth, double width, double mass, double maxPayload, bool isHazardous)
        : base(height, depth, width, mass, maxPayload, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double mass)
    {
        // Якщо вантаж небезпечний, дозволяється заповнити лише 50% від максимальної вантажопідйомності
        double maxAllowed = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (CurrentCargo + mass > maxAllowed)
            throw new Exception("OverfillException: Cargo exceeds container capacity.");
        CurrentCargo += mass;
    }
}
