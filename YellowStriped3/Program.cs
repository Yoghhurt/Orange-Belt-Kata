public interface IAbility
{
    string Name { get; }
    string Effect { get; }
}

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

public class AbilityContainer<T> where T : IAbility
{
    private List<T> abilities = new List<T>();

    public void AddAbility(T ability)
    {
        abilities.Add(ability);
    }

    public void RemoveAbility(T ability)
    {
        abilities.Remove(ability);
    }

    public T GetAbility(int index)
    {
        if (index < 0 || index >= abilities.Count)
        {
            throw new IndexOutOfRangeException("Ability is out of range");
        }
        return abilities[index];
    }
}