using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule.Lex
{
    class LexMeta : ALex
    {
        public LexMeta(Parser parser) : base(parser)
        {
        }

        public override void Initialize()
        {
            Split = true;
            LowerCase = true;

            AddToLexem("_botname_", new string[] { Parser.Core.MetaDB.Find(x => x.Key.Equals("bot name")).First().Value, "@" + Parser.Core.MetaDB.Find(x => x.Key.Equals("bot name")).First().Value });
        }
    }
}
