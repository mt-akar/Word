using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Word
{
    /// <summary>
    /// View model for a login screen
    /// </summary>
    public class LoginPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Corner radius of the login box
        /// </summary>
        public CornerRadius CornRadius => new CornerRadius(10);

        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// A flag indicating if <see cref="LoginCommand"/> is running. Explicitly false at the beginning
        /// </summary>
        public bool LoginIsRunning { get; set; } = false;

        /// <summary>
        /// Command that gets called when login button is pressed
        /// </summary>
        public ICommand LoginCommand => new RelayParameterizedCommand(true, /*Login*/ async parameter =>
        {
            // If parameter is null, throw exception
            if (!(parameter is IHavePassword))
                throw new ArgumentNullException("Login page was not properly loaded");

            // If the LoginCommand is already running, return
            if (LoginIsRunning) return;

            // Set LoginCommand to running
            LoginIsRunning = true;

            try // In case login attampt fails
            {
                // Await the login action
                await Task.Run(() =>
                {
                    // Simulate some action, temporary
                    Thread.Sleep(0);

                    // Store the credentials
                    var email = Email ?? "";
                    
                    // IMPORTANT: Never store unsecure password in memory!
                    var pass = (parameter as IHavePassword)?.SecurePassword.Unsecure();

                    #region TODO: Info Check
                    /* Lets not check anything for now.
                    // 
                    using (var sr = new StreamReader(@"C:\Users\ViraL\Documents\C# projects\Word\Word\user-info.txt"))
                    {
                        bool loggedIn = false;
                        while (sr.Peek() != -1)
                        {
                            string[] info = sr.ReadLine().Split();

                            if (info[0] == email && info[1] == pass)
                            {
                                Console.WriteLine("Login successful");
                                loggedIn = true;
                                LoggedIn();
                            }
                        }

                        if (!loggedIn)
                            Console.WriteLine("Invalid username or password");
                    }
                    */
                    #endregion
                });
            }
            catch
            {
                // Placeholder prompt call
                throw new Exception("This shouldn't have happened");
            }
            finally
            {
                // When finished, set login command to not running
                LoginIsRunning = false;
            }

            // Login is successful, change the page to a chat page
            OnChangePageTo(ApplicationPageEnum.Chat);
        });

        #endregion
    }
}
