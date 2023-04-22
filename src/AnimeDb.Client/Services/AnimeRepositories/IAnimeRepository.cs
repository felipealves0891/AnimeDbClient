using AnimeDb.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Services.AnimeRepositories
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Genre>> GetGenresAsync();

        Task<Anime> GetById(string id);
    }
}
