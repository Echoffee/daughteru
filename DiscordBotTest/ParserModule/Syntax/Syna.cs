using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule.Syntax
{
    public class Syna
    {
        public ParserResult Parse(string str)
        {
            var result = new ParserResult();

            if (str.Contains("_who_are_you_"))
            {
                result.Meaning = GlobalMeaning.QUESTION;
                result.Topic = GlobalTopic.IDENTITY;
                result.Items.Add("target", "bot");
            }

            if (str.Contains("_change_name_to_"))
            {
                result.Meaning = GlobalMeaning.META;
                result.Topic = GlobalTopic.IDENTITY;
                result.Items.Add("target", "bot");
                var a = str.Split(' ');
                var i = Array.IndexOf(a, "_change_name_to_") + 1;
                result.Items.Add("new name", a[i]);
            }

            if (str.Contains("_what_time_is_it_"))
            {
                result.Meaning = GlobalMeaning.QUESTION;
                result.Topic = GlobalTopic.DATE;
                result.Items.Add("scope", "hour");
            }

            if (str.Contains("_what_date_is_it_"))
            {
                result.Meaning = GlobalMeaning.QUESTION;
                result.Topic = GlobalTopic.DATE;
                result.Items.Add("scope", "date");
            }

            if (str.Contains("_add_reminder_"))
            {
                result.Meaning = GlobalMeaning.REMINDER;
                result.Items.Add("action", "add");
                result.Items.Add("key", str.Split(' ')[Array.IndexOf(str.Split(' '), str.Split(' ').Where(x => x.Equals("_add_reminder_")).First()) + 1]);
                result.Items.Add("content", str.Split(new string[] { "_add_reminder_ " + result.Items["key"] }, StringSplitOptions.RemoveEmptyEntries).Last());
            }

            if (str.Contains("_get_reminder_"))
            {
                result.Meaning = GlobalMeaning.REMINDER;
                result.Items.Add("action", "get");
                result.Items.Add("key", str.Split(' ')[Array.IndexOf(str.Split(' '), str.Split(' ').Where(x => x.Equals("_get_reminder_")).First()) + 1]);
            }

                return result;
        }
    }
}
