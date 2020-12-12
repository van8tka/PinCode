using Android.App;
using Android.Runtime;
using PinCode.Services;
using SimpleInjector;
using System;

namespace PinCode
{
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
    public class App : Application
    {
        private static Container _container;

        protected App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {}

        public override void OnCreate()
        {
            base.OnCreate();
            _container = SimpleAppContainer.CreateContainer();
        }

        public static Container GetContainer=>_container;
    }
}