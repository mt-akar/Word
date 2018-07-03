namespace Word
{
    /// <summary>
    /// Styles of page animations for appearing/disapearing
    /// </summary>
    public enum PageAnimationEnum
    {
        /// <summary>
        /// No animation
        /// </summary>
        None,

        /// <summary>
        /// Page slides and fades in from right
        /// </summary>
        SlideAndFadeInFromRight,

        /// <summary>
        /// Page siled and fades out to right
        /// </summary>
        SlideAndFadeOutToLeft
    }

    // We could consider putting this inside the FunctionalBasePage.cs class bacause this enum is used only by that class.
}
