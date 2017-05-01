using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule.Lex
{
    class LexTime : ALex
    {
        public LexTime(Parser parser) : base(parser)
        {
        }

        public override void Initialize()
        {
            Split = false;
            LowerCase = true;

            AddToLexem("_what_time_is_it_", new string[] {
                "it be what hour",
                "what hour be it"
            });

            AddToLexem("_what_date_is_it_", new string[] {
                "it be what day",
                "what day be it",
                "what day be we",
                "what day we be",
                "what date be we",
                "what date we be",
                "we be what day",
                "we be what date"
            });
        }
    }
}
