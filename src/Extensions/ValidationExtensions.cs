// <copyright file="ValidationExtensions.cs" company="Sascha Manns">
// Copyright (c) 2025 Sascha Manns.
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the “Software”), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial
// portions of the Software.
// 
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
// ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

using System.Linq;
using System.Net.Mail;

namespace Saigkill.Toolbox.Extensions
{
  /// <summary>
  /// Class ValidationExtensions.
  /// </summary>
  public static class ValidationExtensions
  {
    /// <summary>
    /// Determines whether [is valid email] [the specified email].
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns><c>true</c> if [is valid email] [the specified email]; otherwise, <c>false</c>.</returns>
    public static bool IsValidEmail(this string email)
    {
      if (string.IsNullOrWhiteSpace(email)) return false;

      try
      {
        var addr = new MailAddress(email);
        return addr.Address == email;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// Determines whether [is valid phone number] [the specified phone number].
    /// </summary>
    /// <param name="phoneNumber">The phone number.</param>
    /// <returns><c>true</c> if [is valid phone number] [the specified phone number]; otherwise, <c>false</c>.</returns>
    public static bool IsValidPhoneNumber(this string phoneNumber)
    {
      if (string.IsNullOrWhiteSpace(phoneNumber)) return false;

      // Remove all non-numeric characters
      var cleaned = new string(phoneNumber.Where(char.IsDigit).ToArray());

      // Check if it's between 10-15 digits (international standard)
      return cleaned.Length >= 10 && cleaned.Length <= 15;
    }

    /// <summary>
    /// Determines whether [is in range] [the specified minimum].
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="min">The minimum.</param>
    /// <param name="max">The maximum.</param>
    /// <returns><c>true</c> if [is in range] [the specified minimum]; otherwise, <c>false</c>.</returns>
    public static bool IsInRange(this int value, int min, int max)
    {
      return value >= min && value <= max;
    }

    /// <summary>
    /// Determines whether [is in range] [the specified minimum].
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="min">The minimum.</param>
    /// <param name="max">The maximum.</param>
    /// <returns><c>true</c> if [is in range] [the specified minimum]; otherwise, <c>false</c>.</returns>
    public static bool IsInRange(this decimal value, decimal min, decimal max)
    {
      return value >= min && value <= max;
    }

    /// <summary>
    /// Validates the required.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <param name="fieldName">Name of the field.</param>
    /// <returns>ValidationResult.</returns>
    public static ValidationResult ValidateRequired<T>(this T value, string fieldName) where T : class
    {
      return value != null ?
        ValidationResult.Success :
        new ValidationResult($"{fieldName} is required");
    }
  }
}
