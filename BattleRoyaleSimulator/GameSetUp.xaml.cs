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

using System.Diagnostics;

using P42.Uno.AsyncNavigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BattleRoyaleSimulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameSetUp : Page
    {
        public List<Character> storedCharacters = new List<Character>();

        DataManagement _data = new DataManagement();

        public string path = DirectoryManagement.GetPath();

        public List<List<CharacterIncident>> storedIncidents = new List<List<CharacterIncident>>();

        public List<eventList> _eventSpaces = new List<eventList>();

        public List<Character> SelectedCharacters = new List<Character>();

        public List<eventList> SelectedEventSpaces = new List<eventList>();

        public List<eventList> DayEventSpaces = new List<eventList>();
        public List<eventList> NightEventSpaces = new List<eventList>();
        public List<eventList> ScenarioEventSpaces = new List<eventList>();

        public GameSetUp()
        {
            this.InitializeComponent();

            storedCharacters = DataManagement.ReadCharacterData(path);

            _data.characters = storedCharacters;

            this.StoredCharactersView.ItemsSource = new List<Character>();

            this.StoredCharactersView.ItemsSource = storedCharacters;

            this.StoredCharactersView.UpdateLayout();

            List<CharacterIncident> _ins = new List<CharacterIncident>();

            _ins = _data.incidents;

            storedIncidents = DataManagement.ReadEventData(path);

            

            for (int i = 0; i < storedIncidents.Count; i++) foreach (CharacterIncident incident in storedIncidents.ElementAt(i)) _data.incidents.Add(incident);

            _eventSpaces = new List<eventList>();

            int _i = 0;
            foreach (List<CharacterIncident> _inc in storedIncidents) { _eventSpaces.Add(new eventList(_inc)); _eventSpaces.ElementAt(_i).updateSpace(); _i++; }

            this.StoredEventsView.ItemsSource = new List<eventList>();

            this.StoredEventsView.ItemsSource = _eventSpaces;

            this.StoredEventsView.UpdateLayout();
        }

        public void CharacterView_Selected (object sender, SelectionChangedEventArgs e)
        {
            SelectedCharacters = new List<Character>();
            foreach (object item in ((ListView)sender).SelectedItems) SelectedCharacters.Add((Character)item);
        }

        public void EventView_Selected(object sender, SelectionChangedEventArgs e)
        {
            SelectedEventSpaces = new List<eventList>();
            foreach (object item in ((ListView)sender).SelectedItems) SelectedEventSpaces.Add((eventList)item);
            List<string> EventSpacesNames = new List<string>();
            foreach (eventList item in SelectedEventSpaces) EventSpacesNames.Add(item.nameSpace);

            DayList.ItemsSource = EventSpacesNames;
            NightList.ItemsSource = EventSpacesNames;
            ScenarioList.ItemsSource = EventSpacesNames;
        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {
            await NavigationExtensions.PopAsync(this);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DayEventSpaces = new List<eventList>();
            NightEventSpaces = new List<eventList>();
            ScenarioEventSpaces = new List<eventList>();

            List<string> DaySelected = new List<string>();
            List<string> NightSelected = new List<string>();
            List<string> ScenarioSelected = new List<string>();

            foreach (object _o in DayList.SelectedItems) DaySelected.Add((string)_o);
            foreach (object _o in NightList.SelectedItems) NightSelected.Add((string)_o);
            foreach (object _o in ScenarioList.SelectedItems) ScenarioSelected.Add((string)_o);

            foreach (eventList _list in SelectedEventSpaces)
            {
                if (DaySelected.Contains(_list.nameSpace)) DayEventSpaces.Add(_list);
                if (NightSelected.Contains(_list.nameSpace)) NightEventSpaces.Add(_list);
                if (ScenarioSelected.Contains(_list.nameSpace)) ScenarioEventSpaces.Add(_list);
            }

            Game _game = new Game(SelectedCharacters, SelectedEventSpaces, DayEventSpaces, NightEventSpaces, ScenarioEventSpaces);
            Page page = _game;
            P42.Uno.AsyncNavigation.NavigationExtensions.SetHasNavigationBar(page, false);
            await NavigationExtensions.PushAsync(this, page);
        }
    }
}
