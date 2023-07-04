using System.ComponentModel.DataAnnotations;

namespace Newsletter.ViewModels
{
    /// <summary>
    /// Модель представления новостной рассылки.
    /// </summary>
    public class NewsletterViewModel
    {
        /// <summary>
        /// Тема сообщения.
        /// </summary>
        [Display(Name = "Тема")]
        public string? Subject { get; set; } = null;

        /// <summary>
        /// Содержание сообщения.
        /// </summary>
        [Required(ErrorMessage = "Содержание должно быть заполнено")]
        [Display(Name = "Содержание")]
        public string Body { get; set; } = null!;

        /// <summary>
        /// Список получателей.
        /// </summary>
        [MinLength(1, ErrorMessage = ("Список получателей пуст"))]
        [Display(Name = "Список получателей")]
        public List<string> Recipients { get; set; } = null!;
    }
}
