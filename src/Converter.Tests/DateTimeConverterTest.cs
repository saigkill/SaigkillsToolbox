using System;
using System.Globalization;

using JetBrains.Annotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Converter.Tests
{
  [TestClass]
  [TestSubject(typeof(DateTimeConverter))]
  public class DateTimeConverterTest
  {
    [TestMethod]
    [DataRow("2023-01-01", DateTimeConverter.DateTimeModes.Year, 2023)]
    [DataRow("2023-01-01", DateTimeConverter.DateTimeModes.Month, 1)]
    [DataRow("2023-01-01", DateTimeConverter.DateTimeModes.Day, 1)]
    [DataRow("2000-12-31", DateTimeConverter.DateTimeModes.Year, 2000)]
    [DataRow("2000-12-31", DateTimeConverter.DateTimeModes.Month, 12)]
    [DataRow("2000-12-31", DateTimeConverter.DateTimeModes.Day, 31)]
    [DataRow("0001-01-01", DateTimeConverter.DateTimeModes.Year, 1)]
    [DataRow("0001-01-01", DateTimeConverter.DateTimeModes.Month, 1)]
    [DataRow("0001-01-01", DateTimeConverter.DateTimeModes.Day, 1)]
    [DataRow("9999-12-31", DateTimeConverter.DateTimeModes.Year, 9999)]
    [DataRow("9999-12-31", DateTimeConverter.DateTimeModes.Month, 12)]
    [DataRow("9999-12-31", DateTimeConverter.DateTimeModes.Day, 31)]
    public void SplitDateByMode_ValidInputs_ReturnsExpectedResult(string dateString,
      DateTimeConverter.DateTimeModes mode, int expected)
    {
      // Arrange
      DateTime dt = DateTime.Parse(dateString, CultureInfo.InvariantCulture);

      // Act
      int result = DateTimeConverter.SplitDateByMode(dt, mode);

      // Assert
      Assert.AreEqual(expected, result);
    }
  }
}
