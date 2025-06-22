// <copyright file="ValidationExtensionsTest.cs" company="Sascha Manns">
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Saigkill.Toolbox.Extensions.Tests
{
  [TestClass]
  public class ValidationExtensionsTests
  {
    [TestMethod]
    public void IsValidEmail_ShouldReturnTrue_ForValidEmail()
    {
      // Arrange
      var email = "test@example.com";
      // Act
      var result = email.IsValidEmail();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValidEmail_ShouldReturnFalse_ForInvalidEmail()
    {
      // Arrange
      var email = "invalid-email";
      // Act
      var result = email.IsValidEmail();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidEmail_ShouldReturnFalse_ForEmptyString()
    {
      // Arrange
      var email = "";
      // Act
      var result = email.IsValidEmail();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidPhoneNumber_ShouldReturnTrue_ForValidPhoneNumber()
    {
      // Arrange
      var phoneNumber = "+1234567890";
      // Act
      var result = phoneNumber.IsValidPhoneNumber();
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValidPhoneNumber_ShouldReturnFalse_ForInvalidPhoneNumber()
    {
      // Arrange
      var phoneNumber = "abc123";
      // Act
      var result = phoneNumber.IsValidPhoneNumber();
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsInRange_Int_ShouldReturnTrue_WhenValueIsInRange()
    {
      // Arrange
      var value = 5;
      // Act
      var result = value.IsInRange(1, 10);
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsInRange_Int_ShouldReturnFalse_WhenValueIsOutOfRange()
    {
      // Arrange
      var value = 15;
      // Act
      var result = value.IsInRange(1, 10);
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsInRange_Decimal_ShouldReturnTrue_WhenValueIsInRange()
    {
      // Arrange
      var value = 5.5m;
      // Act
      var result = value.IsInRange(1.0m, 10.0m);
      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsInRange_Decimal_ShouldReturnFalse_WhenValueIsOutOfRange()
    {
      // Arrange
      var value = 15.5m;
      // Act
      var result = value.IsInRange(1.0m, 10.0m);
      // Assert
      Assert.IsFalse(result);
    }

    [TestMethod]
    public void ValidateRequired_ShouldReturnSuccess_WhenValueIsNotNull()
    {
      // Arrange
      var value = "Test";
      var fieldName = "Field";
      // Act
      var result = value.ValidateRequired(fieldName);
      // Assert
      Assert.IsTrue(result.IsValid);
      Assert.IsNull(result.ErrorMessage);
    }

    [TestMethod]
    public void ValidateRequired_ShouldReturnFailure_WhenValueIsNull()
    {
      // Arrange
      string? value = null;
      var fieldName = "Field";
      // Act
      var result = value.ValidateRequired(fieldName);
      // Assert
      Assert.IsFalse(result.IsValid);
      Assert.AreEqual("Field is required", result.ErrorMessage);
    }
  }
}

