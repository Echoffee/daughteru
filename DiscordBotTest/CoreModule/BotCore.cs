using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using DiscordBotTest.CoreModule.Models;
using DiscordBotTest.Commands;
using Discord;
using System.IO;

namespace DiscordBotTest.CoreModule
{
    public class BotCore
    {
        public string Token { get; set; }

        public LiteCollection<KeyValue> MetaDB { get; set; }

        public List<ACommand> Commands { get; set; }

        public DiscordClient Bot { get; set; }

        public LiteCollection<Reminder> ReminderDB { get; set; }

        public bool Initialize(DiscordClient client)
        {
            var documentsPaths = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = documentsPaths + @"/botchan";
            Token = new StreamReader(path + @"/token.txt").ReadLine();
            var db = new LiteDatabase(path + @"/data.db");
            Bot = client;
            MetaDB = db.GetCollection<KeyValue>("meta");
            ReminderDB = db.GetCollection<Reminder>("reminders");
            LoadCommands();
            return true;
        }

        public bool LoadCommands()
        {
            Commands = new List<ACommand>
            {
                new WhoAmI(this),
                new RenameBot(this),
                new GiveTime(this),
                new ReminderAdd(this),
                new ReminderGet(this)
            };

            return true;
        }
    }
}
