namespace Newsletter.Models
{
    /// <summary>
    /// Модель содержащая конфигурации SMTP.
    /// </summary>
    public class SMTPConfigModel
    {
        /// <summary>
        /// <para>Адрес отправителя. </para>
        /// <para>Требуется при формировании сообщения. </para>
        /// </summary>
        public string? SenderAddress { get; set; }

        /// <summary>
        /// <para>Имя отправителя. </para>
        /// <para>Требуется при формировании сообщения. </para>
        /// </summary>
        public string? SenderName { get; set; }

        /// <summary>
        /// Логин для авторизации на сервере.
        /// </summary>
        public string? AuthLogin { get; set; }
        
        /// <summary>
        /// Пароль для авторизации на сервере.
        /// </summary>
        public string? AuthPassword { get; set; }

        /// <summary>
        /// Имя хоста, к которому нужно подключиться.
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        /// <para>Порт для подключения. </para>
        /// <para>Если указанный порт равен 0, то будет использоваться порт по умолчанию. </para>
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Логическое значение, указывающее, будет ли применяться SSL.
        /// </summary>
        public bool ProtectedConnect { get; set; }
    }
}
