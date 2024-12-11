using System;
using System.Text.RegularExpressions;

public static class ValidationUtils
{
    /// <summary>
    /// Validates if a string is not null, empty, or whitespace.
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <returns>True if valid, otherwise false.</returns>
    public static bool IsValidString(string input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }

    /// <summary>
    /// Validates if a string matches a specific regex pattern.
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <param name="pattern">The regex pattern.</param>
    /// <returns>True if the string matches the pattern, otherwise false.</returns>
    public static bool IsValidPattern(string input, string pattern)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern))
            return false;

        return Regex.IsMatch(input, pattern);
    }

    /// <summary>
    /// Validates if a decimal value is greater than or equal to a specified minimum.
    /// </summary>
    /// <param name="value">The decimal value to validate.</param>
    /// <param name="minValue">The minimum allowed value.</param>
    /// <returns>True if the value is valid, otherwise false.</returns>
    public static bool IsValidDecimal(decimal value, decimal minValue = 0)
    {
        return value >= minValue;
    }

    /// <summary>
    /// Validates if an integer is within a specified range.
    /// </summary>
    /// <param name="value">The integer value to validate.</param>
    /// <param name="minValue">The minimum allowed value.</param>
    /// <param name="maxValue">The maximum allowed value.</param>
    /// <returns>True if the value is within range, otherwise false.</returns>
    public static bool IsValidRange(int value, int minValue, int maxValue)
    {
        return value >= minValue && value <= maxValue;
    }

    /// <summary>
    /// Validates if an email address is in a valid format.
    /// </summary>
    /// <param name="email">The email address to validate.</param>
    /// <returns>True if the email is valid, otherwise false.</returns>
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }
}
