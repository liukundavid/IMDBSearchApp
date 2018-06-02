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
        public BaseView<List<MovieSummary>> View { get; set; }

        SearchMoviesUseCase searchMoviesUseCase = new SearchMoviesUseCase();

        public void SearchMovie(string keyword)
        {
            searchMoviesUseCase.Execute(new SearchMovieObserver { Presenter = this }, keyword);

            View.OnLoadingStart();
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
                    Presenter.View.RenderError(error);
                }
            }

            public override void OnNext(List<MovieSummary> value)
            {
                base.OnNext(value);
                Presenter.View.Render(value);
            }
        }
    }
}
