using System;

class Entity
{
	public int health {get;set;}
    public int attack {get;set;}
    public int money {get;set;}
}

class Player : Entity
{
	public string name;
	
	public Player(string name)
    {
		this.name = name;
        this.health = 1000;
        this.attack = 50;
        this.money = 0;
    }
}

class Enemy : Entity
{
    public Enemy(int hp, int atk)
    {
        this.health = hp;
        this.attack = atk;
        Random r = new Random();
        this.money = r.Next(1,100);
    }
}

class Boss : Enemy 
{
	public Boss(int hp, int atk) : base(hp, atk)
	{
		this.health = hp;
		this.attack = atk;
		this.money = 2500;
	}
	public void warCry()
	{
		Console.WriteLine("The boss lets out a mighty roar!");
	}
}

public class Program()
{
    static void Main()
    {
		Console.WriteLine("Enter your name: ");
		Player player = new Player(Console.ReadLine());
        Enemy goblin = new Enemy(100, 20);
		Boss demon = new Boss(1750, 75);

		Console.WriteLine("Welcome to the game, " + player.name + "!");
    }
}