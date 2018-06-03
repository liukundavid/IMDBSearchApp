using System;
using System.Collections.Generic;
using System.Net.Http;
using IMDBSearchApp.Domain;
using IMDBSearchApp.Domain.Model;
using IMDBSearchApp.Domain.UseCase;

namespace IMDBSearchApp.Presentation.Presenter
{
    public class MovieSearchPresenter
    {
        private IMovieSearchViewSurface View { get; set; }
        private IMovieSearchRouterSurface Router { get; set; }

        SearchMoviesUseCase searchMoviesUseCase = new SearchMoviesUseCase();

        public void OnInject(IMovieSearchViewSurface viewSurface, IMovieSearchRouterSurface routerSurface)
        {
            View = viewSurface;
            Router = routerSurface;
        }

        public void SearchMovie(string keyword)
        {
            searchMoviesUseCase.Execute(new SearchMovieObserver { Presenter = this }, keyword);

            View.OnSearchingMovie();
        }

        public void GotoMovieDetail(MovieSummary movieSummary)
        {
            Router.NavigateToMovieDetailAsync(movieSummary);
        }

        class SearchMovieObserver : DefaultObserver<List<MovieSummary>>
        {
            public MovieSearchPresenter Presenter { get; set; }

            public override void OnCompleted()
            {
                base.OnCompleted();
            }

            public override void OnError(Exception error)
            {
                base.OnError(error);
                if (error.InnerException is HttpRequestException)
                {
                    Presenter.View.OnNetworkDisabledError();
                }
                else
                {
                    Presenter.View.OnSearchingMovieFailed(error);
                }
            }

            public override void OnNext(List<MovieSummary> value)
            {
                base.OnNext(value);
                Presenter.View.OnSearchingMovieSucceed(value);
            }
        }
    }

    public interface IMovieSearchViewSurface
    {
        void OnSearchingMovie();

        void OnSearchingMovieSucceed(List<MovieSummary> data);

        void OnSearchingMovieFailed(Exception error);

        void OnNetworkDisabledError();
    }

    public interface IMovieSearchRouterSurface
    {
        void NavigateToMovieDetailAsync(MovieSummary movieSummary);
    }
}
