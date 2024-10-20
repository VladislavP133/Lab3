using System;

public class Animal
{
    private string name;
    private double weight;
    private int age;
    private string species;

    public string Name { get => name; set => name = value; }
    public double Weight { get => weight; set => weight = value; }
    public int Age { get => age; set => age = value; }
    public string Species { get => species; set => species = value; }

    public Animal()
    {
        Name = "Мурка";
        Weight = 4.5;
        Age = 3;
        Species = "кішка";
    }

    public void ShowWeight()
    {
        Console.WriteLine($"Вага тварини: {Weight} кг");
    }

    public void DescribeAnimal()
    {
        Console.WriteLine($"Ця тварина {Species} з іменем {Name}");
    }
}
