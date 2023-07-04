using Microsoft.Extensions.Options;
using MimeKit;
using Newsletter.Models;

namespace Newsletter.Services
{
    /// <summary>
    /// Сервис для новостных рассылок.
    /// </summary>
    public class NewsService
    {
        private readonly ILogger<NewsService> _logger;
        private readonly SMTPConfigModel _smtpConfig;

        /// <summary>
        /// <para>Конструктор класса NewsService.</para>
        /// <para>Параметр logger будет получать сервис ILogger.</para>
        /// <para>Параметр smtpConfig будет получать конфигурацию IOptions.</para>
        /// </summary>
        /// <param name="logger">Сервис ILogger</param>
        /// <param name="smtpConfig">Конфигурация IOptions</param>
        public NewsService(ILogger<NewsService> logger, IOptions<SMTPConfigModel> smtpConfig)
        {
            _logger = logger;
            _smtpConfig = smtpConfig.Value;
        }

        /// <summary>
        /// <para>Асинхронная задача, которая отправляет электронное сообщение. </para>
        /// <para>Необязательный параметр subject содержит тему сообщения. </para>
        /// <para>Параметр body содержит основую информацию сообщения. </para>
        /// <para>Параметр recipient содержит адрес получателя. </para>
        /// </summary>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="body">Содержание сообщения</param>
        /// <param name="recipient">Адрес получателя</param>
        /// <returns>Возвращает null если сообщение доставленно успешно, иначе возвращает сообщение об ошибке.</returns>
        public async Task<string> SendEmail(string? subject, string body, string recipient)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(name: _smtpConfig.SenderName, address: _smtpConfig.SenderAddress));
                message.To.Add(new MailboxAddress("", recipient));
                message.Subject = subject;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Text)
                {
                    Text = body
                };

                await ConnectionToSMTP.client.SendAsync(message);
                _logger.LogInformation("Сообщение отправлено");
                return null!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ex.Message;
            }
        }
    }
}
