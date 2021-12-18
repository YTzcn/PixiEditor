﻿using System.Windows;
using System.Windows.Input;

namespace PixiEditor.Views
{
    /// <summary>
    ///     Interaction logic for NewFilePopup.xaml.
    /// </summary>
    public partial class NewFilePopup : Window
    {
        public static readonly DependencyProperty FileHeightProperty =
            DependencyProperty.Register(nameof(FileHeight), typeof(int), typeof(NewFilePopup));

        public static readonly DependencyProperty FileWidthProperty =
            DependencyProperty.Register(nameof(FileWidth), typeof(int), typeof(NewFilePopup));

        public NewFilePopup()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            sizePicker.FocusWidthPicker();
        }

        public int FileHeight
        {
            get => (int)GetValue(FileHeightProperty);
            set => SetValue(FileHeightProperty, value);
        }

        public int FileWidth
        {
            get => (int)GetValue(FileWidthProperty);
            set => SetValue(FileWidthProperty, value);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
    }
}