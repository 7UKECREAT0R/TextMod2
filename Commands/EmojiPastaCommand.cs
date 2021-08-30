using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class EmojiPastaCommand : Command
    {
        static readonly string CORPUS_URL = "https://raw.githubusercontent.com/ntratcliff/emojipasta.club/master/corpus.txt";
        static readonly char[] VALIDCHARS = "!1@2#3$4%5^6&7*8(9)0_-+=|\\\"':;?/>.<,qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM ".ToCharArray();

        string corpus;
        Dictionary<string, string> provider;

        public EmojiPastaCommand()
        {
            name = "Emojipasta";
            desc = "Puts the appropriate emojis after certain words.";
            category = CommandCategory.MAIN;

            LoadCorpus();
            TrainFromCorpus();
        }
        void LoadCorpus()
        {
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                corpus = wc.DownloadString(CORPUS_URL);
            }
        }
        void TrainFromCorpus()
        {
            // Get some valid chars to use.

            // Begin processing
            Dictionary<string, string> target = new Dictionary<string, string>();
            string[] words = corpus.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                bool status = true;
                foreach (char c in word.ToCharArray())
                {
                    if (!VALIDCHARS.Contains(c))
                    { status = false; break; }
                }
                if (!status)
                {
                    if (word.Any(c => VALIDCHARS.Contains(c)))
                    {
                        List<char> _actualWord = new List<char>();
                        string rest = "";
                        for (int x = 0; x < word.Length; x++)
                        {
                            if (VALIDCHARS.Contains(word[x]))
                            {
                                _actualWord.Add(word[x]);
                                continue;
                            }
                            else
                            {
                                rest = word.Substring(x);
                                break;
                            }
                        }
                        if (rest.Equals(""))
                        {
                            continue;
                        }
                        if (rest.Any(c => VALIDCHARS.Contains(c)))
                        {
                            try
                            {
                                rest = rest.Substring(0, rest.IndexOfAny(VALIDCHARS));
                            }
                            catch (Exception) { }
                        }
                        string actualWord = new string(_actualWord.ToArray());
                        if (target.ContainsKey(actualWord.ToLower()))
                        {
                            continue;
                        }
                        target.Add(actualWord.ToLower(), rest);
                        continue;
                    }
                }

                try
                {
                    string nextword = words[i + 1];
                    if (nextword.ToCharArray().Any(c => !VALIDCHARS.Contains(c)))
                    {
                        nextword = new string(nextword.ToCharArray().Where(p =>
                            !VALIDCHARS.Contains(p)).ToArray());
                        if (target.ContainsKey(word.ToLower()))
                            continue;
                        target.Add(word.ToLower(), nextword);
                        continue;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            provider = target;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            string[] words = arguments.Split(' ');
            StringBuilder sb = new StringBuilder();
            int i = -1;
            foreach (string word in words)
            {
                i++;
                string s = word.ToLower();
                if (provider.ContainsKey(s))
                {
                    string emoji;
                    provider.TryGetValue(s, out emoji);
                    sb.Append(" " + word + " " + emoji);
                }
                else sb.Append(" " + word);
            }
            try
            {
                sb = sb.Remove(0, 1);
            }
            catch (Exception) { };
            return sb.ToString();
        }
    }
}