using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule.Lex
{
    public abstract class ALex
    {
        public Dictionary<string, string> Lexem;

        public bool Split { get; set; }

        public bool LowerCase { get; set; }

        public Parser Parser { get; set; }

        public ALex(Parser parser)
        {
            this.Parser = parser;
            this.Lexem = new Dictionary<string, string>();
            Initialize();
        }

        public abstract void Initialize();

        public string Parse(string str)
        {
            if (LowerCase)
                str = str.ToLower();

            var sl = str.Split(' ');
            /*
            for(int i = 0; i < sl.Length; i++)
            {
                if (Lexem.ContainsKey(sl[i]))
                    sl[i] = Lexem[sl[i]];
            }

            return string.Join(" ", sl);*/


            foreach (var k in Lexem.Keys)
            {
                if (Split)
                {

                    for(int i = 0; i < sl.Length; i++)
                    {
                        if (sl[i].Equals(k))
                            sl[i] = Lexem[k];
                    }
                }
                else
                {
                    str = str.Replace(k, Lexem[k]);
                }

            }

            if (Split)
                return string.Join(" ", sl);
            else
                return str;
        }

        protected void AddToLexem(string value, string[] keys)
        {
            foreach (var item in keys)
                this.Lexem.Add(item, value);
        }
    }
}
