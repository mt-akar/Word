using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Word
{
    /// <summary>
    /// View model for a chat screen
    /// </summary>
    public class ChatPageViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<ContactViewModel> Contacts { get; }

        #endregion
    }
}
