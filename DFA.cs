using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyDFA
{
    public class DFA
    {
        public State[] states { get; set; }
        public Letter[] letters { get; set; }
        /// <summary>
        /// Matrix of m rows and n columns
        /// where m is number of states and n is cardinality
        ///  of alphabet
        ///  transitions[i][j] is id of a state (index in array states)
        ///   that is result of applying of letter[j] to  states[i]
        ///  That is Px=Q, where P= states[i], x=letters[j],
        ///    Q=transitions[i][j]
        /// </summary>
        public int[][] transitions { get; set; }
        /// <summary>
        /// his array contains all possible pairs of states
        /// as one linear array
        /// </summary>
        public Pair[] pairsDFA { get; set; }
        /// <summary>
        /// This array contains all possible pairs of states
        ///  in such way that pairsMatrix[i][j]=[states[i].states[j]]
        /// </summary>
        public Pair[][] pairsMatrix { get; set; }

        
        public void initializeByFormat1(List<string> lstLines)
        {
            string[] sep1 = new string[] { " " };
            try
            {
                List<State> lstStates = new List<State>();
                List<int[]> rows = new List<int[]>();
                
                int numLetters = 0; //also number of columns in transitions

                bool isFirstLine = true;
                //build states
                foreach (string line in lstLines)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }
                        
                    string[] arr = line.Split(sep1, StringSplitOptions.None);
                    State state = new State(int.Parse(arr[0]), arr[0]);
                    lstStates.Add(state);
                }
                states = lstStates.ToArray();
                foreach (string line in lstLines)
                {                    
                    string[] arr = line.Split(sep1, StringSplitOptions.None);
                    if (line.IndexOf("#") >= 0)
                    {
                        //define  number of letters
                        //example: # a b
                        numLetters = arr.Length-1;
                        letters = new Letter[numLetters];
                        for (int j = 1; j <= numLetters; j++)
                        {
                            letters[j - 1] = new Letter(j-1, arr[j]);
                        }
                        continue;
                    }
                    //define a row of transitions matrix
                    int[] row = new int[numLetters];
                   
                    for (int j = 1; j <= numLetters; j++)
                    {
                        row[j - 1] = int.Parse(arr[j]);
                        
                    }
                    rows.Add(row);
                    
                }
               
                int m = rows.Count;
                transitions = rows.ToArray();
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int initializeByFormat2(List<string> lstLines)
        {
            int errCode = 0;
            string[] sep1 = new string[] { " " };
            try
            {
                string[] alphabet = new string[] {"a","b","c","d",
                "e","f","g","h"};

                List<State> lstStates = new List<State>();
               

                int numLetters = 0; //also number of columns in transitions

                bool isFirstLine = true;
                Dictionary<int, State> dictStates =
                    new Dictionary<int, State>();
                Dictionary<int, Letter> dictLetters =
                    new Dictionary<int, Letter>();
                foreach (string line in lstLines)
                {
                    string[] arr = line.Split(sep1, StringSplitOptions.None);
                    if (isFirstLine)
                    {
                        isFirstLine = false;                        
                        int statesCount = int.Parse(arr[0]);
                        int transitionsCount= int.Parse(arr[1]);
                        numLetters = int.Parse(arr[2]);
                        if(numLetters > 8)
                        {
                            errCode = 1;
                            return errCode;
                        }
                        states = new State[statesCount];
                        letters = new Letter[numLetters];
                        transitions = new int[statesCount][];
                        List<int[]> rows = new List<int[]>();
                        for (int i = 0; i < statesCount; i++)
                        {
                            int[] row = new int[numLetters];
                            rows.Add(row);
                        }
                        transitions = rows.ToArray();
                        continue;
                    }
                    //build states
                    int fromStateIndex = int.Parse(arr[0]) - 1;
                    int toStateIndex = int.Parse(arr[1]) - 1;
                    int letterIndex = int.Parse(arr[2]);
                    State state = null;
                    Letter letter = null;
                    if(!dictStates.ContainsKey(fromStateIndex))
                    {
                        state = new State(fromStateIndex, fromStateIndex.ToString());
                        dictStates[fromStateIndex] = state;
                        states[fromStateIndex] = state;
                    }
                    if (!dictStates.ContainsKey(toStateIndex))
                    {
                        state = new State(toStateIndex, toStateIndex.ToString());
                        dictStates[toStateIndex] = state;
                        states[toStateIndex] = state;
                    }
                    if(!dictLetters.ContainsKey(letterIndex))
                    {
                        letter = new Letter(letterIndex, alphabet[letterIndex]);
                        dictLetters[letterIndex] = letter;
                        letters[letterIndex] = letter;
                    }
                    transitions[fromStateIndex][letterIndex] = toStateIndex;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return errCode;
        }
        public void buildPairs()
        {
            List<Pair> lst = new List<Pair>();
            pairsMatrix = new Pair[states.Length][];
            try
            {
                int index = 0;
                for (int i = 0; i < states.Length; i++)
                {
                    Pair[] row = new Pair[states.Length];
                    for (int j = i; j < states.Length; j++)
                    {
                        Pair pair = new Pair();
                        pair.states =
                            new State[2] { states[i], states[j] };
                        pair.index = index;
                        pair.visited = false;
                        lst.Add(pair);
                        row[j] = pair;
                        index++;
                    }
                    pairsMatrix[i] = row;
                }
                pairsDFA = lst.ToArray();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string getResetWord()
        {
            string result = string.Empty;
            try
            {
                int selectedCount = states.Length;
                while (selectedCount>1)
                {
                    List<Letter> lstLetters = Algorithms.FindSingleton(this);
                    lstLetters.Reverse();
                    foreach (Letter letter in lstLetters)
                    {
                        result += letter.name;
                    }
                    selectedCount = 0;
                        for (int i = 0; i < pairsDFA.Length; i++)
                        {
                            pairsDFA[i].visited = false;                           
                        }
                        
                        for (int i = 0; i < states.Length; i++)
                        {
                            if (states[i].selected)
                            {                                
                                State image =
                                    getStateImage(states[i], lstLetters);
                                image.inImage = true;
                            }                        
                        }
                        //count new selected
                        for (int i = 0; i < states.Length; i++)
                        {
                            if (states[i].inImage)
                            {
                                selectedCount++;
                                states[i].inImage = false;
                                states[i].selected = true;
                            }
                            else
                                states[i].selected = false;
                        }
                    
                }//while
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        private State getStateImage(State state, List<Letter>lstLetters)
        {
            State image = null;
            try
            {
                int id = state.id;
                foreach (Letter letter  in lstLetters)
                {
                    id = transitions[id][letter.id];
                }
                image = states[id];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return image;
        }

    }
   public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        /// <summary>
        /// This property is true if this state belongs to current
        /// set of states P. It is true for initial state of automaton
        /// </summary>
        public bool selected { get; set; }
        /// <summary>
        /// This property is true if this state belongs to current
        /// image of P that is P.v for some v.
        /// It is false for initial state of automaton
        /// </summary>
        public bool inImage { get; set; }
        public State(int id, string name)
        {
            this.id = id;
            this.name = name;
            selected = true;
            inImage = false;
        }
    }
    public class Letter
    {
        public int id { get; set; }
        public string name { get; set; }
        public Letter(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    public class Pair
    {
        public State[] states { get; set; }       
        public bool visited { get; set; }
        public int index { get; set; }
        public bool selected()
        {
            return states[0].selected && states[1].selected;
        }

    }
}
