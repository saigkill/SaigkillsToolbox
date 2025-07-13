using System;
using System.Collections.Generic;
using System.Linq;

namespace Saigkill.Toolbox.Extensions
{
  /// <summary>
  /// Class for IEnumerable Extensions
  /// </summary>
  public static class EnumerableExtensions
  {
    /// <summary>
    /// Checks if the IEnumerable is null or empty
    /// </summary>
    /// <typeparam name="T">Type of Source</typeparam>
    /// <param name="collection">IEnumeration to check.</param>
    /// <returns>true or false</returns>
    public static bool IsEmpty<T>(this IEnumerable<T>? collection)
    {
      if (collection == null) return true;
      return false;
    }

    /// <summary>
    /// Checks if the IEnumerable is not null and not empty
    /// </summary>
    /// <typeparam name="T">Type of Source</typeparam>
    /// <param name="collection">IEnumeration to check</param>
    /// <returns>true or false</returns>
    public static bool IsNotEmpty<T>(this IEnumerable<T>? collection)
    {
      if (collection != null && collection.Any()) return true;
      return false;
    }

    /// <summary>
    /// Determines whether [is null or empty] [the specified collection].
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <returns><c>true</c> if [is null or empty] [the specified collection]; otherwise, <c>false</c>.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
    {
      return collection == null || !collection.Any();
    }

    /// <summary>
    /// Determines whether the specified collection has items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <returns><c>true</c> if the specified collection has items; otherwise, <c>false</c>.</returns>
    public static bool HasItems<T>(this IEnumerable<T> collection)
    {
      return collection != null && collection.Any();
    }

    /// <summary>
    /// Fors the each.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <param name="action">The action.</param>
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
      if (collection == null || action == null) return;

      foreach (var item in collection)
      {
        action(item);
      }
    }

    /// <summary>
    /// Wheres the not null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> collection) where T : class
    {
      return collection?.Where(item => item != null) ?? Enumerable.Empty<T>();
    }

    /// <summary>
    /// Converts to safelist.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <returns>List&lt;T&gt;.</returns>
    public static List<T> ToSafeList<T>(this IEnumerable<T> collection)
    {
      return collection?.ToList() ?? new List<T>();
    }
  }
}
