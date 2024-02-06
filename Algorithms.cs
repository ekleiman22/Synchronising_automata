using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDFA
{
    public class Algorithms
    {
      

        /// <summary>
        /// Runs over pairsDFA of dfa as vertices
        /// Begins from a pair where both states are selected
        /// Given a vertex gets images under transitions and saves predessors
        /// If found a vertex such that states[0]=states[1]
        /// then stop,builds list of predessors letters
        /// </summary>
        /// <param name="dfa"></param>
        public static List<Letter> FindSingleton(DFA dfa)
        {
            Dictionary<int, Predessor> dictPred =
                new Dictionary<int, Predessor>();            
            List<Letter> lstResult = new List<Letter>();            
            Pair start = null;
            try
            {
                bool equalImagesFound = false;
                Pair currentPair = null;
                int singletonIndex = -1;
                for (int i = 0; i < dfa.pairsDFA.Length; i++)
                {
                    if (equalImagesFound)
                        break;                    
                    start = dfa.pairsDFA[i];
                    if (start.states[0].id == start.states[1].id)
                        continue;
                    if (!start.selected() || start.visited)
                        continue;
                    start.visited = true;
                    var queue = new Queue<Pair>();
                    queue.Enqueue(start);
                    while (queue.Count > 0 && !equalImagesFound)
                    {
                        var vertex = queue.Dequeue();
                        for (int j = 0; j < dfa.letters.Length; j++)
                        {
                            int letterId = dfa.letters[j].id;
                            int i1 = vertex.states[0].id;
                            int i2 = vertex.states[1].id;
                            //get image of vertex under current letter
                            int j1 = dfa.transitions[i1][letterId];
                            int j2 = dfa.transitions[i2][letterId];

                            if(j1<=j2)
                             currentPair = dfa.pairsMatrix[j1][j2];
                            else
                                currentPair = dfa.pairsMatrix[j2][j1];
                            if (!currentPair.visited)
                            {                               
                                Predessor prd =
                                    new Predessor(dfa.letters[j], vertex.index);
                                dictPred[currentPair.index] = prd;
                                queue.Enqueue(currentPair);
                                currentPair.visited = true;                                
                                if (j1 == j2 && currentPair.selected())
                                {
                                    equalImagesFound = true;
                                    singletonIndex = currentPair.index;
                                    break;
                                }                                
                            }
                        }//cycle by letters
                    }//cycle by queue
                }//cycle by pairs
                //build word by dictPred
                if(singletonIndex>=0)
                {
                    int currentIndex = singletonIndex;
                    while (dictPred.ContainsKey(currentIndex))
                    {
                        lstResult.Add(dictPred[currentIndex].letter);
                        currentIndex = dictPred[currentIndex].predessorIndex;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }           
            return lstResult;
        }

        public static DFA buildChernyAtomaton(int n)
        {
            DFA result = new DFA();           
            try
            {
               
                //generate letters
                result.letters = new Letter[2];
                result.letters[0] = new Letter(0, "a");
                result.letters[1] = new Letter(1, "b");
                //generate states
                result.states = new State[n];
                for (int i = 0; i < n; i++)
                {
                    State state = new State(i, i.ToString());
                    result.states[i] = state;
                }
                //generate transitions
                List<int[]> rows = new List<int[]>();
                for (int i = 0; i < n; i++)
                {
                    int[] row = new int[2];
                    for (int j = 0; j < 2; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                if (i == 0)
                                    row[j] = 1;
                                else
                                    row[j] = i;
                                break;
                            case 1:
                                row[j] = (i+1) % n;
                                break;
                        }
                        
                    }
                    rows.Add(row);                   
                }
                result.transitions = rows.ToArray();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
        public static string compressStringByPowers(string input)
        {
            string result = string.Empty;
            if (input == string.Empty)
                return result;
            char cur = input[0];
            int curCount = 1;
            string seg = cur.ToString();            
            for (int i = 1; i < input.Length; i++)
            {
                if(input[i]==cur)
                {
                    curCount++;
                }
                else
                {
                    if (curCount == 1)
                        result += cur;
                    else
                        result += cur + "^" + curCount;
                    cur = input[i];
                    curCount = 1;
                }
            }
            if (curCount == 1)
                result += cur;
            else
                result += cur + "^" + curCount;
            return result;
        }
    }
    public class Predessor
    {
        public Letter letter { get; set; }        
        public int predessorIndex { get; set; }
        public Predessor(Letter letter,int index)
        {
            this.letter = letter;
            this.predessorIndex = index;
        }
    }

    
}
