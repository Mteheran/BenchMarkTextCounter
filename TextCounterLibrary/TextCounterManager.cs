using System.Collections.Generic;
using System.IO;

namespace TextCounterLibrary
{
    public class TextCounterManager: ITextCounterManager
    {
       public int ProcessFile(string FileRoot)
        {
            if (string.IsNullOrEmpty(FileRoot)) return 0;

            int NumberofWordRepeted = 0;

            StreamReader sr = new StreamReader(FileRoot);

            var fieInfo = sr.ReadToEnd();

            sr.Close();

            var fileVector = fieInfo.Split(' ');

            List<string> validWords = new List<string>();

            foreach (var item in fileVector)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    validWords.Add(item);
                }                
            }

             Dictionary<string,int> repetedWords = new Dictionary<string,int>();

            for (int i = 0; i < validWords.Count; i++)
            {
                for (int  j = i+1; j < validWords.Count; j++)
                {
                    if (validWords[i].ToLower() == validWords[j].ToLower() && !repetedWords.ContainsKey(validWords[j].ToLower()))
                    {
                        NumberofWordRepeted++;
                        repetedWords.Add(validWords[j].ToLower(), NumberofWordRepeted);
                    }
                }
            }

            return NumberofWordRepeted;
        }

    }
}
