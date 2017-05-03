using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule
{
    public class ParserItem
    {
        public string Value { get; set; }

        public string OriginalValue { get; set; }

        public bool IsParsed { get; set; }
    }
}
