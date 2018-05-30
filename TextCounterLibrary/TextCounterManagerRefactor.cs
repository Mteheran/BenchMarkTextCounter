using System.IO;
using System.Linq;

namespace TextCounterLibrary
{
    public class TextCounterManagerRefactor : ITextCounterManager
    {
        public int ProcessFile(string FileRoot)
        {
            if (string.IsNullOrEmpty(FileRoot)) return 0;
            
            StreamReader sr = new StreamReader(FileRoot);

            var fieInfo = sr.ReadToEnd();

            sr.Close();

            var fileVector = fieInfo.Split(' ').Select(word => word.Trim().ToLower()).ToArray();
            
            return  fileVector.GroupBy(item => item)
                    .Where(a => a.Count() > 1)
                    .Select(g => g.Key).Count();
        }
    }
}
