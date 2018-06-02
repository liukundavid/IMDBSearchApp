using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using IMDBSearchApp.Data.Cache;
using IMDBSearchApp.Data.Entity.Mapper;
using IMDBSearchApp.Data.Repository.DataSource;
using IMDBSearchApp.Domain.Model;
using IMDBSearchApp.Domain.Repository;

namespace IMDBSearchApp.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieDataStoreFactory factory = new MovieDataStoreFactory();

        public IObservable<Movie> GetMovieById(string imdbId)
        {
            MovieMapper movieMapper = new MovieMapper();
            var hasCache = MovieCache.mainCache.hasMovie(imdbId);
            var dataSource = factory.Create(hasCache);
            var movie = dataSource.GetMovieById(imdbId).Select(x => movieMapper.Transform(x));
            return movie;
        }

        public IObservable<List<MovieSummary>> searchMoviesByKeyword(string keyword)
        {
            MovieSummaryMapper movieSummaryMapper = new MovieSummaryMapper();
            var hasCache = MovieCache.mainCache.hasMovieSummary(keyword);
            var dataSource = factory.Create(hasCache);
            var results = dataSource.searchMoviesByKeyword(keyword).Select(x => movieSummaryMapper.TransformList(x));
            return results;
        }
    }
}
