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
    public sealed partial class Game : Page
    {
        

        public List<Character> SelectedCharacters = new List<Character>();

        public List<eventList> SelectedEventSpaces = new List<eventList>();

        public List<eventList> DayEventSpaces = new List<eventList>();
        public List<eventList> NightEventSpaces = new List<eventList>();
        public List<eventList> ScenarioEventSpaces = new List<eventList>();

        public List<CharacterIncident> roundEvents = new List<CharacterIncident>();

        public string Title;

        public int DayCycle = 0;
        public int ScenarioSelected = 0;

        public int ProccessedChars = 0;
        public int DeadChars = 0;
        public int DeadZombs = 0;
        public int _NewDead = 0;
        public int Zombies = 0;

        int _deads = 0;

        int _d = 0;

        public Game(List<Character> _chars, List<eventList> _events, List<eventList> _days, List<eventList> _nights, List<eventList> _scens)
        {

            this.SelectedCharacters = _chars;

            foreach (Character _char in SelectedCharacters) _char.fixOpinionArraySize(SelectedCharacters.Count);

            for (int i = 0; i < SelectedCharacters.Count; i++) { SelectedCharacters.ElementAt(i).relativeID = 1 + i; SelectedCharacters.ElementAt(i).alive = true; SelectedCharacters.ElementAt(i).proccessed = false; }

            this.SelectedEventSpaces = _events;

            this.DayEventSpaces = _days;
            this.NightEventSpaces = _nights;
            this.ScenarioEventSpaces = _scens;

            this.InitializeComponent();

            StoredCharactersView.ItemsSource = new List<CharacterIncident>();
            StoredCharactersView.ItemsSource = roundEvents;
            StoredCharactersView.UpdateLayout();
            DoRound();

        }

        public void DoRound ()
        {
            StoredCharactersView.ItemsSource = new List<CharacterIncident>();
            StoredCharactersView.ItemsSource = roundEvents;
            StoredCharactersView.UpdateLayout();
            roundEvents = new List<CharacterIncident>();
            if (DayCycle == 0) Title = "Day";

            ProccessedChars = 0;

            foreach (Character _char in SelectedCharacters)
            {
                _char.proccessed = false;
            }

            int _count = SelectedCharacters.Count;

            _NewDead = DeadChars;

            List<Character> _charsShuffled = SelectedCharacters;
            _charsShuffled.Shuffle();

            for (int __i = 0; __i < _count; __i++)
            {
                int i = _charsShuffled[__i].relativeID - 1;
                Debug.WriteLine(i.ToString());
                if (SelectedCharacters[i].alive == true && SelectedCharacters[i].proccessed == false)
                {
                    _deads = 0;

                    _d = 0;

                    CharacterIncident _incident = FindEvents(SelectedCharacters[i]);
                    ValidateEvent(_incident, SelectedCharacters[i], out Character[] _chars);
                    Func<Character[], Character[]> charactersFix = x => { var a = x.ToList(); a.Insert(0, SelectedCharacters[i]); return a.ToArray(); };
                    Character[] _Characters = charactersFix(_chars);
                    CharacterIncident proccessedIncident = new CharacterIncident();
                    if (_incident.specialEvent)
                    {
                        proccessedIncident = ((SpecialIncident)((object)_incident)).incidentOutput(_Characters, ref SelectedCharacters, out _d);
                        foreach (Character __char in proccessedIncident.characters)
                        {
                            bool existsInGame = false;
                            for (int ii = 0; ii < SelectedCharacters.Count; ii++) if (SelectedCharacters.ElementAt(ii).id == __char.id) { SelectedCharacters[ii] = __char; existsInGame = true; }
                            if (!existsInGame) SelectedCharacters.Add(__char);
                        }
                        _deads += _incident.killeds.Length;
                        Zombies += ((SpecialIncident)((object)_incident)).zombies.Length;

                        foreach (Character ____char in SelectedCharacters) Debug.WriteLine(____char.name);

                        ProccessedChars += ((SpecialIncident)((object)_incident)).characterCount /*+ ((SpecialIncident)((object)_incident)).resurrected.Length +  ((SpecialIncident)((object)_incident)).zombies.Length + ((SpecialIncident)((object)_incident)).clones.Length + ((SpecialIncident)((object)_incident)).chimps + ((SpecialIncident)((object)_incident)).bees + ((SpecialIncident)((object)_incident)).rats*/;
                    }
                    else
                    {
                        proccessedIncident = _incident.incidentOutput(_Characters);
                        foreach (Character __char in proccessedIncident.characters) for (int ii = 0; ii < SelectedCharacters.Count; ii++) if (SelectedCharacters.ElementAt(ii).id == __char.id) SelectedCharacters[ii] = __char;
                        _deads += _incident.killeds.Length;
                        ProccessedChars += _incident.characterCount;
                    }

                    

                    roundEvents.Add(proccessedIncident);

                    _NewDead += _deads; // + _d

                }

                
            }

            DeadChars = _NewDead;

            DeadZombs = 0;
            foreach (Character character in SelectedCharacters)
            {
                if (character.zombied && character.isNew && !character.alive) DeadZombs++;
            }

            StoredCharactersView.ItemsSource = new List<CharacterIncident>();
            StoredCharactersView.ItemsSource = roundEvents;
            StoredCharactersView.UpdateLayout();
        }

        public CharacterIncident FindEvents (Character character)
        {
            List<CharacterIncident> AvailableEvents = new List<CharacterIncident>();

            List<CharacterIncident> PotentialEvents = new List<CharacterIncident>();

            List<CharacterIncident> ValidatedEvents = new List<CharacterIncident>();

            if (DayCycle == 0) foreach (eventList _list in DayEventSpaces) foreach (CharacterIncident _incident in _list.innerList) AvailableEvents.Add(_incident);
            else if (DayCycle == 1) foreach (eventList _list in NightEventSpaces) foreach (CharacterIncident _incident in _list.innerList) AvailableEvents.Add(_incident);
            else if (DayCycle == 2) foreach (eventList _list in ScenarioEventSpaces) foreach (CharacterIncident _incident in _list.innerList) AvailableEvents.Add(_incident);

            foreach (CharacterIncident _incident in AvailableEvents)
            {
                bool checksOut = true;
                for (int i = 0; i < _incident.statLowerBounds.Length; i++)
                {
                    if (character.stats.ToFloats()[i] < _incident.statLowerBounds[0][i]) checksOut = false;
                }
                for (int i = 0; i < _incident.statUpperBounds.Length; i++)
                {
                    if (character.stats.ToFloats()[i] > _incident.statUpperBounds[0][i]) checksOut = false;
                }

                if (checksOut) PotentialEvents.Add(_incident);
            }

            foreach (CharacterIncident _incident in PotentialEvents)
            {
                if (SelectedCharacters.Count - (ProccessedChars + DeadChars - Zombies) >= _incident.characterCount)
                {
                    if (_incident.specialEvent == true)
                    {
                        SpecialIncident _sIncident = (SpecialIncident)((object)_incident);
                        //Debug.WriteLine("Dead Chars = " + DeadChars.ToString() + " ; _d = " + _d.ToString() + " ; Zombies = " + Zombies.ToString());
                        if ((_sIncident.resurrected.Length + _sIncident.zombies.Length) <= (DeadChars + _d - Zombies - DeadZombs)) if (ValidateEvent(_incident, character)) ValidatedEvents.Add(_incident);
                    }
                    else if (ValidateEvent(_incident, character)) ValidatedEvents.Add(_incident);
                }
            }

            List<int> weights = new List<int>();
            List<int> summedWeights = new List<int>();

            foreach (CharacterIncident _incident in ValidatedEvents)
            {
                weights.Add(_incident.wieght);
                summedWeights.Add(weights.Sum());
            }

            int SelectedWeight = MathExtra.RandomInt(1, weights.Sum());
            int SelectedEvent = 0;

            for (int i = 0; i < ValidatedEvents.Count; i++)
            {
                if (i == 0) { if (SelectedWeight <= summedWeights.ElementAt(i)) SelectedEvent = i; }
                else { if (SelectedWeight > summedWeights.ElementAt(i - 1) && SelectedWeight <= summedWeights.ElementAt(i)) SelectedEvent = i; }
            }

            return ValidatedEvents.ElementAt(SelectedEvent);
        }

        public bool ValidateEvent (CharacterIncident incident, Character currentCharacter)
        {
            if (incident.characterCount == 1)
            {
                return true;
            }
            List<Character> availableChars = new List<Character>();

            foreach (Character _char in SelectedCharacters) if (_char != currentCharacter && !_char.proccessed && _char.alive) availableChars.Add(_char);

            List<Character>[] _Chars = new List<Character>[incident.characterCount - 1];
            for (int i = 0; i < incident.characterCount - 1; i++) _Chars[i] = new List<Character>();


            foreach (Character _char in availableChars)
            { 
                for (int i = 1; i < incident.characterCount; i++)
                {
                    bool checksOut = true;
                    for (int ii = 0; ii < incident.statLowerBounds.Length; ii++) if (_char.stats.ToFloats()[ii] < incident.statLowerBounds[i][ii]) checksOut = false;
                    for (int ii = 0; ii < incident.statUpperBounds.Length; ii++) if (_char.stats.ToFloats()[ii] > incident.statUpperBounds[i][ii]) checksOut = false;

                    if (checksOut) _Chars[i - 1].Add(_char);
                }
            }
            bool checksOut2 = true;
            List<int>[] Appearances = new List<int>[incident.characterCount - 1];

            for (int i = 0; i < incident.characterCount - 1; i++) Appearances[i] = new List<int>();
            for (int i = 0; i < _Chars.Length; i++)
            {
                if (_Chars[i].Count == 0) return false;
                foreach (Character _char in _Chars[i])
                {
                    int _i = 0;
                    for (int ii = 0; ii < _Chars.Length; ii++) if (_Chars[ii].Contains(_char)) _i++;
                    Appearances[i].Add(_i);
                }
            }
            List<List<Character>> _sChars = new List<List<Character>>(_Chars);
            List<List<int>> _sAppearences = new List<List<int>>(Appearances);
            List<List<Character>> __Chars = new List<List<Character>>(_Chars);
            List<List<int>> __Appearences = new List<List<int>>(Appearances);
            _sChars.Sort((a, b) => a.Count - b.Count);
            _sAppearences.Sort((a, b) => a.Count - b.Count);
            _sChars.Reverse();
            _sAppearences.Reverse();
            List<List<Character>> __sChars = _sChars;
            List<List<int>> __sAppearences = _sAppearences;

            Character[] _SelectedCharacters = new Character[incident.characterCount - 1];

            for (int i = 0; i < _sChars.Count; i++)
            {
                int _ii = 0;
                for (int ii = 0; ii < _sChars.ElementAt(i).Count; ii++)
                {
                    if (_sAppearences.ElementAt(i).ElementAt(_ii) > _sAppearences.ElementAt(i).ElementAt(_ii)) _ii = ii;
                }
                int _iii = 0;
                for (int iii = 0; iii < __Chars.Count; iii++)
                {
                    if (__Chars.ElementAt(iii) == _sChars.ElementAt(i)) _iii = iii;
                }
                _SelectedCharacters[_iii] = _sChars.ElementAt(i).ElementAt(_ii);
                __Chars.ElementAt(_iii).RemoveAt(_ii);
            }

            if (_SelectedCharacters.ToList<Character>().Count != _SelectedCharacters.ToList<Character>().Distinct().Count()) checksOut2 = false;

            foreach (Character _char in availableChars)
            {
                bool checksOut = true;
                for (int i = 0; i < incident.characterCount - 1; i++) if (currentCharacter.opinions[_SelectedCharacters[i].relativeID - 1] < incident.opinionLowerBounds[0][i]) checksOut = false;
                for (int i = 0; i < incident.characterCount - 1; i++) if (currentCharacter.opinions[_SelectedCharacters[i].relativeID - 1] > incident.opinionUpperBounds[0][i]) checksOut = false;

                if (!checksOut) checksOut2 = false;
            }
            foreach (Character _char in availableChars)
            {
                for (int i = 1; i < incident.characterCount; i++)
                {
                    bool checksOut = true;
                    for (int ii = 0; ii < incident.characterCount - 1; ii++) if (_char.opinions[_SelectedCharacters[ii].relativeID - 1] < incident.opinionLowerBounds[i][ii]) checksOut = false;
                    for (int ii = 0; ii < incident.characterCount - 1; ii++) if (_char.opinions[_SelectedCharacters[ii].relativeID - 1] > incident.opinionUpperBounds[i][ii]) checksOut = false;

                    if (!checksOut) checksOut2 = false;
                }
            }

            return checksOut2;
        }

        public bool ValidateEvent(CharacterIncident incident, Character currentCharacter, out Character[] _charsAvailable)
        {
            _charsAvailable = new Character[0];

            if (incident.characterCount == 1)
            {
                return true;
            }
            List<Character> availableChars = new List<Character>();

            foreach (Character _char in SelectedCharacters) if (_char != currentCharacter && !_char.proccessed && _char.alive) availableChars.Add(_char);

            List<Character>[] _Chars = new List<Character>[incident.characterCount - 1];
            for (int i = 0; i < incident.characterCount - 1; i++) _Chars[i] = new List<Character>();


            foreach (Character _char in availableChars)
            {
                for (int i = 1; i < incident.characterCount; i++)
                {
                    bool checksOut = true;
                    for (int ii = 0; ii < incident.statLowerBounds.Length; ii++) if (_char.stats.ToFloats()[ii] < incident.statLowerBounds[i][ii]) checksOut = false;
                    for (int ii = 0; ii < incident.statUpperBounds.Length; ii++) if (_char.stats.ToFloats()[ii] > incident.statUpperBounds[i][ii]) checksOut = false;

                    if (checksOut) _Chars[i - 1].Add(_char);
                }
            }
            bool checksOut2 = true;
            List<int>[] Appearances = new List<int>[incident.characterCount - 1];

            for (int i = 0; i < incident.characterCount - 1; i++) Appearances[i] = new List<int>();
            for (int i = 0; i < _Chars.Length; i++)
            {
                if (_Chars[i].Count == 0) return false;
                foreach (Character _char in _Chars[i])
                {
                    int _i = 0;
                    for (int ii = 0; ii < _Chars.Length; ii++) if (_Chars[ii].Contains(_char)) _i++;
                    Appearances[i].Add(_i);
                }
            }
            List<List<Character>> _sChars = new List<List<Character>>(_Chars);
            List<List<int>> _sAppearences = new List<List<int>>(Appearances);
            List<List<Character>> __Chars = new List<List<Character>>(_Chars);
            List<List<int>> __Appearences = new List<List<int>>(Appearances);
            _sChars.Sort((a, b) => a.Count - b.Count);
            _sAppearences.Sort((a, b) => a.Count - b.Count);
            _sChars.Reverse();
            _sAppearences.Reverse();
            List<List<Character>> __sChars = _sChars;
            List<List<int>> __sAppearences = _sAppearences;

            Character[] _SelectedCharacters = new Character[incident.characterCount - 1];

            for (int i = 0; i < _sChars.Count; i++)
            {
                int _ii = 0;
                for (int ii = 0; ii < _sChars.ElementAt(i).Count; ii++)
                {
                    if (_sAppearences.ElementAt(i).ElementAt(_ii) > _sAppearences.ElementAt(i).ElementAt(_ii)) _ii = ii;
                }
                int _iii = 0;
                for (int iii = 0; iii < __Chars.Count; iii++)
                {
                    if (__Chars.ElementAt(iii) == _sChars.ElementAt(i)) _iii = iii;
                }
                _SelectedCharacters[_iii] = _sChars.ElementAt(i).ElementAt(_ii);
                __Chars.ElementAt(_iii).RemoveAt(_ii);
            }

            if (_SelectedCharacters.ToList<Character>().Count != _SelectedCharacters.ToList<Character>().Distinct().Count()) checksOut2 = false;

            foreach (Character _char in availableChars)
            {
                bool checksOut = true;
                for (int i = 0; i < incident.characterCount - 1; i++) if (currentCharacter.opinions[_SelectedCharacters[i].relativeID - 1] < incident.opinionLowerBounds[0][i]) checksOut = false;
                for (int i = 0; i < incident.characterCount - 1; i++) if (currentCharacter.opinions[_SelectedCharacters[i].relativeID - 1] > incident.opinionUpperBounds[0][i]) checksOut = false;

                if (!checksOut) checksOut2 = false;
            }
            foreach (Character _char in availableChars)
            {
                for (int i = 1; i < incident.characterCount; i++)
                {
                    bool checksOut = true;
                    for (int ii = 0; ii < incident.characterCount - 1; ii++) if (_char.opinions[_SelectedCharacters[ii].relativeID - 1] < incident.opinionLowerBounds[i][ii]) checksOut = false;
                    for (int ii = 0; ii < incident.characterCount - 1; ii++) if (_char.opinions[_SelectedCharacters[ii].relativeID - 1] > incident.opinionUpperBounds[i][ii]) checksOut = false;

                    if (!checksOut) checksOut2 = false;
                }
            }

            _charsAvailable = _SelectedCharacters;

            return checksOut2;
        }


        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            DoRound();
        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {
            await NavigationExtensions.PopAsync(this);
        }

        private void StoredCharactersView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
