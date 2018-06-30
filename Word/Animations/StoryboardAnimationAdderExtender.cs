using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Word
{
    /// <summary>
    /// A helper class that adds animations to storyboards
    /// </summary>
    public static class StoryboardAnimationAdderExtender
    {
        /// <summary>
        /// Adds a slide from right animation to the storyboard
        /// </summary>
        /// <param name="storyBoard"> The story board to add the animation</param>
        /// <param name="seconds"> The time that animation will take </param>
        /// <param name="offset"> The distance to the right to start from </param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideFromRight(this Storyboard storyBoard, float seconds, double offset, float decelerationRatio = 1)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide to left animation to the storyboard
        /// </summary>
        /// <param name="storyBoard"> The story board to add the animation</param>
        /// <param name="seconds"> The time that animation will take </param>
        /// <param name="offset"> The distance to the right to start from </param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideToLeft(this Storyboard storyBoard, float seconds, double offset, float decelerationRatio = 1)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = new Thickness(-offset, 0, offset, 0),
                AccelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(animation);
        }

        /// <summary>
        /// Adds fade in animation to the storyboard
        /// </summary>
        /// <param name="storyBoard"> The story board to add the animation</param>
        /// <param name="seconds"> The time that animation will take </param>
        public static void AddFadeIn(this Storyboard storyBoard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyBoard.Children.Add(animation);
        }

        /// <summary>
        /// Adds fade out animation to the storyboard
        /// </summary>
        /// <param name="storyBoard"> The story board to add the animation</param>
        /// <param name="seconds"> The time that animation will take </param>
        public static void AddFadeOut(this Storyboard storyBoard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyBoard.Children.Add(animation);
        }
    }
}
