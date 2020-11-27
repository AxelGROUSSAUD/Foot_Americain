using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheModel.Buisness;
using CoucheModel.Data;

namespace Foot_Americain.viewModel
{
    class viewModelFoot : viewModelBase
    {

        private DaoPays vmDaoPays;
        private daoEquipe vmDaoEquipe;
        private daoJoueur vmDaoJoueur;
        private daoPoste vmDaoPoste;

        private ObservableCollection<Pays> listPays;
        private ObservableCollection<Equipe> listEquipes;
        private ObservableCollection<Joueur> listJoueurs;
        private ObservableCollection<Poste> listPostes;


        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Equipe> ListEquipes { get => listEquipes; set => listEquipes = value; }
        public ObservableCollection<Joueur> ListJoueurs { get => listJoueurs; set => listJoueurs = value; }
        public ObservableCollection<Poste> ListPostes { get => listPostes; set => listPostes = value; }

        public viewModelFoot(DaoPays unDaoPays, daoEquipe unDaoEquipe, daoJoueur unDaoJoueur, daoPoste unDaoPoste)
        {
            vmDaoPays = unDaoPays;
            vmDaoPoste = unDaoPoste;
            vmDaoEquipe = unDaoEquipe;
            vmDaoJoueur = unDaoJoueur;

            listEquipes = new ObservableCollection<Equipe>(unDaoEquipe.SelectAll());
            listJoueurs = new ObservableCollection<Joueur>(unDaoJoueur.SelectAll());
            listPays = new ObservableCollection<Pays>(unDaoPays.SelectAll());
            listPostes = new ObservableCollection<Poste>(unDaoPoste.SelectAll());

        }
    }
}
