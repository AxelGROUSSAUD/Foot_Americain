using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheModel.Buisness;

namespace CoucheModel.Data
{
    public class daoJoueur
    {

        private Dbal thedbal;
        private DaoPays theDaoPays;
        private daoPoste theDaoPoste;

        public daoJoueur(Dbal mydbal, DaoPays theDaoPays, daoPoste theDaoPoste)
        {
            this.thedbal = mydbal;
            this.theDaoPays = theDaoPays;
            this.theDaoPoste = theDaoPoste;
        }

        public void Insert(Joueur theJoueur, Equipe theEquipe)
        {
            string query = "Joueur VALUES ("+theJoueur.Id+",'"+ theJoueur.Nom+"','"+theJoueur.DateEntree+"','"+theJoueur.DateNaissance+"','"+theJoueur.Pays.Id+"','"+theJoueur.Poste.Id+"','"+theEquipe.Id+"');";
            thedbal.Insert(query);
        }

        public void Update(Joueur theJoueur, Equipe theEquipe)
        {
            string query = "Joueur SET id = "+theJoueur.Id+", nom = '"+theJoueur.Nom+"', dateEntree = '"+theJoueur.DateEntree+"', dateNaissance = '"+theJoueur.DateNaissance+"', pays = "+theJoueur.Pays.Id+", poste = "+theJoueur.Poste.Id+", equipe = "+theEquipe.Id+" WHERE id = "+theJoueur.Id+";";
            thedbal.Update(query);
        }

        public void Delete(Joueur theJoueur)
        {
            string query = "Joueur WHERE id = "+theJoueur.Id+";";
            thedbal.Delete(query);
        }

        public List<Joueur> SelectAll()
        {
            List<Joueur> listJoueur = new List<Joueur>();
            DataTable myTable = this.thedbal.SelectAll("Joueur");

            foreach (DataRow r in myTable.Rows)
            {
                Pays myPays = this.theDaoPays.SelectById((int)r["id"]);
                Poste myPoste = this.theDaoPoste.SelectById((int)r["id"]);
                listJoueur.Add(new Joueur((int)r["id"], (string)r["nom"], (DateTime)r["dateNaissance"],(DateTime)r["dateEntree"], myPays, myPoste));
            }

            return listJoueur;
        }

        public List<Joueur> SelectAllByEquipe(Equipe theEquipe)
        {
            List<Joueur> listJoueur = new List<Joueur>();
            string condition = theEquipe.Id + "= Joueur.equipe ;";
            DataTable unDataTable =thedbal.SelectByField("Joueur", condition);
            foreach (DataRow r in unDataTable.Rows)
            {
                Pays myPays = this.theDaoPays.SelectById((int)r["id"]);
                Poste myPoste = this.theDaoPoste.SelectById((int)r["id"]);
                listJoueur.Add(new Joueur((int)r["id"], (string)r["nom"], (DateTime)r["dateNaissance"], (DateTime)r["dateEntree"], myPays, myPoste));
            }
            return listJoueur;
        }
    }
}
