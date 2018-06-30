using System.Windows;
using System.Windows.Controls;

namespace Word
{
    public class PasswordBoxAttachedProperties
    {
        public static readonly DependencyProperty MonitorPasswordProperty =
            DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxAttachedProperties), new PropertyMetadata(false, OnMonitorPasswordChanged));

        private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is PasswordBox)) return;

            var passwordBox = (PasswordBox)d;

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                SetHasText(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetHasText(sender as PasswordBox);
        }

        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool)element.GetValue(MonitorPasswordProperty);
        }

        public static void SetMonitorPassword(PasswordBox element, bool value)
        {
            element.SetValue(MonitorPasswordProperty, element.SecurePassword.Length > 0);
        }



        public static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxAttachedProperties), new PropertyMetadata(false));

        public static bool GetHasText(PasswordBox element)
        {
            return (bool)element.GetValue(HasTextProperty);
        }

        static void SetHasText(PasswordBox element)
        {
            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
        }
    }
}
