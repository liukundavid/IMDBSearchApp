using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IMDBSearchApp.Domain.Model;
using IMDBSearchApp.Presentation.Presenter;
using Xamarin.Forms;

namespace IMDBSearchApp
{
    public partial class MainPage : ContentPage, IMovieSearchViewSurface, IMovieSearchRouterSurface
    {
        MovieSearchPresenter Presenter;

        public ObservableCollection<MovieSummary> movies { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Title = "IMDB Finder";

            Presenter = new MovieSearchPresenter();
            Presenter.OnInject(this, this);

            movies = new ObservableCollection<MovieSummary>();
        }

        void OnSearchBarButtonPressed(object sender, System.EventArgs e)
        {
            Presenter.SearchMovie(searchbar.Text);
        }

        void OnMovieItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Presenter.GotoMovieDetail(e.Item as MovieSummary);
        }

        public async void NavigateToMovieDetailAsync(MovieSummary movieSummary)
        {
            await Navigation.PushAsync(new MovieDetailPage(movieSummary));
        }

        public void OnSearchingMovie()
        {
        }

        public void OnSearchingMovieSucceed(List<MovieSummary> data)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                movies.Clear();
                foreach (var summary in data)
                {
                    movies.Add(summary);
                }

                listView.ItemsSource = movies;
                listView.IsRefreshing = false;
            });
        }

        public async void OnSearchingMovieFailed(Exception error)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Error", error.InnerException.ToString(), "OK");
            });
        }

        public async void OnNetworkDisabledError()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                await DisplayAlert("Error", "Something wrong in network", "OK");
            });
        }
    }
}
