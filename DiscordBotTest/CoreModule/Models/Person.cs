using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.CoreModule.Models
{
    public class Person
    {
        //Identity
        public int Id { get; set; }

        public string DiscordId { get; set; }

        public string CurrentName { get; set; }

        //Currency
        public long Yen { get; set; }

        public long Flowers { get; set; }

        //Moe
        public int AffectionLevel { get; set; }

        public int LikeLevel { get; set; }

        public int LoveLevel { get; set; }

        public int DislikeLevel { get; set; }

        public int HateLevel { get; set; }
    }
}
