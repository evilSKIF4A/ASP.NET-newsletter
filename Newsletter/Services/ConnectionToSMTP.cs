using Microsoft.Extensions.Options;
using Newsletter.Models;

namespace Newsletter.Services
{
    /// <summary>
    /// Сервис для подключения к SMTP
    /// </summary>
    public class ConnectionToSMTP
    {
        private readonly SMTPConfigModel _smtpConfig;

        /// <summary>
        /// Статическое поля, которое используется для отправки сообщения.
        /// </summary>
        public static MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();

        /// <summary>
        /// <para>Конструктор класса ConnectionToSMTP. </para>
        /// <para>Параметр smtpConfig будет получать конфигурацию IOptions. </para>
        /// </summary>
        /// <param name="smtpConfig">Конфигурация IOptions</param>
        public ConnectionToSMTP(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }

        /// <summary>
        /// Асинхронная задача, которая открывает подключение к хосту.
        /// </summary>
        public async Task OpenConnection()
        {
            await client.ConnectAsync(_smtpConfig.Host, _smtpConfig.Port, _smtpConfig.ProtectedConnect);
            await client.AuthenticateAsync(_smtpConfig.AuthLogin, _smtpConfig.AuthPassword);
        }

        /// <summary>
        /// Асинхронная задача, которая закрывает подключение к хосту.
        /// </summary>
        public async Task CloseConnection()
        {
            await client.DisconnectAsync(true);
        }
    }
}
