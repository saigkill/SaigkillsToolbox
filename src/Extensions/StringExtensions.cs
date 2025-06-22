using Ardalis.GuardClauses;

namespace Saigkill.Toolbox.Extensions
{
  /// <summary>
  /// Class StringExtensions.
  /// </summary>
  public static class StringExtensions
  {
    /// <summary>
    /// Returns a salutation based on a given gender.
    /// </summary>
    /// <param name="gender">Gender</param>
    /// <returns>Herr oder Frau</returns>
    public static string GetSalutationText(this string gender)
    {
      Guard.Against.NullOrEmpty(gender);
      return gender switch
      {
        "Male" => "Herr",
        "Female" => "Frau",
        _ => ""
      };
    }

    /// <summary>
    /// Returns a integer based on a given gender.
    /// </summary>
    /// <param name="gender">Gender</param>
    /// <returns>Male = 1, Female = 2, Unknown = -1</returns>
    public static int ReturnGenderId(this string gender)
    {
      Guard.Against.NullOrEmpty(gender);
      return gender switch
      {
        "Male" => 1,
        "Female" => 2,
        _ => -1
      };
    }

    /// <summary>
    /// Determines whether [is null or empty] [the specified value].
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if [is null or empty] [the specified value]; otherwise, <c>false</c>.</returns>
    public static bool IsNullOrEmpty(this string value)
    {
      return string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// Determines whether [is not null or empty] [the specified value].
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if [is not null or empty] [the specified value]; otherwise, <c>false</c>.</returns>
    public static bool IsNotNullOrEmpty(this string value)
    {
      return !string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// Converts to safestring.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>System.String.</returns>
    public static string ToSafeString(this object value)
    {
      return value?.ToString() ?? string.Empty;
    }

    /// <summary>
    /// Truncates the specified maximum length.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="maxLength">The maximum length.</param>
    /// <returns>System.String.</returns>
    public static string Truncate(this string value, int maxLength)
    {
      if (string.IsNullOrEmpty(value)) return string.Empty;
      return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }
  }
}
