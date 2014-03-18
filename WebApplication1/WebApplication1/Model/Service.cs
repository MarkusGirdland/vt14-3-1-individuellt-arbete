using WebApplication1.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Service
    {
        private SpelareDAL _spelareDAL;

        private SpelareDAL SpelareDAL
        {
            get { return _spelareDAL ?? (_spelareDAL = new SpelareDAL()); }
        }

        public Spelare GetOneSpelare(int spelareID)
        {
            return SpelareDAL.GetSpelareById(spelareID);
        }

        public IEnumerable<Spelare> GetSpelare()
        {
            return SpelareDAL.GetSpelare();
        }

        public Spelare GetSpelareById(int spelareID)
        {
            return SpelareDAL.GetSpelareById(spelareID);
        }

        public void SaveSpelare(Spelare spelare)
        {
            if (spelare.SpelareID == 0)
            {
                SpelareDAL.InsertSpelare(spelare);
            }

            else
            {
                SpelareDAL.UpdateSpelare(spelare);
            }
        }

        public void DeleteSpelare(int spelareID)
        {
            SpelareDAL.DeleteSpelare(spelareID);
        }
    }
}