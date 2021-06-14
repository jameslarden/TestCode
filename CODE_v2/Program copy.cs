using System;

namespace CODE2
{   
    class Monster
    {
        public int monsterHealth = 100;
        int monsterStrength = 20;
        public Random hitRoll = new Random();
        public int monsterId = 0;


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

    class Program
    {
        static void Main(string[] args)
        {          
            Console.WriteLine("What class do you want ? \n 0) Rogue \n 1) Archer \n 2) Mage \n 3) Warrior");

            var instantChoice = Convert.ToInt32(Console.ReadLine());

            Player.playerClass choice = (Player.playerClass)instantChoice;

            Player newPlayer = new Player(choice);

            Monster[] newMonster = new Monster[100];
            for (int i = 0; i < 100; i++)
            {
                newMonster[i] = new Monster();
            }

            string playerAction;
            int currentFocusedMonster = 0;

            while(newPlayer.Health > 0)
            {
            Console.WriteLine("\nFighting: Monster " + currentFocusedMonster + "\nWhat would you like to do?\n\nAttack/Magic/Rest/Heal");
            playerAction = Console.ReadLine();
            Console.WriteLine("\n~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~\n");

            if(newMonster[0 + currentFocusedMonster].monsterHealth <= 0)
            {
                newPlayer.gainExperience(50);
                currentFocusedMonster ++;
                Console.WriteLine("\n--------------------------------------\n");
            }
            else if(playerAction == "Attack")
            {
                newMonster[0 + currentFocusedMonster].monsterTakeDamage(newPlayer.playerMeleeAttack());
                newMonster[0 + currentFocusedMonster].getMonsterHealth();
                newPlayer.playerTakeDamage(newMonster[0 + currentFocusedMonster].monsterAttack());
                newPlayer.getPlayerHealth();
            }
            else if(playerAction == "Magic")
            {
                newMonster[0 + currentFocusedMonster].monsterTakeDamage(newPlayer.playerMagicAttack());
                newMonster[0 + currentFocusedMonster].getMonsterHealth();
                newPlayer.playerTakeDamage(newMonster[0 + currentFocusedMonster].monsterAttack());
                newPlayer.getPlayerHealth();
            }
            else if(playerAction == "Rest")
            {
                newPlayer.Rest();
                Console.WriteLine("\nYou take a moment to rest, regaining " + newPlayer.maxMana / newPlayer.manaRegen + " mana. You have " + newPlayer.currentMana + " remaining.");
                newPlayer.playerTakeDamage(newMonster[0 + currentFocusedMonster].monsterAttack());
                newPlayer.getPlayerHealth();
            }
            else if(playerAction == "Heal")
            {
                newPlayer.playerHealSpell();
                Console.WriteLine("\nYou cast a heal spell, regaining " + newPlayer.maxMana / newPlayer.healPower + " health.");
                newPlayer.playerTakeDamage(newMonster[0 + currentFocusedMonster].monsterAttack());
                newPlayer.getPlayerHealth();
            }

            }

            Console.ReadKey();              
        }
    }
}