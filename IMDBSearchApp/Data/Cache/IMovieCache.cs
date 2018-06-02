using System;
using System.Collections.Generic;
using IMDBSearchApp.Data.Entity;

namespace IMDBSearchApp.Data.Cache
{
    public interface IMovieCache
    {
        List<MovieSummaryEntity> GetMoviesSummaryByKeyword(string keyword);

        MovieEntity GetMovieById(string imdbId);

        void PutAll(List<MovieSummaryEntity> entities);

        void Put(MovieEntity entity);

        void ClearAll();
    }
}
