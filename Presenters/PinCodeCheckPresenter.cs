using PinCode.Interfaces;
using System;

namespace PinCode.Presenters
{
    class PinCodeCheckPresenter : PresenterBase<IPinCodeContract.IPinCodeView>, IPinCodeContract.IPinCodePresenter
    {
        private ISecurityStorage _secStorage;
        public PinCodeCheckPresenter(ISecurityStorage securityStorage)
        {
            _secStorage = securityStorage;
        }

        public override void ViewIsReady()
        {
            GetView().ShowEnter(Resource.String.EnterPIN);
        }

        public void OnTextCreate()
        {
           //do nothing
        }

        public async void OnTextEnter()
        {
            var existPin = await _secStorage.GetPIN();
            if(string.Equals(existPin, GetView().GetEnterText(), StringComparison.OrdinalIgnoreCase))
            {
                GetView().Next();
                GetView().Close();
            }
            else
            {
                GetView().ShowMsh(Resource.String.pin_error);
                GetView().ClearAllFields();
            }
        }

        public void OnTextRepeat()
        {
            //do nothing
        }
    }
}