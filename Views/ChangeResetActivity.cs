using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PinCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PinCode.Views
{
    [Activity(Label = "@string/app_name")]
    public class ChangeResetActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChangeResetView);
            var btnChange = FindViewById<Button>(Resource.Id.btnChange);
            var btnReset = FindViewById<Button>(Resource.Id.btnReset);
            btnChange.Click += (s, e) => ChangePinEvent();
            btnReset.Click += (s, e) => ResetPinEvent();
        }

        public void ChangePinEvent()
        {
            PinCodeActivity.ChangePinCode(this);
        }

        public async void ResetPinEvent()
        {
            var secStorage = App.GetContainer.GetInstance<ISecurityStorage>();
            await secStorage.SetPIN(string.Empty);
        }
    }
}