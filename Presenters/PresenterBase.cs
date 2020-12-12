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

namespace PinCode.Presenters
{
    public abstract class PresenterBase<T> : IMvpPresenter<T> where T : class, IMvpView
    {
        private T view;
        public void AttachView(T mvpView)
        {
            view = mvpView;
        }

        public void DetachView()
        {
            view = null;
        }

        public T GetView()
        {
            return view;
        }

        protected bool IsViewAttached()
        {
            return view != null;
        }

        public void Destroy()
        {
             
        }
 
        public virtual void ViewIsReady()
        {
             
        }
    }
}