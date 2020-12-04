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
using System.Data;

namespace Foot_Americain.viewModel
{
    class viewModelFoot : viewModelBase
    {
        private Dbal vmDBAL= new Dbal("dsfootamericain");
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

        private ICommand updateCommand;
        private ICommand addCommand;
        private ICommand deleteCommand;
        private ICommand allJoueursCommand;

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
                    RefreshListJoueurEquipe(selectedEquipe);
                    
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
            get
            {
                if(selectedJoueur!=null)
                {
                    return selectedJoueur.Nom;
                }
                else
                {
                    
                    return null;
                }
            }
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
            get
            {
                if (selectedJoueur != null)
                {
                    return selectedJoueur.DateNaissance;
                }
                else
                {

                    return new DateTime();
                }
            }
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
            get
            {
                if (selectedJoueur != null)
                {
                    return selectedJoueur.DateEntree;
                }
                else
                {

                    return new DateTime();
                }
            }
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
            get
            {
                if (selectedJoueur != null)
                {
                    return selectedJoueur.Pays;
                }
                else
                {

                    return null;
                }
            }
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
            get
            {
                if (selectedJoueur != null)
                {
                    return selectedJoueur.Poste;
                }
                else
                {

                    return null;
                }
            }
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
            int n = 0;
            listJoueurs.Clear();
            foreach(Joueur j in vmDaoJoueur.SelectAllByEquipe(theEquipe))
            {
                listJoueurs.Add(j);
            }
            BindListJoueurListPays();
            BindListJoueurListPoste();
            OnPropertyChanged("ListJoueurs");
        }

        public void RefreshListJoueurEquipeAll()
        {
            listJoueurs.Clear();
            //qui rafraichira la liste de tous les joueurs quand aucune équipe n'est sélectionnée.
            foreach(Joueur j in vmDaoJoueur.SelectAll())
            {
                listJoueurs.Add(j);
            }
            BindListJoueurListPays();
            BindListJoueurListPoste();
            OnPropertyChanged("ListJoueurs");
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateJoueur(), () => true);
                }
                return this.updateCommand;

            }

        }
        public ICommand AddCommand
        {
            get
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new RelayCommand(() => AddJoueur(), () => true);
                }
                return this.addCommand;

            }

        }
        public ICommand DeleteCommand
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new RelayCommand(() => DeleteJoueur(), () => true);
                }
                return this.deleteCommand;

            }

        }

        public ICommand AllJoueurs
        {
            get
            {
                if(this.allJoueursCommand == null)
                {
                    this.allJoueursCommand = new RelayCommand(() => DisplayAllJoueurs(), () => true);
                }
                return this.allJoueursCommand;
            }
        }

        private void UpdateJoueur()
        {
            Joueur backup = new Joueur();
            backup = selectedJoueur;
            int position= listJoueurs.IndexOf(selectedJoueur);
            vmDaoJoueur.Update(selectedJoueur, selectedEquipe);
            listJoueurs.Insert(position, selectedJoueur);
            listJoueurs.RemoveAt(position + 1);
            selectedJoueur = backup;

        }

        private void AddJoueur()
        {
            vmDaoJoueur.Insert(selectedJoueur, selectedEquipe);
            listJoueurs.Add(selectedJoueur);
        }

        private void DeleteJoueur()
        {
            vmDaoJoueur.Delete(selectedJoueur);
            listJoueurs.Remove(selectedJoueur);
        }

        private void DisplayAllJoueurs()
        {
            this.RefreshListJoueurEquipeAll();
        }
    }
}
