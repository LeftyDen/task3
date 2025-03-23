// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using App3Sharp;
class Program
{
    static void Main(string[] args)
    {
        Ship ship1 = new Ship("Ship 1", 100, 10);
        Ship ship2 = new Ship("Ship 2", 80, 10);
        
        Container container1 = new GasContainer(10, 10, 10, 10, 100, 10);
        Container container2 = new LiquidContainer(10, 10, 10, 10, 200, true);
        Container container3 = new RefrigeratedContainer(10, 10, 10, 4, 200, 4);
        
        container1.LoadCargo(10);
        container2.LoadCargo(10);
        container3.LoadCargo(10);
        
        ship1.AddContainer(container1);
        ship1.AddContainer(container2);
        ship1.AddContainer(container3);
        
        Console.WriteLine("\nInfo about ship 1:");
        ship1.PrintInfo();
        Console.WriteLine("\nInfo about ship 2:");
        ship2.PrintInfo();
        
        Console.WriteLine("\nChange container 1 in ship 1:");
        ship1.SwapContainers("KON-G-1", "KON-C-3", ship1);
        
        Console.WriteLine("\nTransfer container to ship  2:");
        ship1.TransferContainer("KON-L-2", ship2);
        
        Console.WriteLine("\nDeleting container from ship 1:");
        ship1.RemoveContainer("KON-C-3");
        
        List<Container> newContainers = new List<Container> {
             new GasContainer(10, 10, 10, 10, 200, 10),
             new GasContainer(10, 10, 10, 10, 200, 10)
        };
        
        ship2.AddContainers(newContainers);
        
        Console.WriteLine("\nNew info about ship  1:");
        ship1.PrintInfo();
        Console.WriteLine("\nNew info about ship  2:");
        ship2.PrintInfo();
    }
}