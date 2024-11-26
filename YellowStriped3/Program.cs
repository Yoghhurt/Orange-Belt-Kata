using YellowStriped3;
//Attack ability
public class AttackAbility : IAbility
{
    public string Name { get; private set; }
    public string Effect { get; private set; }

    public AttackAbility(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}
//Heal ability
public class HealAbility : IAbility
{
    public string Name { get; private set; }
    public string Effect { get; private set; }

    public HealAbility(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}
//Class for the container
public class AbilityContainer<T> where T : IAbility
{
    private List<T> abilities;

    public AbilityContainer()
    {
        abilities = new List<T>();
    }

    public void AddAbility(T ability)
    {
        abilities.Add(ability);
    }

    public bool RemoveAbility(T ability)
    {
        return abilities.Remove(ability);
    }

    public List<T> GetAbilities()
    {
        return abilities;
    }

    public void DisplayAbilities()
    {
        Console.WriteLine("Abilities in container:");
        foreach (var ability in abilities)
        {
            Console.WriteLine($"Name: {ability.Name}, Effect: {ability.Effect}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //Attack container
        AbilityContainer<AttackAbility> attackAbilityContainer = new AbilityContainer<AttackAbility>();
        attackAbilityContainer.AddAbility(new AttackAbility("Fireball", "Deals fire damage to the enemy"));
        attackAbilityContainer.AddAbility(new AttackAbility("Lightning Strike", "Deals lightning damage to the enemy"));
        //Heal container
        AbilityContainer<HealAbility> healAbilityContainer = new AbilityContainer<HealAbility>();
        healAbilityContainer.AddAbility(new HealAbility("Healing Touch", "Heals a friendly target"));
        healAbilityContainer.AddAbility(new HealAbility("Regeneration", "Regenerates health over time"));
        //Display containers
        attackAbilityContainer.DisplayAbilities();
        Console.WriteLine();
        healAbilityContainer.DisplayAbilities();
    }
}