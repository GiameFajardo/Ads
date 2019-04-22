using System;
using System.Windows;
using System.Windows.Media.Animation;
/// <summary>
/// Animaton helper for <see cref="StoryBoard"/>
/// </summary>
namespace SlideShow.Animation
{
    public static class StoryBoardHelpers
    {
        /// <summary>
        /// adds a slide from right animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">The storyboard to add the animaton</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static void AddSlideFromRight(this Storyboard storyBoard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Creates the margin animates from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyBoard.Children.Add(animation);

        }

        /// <summary>
        /// adds a slide to left animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">The storyboard to add the animaton</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static void AddSlideToLeft(this Storyboard storyBoard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Creates the margin animates from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };
            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyBoard.Children.Add(animation);

        }

        /// <summary>
        /// adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">The storyboard to add the animaton</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyBoard, float seconds)
        {
            // Creates the margin animates from right
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0.5,
                To = 1
            };
            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add this to the storyboard
            storyBoard.Children.Add(animation);

        }

        /// <summary>
        /// adds a fade out animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">The storyboard to add the animaton</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeOut(this Storyboard storyBoard, float seconds)
        {
            // Creates the margin animates from right
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add this to the storyboard
            storyBoard.Children.Add(animation);

        }

        /// <summary>
        /// adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">The storyboard to add the animaton</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddWithOut(this Storyboard storyBoard, float seconds)
        {
            // Creates the margin animates from right
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };
            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Width"));

            // Add this to the storyboard
            storyBoard.Children.Add(animation);

        }
    }
}
