namespace PinCode.Interfaces
{
    public interface IPinCodeContract
    {
        public interface IPinCodeView : IMvpView
        {
            ///show labels
            void ShowEnter(int idLabelEnter);
            void ShowCreate(int idLabelCreate);
            void ShowRepeat(int idLabelRepeat);
            //get text from fields
            string GetEnterText();
            string GetCreateText();
            string GetRepeatText();
            //setfocus
            void SetFocusEnter();
            void SetFocusCreate();
            void SetFocusRepeat();
            //clear all
            void ClearAllFields();
            void ShowMsh(int idResMsg);
            //go to next screen
            void Next();
            //close screen
            void Close();
        }
        /// <summary>
        ///IPinCodePresenter описывает методы, которые будут вызываться, 
        /// когда соответствующее поле будет полностью заполнено (когда пользователь ввел 4 символа)
        /// </summary>
        public interface IPinCodePresenter : IMvpPresenter<IPinCodeView>
        {
            // field is filled
            void OnTextEnter();
            void OnTextCreate();
            void OnTextRepeat();
        }
    }
}