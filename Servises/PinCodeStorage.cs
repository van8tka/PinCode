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
using System.Threading.Tasks;
 using Xamarin.Essentials;
 
namespace PinCode.Servises
{
    public class PinCodeStorage : ISecurityStorage
    {
        private const string PIN_TAG = "pin";
        public async Task<string> GetPIN()
        {
            return await SecureStorage.GetAsync(PIN_TAG)??string.Empty;
        }

        public async Task SetPIN(string pin)
        {
            await SecureStorage.SetAsync(PIN_TAG, pin);
        }
    }
}