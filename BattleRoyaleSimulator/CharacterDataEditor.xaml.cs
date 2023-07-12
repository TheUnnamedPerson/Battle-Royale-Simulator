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
    public sealed partial class CharacterDataEditor : Page
    {

        public List<Character> storedCharacters = new List<Character>();

        DataManagement _data = new DataManagement();

        public string path = DirectoryManagement.GetPath();

        public CharacterDataEditor()
        {
            this.InitializeComponent();

            storedCharacters = DataManagement.ReadCharacterData(path);

            _data.characters = storedCharacters;

            this.StoredCharactersView.ItemsSource = new List<Character>();

            this.StoredCharactersView.ItemsSource = storedCharacters;

            this.StoredCharactersView.UpdateLayout();

            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {
            await NavigationExtensions.PopAsync(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            storedCharacters = new List<Character>();

            string[] _strings = new string[2];
            float[] _stats = new float[12];

            _strings[0] = this.nameInput.Text;
            _strings[1] = this.IdInput.Text;

            _stats[0] = (float)this.ConsSlider.Value;
            _stats[1] = (float)this.LuckSlider.Value;
            _stats[2] = (float)this.ChaosSlider.Value;
            _stats[3] = (float)this.SanitySlider.Value;
            _stats[4] = (float)this.IntSlider.Value;
            _stats[5] = (float)this.MarSlider.Value;
            _stats[6] = (float)this.CharismaSlider.Value;
            _stats[7] = (float)this.DilSlider.Value;
            _stats[8] = (float)this.EmpSlider.Value;
            _stats[9] = (float)this.RsrflSlider.Value;
            _stats[10] = (float)this.DetSlider.Value;
            _stats[11] = (float)this.StabSlider.Value;

            _data.ConvertCharacterData(_strings, _stats);

            List<Character> _chars = new List<Character>();

            _chars = _data.characters;

            storedCharacters = DataManagement.SaveReadCharacterData(path, _chars);

            this.StoredCharactersView.ItemsSource = new List<Character>();

            this.StoredCharactersView.ItemsSource = storedCharacters;

            this.StoredCharactersView.UpdateLayout();
        }

        private void CharacterView_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Character _character = (Character)e.AddedItems.ElementAt(0);
                ((ListView)sender).SelectedItem = null;

                _character.DeconvertCharacterData(out string[] _si, out float[] _fi);

                nameInput.Text = _si[0];
                IdInput.Text = _si[1];

                ConsSlider.Value = _fi[0];
                LuckSlider.Value = _fi[1];
                ChaosSlider.Value = _fi[2];
                SanitySlider.Value = _fi[3];
                IntSlider.Value = _fi[4];
                MarSlider.Value = _fi[5];
                CharismaSlider.Value = _fi[6];
                DilSlider.Value = _fi[7];
                EmpSlider.Value = _fi[8];
                RsrflSlider.Value = _fi[9];
                DetSlider.Value = _fi[10];
                StabSlider.Value = _fi[11];

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            storedCharacters = DataManagement.ReadCharacterData(path);

            _data.characters = storedCharacters;

            this.StoredCharactersView.ItemsSource = new List<Character>();

            this.StoredCharactersView.ItemsSource = storedCharacters;

            this.StoredCharactersView.UpdateLayout();



            int _i = 0;
            for (int i = 0; i < storedCharacters.Count; i++) if (storedCharacters.ElementAt(i).name == ((TextBlock)((Grid)((Button)sender).Parent).Children.ElementAt(1)).Text) _i = i;

            Character _character = storedCharacters.ElementAt(_i);

            _data.characters.Remove(_character);

            storedCharacters.Remove(_character);

            List<Character> _chars = new List<Character>();

            _chars = _data.characters;

            storedCharacters = DataManagement.SaveReadCharacterData(path, _chars);

            this.StoredCharactersView.ItemsSource = new List<Character>();

            this.StoredCharactersView.ItemsSource = storedCharacters;

            this.StoredCharactersView.UpdateLayout();

            storedCharacters = DataManagement.ReadCharacterData(path);

            _data.characters = storedCharacters;

            this.StoredCharactersView.ItemsSource = new List<Character>();

            this.StoredCharactersView.ItemsSource = storedCharacters;

            this.StoredCharactersView.UpdateLayout();

        }

    }
}
