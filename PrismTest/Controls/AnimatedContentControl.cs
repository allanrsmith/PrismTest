using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PrismTest.Controls
{
    public class AnimatedContentControl : ContentControl
    {
        public AnimatedContentControl()
        {
            DefaultStyleKey = typeof(AnimatedContentControl);
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

                oldAnimation = CollapseAsync(_old);
                await oldAnimation;
                _old.Visibility = Visibility.Collapsed;
            }

            if (newContent != null)
            {
                _current.Content = newContent;
                await ExpandAsync(_current);
            }
        }

        private Task CollapseAsync(DependencyObject element)
        {
            DoubleAnimation animation = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromMilliseconds(400.0)))
            {
                EasingFunction = new BackEase { EasingMode = EasingMode.EaseIn, Amplitude = 0.3 }
            };

            Storyboard collapseDrawerItem = new Storyboard();
            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath("LayoutTransform.(ScaleTransform.ScaleX)"));
            collapseDrawerItem.Children.Add(animation);
            collapseDrawerItem.FillBehavior = FillBehavior.Stop;

            return collapseDrawerItem.BeginAsync();
        }

        private Task ExpandAsync(DependencyObject element)
        {
            DoubleAnimation animation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(320)))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            }; 

            Storyboard expandDrawerItem = new Storyboard();
            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath("LayoutTransform.(ScaleTransform.ScaleX)"));
            expandDrawerItem.Children.Add(animation);
            expandDrawerItem.FillBehavior = FillBehavior.Stop;

            return expandDrawerItem.BeginAsync();
        }
    }
}
