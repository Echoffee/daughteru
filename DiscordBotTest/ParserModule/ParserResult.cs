using Discord;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DiscordBotTest.ParserModule
{
    public class ParserResult
    {
        public GlobalMeaning Meaning { get; set; }

        public GlobalTopic Topic { get; set; }

        public Dictionary<String, String> Items { get; set; }

        public MessageEventArgs Event { get; set; }

        public ParserResult()
        {
            this.Items = new Dictionary<string, string>();
        }
    }

    public enum GlobalMeaning
    {
        HELP,
        REMINDER,
        META,
        QUESTION,
    }

    public enum GlobalTopic
    {
        IDENTITY,
        DATE,
    }
}