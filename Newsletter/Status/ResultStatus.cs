namespace Newsletter.Status
{
    /// <summary>
    /// Класс представляющий статус отправки сообщения.
    /// </summary>
    public class ResultStatus
    {
        /// <summary>
        /// Поле OK, если успешное выполнение.
        /// </summary>
        public const string OK = "OK";

        /// <summary>
        /// Поле FAILED, если неуспешное выполнение.
        /// </summary>
        public const string FAILED = "Failed";
    }
}
