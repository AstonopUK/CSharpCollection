using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter limit: ");
		int limit = Convert.ToInt32(Console.ReadLine())+1;
		FizzBuzz(limit);
	}
	static void FizzBuzz(int z)
	{
		for (int i = 1; i < z; i++)
		{
			string output = "";
			if (i % 3 == 0)
			{output += "Fizz";}
			if (i % 5 == 0)
			{output += "Buzz";}
			if (output == "")
			{output += Convert.ToString(i);}
			Console.WriteLine(output);
		}
	}
}
