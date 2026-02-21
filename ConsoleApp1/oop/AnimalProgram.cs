class AnimalProgram
{
    static List<Animal> animals = new List<Animal>{
            new Animal("Dog", 3, "Bark"),
            new Animal("Cat", 2, "Meow"),
            new Animal("Cow", 5, "Moo"),
            new Animal("Lion", 4, "Roar"),
            new Animal("Sheep", 1, "Baa"),
            new Animal("Duck", 2, "Quack")
        };

    static string GetAnimalBySound(string sound)
    {
        // foreach (Animal animal in animals)
        // {
        //     if (animal.TypeOfSound == sound)
        //     {
        //         return animal.Name;
        //     }
        // }
        // return "No animal found";
        Animal ? foundAnimal = animals.FirstOrDefault(animal => animal.TypeOfSound == sound) ?? null;
        return foundAnimal != null ? foundAnimal.Name : "No animal found";
    }

    
    // static void Main(string[] args)
    // {
        
    //     Console.WriteLine("Enter the sound to find the corresponding animal:");
    //     string soundToFind = Console.ReadLine() ?? string.Empty;
    //     string animalName = GetAnimalBySound(soundToFind);
    //     Console.WriteLine($"The animal that makes the sound '{soundToFind}' is: {animalName}");
        
    // }
}