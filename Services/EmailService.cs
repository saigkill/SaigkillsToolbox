using System;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Checker;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MimeKit;

namespace Services
{
  /// <summary>
	/// Service for sending emails.
	/// </summary>
	public class EmailService : IEmailService
  {
    private readonly ILogger<EmailService> _logger;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Constructor for EmailService
    /// </summary>
    /// <param name="logger">Class logger.</param>
    /// <param name="configuration">The Configuration object.</param>
    public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
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
        var smtpIp = Guard.Against.NullOrEmpty(_configuration.GetValue<string>("EmailServer:ServerIP"));
        if (Firewall.PingIp(smtpIp))
        {
          var smtpClient = new SmtpClient();
          await smtpClient.ConnectAsync(smtpIp, 25, false).ConfigureAwait(false);
          await smtpClient.SendAsync(message).ConfigureAwait(false);
          await smtpClient.DisconnectAsync(true).ConfigureAwait(false);
          _logger.LogInformation("Sent email");
        }
        else
        {
          _logger.LogInformation("Firewall blockt die Verbindung.");
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error while sending email: {0}", ex);
        throw;
      }

      _logger.Log(LogLevel.Debug, "Email successful sent.");
    }
  }
}
