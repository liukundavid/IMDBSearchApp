using System;
using System.Collections.Generic;
using IMDBSearchApp.Domain.Model;
using IMDBSearchApp.Presentation.Presenter;
using Xamarin.Forms;

namespace IMDBSearchApp
{
    public partial class MovieDetailPage : ContentPage, IMovieDetailViewSurface
    {
        MovieDetailPresenter Presenter;

        public MovieDetailPage(MovieSummary movieSummary)
        {
            InitializeComponent();

            Title = movieSummary.Title;

            Presenter = new MovieDetailPresenter();
            Presenter.OnInject(this);
            Presenter.GetMovieDetail(movieSummary.imdbID);
        }

        public void OnLoadingMovie()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                LoadingIndicator.IsRunning = false;
            });
        }

        public void OnNetworkDisabledError()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                LoadingIndicator.IsRunning = false;
                DisplayAlert("Error", "Something wrong in network", "OK");
            });
        }

        public void OnMovieLoaded(Movie data)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                LoadingIndicator.IsRunning = false;
                MovieImage.Source = data.Poster;
                MoviePlot.Text = data.Plot;
            });
        }

        public void OnMovieLoadFailed(Exception error)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                LoadingIndicator.IsRunning = false;
                DisplayAlert("Error", error.InnerException.ToString(), "OK");
            });
        }
    }
}
