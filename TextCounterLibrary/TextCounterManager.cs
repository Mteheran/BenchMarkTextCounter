using System.Collections.Generic;
using System.IO;

namespace TextCounterLibrary
{
    public class TextCounterManager: ITextCounterManager
    {
       public int ProcessFile(string FileRoot)
        {
            int NumberOfWords = 0, NumberofWordRepeted = 0;

            StreamReader sr = new StreamReader(FileRoot);

            var fieInfo = sr.ReadToEnd();

            sr.Close();

            var fileVector = fieInfo.Split(' ');

            List<string> validWords = new List<string>();

            foreach (var item in fileVector)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    NumberOfWords++;

                    validWords.Add(item);
                }                
            }

            List<string> repetedWords = new List<string>();

            for (int i = 0; i < validWords.Count; i++)
            {
                for (int  j = i+1; j < validWords.Count; j++)
                {
                    if (validWords[i].ToLower() == validWords[j].ToLower() && !repetedWords.Contains(validWords[j]))
                    {
                        NumberofWordRepeted++;
                    }
                }
            }

            return NumberofWordRepeted;
        }
    }
}
