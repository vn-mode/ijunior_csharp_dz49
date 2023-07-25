using System;
using System.Collections.Generic;

class Program
{
    private const string WelcomeMessage = "Добро пожаловать в зоопарк! Выберите вольер для посещения:";
    private const string ExitOption = "0. Выйти";
    private const string PromptReturn = "Нажмите любую клавишу для возврата в меню...";
    private const string PromptContinue = "Нажмите любую клавишу для продолжения...";
    private const int Exit = 0;

    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine(WelcomeMessage);
            zoo.DisplayEnclosures();

            Console.WriteLine(ExitOption);

            int userInput;

            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                if (userInput == Exit)
                {
                    running = false;
                }
                else
                {
                    Console.Clear();
                    zoo.VisitEnclosure(userInput);
                    Console.WriteLine(PromptReturn);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(Zoo.InvalidOption);
                Console.WriteLine(PromptContinue);
                Console.ReadKey();
            }
        }
    }
}

public class Animal
{
    public string Name { get; private set; }
    public string Gender { get; private set; }
    public string Sound { get; private set; }

    public Animal(string name, string gender, string sound)
    {
        Name = name;
        Gender = gender;
        Sound = sound;
    }
}

public class Enclosure
{
    public Enclosure(string description)
    {
        Description = description;
    }

    public string Description { get; private set; }

    private List<Animal> _animals = new List<Animal>();

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
    public const string InvalidOption = "Неверный выбор. Пожалуйста, выберите снова.";
    private List<Enclosure> _enclosures = new List<Enclosure>();

    public Zoo()
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
