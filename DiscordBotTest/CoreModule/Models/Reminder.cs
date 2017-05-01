using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.CoreModule.Models
{
    public class Reminder
    {
        public int ID { get; set; }

        public string Key { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
