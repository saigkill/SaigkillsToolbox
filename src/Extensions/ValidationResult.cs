// <copyright file="ValidationResult.cs" company="Sascha Manns">
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

namespace Saigkill.Toolbox.Extensions
{
  /// <summary>
  /// Class ValidationResult.
  /// </summary>
  public class ValidationResult
  {
    /// <summary>
    /// Returns true if ... is valid.
    /// </summary>
    /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
    public bool IsValid { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    /// <value>The error message.</value>
    public string ErrorMessage { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    /// <param name="isValid">if set to <c>true</c> [is valid].</param>
    /// <param name="errorMessage">The error message.</param>
    private ValidationResult(bool isValid, string errorMessage = null)
    {
      IsValid = isValid;
      ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Gets the success.
    /// </summary>
    /// <value>The success.</value>
    public static ValidationResult Success => new ValidationResult(true);

    /// <summary>
    /// Failures the specified error message.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    /// <returns>ValidationResult.</returns>
    public static ValidationResult Failure(string errorMessage) => new ValidationResult(false, errorMessage);

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    public ValidationResult(string errorMessage) : this(false, errorMessage) { }
  }
}
