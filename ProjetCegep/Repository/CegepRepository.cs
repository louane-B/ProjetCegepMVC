using ProjetCegep.DTO;
using System;
using System.Data.SqlClient;
using System.Data;
using ProjetCegep.Exceptions;

namespace ProjetCegep.Repository
{
    public class CegepRepository : Repository
    {
        #region AttributsProprietes
        private static CegepRepository instance;
        
        public static CegepRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CegepRepository();
                }
                return instance;
            }
        }
        
        #endregion AttributsProprietes
        
        #region Constructeurs
        
        /// <summary>
        /// Constructeur de CegepRepository
        /// </summary>
        private CegepRepository() : base() { }

        #endregion Constructeur

        #region MethodesServices

        /// <summary>
        /// Methodes Permettant de modifier un cegep
        /// </summary>
        /// <param name="cegepDTO"></param>
        /// <exception cref="Exception"></exception>
        public void ModifierCegep(CegepDTO cegepDTO)
        {
            sqlCommand command = new sqlCommand(null, connexion);
            
            command.commandText = " UPDATE Cegep" +
                                    " SET Adresse = @adresse," +
                                    "     Ville = @Ville," +
                                    "     Province = @province," +
                                    "     CodePostal = @codePostal," +
                                    "     Telephone = @telephone," +
                                    "     Courriel = @courriel" +
                                    "WHERE Nom = @nom";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 100);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 75);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter codePostalParam = new SqlParameter("@codePostal", SqlDbType.VarChar, 7);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);
            SqlParameter courrielParam = new SqlParameter("@courriel", SqlDbType, 100);

            nomParam.Value = cegepDTO.Name;
            adresseParam.Value = cegepDTO.Description;
            villeParam.Value = cegepDTO.Ville;
            provinceParam = cegepDTO.Province;
            codePostalParam.Value = cegepDTO.Code;
            telephoneParam.Value = cegepDTO.Telephone;
            courrielParam.Value = cegepDTO.Courriel;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(villeParam);
            command.Parameters.Add(provinceParam);
            command.Parameters.Add(codePostalParam);
            command.Parameters.Add(telephoneParam);
            command.Parameters.Add(courrielParam);

            try
            {
                OuvrirConnexion();
                command.prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'un Cegep ...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }


        public void AjouterCegep(CegepDTo cegepDTO)
        {
            if (!OuvrirConnexion())
            {
                Console.WriteLine("Connexion à la base échouée.");
                return;
            }

        string requete = @"INSERT INTO Cegep (Nom,Adresse, Ville, Province, CodePostal, Telephone, Courriel)
                               VALUES (@NOM, @Adresse, @VIlle, @Province, @CodePostal, @Telephone, @Courriel)";

        using (SqlCommand commande = new SqlCommand(requete, connexion))
        {
            commande.Parameters.AddWithValue("@Nom", cegepDTO.Nom);
            commande.Parameters.AddWithValue("@Adresse", cegepDTO.Adresse);

        }
        }
    }
}