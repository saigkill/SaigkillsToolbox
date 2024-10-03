using System.Collections.Generic;

using JetBrains.Annotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Extensions.Tests
{
  [TestClass]
  [TestSubject(typeof(EnumerableExtensions))]
  public class EnumerableExtensionsTest
  {
    [TestMethod]
    [DataRow(null, true)]
    [DataRow(new string[] { "a", "b", "c" }, false)]
    public void IsEmptyTest(IEnumerable<object>? source, bool expected)
    {
      bool result = EnumerableExtensions.IsEmpty(source);
      Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow(null, false)]
    [DataRow(new string[] { "a", "b", "c" }, true)]
    [DataRow(new string[] { }, false)]
    public void IsNotEmptyTest(IEnumerable<object>? source, bool expected)
    {
      bool result = EnumerableExtensions.IsNotEmpty(source);
      Assert.AreEqual(expected, result);
    }
  }
}
