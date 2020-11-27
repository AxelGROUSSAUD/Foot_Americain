using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheModel.Buisness;

namespace CoucheModel.Data
{
    public class daoEquipe
    {
        private Dbal thedbal;

        public daoEquipe(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public List<Equipe> SelectAll()
        {
            List<Equipe> listEquipe = new List<Equipe>();
            DataTable myTable = this.thedbal.SelectAll("Equipe");

            foreach (DataRow r in myTable.Rows)
            {
                listEquipe.Add(new Equipe((int)r["id"], (string)r["nom"],(DateTime)r["dateCreation"]));
            }

            return listEquipe;
        }

    }
}
