using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CoucheModel.Buisness;
using CoucheModel.Data;

namespace Foot_Americain
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Dbal thedbal;
        private DaoPays thedaopays;
        private daoJoueur thedaojoueur;
        private daoEquipe thedaoequipe;
        private daoPoste thedaoposte;

        private void Application_Startup(object sender , StartupEventArgs e)
        {
            thedbal = new Dbal("dsfootamericain");
            thedaopays = new DaoPays(thedbal);
            thedaoposte = new daoPoste(thedbal);
            thedaojoueur = new daoJoueur(thedbal, thedaopays,thedaoposte);
            thedaoequipe = new daoEquipe(thedbal);

            MainWindow wnd = new MainWindow(thedaopays, thedaojoueur, thedaoequipe, thedaoposte);
            wnd.Show();
            
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
