using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace MonoTorrent.GUI.Controls
{
    public sealed partial class MultiSelectComboBox : UserControl
    {
        #region ItemsSource dependency property
        public object ItemsSource
        {
            get { return GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                listView.ItemsSource = value;
            }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(object), typeof(MultiSelectComboBox), new PropertyMetadata(new List<object>(), OnItemsSourcePropertyChanged));

        private static void OnItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox instance = d as MultiSelectComboBox;
            if (instance != null && e.NewValue != null)
            {
                instance.listView.ItemsSource = e.NewValue;
            }
        }
        #endregion

        #region ItemTemplate dependency property
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set
            {
                SetValue(ItemTemplateProperty, value);
                listView.ItemTemplate = value;
            }
        }

        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(MultiSelectComboBox), new PropertyMetadata(null, OnItemTemplatePropertyChanged));

        private static void OnItemTemplatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox instance = d as MultiSelectComboBox;
            if (instance != null && e.NewValue as DataTemplate != null)
            {
                instance.listView.ItemTemplate = (DataTemplate)e.NewValue;
            }
        }
        #endregion

        #region SelectedItems dependency property
        public IList<object> SelectedItems
        {
            get { return (IList<object>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IList<object>), typeof(MultiSelectComboBox), new PropertyMetadata(new List<object>()));
        #endregion

        #region PopupHeight dependency property
        public double PopupHeight
        {
            get { return (double)GetValue(PopupHeightProperty); }
            set
            {
                SetValue(PopupHeightProperty, value);
                if (value != 0)
                {
                    listView.Height = value;
                }
            }
        }

        public static readonly DependencyProperty PopupHeightProperty =
            DependencyProperty.Register("PopupHeight", typeof(double), typeof(MultiSelectComboBox), new PropertyMetadata(0.0, OnPopupHeightPropertyChanged));

        private static void OnPopupHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox instance = d as MultiSelectComboBox;
            if (instance != null && (double)e.NewValue != 0)
            {
                instance.listView.Height = (double)e.NewValue;
            }
        }
        #endregion

        #region PopupWidth dependency property
        public double PopupWidth
        {
            get { return (double)GetValue(PopupWidthProperty); }
            set
            {
                SetValue(PopupWidthProperty, value);
                if (value != 0)
                {
                    listView.Width = value;
                }
            }
        }

        public static readonly DependencyProperty PopupWidthProperty =
            DependencyProperty.Register("PopupWidth", typeof(double), typeof(MultiSelectComboBox), new PropertyMetadata(0.0, OnPopupWidthPropertyChanged));

        private static void OnPopupWidthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox instance = d as MultiSelectComboBox;
            if (instance != null && (double)e.NewValue != 0)
            {
                instance.listView.Width = (double)e.NewValue;
            }
        }
        #endregion

        #region NoSelectionText dependency property
        public string NoSelectionText
        {
            get { return (string)GetValue(NoSelectionTextProperty); }
            set { SetValue(NoSelectionTextProperty, value); }
        }

        public static readonly DependencyProperty NoSelectionTextProperty =
            DependencyProperty.Register("NoSelectionText", typeof(string), typeof(MultiSelectComboBox), new PropertyMetadata("No selection"));
        #endregion

        #region MultipleSelectionTextFormat dependency property
        public string MultipleSelectionTextFormat
        {
            get { return (string)GetValue(MultipleSelectionTextFormatProperty); }
            set { SetValue(MultipleSelectionTextFormatProperty, value); }
        }

        public static readonly DependencyProperty MultipleSelectionTextFormatProperty =
            DependencyProperty.Register("MultipleSelectionTextFormat", typeof(string), typeof(MultiSelectComboBox), new PropertyMetadata("{0} selected"));
        #endregion

        public MultiSelectComboBox()
        {
            this.InitializeComponent();
            this.Loaded += MultiSelectComboBox_Loaded;
        }

        private void MultiSelectComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateSelectionText();
        }

        private void ComboBoxButton_Click(object sender, RoutedEventArgs e)
        {
            listView.SelectedItems.Clear();
            foreach (var item in SelectedItems)
            {
                listView.SelectedItems.Add(item);
            }
            this.comboBoxPopup.IsOpen = true;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!comboBoxPopup.IsOpen)
            {
                return;
            }

            this.SelectedItems = listView.SelectedItems.ToList();
            UpdateSelectionText();
        }

        private void UpdateSelectionText()
        {
            if (this.SelectedItems == null || this.SelectedItems.Count == 0)
            {
                this.SelectedValueTextBlock.Text = NoSelectionText;
            }
            else if (this.SelectedItems.Count == 1)
            {
                this.SelectedValueTextBlock.Text = this.SelectedItems.First().ToString();
            }
            else
            {
                this.SelectedValueTextBlock.Text = String.Format(MultipleSelectionTextFormat, this.SelectedItems.Count);
            }
        }
    }
}