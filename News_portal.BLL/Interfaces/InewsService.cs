using News_portal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_portal.BLL.Interfaces
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetAllNewsAsync();

        Task<IEnumerable<News>> FindNewsAsync(Func<News, bool> predicate);

        Task<IQueryable<News>> Query();

        Task<News> GetNewsByIdAsync(int id);

        Task CreateNewsAsync(News news);

        Task UpdateNewsAsync(News news);

        Task DeleteNewsAsync(News news);

        Task<int> CountNewsAsync(Func<News, bool> predicate);

        Task<List<News>> GetUsersFavoritesAsync(string id);

        Task RemoveNewsFromUserFavorites(int newsId, string userId);

        Task AddNewsToUserFavorites(int newsId, string userId);
    }
}
