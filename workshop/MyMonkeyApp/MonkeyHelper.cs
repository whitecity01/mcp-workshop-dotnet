using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// Provides static helper methods for managing monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static int randomMonkeyAccessCount = 0;

    /// <summary>
    /// Gets all available monkeys from the MCP server.
    /// </summary>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys != null)
            return monkeys;

        // TODO: Replace with actual MCP server call
        monkeys = await MonkeyMcpClient.FetchMonkeysAsync();
        return monkeys;
    }

    /// <summary>
    /// Gets a random monkey from the collection and tracks access count.
    /// </summary>
    public static async Task<Monkey?> GetRandomMonkeyAsync()
    {
        var allMonkeys = await GetMonkeysAsync();
        if (allMonkeys.Count == 0)
            return null;
        randomMonkeyAccessCount++;
        var random = new Random();
        return allMonkeys[random.Next(allMonkeys.Count)];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive).
    /// </summary>
    public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
    {
        var allMonkeys = await GetMonkeysAsync();
        return allMonkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a random monkey has been picked.
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;
}

/// <summary>
/// Simulates MCP server client for fetching monkey data.
/// Replace with actual MCP integration.
/// </summary>
internal static class MonkeyMcpClient
{
    public static async Task<List<Monkey>> FetchMonkeysAsync()
    {
        // Simulate async fetch with hardcoded data (replace with MCP API call)
        await Task.Delay(100); // Simulate network delay
        return new List<Monkey>
        {
            new Monkey { Name = "Baboon", Location = "Africa & Asia", Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio.", Population = 10000, Latitude = -8.783195, Longitude = 34.508523, Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg" },
            new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae.", Population = 23000, Latitude = 12.769013, Longitude = -85.602364, Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg" },
            // ... Add other monkeys here ...
        };
    }
}
