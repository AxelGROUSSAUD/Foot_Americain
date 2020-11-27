using CoucheModel.Buisness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheModel.Data
{
    public class daoPoste
    {
        private Dbal thedbal;

        public daoPoste(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public Poste SelectById(int idPoste)
        {
            DataRow result = this.thedbal.SelectById("Poste", idPoste);
            return new Poste((int)result["id"], (string)result["nom"], (int)result["escouade"]);

        }

        public List<Poste> SelectAll()
        {
            List<Poste> listPoste = new List<Poste>();
            DataTable myTable = this.thedbal.SelectAll("Poste");

            foreach (DataRow r in myTable.Rows)
            {
                listPoste.Add(new Poste((int)r["id"], (string)r["nom"], (int)r["escouade"]));
            }

            return listPoste;
        }
    }
}
