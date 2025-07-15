using Ardalis.Result;

using JetBrains.Annotations;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Saigkill.Toolbox.Checker.Tests
{

  [TestClass]
  [TestSubject(typeof(Firewall))]
  public class FirewallTest
  {
    [TestMethod]
    public void CheckIpAndPortTest()
    {
      // Arrange
      string ip = "13.107.246.45"; // microsoft.com
      int port = 80;

      // Act
      Result result = Firewall.CheckIpAndPort(ip, port);

      // Assert
      Assert.IsTrue(result.IsOk());
    }

    [TestMethod]
    public void CheckIpAndPortTest_InvalidIp()
    {
      // Arrange
      string ip = "300.300.300.300";
      int port = 80;

      // Act
      Result result = Firewall.CheckIpAndPort(ip, port);

      // Assert
      Assert.IsFalse(result.IsSuccess);
    }

    [TestMethod]
    public void CheckIpAndPortTest_InvalidPort()
    {
      // Arrange
      string ip = "127.0.0.1";
      int port = -1;

      // Act
      Result result = Firewall.CheckIpAndPort(ip, port);

      // Assert
      Assert.IsFalse(result.IsSuccess);
    }

    [TestMethod]
    public void PingIpTest()
    {
      // Arrange
      string ip = "127.0.0.1";

      // Act
      Result result = Firewall.PingIp(ip);

      // Assert
      Assert.IsTrue(result.IsSuccess);
    }

    [TestMethod]
    public void PingIpTest_InvalidIp()
    {
      // Arrange
      string ip = "300.300.300.300";

      // Act
      Result result = Firewall.PingIp(ip);

      // Assert
      Assert.IsFalse(result.IsSuccess);
    }
  }
}
