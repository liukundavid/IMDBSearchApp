
namespace IMDBSearchApp.Data.Repository.DataSource
{
    public class MovieDataStoreFactory
    {

        public IMovieDataStore Create(bool hasCachedData)
        {
            if(hasCachedData)
            {
                return CreateMovieDiskDataStore();
            }
            else
            {
                return CreateMovieCloudDataStore();
            }
        }

        private IMovieDataStore CreateMovieDiskDataStore()
        {
            return new MovieDiskDataStore();
        }

        private IMovieDataStore CreateMovieCloudDataStore()
        {
            return new MovieCloudDataStore();
        }
    }
}
