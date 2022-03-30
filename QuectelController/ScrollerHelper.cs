using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController
{
    public static class ScrollerHelper
    {
        /*
        public static bool GetAutoScroll(AttachedProperty obj)
        {
            return (bool)obj.GetValue(AutoScrollProperty);
        }

        public static void SetAutoScroll(AttachedProperty obj, bool value)
        {
            obj.SetValue(AutoScrollProperty, value);
        }
        Attribut

        public static readonly AttachedProperty<bool> AutoScrollProperty = AvaloniaProperty.RegisterAttached<ScrollViewer, bool>("AutoScroll");
       //     At("AutoScroll", typeof(bool), typeof(ScrollerHelper), new PropertyMetadata(false, AutoScrollPropertyChanged));

        private static void AutoScrollPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = d as ScrollViewer;

            if (scrollViewer != null && (bool)e.NewValue)
            {
                scrollViewer.ScrollToEnd();
            }
        } */
    }
}
