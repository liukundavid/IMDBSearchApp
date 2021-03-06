﻿using System;
using System.Collections.Generic;
using IMDBSearchApp.Domain.Model;

namespace IMDBSearchApp.Domain.Repository
{
    public interface IMovieRepository
    {
        IObservable<List<MovieSummary>> SearchMoviesByKeyword(string keyword);

        IObservable<Movie> GetMovieById(string imdbId);
    }
}
