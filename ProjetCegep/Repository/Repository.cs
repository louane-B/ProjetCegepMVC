using System.Data.SqlClient;

namespace ProjetCegep.Repository
{
    public class Repository
    {
        protected SqlConnection connexion;

        public Repository()
        {
            connexion = new SqlConnection("Data Source=ZENBOOK-LOUANEB;Initial Catalog=Cegep;Integrated Security=True");
        }

        protected bool OuvrirConnexion()
        {
            try
            {
                (connexion.State == System.Data.ConnectionState.Closed)
                    connexion.Open();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur SQL : " + ex.Message);
                return false
            }
        }

        protected bool FermerConnexion()
        {
            try
            {
                if (connexion.State == System.Data.ConnectionState.Open)
                    connexion.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Console.Writeline("Erreur lors de la fermeture de la connexion : " + ex.Message);
                return false;
            }
        }
    }
}