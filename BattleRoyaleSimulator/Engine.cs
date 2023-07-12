using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

using System.Xml.Schema;
using System.Xml;

using System.Diagnostics;

using BattleRoyaleSimulator;

/*

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
This is Going to be the main file you want to look at since all the other stuff is future stuff for this Project. Gonna continue developing this in the future.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


*/

public static class DirectoryManagement
{
    public static string GetPath()
    {
        string appdata = Windows.Storage.ApplicationData.Current.RoamingFolder.Path;

        string storageDirectory = Path.Combine(appdata, "BattleRoyaleSimulator");

        if (!Directory.Exists(storageDirectory)) Directory.CreateDirectory(storageDirectory);

        return storageDirectory;
        
    }
}

[Serializable, XmlRoot("incidentList")]
public class incidentList           //Used to Bypass ristrictions in xml serialization for serializing lists of lists
{
    [XmlElement("innerList")] public List<CharacterIncident> innerList { get; set; }
    
    public incidentList() { }
    public incidentList (List<CharacterIncident> _l)
    {
        innerList = _l;
    }
}

public class DataManagement
{
    public List<Character> characters = new List<Character>();

    public List<CharacterIncident> incidents = new List<CharacterIncident>();   //    !!**       This is My Chosen List for the rquirements that does all the stuff. There are other lists but this one does most of the actual storing before writing.       **!!
    
    public static void SaveData(string _path)   // Tested Serialization with Character Data first. This will be used in future development.
    {
        //Saving Character Data
        Stats _stats = new Stats();
        _stats.setValues(11,12,13,14,15,16,17,18,19,9,8,7);
        Character guy = new Character(1, "Guy Standing");
            
        guy.stats = _stats;

        Stream stream = File.Open(_path + @"\characterData.ryl", FileMode.Create);

        BinaryFormatter bf = new BinaryFormatter();

        bf.Serialize(stream, guy);

        stream.Close();
            

        guy = null;


        stream = File.Open(_path + @"\characterData.ryl", FileMode.Open);

        bf = new BinaryFormatter();

        guy = (Character)bf.Deserialize(stream);

        stream.Close();

        Console.WriteLine("id = " + guy.id.ToString() + " ; Name = " + guy.name + " ; Stats = " + guy.stats.Luck);
    }

    public void ConvertCharacterData(string[] iS, float[] iF)    //Converts Strings to event and adds event to my List.
    {

        Character character = new Character();

        character.name = iS[0];
        int.TryParse(iS[1], out int result);
        character.id = result;

        character.stats.setValues(iF);

        characters.Add(character);

    }

    public static void SaveCharacterData(string _path, List<Character> _characterList)
    {

        if (File.Exists(_path + @"\characterData.xml")) File.Delete(_path + @"\characterData.xml");

        Stream stream = new FileStream(_path + @"\characterData.xml", FileMode.OpenOrCreate);

        XmlSerializer serializer = new XmlSerializer(typeof(List<Character>));
        serializer.Serialize(stream, _characterList);

        stream.Close();

    }
    public static List<Character> ReadCharacterData(string _path)
    {
        if (File.Exists(_path + @"\characterData.xml"))
        {

            List<Character> __List = new List<Character>();

            XmlSerializer deserializer = new XmlSerializer(typeof(List<Character>));

            Stream stream = new FileStream(_path + @"\characterData.xml", FileMode.OpenOrCreate);

            __List = (List<Character>)deserializer.Deserialize(stream);

            stream.Close();

            return __List;
        }
        else return new List<Character>();
    }

    public static List<Character> SaveReadCharacterData(string _path, List<Character> _characterList)
    {

        if (File.Exists(_path + @"\characterData.xml")) File.Delete(_path + @"\characterData.xml");

        Stream stream = new FileStream(_path + @"\characterData.xml", FileMode.OpenOrCreate);

        XmlSerializer serializer = new XmlSerializer(typeof(List<Character>));
        serializer.Serialize(stream, _characterList);

        stream.Close();

        List<Character> __List = new List<Character>();

        XmlSerializer deserializer = new XmlSerializer(typeof(List<Character>));

        stream = new FileStream(_path + @"\characterData.xml", FileMode.Open);

        __List = (List<Character>)deserializer.Deserialize(stream);

        stream.Close();

        return __List;
    }

    public void ConvertEventData( string[] iS, bool[] iB, int[] ii, int[][][] iii, float[][][] ffi )    //Converts Strings to event and adds event to my List.
    {
        CharacterIncident incident = new CharacterIncident();
        if (iB[0] == true) incident = new SpecialIncident();

        incident.name = iS[0];
        incident.eventSpace = iS[1];
        incident.incidentText = iS[2];

        incident.id = ii[0];
        incident.wieght = ii[1];
        incident.characterCount = ii[2];

        incident.statLowerBounds = ffi[0];
        incident.statUpperBounds = ffi[1];
        incident.statChanges = ffi[2];
        incident.opinionUpperBounds = iii[2];
        incident.opinionLowerBounds = iii[1];
        incident.opinionChanges = iii[3];

        incident.killers = iii[0][0].Distinct().ToArray();
        incident.killeds = iii[0][1].Distinct().ToArray();

        intArray[] __oC = new intArray[incident.opinionChanges.Length];
        for (int i = 0; i < __oC.Length; i++) __oC[i] = new intArray(incident.opinionChanges[i]);
        intArray[] __oU = new intArray[incident.opinionUpperBounds.Length];
        for (int i = 0; i < __oU.Length; i++) __oU[i] = new intArray(incident.opinionUpperBounds[i]);
        intArray[] __oL = new intArray[incident.opinionLowerBounds.Length];
        for (int i = 0; i < __oL.Length; i++) __oL[i] = new intArray(incident.opinionLowerBounds[i]);

        floatArray[] __sC = new floatArray[incident.statChanges.Length];
        for (int i = 0; i < __sC.Length; i++) __sC[i] = new floatArray(incident.statChanges[i]);
        floatArray[] __sU = new floatArray[incident.statUpperBounds.Length];
        for (int i = 0; i < __sU.Length; i++) __sU[i] = new floatArray(incident.statUpperBounds[i]);
        floatArray[] __sL = new floatArray[incident.statLowerBounds.Length];
        for (int i = 0; i < __sL.Length; i++) __sL[i] = new floatArray(incident.statLowerBounds[i]);

        incident.sC = __sC;
        incident.oC = __oC;
        incident.sU = __sU;
        incident.sL = __sL;
        incident.oU = __oU;
        incident.oL = __oL;

        incident.specialEvent = iB[0];

        if (iB[0] == true)
        {
            SpecialIncident _incident = incident.ToSpecialIncident();

            _incident.absurd = iB[1];

            _incident.chimps = ii[3];
            _incident.bees = ii[4];
            _incident.rats = ii[5];
            
            _incident.resurrected = iii[0][2].Distinct().ToArray();
            _incident.clones = iii[0][3].Distinct().ToArray();
            _incident.zombies = iii[0][4].Distinct().ToArray();

            incident = _incident;
        }

        incidents.Add(incident);

    } 

    public static void SaveEventData(string _path, List<List<CharacterIncident>> _incidentList) //My Chosen Algorithm/Program. Sorts and separates the events (or INcidents as the class is called) by their eventSpace first, and then saves all the events to an xml file.
    {
        if (File.Exists(_path + @"\eventData.xml")) File.Delete(_path + @"\eventData.xml");

        List<List<CharacterIncident>> _iL = DataManagement.SortEventData(_incidentList);

        List<eventList> _bigList = new List<eventList>();
        foreach (List<CharacterIncident> _list in _iL) _bigList.Add(new eventList(_list)); //new List<List<CharacterIncident>>();

        Stream stream = new FileStream(_path + @"\eventData.xml", FileMode.OpenOrCreate);
        
        XmlSerializer serializer = new XmlSerializer(typeof(List<eventList>));
        serializer.Serialize(stream, _bigList);
        
        stream.Close();
    }
    public static List<List<CharacterIncident>> ReadEventData(string _path)
    {
        if (File.Exists(_path + @"\eventData.xml"))
        {
            List<eventList> __bigList = new List<eventList>();

            XmlSerializer deserializer = new XmlSerializer(typeof(List<eventList>));

            Stream stream = new FileStream(_path + @"\eventData.xml", FileMode.OpenOrCreate);

            __bigList = (List<eventList>)deserializer.Deserialize(stream);

            stream.Close();

            List<List<CharacterIncident>> _blist = new List<List<CharacterIncident>>();

            foreach (eventList _list in __bigList) _blist.Add((List<CharacterIncident>)_list);

            foreach (List<CharacterIncident> _list in _blist) foreach (CharacterIncident incident in _list) incident.FixArrays();

            return DataManagement.SortEventData(_blist);
        }
        else return new List<List<CharacterIncident>>();
    }

    public static List<List<CharacterIncident>> SaveReadEventData(string _path, List<List<CharacterIncident>> _incidentList) //My Chosen Algorithm/Program. Sorts and separates the events (or INcidents as the class is called) by their eventSpace first, and then saves all the events to an xml file.
    {
        if (File.Exists(_path + @"\eventData.xml")) File.Delete(_path + @"\eventData.xml");

        List<List<CharacterIncident>> _iL = DataManagement.SortEventData(_incidentList);

        List<eventList> _bigList = new List<eventList>();
        foreach (List<CharacterIncident> _list in _iL) _bigList.Add(new eventList(_list)); //new List<List<CharacterIncident>>();

        Stream stream = new FileStream(_path + @"\eventData.xml", FileMode.OpenOrCreate);

        XmlSerializer serializer = new XmlSerializer(typeof(List<eventList>));
        serializer.Serialize(stream, _bigList);

        stream.Close();

        List<eventList> __bigList = new List<eventList>();

        XmlSerializer deserializer = new XmlSerializer(typeof(List<eventList>));

        Stream _stream = new FileStream(_path + @"\eventData.xml", FileMode.OpenOrCreate);

        __bigList = (List<eventList>)deserializer.Deserialize(_stream);

        _stream.Close();

        List<List<CharacterIncident>> _blist = new List<List<CharacterIncident>>();

        foreach (eventList _list in __bigList) _blist.Add((List<CharacterIncident>)_list);

        foreach (List<CharacterIncident> _list in _blist) foreach (CharacterIncident incident in _list) incident.FixArrays();

        return DataManagement.SortEventData(_blist);
    }

    public static List<List<CharacterIncident>> SortEventData(List<List<CharacterIncident>> _incs)
    {
        List<string> _spaces = new List<string>();
        List<CharacterIncident> _ins = new List<CharacterIncident>();
        List<List<CharacterIncident>> _insL = new List<List<CharacterIncident>>();

        foreach (List<CharacterIncident> _list in _incs) _ins.AddRange(_list);

        foreach (CharacterIncident incident in _ins)
        {
            bool added = false;
            int i = 0;
            foreach (string _space in _spaces)
            {
                if (incident.eventSpace == _space)
                {
                    _insL.ElementAt(i).Add(incident);
                    added = true;
                }
                i++;
            }
            if (added == false)
            {
                List<CharacterIncident> __ins = new List<CharacterIncident>();
                __ins.Add(incident);
                _insL.Add(__ins);
                _spaces.Add(incident.eventSpace);
            }
        }

        IDComparator _comparator = new IDComparator();
        foreach (List<CharacterIncident> _list in _insL)
        {
            _list.Sort(_comparator);
        }

        return _insL;
    }

    public static List<List<CharacterIncident>> SortEventData(List<CharacterIncident> _incs)
    {
        List<string> _spaces = new List<string>();
        List<CharacterIncident> _ins = new List<CharacterIncident>();
        List<List<CharacterIncident>> _insL = new List<List<CharacterIncident>>();

        _ins = _incs;

        foreach (CharacterIncident incident in _ins)
        {
            bool added = false;
            int i = 0;
            foreach (string _space in _spaces)
            {
                if (incident.eventSpace == _space)
                {
                    _insL.ElementAt(i).Add(incident);
                    added = true;
                }
                i++;
            }
            if (added == false)
            {
                List<CharacterIncident> __ins = new List<CharacterIncident>();
                __ins.Add(incident);
                _insL.Add(__ins);
                _spaces.Add(incident.eventSpace);
            }
        }

        return _insL;
    }

    // !!** In Order to Check out the output, do windows key + R, type "%appdata%" and then press enter, and then go to BattleRoyaleSimulator. %appdata% is a general application data folder so i chose to have it store there since its pretty consistant in windows computers and user specific. **!!
    // Oh yeah to view it's contents tight click the xml file and do "open with" and then choose a text editor like notepad

}

public static class Extensions
{
    public static void DeconvertEventData(this CharacterIncident incident, out string[] iS, out bool[] iB, out int[] ii, out int[][][] iii, out float[][][] ffi)    //Converts Strings to event and adds event to my List.
    {
        iS = new string[3];
        iB = new bool[] { false, false };
        ii = new int[] { 0, 0, 0, 0, 0, 0 };
        iii = new int[][][]
        {
            new int[5][],
            new int[][] { new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
            new int[][] { new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
            new int[][] { new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } }
        };
        ffi = new float[][][]
        {
            new float[][] { new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
            new float[][] { new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
            new float[][] { new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
        };

        iS[0] = incident.name;
        iS[1] = incident.eventSpace;
        iS[2] = incident.incidentText;

        ii[0] = incident.id;
        ii[1] = incident.wieght;
        ii[2] = incident.characterCount;

        incident.FixArrays();

        ffi[0] = incident.statLowerBounds;
        ffi[1] = incident.statUpperBounds;
        ffi[2] = incident.statChanges;
        iii[2] = incident.opinionUpperBounds;
        iii[1] = incident.opinionLowerBounds;
        iii[3] = incident.opinionChanges;

        for (int i = 0; i < 3; i++)
        {
            if (ffi[i] == null) ffi[i] = new float[][] { new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
            if (iii[i + 1] == null) iii[i + 1] = new int[][] { new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
        }

        iii[0][0] = incident.killers.Distinct().ToArray();
        iii[0][1] = incident.killeds.Distinct().ToArray();

        iB[0] = incident.specialEvent;

        if (incident.specialEvent == true)
        {
            SpecialIncident _incident = incident.ToSpecialIncident();

            iB[1] = _incident.absurd;

            ii[3] = _incident.chimps;
            ii[4] = _incident.bees;
            ii[5] = _incident.rats;

            iii[0][2] = _incident.resurrected.Distinct().ToArray();
            iii[0][3] = _incident.clones.Distinct().ToArray();
            iii[0][4] = _incident.zombies.Distinct().ToArray();

        }

    }

    public static void DeconvertCharacterData(this Character character, out string[] iS, out float[] iF)    //Converts Strings to event and adds event to my List.
    {
        iS = new string[] { "", "" };
        iF = new float[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

        iS[0] = character.name;
        iS[1] = character.id.ToString();

        iF = character.stats.ToFloats();

    }

    public static SpecialIncident ToSpecialIncident(this CharacterIncident incident)
    {
        if (incident.GetType() != typeof(SpecialIncident))
        {
            SpecialIncident _incident = new SpecialIncident();

            _incident.name = incident.name;
            _incident.eventSpace = incident.eventSpace;
            _incident.incidentText = incident.incidentText;

            _incident.id = incident.id;
            _incident.characterCount = incident.characterCount;
            _incident.killers = incident.killers;
            _incident.killeds = incident.killeds;

            _incident.characters = incident.characters;
            _incident.opinionChanges = incident.opinionChanges;
            _incident.statChanges = incident.statChanges;

            _incident.sL = incident.sL;
            _incident.sU = incident.sU;
            _incident.oL = incident.oL;
            _incident.oU = incident.oU;
            _incident.oC = incident.oC;
            _incident.sC = incident.sC;

            _incident.statLowerBounds = incident.statLowerBounds;
            _incident.statUpperBounds = incident.statUpperBounds;
            _incident.opinionLowerBounds = incident.opinionLowerBounds;
            _incident.opinionUpperBounds = incident.opinionUpperBounds;
            _incident.wieght = incident.wieght;

            _incident.specialEvent = incident.specialEvent;

            return _incident;
        }
        else
        {
            return (SpecialIncident)((object)incident);
        }
    }

    public static void Shuffle<T> (this List<T> list) where T : class
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}

class IDComparator : IComparer<CharacterIncident>
{
    public int Compare(CharacterIncident x, CharacterIncident y)
    {
        if (x.id == 0 || y.id == 0)
        {
            return 0;
        }

        // CompareTo() method
        return x.id.CompareTo(y.id);

    }
}

class SetUpManagement
{

}


