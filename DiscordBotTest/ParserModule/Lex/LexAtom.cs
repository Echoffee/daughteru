using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTest.ParserModule.Lex
{
    class LexAtom : ALex
    {
        public LexAtom(Parser parser) : base(parser)
        {
        }

        public override void Initialize()
        {
            Split = true;
            LowerCase = true;

            //W
            AddToLexem("who", new string[]{ "qui" });
            AddToLexem("what", new string[] { "quoi", "quelle", "quel" });
            AddToLexem("how_many", new string[] { "combien" });

            //Verbs Aux
            AddToLexem("be", new string[]{ "etre", "suis", "es", "est", "sommes", "etes", "sont" });

            //Pronouns
            AddToLexem("you", new string[] { "tu", "vous" });
            AddToLexem("your", new string[] { "ton", "ta", "tes", "vos" });
            AddToLexem("it", new string[] { "il", "elle" });
            AddToLexem("we", new string[] { "nous", "on" });

            //Verbs
            AddToLexem("change", new string[] { "changer", "change", "changes", "changeons", "changez", "changent", "modifier", "modifie", "modifies", "modifions", "modifiez", "modifient" });
            AddToLexem("give", new string[] { "donner", "donne", "donnes", "donnons", "donnez", "donnent" });
            AddToLexem("recall", new string[] { "rappeler", "rappelle", "rappelles", "rappelons", "rappelez", "rappellent", "retenir", "retiens", "retient", "retenons", "retenez", "retiennent" });

            //Names
            AddToLexem("name", new string[] { "nom", "prenom" });
            AddToLexem("hour", new string[] { "heure" });
            AddToLexem("day", new string[] { "jour" });
            AddToLexem("date", new string[] { "date" });


            //Adv
            AddToLexem("to", new string[] { "en", "vers" });
        }

        
    }
}
