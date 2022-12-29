﻿#nullable disable
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using UserControl = System.Windows.Controls.UserControl;

namespace FastTool.WPF.Controls
{
    /// <summary>
    /// Логика взаимодействия для CalcKeyboard.xaml
    /// </summary>
    public partial class CalcKeyboard : UserControl
    {
        public CalcKeyboard()
        {
            InitializeComponent();
            DataContext = this;
            StandartKeyboard = true;
        }

        #region Propertys
        public ICommand ButtonPressCommand
        {
            get => (ICommand)GetValue(ButtonPressCommandProperty);
            set => SetValue(ButtonPressCommandProperty, value);
        }

        public static readonly DependencyProperty ButtonPressCommandProperty = DependencyProperty.Register("ButtonPressCommand", typeof(ICommand), typeof(CalcKeyboard));

        public ICommand BackPressCommand
        {
            get => (ICommand)GetValue(BackPressCommandProperty);
            set => SetValue(BackPressCommandProperty, value);
        }

        public static readonly DependencyProperty BackPressCommandProperty = DependencyProperty.Register("BackPressCommand", typeof(ICommand), typeof(CalcKeyboard));
        
        public ICommand ClearPressCommand
        {
            get => (ICommand)GetValue(ClearPressCommandProperty);
            set => SetValue(ClearPressCommandProperty, value);
        }

        public static readonly DependencyProperty ClearPressCommandProperty = DependencyProperty.Register("ClearPressCommand", typeof(ICommand), typeof(CalcKeyboard));

        public ICommand EqualsPressCommand
        {
            get => (ICommand)GetValue(EqualsPressCommandProperty);
            set => SetValue(EqualsPressCommandProperty, value);
        }

        public static readonly DependencyProperty EqualsPressCommandProperty = DependencyProperty.Register("EqualsPressCommand", typeof(ICommand), typeof(CalcKeyboard));
        
        public bool SecondKeyboard
        {
            get => (bool)GetValue(SecondKeyboardProperty);
            set => SetValue(SecondKeyboardProperty, value);
        }

        public static readonly DependencyProperty SecondKeyboardProperty = DependencyProperty.Register("SecondKeyboard", typeof(bool), typeof(CalcKeyboard));

        public bool TrigonometryKeyboard
        {
            get => (bool)GetValue(TrigonometryKeyboardProperty);
            set => SetValue(TrigonometryKeyboardProperty, value);
        }

        public static readonly DependencyProperty TrigonometryKeyboardProperty = DependencyProperty.Register("TrigonometryKeyboard", typeof(bool), typeof(CalcKeyboard));

        public bool StandartKeyboard
        {
            get => (bool)GetValue(StandartKeyboardProperty);
            set => SetValue(StandartKeyboardProperty, value);
        }

        public static readonly DependencyProperty StandartKeyboardProperty = DependencyProperty.Register("StandartKeyboard", typeof(bool), typeof(CalcKeyboard));

        #endregion

        #region Hendlers
        private void SecondButtonClick(object sender, RoutedEventArgs e)
        {
            TrigonometryKeyboard = false;
            if ((sender as ToggleButton).IsChecked.Value)
                StandartKeyboard = false;
            else
                StandartKeyboard = true;
        }

        private void TrigonometryBuutonClick(object sender, RoutedEventArgs e)
        {
            SecondKeyboard = false;
            if ((sender as ToggleButton).IsChecked.Value)
                StandartKeyboard = false;
            else
                StandartKeyboard = true;
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            ClearPressCommand?.Execute(null);
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            BackPressCommand?.Execute(null);
        }

        private void EqualsClick(object sender, RoutedEventArgs e)
        {
            EqualsPressCommand?.Execute(null);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            ButtonPressCommand?.Execute(((Button)sender).CommandParameter);
        }
        #endregion
    }

    public class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool val)
            {
                if (val)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }

            throw new Exception();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    public class InverseBoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool val)
            {
                if (val)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }

            throw new Exception();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

}
