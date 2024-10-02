using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Patterns.Tests
{
  [TestClass]
  [TestSubject(typeof(Pipeline<>))]
  public class PipelineTest
  {
    private Mock<ILogger<Pipeline<object>>> _loggerMock;
    private Pipeline<object> _pipeline;

    [TestInitialize]
    public void Setup()
    {
      _loggerMock = new Mock<ILogger<Pipeline<object>>>();
      _pipeline = new Pipeline<object>("TestPipeline", _loggerMock.Object);
    }

    [TestMethod]
    public void WithStep_AddsStepToPipeline()
    {
      // Arrange
      var stepMock = new Mock<IStep<object>>();

      // Act
      _pipeline.WithStep(stepMock.Object);

      // Assert
      Assert.AreEqual(1, _pipeline.Steps.Count);
      Assert.AreSame(stepMock.Object, _pipeline.Steps.First());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void WithStep_ThrowsArgumentNullException_WhenStepIsNull()
    {
      // Act
      _pipeline.WithStep(null);
    }

    [TestMethod]
    public async Task StartAsync_ExecutesAllStepsInOrderAsync()
    {
      // Arrange
      var step1Mock = new Mock<IStep<object>>();
      var step2Mock = new Mock<IStep<object>>();
      var data = new object();
      var intermediateData = new object();
      var finalData = new object();

      step1Mock.Setup(s => s.ExecuteAsync(data)).ReturnsAsync(intermediateData);
      step2Mock.Setup(s => s.ExecuteAsync(intermediateData)).ReturnsAsync(finalData);

      _pipeline.WithStep(step1Mock.Object);
      _pipeline.WithStep(step2Mock.Object);

      // Act
      var result = await _pipeline.StartAsync(data);

      // Assert
      Assert.AreSame(finalData, result);
      step1Mock.Verify(s => s.ExecuteAsync(data), Times.Once);
      step2Mock.Verify(s => s.ExecuteAsync(intermediateData), Times.Once);
    }

    [TestMethod]
    public async Task StartAsync_ReturnsInitialData_WhenNoStepsAreAddedAsync()
    {
      // Arrange
      var data = new object();

      // Act
      var result = await _pipeline.StartAsync(data);

      // Assert
      Assert.AreSame(data, result);
    }

    [TestMethod]
    public void Name_PropertyGetSet()
    {
      // Arrange
      var newName = "NewPipelineName";

      // Act
      _pipeline.Name = newName;

      // Assert
      Assert.AreEqual(newName, _pipeline.Name);
    }

    [TestMethod]
    public void Steps_PropertyReturnsReadOnlyCollection()
    {
      // Arrange
      var stepMock = new Mock<IStep<object>>();
      _pipeline.WithStep(stepMock.Object);

      // Act
      var steps = _pipeline.Steps;

      // Assert
      Assert.IsInstanceOfType(steps, typeof(IReadOnlyCollection<IStep<object>>));
      Assert.AreEqual(1, steps.Count);
      Assert.AreSame(stepMock.Object, steps.First());
    }
  }
}
