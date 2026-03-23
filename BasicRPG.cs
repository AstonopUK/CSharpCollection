using System;

class Entity
{
	public int health {get;set;}
    public int attack {get;set;}
    public int money {get;set;}
	
	public void outputHealth(string entity)
	{Console.WriteLine("The {0} has {1} health remaining.", entity, this.health);}
}

class Player : Entity
{
	public string name;
	public int[] position = new int[2];
	
	public Player(string name)
    {
		this.name = name;
        this.health = 1000;
        this.attack = 50;
        this.money = 0;
		this.position = new int[] {0,0};
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
		string[,] map = new string[,] {{"Field", "House", "Cabbage Patch", "Forest"},{"Field", "House", "Cabbage Patch", "Forest"},{"Field", "House", "Cabbage Patch", "Forest"},{"Field", "House", "Cabbage Patch", "Forest"}};
		
		Console.WriteLine("Enter your name: ");
		Player player = new Player(Console.ReadLine());
        Enemy goblin = new Enemy(100, 20);
		Boss demon = new Boss(1750, 75);

		Write("Welcome to the game, " + player.name + "!");
		Write("You are about to explore the new adventurous world!");
		Write("Enjoy!");
		
		while (true)
		{
			Write("Where would you like to go? [North] [South] [East] [West]");
			string direction = Console.ReadLine();
			try
			{
				switch(direction)
				{
					case "North":
						player.position[0]++;
						if (player.position[0]>3)
						{player.position[0] = 0;}
						break;
					case "East":
						player.position[1]++;
						if (player.position[1]>3)
						{player.position[1] = 0;}
						break;
					case "South":
						player.position[0]--;
						if (player.position[0]<0)
						{player.position[0] = 3;}
						break;
					case "West":
						player.position[1]--;
						if (player.position[1]<0)
						{player.position[1] = 3;}
						break;
					default:
						break;
				}
			}
			catch
			{Write("Invalid command!");}
			Console.WriteLine("You are now in the {0}.",map[player.position[0],player.position[1]]);
		}
    }
	static void Write(string output)
	{Console.WriteLine(output);}
}