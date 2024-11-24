public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    //Delegation for the charater actions.
    public delegate void CharacterAction(Character Target);
    //For if the character health changes
    public event Action<Character> HealthChanged;

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }
//Attack method.
    public void Attack(Character target)
    {
        //Attack action.
        CharacterAction action = (Character t) =>
        {
            //Damage dealt, and reduce hp.
            int damage = 10;
            t.Health -= damage;
            Console.WriteLine($"{Name} attacked {t.Name} for {damage} damage.");
            //Start the health change event.
            OnHealthChanged(t);
        };

        //Trigger attack action.
        action(target);
    }

    //Method for health change event.
    protected virtual void OnHealthChanged(Character target)
    {
        //Reacts to the specifik target for the event
        HealthChanged?.Invoke(target); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        Character hero = new Character("Hero", 100);
        Character villain = new Character("Villain", 100);

        //Links the characters to the health change event.
        hero.HealthChanged += (Character target) =>
        {
            Console.WriteLine($"{target.Name} health changed to {target.Health}");
        };

        villain.HealthChanged += (Character target) =>
        {
            Console.WriteLine($"{target.Name} health changed to {target.Health}");
        };
        
        //Triggers the attack
        hero.Attack(villain);
        villain.Attack(hero);
    }
}