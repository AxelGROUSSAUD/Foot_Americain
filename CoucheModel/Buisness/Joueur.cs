
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheModel.Buisness
{
    public class Joueur
    {
        private int _id;
        private string _nom;
        private DateTime _dateNaissance;
        private DateTime _dateEntree ;
        private Pays _pays;
        private Poste _poste;

        public Joueur()
        {
            _id = 0;
            _nom = "";
            _dateNaissance = new DateTime();
            _dateEntree = new DateTime();
            _pays = new Pays();
            _poste = new Poste();

        }

        public Joueur(int unId,  string unNom, DateTime uneDateNaissance, DateTime uneDateEntree, Pays unPays, Poste unPoste)
        {
            _id = unId;
            _nom = unNom;
            _dateNaissance = uneDateNaissance;
            _dateEntree = uneDateEntree;
            _pays = unPays;
            _poste = unPoste;
        }

        public int Id { get => _id; set => _id = value; }

        public string Nom { get => _nom; set => _nom = value; }

        public DateTime DateNaissance { get => _dateNaissance; set => _dateNaissance = value; }

        public DateTime DateEntree { get => _dateEntree; set => _dateEntree = value; }

        public Pays Pays { get => _pays; set => _pays = value; }

        public Poste Poste { get => _poste; set => _poste = value; }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
