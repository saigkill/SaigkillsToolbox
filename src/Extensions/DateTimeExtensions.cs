using System;

using Ardalis.GuardClauses;

#pragma warning disable MA0011

namespace Saigkill.Toolbox.Extensions
{

  /// <summary>
  /// Class DateTimeExtensions.
  /// </summary>
  public static class DateTimeExtensions
  {
    /// <summary> Converts a given DateTime Object to yyyMMdd. </summary>
    /// <param name="dt">DateTime Object</param>
    /// <returns>Integer numeric DateTime</returns>
    public static int ConvertDateToNumeric(this DateTime dt)
    {
      Guard.Against.Null(dt);
      return int.Parse(dt.ToString("yyyyMMdd"));
    }

    /// <summary>
    /// Converts a given DateTime Object to yyyy-MM-dd HH:mm:ssZ.
    /// </summary>
    /// <param name="dt">DateTime Object.</param>
    /// <returns>System.String.</returns>
    public static string ConvertDateTimeToString(this DateTime dt)
    {
      Guard.Against.Null(dt);
      return dt.ToString("yyyy-MM-dd HH:mm:ssZ");
    }

    /// <summary>
    /// Determines whether the specified start date is between.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns><c>true</c> if the specified start date is between; otherwise, <c>false</c>.</returns>
    public static bool IsBetween(this DateTime dateTime, DateTime startDate, DateTime endDate)
    {
      return dateTime >= startDate && dateTime <= endDate;
    }

    /// <summary>
    /// Starts the of day.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>DateTime.</returns>
    public static DateTime StartOfDay(this DateTime dateTime)
    {
      return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
    }

    /// <summary>
    /// Ends the of day.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>DateTime.</returns>
    public static DateTime EndOfDay(this DateTime dateTime)
    {
      return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999, dateTime.Kind);
    }

    /// <summary>
    /// Gets the age.
    /// </summary>
    /// <param name="birthDate">The birth date.</param>
    /// <returns>System.Int32.</returns>
    public static int GetAge(this DateTime birthDate)
    {
      var today = DateTime.Today;
      var age = today.Year - birthDate.Year;
      if (birthDate.Date > today.AddYears(-age)) age--;
      return age;
    }

    /// <summary>
    /// Determines whether the specified date time is weekend.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns><c>true</c> if the specified date time is weekend; otherwise, <c>false</c>.</returns>
    public static bool IsWeekend(this DateTime dateTime)
    {
      return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
    }

    /// <summary>
    /// Nexts the business day.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>DateTime.</returns>
    public static DateTime NextBusinessDay(this DateTime dateTime)
    {
      var nextDay = dateTime.AddDays(1);
      while (nextDay.IsWeekend())
      {
        nextDay = nextDay.AddDays(1);
      }
      return nextDay;
    }
  }
}
