using System;

class Monster
    {
        public int monsterStrength;
        public int monsterHealth;
        
        public enum monsterType
        {
            Imp,
            Goblin,
            Troll,
            Centaur,
            Dragon
        }
        
        public monsterType currentMonster;

        public Monster (monsterType _monsterType)
        {
            currentMonster = _monsterType;
            monsterStats(_monsterType);
        }

        public void monsterStats (monsterType _monsterType)
        {
           switch (monsterUniqueStats)
            {
                case monsterType.Imp:
                    Console.WriteLine("An Imp appears!");
                    monsterHealth = 30;
                    monsterStrength = 15;
                break;
                case monsterType.Goblin:
                    Console.WriteLine("A Goblin appears!");
                    monsterHealth = 50;
                    monsterStrength = 25;
                break;
                case monsterType.Troll:
                    Console.WriteLine("A Troll appears!");
                    monsterHealth = 200;
                    monsterStrength = 60;
                break;
                case monsterType.Centaur:
                    Console.WriteLine("A Centaur appears!");
                    monsterHealth = 100;
                    monsterStrength = 60;
                break;
                case monsterType.Dragon:
                    Console.WriteLine("A Dragon appears!");
                    monsterHealth = 500;
                    monsterStrength = 100;
                break;
            default:
            break;
            }
        }
            public void monsterTakeDamage(int mDamage)
        {
            monsterHealth -= mDamage;
        }        
        public int monsterAttack()
        {
            int monsterDamageRoll = monsterStrength += hitRoll.Next(1, 6);
            Console.WriteLine("\nThe monster takes a swing at you. Dealing " + monsterDamageRoll + " damage.");
            return(monsterDamageRoll);
        }
        public void getMonsterHealth()
        {
            Console.WriteLine("\nThe monster has " + monsterHealth + " health remaining.");
        }
    }