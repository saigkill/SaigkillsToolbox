using System;

using JetBrains.Annotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saigkill.Toolbox.Extensions.Tests
{

  [TestClass]
  [TestSubject(typeof(DateTimeExtensions))]
  public class DateTimeExtensionsTest
  {

    [TestMethod]
    public void ConvertDateToNumeric_ShouldReturnCorrectInteger()
    {
      // Arrange
      var date = new DateTime(2023, 10, 15);
      // Act
      var result = date.ConvertDateToNumeric();
      // Assert
      Assert.AreEqual(20231015, result);
    }

    [TestMethod]
    public void ConvertDateTimeToString_ShouldReturnFormattedString()
    {
      // Arrange
      var date = new DateTime(2023, 10, 15, 14, 30, 45);
      // Act
      var result = date.ConvertDateTimeToString();
      // Assert
      Assert.AreEqual("2023-10-15 14:30:45Z", result);
    }

    [TestMethod()]
    public void IsBetween_ShouldReturnTrue_WhenDateIsInRange()
    {
      // Arrange
      var date = new DateTime(2023, 10, 15);
      var startDate = new DateTime(2023, 10, 1);
      var endDate = new DateTime(2023, 10, 31);
      // Act
      var result = date.IsBetween(startDate, endDate);
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod()]
    public void StartOfDay_ShouldReturnDateAtStartOfDay()
    {
      // Arrange
      var date = new DateTime(2023, 10, 15, 14, 30, 45);
      // Act
      var result = date.StartOfDay();
      // Assert
      Assert.AreEqual(new DateTime(2023, 10, 15, 0, 0, 0), result);
    }

    [TestMethod()]
    public void EndOfDay_ShouldReturnDateAtEndOfDay()
    {
      // Arrange
      var date = new DateTime(2023, 10, 15, 14, 30, 45);
      // Act
      var result = date.EndOfDay();
      // Assert
      Assert.AreEqual(new DateTime(2023, 10, 15, 23, 59, 59, 999), result);
    }

    [TestMethod()]
    public void IsWeekend_ShouldReturnTrue_WhenDateIsSaturday()
    {
      // Arrange
      var date = new DateTime(2023, 10, 14); // Saturday
      // Act
      var result = date.IsWeekend();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod()]
    public void NextBusinessDay_ShouldReturnNextMonday_WhenDateIsFriday()
    {
      // Arrange
      var date = new DateTime(2023, 10, 13); // Friday
      // Act
      var result = date.NextBusinessDay();
      // Assert
      Assert.AreEqual(new DateTime(2023, 10, 16), result); // Monday
    }
  }
}
