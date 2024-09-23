using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;

namespace Services.Tests;

[TestClass]
[TestSubject(typeof(CsvService))]
public class CsvServiceTest
{
  private Mock<ILogger<CsvService>> _mockLogger;

  [TestInitialize]
  public void SetUp()
  {
    _mockLogger = new Mock<ILogger<CsvService>>();
  }

  [TestMethod]
  public async Task Write_SendsDataToFileAsync()
  {
    var targetName = "test.csv";
    var sampleList = new List<Foo>
    {
      new Foo { Id = 1, Name = "Test1"},
      new Foo { Id = 2, Name = "Test2"}
    };

    // Arrange
    var service = new CsvService(_mockLogger.Object);

    // Act
    await service.WriteAsync(sampleList, targetName, ",", "de-DE");

    // Assert
    _mockLogger.Verify(m => m.Log(
      LogLevel.Debug,
      It.IsAny<EventId>(),
      It.IsAny<It.IsAnyType>(),
      It.IsAny<Exception>(),
      It.IsAny<Func<It.IsAnyType, Exception, string>>()));
  }

  [TestMethod]
  public async Task Write_ThrowsException_OnEmptyListAsync()
  {
    var targetName = "test.csv";
    var sampleList = new List<string>();

    // Arrange
    var service = new CsvService(_mockLogger.Object);

    // Act / Assert
    await Assert.ThrowsExceptionAsync<ArgumentException>(() => service.WriteAsync(sampleList, targetName, ",", "de-DE"));
  }

  [TestMethod]
  public async Task Write_ThrowsException_OnEmptyTargetAsync()
  {
    var sampleList = new List<string> { "test1", "test2" };

    // Arrange
    var service = new CsvService(_mockLogger.Object);

    // Act / Assert
    await Assert.ThrowsExceptionAsync<ArgumentException>(() => service.WriteAsync(sampleList, string.Empty, ",", "de-DE"));
  }

  [TestMethod]
  public async Task Write_ThrowsException_OnNullListAsync()
  {
    var targetName = "test.csv";

    // Arrange
    var service = new CsvService(_mockLogger.Object);

    // Act / Assert
    // ReSharper disable once AssignNullToNotNullAttribute
    await Assert.ThrowsExceptionAsync<ArgumentNullException>(
      () => service.WriteAsync<List<string>>(null, targetName, ",", "de-DE"));
  }

  [TestMethod]
  public async Task Write_ThrowsException_OnNullTargetAsync()
  {
    var sampleList = new List<string> { "test1", "test2" };

    // Arrange
    var service = new CsvService(_mockLogger.Object);

    // Act / Assert
    // ReSharper disable once AssignNullToNotNullAttribute
    await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => service.WriteAsync(sampleList, null, ",", "de-DE"));
  }
}
