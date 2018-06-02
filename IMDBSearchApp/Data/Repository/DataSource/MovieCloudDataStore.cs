using System;
using System.Collections.Generic;
using IMDBSearchApp.Data.Entity;
using IMDBSearchApp.Data.Net;

namespace IMDBSearchApp.Data.Repository.DataSource
{
    public class MovieCloudDataStore : IMovieDataStore
    {
        IIMDBRestApi apiCleint = new IMDBRestApiClient();

        public IObservable<MovieEntity> GetMovieById(string imdbId)
        {
            return apiCleint.GetMovieById(imdbId);
        }

        public IObservable<List<MovieSummaryEntity>> searchMoviesByKeyword(string keyword)
        {
            return apiCleint.searchMoviesByKeyword(keyword);
        }
    }
}
