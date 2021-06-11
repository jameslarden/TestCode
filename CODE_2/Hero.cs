 public class Hero
{
    /*
Health, Stamina, Strength, Mana
    */
string playerName, playerWeapon;
int Health, Stamina, Strength, Mana;

//Constructor called on class creation - see line 20 on gamemanager.cs    
public Hero(int SHealth, int SStamina, int SStrength, int SMana, string splayerName, string splayerWeapon)
{
    //assign temporary creation values to class variables
    Health = SHealth;
    Stamina = SStamina;
    Strength = SStrength;
    Mana = SMana;
    playerName = splayerName;
    playerWeapon = splayerWeapon;
}

    //allows other classes to see Heros health
    public int GetHealth()
    {
        return Health;
    }
    public int GetStamina()
    {
        return Stamina;
    }
        public int GetMana()
    {
        return Mana;
    }
        public string GetplayerName()
    {
        return playerName;
    }
        
        public int GetAllStats()
        {
            return Health;

        }

    public bool isdead()
    {
        return Health <= 0;
    }

    //void means a function does not need to return
    public void takeDamage(int Damage)
    {
        Health -= Damage;
    }
    //return for stamina strength mana and name
}