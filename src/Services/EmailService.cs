using System;
using System.Threading.Tasks;

using Ardalis.GuardClauses;

using MailKit.Net.Smtp;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using MimeKit;

using Saigkill.Toolbox.Checker;

namespace Saigkill.Toolbox.Services
{
    /// <summary>
    /// Service for sending emails.
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor for EmailService. This email service can be used, if the mailserver is reachable intern without password.
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
                var port = Guard.Against.NegativeOrZero(_configuration.GetValue<int>("EmailServer:Port"));

                if (Firewall.PingIp(smtpIp))
                {
                    var smtpClient = new SmtpClient();
                    await smtpClient.ConnectAsync(smtpIp, port, true).ConfigureAwait(false);
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
