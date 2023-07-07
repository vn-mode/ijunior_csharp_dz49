using System;
using System.Collections.Generic;

class Program
{
    const string WELCOME_MESSAGE = "Добро пожаловать в зоопарк! Выберите вольер для посещения:";
    const string EXIT_OPTION = "0. Выйти";
    const int EXIT = 0;
    const string PROMPT_RETURN = "Нажмите любую клавишу для возврата в меню...";
    const string PROMPT_CONTINUE = "Нажмите любую клавишу для продолжения...";

    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(WELCOME_MESSAGE);
            zoo.DisplayEnclosures();

            Console.WriteLine(EXIT_OPTION);

            int userInput;

            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                if (userInput == EXIT)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    zoo.VisitEnclosure(userInput);
                    Console.WriteLine(PROMPT_RETURN);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(Zoo.INVALID_OPTION);
                Console.WriteLine(PROMPT_CONTINUE);
                Console.ReadKey();
            }
        }
    }
}

public class Animal
{
    private string _name;
    private string _gender;
    private string _sound;

    public Animal(string name, string gender, string sound)
    {
        _name = name;
        _gender = gender;
        _sound = sound;
    }

    public string GetName() => _name;
    public string GetGender() => _gender;
    public string MakeSound() => _sound;
}

public class Enclosure
{
    private string _description;
    private List<Animal> _animals = new List<Animal>();

    public Enclosure(string description)
    {
        _description = description;
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public string Description => _description;

    public void DisplayAnimalsInfo()
    {
        Console.WriteLine(_description);

        foreach (Animal animal in _animals)
        {
            Console.WriteLine($"Имя: {animal.GetName()}, пол: {animal.GetGender()}, звук: {animal.MakeSound()}");
        }
    }
}

public class Zoo
{
    public const string INVALID_OPTION = "Неверный выбор. Пожалуйста, выберите снова.";
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
            Console.WriteLine(INVALID_OPTION);
        }
    }
}
