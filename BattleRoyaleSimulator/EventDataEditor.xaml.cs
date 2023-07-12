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
    public sealed partial class EventDataEditor : Page
    {

        public List<List<CharacterIncident>> storedIncidents = new List<List<CharacterIncident>>();
        DataManagement _data = new DataManagement();
        public string path = DirectoryManagement.GetPath();

        public List<string> _Ints = new List<string>(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });

        public bool statsLowerOpen = false;
        public bool statsUpperOpen = false;
        public bool statsChangesOpen = false;
        public bool OpinionsLowerOpen = false;
        public bool OpinionsUpperOpen = false;
        public bool OpinionsChangesOpen = false;

        private TextBox[][] statLowerBoxes = new TextBox[10][];
        private TextBox[][] statUpperBoxes = new TextBox[10][];
        private TextBox[][] statChangesBoxes = new TextBox[10][];
        private TextBox[][] opinionLowerBoxes = new TextBox[10][];
        private TextBox[][] opinionUpperBoxes = new TextBox[10][];
        private TextBox[][] opinionChangesBoxes = new TextBox[10][];



        public List<eventList> _eventSpaces = new List<eventList>();

        public EventDataEditor()
        {

            this.InitializeComponent();

            this.LoadStuff();

        }

        public void LoadStuff ()
        {
            MainGrid.Visibility = Visibility.Visible;
            Loading.Visibility = Visibility.Collapsed;

            MainGrid.UpdateLayout();
            Loading.UpdateLayout();

            KillersList.ItemsSource = _Ints;
            KilledList.ItemsSource = _Ints;
            ReviveList.ItemsSource = _Ints;
            CloneList.ItemsSource = _Ints;
            ZombieList.ItemsSource = _Ints;

            StatsLowerList.Height = 40;
            StatsLowerGrid.Height = 50;

            StatsUpperList.Height = 40;
            StatsUpperGrid.Height = 50;

            StatsChangesList.Height = 40;
            StatsChangesGrid.Height = 50;

            OpinionsLowerList.Height = 40;
            OpinionsLowerGrid.Height = 50;

            OpinionsUpperList.Height = 40;
            OpinionsUpperGrid.Height = 50;

            OpinionsChangesList.Height = 40;
            OpinionsChangesGrid.Height = 50;

            statLowerBoxes[0] = new TextBox[] { Char1ConsLower, Char1LukLower, Char1ChaosLower, Char1SanLower, Char1IntLower, Char1MarLower, Char1ChaLower, Char1DilLower, Char1EmpLower, Char1ResLower, Char1DetLower, Char1StaLower };
            statLowerBoxes[1] = new TextBox[] { Char2ConsLower, Char2LukLower, Char2ChaosLower, Char2SanLower, Char2IntLower, Char2MarLower, Char2ChaLower, Char2DilLower, Char2EmpLower, Char2ResLower, Char2DetLower, Char2StaLower };
            statLowerBoxes[2] = new TextBox[] { Char3ConsLower, Char3LukLower, Char3ChaosLower, Char3SanLower, Char3IntLower, Char3MarLower, Char3ChaLower, Char3DilLower, Char3EmpLower, Char3ResLower, Char3DetLower, Char3StaLower };
            statLowerBoxes[3] = new TextBox[] { Char4ConsLower, Char4LukLower, Char4ChaosLower, Char4SanLower, Char4IntLower, Char4MarLower, Char4ChaLower, Char4DilLower, Char4EmpLower, Char4ResLower, Char4DetLower, Char4StaLower };
            statLowerBoxes[4] = new TextBox[] { Char5ConsLower, Char5LukLower, Char5ChaosLower, Char5SanLower, Char5IntLower, Char5MarLower, Char5ChaLower, Char5DilLower, Char5EmpLower, Char5ResLower, Char5DetLower, Char5StaLower };
            statLowerBoxes[5] = new TextBox[] { Char6ConsLower, Char6LukLower, Char6ChaosLower, Char6SanLower, Char6IntLower, Char6MarLower, Char6ChaLower, Char6DilLower, Char6EmpLower, Char6ResLower, Char6DetLower, Char6StaLower };
            statLowerBoxes[6] = new TextBox[] { Char7ConsLower, Char7LukLower, Char7ChaosLower, Char7SanLower, Char7IntLower, Char7MarLower, Char7ChaLower, Char7DilLower, Char7EmpLower, Char7ResLower, Char7DetLower, Char7StaLower };
            statLowerBoxes[7] = new TextBox[] { Char8ConsLower, Char8LukLower, Char8ChaosLower, Char8SanLower, Char8IntLower, Char8MarLower, Char8ChaLower, Char8DilLower, Char8EmpLower, Char8ResLower, Char8DetLower, Char8StaLower };
            statLowerBoxes[8] = new TextBox[] { Char9ConsLower, Char9LukLower, Char9ChaosLower, Char9SanLower, Char9IntLower, Char9MarLower, Char9ChaLower, Char9DilLower, Char9EmpLower, Char9ResLower, Char9DetLower, Char9StaLower };
            statLowerBoxes[9] = new TextBox[] { Char10ConsLower, Char10LukLower, Char10ChaosLower, Char10SanLower, Char10IntLower, Char10MarLower, Char10ChaLower, Char10DilLower, Char10EmpLower, Char10ResLower, Char10DetLower, Char10StaLower };

            statUpperBoxes[0] = new TextBox[] { Char1ConsUpper, Char1LukUpper, Char1ChaosUpper, Char1SanUpper, Char1IntUpper, Char1MarUpper, Char1ChaUpper, Char1DilUpper, Char1EmpUpper, Char1ResUpper, Char1DetUpper, Char1StaUpper };
            statUpperBoxes[1] = new TextBox[] { Char2ConsUpper, Char2LukUpper, Char2ChaosUpper, Char2SanUpper, Char2IntUpper, Char2MarUpper, Char2ChaUpper, Char2DilUpper, Char2EmpUpper, Char2ResUpper, Char2DetUpper, Char2StaUpper };
            statUpperBoxes[2] = new TextBox[] { Char3ConsUpper, Char3LukUpper, Char3ChaosUpper, Char3SanUpper, Char3IntUpper, Char3MarUpper, Char3ChaUpper, Char3DilUpper, Char3EmpUpper, Char3ResUpper, Char3DetUpper, Char3StaUpper };
            statUpperBoxes[3] = new TextBox[] { Char4ConsUpper, Char4LukUpper, Char4ChaosUpper, Char4SanUpper, Char4IntUpper, Char4MarUpper, Char4ChaUpper, Char4DilUpper, Char4EmpUpper, Char4ResUpper, Char4DetUpper, Char4StaUpper };
            statUpperBoxes[4] = new TextBox[] { Char5ConsUpper, Char5LukUpper, Char5ChaosUpper, Char5SanUpper, Char5IntUpper, Char5MarUpper, Char5ChaUpper, Char5DilUpper, Char5EmpUpper, Char5ResUpper, Char5DetUpper, Char5StaUpper };
            statUpperBoxes[5] = new TextBox[] { Char6ConsUpper, Char6LukUpper, Char6ChaosUpper, Char6SanUpper, Char6IntUpper, Char6MarUpper, Char6ChaUpper, Char6DilUpper, Char6EmpUpper, Char6ResUpper, Char6DetUpper, Char6StaUpper };
            statUpperBoxes[6] = new TextBox[] { Char7ConsUpper, Char7LukUpper, Char7ChaosUpper, Char7SanUpper, Char7IntUpper, Char7MarUpper, Char7ChaUpper, Char7DilUpper, Char7EmpUpper, Char7ResUpper, Char7DetUpper, Char7StaUpper };
            statUpperBoxes[7] = new TextBox[] { Char8ConsUpper, Char8LukUpper, Char8ChaosUpper, Char8SanUpper, Char8IntUpper, Char8MarUpper, Char8ChaUpper, Char8DilUpper, Char8EmpUpper, Char8ResUpper, Char8DetUpper, Char8StaUpper };
            statUpperBoxes[8] = new TextBox[] { Char9ConsUpper, Char9LukUpper, Char9ChaosUpper, Char9SanUpper, Char9IntUpper, Char9MarUpper, Char9ChaUpper, Char9DilUpper, Char9EmpUpper, Char9ResUpper, Char9DetUpper, Char9StaUpper };
            statUpperBoxes[9] = new TextBox[] { Char10ConsUpper, Char10LukUpper, Char10ChaosUpper, Char10SanUpper, Char10IntUpper, Char10MarUpper, Char10ChaUpper, Char10DilUpper, Char10EmpUpper, Char10ResUpper, Char10DetUpper, Char10StaUpper };

            statChangesBoxes[0] = new TextBox[] { Char1ConsChanges, Char1LukChanges, Char1ChaosChanges, Char1SanChanges, Char1IntChanges, Char1MarChanges, Char1ChaChanges, Char1DilChanges, Char1EmpChanges, Char1ResChanges, Char1DetChanges, Char1StaChanges };
            statChangesBoxes[1] = new TextBox[] { Char2ConsChanges, Char2LukChanges, Char2ChaosChanges, Char2SanChanges, Char2IntChanges, Char2MarChanges, Char2ChaChanges, Char2DilChanges, Char2EmpChanges, Char2ResChanges, Char2DetChanges, Char2StaChanges };
            statChangesBoxes[2] = new TextBox[] { Char3ConsChanges, Char3LukChanges, Char3ChaosChanges, Char3SanChanges, Char3IntChanges, Char3MarChanges, Char3ChaChanges, Char3DilChanges, Char3EmpChanges, Char3ResChanges, Char3DetChanges, Char3StaChanges };
            statChangesBoxes[3] = new TextBox[] { Char4ConsChanges, Char4LukChanges, Char4ChaosChanges, Char4SanChanges, Char4IntChanges, Char4MarChanges, Char4ChaChanges, Char4DilChanges, Char4EmpChanges, Char4ResChanges, Char4DetChanges, Char4StaChanges };
            statChangesBoxes[4] = new TextBox[] { Char5ConsChanges, Char5LukChanges, Char5ChaosChanges, Char5SanChanges, Char5IntChanges, Char5MarChanges, Char5ChaChanges, Char5DilChanges, Char5EmpChanges, Char5ResChanges, Char5DetChanges, Char5StaChanges };
            statChangesBoxes[5] = new TextBox[] { Char6ConsChanges, Char6LukChanges, Char6ChaosChanges, Char6SanChanges, Char6IntChanges, Char6MarChanges, Char6ChaChanges, Char6DilChanges, Char6EmpChanges, Char6ResChanges, Char6DetChanges, Char6StaChanges };
            statChangesBoxes[6] = new TextBox[] { Char7ConsChanges, Char7LukChanges, Char7ChaosChanges, Char7SanChanges, Char7IntChanges, Char7MarChanges, Char7ChaChanges, Char7DilChanges, Char7EmpChanges, Char7ResChanges, Char7DetChanges, Char7StaChanges };
            statChangesBoxes[7] = new TextBox[] { Char8ConsChanges, Char8LukChanges, Char8ChaosChanges, Char8SanChanges, Char8IntChanges, Char8MarChanges, Char8ChaChanges, Char8DilChanges, Char8EmpChanges, Char8ResChanges, Char8DetChanges, Char8StaChanges };
            statChangesBoxes[8] = new TextBox[] { Char9ConsChanges, Char9LukChanges, Char9ChaosChanges, Char9SanChanges, Char9IntChanges, Char9MarChanges, Char9ChaChanges, Char9DilChanges, Char9EmpChanges, Char9ResChanges, Char9DetChanges, Char9StaChanges };
            statChangesBoxes[9] = new TextBox[] { Char10ConsChanges, Char10LukChanges, Char10ChaosChanges, Char10SanChanges, Char10IntChanges, Char10MarChanges, Char10ChaChanges, Char10DilChanges, Char10EmpChanges, Char10ResChanges, Char10DetChanges, Char10StaChanges };

            opinionLowerBoxes[0] = new TextBox[] { Char1Char2Lower, Char1Char3Lower, Char1Char4Lower, Char1Char5Lower, Char1Char6Lower, Char1Char7Lower, Char1Char8Lower, Char1Char9Lower, Char1Char10Lower };
            opinionLowerBoxes[1] = new TextBox[] { Char2Char1Lower, Char2Char3Lower, Char2Char4Lower, Char2Char5Lower, Char2Char6Lower, Char2Char7Lower, Char2Char8Lower, Char2Char9Lower, Char2Char10Lower };
            opinionLowerBoxes[2] = new TextBox[] { Char3Char1Lower, Char3Char2Lower, Char3Char4Lower, Char3Char5Lower, Char3Char6Lower, Char3Char7Lower, Char3Char8Lower, Char3Char9Lower, Char3Char10Lower };
            opinionLowerBoxes[3] = new TextBox[] { Char4Char1Lower, Char4Char2Lower, Char4Char3Lower, Char4Char5Lower, Char4Char6Lower, Char4Char7Lower, Char4Char8Lower, Char4Char9Lower, Char4Char10Lower };
            opinionLowerBoxes[4] = new TextBox[] { Char5Char1Lower, Char5Char2Lower, Char5Char3Lower, Char5Char4Lower, Char5Char6Lower, Char5Char7Lower, Char5Char8Lower, Char5Char9Lower, Char5Char10Lower };
            opinionLowerBoxes[5] = new TextBox[] { Char6Char1Lower, Char6Char2Lower, Char6Char3Lower, Char6Char4Lower, Char6Char5Lower, Char6Char7Lower, Char6Char8Lower, Char6Char9Lower, Char6Char10Lower };
            opinionLowerBoxes[6] = new TextBox[] { Char7Char1Lower, Char7Char2Lower, Char7Char3Lower, Char7Char4Lower, Char7Char5Lower, Char7Char6Lower, Char7Char8Lower, Char7Char9Lower, Char7Char10Lower };
            opinionLowerBoxes[7] = new TextBox[] { Char8Char1Lower, Char8Char2Lower, Char8Char3Lower, Char8Char4Lower, Char8Char5Lower, Char8Char6Lower, Char8Char7Lower, Char8Char9Lower, Char8Char10Lower };
            opinionLowerBoxes[8] = new TextBox[] { Char9Char1Lower, Char9Char2Lower, Char9Char3Lower, Char9Char4Lower, Char9Char5Lower, Char9Char6Lower, Char9Char7Lower, Char9Char8Lower, Char9Char10Lower };
            opinionLowerBoxes[9] = new TextBox[] { Char10Char1Lower, Char10Char2Lower, Char10Char3Lower, Char10Char4Lower, Char10Char5Lower, Char10Char6Lower, Char10Char7Lower, Char10Char8Lower, Char10Char9Lower };

            opinionUpperBoxes[0] = new TextBox[] { Char1Char2Upper, Char1Char3Upper, Char1Char4Upper, Char1Char5Upper, Char1Char6Upper, Char1Char7Upper, Char1Char8Upper, Char1Char9Upper, Char1Char10Upper };
            opinionUpperBoxes[1] = new TextBox[] { Char2Char1Upper, Char2Char3Upper, Char2Char4Upper, Char2Char5Upper, Char2Char6Upper, Char2Char7Upper, Char2Char8Upper, Char2Char9Upper, Char2Char10Upper };
            opinionUpperBoxes[2] = new TextBox[] { Char3Char1Upper, Char3Char2Upper, Char3Char4Upper, Char3Char5Upper, Char3Char6Upper, Char3Char7Upper, Char3Char8Upper, Char3Char9Upper, Char3Char10Upper };
            opinionUpperBoxes[3] = new TextBox[] { Char4Char1Upper, Char4Char2Upper, Char4Char3Upper, Char4Char5Upper, Char4Char6Upper, Char4Char7Upper, Char4Char8Upper, Char4Char9Upper, Char4Char10Upper };
            opinionUpperBoxes[4] = new TextBox[] { Char5Char1Upper, Char5Char2Upper, Char5Char3Upper, Char5Char4Upper, Char5Char6Upper, Char5Char7Upper, Char5Char8Upper, Char5Char9Upper, Char5Char10Upper };
            opinionUpperBoxes[5] = new TextBox[] { Char6Char1Upper, Char6Char2Upper, Char6Char3Upper, Char6Char4Upper, Char6Char5Upper, Char6Char7Upper, Char6Char8Upper, Char6Char9Upper, Char6Char10Upper };
            opinionUpperBoxes[6] = new TextBox[] { Char7Char1Upper, Char7Char2Upper, Char7Char3Upper, Char7Char4Upper, Char7Char5Upper, Char7Char6Upper, Char7Char8Upper, Char7Char9Upper, Char7Char10Upper };
            opinionUpperBoxes[7] = new TextBox[] { Char8Char1Upper, Char8Char2Upper, Char8Char3Upper, Char8Char4Upper, Char8Char5Upper, Char8Char6Upper, Char8Char7Upper, Char8Char9Upper, Char8Char10Upper };
            opinionUpperBoxes[8] = new TextBox[] { Char9Char1Upper, Char9Char2Upper, Char9Char3Upper, Char9Char4Upper, Char9Char5Upper, Char9Char6Upper, Char9Char7Upper, Char9Char8Upper, Char9Char10Upper };
            opinionUpperBoxes[9] = new TextBox[] { Char10Char1Upper, Char10Char2Upper, Char10Char3Upper, Char10Char4Upper, Char10Char5Upper, Char10Char6Upper, Char10Char7Upper, Char10Char8Upper, Char10Char9Upper };

            opinionChangesBoxes[0] = new TextBox[] { Char1Char2Changes, Char1Char3Changes, Char1Char4Changes, Char1Char5Changes, Char1Char6Changes, Char1Char7Changes, Char1Char8Changes, Char1Char9Changes, Char1Char10Changes };
            opinionChangesBoxes[1] = new TextBox[] { Char2Char1Changes, Char2Char3Changes, Char2Char4Changes, Char2Char5Changes, Char2Char6Changes, Char2Char7Changes, Char2Char8Changes, Char2Char9Changes, Char2Char10Changes };
            opinionChangesBoxes[2] = new TextBox[] { Char3Char1Changes, Char3Char2Changes, Char3Char4Changes, Char3Char5Changes, Char3Char6Changes, Char3Char7Changes, Char3Char8Changes, Char3Char9Changes, Char3Char10Changes };
            opinionChangesBoxes[3] = new TextBox[] { Char4Char1Changes, Char4Char2Changes, Char4Char3Changes, Char4Char5Changes, Char4Char6Changes, Char4Char7Changes, Char4Char8Changes, Char4Char9Changes, Char4Char10Changes };
            opinionChangesBoxes[4] = new TextBox[] { Char5Char1Changes, Char5Char2Changes, Char5Char3Changes, Char5Char4Changes, Char5Char6Changes, Char5Char7Changes, Char5Char8Changes, Char5Char9Changes, Char5Char10Changes };
            opinionChangesBoxes[5] = new TextBox[] { Char6Char1Changes, Char6Char2Changes, Char6Char3Changes, Char6Char4Changes, Char6Char5Changes, Char6Char7Changes, Char6Char8Changes, Char6Char9Changes, Char6Char10Changes };
            opinionChangesBoxes[6] = new TextBox[] { Char7Char1Changes, Char7Char2Changes, Char7Char3Changes, Char7Char4Changes, Char7Char5Changes, Char7Char6Changes, Char7Char8Changes, Char7Char9Changes, Char7Char10Changes };
            opinionChangesBoxes[7] = new TextBox[] { Char8Char1Changes, Char8Char2Changes, Char8Char3Changes, Char8Char4Changes, Char8Char5Changes, Char8Char6Changes, Char8Char7Changes, Char8Char9Changes, Char8Char10Changes };
            opinionChangesBoxes[8] = new TextBox[] { Char9Char1Changes, Char9Char2Changes, Char9Char3Changes, Char9Char4Changes, Char9Char5Changes, Char9Char6Changes, Char9Char7Changes, Char9Char8Changes, Char9Char10Changes };
            opinionChangesBoxes[9] = new TextBox[] { Char10Char1Changes, Char10Char2Changes, Char10Char3Changes, Char10Char4Changes, Char10Char5Changes, Char10Char6Changes, Char10Char7Changes, Char10Char8Changes, Char10Char9Changes };

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

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StartLoading();
            await NavigationExtensions.PopAsync(this);
            StopLoading();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            statLowerBoxes[0] = new TextBox[] { Char1ConsLower, Char1LukLower, Char1ChaosLower, Char1SanLower, Char1IntLower, Char1MarLower, Char1ChaLower, Char1DilLower, Char1EmpLower, Char1ResLower, Char1DetLower, Char1StaLower };
            statLowerBoxes[1] = new TextBox[] { Char2ConsLower, Char2LukLower, Char2ChaosLower, Char2SanLower, Char2IntLower, Char2MarLower, Char2ChaLower, Char2DilLower, Char2EmpLower, Char2ResLower, Char2DetLower, Char2StaLower };
            statLowerBoxes[2] = new TextBox[] { Char3ConsLower, Char3LukLower, Char3ChaosLower, Char3SanLower, Char3IntLower, Char3MarLower, Char3ChaLower, Char3DilLower, Char3EmpLower, Char3ResLower, Char3DetLower, Char3StaLower };
            statLowerBoxes[3] = new TextBox[] { Char4ConsLower, Char4LukLower, Char4ChaosLower, Char4SanLower, Char4IntLower, Char4MarLower, Char4ChaLower, Char4DilLower, Char4EmpLower, Char4ResLower, Char4DetLower, Char4StaLower };
            statLowerBoxes[4] = new TextBox[] { Char5ConsLower, Char5LukLower, Char5ChaosLower, Char5SanLower, Char5IntLower, Char5MarLower, Char5ChaLower, Char5DilLower, Char5EmpLower, Char5ResLower, Char5DetLower, Char5StaLower };
            statLowerBoxes[5] = new TextBox[] { Char6ConsLower, Char6LukLower, Char6ChaosLower, Char6SanLower, Char6IntLower, Char6MarLower, Char6ChaLower, Char6DilLower, Char6EmpLower, Char6ResLower, Char6DetLower, Char6StaLower };
            statLowerBoxes[6] = new TextBox[] { Char7ConsLower, Char7LukLower, Char7ChaosLower, Char7SanLower, Char7IntLower, Char7MarLower, Char7ChaLower, Char7DilLower, Char7EmpLower, Char7ResLower, Char7DetLower, Char7StaLower };
            statLowerBoxes[7] = new TextBox[] { Char8ConsLower, Char8LukLower, Char8ChaosLower, Char8SanLower, Char8IntLower, Char8MarLower, Char8ChaLower, Char8DilLower, Char8EmpLower, Char8ResLower, Char8DetLower, Char8StaLower };
            statLowerBoxes[8] = new TextBox[] { Char9ConsLower, Char9LukLower, Char9ChaosLower, Char9SanLower, Char9IntLower, Char9MarLower, Char9ChaLower, Char9DilLower, Char9EmpLower, Char9ResLower, Char9DetLower, Char9StaLower };
            statLowerBoxes[9] = new TextBox[] { Char10ConsLower, Char10LukLower, Char10ChaosLower, Char10SanLower, Char10IntLower, Char10MarLower, Char10ChaLower, Char10DilLower, Char10EmpLower, Char10ResLower, Char10DetLower, Char10StaLower };

            statUpperBoxes[0] = new TextBox[] { Char1ConsUpper, Char1LukUpper, Char1ChaosUpper, Char1SanUpper, Char1IntUpper, Char1MarUpper, Char1ChaUpper, Char1DilUpper, Char1EmpUpper, Char1ResUpper, Char1DetUpper, Char1StaUpper };
            statUpperBoxes[1] = new TextBox[] { Char2ConsUpper, Char2LukUpper, Char2ChaosUpper, Char2SanUpper, Char2IntUpper, Char2MarUpper, Char2ChaUpper, Char2DilUpper, Char2EmpUpper, Char2ResUpper, Char2DetUpper, Char2StaUpper };
            statUpperBoxes[2] = new TextBox[] { Char3ConsUpper, Char3LukUpper, Char3ChaosUpper, Char3SanUpper, Char3IntUpper, Char3MarUpper, Char3ChaUpper, Char3DilUpper, Char3EmpUpper, Char3ResUpper, Char3DetUpper, Char3StaUpper };
            statUpperBoxes[3] = new TextBox[] { Char4ConsUpper, Char4LukUpper, Char4ChaosUpper, Char4SanUpper, Char4IntUpper, Char4MarUpper, Char4ChaUpper, Char4DilUpper, Char4EmpUpper, Char4ResUpper, Char4DetUpper, Char4StaUpper };
            statUpperBoxes[4] = new TextBox[] { Char5ConsUpper, Char5LukUpper, Char5ChaosUpper, Char5SanUpper, Char5IntUpper, Char5MarUpper, Char5ChaUpper, Char5DilUpper, Char5EmpUpper, Char5ResUpper, Char5DetUpper, Char5StaUpper };
            statUpperBoxes[5] = new TextBox[] { Char6ConsUpper, Char6LukUpper, Char6ChaosUpper, Char6SanUpper, Char6IntUpper, Char6MarUpper, Char6ChaUpper, Char6DilUpper, Char6EmpUpper, Char6ResUpper, Char6DetUpper, Char6StaUpper };
            statUpperBoxes[6] = new TextBox[] { Char7ConsUpper, Char7LukUpper, Char7ChaosUpper, Char7SanUpper, Char7IntUpper, Char7MarUpper, Char7ChaUpper, Char7DilUpper, Char7EmpUpper, Char7ResUpper, Char7DetUpper, Char7StaUpper };
            statUpperBoxes[7] = new TextBox[] { Char8ConsUpper, Char8LukUpper, Char8ChaosUpper, Char8SanUpper, Char8IntUpper, Char8MarUpper, Char8ChaUpper, Char8DilUpper, Char8EmpUpper, Char8ResUpper, Char8DetUpper, Char8StaUpper };
            statUpperBoxes[8] = new TextBox[] { Char9ConsUpper, Char9LukUpper, Char9ChaosUpper, Char9SanUpper, Char9IntUpper, Char9MarUpper, Char9ChaUpper, Char9DilUpper, Char9EmpUpper, Char9ResUpper, Char9DetUpper, Char9StaUpper };
            statUpperBoxes[9] = new TextBox[] { Char10ConsUpper, Char10LukUpper, Char10ChaosUpper, Char10SanUpper, Char10IntUpper, Char10MarUpper, Char10ChaUpper, Char10DilUpper, Char10EmpUpper, Char10ResUpper, Char10DetUpper, Char10StaUpper };

            statChangesBoxes[0] = new TextBox[] { Char1ConsChanges, Char1LukChanges, Char1ChaosChanges, Char1SanChanges, Char1IntChanges, Char1MarChanges, Char1ChaChanges, Char1DilChanges, Char1EmpChanges, Char1ResChanges, Char1DetChanges, Char1StaChanges };
            statChangesBoxes[1] = new TextBox[] { Char2ConsChanges, Char2LukChanges, Char2ChaosChanges, Char2SanChanges, Char2IntChanges, Char2MarChanges, Char2ChaChanges, Char2DilChanges, Char2EmpChanges, Char2ResChanges, Char2DetChanges, Char2StaChanges };
            statChangesBoxes[2] = new TextBox[] { Char3ConsChanges, Char3LukChanges, Char3ChaosChanges, Char3SanChanges, Char3IntChanges, Char3MarChanges, Char3ChaChanges, Char3DilChanges, Char3EmpChanges, Char3ResChanges, Char3DetChanges, Char3StaChanges };
            statChangesBoxes[3] = new TextBox[] { Char4ConsChanges, Char4LukChanges, Char4ChaosChanges, Char4SanChanges, Char4IntChanges, Char4MarChanges, Char4ChaChanges, Char4DilChanges, Char4EmpChanges, Char4ResChanges, Char4DetChanges, Char4StaChanges };
            statChangesBoxes[4] = new TextBox[] { Char5ConsChanges, Char5LukChanges, Char5ChaosChanges, Char5SanChanges, Char5IntChanges, Char5MarChanges, Char5ChaChanges, Char5DilChanges, Char5EmpChanges, Char5ResChanges, Char5DetChanges, Char5StaChanges };
            statChangesBoxes[5] = new TextBox[] { Char6ConsChanges, Char6LukChanges, Char6ChaosChanges, Char6SanChanges, Char6IntChanges, Char6MarChanges, Char6ChaChanges, Char6DilChanges, Char6EmpChanges, Char6ResChanges, Char6DetChanges, Char6StaChanges };
            statChangesBoxes[6] = new TextBox[] { Char7ConsChanges, Char7LukChanges, Char7ChaosChanges, Char7SanChanges, Char7IntChanges, Char7MarChanges, Char7ChaChanges, Char7DilChanges, Char7EmpChanges, Char7ResChanges, Char7DetChanges, Char7StaChanges };
            statChangesBoxes[7] = new TextBox[] { Char8ConsChanges, Char8LukChanges, Char8ChaosChanges, Char8SanChanges, Char8IntChanges, Char8MarChanges, Char8ChaChanges, Char8DilChanges, Char8EmpChanges, Char8ResChanges, Char8DetChanges, Char8StaChanges };
            statChangesBoxes[8] = new TextBox[] { Char9ConsChanges, Char9LukChanges, Char9ChaosChanges, Char9SanChanges, Char9IntChanges, Char9MarChanges, Char9ChaChanges, Char9DilChanges, Char9EmpChanges, Char9ResChanges, Char9DetChanges, Char9StaChanges };
            statChangesBoxes[9] = new TextBox[] { Char10ConsChanges, Char10LukChanges, Char10ChaosChanges, Char10SanChanges, Char10IntChanges, Char10MarChanges, Char10ChaChanges, Char10DilChanges, Char10EmpChanges, Char10ResChanges, Char10DetChanges, Char10StaChanges };

            opinionLowerBoxes[0] = new TextBox[] { Char1Char2Lower, Char1Char3Lower, Char1Char4Lower, Char1Char5Lower, Char1Char6Lower, Char1Char7Lower, Char1Char8Lower, Char1Char9Lower, Char1Char10Lower };
            opinionLowerBoxes[1] = new TextBox[] { Char2Char1Lower, Char2Char3Lower, Char2Char4Lower, Char2Char5Lower, Char2Char6Lower, Char2Char7Lower, Char2Char8Lower, Char2Char9Lower, Char2Char10Lower };
            opinionLowerBoxes[2] = new TextBox[] { Char3Char1Lower, Char3Char2Lower, Char3Char4Lower, Char3Char5Lower, Char3Char6Lower, Char3Char7Lower, Char3Char8Lower, Char3Char9Lower, Char3Char10Lower };
            opinionLowerBoxes[3] = new TextBox[] { Char4Char1Lower, Char4Char2Lower, Char4Char3Lower, Char4Char5Lower, Char4Char6Lower, Char4Char7Lower, Char4Char8Lower, Char4Char9Lower, Char4Char10Lower };
            opinionLowerBoxes[4] = new TextBox[] { Char5Char1Lower, Char5Char2Lower, Char5Char3Lower, Char5Char4Lower, Char5Char6Lower, Char5Char7Lower, Char5Char8Lower, Char5Char9Lower, Char5Char10Lower };
            opinionLowerBoxes[5] = new TextBox[] { Char6Char1Lower, Char6Char2Lower, Char6Char3Lower, Char6Char4Lower, Char6Char5Lower, Char6Char7Lower, Char6Char8Lower, Char6Char9Lower, Char6Char10Lower };
            opinionLowerBoxes[6] = new TextBox[] { Char7Char1Lower, Char7Char2Lower, Char7Char3Lower, Char7Char4Lower, Char7Char5Lower, Char7Char6Lower, Char7Char8Lower, Char7Char9Lower, Char7Char10Lower };
            opinionLowerBoxes[7] = new TextBox[] { Char8Char1Lower, Char8Char2Lower, Char8Char3Lower, Char8Char4Lower, Char8Char5Lower, Char8Char6Lower, Char8Char7Lower, Char8Char9Lower, Char8Char10Lower };
            opinionLowerBoxes[8] = new TextBox[] { Char9Char1Lower, Char9Char2Lower, Char9Char3Lower, Char9Char4Lower, Char9Char5Lower, Char9Char6Lower, Char9Char7Lower, Char9Char8Lower, Char9Char10Lower };
            opinionLowerBoxes[9] = new TextBox[] { Char10Char1Lower, Char10Char2Lower, Char10Char3Lower, Char10Char4Lower, Char10Char5Lower, Char10Char6Lower, Char10Char7Lower, Char10Char8Lower, Char10Char9Lower };

            opinionUpperBoxes[0] = new TextBox[] { Char1Char2Upper, Char1Char3Upper, Char1Char4Upper, Char1Char5Upper, Char1Char6Upper, Char1Char7Upper, Char1Char8Upper, Char1Char9Upper, Char1Char10Upper };
            opinionUpperBoxes[1] = new TextBox[] { Char2Char1Upper, Char2Char3Upper, Char2Char4Upper, Char2Char5Upper, Char2Char6Upper, Char2Char7Upper, Char2Char8Upper, Char2Char9Upper, Char2Char10Upper };
            opinionUpperBoxes[2] = new TextBox[] { Char3Char1Upper, Char3Char2Upper, Char3Char4Upper, Char3Char5Upper, Char3Char6Upper, Char3Char7Upper, Char3Char8Upper, Char3Char9Upper, Char3Char10Upper };
            opinionUpperBoxes[3] = new TextBox[] { Char4Char1Upper, Char4Char2Upper, Char4Char3Upper, Char4Char5Upper, Char4Char6Upper, Char4Char7Upper, Char4Char8Upper, Char4Char9Upper, Char4Char10Upper };
            opinionUpperBoxes[4] = new TextBox[] { Char5Char1Upper, Char5Char2Upper, Char5Char3Upper, Char5Char4Upper, Char5Char6Upper, Char5Char7Upper, Char5Char8Upper, Char5Char9Upper, Char5Char10Upper };
            opinionUpperBoxes[5] = new TextBox[] { Char6Char1Upper, Char6Char2Upper, Char6Char3Upper, Char6Char4Upper, Char6Char5Upper, Char6Char7Upper, Char6Char8Upper, Char6Char9Upper, Char6Char10Upper };
            opinionUpperBoxes[6] = new TextBox[] { Char7Char1Upper, Char7Char2Upper, Char7Char3Upper, Char7Char4Upper, Char7Char5Upper, Char7Char6Upper, Char7Char8Upper, Char7Char9Upper, Char7Char10Upper };
            opinionUpperBoxes[7] = new TextBox[] { Char8Char1Upper, Char8Char2Upper, Char8Char3Upper, Char8Char4Upper, Char8Char5Upper, Char8Char6Upper, Char8Char7Upper, Char8Char9Upper, Char8Char10Upper };
            opinionUpperBoxes[8] = new TextBox[] { Char9Char1Upper, Char9Char2Upper, Char9Char3Upper, Char9Char4Upper, Char9Char5Upper, Char9Char6Upper, Char9Char7Upper, Char9Char8Upper, Char9Char10Upper };
            opinionUpperBoxes[9] = new TextBox[] { Char10Char1Upper, Char10Char2Upper, Char10Char3Upper, Char10Char4Upper, Char10Char5Upper, Char10Char6Upper, Char10Char7Upper, Char10Char8Upper, Char10Char9Upper };

            opinionChangesBoxes[0] = new TextBox[] { Char1Char2Changes, Char1Char3Changes, Char1Char4Changes, Char1Char5Changes, Char1Char6Changes, Char1Char7Changes, Char1Char8Changes, Char1Char9Changes, Char1Char10Changes };
            opinionChangesBoxes[1] = new TextBox[] { Char2Char1Changes, Char2Char3Changes, Char2Char4Changes, Char2Char5Changes, Char2Char6Changes, Char2Char7Changes, Char2Char8Changes, Char2Char9Changes, Char2Char10Changes };
            opinionChangesBoxes[2] = new TextBox[] { Char3Char1Changes, Char3Char2Changes, Char3Char4Changes, Char3Char5Changes, Char3Char6Changes, Char3Char7Changes, Char3Char8Changes, Char3Char9Changes, Char3Char10Changes };
            opinionChangesBoxes[3] = new TextBox[] { Char4Char1Changes, Char4Char2Changes, Char4Char3Changes, Char4Char5Changes, Char4Char6Changes, Char4Char7Changes, Char4Char8Changes, Char4Char9Changes, Char4Char10Changes };
            opinionChangesBoxes[4] = new TextBox[] { Char5Char1Changes, Char5Char2Changes, Char5Char3Changes, Char5Char4Changes, Char5Char6Changes, Char5Char7Changes, Char5Char8Changes, Char5Char9Changes, Char5Char10Changes };
            opinionChangesBoxes[5] = new TextBox[] { Char6Char1Changes, Char6Char2Changes, Char6Char3Changes, Char6Char4Changes, Char6Char5Changes, Char6Char7Changes, Char6Char8Changes, Char6Char9Changes, Char6Char10Changes };
            opinionChangesBoxes[6] = new TextBox[] { Char7Char1Changes, Char7Char2Changes, Char7Char3Changes, Char7Char4Changes, Char7Char5Changes, Char7Char6Changes, Char7Char8Changes, Char7Char9Changes, Char7Char10Changes };
            opinionChangesBoxes[7] = new TextBox[] { Char8Char1Changes, Char8Char2Changes, Char8Char3Changes, Char8Char4Changes, Char8Char5Changes, Char8Char6Changes, Char8Char7Changes, Char8Char9Changes, Char8Char10Changes };
            opinionChangesBoxes[8] = new TextBox[] { Char9Char1Changes, Char9Char2Changes, Char9Char3Changes, Char9Char4Changes, Char9Char5Changes, Char9Char6Changes, Char9Char7Changes, Char9Char8Changes, Char9Char10Changes };
            opinionChangesBoxes[9] = new TextBox[] { Char10Char1Changes, Char10Char2Changes, Char10Char3Changes, Char10Char4Changes, Char10Char5Changes, Char10Char6Changes, Char10Char7Changes, Char10Char8Changes, Char10Char9Changes };

            List<float[]> StatLowers = new List<float[]>();
            List<float[]> StatUppers = new List<float[]>();
            List<float[]> StatChanges = new List<float[]>();
            List<int[]> OpinionLowers = new List<int[]>();
            List<int[]> OpinionUppers = new List<int[]>();
            List<int[]> OpinionChanges = new List<int[]>();

            int charCount = (int)CharSlider.Value;

            for (int i = 0; i < charCount; i++)
            {
                float[] statLowers = new float[12];
                float[] statUppers = new float[12];
                float[] statChanges = new float[12];
                for (int ii = 0; ii < 12; ii++)
                {
                    if (!float.TryParse(statLowerBoxes[i][ii].Text, out statLowers[ii])) statLowers[ii] = 0;
                    if (!float.TryParse(statUpperBoxes[i][ii].Text, out statUppers[ii])) statUppers[ii] = 0;
                    if (!float.TryParse(statChangesBoxes[i][ii].Text, out statChanges[ii])) statChanges[ii] = 0;
                }

                int[] opinionLowers = new int[9];
                int[] opinionUppers = new int[9];
                int[] opinionChanges = new int[9];
                for (int ii = 0; ii < 9; ii++)
                {
                    if (!int.TryParse(opinionLowerBoxes[i][ii].Text, out opinionLowers[ii])) opinionLowers[ii] = 0;
                    if (!int.TryParse(opinionUpperBoxes[i][ii].Text, out opinionUppers[ii])) opinionUppers[ii] = 0;
                    if (!int.TryParse(opinionChangesBoxes[i][ii].Text, out opinionChanges[ii])) opinionChanges[ii] = 0;
                }

                StatLowers.Add(statLowers);
                StatUppers.Add(statUppers);
                StatChanges.Add(statChanges);
                OpinionLowers.Add(opinionLowers);
                OpinionUppers.Add(opinionUppers);
                OpinionChanges.Add(opinionChanges);
            }

            /* Input into Conversion Function */ string[] _si = new string[] { nameInput.Text, NamespaceInput.Text, TextInput.Text };
            /* Input into Conversion Function */ bool[] _bi = new bool[] { SpecialInput.IsOn, AbsurdInput.IsOn };
            if (!int.TryParse((string)IdInput.Text, out int _r0)) _r0 = 0;
            if (!int.TryParse((string)WeightInput.Text, out int _r2)) _r2 = 0;
            /* Input into Conversion Function */ int[] _in = new int[] { _r0, _r2, (int)CharSlider.Value, (int)ChimpSlider.Value, (int)BeeSlider.Value, (int)RatSlider.Value };
            List<int> _killersList = new List<int>();
            for (int i = 0; i < KillersList.SelectedItems.Count; i++) { if (!int.TryParse((string)KillersList.SelectedItems.ElementAt(i), out int _r1)) _r1 = 1; _killersList.Add(_r1); }
            List<int> _killedList = new List<int>();
            for (int i = 0; i < KilledList.SelectedItems.Count; i++) { if (!int.TryParse((string)KilledList.SelectedItems.ElementAt(i), out int _r1)) _r1 = 1; _killedList.Add(_r1); }
            List<int> _reviveList = new List<int>();
            for (int i = 0; i < ReviveList.SelectedItems.Count; i++) { if (!int.TryParse((string)ReviveList.SelectedItems.ElementAt(i), out int _r1)) _r1 = 1; _reviveList.Add(_r1); }
            List<int> _cloneList = new List<int>();
            for (int i = 0; i < CloneList.SelectedItems.Count; i++) { if (!int.TryParse((string)CloneList.SelectedItems.ElementAt(i), out int _r1)) _r1 = 1; _cloneList.Add(_r1); }
            List<int> _zombieList = new List<int>();
            for (int i = 0; i < ZombieList.SelectedItems.Count; i++) { if (!int.TryParse((string)ZombieList.SelectedItems.ElementAt(i), out int _r1)) _r1 = 1; _zombieList.Add(_r1); }
            /* Input into Conversion Function */ int[][][] _iii = new int[][][] { new int[][] { _killersList.ToArray(), _killedList.ToArray(), _reviveList.ToArray(), _cloneList.ToArray(), _zombieList.ToArray() }, OpinionLowers.ToArray(), OpinionUppers.ToArray(), OpinionChanges.ToArray() };
            /* Input into Conversion Function */ float[][][] _ffi = new float[][][] { StatLowers.ToArray(), StatUppers.ToArray(), StatChanges.ToArray() };

            _data.ConvertEventData(_si, _bi, _in, _iii, _ffi);

            List<List<CharacterIncident>> _ins = new List<List<CharacterIncident>>();

            _ins = DataManagement.SortEventData(_data.incidents);

            storedIncidents = DataManagement.SaveReadEventData(path, DataManagement.SortEventData(_ins));

            storedIncidents = DataManagement.SortEventData(storedIncidents);

            _eventSpaces = new List<eventList>();

            int _i = 0;
            foreach (List<CharacterIncident> _inc in storedIncidents) { _eventSpaces.Add(new eventList(_inc)); _eventSpaces.ElementAt(_i).updateSpace(); _i++; }

            this.StoredEventsView.ItemsSource = new List<eventList>();

            this.StoredEventsView.ItemsSource = _eventSpaces;

            this.StoredEventsView.UpdateLayout();

        }

        private void StatLowerButton_Click(object sender, RoutedEventArgs e)
        {
            if (statsLowerOpen) { StatsLowerList.Height = 40; StatsLowerGrid.Height = 50; statsLowerOpen = false; } else { StatsLowerList.Height = 350; StatsLowerGrid.Height = 350; statsLowerOpen = true; }
        }
        private void StatUpperButton_Click(object sender, RoutedEventArgs e)
        {
            if (statsUpperOpen) { StatsUpperList.Height = 40; StatsUpperGrid.Height = 50; statsUpperOpen = false; } else { StatsUpperList.Height = 350; StatsUpperGrid.Height = 350; statsUpperOpen = true; }
        }

        private void StatChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (statsChangesOpen) { StatsChangesList.Height = 40; StatsChangesGrid.Height = 50; statsChangesOpen = false; } else { StatsChangesList.Height = 350; StatsChangesGrid.Height = 350; statsChangesOpen = true; }
        }

        private void OpinionsLowerButton_Click(object sender, RoutedEventArgs e)
        {
            if (OpinionsLowerOpen) { OpinionsLowerList.Height = 40; OpinionsLowerGrid.Height = 50; OpinionsLowerOpen = false; } else { OpinionsLowerList.Height = 425; OpinionsLowerGrid.Height = 425; OpinionsLowerOpen = true; }
        }
        private void OpinionsUpperButton_Click(object sender, RoutedEventArgs e)
        {
            if (OpinionsUpperOpen) { OpinionsUpperList.Height = 40; OpinionsUpperGrid.Height = 50; OpinionsUpperOpen = false; } else { OpinionsUpperList.Height = 425; OpinionsUpperGrid.Height = 425; OpinionsUpperOpen = true; }
        }

        private void OpinionsChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (OpinionsChangesOpen) { OpinionsChangesList.Height = 40; OpinionsChangesGrid.Height = 50; OpinionsChangesOpen = false; } else { OpinionsChangesList.Height = 425; OpinionsChangesGrid.Height = 425; OpinionsChangesOpen = true; }
        }
        private void EventSpaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ListView)((StackPanel)((Button)sender).Parent).Parent).Height != 50)
            {
                ((ListView)((StackPanel)((Button)sender).Parent).Parent).Height = 50;
                ((Grid)((ListView)((StackPanel)((Button)sender).Parent).Parent).Parent).Height = 75;
                ((StackPanel)((Grid)((ListView)((StackPanel)((Button)sender).Parent).Parent).Parent).Parent).Height = 100;
            } 
            else
            {
                ((ListView)((StackPanel)((Button)sender).Parent).Parent).Height = 300;
                ((Grid)((ListView)((StackPanel)((Button)sender).Parent).Parent).Parent).Height = 325;
                ((StackPanel)((Grid)((ListView)((StackPanel)((Button)sender).Parent).Parent).Parent).Parent).Height = 350;
            }
        }

        private void EventView_Loaded(object sender, RoutedEventArgs e)
        {
            int _i = 0;
            for (int i = 0; i < _eventSpaces.Count; i++) if (_eventSpaces.ElementAt(i).nameSpace == (string)((Button)((StackPanel)((ListView)sender).Parent).Children.ElementAt(0)).Content) _i = i;
            ((ListView)sender).ItemsSource = new List<CharacterIncident>();
            if (_eventSpaces.Count > 0) ((ListView)sender).ItemsSource = _eventSpaces.ElementAt(_i).innerList; else ((ListView)sender).ItemsSource = new List<CharacterIncident>();
            ((ListView)sender).UpdateLayout();
        }

        private void EventView_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                CharacterIncident _incident = (CharacterIncident)e.AddedItems.ElementAt(0);
                ((ListView)sender).SelectedItem = null;

                statLowerBoxes[0] = new TextBox[] { Char1ConsLower, Char1LukLower, Char1ChaosLower, Char1SanLower, Char1IntLower, Char1MarLower, Char1ChaLower, Char1DilLower, Char1EmpLower, Char1ResLower, Char1DetLower, Char1StaLower };
                statLowerBoxes[1] = new TextBox[] { Char2ConsLower, Char2LukLower, Char2ChaosLower, Char2SanLower, Char2IntLower, Char2MarLower, Char2ChaLower, Char2DilLower, Char2EmpLower, Char2ResLower, Char2DetLower, Char2StaLower };
                statLowerBoxes[2] = new TextBox[] { Char3ConsLower, Char3LukLower, Char3ChaosLower, Char3SanLower, Char3IntLower, Char3MarLower, Char3ChaLower, Char3DilLower, Char3EmpLower, Char3ResLower, Char3DetLower, Char3StaLower };
                statLowerBoxes[3] = new TextBox[] { Char4ConsLower, Char4LukLower, Char4ChaosLower, Char4SanLower, Char4IntLower, Char4MarLower, Char4ChaLower, Char4DilLower, Char4EmpLower, Char4ResLower, Char4DetLower, Char4StaLower };
                statLowerBoxes[4] = new TextBox[] { Char5ConsLower, Char5LukLower, Char5ChaosLower, Char5SanLower, Char5IntLower, Char5MarLower, Char5ChaLower, Char5DilLower, Char5EmpLower, Char5ResLower, Char5DetLower, Char5StaLower };
                statLowerBoxes[5] = new TextBox[] { Char6ConsLower, Char6LukLower, Char6ChaosLower, Char6SanLower, Char6IntLower, Char6MarLower, Char6ChaLower, Char6DilLower, Char6EmpLower, Char6ResLower, Char6DetLower, Char6StaLower };
                statLowerBoxes[6] = new TextBox[] { Char7ConsLower, Char7LukLower, Char7ChaosLower, Char7SanLower, Char7IntLower, Char7MarLower, Char7ChaLower, Char7DilLower, Char7EmpLower, Char7ResLower, Char7DetLower, Char7StaLower };
                statLowerBoxes[7] = new TextBox[] { Char8ConsLower, Char8LukLower, Char8ChaosLower, Char8SanLower, Char8IntLower, Char8MarLower, Char8ChaLower, Char8DilLower, Char8EmpLower, Char8ResLower, Char8DetLower, Char8StaLower };
                statLowerBoxes[8] = new TextBox[] { Char9ConsLower, Char9LukLower, Char9ChaosLower, Char9SanLower, Char9IntLower, Char9MarLower, Char9ChaLower, Char9DilLower, Char9EmpLower, Char9ResLower, Char9DetLower, Char9StaLower };
                statLowerBoxes[9] = new TextBox[] { Char10ConsLower, Char10LukLower, Char10ChaosLower, Char10SanLower, Char10IntLower, Char10MarLower, Char10ChaLower, Char10DilLower, Char10EmpLower, Char10ResLower, Char10DetLower, Char10StaLower };

                statUpperBoxes[0] = new TextBox[] { Char1ConsUpper, Char1LukUpper, Char1ChaosUpper, Char1SanUpper, Char1IntUpper, Char1MarUpper, Char1ChaUpper, Char1DilUpper, Char1EmpUpper, Char1ResUpper, Char1DetUpper, Char1StaUpper };
                statUpperBoxes[1] = new TextBox[] { Char2ConsUpper, Char2LukUpper, Char2ChaosUpper, Char2SanUpper, Char2IntUpper, Char2MarUpper, Char2ChaUpper, Char2DilUpper, Char2EmpUpper, Char2ResUpper, Char2DetUpper, Char2StaUpper };
                statUpperBoxes[2] = new TextBox[] { Char3ConsUpper, Char3LukUpper, Char3ChaosUpper, Char3SanUpper, Char3IntUpper, Char3MarUpper, Char3ChaUpper, Char3DilUpper, Char3EmpUpper, Char3ResUpper, Char3DetUpper, Char3StaUpper };
                statUpperBoxes[3] = new TextBox[] { Char4ConsUpper, Char4LukUpper, Char4ChaosUpper, Char4SanUpper, Char4IntUpper, Char4MarUpper, Char4ChaUpper, Char4DilUpper, Char4EmpUpper, Char4ResUpper, Char4DetUpper, Char4StaUpper };
                statUpperBoxes[4] = new TextBox[] { Char5ConsUpper, Char5LukUpper, Char5ChaosUpper, Char5SanUpper, Char5IntUpper, Char5MarUpper, Char5ChaUpper, Char5DilUpper, Char5EmpUpper, Char5ResUpper, Char5DetUpper, Char5StaUpper };
                statUpperBoxes[5] = new TextBox[] { Char6ConsUpper, Char6LukUpper, Char6ChaosUpper, Char6SanUpper, Char6IntUpper, Char6MarUpper, Char6ChaUpper, Char6DilUpper, Char6EmpUpper, Char6ResUpper, Char6DetUpper, Char6StaUpper };
                statUpperBoxes[6] = new TextBox[] { Char7ConsUpper, Char7LukUpper, Char7ChaosUpper, Char7SanUpper, Char7IntUpper, Char7MarUpper, Char7ChaUpper, Char7DilUpper, Char7EmpUpper, Char7ResUpper, Char7DetUpper, Char7StaUpper };
                statUpperBoxes[7] = new TextBox[] { Char8ConsUpper, Char8LukUpper, Char8ChaosUpper, Char8SanUpper, Char8IntUpper, Char8MarUpper, Char8ChaUpper, Char8DilUpper, Char8EmpUpper, Char8ResUpper, Char8DetUpper, Char8StaUpper };
                statUpperBoxes[8] = new TextBox[] { Char9ConsUpper, Char9LukUpper, Char9ChaosUpper, Char9SanUpper, Char9IntUpper, Char9MarUpper, Char9ChaUpper, Char9DilUpper, Char9EmpUpper, Char9ResUpper, Char9DetUpper, Char9StaUpper };
                statUpperBoxes[9] = new TextBox[] { Char10ConsUpper, Char10LukUpper, Char10ChaosUpper, Char10SanUpper, Char10IntUpper, Char10MarUpper, Char10ChaUpper, Char10DilUpper, Char10EmpUpper, Char10ResUpper, Char10DetUpper, Char10StaUpper };

                statChangesBoxes[0] = new TextBox[] { Char1ConsChanges, Char1LukChanges, Char1ChaosChanges, Char1SanChanges, Char1IntChanges, Char1MarChanges, Char1ChaChanges, Char1DilChanges, Char1EmpChanges, Char1ResChanges, Char1DetChanges, Char1StaChanges };
                statChangesBoxes[1] = new TextBox[] { Char2ConsChanges, Char2LukChanges, Char2ChaosChanges, Char2SanChanges, Char2IntChanges, Char2MarChanges, Char2ChaChanges, Char2DilChanges, Char2EmpChanges, Char2ResChanges, Char2DetChanges, Char2StaChanges };
                statChangesBoxes[2] = new TextBox[] { Char3ConsChanges, Char3LukChanges, Char3ChaosChanges, Char3SanChanges, Char3IntChanges, Char3MarChanges, Char3ChaChanges, Char3DilChanges, Char3EmpChanges, Char3ResChanges, Char3DetChanges, Char3StaChanges };
                statChangesBoxes[3] = new TextBox[] { Char4ConsChanges, Char4LukChanges, Char4ChaosChanges, Char4SanChanges, Char4IntChanges, Char4MarChanges, Char4ChaChanges, Char4DilChanges, Char4EmpChanges, Char4ResChanges, Char4DetChanges, Char4StaChanges };
                statChangesBoxes[4] = new TextBox[] { Char5ConsChanges, Char5LukChanges, Char5ChaosChanges, Char5SanChanges, Char5IntChanges, Char5MarChanges, Char5ChaChanges, Char5DilChanges, Char5EmpChanges, Char5ResChanges, Char5DetChanges, Char5StaChanges };
                statChangesBoxes[5] = new TextBox[] { Char6ConsChanges, Char6LukChanges, Char6ChaosChanges, Char6SanChanges, Char6IntChanges, Char6MarChanges, Char6ChaChanges, Char6DilChanges, Char6EmpChanges, Char6ResChanges, Char6DetChanges, Char6StaChanges };
                statChangesBoxes[6] = new TextBox[] { Char7ConsChanges, Char7LukChanges, Char7ChaosChanges, Char7SanChanges, Char7IntChanges, Char7MarChanges, Char7ChaChanges, Char7DilChanges, Char7EmpChanges, Char7ResChanges, Char7DetChanges, Char7StaChanges };
                statChangesBoxes[7] = new TextBox[] { Char8ConsChanges, Char8LukChanges, Char8ChaosChanges, Char8SanChanges, Char8IntChanges, Char8MarChanges, Char8ChaChanges, Char8DilChanges, Char8EmpChanges, Char8ResChanges, Char8DetChanges, Char8StaChanges };
                statChangesBoxes[8] = new TextBox[] { Char9ConsChanges, Char9LukChanges, Char9ChaosChanges, Char9SanChanges, Char9IntChanges, Char9MarChanges, Char9ChaChanges, Char9DilChanges, Char9EmpChanges, Char9ResChanges, Char9DetChanges, Char9StaChanges };
                statChangesBoxes[9] = new TextBox[] { Char10ConsChanges, Char10LukChanges, Char10ChaosChanges, Char10SanChanges, Char10IntChanges, Char10MarChanges, Char10ChaChanges, Char10DilChanges, Char10EmpChanges, Char10ResChanges, Char10DetChanges, Char10StaChanges };

                opinionLowerBoxes[0] = new TextBox[] { Char1Char2Lower, Char1Char3Lower, Char1Char4Lower, Char1Char5Lower, Char1Char6Lower, Char1Char7Lower, Char1Char8Lower, Char1Char9Lower, Char1Char10Lower };
                opinionLowerBoxes[1] = new TextBox[] { Char2Char1Lower, Char2Char3Lower, Char2Char4Lower, Char2Char5Lower, Char2Char6Lower, Char2Char7Lower, Char2Char8Lower, Char2Char9Lower, Char2Char10Lower };
                opinionLowerBoxes[2] = new TextBox[] { Char3Char1Lower, Char3Char2Lower, Char3Char4Lower, Char3Char5Lower, Char3Char6Lower, Char3Char7Lower, Char3Char8Lower, Char3Char9Lower, Char3Char10Lower };
                opinionLowerBoxes[3] = new TextBox[] { Char4Char1Lower, Char4Char2Lower, Char4Char3Lower, Char4Char5Lower, Char4Char6Lower, Char4Char7Lower, Char4Char8Lower, Char4Char9Lower, Char4Char10Lower };
                opinionLowerBoxes[4] = new TextBox[] { Char5Char1Lower, Char5Char2Lower, Char5Char3Lower, Char5Char4Lower, Char5Char6Lower, Char5Char7Lower, Char5Char8Lower, Char5Char9Lower, Char5Char10Lower };
                opinionLowerBoxes[5] = new TextBox[] { Char6Char1Lower, Char6Char2Lower, Char6Char3Lower, Char6Char4Lower, Char6Char5Lower, Char6Char7Lower, Char6Char8Lower, Char6Char9Lower, Char6Char10Lower };
                opinionLowerBoxes[6] = new TextBox[] { Char7Char1Lower, Char7Char2Lower, Char7Char3Lower, Char7Char4Lower, Char7Char5Lower, Char7Char6Lower, Char7Char8Lower, Char7Char9Lower, Char7Char10Lower };
                opinionLowerBoxes[7] = new TextBox[] { Char8Char1Lower, Char8Char2Lower, Char8Char3Lower, Char8Char4Lower, Char8Char5Lower, Char8Char6Lower, Char8Char7Lower, Char8Char9Lower, Char8Char10Lower };
                opinionLowerBoxes[8] = new TextBox[] { Char9Char1Lower, Char9Char2Lower, Char9Char3Lower, Char9Char4Lower, Char9Char5Lower, Char9Char6Lower, Char9Char7Lower, Char9Char8Lower, Char9Char10Lower };
                opinionLowerBoxes[9] = new TextBox[] { Char10Char1Lower, Char10Char2Lower, Char10Char3Lower, Char10Char4Lower, Char10Char5Lower, Char10Char6Lower, Char10Char7Lower, Char10Char8Lower, Char10Char9Lower };

                opinionUpperBoxes[0] = new TextBox[] { Char1Char2Upper, Char1Char3Upper, Char1Char4Upper, Char1Char5Upper, Char1Char6Upper, Char1Char7Upper, Char1Char8Upper, Char1Char9Upper, Char1Char10Upper };
                opinionUpperBoxes[1] = new TextBox[] { Char2Char1Upper, Char2Char3Upper, Char2Char4Upper, Char2Char5Upper, Char2Char6Upper, Char2Char7Upper, Char2Char8Upper, Char2Char9Upper, Char2Char10Upper };
                opinionUpperBoxes[2] = new TextBox[] { Char3Char1Upper, Char3Char2Upper, Char3Char4Upper, Char3Char5Upper, Char3Char6Upper, Char3Char7Upper, Char3Char8Upper, Char3Char9Upper, Char3Char10Upper };
                opinionUpperBoxes[3] = new TextBox[] { Char4Char1Upper, Char4Char2Upper, Char4Char3Upper, Char4Char5Upper, Char4Char6Upper, Char4Char7Upper, Char4Char8Upper, Char4Char9Upper, Char4Char10Upper };
                opinionUpperBoxes[4] = new TextBox[] { Char5Char1Upper, Char5Char2Upper, Char5Char3Upper, Char5Char4Upper, Char5Char6Upper, Char5Char7Upper, Char5Char8Upper, Char5Char9Upper, Char5Char10Upper };
                opinionUpperBoxes[5] = new TextBox[] { Char6Char1Upper, Char6Char2Upper, Char6Char3Upper, Char6Char4Upper, Char6Char5Upper, Char6Char7Upper, Char6Char8Upper, Char6Char9Upper, Char6Char10Upper };
                opinionUpperBoxes[6] = new TextBox[] { Char7Char1Upper, Char7Char2Upper, Char7Char3Upper, Char7Char4Upper, Char7Char5Upper, Char7Char6Upper, Char7Char8Upper, Char7Char9Upper, Char7Char10Upper };
                opinionUpperBoxes[7] = new TextBox[] { Char8Char1Upper, Char8Char2Upper, Char8Char3Upper, Char8Char4Upper, Char8Char5Upper, Char8Char6Upper, Char8Char7Upper, Char8Char9Upper, Char8Char10Upper };
                opinionUpperBoxes[8] = new TextBox[] { Char9Char1Upper, Char9Char2Upper, Char9Char3Upper, Char9Char4Upper, Char9Char5Upper, Char9Char6Upper, Char9Char7Upper, Char9Char8Upper, Char9Char10Upper };
                opinionUpperBoxes[9] = new TextBox[] { Char10Char1Upper, Char10Char2Upper, Char10Char3Upper, Char10Char4Upper, Char10Char5Upper, Char10Char6Upper, Char10Char7Upper, Char10Char8Upper, Char10Char9Upper };

                opinionChangesBoxes[0] = new TextBox[] { Char1Char2Changes, Char1Char3Changes, Char1Char4Changes, Char1Char5Changes, Char1Char6Changes, Char1Char7Changes, Char1Char8Changes, Char1Char9Changes, Char1Char10Changes };
                opinionChangesBoxes[1] = new TextBox[] { Char2Char1Changes, Char2Char3Changes, Char2Char4Changes, Char2Char5Changes, Char2Char6Changes, Char2Char7Changes, Char2Char8Changes, Char2Char9Changes, Char2Char10Changes };
                opinionChangesBoxes[2] = new TextBox[] { Char3Char1Changes, Char3Char2Changes, Char3Char4Changes, Char3Char5Changes, Char3Char6Changes, Char3Char7Changes, Char3Char8Changes, Char3Char9Changes, Char3Char10Changes };
                opinionChangesBoxes[3] = new TextBox[] { Char4Char1Changes, Char4Char2Changes, Char4Char3Changes, Char4Char5Changes, Char4Char6Changes, Char4Char7Changes, Char4Char8Changes, Char4Char9Changes, Char4Char10Changes };
                opinionChangesBoxes[4] = new TextBox[] { Char5Char1Changes, Char5Char2Changes, Char5Char3Changes, Char5Char4Changes, Char5Char6Changes, Char5Char7Changes, Char5Char8Changes, Char5Char9Changes, Char5Char10Changes };
                opinionChangesBoxes[5] = new TextBox[] { Char6Char1Changes, Char6Char2Changes, Char6Char3Changes, Char6Char4Changes, Char6Char5Changes, Char6Char7Changes, Char6Char8Changes, Char6Char9Changes, Char6Char10Changes };
                opinionChangesBoxes[6] = new TextBox[] { Char7Char1Changes, Char7Char2Changes, Char7Char3Changes, Char7Char4Changes, Char7Char5Changes, Char7Char6Changes, Char7Char8Changes, Char7Char9Changes, Char7Char10Changes };
                opinionChangesBoxes[7] = new TextBox[] { Char8Char1Changes, Char8Char2Changes, Char8Char3Changes, Char8Char4Changes, Char8Char5Changes, Char8Char6Changes, Char8Char7Changes, Char8Char9Changes, Char8Char10Changes };
                opinionChangesBoxes[8] = new TextBox[] { Char9Char1Changes, Char9Char2Changes, Char9Char3Changes, Char9Char4Changes, Char9Char5Changes, Char9Char6Changes, Char9Char7Changes, Char9Char8Changes, Char9Char10Changes };
                opinionChangesBoxes[9] = new TextBox[] { Char10Char1Changes, Char10Char2Changes, Char10Char3Changes, Char10Char4Changes, Char10Char5Changes, Char10Char6Changes, Char10Char7Changes, Char10Char8Changes, Char10Char9Changes };



                _incident.DeconvertEventData(out string[] _si, out bool[] _bi, out int[] _in, out int[][][] _iii, out float[][][] _ffi);

                nameInput.Text = _si[0];
                NamespaceInput.Text = _si[1];
                TextInput.Text = _si[2];

                SpecialInput.IsOn = _bi[0];
                AbsurdInput.IsOn = _bi[1];

                IdInput.Text = _in[0].ToString();
                WeightInput.Text = _in[1].ToString();
                CharSlider.Value = _in[2];
                ChimpSlider.Value = _in[3];
                BeeSlider.Value = _in[4];
                RatSlider.Value = _in[5];

                if (_iii[0][0] != null) if (_iii[0][0].Length > 0) for (int i = 0; i < _iii[0][0].Length; i++) KillersList.SelectedItems.Add(_iii[0][0][i].ToString());
                if (_iii[0][1] != null) if (_iii[0][1].Length > 0) for (int i = 0; i < _iii[0][1].Length; i++) KilledList.SelectedItems.Add(_iii[0][1][i].ToString());
                if (_iii[0][2] != null) if (_iii[0][2].Length > 0) for (int i = 0; i < _iii[0][2].Length; i++) ReviveList.SelectedItems.Add(_iii[0][2][i].ToString());
                if (_iii[0][3] != null) if (_iii[0][3].Length > 0) for (int i = 0; i < _iii[0][3].Length; i++) CloneList.SelectedItems.Add(_iii[0][3][i].ToString());
                if (_iii[0][4] != null) if (_iii[0][4].Length > 0) for (int i = 0; i < _iii[0][4].Length; i++) ZombieList.SelectedItems.Add(_iii[0][4][i].ToString());

                for (int i = 0; i < 10; i++)
                {
                    float[] statLowers = _ffi[0][i];
                    float[] statUppers = _ffi[1][i];
                    float[] statChanges = _ffi[2][i];
                    for (int ii = 0; ii < 12; ii++)
                    {
                        statLowerBoxes[i][ii].Text = statLowers[ii].ToString();
                        statUpperBoxes[i][ii].Text = statUppers[ii].ToString();
                        statChangesBoxes[i][ii].Text = statChanges[ii].ToString();
                    }

                    int[] opinionLowers = _iii[1][i];
                    int[] opinionUppers = _iii[2][i];
                    int[] opinionChanges = _iii[3][i];
                    for (int ii = 0; ii < 9; ii++)
                    {
                        opinionLowerBoxes[i][ii].Text = opinionLowers[ii].ToString();
                        opinionUpperBoxes[i][ii].Text = opinionUppers[ii].ToString();
                        opinionChangesBoxes[i][ii].Text = opinionChanges[ii].ToString();
                    }
                }

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            storedIncidents = new List<List<CharacterIncident>>();
            _data = new DataManagement();
            _eventSpaces = new List<eventList>();

            LoadStuff();

            bool deleteSpace = false;

            int _i = 0;
            for (int i = 0; i < _eventSpaces.Count; i++) if (_eventSpaces.ElementAt(i).nameSpace == ((TextBlock)((Grid)((Button)sender).Parent).Children.ElementAt(2)).Text) _i = i;

            Debug.WriteLine(_i.ToString());

            int _ii = 0;
            for (int i = 0; i < _eventSpaces.ElementAt(_i).innerList.Count; i++) if (_eventSpaces.ElementAt(_i).innerList.ElementAt(i).name == ((TextBlock)((Grid)((Button)sender).Parent).Children.ElementAt(1)).Text) _ii = i;     //((ListView)((Viewbox)((StackPanel)((Grid)((Button)sender).Parent).Parent).Parent).Parent).Item

            Debug.WriteLine(_ii.ToString());

            CharacterIncident _incident = (CharacterIncident)_eventSpaces.ElementAt(_i).innerList.ElementAt(_ii);

            if (_eventSpaces.ElementAt(_i).innerList.Count <= 1) deleteSpace = true;

            _data.incidents.Remove(_incident);

            storedIncidents.ElementAt(_i).Remove(_incident);

            _eventSpaces.ElementAt(_i).innerList.Remove(_incident);

            if (deleteSpace) { _eventSpaces.RemoveAt(_i); storedIncidents.RemoveAt(_i); }

            List<List<CharacterIncident>> _ins = new List<List<CharacterIncident>>();

            _ins = DataManagement.SortEventData(_data.incidents);

            storedIncidents = DataManagement.SaveReadEventData(path, DataManagement.SortEventData(_ins));

            storedIncidents = DataManagement.SortEventData(storedIncidents);

            _eventSpaces = new List<eventList>();

            int __i = 0;
            foreach (List<CharacterIncident> _inc in storedIncidents) { _eventSpaces.Add(new eventList(_inc)); _eventSpaces.ElementAt(__i).updateSpace(); __i++; }

            this.StoredEventsView.ItemsSource = new List<eventList>();

            this.StoredEventsView.ItemsSource = _eventSpaces;

            this.StoredEventsView.UpdateLayout();

            storedIncidents = new List<List<CharacterIncident>>();
            _data = new DataManagement();
            _eventSpaces = new List<eventList>();

            LoadStuff();

        }

        private void EventSpaceButton_Load(object sender, RoutedEventArgs e)
        {
            ((ListView)((StackPanel)((Button)sender).Parent).Parent).Height = 50;
            ((Grid)((ListView)((StackPanel)((Button)sender).Parent).Parent).Parent).Height = 75;
            ((StackPanel)((Grid)((ListView)((StackPanel)((Button)sender).Parent).Parent).Parent).Parent).Height = 100;
        }
        private void StartLoading()
        {
            MainGrid.Visibility = Visibility.Collapsed;
            Loading.Visibility = Visibility.Visible;

            MainGrid.UpdateLayout();
            Loading.UpdateLayout();
        }

        private void StopLoading()
        {
            MainGrid.Visibility = Visibility.Visible;
            Loading.Visibility = Visibility.Collapsed;

            MainGrid.UpdateLayout();
            Loading.UpdateLayout();
        }
    }
}
