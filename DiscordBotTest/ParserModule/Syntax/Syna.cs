using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule.Syntax
{
    public class Syna
    {
		IList<ParserItem> Str;

		public ParserResult Parse(string str, string str_orig)
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
                result.Items.Add("key", str_orig.Split(' ')[Array.IndexOf(str.Split(' '), str.Split(' ').Where(x => x.Equals("_add_reminder_")).First()) + 1]);
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

		public ParserResult ParseV2(IList<ParserItem> str)
		{
			Str = str;
			var result = new ParserResult();

			if (WhereContains("_who_are_you_"))
			{
				result.Meaning = GlobalMeaning.QUESTION;
				result.Topic = GlobalTopic.IDENTITY;
				result.Items.Add("target", "bot");
			}

			if (WhereContains("_change_name_to_"))
			{
				result.Meaning = GlobalMeaning.META;
				result.Topic = GlobalTopic.IDENTITY;
				result.Items.Add("target", "bot");
				var i = str.IndexOf(str.Where(x => x.Value.Equals("_change_name_to_")).First()) + 1;
				result.Items.Add("new name", str[i].OriginalValue);
			}

			if (WhereContains("_what_time_is_it_"))
			{
				result.Meaning = GlobalMeaning.QUESTION;
				result.Topic = GlobalTopic.DATE;
				result.Items.Add("scope", "hour");
			}

			if (WhereContains("_what_date_is_it_"))
			{
				result.Meaning = GlobalMeaning.QUESTION;
				result.Topic = GlobalTopic.DATE;
				result.Items.Add("scope", "date");
			}

			if (WhereContains("_add_reminder_"))
			{
				result.Meaning = GlobalMeaning.REMINDER;
				result.Items.Add("action", "add");
				//result.Items.Add("key", str_orig.Split(' ')[Array.IndexOf(str.Split(' '), str.Split(' ').Where(x => x.Equals("_add_reminder_")).First()) + 1]);
				//result.Items.Add("content", str.Split(new string[] { "_add_reminder_ " + result.Items["key"] }, StringSplitOptions.RemoveEmptyEntries).Last());
				result.Items.Add("key", GetSymbols("_add_reminder_"));
				result.Items.Add("content", GetSymbols(result.Items["key"], length: Str.Count));
			}

			if (WhereContains("_get_reminder_"))
			{
				result.Meaning = GlobalMeaning.REMINDER;
				result.Items.Add("action", "get");
				//result.Items.Add("key", str.Split(' ')[Array.IndexOf(str.Split(' '), str.Split(' ').Where(x => x.Equals("_get_reminder_")).First()) + 1]);
				result.Items.Add("key", GetSymbols("_get_reminder_"));
			}

			return result;
		}

		bool WhereContains(string str)
		{
			return Str.Where(x => x.Value.Equals(str)).Count() > 0;
		}

		string GetSymbols(string key, int offset = 1, int length = 1)
		{
			int index = -1;
			var result = new List<string>();
			for (int i = 0; i < Str.Count && index < 0; i++)
				if (Str[i].Value.Equals(key))
					index = i;

			for (int i = 0; i < length && i < Str.Count - offset - index; i++)
				result.Add(Str[index + offset + i].OriginalValue);

			return string.Join(" ", result);
		}

	}
}
