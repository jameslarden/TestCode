using System;

namespace CODE
{
    class GameManager
    {
        public int[] playerstats = new int[4];
            int skillpoints = 100;
            int tempskillpoints;
            Hero MyHero;
            // Monster class here.

        static void Main(string[] args)
        {

            GameManager Game = new GameManager();

            Game.newskillpoints();

            Game.MyHero = new Hero(Game.playerstats[0], Game.playerstats[1], Game.playerstats[2], Game.playerstats[3], "Billy", "Thunderfury");

            Console.WriteLine("Hero has " + Game.MyHero.GetHealth().ToString() + " health remaining.");
            Console.WriteLine("Hero has " + Game.MyHero.GetHealth().ToString() + " stamina remaining.");
            Console.WriteLine("Hero has " + Game.MyHero.GetHealth().ToString() + " mana remaining.");
            Console.WriteLine("Your hero is called " + Game.MyHero.GetplayerName());

            // while player lives
            while(!Game.MyHero.isdead())
            {
                Game.playerattack();
            }

            Console.WriteLine("You died.");

            Console.ReadKey();

        }


        private void newskillpoints()
        {
    
            tempskillpoints = skillpoints;

            while(skillpoints >= 1)
            {
                Console.WriteLine("You have " + skillpoints + " to spend.");
                Console.WriteLine("Health: "); 
                playerstats[0] = playerstats[0] + Convert.ToInt32( Console.ReadLine() );
                Console.WriteLine("Stamina: "); 
                playerstats[1] = playerstats[1] + Convert.ToInt32( Console.ReadLine() );
                Console.WriteLine("Stamina: "); 
                playerstats[2] = playerstats[2] + Convert.ToInt32( Console.ReadLine() );
                Console.WriteLine("Strength: "); 
                playerstats[3] = playerstats[3] + Convert.ToInt32( Console.ReadLine() );
                skillpoints = tempskillpoints - playerstats[0] - playerstats[1] - playerstats [2] - playerstats [3];
            }
        }
        private void playerattack(){
            Random numberGen = new Random();
            
            int playerattack = numberGen.Next(5, playerstats[3]);
            //Chooses a random number between 5 and the players strength. Next function will exclude the upper limit, so if the player puts 20 skill points in their strength, their max hit will be 19.

            Console.WriteLine("A wild monster appears!\nAttack?");

            string combatInitiated = Console.ReadLine();

            if(combatInitiated == "Yes") 
            {
                int monsterHp = 500 - playerattack;
                Console.WriteLine("The monster has " + monsterHp + " health left.");
                MyHero.takeDamage(numberGen.Next(5, 10)); //Use monster damage when created
                Console.WriteLine("My hero health " + MyHero.GetHealth());

            } 
            else if (combatInitiated == "No") 
            {
                Console.WriteLine("The monster gives you a confused look, then flies away");
            }


        }

     }
}