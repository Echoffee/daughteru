using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using DiscordBotTest.CoreModule;
using DiscordBotTest.ParserModule;
using DiscordBotTest.CoreModule.Models;

namespace DiscordBotTest.Commands
{
    class ReminderAdd : ACommand
    {
        public ReminderAdd(BotCore core) : base(core)
        {
        }

        public override bool VerifyParserResult(ParserResult r)
        {
            return (r.Meaning == GlobalMeaning.REMINDER && r.Items["action"].Equals("add"));
        }

        public override Task<Message> Execute(ParserResult r)
        {
            var c = core.ReminderDB.Find(x => x.Key.Equals(r.Items["key"]));
            Reminder n;
            if (c.Count() == 1)
                n = c.First();
            else
                n = new Reminder();

            n.Author = r.Event.Message.User.Id.ToString();
            n.CreationDate = DateTime.UtcNow;
            n.Content = r.Items["content"];
            n.Key = r.Items["key"];
            core.ReminderDB.Upsert(n);

            return r.Event.Channel.SendMessage("Ok :ok_hand:");
        }
    }
}
