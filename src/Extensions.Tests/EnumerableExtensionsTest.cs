using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saigkill.Toolbox.Extensions.Tests
{
  [TestClass]
  [TestSubject(typeof(EnumerableExtensions))]
  public class EnumerableExtensionsTest
  {
    [TestMethod]
    public void IsEmpty_ShouldReturnTrue_WhenCollectionIsNull()
    {
      // Arrange
      IEnumerable<int>? collection = null;
      // Act
      var result = collection.IsEmpty();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsEmpty_ShouldReturnFalse_WhenCollectionIsNotEmpty()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      // Act
      var result = collection.IsEmpty();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsNotEmpty_ShouldReturnTrue_WhenCollectionHasItems()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      // Act
      var result = collection.IsNotEmpty();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsNotEmpty_ShouldReturnFalse_WhenCollectionIsNull()
    {
      // Arrange
      IEnumerable<int>? collection = null;
      // Act
      var result = collection.IsNotEmpty();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsNullOrEmpty_ShouldReturnTrue_WhenCollectionIsNull()
    {
      // Arrange
      IEnumerable<int>? collection = null;
      // Act
      var result = collection.IsNullOrEmpty();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsNullOrEmpty_ShouldReturnTrue_WhenCollectionIsEmpty()
    {
      // Arrange
      var collection = Enumerable.Empty<int>();
      // Act
      var result = collection.IsNullOrEmpty();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void HasItems_ShouldReturnTrue_WhenCollectionHasItems()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      // Act
      var result = collection.HasItems();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void HasItems_ShouldReturnFalse_WhenCollectionIsNull()
    {
      // Arrange
      IEnumerable<int>? collection = null;
      // Act
      var result = collection.HasItems();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void ForEach_ShouldExecuteActionForEachItem()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      var result = new List<int>();
      // Act
      collection.ForEach(item => result.Add(item * 2));
      // Assert
      CollectionAssert.AreEqual(new List<int> { 2, 4, 6 }, result);
    }

    [TestMethod]
    public void WhereNotNull_ShouldFilterOutNullValues()
    {
      // Arrange
      var collection = new List<string?> { "a", null, "b", null, "c" };
      // Act
      var result = collection.WhereNotNull();
      // Assert
      CollectionAssert.AreEqual(new List<string> { "a", "b", "c" }, result.ToList());
    }

    [TestMethod]
    public void ToSafeList_ShouldReturnEmptyList_WhenCollectionIsNull()
    {
      // Arrange
      IEnumerable<int>? collection = null;
      // Act
      var result = collection.ToSafeList();
      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void ToSafeList_ShouldReturnListWithSameItems()
    {
      // Arrange
      var collection = new List<int> { 1, 2, 3 };
      // Act
      var result = collection.ToSafeList();
      // Assert
      CollectionAssert.AreEqual(collection, result);
    }
  }
}
