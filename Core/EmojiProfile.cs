using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

namespace TextMod_2.Core
{
    /// <summary>
    /// Emoji profile for storing stuff idk
    /// </summary>
    public class EmojiProfile
    {
        List<Emoji> emoji = new List<Emoji>();

        /// <summary>
        /// Create emoji based off of a list of file paths.
        /// </summary>
        /// <param name="files"></param>
        public void CreateEmoji(params string[] files)
        {
            if (files.Length == 0)
                return;
            foreach(string file in files)
            {
                Emoji emoji = new Emoji(file);
                this.emoji.Add(emoji);
            }
        }
        /// <summary>
        /// Set an emoji at a certain index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="modification"></param>
        public void ModifyEmojiAtIndex(int index, Emoji modification)
        {
            if (index < 0 || index > emoji.Count)
                return;
            emoji[index] = modification;
        }
        public void RemoveEmojiAtIndex(int index)
        {
            if (index < 0 || index > emoji.Count)
                return;
            emoji.RemoveAt(index);
        }

        public string[] GetEmojiNames()
        {
            return emoji.Select(e => e.name).ToArray();
        }
        public string[] GetEmojiPaths()
        {
            return emoji.Select(e => e.path).ToArray();
        }
        public Emoji[] GetAllEmoji()
        {
            return emoji.ToArray();
        }

        /// <summary>
        /// Try to fetch an emoji by its name. Case insensitive.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="e"></param>
        /// <returns>True if an emoji is found and the out parameter was assigned a valid value.</returns>
        public bool TryGetEmojiByName(string name, out Emoji? e)
        {
            if (!emoji.Any(test => test.name.ToLower().Equals(name.ToLower())))
            {
                e = null;
                return false;
            }
            e = emoji.First(test => test.name.ToLower().Equals(name.ToLower()));
            return true;
        }
        /// <summary>
        /// Try to fetch an emoji by its path. Case sensitive.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="e"></param>
        /// <returns>True if an emoji is found and the out parameter was assigned a valid value.</returns>
        public bool TryGetEmojiByPath(string path, out Emoji? e)
        {
            if (!emoji.Any(test => test.path.Equals(path)))
            {
                e = null;
                return false;
            }
            e = emoji.First(test => test.path.Equals(path));
            return true;
        }
        /// <summary>
        /// Try to fetch an emoji by its index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        /// <returns>True if the index was valid and the out parameter was assigned a valid value.</returns>
        public bool TryGetEmojiByIndex(int index, out Emoji? e)
        {
            if (index < 0 || index > emoji.Count)
            {
                e = null;
                return false;
            }
            e = emoji[index];
            return true;
        }

        /// <summary>
        /// Load and resize the image for this emoji.
        /// </summary>
        /// <param name="emoji"></param>
        /// <returns>The resized, undisposed image for this emoji. NULL if the file doesn't exist (though you should check that beforehand...)</returns>
        public Bitmap GetEmojiImage(Emoji emoji)
        {
            string path = emoji.path;
            if (!File.Exists(path))
                return null;

            using (Image i = Image.FromFile(path))
            {
                return new Bitmap(i, 42, 42);
            }
        }

        // data
        public string GetFileContents()
        {
            int count = emoji.Count;
            string[] write = new string[count + 3];
            write[0] = "# This file contains all of the emoji that TextMod has registered.";
            write[1] = "# Each entry is formatted as such: <path>|<name>";
            write[2] = "# You can add them here, or add them through the TextMod GUI, which is generally a lot easier.";
            for(int i = 0; i < count; i++)
                write[i + 3] = emoji[i].ToString();
            return string.Join("\n", write);
        }
        public void ParseFileContents(string[] lines)
        {
            foreach(string line in lines)
            {
                if (line[0] == '#')
                    continue;
                if (!line.Contains('|'))
                    continue;
                string[] halves = line.Split('|');
                if (halves.Length < 2)
                    continue;
                string path = halves[0];
                string name = Emoji.FilterCharacters(halves[1]);
                if (string.IsNullOrWhiteSpace(name))
                    continue;
                if (!File.Exists(path))
                    continue;
                emoji.Add(new Emoji(path, name));
            }
        }
    }
    public struct Emoji
    {
        public static readonly char[] ALLOWED_CHARS = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_".ToCharArray();
        public static readonly Regex REGEX = new Regex(":([0-9a-zA-Z_]+):"); // Matches :some_emoji:
        public static string FilterCharacters(string input)
        {
            if (input.All(c => ALLOWED_CHARS.Contains(c)))
                return input;

            char[] characters = input.ToCharArray();
            for(int i = 0; i < characters.Length; i++)
            {
                if (!ALLOWED_CHARS.Contains(characters[i]))
                    characters[i] = '_';
            }
            return new string(characters);
        }


        public string path, name;
        public Emoji(string path)
        {
            this.path = path;
            this.name = FilterCharacters(Path.GetFileNameWithoutExtension(path));
        }
        public Emoji(string path, string name)
        {
            this.path = path;
            this.name = name;
        }
        public override string ToString()
        {
            return path + '|' + name;
        }
    }
}
