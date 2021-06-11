using System;

namespace CODE2
{   
    class Player
    {
        public int Health = 100;
        
        public void takeDamage(int Damage)
        {
            Health -= Damage;
        }

    }
    
    class Monster
    {
        int monsterStrength = 20;
        Random hitRoll = new Random();

        public int monsterAttack()
        {
            return(monsterStrength += hitRoll.Next(1, 6));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {          
            Player newPlayer = new Player();
            Monster newMonster = new Monster();

            while(newPlayer.Health > 0)
            {
            newPlayer.takeDamage(newMonster.monsterAttack());
            Console.WriteLine("Player health: " + newPlayer.Health);
            }

            Console.ReadKey();              
        }
    }
}