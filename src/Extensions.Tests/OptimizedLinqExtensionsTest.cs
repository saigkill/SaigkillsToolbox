// <copyright file="OptimizedLinqExtensionsTest.cs" company="Sascha Manns">
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

using System.Collections.Generic;

using JetBrains.Annotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Saigkill.Toolbox.Extensions.Tests
{
  [TestClass]
  [TestSubject(typeof(OptimizedLinqExtensions))]
  public class OptimizedLinqExtensionsTests
  {
    [TestMethod]
    public void AnyFast_ShouldReturnTrue_WhenCollectionHasItems()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      // Act
      var result = collection.AnyFast();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void AnyFast_ShouldReturnFalse_WhenCollectionIsEmpty()
    {
      // Arrange
      var collection = new List<int>();
      // Act
      var result = collection.AnyFast();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void AnyFast_WithPredicate_ShouldReturnTrue_WhenPredicateMatches()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      // Act
      var result = collection.AnyFast(x => x > 2);
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void AnyFast_WithPredicate_ShouldReturnFalse_WhenPredicateDoesNotMatch()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      // Act
      var result = collection.AnyFast(x => x > 5);
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void FirstOrDefault_ShouldReturnFirstItem_WhenCollectionHasItems()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      // Act
      var result = collection.FirstOrDefault(0);
      // Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void FirstOrDefault_ShouldReturnDefaultValue_WhenCollectionIsEmpty()
    {
      // Arrange
      var collection = new List<int>();
      // Act
      var result = collection.FirstOrDefault(0);
      // Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void TakeFast_ShouldReturnSpecifiedNumberOfItems()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3, 4, 5 };
      // Act
      var result = collection.TakeFast(3);
      // Assert
      CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, new List<int>(result));
    }

    [TestMethod]
    public void TakeFast_ShouldReturnEmpty_WhenCountIsZero()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      // Act
      var result = collection.TakeFast(0);
      // Assert
      Assert.AreEqual(0, new List<int>(result).Count);
    }

    [TestMethod]
    public void TakeFast_ShouldReturnEmpty_WhenCollectionIsNull()
    {
      // Arrange
      IEnumerable<int>? collection = null;
      // Act
      var result = collection.TakeFast(3);
      // Assert
      Assert.AreEqual(0, new List<int>(result).Count);
    }
  }
}
