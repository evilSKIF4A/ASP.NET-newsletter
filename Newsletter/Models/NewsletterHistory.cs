using System.ComponentModel.DataAnnotations;

namespace Newsletter.Models
{
    /// <summary>
    /// Модель истории новостных рассылок.
    /// </summary>
    public class NewsletterHistory
    {
        /// <summary>
        /// <para>Уникальный идентификатор. </para>
        /// <para>Автоматически присваивается при создании экземпляра. </para>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// <para>Тема содержания письма. </para>
        /// <para>Если к полю ничего не присвоено, то тема письима считается: Без темы. </para>
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// <para>Основное содержание письма. </para>
        /// <para>Поле является обязательным для заполнения! </para>
        /// </summary>
        public string Body { get; set; } = null!;

        /// <summary>
        /// <para>Адрес получателя письма. </para>
        /// <para>Поле является обязательным для заполнения! </para>
        /// </summary>
        public string Recipient { get; set; } = null!;

        /// <summary>
        /// <para>Дата отправления письма. </para>
        /// <para>Автоматически присваивается при создании экземпляра. </para>
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// <para>Статус успешного отправления письма. </para>
        /// <para>Если письмо было отправлено успешно, то статус ОК, иначе Failed. </para>
        /// </summary>
        public string Result { get; set; } = null!;

       /// <summary>
       /// Содержит ошибку отсылки сообщения, если статус отправки Failed.
       /// </summary>
        public string? FailedMessage { get; set; } = null;
    }
}
