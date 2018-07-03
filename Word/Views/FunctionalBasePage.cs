
namespace Word
{
    /// <summary>
    /// A functional base page for all pages to gain functionalities
    /// </summary>
    public class FunctionalBasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        #region Public Properties

        /// <summary>
        /// View model of this page
        /// </summary>
        VM VievModel { get; set; } 

        #endregion

        #region Constructor

        /// <inheritdoc />
        /// <summary>
        /// Default constructor
        /// </summary>
        public FunctionalBasePage()
        {
            // Set the view model
            DataContext = VievModel = new VM();

            // Listen out for page changing
            VievModel.ChangePageTo += BasePage_Unload;
        }

        #endregion
    }
}
