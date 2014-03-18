using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        public void SpelareListView_InsertItem(Spelare spelare)
        {
            try
            {
                Service.SaveSpelare(spelare);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade med tilläggning av spelare.");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Spelare> SpelareListView_GetData()
        {
            return Service.GetSpelare();
        }

        public void SpelareListView_UpdateItem(int spelareID)
        {
            try
            {
                var spelare = Service.GetOneSpelare(spelareID);
                if (spelare == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kunded med kundnummer{0} hittades inte.", spelareID));
                    return;
                }

                if (TryUpdateModel(spelare))
                {
                    Service.SaveSpelare(spelare);
                }
            }

            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel med uppdatering av spelaruppgifter.");
            }
        }

        public void SpelareListView_DeleteItem(int spelareID)
        {
            try
            {
                Service.DeleteSpelare(spelareID);
            }
            
            catch
            {
                ModelState.AddModelError(String.Empty, "Ett fel med att ta bort spelaren inträffade.");
            }
        }
    }
}