using News_portal.BLL.Interfaces;
using News_portal.DAL.Interfaces;
using News_portal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace News_portal.BLL.Services
{

    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        protected async Task Save() => await _newsRepository.Save();

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {    
            return await _newsRepository.GetAllNewsAsync();
        }

        public async Task<IEnumerable<News>> FindNewsAsync(Func<News, bool> predicate)
        {
          return await _newsRepository.FindNewsAsync(predicate);
        }

        public async Task<IQueryable<News>> Query()
        {
            return await _newsRepository.Query();
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            return await _newsRepository.GetNewsByIdAsync(id);
        }

        public async Task CreateNewsAsync(News news)
        {
            await _newsRepository.CreateNewsAsync(news);
        }

        public async Task UpdateNewsAsync(News news)
        {
            await _newsRepository.UpdateNewsAsync(news);
        }

        public async Task DeleteNewsAsync(News news)
        {
            await _newsRepository.DeleteNewsAsync(news);
        }

        public async Task<int> CountNewsAsync(Func<News, bool> predicate)
        {
            return await _newsRepository.CountNewsAsync(predicate);
        }

        public async Task<List<News>> GetUsersFavoritesAsync(string id)
        {
            return await _newsRepository.GetUsersFavoritesAsync(id);
        }

        public async Task RemoveNewsFromUserFavorites(int newsId, string userId)
        {
            await _newsRepository.RemoveNewsFromUserFavorites(newsId, userId);
        }

        public async Task AddNewsToUserFavorites(int newsId, string userId)
        {
            await _newsRepository.AddNewsToUserFavorites(newsId, userId);
        }

    }
}
