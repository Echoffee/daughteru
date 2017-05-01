using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBotTest.CoreModule;
using DiscordBotTest.ParserModule;
using DiscordBotTest.CoreModule.Models;
using Discord;

namespace DiscordBotTest.Commands
{
    class WhoAmI : ACommand
    {
        public WhoAmI(BotCore core) : base(core)
        {
        }

        public override Task<Message> Execute(ParserResult r)
        {
            var e = r.Event;
            return e.Channel.SendMessage(core.MetaDB.Find(x => x.Key.Equals("bot name")).First().Value);
        }

        public bool Initialize()
        {
            if (core.MetaDB.Find(x => x.Key.Equals("bot name")).Count() == 0)
            {
                var n = new KeyValue()
                {
                    Key = "bot name",
                    Value = "Nameless"
                };

                core.MetaDB.Insert(n);
            }

            return true;
        }

        public override bool VerifyParserResult(ParserResult r)
        {
            if (r.Meaning == GlobalMeaning.QUESTION && r.Topic == GlobalTopic.IDENTITY)
                if (r.Items["target"].Equals("bot"))
                    return true;

            return false;
        }
    }
}
