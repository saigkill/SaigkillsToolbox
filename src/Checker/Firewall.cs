using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using Ardalis.GuardClauses;
using Ardalis.Result;

namespace Saigkill.Toolbox.Checker
{

  /// <summary>
  /// Class for checking the firewall.
  /// </summary>
  public static class Firewall
  {
    /// <summary>
    /// Check if a port on a ip is open.
    /// </summary>
    /// <param name="ip">IP to check</param>
    /// <param name="portNumber">Port to check.</param>
    /// <returns>State if True or False.</returns>
    public static Result CheckIpAndPort(string ip, int portNumber)
    {
      Guard.Against.NullOrEmpty(ip);
      Guard.Against.Null(ip);

      var tcpClient = new TcpClient();

      try
      {
        tcpClient.Connect(ip, portNumber);
        tcpClient.Dispose();
        return Result.Success();
      }
      catch (Exception)
      {
        return Result.Error();
      }
    }

    /// <summary>
    /// Pings an IP.
    /// </summary>
    /// <param name="ip">IP to ping.</param>
    /// <returns>True or false.</returns>
    public static Result PingIp(string ip)
    {
      Guard.Against.NullOrEmpty(ip);
      try
      {
        var ping = new Ping();
        var pingReply = ping.Send(ip);
        if (pingReply.Status == IPStatus.Success)
        {
          return Result.Success();
        }

        return Result.Error();
      }
      catch
      {
        return Result.Error();
      }
    }
  }
}
