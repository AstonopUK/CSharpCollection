using System;
using System.Collections.Generic;
using System.Linq;

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
	private string[] enemyTypes = new string[] {"Aigamuxa", "Antman Warrior", "Bunyip", "Ciguapa", "Cyclopes", "Lesser Dragon", "Lesser Fenrir", "Golem", "Vicious Gremlin", "Jersey Devil", "Kongamato", "Loch Ness Barracuda", "Nandi Bear", "Roc", "Orc", "Ogre", "Talos", "Troll", "Skeleton", "Draugr"};
    public string type;
	public Enemy(int hp, int atk)
    {
        this.health = hp;
        this.attack = atk;
        Random r = new Random();
        this.money = r.Next(1,100);
		this.type = enemyTypes[r.Next(0,enemyTypes.Length)];
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
		string[,] map = {{"Castle Holdent","Wide Orchard","Rolling Fields","Urbos Hamlet","Western Badlands", "The Lunar Ocean", "Eaqeadore", "Gaglixar"},
            {"Grassy Grove","Rushly Village","Swampy Knoll","Kwarmi Jungle","The Expanse", "Iceglen", "The Rune Dominion", "Gleakiomund"},
            {"Arid Lowlands","Sand Banks","Vast Field","Pumpkin Patch","Northern Badlands", "Flellonet", "The Imagined Isle", "Strirranor"},
            {"Low-lying Mires","Waterlogged Village","Riverside Cliffs","High Peaks","The Pitch Black", "The Savage Plane", "The Phantom Valley", "The Mad Reach"},
            {"Hazey Frostlands","Frozen Lake","Snowy Town","Desolate Hills","Eastern Badlands", "The Miracle Territories", "The Final Moon", "Madmoor"},
            {"Garooreeg Tropics", "Lodcad Wetlands", "The Bush of Kisudogob", "Starruryon", "The Paradise of Ballirama", "The Mold", "The Feral Country", "???"},
            {"Riverwich Village", "Buteca Wild", "The Volcanic Jungle", "Flameshore", "Crabbiothra", "Wiommolon", "The Legend Province", "???"}};
		
		List<Enemy> enemies = new List<Enemy>();
		Random r = new Random();

		Console.WriteLine("Enter your name: ");
		Player player = new Player(Console.ReadLine());
		Boss demon = new Boss(1750, 75);

		Console.WriteLine("Welcome to the game, " + player.name + "!");
		Console.WriteLine("You are about to explore the new adventurous world!");
		Console.WriteLine("Enjoy!");
		
		while (true)
		{
			Console.WriteLine("Where would you like to go? [North] [South] [East] [West]");
			string direction = Console.ReadLine();
			try
			{
				switch(direction)
				{
					case "North":
						player.position[0]++;
						if (player.position[0]>7)
						{player.position[0] = 0;}
						break;
					case "East":
						player.position[1]++;
						if (player.position[1]>7)
						{player.position[1] = 0;}
						break;
					case "South":
						player.position[0]--;
						if (player.position[0]<0)
						{player.position[0] = 7;}
						break;
					case "West":
						player.position[1]--;
						if (player.position[1]<0)
						{player.position[1] = 7;}
						break;
					default:
						break;
				}

				if (r.Next(0,100) > 50)
				{
					for (int i = 0; i < r.Next(0,3); i++)
					{
						Enemy e = new Enemy(100, 20);
						enemies.Add(e);
					}
				}
				if (enemies.Count > 0)
				{
					string[] validActions = {"attack", "defend", "run"};
					foreach (Enemy enemy in enemies)
					{
						Console.WriteLine("You have encountered the {0}!", enemy.type);
						while (player.health > 0 & enemy.health > 0)
						{
							bool validInput = false;
							bool defending = false;
							bool running = false;
							string action = "";
							while (validInput == false)
							{
								Console.WriteLine("It is your turn to move. Type [Attack], [Defend] or [Run].");
								action = Console.ReadLine();
								if (validActions.Contains(action.ToLower()))
								{validInput = true;}
								else
								{Console.WriteLine("Invalid input entered! Try again.");}
							}
							switch (action.ToLower())
							{
								case "attack":
									enemy.health -= player.attack;
									if (enemy.health<0){enemy.health=0;}
									Console.WriteLine("You strike the enemy for {0} damage! The enemy is on {1} health.", player.attack, enemy.health);
									break;
								case "defend":
									defending = true;
									Console.WriteLine("You raise your defences, mitigating a portion of damage if the enemy strikes you.");
									break;
								case "run":
									if (r.Next(1,4)>2){running=true;}
									break;
								default:
									break;
									
							}
							if (running!=true)
							{
								Console.WriteLine("The {0} makes its move...", enemy.type);
								if (r.Next(1,20)<18)
								{
									Console.WriteLine("The {0} attacks!", enemy.type);
									if (defending)
									{player.health-=(int)enemy.attack/4;
									Console.WriteLine("The {0} dealt {1} damage!", enemy.type, (int)enemy.attack/4);}
									else
									{player.health-=enemy.attack;
									Console.WriteLine("The {0} dealt {1} damage!", enemy.type, enemy.attack);}
								}
								else
								{
									Console.WriteLine("The {0} ran away!", enemy.type);
									enemy.health = 0;
								}
							}
							else
							{
								enemy.health = 0;
							}
						}
					}
				}
				else
				{
					Console.WriteLine("You swiftly navigate past any danger.");
				}
			}
			catch
			{Console.WriteLine("Invalid command!");}

			Console.WriteLine("You are now in the {0}.",map[player.position[0],player.position[1]]);
		}
    }
}