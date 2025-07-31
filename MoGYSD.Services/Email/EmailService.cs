using MoGYSD.ViewModels.Email;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace MoGYSD.Services
{
    public interface IEmailService
	{
		Task SendEmailAsync<T>(EmailViewModel<T> emailViewModel);

		Task SendEmailAsync(string toAddress, string subject, string htmlMessage);

		Task<string> Create<T>(T model);
	}

	public class EmailService : IEmailService
	{
		private readonly string _host;
		private readonly string _from;
		private readonly IConfiguration _configuration;
		private readonly int _port;
		private readonly string _username;
		private readonly string _password;
		private readonly bool _isHtml;
		private readonly bool _enableSSL;
		private readonly string _path;
		private readonly IRazorViewRenderer _viewRender;

		public EmailService(IConfiguration configuration, IRazorViewRenderer viewRender)
		{
			_viewRender = viewRender;
			_configuration = configuration;
			_from = _configuration["EmailSender:From"];
			_host = _configuration["EmailSender:Host"];
			_port = int.Parse(_configuration["EmailSender:Port"]);
			_password = _configuration["EmailSender:Password"];
			_username = _configuration["EmailSender:Username"];
			_isHtml = bool.Parse(_configuration["EmailSender:IsBodyHtml"]);
			_enableSSL = bool.Parse(_configuration["EmailSender:EnableSSL"]);
			_path = _configuration["EmailSender:FileFolder"];

			if (string.IsNullOrEmpty(_path))
			{
				this._path = "Emails/";
			}
		}

		public async Task<string> Create<T>(T model)
		{
			return await _viewRender.RenderViewToStringAsync("", model);
		}

		public async Task<string> CreateMailMessage<T>(T model)
		{
			var emailMessage = "";
            var path = $"{_path}{typeof(T).Name}.cshtml".Replace("Email.cshtml", "");
            try
			{
				emailMessage = await _viewRender.RenderViewToStringAsync(path, model);
			}
			catch (Exception ex)
			{
				emailMessage = ex.ToString();
			}
			return emailMessage;
		}

		public async Task SendEmailAsync<T>(EmailViewModel<T> emailViewModel)
		{
			var body = await CreateMailMessage(emailViewModel.Email);
			var message = new MimeMessage();
			message.From.Add(MailboxAddress.Parse(_username));
			message.To.Add(MailboxAddress.Parse(emailViewModel.To));
			message.Subject = emailViewModel.Subject;
			var textFormat = emailViewModel.IsHtml ? TextFormat.Html : TextFormat.Plain;
			message.Body = new TextPart(textFormat)
			{
				Text = body
			};
			using (var client = new SmtpClient())
			{
				// Accept all SSL certificates (in case the server supports STARTTLS)
				client.ServerCertificateValidationCallback = (s, c, h, e) => true;
				await client.ConnectAsync(_host, _port, false);
				// Note: since we don't have an OAuth2 token, disable
				// the XOAUTH2 authentication mechanism.
				client.AuthenticationMechanisms.Remove("XOAUTH2");
				// Note: only needed if the SMTP server requires authentication
				await client.AuthenticateAsync(_username, _password);
				await client.SendAsync(message);
				await client.DisconnectAsync(true);
			}
		}

		public async Task SendEmailAsync(string toAddress, string subject, string htmlMessage)
		{
			var message = new MimeMessage();
			message.From.Add(MailboxAddress.Parse(_username));
			message.To.Add(MailboxAddress.Parse(toAddress));
			message.Subject = message.Subject;
			var textFormat = string.IsNullOrWhiteSpace(htmlMessage) ? TextFormat.Html : TextFormat.Plain;
			message.Body = new TextPart(textFormat)
			{
				Text = htmlMessage
			};

			using (var client = new SmtpClient())
			{
				// Accept all SSL certificates (in case the server supports STARTTLS)
				client.ServerCertificateValidationCallback = (s, c, h, e) => true;
				await client.ConnectAsync(_host, _port, false);

				// Note: since we don't have an OAuth2 token, disable
				// the XOAUTH2 authentication mechanism.
				client.AuthenticationMechanisms.Remove("XOAUTH2");
				// Note: only needed if the SMTP server requires authentication
				await client.AuthenticateAsync(_username, _password);
				await client.SendAsync(message);
				await client.DisconnectAsync(true);
			}
		}
	}

}
