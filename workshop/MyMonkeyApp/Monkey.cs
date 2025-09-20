namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species with relevant details.
/// </summary>
public class Monkey
{
    /// <summary>
    /// The name of the monkey species.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The primary location or habitat of the monkey.
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// A description or interesting fact about the monkey.
    /// </summary>
    public string Details { get; set; }

    /// <summary>
    /// The estimated population of the monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// The latitude of the monkey's habitat.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// The longitude of the monkey's habitat.
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// An image URL for the monkey (optional for ASCII art).
    /// </summary>
    public string? Image { get; set; }
}
