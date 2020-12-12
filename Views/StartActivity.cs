using Android.App;
using Android.OS;
using Android.Support.V7.App;
using PinCode.Interfaces;
using System;

namespace PinCode.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class StartActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            CheckPinExist();
        }

        private async void CheckPinExist()
        {
            var secStorage = App.GetContainer.GetInstance<ISecurityStorage>();
            var pinExist = await secStorage.GetPIN();
            if (string.IsNullOrEmpty(pinExist))
                PinCodeActivity.CreatePinCode(this);
            else
                PinCodeActivity.CheckPinCode(this);
            Finish();
        }
    }
}