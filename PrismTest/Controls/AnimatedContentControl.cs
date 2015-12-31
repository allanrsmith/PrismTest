using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using PrismTest.Extensions;

namespace PrismTest.Controls
{
    public class AnimatedContentControl : ContentControl
    {
        public AnimatedContentControl()
        {
            DefaultStyleKey = typeof(AnimatedContentControl);
        }

        public static readonly DependencyProperty RemovedStoryboardProperty =
        DependencyProperty.Register("RemovedStoryboard",
            typeof(Storyboard),
            typeof(AnimatedContentControl),
            new UIPropertyMetadata(null));

        public Storyboard RemovedStoryboard
        {
            get { return (Storyboard)GetValue(RemovedStoryboardProperty); }
            set { SetValue(RemovedStoryboardProperty, value); }
        }

        public static readonly DependencyProperty AddedStoryboardProperty =
        DependencyProperty.Register("AddedStoryboard",
            typeof(Storyboard),
            typeof(AnimatedContentControl),
            new UIPropertyMetadata(null));

        public Storyboard AddedStoryboard
        {
            get { return (Storyboard)GetValue(AddedStoryboardProperty); }
            set { SetValue(AddedStoryboardProperty, value); }
        }

        ContentControl _old;
        ContentControl _current;

        Task oldAnimation;

        public override void OnApplyTemplate()
        {
            _old = (ContentControl)GetTemplateChild("_old");
            _current = (ContentControl)GetTemplateChild("_current");
            base.OnApplyTemplate();
        }


        protected async override void OnContentChanged(object oldContent, object newContent)
        {
            // when using Prism Navigation this Handler is called twice. 
            // first to remove the oldContent (i.e. newContent == null)
            // second to add newContent (i.e. oldContent == null)

            if (oldAnimation != null)
            {
                await oldAnimation;
            }

            if (oldContent != null)
            {
                _old.Content = oldContent;

                oldAnimation = RemovedAnimationAsync();
                await oldAnimation;
                _old.Visibility = Visibility.Collapsed;
            }

            if (newContent != null)
            {
                _current.Content = newContent;
                await AddedAnimationAsync();
            }
        }

        private Task RemovedAnimationAsync()
        {
            if (RemovedStoryboard != null)
            {
                var storyboard = RemovedStoryboard.Clone();
                Storyboard.SetTarget(storyboard, this);
                return storyboard.BeginAsync();
            }
            return Task.FromResult(true);
        }

        private Task AddedAnimationAsync()
        {
            if (AddedStoryboard != null)
            {
                var storyboard = AddedStoryboard.Clone();
                Storyboard.SetTarget(storyboard, this);
                return storyboard.BeginAsync();
            }
            return Task.FromResult(true);
        }
    }
}
