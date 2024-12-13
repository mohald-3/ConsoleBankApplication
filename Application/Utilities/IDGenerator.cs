using System;
using System.Collections.Generic;

public class IDGenerator
{
    private static HashSet<string> _generatedIds = new HashSet<string>();

    /// <summary>
    /// Generates a unique ID with the specified prefix and length.
    /// </summary>
    /// <param name="prefix">A string to prepend to the ID (optional).</param>
    /// <param name="length">The total length of the ID, including the prefix.</param>
    /// <returns>A unique ID as a string.</returns>
    public static string Generate(string prefix = "", int length = 10)
    {
        if (length <= prefix.Length)
            throw new ArgumentException("Total length must be greater than the prefix length.");

        string uniqueId;
        var random = new Random();

        do
        {
            var numericPart = new string('0', length - prefix.Length)
                .Select(_ => random.Next(10).ToString()[0])
                .ToArray();

            uniqueId = prefix + new string(numericPart);
        }
        while (!_generatedIds.Add(uniqueId)); // Ensure the ID is unique

        return uniqueId;
    }
}
