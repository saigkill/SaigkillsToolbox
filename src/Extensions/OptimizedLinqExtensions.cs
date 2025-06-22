// <copyright file="OptimizedLinqExtensions.cs" company="Sascha Manns">
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

using System;
using System.Collections.Generic;

namespace Saigkill.Toolbox.Extensions
{
  /// <summary>
  /// Class OptimizedLinqExtensions.
  /// </summary>
  public static class OptimizedLinqExtensions
  {
    /// <summary>
    /// Anies the fast.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    public static bool AnyFast<T>(this ICollection<T> collection)
    {
      return collection != null && collection.Count > 0;
    }

    /// <summary>
    /// Anies the fast.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <param name="predicate">The predicate.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    public static bool AnyFast<T>(this ICollection<T> collection, Func<T, bool> predicate)
    {
      if (collection == null || predicate == null) return false;

      foreach (var item in collection)
      {
        if (predicate(item)) return true;
      }
      return false;
    }

    /// <summary>
    /// Firsts the or default.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>T.</returns>
    public static T FirstOrDefault<T>(this IEnumerable<T> collection, T defaultValue)
    {
      if (collection == null) return defaultValue;

      foreach (var item in collection)
      {
        return item;
      }
      return defaultValue;
    }

    /// <summary>
    /// Takes the fast.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <param name="count">The count.</param>
    /// <returns>IEnumerable&lt;T&gt;.</returns>
    public static IEnumerable<T> TakeFast<T>(this IEnumerable<T> collection, int count)
    {
      if (collection == null || count <= 0) yield break;

      var taken = 0;
      foreach (var item in collection)
      {
        if (taken >= count) yield break;
        yield return item;
        taken++;
      }
    }
  }
}
