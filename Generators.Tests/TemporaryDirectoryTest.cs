using System.IO;

using JetBrains.Annotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generators.Tests;

[TestClass]
[TestSubject(typeof(TemporaryDirectory))]
public class TemporaryDirectoryTest
{
  [TestMethod]
  public void GetTemporaryDirectory_ShouldReturnUniqueDirectoryPaths()
  {
    // Arrange & Act
    string tempDir1 = TemporaryDirectory.GetTemporaryDirectory();
    string tempDir2 = TemporaryDirectory.GetTemporaryDirectory();

    // Assert
    Assert.IsFalse(string.IsNullOrEmpty(tempDir1));
    Assert.IsFalse(string.IsNullOrEmpty(tempDir2));
    Assert.AreNotEqual(tempDir1, tempDir2);
    Assert.IsTrue(Directory.Exists(tempDir1));
    Assert.IsTrue(Directory.Exists(tempDir2));
  }

  [TestMethod]
  public void GetTemporaryDirectory_ShouldCreateDirectory()
  {
    // Act
    string tempDir = TemporaryDirectory.GetTemporaryDirectory();

    // Assert
    Assert.IsTrue(Directory.Exists(tempDir));
  }

  [TestMethod]
  public void GetTemporaryDirectory_ShouldHandleExistingDirectory()
  {
    // Arrange
    string existingTempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
    Directory.CreateDirectory(existingTempDir);

    // Act
    string tempDir = TemporaryDirectory.GetTemporaryDirectory();

    // Assert
    Assert.IsTrue(Directory.Exists(tempDir));
    Assert.AreNotEqual(existingTempDir, tempDir);
  }

  [TestMethod]
  public void GetTemporaryDirectory_ShouldHandleConcurrentCalls()
  {
    // Arrange
    const int numberOfCalls = 100;
    string[] tempDirs = new string[numberOfCalls];

    // Act
    for (int i = 0; i < numberOfCalls; i++)
    {
      tempDirs[i] = TemporaryDirectory.GetTemporaryDirectory();
    }

    // Assert
    for (int i = 0; i < numberOfCalls; i++)
    {
      Assert.IsFalse(string.IsNullOrEmpty(tempDirs[i]));
      Assert.IsTrue(Directory.Exists(tempDirs[i]));
      for (int j = i + 1; j < numberOfCalls; j++)
      {
        Assert.AreNotEqual(tempDirs[i], tempDirs[j]);
      }
    }
  }
}
