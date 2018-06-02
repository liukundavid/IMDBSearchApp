using System;
namespace IMDBSearchApp.Presentation
{
    public interface BaseView<T>
    {
        void OnLoadingStart();

        void Render(T data);

        void RenderError(Exception error);

        void OnNetworkDisabledError();
    }
}
