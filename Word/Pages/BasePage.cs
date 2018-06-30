using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Word
{
    /// <summary>
    /// A base page for all pages to gain base functionalities
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region Events

        /// <summary>
        /// Event raised when the page is done being animated out
        /// </summary>
        public static event Action<ApplicationPageEnum> DoneAnimatingOut;

        #endregion

        #region Public Properties

        /// <summary>
        /// View model of this page
        /// </summary>
        VM viewModel;

        /// <summary>
        /// View model of this page
        /// </summary>
        public VM VievModel { get => viewModel;
            set
            {
                // If same value is passed, return
                if (value == viewModel) return;

                // Update the value
                viewModel = value;

                // Set the viev model of this page
                DataContext = viewModel;
            }
        }

        #endregion

        #region Public Animation Properties

        /// <summary>
        /// The animation to play when the page first loads
        /// </summary>
        public PageAnimationEnum LoadAnimation { get; set; } = PageAnimationEnum.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation to play when the page unloads
        /// </summary>
        public PageAnimationEnum UnloadAnimation { get; set; } = PageAnimationEnum.SlideAndFadeOutToLeft;

        public float AnimationDuration { get; set; } = .8f;

        #endregion

        #region Constructor

        /// <inheritdoc />
        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // If the page has a enter animation, start the page as collapsed
            if (LoadAnimation != PageAnimationEnum.None)
                Visibility = Visibility.Collapsed;

            // Listen out for page loaded
            Loaded += BasePage_Loaded;

            // Set the view model
            VievModel = new VM();

            // Listen out for page changing
            viewModel.ChangePageTo += BasePage_Unload;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// When the page is loaded, perform the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            // Animate the page in
            await AnimateIn(); // You cannot make another thread execute AnimateIn function because the "page" is on UI thread.
        }

        /// <summary>
        /// When the page is loaded, perform the animation
        /// </summary>
        /// <param name="pageEnum">Page to be load after this page unloads</param>
        private async void BasePage_Unload(ApplicationPageEnum pageEnum)
        {
            // Animate the page out
            await AnimateOut(); // You cannot make another thread execute AnimateIn function because the "page" is on UI thread.

            // Raise done animating event
            DoneAnimatingOut?.Invoke(pageEnum);
        }

        #endregion

        #region Animator Methods

        /// <summary>
        /// Perform the load animation
        /// </summary>
        /// <returns>Task to run</returns>
        public async Task AnimateIn()
        {
            // Switch statemnt based on load animation type
            switch (LoadAnimation)
            {
                // If there is no animation, return
                case PageAnimationEnum.None:
                    break;

                case PageAnimationEnum.SlideAndFadeInFromRight:

                    // Create a storyboard and add animations to it
                    var sb = new Storyboard();
                    sb.AddSlideFromRight(AnimationDuration, WindowWidth);
                    sb.AddFadeIn(AnimationDuration);

                    // Begins the animation on this page and awaits it
                    sb.Begin(this);
                    Visibility = Visibility.Visible;
                    await Task.Delay((int)(AnimationDuration * 1000));
                    break;
                default:
                    throw new NotImplementedException("Animation type is not implemented");
            }
        }

        /// <summary>
        /// Perform the unload animation
        /// </summary>
        /// <returns>Task to run</returns>
        public async Task AnimateOut()
        {
            // Switch statemnt based on unload animation type
            switch (UnloadAnimation)
            {
                // If there is no animation, return
                case PageAnimationEnum.None:
                    break;

                case PageAnimationEnum.SlideAndFadeOutToLeft:

                    // Create a storyboard and add animations to it
                    var sb = new Storyboard();
                    sb.AddSlideToLeft(AnimationDuration, WindowWidth);
                    sb.AddFadeOut(AnimationDuration);

                    // Begins the animation on this page and awaits it
                    sb.Begin(this);
                    Visibility = Visibility.Visible;
                    await Task.Delay((int)(AnimationDuration * 1000));
                    break;
                default:
                    throw new NotImplementedException("Animation type is not implemented");
            }
        }

        #endregion
    }
}
