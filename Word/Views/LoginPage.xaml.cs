using System.Security;

namespace Word
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : FunctionalBasePage<LoginPageViewModel>, IHavePassword
    {
        #region IHavePassword

        /// <summary>
        /// Secure password for this view, at that moment
        /// </summary>
        public SecureString SecurePassword => PasswordContainer.SecurePassword;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }

        #endregion
    }
}
