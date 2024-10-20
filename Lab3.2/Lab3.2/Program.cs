using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Student student = new Student("Іван", 20, 2, 4.5);
        Console.WriteLine("\n--- Інформація про студента ---");
        Console.WriteLine($"Ім'я студента: {student.Name}");
        student.StudentRating();
        Console.WriteLine($"Студент є: {student.GetRole(student.Course)}");

        student.EditStudent("Олег", 21, 4.8);
        Console.WriteLine("\n--- Оновлена інформація про студента ---");
        Console.WriteLine($"Ім'я студента: {student.Name}");
        student.StudentRating();

        Animal animal = new Animal();
        Console.WriteLine("\n--- Інформація про тварину ---");
        Console.WriteLine($"Ім'я: {animal.Name}");
        Console.WriteLine($"Вага: {animal.Weight} кг");
        Console.WriteLine($"Вік: {animal.Age} років");
        Console.WriteLine($"Вид: {animal.Species}");
        Console.WriteLine("-------------------------------");

        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}
