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
    class RenameBot : ACommand
    {
        public RenameBot(BotCore core) : base(core)
        {
        }

        public override Task<Message> Execute(ParserResult r)
        {
            var newName = r.Items["new name"];
            var val = core.MetaDB.Find(x => x.Key.Equals("bot name")).First();
            val.Value = newName;
            core.MetaDB.Update(val);
            core.Bot.CurrentUser.Edit(username: newName);

            return r.Event.Channel.SendMessage("Ok, j'ai changé de nom en " + newName);
        }

        public override bool VerifyParserResult(ParserResult r)
        {
            if (r.Meaning == GlobalMeaning.META && r.Topic == GlobalTopic.IDENTITY)
                if (r.Items["target"].Equals("bot"))
                    return true;

            return false;
        }
    }
}
