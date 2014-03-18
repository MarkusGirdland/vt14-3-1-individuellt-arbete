using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Spelare
    {
        public int SpelareID { get; set; }
        public int SkicklighetstypID { get; set; }
        public int HjälteID { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public int Lön { get; set; }
        public string Hjältenamn { get; set; }
        public string Skicklighet { get; set; }
    }
}