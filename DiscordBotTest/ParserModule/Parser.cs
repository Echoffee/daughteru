using DiscordBotTest.CoreModule;
using DiscordBotTest.ParserModule.Lex;
using DiscordBotTest.ParserModule.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule
{
    public class Parser
    {
        public ALex Atom { get; set; }

        public List<ALex> LexList { get; set; }

        public Syna Syna { get; set; }

        public BotCore Core { get; set; }

        public Parser(BotCore core)
        {
            Core = core;

            LexList = new List<ALex>();

            Atom = (new LexAtom(this));
            LexList.Add(new LexIdentity(this));
            LexList.Add(new LexMeta(this));
            LexList.Add(new LexReminder(this));
            LexList.Add(new LexTime(this));

            this.Syna = new Syna();
        }

        public ParserResult ParseString(String s)
        {
            s = Atom.Parse(s);
            foreach (var l in LexList)
                s = l.Parse(s);

            var result = Syna.Parse(s);
            return result;
        }
    }
}
