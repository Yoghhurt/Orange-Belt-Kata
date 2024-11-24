using System;

public class Program
{
    public static void Main()
    {
        var warrior = new Character("Warrior", 45);
        var healer = new Character("Healer", 40);

        // Role specific actions
        warrior.PrimaryAction = () => warrior.Attack();
        healer.PrimaryAction = () => healer.Heal(warrior);

        // Gameloop, checks health
        GameLoop(warrior, healer);
    }

    // Gameloop, choice to attack or heal.
    public static void GameLoop(Character warrior, Character healer)
    {
        // Classic battle round setup
        for (int round = 1; round <= 5; round++)
        {
            Console.WriteLine($"\n--- Round {round} ---");
            
            // If health is below 50, Warrior will attack.
            if (warrior.Health < 50)
            {
                Console.WriteLine($"{warrior.Name} decides to attack!");
                warrior.PrimaryAction.Invoke();
            }

            // Healer will heal the one with lowest health if their health is below 50
            if (healer.Health < 50)
            {
                Console.WriteLine($"{healer.Name} decides to heal the character with lowest health!");
                healer.PrimaryAction.Invoke();
            }

            // Checks health after actions.
            Console.WriteLine($"Warrior's Health: {warrior.Health}");
            Console.WriteLine($"Healer's Health: {healer.Health}");
        }
    }
}
public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Action PrimaryAction { get; set; }

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    // Warrior attack method
    public void Attack()
    {
        Console.WriteLine($"{Name} attacks!");
        Health -= 10;
    }

    // Healer heal method
    public void Heal(Character target)
    {
        Console.WriteLine($"{Name} heals {target.Name}!");
        target.Health += 15;
    }
}
