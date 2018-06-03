using System;
using System.Linq;
using System.Collections.Generic;
using IMDBSearchApp.Data.Entity;
using Realms;

namespace IMDBSearchApp.Data.Cache
{
    public class MovieCache : IMovieCache
    {

        private static readonly Lazy<MovieCache> lazy =
            new Lazy<MovieCache>(() => new MovieCache(), true);

        public static MovieCache mainCache => lazy.Value;

        private MovieCache()
        {
        }

        public void ClearAll()
        {
            var realm = Realm.GetInstance();
            using(var transaction = realm.BeginWrite())
            {
                realm.RemoveAll<MovieSummaryEntity>();
                realm.RemoveAll<MovieEntity>();
                transaction.Commit();
            }
        }

        public bool hasMovieSummary(string keyword)
        {
            var results = GetMoviesSummaryByKeyword(keyword);
            if(results != null)
            {
                return results.Count > 0;
            }
            return  false;
        }

        public bool hasMovie(string imdbId)
        {
            var result = GetMovieById(imdbId);
            return result != null;
        }

        public List<MovieSummaryEntity> GetMoviesSummaryByKeyword(string keyword)
        {
            var realm = Realm.GetInstance();
            var entities = realm.All<MovieSummaryEntity>()
                                .Where(entity => entity.Title.Contains(keyword));
            return entities?.ToList<MovieSummaryEntity>();
        }

        public void Put(MovieEntity entity)
        {
            var realm = Realm.GetInstance();
            realm.Write(() => {
                realm.Add(entity);
            });
        }

        public void PutAll(List<MovieSummaryEntity> entities)
        {
            var realm = Realm.GetInstance();
            using(var transaction = realm.BeginWrite())
            {
                foreach(var entity in entities)
                {
                    realm.Add(entity);
                }
                transaction.Commit();
            }
        }

        public MovieEntity GetMovieById(string imdbId)
        {
            var realm = Realm.GetInstance();
            var entity = realm.Find<MovieEntity>(imdbId);
            return entity;
        }
    }
}
