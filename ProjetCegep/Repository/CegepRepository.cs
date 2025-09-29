using ProjetCegep.DTO
using System;
using System.Data.SqlClient;

namespace ProjetCegep.Repository
{
    public CegepRepository : Repository
    {
        private static CegepRepository _instance;
        public static CegepRepository Instance => _instance ??= new CegepRepository();
        
        public void ModifierCegep(CegepDTO cegepDTO)
        {
        if (!OuvrirConnexion())
            throw new Exception("Impossible d'ouvrir la connexion à la base de données.");

        string requete = @"
            UPDATE Cegep
            SET Adresse = @Adresse,
                Ville = @Ville,
                Province = @Province,
                CodePostal = @CodePostal,
                Telephone = @Telephone,
                Courriel = @Courriel
            WHERE Nom = @Nom";

        using (SqlCommand commande = new SqlCommand(requete, connexion))
        {
            commande.Parameters.AddWithValue("@Nom", cegepDTO.Nom);
            commande.Parameters.AddWithValue("@Adresse", cegepDTO.Adresse);
            commande.Parameters.AddWithValue("@Ville", cegepDTO.Ville);
            commande.Parameters.AddWithValue("@Province", cegepDTO.Province);
            commande.Parameters.AddWithValue("@CodePostal", cegepDTO.CodePostal);
            commande.Parameters.AddWithValue("@Telephone", cegepDTO.Telephone);
            commande.Parameters.AddWithValue("@Courriel", cegepDTO.Courriel);

            int lignesModifiees = commande.ExecuteNonQuery();
            if (lignesModifiees == 0)
                throw new Exception("Aucune modification effectuée. Vérifiez que le cégep existe.");
        }
        FermerConnexion();
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