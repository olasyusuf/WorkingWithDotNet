public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string TypeOfSound { get; set; }

    public Animal(string name, int age, string typeOfSound)
    {
        Name = name;
        Age = age;
        TypeOfSound = typeOfSound;
    }

    public void Sound()
    {
        Console.WriteLine($"{Name} makes a sound.");
    }
}

