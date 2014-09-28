using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace DontForget.Behaviors
{
    public class FocusOnLoadedBehavior : Behavior<Control>
    {
        public static readonly DependencyProperty SetFocusOnLoadedProperty =
            DependencyProperty.Register(
                "SetFocusOnLoaded",
                typeof(bool),
                typeof(FocusOnLoadedBehavior),
                new PropertyMetadata(true));

        public bool SetFocusOnLoaded
        {
            get { return (bool) GetValue(SetFocusOnLoadedProperty); }
            set { SetValue(SetFocusOnLoadedProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += ObjectLoaded;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Loaded -= ObjectLoaded;
        }

        private void ObjectLoaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Loaded -= ObjectLoaded;

            if (SetFocusOnLoaded)
            {
                AssociatedObject.Focus();
            }
        }
    }
}
