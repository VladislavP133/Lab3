using System;

public class Student
{
    private string name;
    private int age;
    private int course;
    private double rating;

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public int Course { get => course; set => course = value; }
    public double Rating { get => rating; set => rating = value; }

    public Student(string name, int age, int course, double rating)
    {
        this.name = name;
        this.age = age;
        this.course = course;
        this.rating = rating;
    }

    public void EditStudent(string newName, int newAge, double newRating)
    {
        Name = newName;
        Age = newAge;
        Rating = newRating;
    }

    public void StudentRating()
    {
        Console.WriteLine($"Рейтинг студента: {Rating}");
    }

    public string GetRole(int course)
    {
        return course >= 1 && course <= 4 ? "бакалавр" : "магістр";
    }
}
