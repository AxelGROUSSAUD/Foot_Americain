using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoucheModel.Buisness;
using CoucheModel.Data;
using Foot_Americain.viewModel;
using System.Windows.Input;

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

        private Equipe selectedEquipe = new Equipe();
        private Joueur selectedJoueur = new Joueur();

        

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
            this.BindListJoueurListPays();
            this.BindListJoueurListPoste();
        }

        public Equipe SelectedEquipe
        {
            get => selectedEquipe;
            set
            {
                if (selectedEquipe != value)
                {
                    selectedEquipe = value;
                    OnPropertyChanged("SelectedEquipe");

                }
            }
        }
        public Joueur SelectedJoueur
        {
            get => selectedJoueur;
            set
            {
                if(selectedJoueur!=value)
                {
                    selectedJoueur = value;
                    OnPropertyChanged("SelectedJoueur");
                    OnPropertyChanged("Name");
                    OnPropertyChanged("DateNaissance");
                    OnPropertyChanged("DateEntree");
                    OnPropertyChanged("PaysNaissance");
                    OnPropertyChanged("PosteJoueur");
                }
            }
        }

        //public ObservableCollection<Joueur> SelectedListJoueur
        //{
        //    get{
        //        ObservableCollection<Joueur> ListeJoueurs = new ObservableCollection<Joueur>();
        //        foreach(Joueur j in selectedEquipe.MesJoueurs)
        //        {
        //            ListeJoueurs.Add(j);
        //        }
        //        return ListeJoueurs;
        //    }
        //}

        public string Name
        {
            get => selectedJoueur.Nom;
            set
            {
                if(selectedJoueur.Nom!= value)
                {
                    selectedJoueur.Nom = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public DateTime DateNaissance
        {
            get => selectedJoueur.DateNaissance;
            set
            {
                if(selectedJoueur.DateNaissance!=value)
                {
                    selectedJoueur.DateNaissance = value;
                    OnPropertyChanged("DateNaissance");
                }
            }
        }

        public DateTime DateEntree
        {
            get => selectedJoueur.DateEntree;
            set
            {
                if(selectedJoueur.DateEntree!= value)
                {
                    selectedJoueur.DateEntree = value;
                    OnPropertyChanged("DateEntree");
                }
            }
        }

        public Pays PaysNaissance
        {
            get => selectedJoueur.Pays;
            set
            {
                if(selectedJoueur.Pays!= value)
                {
                    selectedJoueur.Pays = value;
                    OnPropertyChanged("PaysNaissance");
                }
            }
        }

        public Poste PosteJoueur
        {
            get => selectedJoueur.Poste;
            set
            {
                if(selectedJoueur.Poste!=value)
                {
                    selectedJoueur.Poste = value;
                    OnPropertyChanged("PosteJoueur");
                }
            }
        }
        public void BindListJoueurListPays()
        {
            foreach(Joueur j in listJoueurs)
            {
                int n = 0;
                while(j.Pays.Name!= listPays[n].Name)
                {
                    n = n + 1;
                }
                j.Pays = listPays[n];
            }
        }

        public void BindListJoueurListPoste()
        {
            foreach (Joueur j in listJoueurs)
            {
                int n = 0;
                while (j.Poste.Nom!=listPostes[n].Nom)
                {
                    n = n + 1;
                }
                j.Poste = listPostes[n];
            }
        }

        public void RefreshListJoueurEquipe(Equipe theEquipe)
        {

        }

    }
}
