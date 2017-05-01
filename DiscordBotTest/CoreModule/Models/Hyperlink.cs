using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.CoreModule.Models
{
    class Hyperlink
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public string AuthorDiscordId { get; set; }

        public DateTime PostedDate { get; set; }
    }
}
