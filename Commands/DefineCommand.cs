using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class DefineCommand : Command
    {
        private static readonly string URL = @"https://api.dictionaryapi.dev/api/v2/entries/en_US/";
        private static readonly char[] VOWELS = { 'a', 'e', 'i', 'o', 'u' };
        private static string BuildURL(string inputWord)
        {
            return URL + inputWord;
        }
        public DefineCommand()
        {
            name = "Define";
            desc = "Define a word in the dictionary. Instantly wins arguments!";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            string url = BuildURL(arguments);
            JToken json;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    string contents = wc.DownloadString(url);
                    json = JArray.Parse(contents)[0];
                }
            } catch(Exception)
            {
                System.Windows.Forms.MessageBox.Show("Word not found! Make sure you're spelling it right.", "TextMod");
                return null;
            }
            try
            {
                string word = json.Value<string>("word");
                JArray partsOfSpeech = json.Value<JArray>("meanings");
                string[] finalParts = new string[partsOfSpeech == null ? 0 : partsOfSpeech.Count];
                for (int i = 0; i < partsOfSpeech.Count; i++)
                {
                    JToken pos = partsOfSpeech[i];
                    string partOfSpeech = pos.Value<string>("partOfSpeech");
                    JArray definitions = pos.Value<JArray>("definitions");
                    string[] defs = new string[definitions == null ? 0 : definitions.Count];
                    for (int x = 0; x < definitions.Count; x++)
                    {
                        JToken definition = definitions[x];
                        defs[x] = "> " + (x + 1).ToString() + ". " + definition.Value<string>("definition");
                    }
                    string fullDefs = string.Join("\n", defs);
                    string aOrAn = VOWELS.Contains(char.ToLower(partOfSpeech[0])) ? "an" : "a";
                    finalParts[i] = "**As " + aOrAn + " " + partOfSpeech + ":**\n" + fullDefs;
                }

                string full = string.Join("\n", finalParts);
                full = "◄▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬►\nDefinition(s) of " +
                    word + ":\n\n" + full + "\n◄▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬►";
                return full;
            } catch(Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("Something went wrong trying to get that definition...", "TextMod");
                System.Diagnostics.Debug.WriteLine(exc.ToString());
                return null;
            }
        }
    }
}