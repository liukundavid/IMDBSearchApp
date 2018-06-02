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

        private Realm realm;

        private MovieCache()
        {
            realm = Realm.GetInstance();    
        }

        public void ClearAll()
        {
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
            var entities = realm.All<MovieSummaryEntity>()
                                .Where(entity => entity.Title.Contains(keyword));
            return entities?.ToList<MovieSummaryEntity>();
        }

        public void Put(MovieEntity entity)
        {
            realm.Write(() => {
                realm.Add(entity);
            });
        }

        public void PutAll(List<MovieSummaryEntity> entities)
        {
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
            var entity = realm.Find<MovieEntity>(imdbId);
            return entity;
        }
    }
}
