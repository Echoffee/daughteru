using DiscordBotTest.ParserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBotTest.CoreModule;
using Discord;

namespace DiscordBotTest.Commands
{
    public abstract class ACommand
    {
        protected BotCore core;

        public ACommand(BotCore core)
        {
            this.core = core;
        }

        public virtual bool VerifyParserResult(ParserResult r)
        {
            return false;
        }

        public abstract Task<Message> Execute(ParserResult r);
    }
}
