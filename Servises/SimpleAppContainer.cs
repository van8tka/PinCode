using PinCode.Interfaces;
using PinCode.Presenters;
using PinCode.Servises;
using SimpleInjector;
using System;

namespace PinCode.Services
{
    internal class SimpleAppContainer
    {
        internal static Container CreateContainer()
        {
            var c = new Container();
            c.Register<ISecurityStorage, PinCodeStorage>(Lifestyle.Transient);
            c.Register<PinCodeCreatePresenter>(Lifestyle.Transient);
            c.Register<PinCodeCheckPresenter>(Lifestyle.Transient);
            c.Register<PinCodeChangePresenter>(Lifestyle.Transient);
            c.Verify();
            return c;
        }
    }
}