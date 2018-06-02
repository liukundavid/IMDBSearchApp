using System;
using System.Net.Http;
using IMDBSearchApp.Domain;
using IMDBSearchApp.Domain.Model;
using IMDBSearchApp.Domain.UseCase;

namespace IMDBSearchApp.Presentation.Presenter
{
    public class MovieDetailPresenter
    {
        public BaseView<Movie> View { get; set; }

        GetMovieDetailUseCase getMovieDetailUseCase = new GetMovieDetailUseCase();

        public void GetMovieDetail(string imdbId)
        {
            getMovieDetailUseCase.Execute(new GetMovieDetailObserver { Presenter = this }, imdbId);

            View.OnLoadingStart();
        }

        class GetMovieDetailObserver : DefaultObserver<Movie>
        {
            public MovieDetailPresenter Presenter { get; set; }

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

            public override void OnNext(Movie value)
            {
                base.OnNext(value);
                Presenter.View.Render(value);
            }
        }
    }
}
