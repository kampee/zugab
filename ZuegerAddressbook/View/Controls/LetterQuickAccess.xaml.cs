﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using ZuegerAdressbook.Extensions;

namespace ZuegerAdressbook.View.Controls
{
    public partial class LetterQuickAccess : UserControl
    {
        public LetterQuickAccess()
        {
            InitializeComponent();

            MouseDown += OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var textBlock = e.OriginalSource as TextBlock;

            if (textBlock != null && textBlock.Text.Length == 1)
            {
                var letter = textBlock.Text.Substring(0, 1);
                ScrollToLetter(letter);
            }
        }

        private void ScrollToLetter(string letter)
        {
            if (TargetControl == null || TargetControl.ItemsSource == null)
            {
                return;
            }

            var collectionView = CollectionViewSource.GetDefaultView(TargetControl.ItemsSource);

            if (collectionView == null)
            {
                throw new InvalidOperationException("The TargetControl should use ICollectionView as ItemSource.");
            }

            if (string.IsNullOrEmpty(TargetPropertyPath))
            {
                throw new InvalidOperationException("TargetPropertyPath is not set.");
            }

            var firstWithLetter = collectionView.SourceCollection.Cast<object>().FirstOrDefault(o => o.DynamicAccess<string>(TargetPropertyPath)?.StartsWith(letter, true, CultureInfo.InvariantCulture) ?? false);

            if (firstWithLetter != null)
            {
                var scrollViewer = TargetControl.FindChild<ScrollViewer>();
                scrollViewer.ScrollToBottom();
                TargetControl.ScrollIntoView(firstWithLetter);
            }
        }

        public static readonly DependencyProperty TargetControlProperty = DependencyProperty.Register("TargetControl", typeof(ItemsControl), typeof(LetterQuickAccess), new UIPropertyMetadata(null));
        public static readonly DependencyProperty TargetPropertyPathProperty = DependencyProperty.Register("TargetPropertyPath", typeof(string), typeof(LetterQuickAccess), new PropertyMetadata(string.Empty));

        public ListBox TargetControl
        {
            get { return (ListBox)GetValue(TargetControlProperty); }
            set { SetValue(TargetControlProperty, value); }
        }

        public string TargetPropertyPath
        {
            get { return (string)GetValue(TargetPropertyPathProperty); }
            set { SetValue(TargetPropertyPathProperty, value); }
        }
    }
}
