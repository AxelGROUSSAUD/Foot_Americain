using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheModel.Buisness
{
    public class Poste
    {
        private int _id;
        private string _nom;
        private int _escouade;

        public Poste()
        {
            _id = 0;
            _nom = "";
            _escouade = 0;
        }

        public Poste(int unId, string unNom, int uneEscouade)
        {
            _id = unId;
            _nom = unNom;
            _escouade = uneEscouade;
        }

        public int Id { get => _id; set => _id = value; }

        public string Nom { get => _nom; set => _nom = value; }

        public int Escouade { get => _escouade; set => _escouade = value; }
    }
}
