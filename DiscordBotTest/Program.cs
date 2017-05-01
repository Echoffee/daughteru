using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using DiscordBotTest.CoreModule;
using DiscordBotTest.ParserModule;
using DiscordBotTest.Commands;

namespace DiscordBotTest
{
    class Program
    {
        public BotCore Core { get; set; }

        public Parser Parser { get; set; }

        static void Main(string[] args)
        {
            new Program().Start();
        }

        public void Start()
        {
            Core = new BotCore();
            var client = new DiscordClient();
            Core.Initialize(client);
            var token = Core.Token;
            Parser = new Parser(Core);


            client.MessageReceived += Answer;
            client.MessageReceived += Logs.Log;

            client.ExecuteAndWait(async () =>
            {
                await client.Connect(token, TokenType.Bot);
            });
        }

        async public void Echo(Object s, MessageEventArgs e)
        {
            
            if (!e.Message.IsAuthor)
                await e.Channel.SendMessage(e.Message.Text);
        }

        async public void Answer(Object s, MessageEventArgs e)
        {
            if (!e.Message.IsAuthor)
            {
                var r = Parser.ParseString(e.Message.Text);
                r.Event = e;

                foreach (var c in Core.Commands)
                    if (c.VerifyParserResult(r))
                        await c.Execute(r);
            }
        }
    }
}
