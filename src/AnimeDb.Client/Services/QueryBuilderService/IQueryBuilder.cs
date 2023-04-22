using AnimeDb.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDb.Client.Services.QueryBuilderService
{
    public interface IQueryBuilder
    {
        IQueryBuilder Clear();

        IQueryBuilder AddPage(int page);

        IQueryBuilder AddPageSize(int size);

        IQueryBuilder AddSearch(string search);

        IQueryBuilder AddGenre(Genre genge);

        IQueryBuilder AddSortBy(string propertyName);

        IQueryBuilder AddSortOrder(bool isAsc);

        Task<Payload<Anime>> BuildAsync();

    }
}
