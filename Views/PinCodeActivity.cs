using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using PinCode.Interfaces;
using Android.Content;
using PinCode.Presenters;

namespace PinCode.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class PinCodeActivity : AppCompatActivity, IPinCodeContract.IPinCodeView
    {
        private IPinCodeContract.IPinCodePresenter _presenter;
        private TextView tvEnter, tvCreate, tvRepeat;
        private EditText edEnter, edCreate, edRepeat;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);       
            SetContentView(Resource.Layout.activity_main);
            var mode_str = Intent.GetStringExtra(Constants.EXTRA_MODE);
            var mode = (Constants.PinCodeMode)Enum.Parse(typeof(Constants.PinCodeMode),mode_str,true);
            _presenter = PresenterFactory.CreatePresenter(mode);     
            tvCreate = FindViewById<TextView>(Resource.Id.tvCreate);
            tvEnter = FindViewById<TextView>(Resource.Id.tvEnter);
            tvRepeat = FindViewById<TextView>(Resource.Id.tvRepeat);
            edCreate = FindViewById<EditText>(Resource.Id.edCreate);
            edEnter = FindViewById<EditText>(Resource.Id.edEnter);
            edRepeat = FindViewById<EditText>(Resource.Id.edRepeat);
            _presenter.AttachView(this);
            _presenter.ViewIsReady();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _presenter.DetachView();
            if (IsFinishing)
            {
                _presenter.Destroy();
                //освобождаем все зависимости
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        internal static void ChangePinCode(Context context)
        {
            StartActivity(context, Constants.PinCodeMode.CHANGE);
        }

        internal static void CheckPinCode(Context context)
        {
            StartActivity(context, Constants.PinCodeMode.CHECK);
        }

        internal static void CreatePinCode(Context context)
        {
            StartActivity(context, Constants.PinCodeMode.CREATE);
        }

        private static void StartActivity(Context context, Constants.PinCodeMode mode)
        {
            var intent = new Intent(context, typeof(PinCodeActivity));
            intent.PutExtra(Constants.EXTRA_MODE, mode.ToString());
            context.StartActivity(intent);
        }

        public void ShowEnter(int idLabelEnter)
        {
            tvEnter.SetText(idLabelEnter);
            tvEnter.Visibility = Android.Views.ViewStates.Visible;
            edEnter.Visibility = Android.Views.ViewStates.Visible;
            edEnter.AfterTextChanged += (s, e) => { if (edEnter.Text.Length == 4) _presenter.OnTextEnter(); };
        }

        public void ShowCreate(int idLabelCreate)
        {
            tvCreate.SetText(idLabelCreate);
            tvCreate.Visibility = Android.Views.ViewStates.Visible;
            edCreate.Visibility = Android.Views.ViewStates.Visible;
            edCreate.AfterTextChanged += (s, e) => { if (edCreate.Text.Length == 4) _presenter.OnTextCreate(); };
        }

        public void ShowRepeat(int idLabelRepeat)
        {
            tvRepeat.SetText(idLabelRepeat);
            tvRepeat.Visibility = Android.Views.ViewStates.Visible;
            edRepeat.Visibility = Android.Views.ViewStates.Visible;
            edRepeat.AfterTextChanged += (s, e) => { if (edRepeat.Text.Length == 4) _presenter.OnTextRepeat(); };
        }

        public string GetEnterText()
        {
            return edEnter.Text;
        }

        public string GetCreateText()
        {
            return edCreate.Text;
        }

        public string GetRepeatText()
        {
            return edRepeat.Text;
        }

        public void SetFocusEnter()
        {
            edEnter.RequestFocus();
        }

        public void SetFocusCreate()
        {
            edCreate.RequestFocus();
        }

        public void SetFocusRepeat()
        {
            edRepeat.RequestFocus();
        }

        public void ClearAllFields()
        {
            edRepeat.Text = string.Empty;
            edEnter.Text = string.Empty;
            edCreate.Text = string.Empty;
        }

        public void ShowMsh(int idResMsg)
        {
            Toast.MakeText(this, idResMsg, ToastLength.Long).Show();
        }

        public void Next()
        {
            var intent = new Intent(this, typeof(ChangeResetActivity));
            StartActivity(intent);
        }

        public void Close()
        {
            Finish();
        }
    }
}