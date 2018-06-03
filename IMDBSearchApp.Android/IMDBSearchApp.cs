using System;
using Android.App;
using Android.OS;
using Android.Runtime;

namespace IMDBSearchApp.Droid
{
    [Application]
    public class IMDBSearchApp : Application, Application.IActivityLifecycleCallbacks
    {
        public IMDBSearchApp(IntPtr handle, JniHandleOwnership transer): base(handle, transer)
        {
            
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            
        }

        public void OnActivityDestroyed(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityPaused(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityResumed(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            throw new NotImplementedException();
        }

        public void OnActivityStarted(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void OnActivityStopped(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
