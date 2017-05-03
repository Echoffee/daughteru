using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.CoreModule
{
    public class Logs
    {
        async public static void Log(object s, MessageEventArgs e)
        {
            await Task.Run(() => {
                Console.WriteLine(e.Channel.Name + " MESSAGE from " + e.Message.User.Name + ":" + e.Message.Text);
                if (e.Message.MentionedUsers.Count() > 0)
                {
                    Console.WriteLine("MentionedUsers :");
                    foreach (var item in e.Message.MentionedUsers)
                    {
                        Console.WriteLine("\t" + item.Name + " (" + item.Mention + ")");
                    }
                }
            });
            
        }
    }
}
