using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PinCode.Interfaces
{
    /// <summary>
    /// Интерфейс, который будет реализован всеми презентерами,
    /// которые будут работать по MVP. 
    /// Он содержит несколько методов, которые будут вызываться из View
    /// </summary>
    /// <typeparam name="T">Activity (андроид)или UIViewController (ios)</typeparam>
    public interface IMvpPresenter<T> where T: class, IMvpView
    {
        /// <summary>
        /// метод для передачи View презентеру. Т.е. View вызовет его и передаст туда себя
        /// </summary>
        /// <param name="mvpView">Activity (андроид)или UIViewController (ios)</param>
        void AttachView(T mvpView);
        /// <summary>
        /// сигнал презентеру о том, что View готово к работе. Презентер может начинать, например, загружать данные
        /// </summary>
        void ViewIsReady();
        /// <summary>
        ///  презентер должен отпустить View.
        ///  Вызывается,н.р. при повороте экрана, когда уничтожается старый экземпляр Activity,
        ///  или при закрытии Activity. Презентер должен обнулить ссылку на Activity.
        /// </summary>
        void DetachView();
        /// <summary>
        /// сигнал презентеру о том, что View завершает свою работу и будет закрыто.
        /// Т.е. Здесь необходимо отписываться от всех моделей, завершать все текущие операции
        /// </summary>
        void Destroy();
    }
}