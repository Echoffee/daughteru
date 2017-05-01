using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule.Lex
{
    class LexReminder : ALex
    {
        public LexReminder(Parser parser) : base(parser)
        {
        }

        public override void Initialize()
        {
            Split = false;
            LowerCase = true;

            AddToLexem("_add_reminder_", new string[] { "_botname_ recall" });
            AddToLexem("_get_reminder_", new string[] { "_botname_ 📣" });
        }
    }
}
