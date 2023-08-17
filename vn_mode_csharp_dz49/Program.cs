using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        const int _Exit = 0;

        bool isRunning = true;
        Zoo zoo = new Zoo();

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в зоопарк! Выберите вольер для посещения:");
            zoo.DisplayEnclosures();
            Console.WriteLine("0. Выйти");

            int userInput;

            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                if (userInput == _Exit)
                {
                    isRunning = false;
                }
                else
                {
                    Console.Clear();
                    zoo.VisitEnclosure(userInput);
                    Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(Zoo.InvalidOption);
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}

public class Animal
{
    public Animal(string name, string gender, string sound)
    {
        Name = name;
        Gender = gender;
        Sound = sound;
    }

    public string Name { get; }
    public string Gender { get; }
    public string Sound { get; }
}

public class Enclosure
{
    private List<Animal> _animals = new List<Animal>();

    public Enclosure(string description)
    {
        Description = description;
    }

    public string Description { get; }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public void DisplayAnimalsInfo()
    {
        Console.WriteLine(Description);

        foreach (Animal animal in _animals)
        {
            Console.WriteLine($"Имя: {animal.Name}, пол: {animal.Gender}, звук: {animal.Sound}");
        }
    }
}

public class Zoo
{
    private List<Enclosure> _enclosures = new List<Enclosure>();

    public Zoo()
    {
        InitializeZoo();
    }

    private void InitializeZoo()
    {
        string[] enclosureDescriptions = new string[]
        {
            "Вольер 1: обитают львы.",
            "Вольер 2: обитают обезьяны.",
            "Вольер 3: обитают тигры.",
            "Вольер 4: обитают жирафы."
        };

        string[] animalNames = new string[] { "Лев", "Обезьяна", "Тигр", "Жираф" };
        string[] animalGenders = new string[] { "мужской", "женский" };
        string[] animalSounds = new string[] { "Р-р-р", "У-у-а-а-а", "Р-р-р", "Э-э-э" };

        for (int i = 0; i < enclosureDescriptions.Length; i++)
        {
            Enclosure enclosure = new Enclosure(enclosureDescriptions[i]);

            for (int j = 0; j < animalGenders.Length; j++)
            {
                enclosure.AddAnimal(new Animal(animalNames[i], animalGenders[j], animalSounds[i]));
            }
            _enclosures.Add(enclosure);
        }
    }

    public static string InvalidOption { get; } = "Неверный выбор. Пожалуйста, выберите снова.";

    public void DisplayEnclosures()
    {
        for (int i = 0; i < _enclosures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_enclosures[i].Description}");
        }
    }

    public void VisitEnclosure(int enclosureNumber)
    {
        if (enclosureNumber > 0 && enclosureNumber <= _enclosures.Count)
        {
            _enclosures[enclosureNumber - 1].DisplayAnimalsInfo();
        }
        else
        {
            Console.WriteLine(InvalidOption);
        }
    }
}
