using System;

public class Inhabitant
{
    protected int hp;
    protected int ac;
    protected int damage;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        Random r = new Random();
        this.hp = r.Next(10,21);
        this.ac = r.Next(10,18) - 10;
        this.damage = r.Next(1,6) + 5;
    }

     public string getData()
     {
        string s = this.name;
        s = s + " - " + this.hp + " / " + this.ac + " / " + this.damage;
        return s;
     }

     public int getAC()
     {
        return this.ac;
     }

     public int getDamage()
     {
        return this.damage;
     }

     public void takeDamage(int damage)
     {
        this.hp = this.hp - damage;
     }

     public bool isDead()
     {
        return this.hp <= 0;
     }
}

