using System;
namespace IMDBSearchApp.Domain.Model
{
    public class MovieSummary
    {
        public string imdbID { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string Type { get; set; }

        public string Poster { get; set; }
    }
}
