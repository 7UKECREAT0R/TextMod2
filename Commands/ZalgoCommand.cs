using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class ZalgoCommand : Command
    {
        private static readonly string zalgoSample = "a͕̯̻̰͚͓̱̋̅̀̀̓̅͊̓͐b̵͔̭̙̥͙̤̲̜̥́̈͗̇͑̐̎́̔̈́c̗̰͙̦̔̀̂̍̌̋͘͢͢ď̡̰͚̙̬̼̞͍͒̂̉͂̊̎̅͝͝ȇ̷̢̳̙̟̼͖̜̙̔̿̆̈̒̅͋̑̐͜f̜̣͙̩̬͚̫̞̮͊̎̊́͒̌̾͟͠͠g̷̢̨͕̬̺̟̘̥͔̥͌͐̿̏͠h̢͇̪̦̦̩̻̣̍̅͌̌̿́̕i͔̯̳̝͔̮͙̗͈͌̓̾̏͐͘̚͢j̡̧͙̗͓͈̔̇̍́̔̕k̵̢̗̰͙̖͇̙̫̾͊̋̊͋̄̕͡l̷̺̺̱̩̙̟̞̥̪̏̋̑̆̀̑̎́̌̚ͅm̡̧̢̲̖̯̝̭̤͐͆̾̆͞͡n̲̥͕̙̩̟̺̒͛͒͒͆̚͢ơ̛̬̠͉̜͕͊̂͛̾̋̎͒͘p̵̨̜̫͚̰̌̃͗̇̇͘͜͢͜͝q̸̧̬̺̝̹͉̮̮̫͐̇̀̂̈͢ř̨̯̱̰͍̙̝͐̑̓̏̌͒̉̑ş̴̢̱̫͓͈͔͂͂̔̔̓̓̏͂̚͡ͅt̢̗͈̮̣͚̤̖̂͒̏͑͊̄̅̾͡͠ų̵̨͇̻̮̤͆̑̌͘̕͞v̡͙̰̞̲͙̜̖̍̐́̀͑͘͜͠w̶̧̺̦̣͈̝̆̆̀͛̄x̸̳͍͇̞̬͉̗̞̖͒̃̈́̀̒͑ͅy̧̧̖͓̾́͘͜͠͠ẕ̶̭͚̥͔̥̣̖͊̉̀̐̀̓̐͜͝͝͡ͅȂ̸̧̝̬̱̱̮̱͇̭̿̍̊͗͐̃̚͝͞ͅB̡̛͓͈͔̪̦̜̭̤́̄͛̆̂̌͢Ċ̨̖͔͎̦̥́͛͂̊̓̚͠Ḏ̶͈̲̪̓͒̽̾̎͢͜͞E̢̖͔̞͇͌̉̇́͋̔̒́̾͘F̴̛̖̯̻̝̃̈́͑̄̉̓̉͢͟͢Ĝ̵̰̥̺̱͙͚̞̰̟̊̑̊͡H̨̪̟̥̺̰̪͚̟̗̾̿̀̈́͛͐̎͝I̴̧͉̳͎̟̱̻̗̒̑̈́̎̀͛͝ͅJ̠̤͖͎͕̦͗͌̉̐͜͠K̖̳̮͙͚̻̰͔̈́̊́͛͛̾̓͂́͢L̷̙̮̜͈̤̭͎͎̳̍͛̊͋̂̀M̶̖̲̰̫͙̳̳̙̥̿̈́͛̈̈̐͜N̫͉̰̣͔̤͎̆̑̒̃̾̀͠͞ͅƠ̸̢̪͔̱̥͒̿̉̀̉̐̕͜͞P̴̼̻̲̗̯̲̋̔̑̓͡͡͡Q̵̡̝̦̗̼͙͖̫̰͗̑͋̌̒̽́̈R̷̛̞̱̻̫̮̭̆̊̽̂͛͑͢Ş̨̪͙̣̩̤̻͛̀̾̄̕T̙͈̪̲͔͚̑͑́̇̇̄͘͘͟͝ͅU̖͓͈̰̹̦̠̐͗̀̕͜͝͠V̫͈̗̘̘̦̾̎̃͂̚͠W̡̠̬͉͕̮͑̎̑͐̿͐͒͑̚̕X̸̨͈̪̞̮̟͈͕͛̽̈́̓̊̄Y̨̧̛̝̝̟͍̪̏̊̊͌͢͠͞Z̷̧̛̩̯̜̤̗̀̌͆̉̎͢͢͞1̨͎͖̗̪̜̉̀̂͑̾̚͜͞͞2̸̗͚̻̩̰̹̟̫̽̔͌̃̕͜͠3̷͍̬̗͕̦̺̺͉̊̃̍͂́̑̚͟͞4̧̢̣̩͖̎͗̑̀́̎̄͊̒͟5̸̭͇͚̫̝̖̏͗̒̊͠6̷̢̢̖͇͕̹̮͕̈́͆͆́̋̿̚͝͡7̸̼̤̲̰̠͖̄̀͊͆͞͝8͎̱̯̹͔͖̰̣͊͌̓̋̚͟͠͠͠ͅ9̵̖͇̩̬̺̪͈̖̪͒̿̾̉̾͛̈̂̀̕0̷̛̫̳͔̲͂̿͗̐́̇̚͟";
        private static readonly char[] alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        string[] zalgo;

        public ZalgoCommand()
        {
            name = "Zalgo";
            desc = "Adds glitches your text.";
            category = CommandCategory.MAIN;

            zalgo = zalgoSample.Split(alphabet, StringSplitOptions.RemoveEmptyEntries);
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;
            return TextModCore.MapAppendChars(arguments, alphabet, zalgo);
        }
    }
}
