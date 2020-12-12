using PinCode.Interfaces;
using System;

namespace PinCode.Presenters
{
    public class PinCodeCreatePresenter: PresenterBase<IPinCodeContract.IPinCodeView>, IPinCodeContract.IPinCodePresenter
    {
        private ISecurityStorage _secStorage;
        public PinCodeCreatePresenter(ISecurityStorage securityStorage)
        {
            _secStorage = securityStorage;
        }

        public override void ViewIsReady()
        {
            GetView().ShowCreate(Resource.String.CreatePIN);
            GetView().ShowRepeat(Resource.String.RepeatPIN);
        }

        public void OnTextCreate()
        {
            GetView().SetFocusRepeat();
        }

        public void OnTextEnter()
        {
            //do nothing
            //throw new NotImplementedException();
        }

        public async void OnTextRepeat()
        {
            if (GetView().GetCreateText().Equals(GetView().GetRepeatText(),StringComparison.OrdinalIgnoreCase))
            {
                await _secStorage.SetPIN(GetView().GetCreateText());              
                GetView().ShowMsh(Resource.String.pin_created);
                GetView().Next();
                GetView().Close();
            }
            else
            {
                GetView().ShowMsh(Resource.String.pin_no_match);
                GetView().ClearAllFields();
                GetView().SetFocusCreate();
            }
        }
    }
}