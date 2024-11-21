using System;
using System.Collections.Generic;

class Program
{
    //Character class definitions.
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Action PrimaryAction { get; set; }

        public Character(string name, int health, Action _PrimaryAction)
        {
            Name = name;
            Health = health;
            PrimaryAction = _PrimaryAction;
        }

        public void ExecuteAction()
        {
            PrimaryAction?.Invoke();
        }
    }

    static void Main(string[] args)
    {
        //Warrior class with the ability to attack with sword.
        var warrior = new Character("Warrior", 40, () =>
        {
            Console.WriteLine("Warrior attacks with sword!");
        });
        //Healer class with the ability to heal.
        var healer = new Character("Healer", 60, () =>
        {
            Console.WriteLine("Healer casts healing spell!");
        });
        //Characters in party.
        var characters = new List<Character> { warrior, healer };
        //This is for knowing when the characters are going to do the right actions, in this case it is based on what health the actions is going to execute.
        foreach (var character in characters)
        {
            if (character.Health < 50)
            {
                //If health is below 50, the warrior will attack and the healer will heal. 
                if (character.Name == "Warrior")
                {
                    // The warrior will also attack if the warriors heatlth is low. 
                    Console.WriteLine($"{character.Name} is low on health ({character.Health}) and chooses to attack!");
                    character.ExecuteAction();
                }
                else if (character.Name == "Healer")
                {
                    var target = characters.Find(c => c != character && c.Health < 50);
                    if (target != null)
                    {
                        //The healer will heal the lowest health character. 
                        Console.WriteLine($"{character.Name} notices {target.Name} is low on health and heals them!");
                        character.ExecuteAction();
                    }
                }
            }
            else
            {
                //Regular actions will be executed if health is above 50. 
                Console.WriteLine($"{character.Name} is healthy ({character.Health}) and performs a regular action.");
                character.ExecuteAction();
            }
        }
    }
}
