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

using P42.Uno.AsyncNavigation;





// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BattleRoyaleSimulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            MainPanel.Visibility = Visibility.Visible;
            Loading.Visibility = Visibility.Collapsed;

            MainPanel.UpdateLayout();
            Loading.UpdateLayout();

            P42.Uno.AsyncNavigation.NavigationExtensions.SetHasNavigationBar(this, false);

        }

        

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(GameSetUp));
            Page page = new GameSetUp();
            P42.Uno.AsyncNavigation.NavigationExtensions.SetHasNavigationBar(page, false);
            await NavigationExtensions.PushAsync(this, page);
        }

        private async void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(CharacterDataEditor));
            Page page = new CharacterDataEditor();
            P42.Uno.AsyncNavigation.NavigationExtensions.SetHasNavigationBar(page, false);
            await NavigationExtensions.PushAsync(this, page);
        }

        private async void EventDataButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(EventDataEditor));

            //await StartProgressAnimation();  // your code to display a progress indicator
            StartLoading();
            Page page = new EventDataEditor();
            P42.Uno.AsyncNavigation.NavigationExtensions.SetHasNavigationBar(page, false);
            await NavigationExtensions.PushAsync(this, page);
            StopLoading();
            //await StopProgressAnimation();  // your code to hide the progress indicator shown above
        }

        private void StartLoading()
        {
            MainPanel.Visibility = Visibility.Collapsed;
            Loading.Visibility = Visibility.Visible;

            MainPanel.UpdateLayout();
            Loading.UpdateLayout();
        }

        private void StopLoading()
        {
            MainPanel.Visibility = Visibility.Visible;
            Loading.Visibility = Visibility.Collapsed;

            MainPanel.UpdateLayout();
            Loading.UpdateLayout();
        }
    }
}
