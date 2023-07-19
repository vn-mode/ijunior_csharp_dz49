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
    private List<Animal> _animals = new List<Animal>();

    public string Description { get; private set; }

    public Enclosure(string description)
    {
        Description = description;
    }

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
        Enclosure enclosure1 = new Enclosure("Вольер 1: обитают львы.");
        enclosure1.AddAnimal(new Animal("Лев", "мужской", "Р-р-р"));
        enclosure1.AddAnimal(new Animal("Львица", "женский", "Мяу"));

        Enclosure enclosure2 = new Enclosure("Вольер 2: обитают обезьяны.");
        enclosure2.AddAnimal(new Animal("Обезьяна", "мужской", "У-у-а-а-а"));
        enclosure2.AddAnimal(new Animal("Обезьяна", "женский", "И-и-а-а"));

        Enclosure enclosure3 = new Enclosure("Вольер 3: обитают тигры.");
        enclosure3.AddAnimal(new Animal("Тигр", "мужской", "Р-р-р"));
        enclosure3.AddAnimal(new Animal("Тигрица", "женский", "Мяу"));

        Enclosure enclosure4 = new Enclosure("Вольер 4: обитают жирафы.");
        enclosure4.AddAnimal(new Animal("Жираф", "мужской", "Э-э-э"));
        enclosure4.AddAnimal(new Animal("Жирафа", "женский", "Э-э-э"));

        _enclosures.Add(enclosure1);
        _enclosures.Add(enclosure2);
        _enclosures.Add(enclosure3);
        _enclosures.Add(enclosure4);
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
