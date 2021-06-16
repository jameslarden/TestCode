using System;

namespace CODE2
{   
    class Program
    {
        static void Main(string[] args)
        {          
            Console.WriteLine("What class do you want ? \n 0) Rogue \n 1) Archer \n 2) Mage \n 3) Warrior");

            var instantChoice = Convert.ToInt32(Console.ReadLine());

            Random monsterRoll = new Random();

            Player.playerClass choice = (Player.playerClass)instantChoice;

            Player Player = new Player(choice);

            Monster.monsterType monsterGen = (Monster.monsterType) monsterRoll.Next(0,5);

            Monster Monster = new Monster(monsterGen);

            string playerAction;
            int currentFocusedMonster = 0;

            while(Player.Health > 0)
            {
            Console.WriteLine("\nFighting: " + Monster.currentMonster + "\nWhat would you like to do?\n\nAttack/Magic/Rest/Heal");
            playerAction = Console.ReadLine();

                if(Monster.monsterHealth <= 0)
                {
                    Player.gainExperience(50);
                    currentFocusedMonster ++;
                    Console.WriteLine("\n--------------------------------------\n");
                    Monster = new Monster(monsterGen);
                }
                    else if(playerAction == "Attack")
                    {
                        Monster.monsterTakeDamage(Player.playerMeleeAttack());
                        Monster.getMonsterHealth();
                        Player.playerTakeDamage(Monster.monsterAttack());
                        Player.getPlayerHealth();
                    }
                    else if(playerAction == "Magic")
                    {
                        Monster.monsterTakeDamage(Player.playerMagicAttack());
                        Monster.getMonsterHealth();
                        Player.playerTakeDamage(Monster.monsterAttack());
                        Player.getPlayerHealth();
                    }
                    else if(playerAction == "Rest")
                    {
                        Player.Rest();
                        Console.WriteLine("\nYou take a moment to rest, regaining " + Player.maxMana / Player.manaRegen + " mana. You have " + Player.currentMana + " remaining.");
                        Player.playerTakeDamage(Monster.monsterAttack());
                        Player.getPlayerHealth();
                    }
                    else if(playerAction == "Heal")
                    {
                        Player.playerHealSpell();
                        Console.WriteLine("\nYou cast a heal spell, regaining " + Player.maxMana / Player.healPower + " health.");
                        Player.playerTakeDamage(Monster.monsterAttack());
                        Player.getPlayerHealth();
            }

            }

            Console.ReadKey();              
        }
    }
}