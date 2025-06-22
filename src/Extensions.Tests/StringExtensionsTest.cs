using System;

using JetBrains.Annotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saigkill.Toolbox.Extensions.Tests
{

  [TestClass]
  [TestSubject(typeof(StringExtensions))]
  public class StringExtensionsTest
  {

    [TestMethod]
    public void GetSalutationText_ShouldReturnHerr_WhenGenderIsMale()
    {
      // Arrange
      var gender = "Male";
      // Act
      var result = gender.GetSalutationText();
      // Assert
      Assert.AreEqual("Herr", result);
    }

    [TestMethod]
    public void GetSalutationText_ShouldReturnFrau_WhenGenderIsFemale()
    {
      // Arrange
      var gender = "Female";
      // Act
      var result = gender.GetSalutationText();
      // Assert
      Assert.AreEqual("Frau", result);
    }

    [TestMethod]
    public void GetSalutationText_ShouldReturnEmpty_WhenGenderIsUnknown()
    {
      // Arrange
      var gender = "Unknown";
      // Act
      var result = gender.GetSalutationText();
      // Assert
      Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetSalutationText_ShouldThrowException_WhenGenderIsNull()
    {
      // Arrange
      string? gender = null;
      // Act
      gender.GetSalutationText();
    }

    [TestMethod]
    public void ReturnGenderId_ShouldReturn1_WhenGenderIsMale()
    {
      // Arrange
      var gender = "Male";
      // Act
      var result = gender.ReturnGenderId();
      // Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void ReturnGenderId_ShouldReturn2_WhenGenderIsFemale()
    {
      // Arrange
      var gender = "Female";
      // Act
      var result = gender.ReturnGenderId();
      // Assert
      Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void ReturnGenderId_ShouldReturnMinus1_WhenGenderIsUnknown()
    {
      // Arrange
      var gender = "Unknown";
      // Act
      var result = gender.ReturnGenderId();
      // Assert
      Assert.AreEqual(-1, result);
    }

    [TestMethod]
    public void IsNullOrEmpty_ShouldReturnTrue_WhenStringIsNull()
    {
      // Arrange
      string? value = null;
      // Act
      var result = value.IsNullOrEmpty();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsNullOrEmpty_ShouldReturnTrue_WhenStringIsEmpty()
    {
      // Arrange
      var value = string.Empty;
      // Act
      var result = value.IsNullOrEmpty();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsNullOrEmpty_ShouldReturnFalse_WhenStringIsNotEmpty()
    {
      // Arrange
      var value = "Test";
      // Act
      var result = value.IsNullOrEmpty();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsNotNullOrEmpty_ShouldReturnFalse_WhenStringIsNull()
    {
      // Arrange
      string? value = null;
      // Act
      var result = value.IsNotNullOrEmpty();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsNotNullOrEmpty_ShouldReturnFalse_WhenStringIsEmpty()
    {
      // Arrange
      var value = string.Empty;
      // Act
      var result = value.IsNotNullOrEmpty();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsNotNullOrEmpty_ShouldReturnTrue_WhenStringIsNotEmpty()
    {
      // Arrange
      var value = "Test";
      // Act
      var result = value.IsNotNullOrEmpty();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void ToSafeString_ShouldReturnEmpty_WhenObjectIsNull()
    {
      // Arrange
      object? value = null;
      // Act
      var result = value.ToSafeString();
      // Assert
      Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void ToSafeString_ShouldReturnStringRepresentation_WhenObjectIsNotNull()
    {
      // Arrange
      var value = 123;
      // Act
      var result = value.ToSafeString();
      // Assert
      Assert.AreEqual("123", result);
    }

    [TestMethod]
    public void Truncate_ShouldReturnTruncatedString_WhenStringExceedsMaxLength()
    {
      // Arrange
      var value = "This is a long string";
      var maxLength = 10;
      // Act
      var result = value.Truncate(maxLength);
      // Assert
      Assert.AreEqual("This is a ", result);
    }

    [TestMethod]
    public void Truncate_ShouldReturnOriginalString_WhenStringIsShorterThanMaxLength()
    {
      // Arrange
      var value = "Short";
      var maxLength = 10;
      // Act
      var result = value.Truncate(maxLength);
      // Assert
      Assert.AreEqual("Short", result);
    }

    [TestMethod]
    public void Truncate_ShouldReturnEmpty_WhenStringIsNullOrEmpty()
    {
      // Arrange
      string? value = null;
      var maxLength = 10;
      // Act
      var result = value.Truncate(maxLength);
      // Assert
      Assert.AreEqual(string.Empty, result);
    }
  }
}
