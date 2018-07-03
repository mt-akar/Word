using System;
using System.ComponentModel;

namespace Word
{
    /// <summary>
    /// A base view model that handles INotifPropertyChanged methods
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events

        public event Action<ApplicationPageEnum> ChangePageTo;

        public void OnChangePageTo(ApplicationPageEnum pageEnum)
        {
            ChangePageTo?.Invoke(pageEnum);
        }

        #endregion

        #region INotifyPropertyChanged

        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        } 

        #endregion
    }
}
