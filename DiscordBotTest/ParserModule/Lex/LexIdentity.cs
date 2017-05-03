using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule.Lex
{
    class LexIdentity : ALex
    {
        public LexIdentity(Parser parser) : base(parser)
        {
        }

        public override void Initialize()
        {
            Split = false;
            LowerCase = true;

			AddToLexem("_who_are_you_", new string[] { "who be you" });
			AddToLexem("_change_name_to_", new string[] { "_botname_ change your name to", "_botname_ change of name to" });
        }
    }
}
