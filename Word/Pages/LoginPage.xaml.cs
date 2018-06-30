using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Word
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginPageViewModel>, IHavePassword
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
