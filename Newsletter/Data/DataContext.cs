using Microsoft.EntityFrameworkCore;
using Newsletter.Models;

namespace Newsletter.Data
{
    /// <summary>
    /// <para>Контекст данных. </para>
    /// <para>Унаследован от класса Microsoft.EntityFrameworkCore.DbContext.</para>
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// <para>Конструктор класса DataContext.</para>
        /// <para>Параметр options будет передаваться настройки контекста данных.</para>
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        /// <summary>
        /// Свойство NewsletterHistories будет представлять таблицу, в которой будут храниться объекты класса NewsletterHistory.
        /// </summary>
        public DbSet<NewsletterHistory> newsletterHistories => Set<NewsletterHistory>();
    }
}
