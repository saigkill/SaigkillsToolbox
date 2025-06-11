// <copyright file="EmailServiceWithAuth.cs" company="Sascha Manns">
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

using System;
using System.Threading.Tasks;

using Ardalis.GuardClauses;

using Checker;

using MailKit.Net.Smtp;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MimeKit;

namespace Saigkill.Toolbox.Services
{
  /// <summary>
  /// Class EmailServiceWithAuth. Implements a Email server with authentication.
  /// Implements the <see cref="Services.IEmailService" />
  /// </summary>
  /// <seealso cref="Services.IEmailService" />
  public class EmailServiceWithAuth : IEmailService
  {
    private readonly ILogger<EmailServiceWithAuth> _logger;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Constructor for EmailService
    /// </summary>
    /// <param name="logger">Class logger.</param>
    /// <param name="configuration">The Configuration object.</param>
    public EmailServiceWithAuth(ILogger<EmailServiceWithAuth> logger, IConfiguration configuration)
    {
      _logger = logger;
      _configuration = configuration;
    }

    ///<summary>Method for sending an email..</summary>
    ///<param name = "message" >MimeMessage.</param>
    ///<exception cref = "ArgumentNullException" >
    ///<paramref name="message" /> ist null.</exception>
    // ReSharper disable once MethodTooLong
    public async Task SendMessageAsync(MimeMessage message)
    {
      Guard.Against.Null(message);

      if (message.To == null) throw new ArgumentNullException(nameof(message));
      if (message.From == null)
      {
        var defaultAddress =
          Guard.Against.NullOrEmpty(_configuration.GetValue<string>("EmailServer:DefaultEmailAddress"));
        var defaultSenderName = Guard.Against.NullOrEmpty(_configuration.GetValue<string>("EmailServer:DefaultSenderName"));
        message.From?.Add(new MailboxAddress(defaultSenderName, defaultAddress));
      }

      try
      {
        var user = Guard.Against.NullOrEmpty(_configuration.GetValue<string>("EmailServer:User"));
        var password = Guard.Against.NullOrEmpty(_configuration.GetValue<string>("EmailServer:Password"));
        var port = Guard.Against.NegativeOrZero(_configuration.GetValue<int>("EmailServer:Port"));
        var useSsl = _configuration.GetValue<bool>("EmailServer:UseSSL");
        var smtpHost = Guard.Against.NullOrEmpty(_configuration.GetValue<string>("EmailServer:Host"));
        if (Firewall.PingIp(smtpHost))
        {
          var smtpClient = new SmtpClient();
          await smtpClient.ConnectAsync(smtpHost, port, useSsl).ConfigureAwait(false);
          await smtpClient.AuthenticateAsync(user, password).ConfigureAwait(false);
          await smtpClient.SendAsync(message).ConfigureAwait(false);
          await smtpClient.DisconnectAsync(true).ConfigureAwait(false);
          _logger.LogInformation("Sent email");
        }
        else
        {
          _logger.LogInformation("Firewall blockt die Verbindung.");
        }
      }
#pragma warning disable S2139
      catch (Exception ex)
#pragma warning restore S2139
      {
        _logger.LogError(ex, "Error while sending email: {0}", ex);
        throw;
      }

      _logger.Log(LogLevel.Debug, "Email successful sent.");
    }
  }
}
