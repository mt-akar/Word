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
        WindowDockPosition dockPosition = WindowDockPosition.Undocked; // Never changes basically

        #endregion

        #region Public Properties

        /// <summary>
        /// Emphesizes the minimum window width
        /// </summary>
        public int MinimumWindowWidth { get; } = 800;

        /// <summary>
        /// Emphesizes the minimum window Height
        /// </summary>
        public int MinimumWindowHeight { get; } = 450;

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless => window.WindowState == WindowState.Maximized || dockPosition != WindowDockPosition.Undocked;

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
        public GridLength CaptionGridLength { get; } = new GridLength(48);

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
        public ICommand MinimizeCommand { get => new RelayCommand(true, () => window.WindowState = WindowState.Minimized); }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get => new RelayCommand(true, () => window.WindowState ^= WindowState.Maximized); }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get => new RelayCommand(true, window.Close); }

        /// <summary>
        /// The command to show the menu
        /// </summary>
        public ICommand MenuCommand { get => new RelayCommand(true, () => SystemCommands.ShowSystemMenu(window, window.PointToScreen(Mouse.GetPosition(window)))); }

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

            BasePage<LoginPageViewModel>.DoneAnimatingOut += ChangePage;

            // This fixes a window size bug relating WindowStyle="None" where the content goes out of the screen and behind the taskbar
            new WindowResizer(window);
        }

        #endregion

        void ChangePage(ApplicationPageEnum newPage)
        {
            CurrentPage = newPage;
        }
    }
}
