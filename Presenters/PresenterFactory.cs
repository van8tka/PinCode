using PinCode.Interfaces;
using System;

namespace PinCode.Presenters
{
    public class PresenterFactory
    {
        public static IPinCodeContract.IPinCodePresenter CreatePresenter(Constants.PinCodeMode mode)
        {
            switch (mode)
            {
                case Constants.PinCodeMode.CREATE:
                    {
                        return App.GetContainer.GetInstance<PinCodeCreatePresenter>();
                    }
                case Constants.PinCodeMode.CHANGE:
                    {
                        return App.GetContainer.GetInstance<PinCodeChangePresenter>();
                    }
                case Constants.PinCodeMode.CHECK:
                    {
                        return App.GetContainer.GetInstance<PinCodeCheckPresenter>();
                    }
                default: throw new Exception("Can't find PinCodeMode");
            }
        }
    }
}