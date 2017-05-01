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

            this.Lexem.Add("who be you", "_who_are_you_");
            this.Lexem.Add("change your name to", "_change_name_to_");
        }
    }
}
