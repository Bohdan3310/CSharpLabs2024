using System;
using System.Collections.Generic;

public abstract class Mage
{
    public string Name { get; set; }
    public int MagicLevel { get; set; }
    public int Health { get; set; }
    public List<string> Spells { get; set; }

    protected Mage(string name, int magicLevel, List<string> spells, int health)
    {
        Name = name;
        MagicLevel = magicLevel;
        Spells = spells;
        Health = health;
    }

    public abstract void Attack(string spell);
    public abstract void Defend(string spell);
    public void DisplayHealth()
    {
        Console.WriteLine($"{Name}'s health: {Health}");
    }
}

public interface ISpell
{
    void Cast();
}

public class FireMage : Mage
{
    public FireMage(string name, int magicLevel, List<string> spells, int health) : base(name, magicLevel, spells, health) { }

    public override void Attack(string spell)
    {
        if (Spells.Contains(spell))
        {
            Console.WriteLine($"{Name} casts {spell}!");
        }
        else
        {
            Console.WriteLine($"{Name} does not know {spell}!");
        }
    }

    public override void Defend(string spell)
    {
        if (Spells.Contains(spell))
        {
            Console.WriteLine($"{Name} conjures {spell}!");
        }
        else
        {
            Console.WriteLine($"{Name} does not know {spell}!");
        }
    }
}

public class WaterMage : Mage
{
    public WaterMage(string name, int magicLevel, List<string> spells, int health) : base(name, magicLevel, spells, health) { }

    public override void Attack(string spell)
    {
        if (Spells.Contains(spell))
        {
            Console.WriteLine($"{Name} casts {spell}!");
        }
        else
        {
            Console.WriteLine($"{Name} does not know {spell}!");
        }
    }

    public override void Defend(string spell)
    {
        if (Spells.Contains(spell))
        {
            Console.WriteLine($"{Name} creates {spell}!");
        }
        else
        {
            Console.WriteLine($"{Name} does not know {spell}!");
        }
    }
}

public class Battle
{
    private readonly Mage _mage1;
    private readonly Mage _mage2;

    public Battle(Mage mage1, Mage mage2)
    {
        _mage1 = mage1;
        _mage2 = mage2;
    }

    public void Start()
    {
        Console.WriteLine($"Battle between {_mage1.Name} and {_mage2.Name} begins!");

        while (_mage1.Health > 0 && _mage2.Health > 0)
        {
            Console.WriteLine($"Choose an action for {_mage1.Name} (1 for attack, 2 for defend):");
            int action1 = GetActionChoice();
            string spell1 = "";
            if (action1 == 1 || action1 == 2)
            {
                Console.WriteLine($"Choose a spell for {_mage1.Name}:");
                spell1 = Console.ReadLine();
            }

            Console.WriteLine($"Choose an action for {_mage2.Name} (1 for attack, 2 for defend):");
            int action2 = GetActionChoice();
            string spell2 = "";
            if (action2 == 1 || action2 == 2)
            {
                Console.WriteLine($"Choose a spell for {_mage2.Name}:");
                spell2 = Console.ReadLine();
            }

            PerformAction(_mage1, action1, spell1, _mage2);
            PerformAction(_mage2, action2, spell2, _mage1);
        }

        if (_mage1.Health <= 0)
        {
            Console.WriteLine($"{_mage1.Name} has fallen! {_mage2.Name} is victorious!");
        }
        else
        {
            Console.WriteLine($"{_mage2.Name} has fallen! {_mage1.Name} is victorious!");
        }
    }

    private void PerformAction(Mage mage, int action, string spell, Mage opponent)
    {
        if (action == 1)
        {
            mage.Attack(spell);
            opponent.Defend(spell);
            opponent.Health -= 10;
        }
        else if (action == 2)
        {
            mage.Defend(spell);
        }

        mage.DisplayHealth();
        opponent.DisplayHealth();
    }

    private int GetActionChoice()
    {
        int choice = -1;
        while (choice != 1 && choice != 2)
        {
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter 1 for attack or 2 for defend:");
            }
        }
        return choice;
    }
}

class Program
{
    static void Main()
    {
        List<string> fireSpells = new List<string> { "fireball", "firewall" };
        Mage mage1 = new FireMage("Бодя", 100, fireSpells, 100);

        List<string> waterSpells = new List<string> { "water blast", "water shield" };
        Mage mage2 = new WaterMage("Дiма", 100, waterSpells, 100);

        Battle battle = new Battle(mage1, mage2);
        battle.Start();
    }
}
