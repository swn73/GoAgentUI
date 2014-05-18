using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace GoAgentUI
{
    public partial class App : Application
    {
        // Handle close button event
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = null;

            if (sender is Window)
            {
                window = (Window)sender;
            }
            if (window == null)
            {
                window = Window.GetWindow((DependencyObject)sender);
            }
            window.Close();
        }
        // Close animation binding
        private void Window_ClosingEventSet(object sender, RoutedEventArgs e)
        {
            Window window = null;

            if (sender is Window)
            {
                window = (Window)sender;
            }

            if (window == null)
            {
                window = Window.GetWindow((DependencyObject)sender);
            }
            window.Closing += Window_Closing;
        }
        // Closing animation
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window window = null;

            if (sender is Window)
            {
                window = (Window)sender;
            }

            if (window == null)
            {
                window = Window.GetWindow((DependencyObject)sender);
            }
            window.Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new System.Windows.Media.Animation.DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.3));
            anim.Completed += (s, _) => window.Close();
            window.BeginAnimation(UIElement.OpacityProperty, anim);
        }
        // Close event trigger
        private void Window_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Window window = null;

            if (sender is Window)
            {
                window = (Window)sender;
            }

            if (window == null)
            {
                window = Window.GetWindow((DependencyObject)sender);
            }

            window.DragMove();
        }
    }

}
