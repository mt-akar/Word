using System.Windows;
using System.Windows.Controls; // Used in comments
using System.Windows.Input;

namespace Word
{
    /// <summary>
    /// View model for the whole window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The <see cref="Window"/> that this model controls
        /// </summary>
        MainWindow window;

        /// <summary>
        /// The last known dock position
        /// </summary>
        WindowDockPositionEnum dockPosition = WindowDockPositionEnum.Undocked; // Never changes basically

        #endregion

        #region Public Properties

        /// <summary>
        /// Emphesizes the minimum window width
        /// </summary>
        public int MinimumWindowWidth { get; } = 800;

        /// <summary>
        /// Emphesizes the minimum window Height
        /// </summary>
        public int MinimumWindowHeight { get; } = 500;

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless => window.WindowState == WindowState.Maximized || dockPosition != WindowDockPositionEnum.Undocked;

        /// <summary>
        /// Outer margin width to create the dropshadow in
        /// </summary>
        int OuterMargin => window.WindowState == WindowState.Maximized ? 0 : 10;
        /// <summary>
        /// <see cref="Thickness"/> version of <see cref="OuterMargin"/>
        /// </summary>
        public Thickness OuterMarginThickness => new Thickness(OuterMargin);

        /// <summary>
        /// The size of resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(Borderless ? 0 : 6 /*Resize border size*/ + OuterMargin);

        /// <summary>
        /// Radius of curved edges around the window
        /// </summary>
        public CornerRadius CornRadius => new CornerRadius(window.WindowState == WindowState.Maximized ? 0 : 10);

        /// <summary>
        /// The height of the caption, bar on top of the window
        /// </summary>
        public GridLength CaptionGridLength => new GridLength(48);
        /// <summary>
        /// True height of the caption calculating the outer margin 
        /// </summary>
        public double TrueCaptionHeight => 33 + OuterMargin;

        /// <summary>
        /// <see cref="Thickness"/> version of <see cref="InnerContentPadding"/>
        /// </summary>
        public Thickness InnerContentPaddingThickness { get; } = new Thickness(0);

        /// <summary>
        /// The current <see cref="Page"/> of the application
        /// </summary>
        public ApplicationPageEnum CurrentPage { get; set; } = ApplicationPageEnum.Login;

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand => new RelayCommand(true, () => window.WindowState = WindowState.Minimized);

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand => new RelayCommand(true, () => window.WindowState ^= WindowState.Maximized);

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand => new RelayCommand(true, window.Close);

        /// <summary>
        /// The command to show the menu
        /// </summary>
        public ICommand MenuCommand => new RelayCommand(true, () => SystemCommands.ShowSystemMenu(window, window.PointToScreen(Mouse.GetPosition(window))));

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(MainWindow wind)
        {
            // Initialize window object
            window = wind;

            // When window state changes, update necessary properties
            window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginThickness));
                OnPropertyChanged(nameof(CornRadius));
            };

            BasePage.DoneAnimatingOut += ChangePage;

            // This fixes a window size bug relating WindowStyle="None" where the content goes out of the screen and behind the taskbar
            new WindowResizer(window);
        }

        #endregion

        #region Event Listeners

        /// <summary>
        /// Event listener that changes the current page
        /// </summary>
        /// <param name="newPage"></param>
        void ChangePage(ApplicationPageEnum newPage)
        {
            CurrentPage = newPage;
        }

        #endregion
    }
}
