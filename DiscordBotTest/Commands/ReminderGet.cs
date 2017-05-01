using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using DiscordBotTest.CoreModule;
using DiscordBotTest.ParserModule;

namespace DiscordBotTest.Commands
{
    class ReminderGet : ACommand
    {
        public ReminderGet(BotCore core) : base(core)
        {
        }

        public override bool VerifyParserResult(ParserResult r)
        {
            return (r.Meaning == GlobalMeaning.REMINDER && r.Items["action"].Equals("get"));
        }

        public override Task<Message> Execute(ParserResult r)
        {
            var c = core.ReminderDB.Find(x => x.Key.Equals(r.Items["key"]));
            if (c.Count() == 1)
                return r.Event.Channel.SendMessage(":mega: " + c.First().Key + " : " + c.First().Content);
            else
                return r.Event.Channel.SendMessage(":thinking: ?");
        }
    }
}
