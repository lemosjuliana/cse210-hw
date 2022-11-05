using System; 
namespace SandboxProject

{
    class Program_

    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.SetFirstName("Juliana");
            person1.SetLastName("Lemos");

            Console.WriteLine(person1.GetPeopleNames());
        }
    }
}

