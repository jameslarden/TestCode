using System;

class Player
    {
        public int playerLevel;
        public int expToNextLevel;
        public int Health;
        public float EXP;
        public int maxMana;
        public int currentMana;
        public int playerMeleeDamage;
        public int playerMagicDamage;
        public int manaRegen;
        public int healPower;
        public int skillPoints;
        public int magicProficiency;
        public int meleeProficiency;
        int mpPointSpendAmount;

        public playerClass myClass;

        public enum playerClass
        {
            Rogue, 
            Archer, 
            Mage, 
            Warrior
        }

        public Player(playerClass classChoice)
        {
            myClass = classChoice;
            playerStats(classChoice);
        }

        public void playerStats(playerClass classChoice)
        {
            playerLevel = 1;
            EXP = 0;
            expToNextLevel = 100;
            skillPoints = 0;


            switch (classChoice)
            {
                case playerClass.Rogue:
                            Console.WriteLine("You are a Rogue");
                            Health = 200;
                            maxMana = 100;
                            currentMana = 100;
                            magicProficiency = 1;
                            meleeProficiency = 1;
                            playerMagicDamage = 20 + (10 * magicProficiency);
                            playerMeleeDamage = 15 + (5 * meleeProficiency);
                            manaRegen = 2;
                            healPower = 2;
                    break;
                case playerClass.Archer:
                            Console.WriteLine("You are a Archer");
                            Health = 200;
                            maxMana = 100;
                            currentMana = 100;
                            magicProficiency = 1;
                            meleeProficiency = 1;
                            playerMagicDamage = 20 + (10 * magicProficiency);
                            playerMeleeDamage = 15 + (5 * meleeProficiency);
                            manaRegen = 2;
                            healPower = 2;
                    break;
                case playerClass.Mage:
                            Console.WriteLine("You are a Mage");
                            Health = 200;
                            maxMana = 100;
                            currentMana = 100;
                            magicProficiency = 1;
                            meleeProficiency = 1;
                            playerMagicDamage = 20 + (10 * magicProficiency);
                            playerMeleeDamage = 15 + (5 * meleeProficiency);
                            manaRegen = 2;
                            healPower = 2;
                    break;
                case playerClass.Warrior:
                            Console.WriteLine("You are a Warrior");
                            Health = 200;
                            maxMana = 100;
                            currentMana = 100;
                            magicProficiency = 1;
                            meleeProficiency = 1;
                            playerMagicDamage = 20 + (10 * magicProficiency);
                            playerMeleeDamage = 15 + (5 * meleeProficiency);
                            manaRegen = 2;
                            healPower = 2;
                    break;
                default:
                    break;
            }
        }

        public void gainExperience(int expAmount)
        {
            EXP += expAmount;
            if(EXP >= expToNextLevel)
            {
                playerLevel ++;
                skillPoints += 5;
                Console.WriteLine("\nYou have gained a level, you are now level " + playerLevel + " and you have " + skillPoints + " skillpoints.");
                skillPointChoice();
                EXP -= expToNextLevel;
                
            }
        }

        public void skillPointChoice()
        {
            string spendSkillPoints;
            Console.WriteLine ( "\n Would you like to spend your skillpoints?\n\n Yes/No ");
            spendSkillPoints = Console.ReadLine();
            if(spendSkillPoints == "Yes")
            {
                while (skillPoints > 0)
                {
                    skillPointSpend();
                }
            }
        }

        public void skillPointSpend()
        {
            string _skillPointChoice;
            Console.WriteLine("How would you like to spend your skillpoints?\n\n Magic/Melee/Health");
            _skillPointChoice = Console.ReadLine();
            if(_skillPointChoice == "Magic")
            {
                Console.WriteLine("You have " + skillPoints + " remaining.");
                Console.WriteLine("How many skill points would you like to spend?");
                mpPointSpendAmount = Convert.ToInt32(Console.ReadLine());
                magicProficiency += skillPointClamp(mpPointSpendAmount, 1, skillPoints);
                skillPoints -= skillPoints;
            }
            else if(_skillPointChoice == "Melee")
            {
                Console.WriteLine("You have " + skillPoints + " remaining.");
                Console.WriteLine("How many skill points would you like to spend?");
                mpPointSpendAmount = Convert.ToInt32(Console.ReadLine());
                magicProficiency += skillPointClamp(mpPointSpendAmount, 1, skillPoints);
                skillPoints -= skillPoints;
            }
            else if(_skillPointChoice == "Health")
            {
                Console.WriteLine("You have " + skillPoints + " remaining.");
                Console.WriteLine("How many skill poinst would you like to spend? Each point increases your health by 25.");
                mpPointSpendAmount = Convert.ToInt32(Console.ReadLine());
                Health += 25 * skillPointClamp(mpPointSpendAmount, 1, skillPoints);
                skillPoints -= skillPoints;
            }
        }
        
        public static int skillPointClamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        public void Rest ()
        {
            currentMana = currentMana + (maxMana / manaRegen);
        }
        
        Random phitRoll = new Random();

        public int playerMeleeAttack()
        {
            int meleeDamageRoll = playerMeleeDamage += phitRoll.Next(1,6);
            Console.WriteLine("\nYou swing your sword at the monster, dealing " + meleeDamageRoll + " damage.");
            return(meleeDamageRoll);
        }
        public int playerMagicAttack()
        {
            if(currentMana >= 25)
            {
            int magicDamageRoll = playerMagicDamage += phitRoll.Next(1,10);
            Console.WriteLine("\nYou sling a fireball at the monster, dealing " + magicDamageRoll + " damage.");
            currentMana -= 25;
            return(magicDamageRoll);
            }
            else
            {
            Console.WriteLine("\nYou don't have enough mana for that."); return 0;
            }
        }
        public void getPlayerHealth()
        {
            Console.WriteLine("\nYou have " + Health + " health remaining.");
        }

        public void playerTakeDamage(int Damage)
        {
            Health -= Damage;
        }

        public void playerHealSpell()
        {
            if(currentMana >= 40)
            {
                currentMana -= 40;
                healPower = maxMana / healPower;
                Health += healPower;
            }
            else if(currentMana < 40)
            {
                Console.WriteLine("\nYou don't have enough mana to heal (40 Mana required).");
            }
        }

    }
    