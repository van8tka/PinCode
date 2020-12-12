using PinCode.Interfaces;
using System;

namespace PinCode.Presenters
{
    public class PinCodeChangePresenter : PresenterBase<IPinCodeContract.IPinCodeView>,IPinCodeContract.IPinCodePresenter
    {
        private ISecurityStorage _secStorage;
        public PinCodeChangePresenter(ISecurityStorage securityStorage)
        {
            _secStorage = securityStorage;
        }

        public override void ViewIsReady()
        {
            GetView().ShowEnter(Resource.String.EnterPIN);
            GetView().ShowCreate(Resource.String.CreatePIN);
            GetView().ShowRepeat(Resource.String.RepeatPIN);
        }

       

        public async void OnTextEnter()
        {
            var existPin = await _secStorage.GetPIN();
            if(string.Equals(existPin, GetView().GetEnterText(), StringComparison.OrdinalIgnoreCase))
            {
                GetView().SetFocusCreate();
            }
            else
            {
                GetView().ShowMsh(Resource.String.pin_error);
                GetView().ClearAllFields();
            }
        }

        public void OnTextCreate()
        {
            GetView().SetFocusRepeat();
        }

        public async void OnTextRepeat()
        {
            if(string.Equals(GetView().GetCreateText(), GetView().GetRepeatText(), StringComparison.OrdinalIgnoreCase))
            {
                await _secStorage.SetPIN(GetView().GetRepeatText());
                GetView().Next();
                GetView().Close();
            }
            else
            {
                GetView().ClearAllFields();
                GetView().SetFocusEnter();
            }
        }
        
    }
}