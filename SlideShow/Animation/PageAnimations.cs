using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SlideShow.Animation
{
    /// <summary>
    /// Helpers top animated pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slide a page in from the right
        /// </summary>
        /// <param name="page">The page to animates</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRignt(this Page page, float seconds)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);
            
            //Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animation 
            sb.Begin(page);

            // Make page visibility
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }
        /// <summary>
        /// Slide a page out to the left
        /// </summary>
        /// <param name="page">The page to animates</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //Add fade in animation
            sb.AddFadeOut(seconds);

            // Start animation 
            sb.Begin(page);

            // Make page visibility
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }


        public static async Task SlideAndFadeInOut(this Page page, float seconds)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animation 
            sb.Begin(page);

            // Make page visibility
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 500));



            //Add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //Add fade in animation
            sb.AddFadeOut(seconds);

            // Start animation 
            sb.Begin(page);

            // Make page visibility
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 0));
        }
    }
}
