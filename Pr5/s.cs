using System;

namespace MageBattle
{
    // Абстрактний клас для магів
    public abstract class Mage
    {
        public string Name { get; set; }
        public int MagicLevel { get; set; }
        public int Health { get; set; }

        // Події для сповіщення про атаки та захист
        public event EventHandler<string> Attacked;
        public event EventHandler<string> Defended;

        protected Mage(string name, int magicLevel, int health)
        {
            Name = name;
            MagicLevel = magicLevel;
            Health = health;
        }

        public abstract void Attack(Mage opponent);
        public abstract void Defend(int damage);

        protected void OnAttacked(string message)
        {
            Attacked?.Invoke(this, message);
        }

        protected void OnDefended(string message)
        {
            Defended?.Invoke(this, message);
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }

    // Інтерфейс для заклять
    public interface ISpell
    {
        int Cast(); // Метод для використання закляття, повертає шкоду
        string SpellName { get; }
    }

    // Конкретний клас магії вогню
    public class FireMage : Mage, ISpell
    {
        public FireMage(string name, int magicLevel, int health)
            : base(name, magicLevel, health) { }

        public override void Attack(Mage opponent)
        {
            int damage = Cast();
            OnAttacked($"{Name} атакує {opponent.Name} з закляттям {SpellName}, завдаючи {damage} шкоди.");
            opponent.Defend(damage);
        }

        public override void Defend(int damage)
        {
            Health -= damage;
            OnDefended($"{Name} отримав {damage} шкоди. Залишилось {Health} здоров'я.");
        }

        public int Cast()
        {
            return MagicLevel * 2; // Закляття вогню завдає шкоду, подвоюючи рівень магії
        }

        public string SpellName => "Вогняне закляття";
    }

    // Конкретний клас магії води
    public class WaterMage : Mage, ISpell
    {
        public WaterMage(string name, int magicLevel, int health)
            : base(name, magicLevel, health) { }

        public override void Attack(Mage opponent)
        {
            int damage = Cast();
            OnAttacked($"{Name} атакує {opponent.Name} з закляттям {SpellName}, завдаючи {damage} шкоди.");
            opponent.Defend(damage);
        }

        public override void Defend(int damage)
        {
            Health -= damage;
            OnDefended($"{Name} отримав {damage} шкоди. Залишилось {Health} здоров'я.");
        }

        public int Cast()
        {
            return MagicLevel * 3; // Закляття води завдає шкоду, потроюючи рівень магії
        }

        public string SpellName => "Водне закляття";
    }

    // Клас для управління грою
    public class Game
    {
        public event EventHandler<Mage> BattleEnded;

        public void StartBattle(Mage mage1, Mage mage2)
        {
            mage1.Attacked += Mage_Attacked;
            mage1.Defended += Mage_Defended;
            mage2.Attacked += Mage_Attacked;
            mage2.Defended += Mage_Defended;

            while (mage1.IsAlive() && mage2.IsAlive())
            {
                mage1.Attack(mage2);
                if (!mage2.IsAlive())
                {
                    OnBattleEnded(mage1);
                    break;
                }

                mage2.Attack(mage1);
                if (!mage1.IsAlive())
                {
                    OnBattleEnded(mage2);
                    break;
                }
            }
        }

        private void Mage_Attacked(object sender, string e)
        {
            Console.WriteLine(e);
        }

        private void Mage_Defended(object sender, string e)
        {
            Console.WriteLine(e);
        }

        protected virtual void OnBattleEnded(Mage winner)
        {
            BattleEnded?.Invoke(this, winner);
        }
    }

    // Основна програма
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вітаємо в грі 'Битва магів'!");

            // Створюємо магів
            Mage fireMage = new FireMage("Аргос", 10, 100);
            Mage waterMage = new WaterMage("Левіафан", 8, 120);

            // Створюємо гру і підписуємось на події
            Game game = new Game();
            game.BattleEnded += Game_BattleEnded;

            // Початок битви
            game.StartBattle(fireMage, waterMage);
        }

        // Обробник події завершення битви
        private static void Game_BattleEnded(object sender, Mage winner)
        {
            Console.WriteLine($"{winner.Name} переміг у битві!");
        }
    }
}
