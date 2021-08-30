using DiscordRPC;
using DiscordRPC.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TextMod_2.Variables;

namespace TextMod_2.Core
{
    /// <summary>
    /// Holds data about the custom Discord Rich Presence
    /// </summary>
    public class RichPresenceProfile : IDisposable
    {
        Timer updateTimer;

        public static List<RichPresenceVariable> VARIABLES;
        public static Regex VARIABLE_REGEX = new Regex("{(\\w+)(:\\s*([^\\n\\r}]+))?}");

        public static string SetVariables(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            MatchCollection _matches = VARIABLE_REGEX.Matches(input);
            Match[] matches = (
                from Match m in _matches
                orderby m.Index descending
                select m).ToArray();

            if (matches.Length < 1)
                return input;

            for(int i = 0; i < matches.Length; i++)
            {
                Match variableMatch = matches[i];
                int index = variableMatch.Index;
                int len = variableMatch.Length;
                input = input.Remove(index, len);

                var groups = variableMatch.Groups;
                string variableName = groups[1].Value;
                string variableArg = groups[3].Success ? groups[3].Value : null;

                foreach(RichPresenceVariable test in VARIABLES)
                {
                    if(test.name.ToLower().Equals(variableName.ToLower()))
                    {
                        string output = test.GetString(variableArg);
                        if (output == null)
                            break;
                        input = input.Insert(index, output);
                        break;
                    }
                }
            }

            return input;
        }
        public static string Limit(string input, int limit)
        {
            if (input == null)
                return null;
            if (input.Length < limit)
                return input;
            return input.Substring(0, limit);
        }

        void UpdatePresence(object state)
        {
            RichPresenceProfile @this = state as RichPresenceProfile;
            if (@this.clientReady)
            {
                RichPresence copy = new RichPresence();
                int csize = sizeof(char);
                copy.Details = Limit(SetVariables(@this.presence.Details), 128/csize);
                copy.State = Limit(SetVariables(@this.presence.State), 128/csize);
                copy.Assets = @this.presence.Assets;
                copy.Buttons = @this.presence.Buttons;
                @this.client.SetPresence(copy);
            }
        }
        public RichPresenceProfile()
        {
            presenceEnabled = false;
            clientReady = false;
            presence = new RichPresence()
            {
                Assets = new Assets(),
                Details = "TextMod 2",
                State = "Custom Status"
            };
            client = null;
            updateTimer = new Timer(UpdatePresence, this, 2000, 2000);

            VARIABLES = new List<RichPresenceVariable>();
        }
        public void LoadVariables()
        {
            Assembly current = Assembly.GetEntryAssembly();
            Type type = typeof(RichPresenceVariable);
            Type[] all = current.GetTypes();
            Type[] allVariableTypes = all
                .Where(t => t.IsSubclassOf(type) && !t.IsAbstract)
                .ToArray();
            
            foreach (Type variableType in allVariableTypes)
            {
                RichPresenceVariable variable = (RichPresenceVariable)
                    Activator.CreateInstance(variableType);
                VARIABLES.Add(variable);
            }
            Debug.WriteLine("Located and instanced {0} variables.",
                allVariableTypes.Length);
        }

        public bool clientReady { get; private set; }
        public DiscordRpcClient client { get; private set; }
        public RichPresence presence { get; private set; }
        public bool presenceEnabled { get; private set; }
        public int buttonCount
        {
            get
            {
                if (presence == null)
                    return 0;
                if (presence.Buttons == null)
                    return 0;
                return presence.Buttons.Length;
            }
        }

        public static readonly Regex CID_REGEX = new Regex("^\\d{18}$");
        public static bool IsValidClientID(string input)
        {
            return CID_REGEX.IsMatch(input);
        }

        public delegate void ClientBoop();
        public event ClientBoop OnClientReady;
        //public event ClientBoop OnClientFailed;

        public string clientID = "621341181925654545"; // default TextMod

        public void DisablePresence()
        {
            if (client != null)
            {
                client.ClearPresence();
                client.OnReady -= RPC_Ready;
                client.Dispose();
            }
            client = null;
            clientReady = false;
            presenceEnabled = false;
        }
        public void EnablePresence(string clientID)
        {
            this.clientID = clientID;
            clientReady = false;
            if (client != null)
            {
                if (!client.IsDisposed)
                {
                    client.OnReady -= RPC_Ready;
                    client.Dispose();
                }
                client = null;
            }
            presenceEnabled = true;
            client = new DiscordRpcClient(clientID);
            client.OnReady += RPC_Ready;
            client.Initialize();
        }
        private void RPC_Ready(object sender, ReadyMessage args)
        {
            clientReady = true;
            client.SetPresence(presence);
            OnClientReady?.Invoke();
        }
        
        public void UpdateTopText(string topText)
        {
            if (string.IsNullOrWhiteSpace(topText))
                topText = "";
            presence.Details = topText;
        }
        public void UpdateBottomText(string bottomText)
        {
            if (string.IsNullOrWhiteSpace(bottomText))
                bottomText = "";
            presence.State = bottomText;
        }
        public void UpdateImageKey(ImageKey image, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                key = "";

            Assets assets = presence.Assets;
            int csize = sizeof(char);
            key = Limit(key, 32 / csize);

            if (image == ImageKey.LARGE)
                assets.LargeImageKey = key;
            else
                assets.SmallImageKey = key;

            presence.Assets = assets;
        }
        public void UpdateImageText(ImageKey image, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                text = "";

            Assets assets = presence.Assets;
            int csize = sizeof(char);
            text = Limit(text, 128 / csize);

            if (image == ImageKey.LARGE)
                assets.LargeImageText = text;
            else
                assets.SmallImageText = text;

            presence.Assets = assets;
        }
        public void SetButtons(params Button[] buttons)
        {
            presence.Buttons = buttons;
        }

        public string GetFileContents()
        {
            int i = 8;
            int len = i + (presence.Buttons == null ? 0 : presence.Buttons.Length) * 2;
            string[] lines = new string[len];
            lines[0] = presenceEnabled.ToString();
            lines[1] = clientID.Replace('\n', '_');
            lines[2] = (presence.Details ?? "").Replace('\n', '_');
            lines[3] = (presence.State ?? "").Replace('\n', '_');
            if (presence.Assets != null)
            {
                Assets a = presence.Assets;
                lines[4] = (a.LargeImageKey ?? "").Replace('\n', '_');
                lines[5] = (a.LargeImageText ?? "").Replace('\n', '_');
                lines[6] = (a.SmallImageKey ?? "").Replace('\n', '_');
                lines[7] = (a.SmallImageText ?? "").Replace('\n', '_');
            } else
            {
                lines[4] = "";
                lines[5] = "";
                lines[6] = "";
                lines[7] = "";
            }

            if(presence.Buttons != null)
                foreach (Button b in presence.Buttons)
                {
                    lines[i++] = b.Url.Replace('\n', '_');
                    lines[i++] = b.Label.Replace('\n', '_');
                }

            return string.Join("\n", lines);
        }
        public void ParseFileContents(string file)
        {
            string[] lines = file.Split('\n');
            if(lines.Length < 8 || lines.Length % 2 == 1)
            {
                System.Windows.Forms.MessageBox.Show("Rich Presence save file corrupted.");
                return;
            }

            presenceEnabled = lines[0].Equals("True");
            clientID = lines[1];
            UpdateTopText(lines[2]);
            UpdateBottomText(lines[3]);
            UpdateImageKey(ImageKey.LARGE, lines[4]);
            UpdateImageText(ImageKey.LARGE, lines[5]);
            UpdateImageKey(ImageKey.SMALL, lines[6]);
            UpdateImageText(ImageKey.SMALL, lines[7]);

            int buttons = (lines.Length - 8) / 2;
            if(buttons > 0)
            {
                Button[] array = new Button[buttons];
                int read = 8;
                for(int i = 0; i < buttons; i++)
                {
                    array[i] = new Button();
                    array[i].Url = lines[read++];
                    array[i].Label = lines[read++];
                }
                SetButtons(array);
            }

            if(presenceEnabled)
                EnablePresence(clientID);
        }
        public void Dispose()
        {
            client?.Dispose();
            updateTimer?.Dispose();
        }
    }
    /// <summary>
    /// A type of image in Rich Presence.
    /// </summary>
    public enum ImageKey { LARGE, SMALL }
}