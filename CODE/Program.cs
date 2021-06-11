using System;

namespace CODE
{   
    class MonsterClass
    {
        publicint numMonsters = 100;

        public string monsterName;
        public int monsterHealth;
        public int monsterStrength;
        Random numberGen = new Random();
        
        public void monsterAttack()
        {
            int monsterDamage = numberGen.Next(3, 7);
            monsterStrength = monsterDamage;
            Console.WriteLine("The monster strikes you. Dealing " + monsterDamage + " damage.");
        }
    }

    class PlayerClass
    {
        public string PlayerName;
        public int Health;
        public int Mana;
        public int Stamina;
        public int Rage;
        public int weaponDamage;
        public float EXP;
        public void Mage()
        {
            Health = 50;
            Mana = 100;
            weaponDamage = 10;
            EXP = 0f;
            Skillpoints = 0;
        }
        public void Warrior()
        {
            Health = 100;
            Rage = 100;
            weaponDamage = 30;
            EXP = 0f;
            Skillpoints = 0;
        }
        public void Archer()
        {
            Health = 50;
            Stamina = 100;
            weaponDamage = 25;
            EXP = 0f;
            Skillpoints = 0;
        }
        public void Rogue()
        {
            Health = 75;
            Stamina = 10;
            weaponDamage = 25;
            EXP = 0f;
            Skillpoints = 0;
        }
        public int Skillpoints;
        public string FrostNova;
        public string Heal;
        public int spellDamage;
        public void playerOptions()
        {
            Console.WriteLine("Attack/Magic/Rest");
        }
        
        Random spellDamageRoll = new Random();

        public void CastSpell()
        {
            if(Mana > 0)
            {
            Console.WriteLine(PlayerName + " casts Fireball");
            Mana -= 10;
            spellDamage = spellDamageRoll.Next(25, 41);
            }
            else
            {
                Console.WriteLine("You don't have enough Mana for that.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose your class!\nMage, Warrior, Archer or Rogue?");
            string _playerClass = Console.ReadLine();
            
            PlayerClass newPlayer = new PlayerClass();
            
            if(_playerClass == "Mage")
            {
                newPlayer.Mage();
                Console.WriteLine ("\nYou have chosen the Mage class.\n\nWhat is your name?");
                newPlayer.PlayerName = Console.ReadLine();
            }
            else if(_playerClass == "Warrior")
            {
                newPlayer.Warrior();
                Console.WriteLine ("\nYou have chosen the Warrior class.\n\nWhat is your name?");
                newPlayer.PlayerName = Console.ReadLine();
            }
            else if(_playerClass == "Archer")
            {
                newPlayer.Archer();
                Console.WriteLine ("\nYou have chosen the Archer class.\n\nWhat is your name?");
                newPlayer.PlayerName = Console.ReadLine();
            }
            else if(_playerClass == "Rogue")
            {
                newPlayer.Rogue();
                Console.WriteLine ("\nYou have chosen the Rogue class.\n\nWhat is your name?");
                newPlayer.PlayerName = Console.ReadLine();
            }
            
            Console.WriteLine("Hello " + newPlayer.PlayerName + ", welcome to ShitCodeScape. Would you like to start your journey?\n\nYes/No");
            string playerStart = Console.ReadLine();

            if(playerStart == "Yes")
            {
                Console.WriteLine("Please enjoy your stay in ShitCodeScape.");
            }
            else
            {
                Console.WriteLine("Please choose a new class.");
            }

            MonsterClass[] newMonster = new MonsterClass[100];

            for (int i = 0; i < 100; i++)
            {
                Random healthRoll = new Random();
                newMonster[i] = new MonsterClass();
                newMonster[i].monsterHealth = healthRoll.Next(80, 121);
                newMonster[i].monsterName = Convert.ToString(newMonster[i]);
            }

            //I've created a 

            while(newMonster[1].monsterHealth > 0 && newPlayer.Health > 0)
                {
                    Console.WriteLine("\nA new monster has appeared. It looks to be a " + newMonster.monsterName + " what would you like to do?");
                    newPlayer.playerOptions();
                    string playerMoveOptions = Console.ReadLine();
                if(playerMoveOptions == "Attack")
                {
                    newMonster[1].monsterHealth -= newPlayer.weaponDamage;
                    Console.WriteLine("The monster has " + newMonster[1].monsterHealth + " health left.");
                    newMonster[1].monsterAttack();
                    newPlayer.Health -= newMonster[1].monsterStrength;
                }
                else if(playerMoveOptions == "Magic")
                {
                    newPlayer.CastSpell();
                    newMonster[1].monsterHealth -= newPlayer.spellDamage;
                    Console.WriteLine("The monster has " + newMonster[1].monsterHealth + " health left.");
                    newMonster[1].monsterAttack();
                    newPlayer.Health -= newMonster[1].monsterStrength;
                }
                else if(playerMoveOptions == "Rest" && _playerClass == "Mage")
                {
                    newPlayer.Mana += 15;
                    newMonster[1].monsterAttack();
                    newPlayer.Health -= newMonster[1].monsterStrength;
                }
                else if(playerMoveOptions == "Rest" && _playerClass == "Warrior")
                {
                    newPlayer.Rage += 15;
                    newMonster[1].monsterAttack();
                    newPlayer.Health -= newMonster[1].monsterStrength;
                }
                else if(playerMoveOptions == "Rest" && _playerClass == "Archer")
                {
                    newPlayer.Stamina += 15;
                    newMonster[1].monsterAttack();
                    newPlayer.Health -= newMonster[1].monsterStrength;
                }
                else if(playerMoveOptions == "Rest" && _playerClass == "Rogue")
                {
                    newPlayer.Stamina += 15;
                    newMonster[1].monsterAttack();
                    newPlayer.Health -= newMonster[1].monsterStrength;
                }

            Console.ReadKey();              
        }
    }
}