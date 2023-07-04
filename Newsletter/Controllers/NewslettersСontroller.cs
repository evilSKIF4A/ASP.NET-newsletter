using Newsletter.Models;
using Newsletter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Status;
using Newsletter.Services;
using Newsletter.Data;
using Microsoft.EntityFrameworkCore;

namespace Newsletter.Controllers
{

    /// <summary>
    /// <para>Контроллер для обработки новостых рассылок.</para>
    /// <para>Унаследован от класса Microsoft.AspNetCore.Mvc.ControllerBase.</para>
    /// </summary>
    [ApiController]
    [Route("api/mails/[controller]")]
    public class NewslettersСontroller : ControllerBase
    {
        private readonly ILogger<NewslettersСontroller> _logger;
        private readonly NewsService _newsService;
        private readonly DataContext _dataContext;
        private readonly ConnectionToSMTP _connectionToSMTP;

        /// <summary>
        /// Конструктор получает сервис ILogger, сервис NewsService, контекст DataContext, сервис ConnectionToSMTP
        /// </summary>
        /// <param name="logger">Сервис ILogger</param>
        /// <param name="newsService">Сервис NewsService</param>
        /// <param name="dataContext">Контекст DataContext</param>
        /// <param name="connectionToSMTP">Сервис ConnectionToSMTP</param>
        public NewslettersСontroller(ILogger<NewslettersСontroller> logger, NewsService newsService, DataContext dataContext, ConnectionToSMTP connectionToSMTP)
        {
            _logger = logger;
            _newsService = newsService;
            _dataContext = dataContext;
            _connectionToSMTP = connectionToSMTP;
        }

        /// <summary>
        /// Асинхронная задача, которая выполняет рассылку на полученные почтовые адреса.
        /// </summary>
        /// <param name="newsletter">Модель представления новостной рассылки</param>
        [HttpPost("CreateNewsletters")]
        public async Task CreateNewsletters(NewsletterViewModel newsletter)
        {
            try
            {
                await _connectionToSMTP.OpenConnection();
                foreach(string email in newsletter.Recipients){
                   string FailedMessage = await _newsService.SendEmail(newsletter.Subject, newsletter.Body, email);
                    NewsletterHistory _doc = new NewsletterHistory() {Subject = newsletter.Subject, Body = newsletter.Body, Recipient = email,
                        Result = FailedMessage == null ? ResultStatus.OK : ResultStatus.FAILED, FailedMessage = FailedMessage};
                    await _dataContext.newsletterHistories.AddAsync(_doc);
                }
                await _dataContext.SaveChangesAsync();
                await _connectionToSMTP.CloseConnection();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
           
        }

        /// <summary>
        /// Асинхронная задача, которая возвращает историю новостных рассылок.
        /// </summary>
        /// <returns>Возвращает список новостных рассылок</returns>
        [HttpGet("GetNewsletterHistories")]
        public async Task<List<NewsletterHistory>> GetNewsletterHistories()
        {
            return await _dataContext.newsletterHistories.ToListAsync();
        }
    }
}
