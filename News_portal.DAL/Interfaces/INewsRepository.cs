using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News_portal.DAL.Entities;

namespace News_portal.DAL.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllNewsAsync();

        Task<IEnumerable<News>> FindNewsAsync(Func<News, bool> predicate);

        Task<IQueryable<News>> Query();

        Task<News> GetNewsByIdAsync(int id);

        Task CreateNewsAsync(News news);

        Task UpdateNewsAsync(News news);

        Task DeleteNewsAsync(News news);

        Task Save();

        Task<int> CountNewsAsync(Func<News, bool> predicate);

        Task<List<News>> GetUsersFavoritesAsync(string id);

        Task RemoveNewsFromUserFavorites(int newsId, string userId);

        Task AddNewsToUserFavorites(int newsId, string userId);
    }
}
