using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDBSearchApp.Domain.UseCase
{
    public abstract class BaseUseCase<T, P>
    {
        List<IDisposable> Disposables;

        public abstract IObservable<T> CreateUseCaseObservable(P param);

        public BaseUseCase()
        {
            Disposables = new List<IDisposable>();
        }

        public void Execute(IObserver<T> observer, P param)
        {
            if (observer != null)
            {
                Task.Run(() =>
                {
                    IObservable<T> observable = CreateUseCaseObservable(param);
                    AddDisposable(observable.SubscribeSafe(observer));
                });
            }
        }

        public void Dispose()
        {
            foreach (var disposable in Disposables)
            {
                disposable.Dispose();
            }
        }

        void AddDisposable(IDisposable disposable)
        {
            if (Disposables != null && disposable != null)
            {
                Disposables.Add(disposable);
            }
        }
    }
}
