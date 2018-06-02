using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDBSearchApp.Domain.Model;
using IMDBSearchApp.Presentation;
using IMDBSearchApp.Presentation.Presenter;
using Xamarin.Forms;

namespace IMDBSearchApp
{
    public partial class MainPage : ContentPage, BaseView<Movie>
    {
        //MovieSearchPresenter Presenter;
        MovieDetailPresenter Presenter;

        public MainPage()
        {
            InitializeComponent();

            //Presenter = new MovieSearchPresenter { View = this };
            //Presenter.SearchMovie("Avengers");
            Presenter = new MovieDetailPresenter { View = this };
            Presenter.GetMovieDetail("tt0848228");
        }

        public void OnLoadingStart()
        {
            
        }

        public void OnNetworkDisabledError()
        {
            
        }

        public void Render(Movie data)
        {
            
        }

        public void RenderError(Exception error)
        {
            
        }
    }
}
