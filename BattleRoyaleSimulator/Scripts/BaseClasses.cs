using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

using System.Diagnostics;

//Creating this from Scratch so only refrences I Will do will be to system (since they are kind of necessary otherwise c# programs wouldnt be a thing) and to other files I am making specifically for this project so everything is uncluded and no need to comment ouit anything (woo!)

/*

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
I Suggest Skipping to the Event Class since besides that most of the classes aren't used in the saving / writing xml proecedure.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


*/

namespace BattleRoyaleSimulator
{
    //If you allowed arrays instead of only lists/collections I would have been a very happy person

    /*
    This File will be for Classes.
    Having everything Seperated like this will help me out later on. (hopefully)

    IDs are heavilly used in order to properly keep track of different things since everything except IDs can change.
    */




    /*
        Stats are the basic details for each of the characters.
        Most of the Stats arew self-explanatory.
        For Math-Purposes the Values are 10 more than they appear to the User just to make things easier to understand.
    */
    [Serializable , XmlRoot("Stats")]
    public class Stats //Making Stats its own class will save me many headaches further along from past experience.
    {
        //Principle Stats   -   These are the Stats that will inflence how most of the other stats are calculated. Besides sanity these stats will rarely be changed.
        [XmlElement("Cons")] public float Cons = 10f;        //Consistancy
        [XmlElement("Luck")] public float Luck = 10f;        //Luck
        [XmlElement("Chaos")] public float Chaos = 10f;       //Chaos
        [XmlElement("Sanity")] public float Sanity = 10f;      //Sanity
        //Main Stats        -   These are going to be the most used Stats dictating general things. (Example) High intelligence rolls might lead to character finding a book about Survival tips leading to an increase in the Character's Resourcefulness.
        [XmlElement("Intel")] public float Intel = 10f;       //Intelligence
        [XmlElement("Martial")] public float Martial = 10f;     //Martial
        [XmlElement("Charisma")] public float Charisma = 10f;    //Charisma
        [XmlElement("Dilig")] public float Dilig = 10f;       //Diligence
        //Secondary Stats   -   These are used for more specific things. (Example) A good Resourcefullness roll at night could lead to character setting up a Decent Campsite, recovering some health.
        [XmlElement("Empathy")] public float Empathy = 10f;     //Empathy
        [XmlElement("Resrfl")] public float Resrfl = 10f;      //Resourcefulness
        [XmlElement("Determ")] public float Determ = 10f;      //Determination
        [XmlElement("Stability")] public float Stability = 10f;   //Stability

        public void setValues(float _1 = 10f, float _2 = 10f, float _3 = 10f, float _4 = 10f, float _5 = 10f, float _6 = 10f, float _7 = 10f, float _8 = 10f, float _9 = 10f, float _10 = 10f, float _11 = 10f, float _12 = 10f)
        {
            Cons = _1;
            Luck = _2;
            Chaos = _3;
            Sanity = _4;
            Intel = _5;
            Martial = _6;
            Charisma = _7;
            Dilig = _8;
            Empathy = _9;
            Resrfl = _10;
            Determ = _11;
            Stability = _12;
        }

        public void setValues(float[] inputs)
        {
            if (inputs.Length != 12) throw new ArgumentException("inputs should be float[12]");
            Cons = inputs[0];
            Luck = inputs[1];
            Chaos = inputs[2];
            Sanity = inputs[3];
            Intel = inputs[4];
            Martial = inputs[5];
            Charisma = inputs[6];
            Dilig = inputs[7];
            Empathy = inputs[8];
            Resrfl = inputs[9];
            Determ = inputs[10];
            Stability = inputs[11];
        }

        public void addValues(float[] inputs)
        {
            if (inputs.Length != 12) throw new ArgumentException("inputs should be float[12]");
            Cons += inputs[0];
            Luck += inputs[1];
            Chaos += inputs[2];
            Sanity += inputs[3];
            Intel += inputs[4];
            Martial += inputs[5];
            Charisma += inputs[6];
            Dilig += inputs[7];
            Empathy += inputs[8];
            Resrfl += inputs[9];
            Determ += inputs[10];
            Stability += inputs[11];
        }

        /*
            CODE EXPLANATION
        
            So this is my 7th time now setting up base code that works simularly and in my opinion it is the most Refined version of my stat-shuffling code.

            This version makes significant use of Normal Probability. (FINALLY A USE FOR AP STATS. Granted I'm still in high school but still it's proved shockingly useful in programming.)
        
            The way the shuffled stat is calculated is by running everything through an Inverse Normal Cumulative Distribution Function. (For Details on how it works go to the MathExtra File.)

            The Mean is just the base-value for the stat.
        
            The Standard deviation is Mainly dictated through the Chaos Stat. The value of the Chaos Stat is multiplied with a gaussian random number. (Created using random number between Consistancy divded by 20 and 1 put throuugh inversenorm that is affected by Luck).
            
            The Area value is determined by a random number that is skewed towards either 0 or 1 by a magnitude that depends on the value of Luck.
            
            All of this Results in Rolled Stats that are close to the base stat, but can be off by an amount that depends on the values of the Principle Stats minus Sanity. Sanity is used for the lowering and raising of specific stats over time.
        */
        public void ShuffleStats()     //Used for Rolling Stats.
        {
            Intel = MathExtra.InverseNorm(Intel, Chaos * MathExtra.InverseNorm(0.5f, 0.19f * (Luck / 15), MathExtra.RandomFloat(Cons / 20, 1f)), MathExtra.SkewedFloat((Luck - 10) / 10, MathExtra.RandomFloat(0, 1)));
            Martial = MathExtra.InverseNorm(Martial, Chaos * MathExtra.InverseNorm(0.5f, 0.19f * (Luck / 15), MathExtra.RandomFloat(Cons / 20, 1f)), MathExtra.SkewedFloat((Luck - 10) / 10, MathExtra.RandomFloat(0, 1)));
            Charisma = MathExtra.InverseNorm(Charisma, Chaos * MathExtra.InverseNorm(0.5f, 0.19f * (Luck / 15), MathExtra.RandomFloat(Cons / 20, 1f)), MathExtra.SkewedFloat((Luck - 10) / 10, MathExtra.RandomFloat(0, 1)));
            Dilig = MathExtra.InverseNorm(Dilig, Chaos * MathExtra.InverseNorm(0.5f, 0.19f * (Luck / 15), MathExtra.RandomFloat(Cons / 20, 1f)), MathExtra.SkewedFloat((Luck - 10) / 10, MathExtra.RandomFloat(0, 1)));
            Empathy = MathExtra.InverseNorm(Empathy, Chaos * MathExtra.InverseNorm(0.5f, 0.19f * (Luck / 15), MathExtra.RandomFloat(Cons / 20, 1f)), MathExtra.SkewedFloat((Luck - 10) / 10, MathExtra.RandomFloat(0, 1)));
            Resrfl = MathExtra.InverseNorm(Resrfl, Chaos * MathExtra.InverseNorm(0.5f, 0.19f * (Luck / 15), MathExtra.RandomFloat(Cons / 20, 1f)), MathExtra.SkewedFloat((Luck - 10) / 10, MathExtra.RandomFloat(0, 1)));
            Determ = MathExtra.InverseNorm(Determ, Chaos * MathExtra.InverseNorm(0.5f, 0.19f * (Luck / 15), MathExtra.RandomFloat(Cons / 20, 1f)), MathExtra.SkewedFloat((Luck - 10) / 10, MathExtra.RandomFloat(0, 1)));
            Stability = MathExtra.InverseNorm(Stability, Chaos * MathExtra.InverseNorm(0.5f, 0.19f * (Luck / 15), MathExtra.RandomFloat(Cons / 20, 1f)), MathExtra.SkewedFloat((Luck - 10) / 10, MathExtra.RandomFloat(0, 1)));
        }
        public float ShuffledFloat(float _i)     //Used for Rolling Luck. Works the same as above except that it acts like all the principle stats minus luck are 10
        {
            float result = MathExtra.InverseNorm(_i, 10 * MathExtra.InverseNorm(0.5f, 0.19f * (Luck / 15), MathExtra.RandomFloat(10 / 20, 1f)), MathExtra.SkewedFloat((Luck - 10) / 10, MathExtra.RandomFloat(0, 1)));
            return result;
        }

        public float[] ToFloats()
        {
            float[] _f = new float[12];
            _f[0] = Cons;
            _f[1] = Luck;
            _f[2] = Chaos;
            _f[3] = Sanity;

            _f[4] = Intel;
            _f[5] = Martial;
            _f[6] = Charisma;
            _f[7] = Dilig;

            _f[8] = Empathy;
            _f[9] = Resrfl;
            _f[10] = Determ;
            _f[11] = Stability;

            return _f;
        }
    }

    [Serializable]
    public class Team  //A weird Fusion between Hunger Games districts and general alliances and other stuff
    {
        public int TeamID;              //Team ID
        public int[] members;           //Member IDs
        public int gvmtID;              //Determines How the Team will function.    id=0 Means its just an alliance   id=1 has a team leader id=2 means it is a non-agression pact.
        public int leaderID;            //El Team leader's id


        public List<int> allies;       //Allied Teams.
        public List<int> enemies;      //Enemy Teams.
    }

    [Serializable , XmlRoot("Character")]
    public class Character : ISerializable     //Main Class for Characters.
    {
        [XmlElement("id")] public int id { get; set; }                 //IDs will be assigned in order to keep track of characters.
        [XmlElement("relativeID")] public int relativeID;                      //An ID that keeps track of the character relative to other characters instead of overall and dictates things such as their index in the opinion arrays.
        [XmlElement("Name")] public string name { get; set; }            //Character Name
        [XmlElement("stats")] public Stats stats { get; set; }            //Base Stats

        [XmlElement("roundStats")] public Stats roundStats;                    //Rolled Stats for a round
        [XmlElement("roundLuck")] public float roundLuck;                     //Rolled Luck for a round
        [XmlElement("Stats")] public Stats rolledStats;                   //Rolled Stats for an interaction or for secondary rolls
        [XmlElement("rolledLuck")] public float rolledLuck;                    //Rolled Luck for an interacton or secdonary rolls

        [XmlArray("opinions")] [XmlArrayItem("opinion")] public int[] opinions;                      //Opinion of other Characters

        [XmlElement("alive")] public bool alive;                          //Is This Character still alive?
        [XmlElement("killCount")] public int killCount;                       //How Many People did they kill?

        [XmlIgnore] public bool zombied = false;
        [XmlIgnore] public bool isNew = false;
        [XmlIgnore] public bool proccessed = false;

        public Character() { stats = new Stats(); }

        public Character(int _id = 0, string _name = "SAMPLE TEXT")
        {
            id = _id;
            name = _name;
            stats = new Stats(); 
        }

        public void fixOpinionArraySize(int characterCount)
        {
            if (opinions == null) { opinions = new int[characterCount]; for (int i = 0; i < characterCount; i++) opinions[i] = 0; };
            List<int> opinionList = new List<int>();
            for (int i = 0; i < opinions.Length; i++) opinionList.Add(opinions[i]);
            for (int i = 0; i < characterCount - opinions.Length; i++) opinionList.Add(0);
            opinions = opinionList.ToArray();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("name", name);
            info.AddValue("stats", stats);
            info.AddValue("roundStats", roundStats);
            info.AddValue("roundLuck", roundLuck);
            info.AddValue("rolledStats", rolledStats);
            info.AddValue("rolledLuck", rolledLuck);
        }

        public Character(SerializationInfo info, StreamingContext context)
        {
            id = (int)info.GetValue("id", typeof(int));
            name = (string)info.GetValue("name", typeof(string));
            stats = (Stats)info.GetValue("stats", typeof(Stats));
            roundStats = (Stats)info.GetValue("roundStats", typeof(Stats));
            roundLuck = (float)info.GetValue("roundLuck", typeof(float));
            rolledStats = (Stats)info.GetValue("rolledStats", typeof(Stats));
            rolledLuck = (float)info.GetValue("rolledLuck", typeof(float));
        }
    }

    [Serializable , XmlType("CharacterIncident") , XmlInclude(typeof(SpecialIncident))]
    public class CharacterIncident : ISerializable //Non-Team Incidents. The most common kind.
    {

        [XmlElement("name")] public string name;
        [XmlElement("eventSpace")] public string eventSpace;
        [XmlElement("incidentText")] public string incidentText;

        [XmlElement("id")] public int id = 0;
        [XmlElement("characterCount")] public int characterCount = 1;
        [XmlArray("killers")] [XmlArrayItem("killer")] public int[] killers;
        [XmlArray("killeds")] [XmlArrayItem("killed")] public int[] killeds;

        [XmlIgnore] public Character[] characters;  //beautiful, oh so beautiful arrays. 
        [XmlIgnore] public int[][] opinionChanges = new int[][]
            {
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
        [XmlIgnore] public float[][] statChanges = new float[][]
        {
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        [XmlArray("statLowerBounds")] [XmlArrayItem("statLowerBound")] public floatArray[] sL;
        [XmlArray("statUpperBounds")] [XmlArrayItem("statUpperBound")] public floatArray[] sU;
        [XmlArray("opinionLowerBounds")] [XmlArrayItem("opinionLowerBound")] public intArray[] oL;
        [XmlArray("opinionUpperBounds")] [XmlArrayItem("opinionUpperBound")] public intArray[] oU;
        [XmlArray("opinionChanges")] [XmlArrayItem("opinionChange")] public intArray[] oC;
        [XmlArray("statChanges")] [XmlArrayItem("statChange")] public floatArray[] sC;

        [XmlIgnore] public float[][] statLowerBounds = new float[][]
        {
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        [XmlIgnore] public float[][] statUpperBounds = new float[][]
        {
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        [XmlIgnore] public int[][] opinionLowerBounds = new int[][]
            {
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
        [XmlIgnore] public int[][] opinionUpperBounds = new int[][]
            {
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
        [XmlElement("weight")] public int wieght = 1;

        [XmlElement("specialEvent")] public bool specialEvent = false;

        public CharacterIncident()
        {
            oC = new intArray[opinionChanges.Length];
            for (int i = 0; i < oC.Length; i++) oC[i] = new intArray(opinionChanges[i]);
            oU = new intArray[opinionUpperBounds.Length];
            for (int i = 0; i < oU.Length; i++) oU[i] = new intArray(opinionUpperBounds[i]);
            oL = new intArray[opinionLowerBounds.Length];
            for (int i = 0; i < oL.Length; i++) oL[i] = new intArray(opinionLowerBounds[i]);

            sC = new floatArray[statChanges.Length];
            for (int i = 0; i < sC.Length; i++) sC[i] = new floatArray(statChanges[i]);
            sU = new floatArray[statUpperBounds.Length];
            for (int i = 0; i < sU.Length; i++) sU[i] = new floatArray(statUpperBounds[i]);
            sL = new floatArray[statLowerBounds.Length];
            for (int i = 0; i < sL.Length; i++) sL[i] = new floatArray(statLowerBounds[i]);
        }

        public CharacterIncident incidentOutput(Character[] characters)
        {
            CharacterIncident result = new CharacterIncident();
            result.characters = characters;
            int[] relativeIDs = new int[characterCount];
            result.incidentText = incidentText;
            for (int i = 1; i <= characterCount; i++)
            {
                result.incidentText = result.incidentText.Replace("[Player" + i.ToString() + "]", result.characters[i - 1].name);
                result.characters[i - 1].stats.addValues(statChanges[i - 1]);
                relativeIDs[i - 1] = result.characters[i - 1].relativeID;
            }

            foreach (Character _char in result.characters) _char.proccessed = true;

            for (int i = 0; i < characterCount; i++) for (int ii = 0; ii < characterCount; ii++) result.characters[i].opinions[relativeIDs[ii] - 1] = opinionChanges[i][relativeIDs[ii] - 1];

            for (int i = 0; i < killeds.Length; i++) result.characters[killeds[i] - 1].alive = false;
            for (int i = 0; i < killers.Length; i++) result.characters[killers[i] - 1].killCount++;

            return result;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) //!!**     This is My Procedure. It wont directly appear to be called but it gets called during serialization. It neccesarily have a return but it does write data to info.   **!!
        {
            info.AddValue("name", name);
            info.AddValue("incidentText", incidentText);
            info.AddValue("id", id);
            info.AddValue("characterCount", characterCount);
            info.AddValue("killers", killers);
            info.AddValue("killeds", killeds);

            oC = new intArray[opinionChanges.Length];
            for (int i = 0; i < oC.Length; i++) oC[i] = new intArray(opinionChanges[i]);
            oU = new intArray[opinionUpperBounds.Length];
            for (int i = 0; i < oU.Length; i++) oU[i] = new intArray(opinionUpperBounds[i]);
            oL = new intArray[opinionLowerBounds.Length];
            for (int i = 0; i < oL.Length; i++) oL[i] = new intArray(opinionLowerBounds[i]);

            sC = new floatArray[statChanges.Length];
            for (int i = 0; i < sC.Length; i++) sC[i] = new floatArray(statChanges[i]);
            sU = new floatArray[statUpperBounds.Length];
            for (int i = 0; i < sU.Length; i++) sU[i] = new floatArray(statUpperBounds[i]);
            sL = new floatArray[statLowerBounds.Length];
            for (int i = 0; i < sL.Length; i++) sL[i] = new floatArray(statLowerBounds[i]);

            info.AddValue("oC", oC);
            info.AddValue("sC", sC);
            info.AddValue("oU", oU);
            info.AddValue("oL", oL);
            info.AddValue("sU", sU);
            info.AddValue("sL", sL);

            info.AddValue("wieght", wieght);
            info.AddValue("specialEvent", specialEvent);
        }

        public CharacterIncident(SerializationInfo info, StreamingContext context)
        {
            incidentText = (string)info.GetValue("name", typeof(string));
            incidentText = (string)info.GetValue("incidentText", typeof(string));
            id = (int)info.GetValue("id", typeof(int));
            characterCount = (int)info.GetValue("characterCount", typeof(int));
            killers = (int[])info.GetValue("killers", typeof(int[]));
            killeds = (int[])info.GetValue("killeds", typeof(int[]));
            
            oC = (intArray[])info.GetValue("oC", typeof(intArray[]));
            sC = (floatArray[])info.GetValue("sC", typeof(floatArray[]));
            sL = (floatArray[])info.GetValue("sL", typeof(floatArray[]));
            sU = (floatArray[])info.GetValue("sU", typeof(floatArray[]));
            oL = (intArray[])info.GetValue("oL", typeof(intArray[]));
            oU = (intArray[])info.GetValue("oU", typeof(intArray[]));

            for (int i = 0; i < oC.Length; i++) opinionChanges[i] = oC[i].innerArray;
            for (int i = 0; i < oU.Length; i++) opinionUpperBounds[i] = oU[i].innerArray;
            for (int i = 0; i < oL.Length; i++) opinionLowerBounds[i] = oL[i].innerArray;

            for (int i = 0; i < sC.Length; i++) statChanges[i] = sC[i].innerArray;
            for (int i = 0; i < sU.Length; i++) statUpperBounds[i] = sU[i].innerArray;
            for (int i = 0; i < sL.Length; i++) statLowerBounds[i] = sL[i].innerArray;

            wieght = (int)info.GetValue("wieght", typeof(int));
            specialEvent = (bool)info.GetValue("specialEvent", typeof(bool));
        }

        public void FixArrays()
        {
            for (int i = 0; i < oC.Length; i++) opinionChanges[i] = oC[i].innerArray;
            for (int i = 0; i < oU.Length; i++) opinionUpperBounds[i] = oU[i].innerArray;
            for (int i = 0; i < oL.Length; i++) opinionLowerBounds[i] = oL[i].innerArray;

            for (int i = 0; i < sC.Length; i++) statChanges[i] = sC[i].innerArray;
            for (int i = 0; i < sU.Length; i++) statUpperBounds[i] = sU[i].innerArray;
            for (int i = 0; i < sL.Length; i++) statLowerBounds[i] = sL[i].innerArray;
        }

    }

    [Serializable , XmlType("SpecialIncident")]
    public class SpecialIncident    :   CharacterIncident , ISerializable    //Special Incidents. Probably Wont be available for public editing and are only for pre-made packs.
    {

        //Special Stuff -  this stuff will not happen often and can be disabled.
        [XmlElement("absurd")] public bool absurd;             //dictating if absurd or not. Will probably be true for all of them. Exists so these events can be disabled.

        [XmlArray("resurrecteds")] [XmlArrayItem("resurrected")] public int[] resurrected;       //Characters May Be Resurrected
        [XmlArray("zombies")] [XmlArrayItem("zombie")] public int[] zombies;           //Unsuccesful resurrectios lead to zombies. Won't turn other characters into zombies though.
        [XmlArray("clones")] [XmlArrayItem("clone")] public int[] clones;            //Character is Cloned.
        [XmlElement("chimps")] public int chimps;              //[RANDOM CHIMP EVENT.]
        [XmlElement("bees")] public int bees;                //NO NOT THE BEES!!!!
        [XmlElement("rats")] public int rats;                //rat

        [XmlIgnore] public int newDeathCount;

        public SpecialIncident() { }

        public SpecialIncident incidentOutput(Character[] characters, ref List<Character> everyone, out int _deads)
        {
            int deathCount = 0;

            Stats _chimpStats = new Stats();
            _chimpStats.setValues(10, 10, 20, 0, 5, 15, 0, 7, 0, 15, 20, 20);
            Character chimpTemplate = new Character(500, "Chimp");
            chimpTemplate.stats = _chimpStats;

            Stats _beeStats = new Stats();
            _beeStats.setValues(20, 2, 20, 0, 1, 20, 0, 20, 0, 10, 20, 20);
            Character beeTemplate = new Character(501, "Bee Squadron");
            beeTemplate.stats = _beeStats;

            Stats _ratStats = new Stats();
            _ratStats.setValues(10, 10, 20, 0, 3, 12, 10, 5, 0, 20, 20, 20);
            Character ratTemplate = new Character(502, "rat.");
            ratTemplate.stats = _ratStats;          

            SpecialIncident result = new SpecialIncident();
            result.characters = characters;
            int[] relativeIDs = new int[characterCount];
            result.incidentText = incidentText;
            for (int i = 1; i <= characterCount; i++)
            {
                result.incidentText = result.incidentText.Replace("[Player" + i.ToString() + "]", result.characters[i - 1].name);
                result.characters[i - 1].stats.addValues(statChanges[i - 1]);
                relativeIDs[i - 1] = result.characters[i - 1].relativeID;
            }

            foreach (Character _char in result.characters) _char.proccessed = true;

            for (int i = 0; i < characterCount; i++) for (int ii = 0; ii < characterCount; ii++) result.characters[i].opinions[relativeIDs[ii] - 1] = opinionChanges[i][relativeIDs[ii] - 1];

            for (int i = 0; i < killeds.Length; i++) result.characters[killeds[i] - 1].alive = false;
            for (int i = 0; i < killers.Length; i++) result.characters[killers[i] - 1].killCount++;

            SpecialIncident result2 = result;

            List<Character> updatedCharacters = new List<Character>();
            List<int> charactersIn = new List<int>();

            result2.characters = everyone.ToArray();

            for (int i = 0; i < result2.characters.Length; i++)
            {
                if (result2.characters[i].relativeID == result.characters[i].relativeID) result2.characters[i] = result.characters[i];
                updatedCharacters.Add(result2.characters[i]);
                charactersIn.Add(result2.characters[i].id);
            }

            for (int i = 0; i < clones.Length; i++)
            {
                Character clone = result.characters[i];
                clone.relativeID = updatedCharacters.Count;
                clone.proccessed = true;
                updatedCharacters.Add(clone);
            }
            for (int i = 0; i < zombies.Length; i++)
            {
                bool foundR = false;
                List<Character> _everyone = new List<Character>(everyone);
                _everyone.Shuffle();
                int __ii = -1;
                Debug.WriteLine("Start Zombie Search");
                for (int ii = 0; ii < _everyone.Count; ii++)
                {
                    if (!foundR)
                    {
                        //Debug.WriteLine(_everyone[ii].name.ToString());
                        //Debug.WriteLine(_everyone[ii].alive.ToString());
                        //Debug.WriteLine(_everyone[ii].zombied.ToString());
                        if (!_everyone[ii].alive && !_everyone[ii].zombied) { foundR = true; __ii = ii; }
                    }
                }
                Debug.WriteLine(__ii.ToString());
                Character zombie = _everyone[__ii];
                everyone[_everyone[__ii].relativeID - 1].zombied = true;
                zombie.relativeID = updatedCharacters.Count;
                zombie.name = "The Ressurected, Rotting Corpse of " + _everyone[__ii].name;
                zombie.stats.Empathy = 0;
                zombie.stats.Sanity = 0;
                zombie.stats.Stability = 0;
                zombie.stats.Martial += 2;
                zombie.alive = true;
                zombie.proccessed = true;
                zombie.zombied = true;
                zombie.isNew = true;
                deathCount--;
                updatedCharacters.Add(zombie);

                //Debug.WriteLine(zombies[i].ToString() + " is zombie[i]");
                result.incidentText = result.incidentText.Replace("[Player" + zombies[i].ToString() + "]", _everyone[__ii].name);
                //}
            }
            for (int i = 0; i < resurrected.Length; i++)
            {
                //if (deathCount > 0)
                //{
                int r = MathExtra.RandomInt(1, everyone.Count);
                bool foundR = everyone[r].alive;
                while (foundR == true)
                {
                    r = MathExtra.RandomInt(1, everyone.Count);
                    foundR = everyone[r].alive;
                }
                everyone[r].alive = true;
                everyone[r].proccessed = true;
                updatedCharacters.Add(everyone[r]);
                    deathCount--;
                //}
            }
            for (int i = 0; i < chimps; i++)
            {
                Character chimp = chimpTemplate;
                chimp.id += updatedCharacters.Count;
                chimp.relativeID = updatedCharacters.Count;
                chimp.proccessed = true;
                chimp.alive = true;
                updatedCharacters.Add(chimp);
                Debug.WriteLine("Chimped.");
            }
            
            for (int i = 0; i < bees; i++)
            {
                Character bee = beeTemplate;
                bee.relativeID = updatedCharacters.Count;
                bee.proccessed = true;
                updatedCharacters.Add(bee);
            }
            for (int i = 0; i < rats; i++)
            {
                Character rat = ratTemplate;
                rat.relativeID = updatedCharacters.Count;
                rat.proccessed = true;
                updatedCharacters.Add(rat);
            }

            result2.characters = updatedCharacters.ToArray();
            result2.specialEvent = true;

            for (int i = 0; i < result2.characters.Length; i++) result2.characters[i].fixOpinionArraySize(result2.characters.Length);

            _deads = deathCount;

            result2.FixArrays();

            return result2;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) //  
        {
            info.AddValue("incidentText", incidentText);
            info.AddValue("id", id);
            info.AddValue("characterCount", characterCount);
            info.AddValue("killers", killers);
            info.AddValue("killeds", killeds);

            oC = new intArray[opinionChanges.Length];
            for (int i = 0; i < oC.Length; i++) oC[i] = new intArray(opinionChanges[i]);
            oU = new intArray[opinionUpperBounds.Length];
            for (int i = 0; i < oU.Length; i++) oU[i] = new intArray(opinionUpperBounds[i]);
            oL = new intArray[opinionLowerBounds.Length];
            for (int i = 0; i < oL.Length; i++) oL[i] = new intArray(opinionLowerBounds[i]);

            sC = new floatArray[statChanges.Length];
            for (int i = 0; i < sC.Length; i++) sC[i] = new floatArray(statChanges[i]);
            sU = new floatArray[statUpperBounds.Length];
            for (int i = 0; i < sU.Length; i++) sU[i] = new floatArray(statUpperBounds[i]);
            sL = new floatArray[statLowerBounds.Length];
            for (int i = 0; i < sL.Length; i++) sL[i] = new floatArray(statLowerBounds[i]);

            info.AddValue("oC", oC);
            info.AddValue("sC", sC);
            info.AddValue("oU", oU);
            info.AddValue("oL", oL);
            info.AddValue("sU", sU);
            info.AddValue("sL", sL);

            info.AddValue("wieght", wieght);
            info.AddValue("specialEvent", specialEvent);
            info.AddValue("absurd", absurd);
            info.AddValue("resurrected", resurrected);
            info.AddValue("zombies", zombies);
            info.AddValue("clones", clones);
            info.AddValue("chimps", chimps);
            info.AddValue("bees", bees);
            info.AddValue("rats", rats);
        }

        public SpecialIncident(SerializationInfo info, StreamingContext context)
        {
            incidentText = (string)info.GetValue("incidentText", typeof(string));
            id = (int)info.GetValue("id", typeof(int));
            characterCount = (int)info.GetValue("characterCount", typeof(int));
            killers = (int[])info.GetValue("killers", typeof(int[]));
            killeds = (int[])info.GetValue("killeds", typeof(int[]));

            oC = (intArray[])info.GetValue("oC", typeof(intArray[]));
            sC = (floatArray[])info.GetValue("sC", typeof(floatArray[]));
            sL = (floatArray[])info.GetValue("sL", typeof(floatArray[]));
            sU = (floatArray[])info.GetValue("sU", typeof(floatArray[]));
            oL = (intArray[])info.GetValue("oL", typeof(intArray[]));
            oU = (intArray[])info.GetValue("oU", typeof(intArray[]));

            for (int i = 0; i < oC.Length; i++) opinionChanges[i] = oC[i].innerArray;
            for (int i = 0; i < oU.Length; i++) opinionUpperBounds[i] = oU[i].innerArray;
            for (int i = 0; i < oL.Length; i++) opinionLowerBounds[i] = oL[i].innerArray;

            for (int i = 0; i < sC.Length; i++) statChanges[i] = sC[i].innerArray;
            for (int i = 0; i < sU.Length; i++) statUpperBounds[i] = sU[i].innerArray;
            for (int i = 0; i < sL.Length; i++) statLowerBounds[i] = sL[i].innerArray;

            wieght = (int)info.GetValue("wieght", typeof(int));
            specialEvent = (bool)info.GetValue("specialEvent", typeof(bool));
            absurd = (bool)info.GetValue("absurd", typeof(bool));
            resurrected = (int[])info.GetValue("resurrected", typeof(int[]));
            zombies = (int[])info.GetValue("zombies", typeof(int[]));
            clones = (int[])info.GetValue("clones", typeof(int[]));
            chimps = (int)info.GetValue("chimps", typeof(int));
            bees = (int)info.GetValue("bees", typeof(int));
            rats = (int)info.GetValue("rats", typeof(int));
        }

    }

    [Serializable , XmlRoot("intArray")]
    public class intArray : ISerializable    //used to get around the jagged array restrictions with XML
    {
        [XmlArray("innerArray")] [XmlArrayItem("arrayMember")] public int[] innerArray { get; set; }

        public intArray() { }

        public intArray(int[] _array)
        {
            innerArray = _array;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("innerArray", innerArray);
        }

        public intArray(SerializationInfo info, StreamingContext context)
        {
            innerArray = (int[])info.GetValue("innerArray", typeof(int[]));
        }
    }
    [Serializable , XmlRoot("floatArray")]
    public class floatArray : ISerializable    //used to get around the jagged array restrictions with XML
    {
        [XmlArray("innerArray")] [XmlArrayItem("arrayMember")] public float[] innerArray { get; set; }

        public floatArray() { }

        public floatArray(float[] _array)
        {
            innerArray = _array;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("innerArray", innerArray);
        }

        public floatArray(SerializationInfo info, StreamingContext context)
        {
            innerArray = (float[])info.GetValue("innerArray", typeof(float[]));
        }
    }

    [Serializable, XmlRoot("eventList")]
    public class eventList : ISerializable    //used to get around the List of Lists restrictions with XML
    {
        [XmlArray("innerList")] [XmlArrayItem("listMember")] public List<CharacterIncident> innerList { get; set; }
        [XmlElement("nameSpace")] public string nameSpace = "";

        public eventList() { }

        public eventList(List<CharacterIncident> _list)
        {
            innerList = _list;
            if (_list.Count > 0) nameSpace = _list.ElementAt(0).eventSpace;
        }

        public void updateSpace ()
        {
            if (innerList.Count > 0) nameSpace = innerList.ElementAt(0).eventSpace;
        }

        public static explicit operator List<CharacterIncident>(eventList m)
        {
            return m.innerList;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("innerList", innerList);
        }

        public eventList(SerializationInfo info, StreamingContext context)
        {
            innerList = (List<CharacterIncident>)info.GetValue("innerList", typeof(List<CharacterIncident>));
            if (innerList.Count > 0) nameSpace = innerList.ElementAt(0).eventSpace;
        }
    }

}
