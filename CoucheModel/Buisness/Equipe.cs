
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheModel.Buisness
{
    public class Equipe
    {
        private int _id;
        private string _nom;
        private DateTime _dateCreation;
        private List<Joueur> _mesJoueurs;

        public Equipe()
        {
            _id = 0;
            _nom = "null";
            _dateCreation = new DateTime();
            _mesJoueurs = new List<Joueur>();
        }

        public Equipe(int unId, string unNom, DateTime uneDate)
        {
            _id = unId;
            _nom = unNom;
            _dateCreation = uneDate;
            _mesJoueurs = new List<Joueur>();
        }

        public int Id { get => _id; set => _id = value; }

        public string Nom { get => _nom; set => _nom = value; }

        public DateTime DateCreation { get => _dateCreation; set => _dateCreation = value; }

        public List<Joueur> MesJoueurs => _mesJoueurs;

    }
}
