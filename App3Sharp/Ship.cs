namespace App3Sharp;

using System;
using System.Collections.Generic;

public class Ship
{
    public string Name { get; private set; }
    public double MaxWeight { get; private set; }
    public int MaxContainerCount { get; private set; }
    private List<Container> containers;

    public Ship(string name, double maxWeight, int maxContainerCount)
    {
        Name = name;
        MaxWeight = maxWeight;
        MaxContainerCount = maxContainerCount;
        containers = new List<Container>();
    }

    public double GetTotalWeight()
    {
        double totalWeight = 0;
        foreach (var container in containers)
        {
            totalWeight += container.GetTotalWeight();
        }
        return totalWeight;
    }

    public void AddContainer(Container container)
    {
        if (containers.Count >= MaxContainerCount)
        {
            Console.WriteLine("imposible add container.");
            return;
        }

        if (GetTotalWeight() + container.GetTotalWeight() > MaxWeight)
        {
            Console.WriteLine("imposible add container.");
            return;
        }

        containers.Add(container);
        Console.WriteLine("Container added.");
    }

    public void RemoveContainer(string serialNumber)
    {
        Container container = containers.Find(c => c.SerialNumber == serialNumber);

        if (container == null)
        {
            Console.WriteLine("Container not found.");
            return;
        }

        containers.Remove(container);
        Console.WriteLine("Container removed from ship.");
    }

    public void SwapContainers(string serialNumber1, string serialNumber2, Ship otherShip)
    {
        Container container1 = containers.Find(c => c.SerialNumber == serialNumber1);
        Container container2 = otherShip.containers.Find(c => c.SerialNumber == serialNumber2);

        if (container1 == null || container2 == null)
        {
            Console.WriteLine("One of the containers does not exist.");
            return;
        }

        if (GetTotalWeight() - container1.GetTotalWeight() + container2.GetTotalWeight() > MaxWeight ||
            otherShip.GetTotalWeight() - container2.GetTotalWeight() + container1.GetTotalWeight() > otherShip.MaxWeight)
        {
            Console.WriteLine("Change is impossible.");
            return;
        }

        containers.Remove(container1);
        otherShip.containers.Remove(container2);

        containers.Add(container2);
        otherShip.containers.Add(container1);

        Console.WriteLine("Containers changed succesfully.");
    }

    public void TransferContainer(string serialNumber, Ship targetShip)
    {
        Container container = containers.Find(c => c.SerialNumber == serialNumber);

        if (container == null)
        {
            Console.WriteLine("Container not found in  this ship.");
            return;
        }

        if (targetShip.GetTotalWeight() + container.GetTotalWeight() > targetShip.MaxWeight ||
            targetShip.containers.Count >= targetShip.MaxContainerCount)
        {
            Console.WriteLine("This ship cannot accept this container.");
            return;
        }

        containers.Remove(container);
        targetShip.containers.Add(container);

        Console.WriteLine("Container transfered successfully.");
    }

    
    public void AddContainers(List<Container> newContainers)
    {
        double newContainersWeight = 0;
        foreach (var container in newContainers)
        {
            newContainersWeight += container.GetTotalWeight();
        }

        if (containers.Count + newContainers.Count > MaxContainerCount)
        {
            Console.WriteLine("Impossible to add container.To much containers.");
            return;
        }

        if (GetTotalWeight() + newContainersWeight > MaxWeight)
        {
            Console.WriteLine("imposible to add container. To much weight.");
            return;
        }

        containers.AddRange(newContainers);
        Console.WriteLine("Containers added.");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Ship: {Name}, Max weight: {MaxWeight} kg, Max containers: {MaxContainerCount}");
        Console.WriteLine($"Current weight: {GetTotalWeight()} kg, Container number: {containers.Count}");

        foreach (var container in containers)
        {
            container.PrintInfo();
        }
    }
}