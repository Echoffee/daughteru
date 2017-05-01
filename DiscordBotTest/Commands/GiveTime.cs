using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using DiscordBotTest.CoreModule;
using DiscordBotTest.ParserModule;
using DiscordBotTest.Utilities;

namespace DiscordBotTest.Commands
{
    class GiveTime : ACommand
    {
        public GiveTime(BotCore core) : base(core)
        {
        }

        public override bool VerifyParserResult(ParserResult r)
        {
            if (r.Meaning == GlobalMeaning.QUESTION && r.Topic == GlobalTopic.DATE)
                return true;

            return false;
        }

        public override Task<Message> Execute(ParserResult r)
        {
            if (r.Items["scope"] == "hour")
                return r.Event.Channel.SendMessage("Il est " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ".");

            if (r.Items["scope"] == "date")
                return r.Event.Channel.SendMessage("On est le " + DateTools.DayOfWeekFr(DateTime.Now.DayOfWeek) + " " + DateTime.Now.Day + " " + DateTools.MonthNameFr(DateTime.Now.Month) + ".");

            return r.Event.Channel.SendMessage("Je n'ai pas compris la question. :thinking:");
        }
    }
}
