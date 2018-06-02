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
    public partial class MainPage : ContentPage, BaseView<List<MovieSummary>>
    {
        MoviePresenter Presenter;

        public MainPage()
        {
            InitializeComponent();

            Presenter = new MoviePresenter { View = this };
            Presenter.SearchMovie("Avengers");
        }

        public void OnLoadingStart()
        {
            
        }

        public void OnNetworkDisabledError()
        {
            
        }

        public void Render(List<MovieSummary> data)
        {
            
        }

        public void RenderError(Exception error)
        {
            
        }
    }
}
