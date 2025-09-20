
using MyMonkeyApp;

class Program
{
	private static readonly List<string> asciiArtList = new()
	{
		@"  (\__/)",
		@"  (•ㅅ•)",
		@"  / 　 づ",
		@"  (o.o)",
		@"  ( : )",
		@"  (\(\
  (-.-)
  o_(")(")",
		@"  (\_/)
  ( •_•)
  / >🍌"
	};

	static async Task Main()
	{
		while (true)
		{
			DisplayRandomAsciiArt();
			Console.WriteLine("\nMonkey Console Application");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");
			var input = Console.ReadLine();

			switch (input)
			{
				case "1":
					await ListAllMonkeysAsync();
					break;
				case "2":
					await GetMonkeyDetailsAsync();
					break;
				case "3":
					await GetRandomMonkeyAsync();
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Invalid option. Please try again.\n");
					break;
			}
		}
	}

	static void DisplayRandomAsciiArt()
	{
		var random = new Random();
		var art = asciiArtList[random.Next(asciiArtList.Count)];
		Console.WriteLine("\n" + art + "\n");
	}

	static async Task ListAllMonkeysAsync()
	{
		var monkeys = await MonkeyHelper.GetMonkeysAsync();
		Console.WriteLine("\nAvailable Monkeys:");
		Console.WriteLine("-------------------------------------------------------------");
		Console.WriteLine($"{'Name', -20} {'Location', -25} {'Population', -10}");
		Console.WriteLine("-------------------------------------------------------------");
		foreach (var monkey in monkeys)
		{
			Console.WriteLine($"{monkey.Name, -20} {monkey.Location, -25} {monkey.Population, -10}");
		}
		Console.WriteLine("-------------------------------------------------------------\n");
	}

	static async Task GetMonkeyDetailsAsync()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name ?? "");
		if (monkey == null)
		{
			Console.WriteLine($"Monkey '{name}' not found.\n");
			return;
		}
		Console.WriteLine($"\nName: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nLatitude: {monkey.Latitude}\nLongitude: {monkey.Longitude}\n");
	}

	static async Task GetRandomMonkeyAsync()
	{
		var monkey = await MonkeyHelper.GetRandomMonkeyAsync();
		if (monkey == null)
		{
			Console.WriteLine("No monkeys available.\n");
			return;
		}
		Console.WriteLine($"\nRandom Monkey: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nLatitude: {monkey.Latitude}\nLongitude: {monkey.Longitude}\n");
		Console.WriteLine($"Random monkey picked {MonkeyHelper.GetRandomMonkeyAccessCount()} times.\n");
	}
}
