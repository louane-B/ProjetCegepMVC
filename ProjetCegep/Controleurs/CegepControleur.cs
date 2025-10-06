using System.IO;
using System.Xml.Serialization;
using ProjetCegep.Modeles;
using ProjetCegep.DTOs;
using System.Collections.Generic;
using System;

/// <summary>
/// Namespace pour les classes de type Controleur.
/// </summary>
namespace ProjetCegep.Controleurs
{
    /// <summary>
    /// Classe représentant le controleur de l'application.
    /// </summary>
    public class CegepControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe CegepControleur.
        /// </summary>
        private static CegepControleur instance;

        /// <summary>
        /// Attribut représentant le Cégep.
        /// </summary>
        private Cegep monCegep;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CegepControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CegepControleur();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Controleurs

        /// <summary>
        /// Constructeur par défaut de la classe.
        /// </summary>
        private CegepControleur()
        {
            monCegep = null;
        }

        #endregion Controleurs

        #region MethodesCegep

        /// <summary>
        /// Méthode de service permettant de créer le Cégep.
        /// </summary>
        /// <param name="cegep">Le DTO du Cégep.</param>
        /// <returns>True si créé, False sinon...</returns>
        public bool CreerCegep(CegepDTO cegep)
        {
            if (!cegep.Nom.Equals("Cégep Rivière-du-Loup"))
                throw new Exception("Erreur - Vous devez utiliser le Cégep Rivière-du-Loup ...");
            try
            {
                CegepRepository.Instance.AjouterCegep(cegep);
                monCegep = new Cegep(cegep.Nom, cegep.Adresse, cegep.Ville, cegep.Province, cegep.CodePostal, cegep.Telephone, cegep.Courriel);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du cégep : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier le Cégep.
        /// </summary>
        /// <param name="cegep">Le DTO du Cégep.</param>
        /// <returns>True si modifié, False sinon...</returns>
        public bool ModifierCegep(CegepDTO cegepDTO)
        {
            CegepDTO cegepActuel = ObtenirCegep();

            if (cegepDTO.Nom.Equals("Cégep Rivière-du-Loup"))
            {
                if (cegepActuel.Adresse != cegepDTO.Adresse || cegepActuel.Ville != cegepDTO.Ville || cegepActuel.Province != cegepDTO.Province || cegepActuel.CodePostal != cegepDTO.CodePostal || cegepActuel.Telephone != cegepDTO.Telephone || cegepActuel.Courriel != cegepDTO.Courriel)
                {
                    CegepRepository.Instance.ModifierCegep(cegepDTO);
                    return true;
                }
                else
                {
                    throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
                }
            }
            else
            {
                throw new Exception("Erreur - Vous devez utiliser le Cégep Rivière-du-Loup...");
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer le Cégep.
        /// </summary>
        /// <returns>True si supprimé, False sinon...</returns>
        public bool SupprimerCegep()
        {
            if (monCegep == null)
                throw new Exception("Erreur - Aucun cégep n'est actuellement chargé.");
            if (!monCegep.Nom.Equals("Cégep Rivière-du-Loup"))

            if (!cegepDTO.Nom.Equals("Cégep Rivière-du-Loup"))
                throw new Exception("Erreur - Vous devez utiliser le Cégep Rivière-du-Loup...");

            try
            {
                CegepDTO cegepDTO = new CegepDTO(monCegep);
                CegepRepository.Instance.SupprimerCegep(CegepDTO);

                monCegep = null;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le Cégep.
        /// </summary>
        /// <returns>Le DTO du Cégep.</returns>
        public CegepDTO ObtenirCegep()
        {
            try
            {
                CegepDTO cegepDTO = CegeRepository.Instance.ObtenirCegep("Cégep Rivière-du-loup");

                monCegep = new Cegep(cegepDTO.Nom, cegepDTO.Adresse, cegepDTO.Ville, cegepDTO.Province, cegepDTO.CodePostal, cegepDTO.Telephone, cegepDTO.Courriel);

                return cegepDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'obtention du cégep : " + ex.Message);
                return null;
            }
        }

        #endregion MethodesCegep

        #region MethodesDepartement

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des départements.
        /// </summary>
        /// <returns>Liste contenant les département.</returns>
        public List<DepartementDTO> ObtenirListeDepartement()
        {
            List<DepartementDTO> liste = new List<DepartementDTO>();
            foreach (Departement departement in monCegep.ObtenirListeDepartement())
            {
                liste.Add(new DepartementDTO(departement));
            }
            return liste;
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un département.
        /// </summary>
        /// <param name="departement">Le DTO du département désiré. (Informations du Equals nécessaires)</param>
        /// <returns>Le DTO du département désiré.</returns>
        public DepartementDTO ObtenirDepartement(DepartementDTO departement)
        {
            return new DepartementDTO(monCegep.ObtenirDepartement(new Departement(departement.No, departement.Nom, departement.Description)));
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un département.
        /// </summary>
        /// <param name="departement">Le DTO du département a ajouter.</param>
        /// <returns>True si ajouté, False sinon.</returns>
        public bool AjouterDepartement(DepartementDTO departement)
        {
            return monCegep.AjouterDepartement(new Departement(departement.No, departement.Nom, departement.Description));
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un département.
        /// </summary>
        /// <param name="departement">Le DTO du département a supprimer.</param>
        /// <returns>True si supprimé, False sinon.</returns>
        public bool SupprimerDepartement(DepartementDTO departement)
        {
            return monCegep.EnleverDepartement(new Departement(unNom: departement.Nom));
        }

        #endregion MethodesDepartement

        #region MethodesEnseignant

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des enseignants.
        /// </summary>
        /// <param name="departement">Le DTO du département désiré.</param>
        /// <returns>Liste des enseignants.</returns>
        public List<EnseignantDTO> ObtenirListeEnseignant(DepartementDTO departement)
        {
            List<EnseignantDTO> liste = new List<EnseignantDTO>();
            Departement leDepartement = monCegep.ObtenirDepartement(new Departement(departement.No, departement.Nom, departement.Description));
            foreach (Enseignant enseignant in leDepartement.ObtenirListeEnseignant())
            {
                liste.Add(new EnseignantDTO(enseignant));
            }
            return liste;
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un enseignant.
        /// </summary>
        /// <param name="departement">Le DTO du département de l'enseignant.</param>
        /// <param name="enseignant">Le DTO de l'enseignant désiré.</param>
        /// <returns>Le DTO de l'enseignant désiré.</returns>
        public EnseignantDTO ObtenirEnseignant(DepartementDTO departement, EnseignantDTO enseignant)
        {
            return new EnseignantDTO(monCegep.ObtenirDepartement(new Departement(unNom: departement.Nom)).ObtenirEnseignant(new Enseignant(unNoEmploye: enseignant.NoEmploye)));
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un enseignant dans un département.
        /// </summary>
        /// <param name="departement">Le DTO du département dans lequel ajouter l'enseignant.</param>
        /// <param name="enseignant">Le DTO de l'enseignant à ajouter.</param>
        /// <returns>True si ajouté, False sinon.</returns>
        public bool AjouterEnseignant(DepartementDTO departement, EnseignantDTO enseignant)
        {
            return monCegep.ObtenirDepartement(new Departement(unNom:departement.Nom)).AjouterEnseignant(new Enseignant(enseignant.NoEmploye, enseignant.Nom, enseignant.Prenom, enseignant.Adresse, enseignant.Ville, enseignant.Province, enseignant.CodePostal, enseignant.Telephone, enseignant.Courriel));
        }

        /// <summary>
        /// Méthode de service permettant de modifier un enseignant.
        /// </summary>
        /// <param name="departement">Le DTO du département de l'enseignant.</param>
        /// <param name="enseignant">Le DTO de l'enseignant a modifier.</param>
        /// <returns>True si modifiée, False sinon.</returns>
        public bool ModifierEnseignant(DepartementDTO departement, EnseignantDTO enseignant)
        {
            Enseignant lenseignant = monCegep.ObtenirDepartement(new Departement(unNom: departement.Nom)).ObtenirEnseignant(new Enseignant(enseignant.NoEmploye));

            lenseignant.Nom = enseignant.Nom;
            lenseignant.Prenom = enseignant.Prenom;
            lenseignant.Adresse = enseignant.Adresse;
            lenseignant.Ville = enseignant.Ville;
            lenseignant.Province = enseignant.Province;
            lenseignant.CodePostal = enseignant.CodePostal;
            lenseignant.Telephone = enseignant.Telephone;
            lenseignant.Courriel = enseignant.Courriel;
            return true;
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un enseignant.
        /// </summary>
        /// <param name="departement">Le DTO du département de l'enseignant.</param>
        /// <param name="enseignant">Le DTO de l'enseignant a supprimer.</param>
        /// <returns>True si supprimé, False sinon.</returns>
        public bool SupprimerEnseignant(DepartementDTO departement, EnseignantDTO enseignant)
        {
            return monCegep.ObtenirDepartement(new Departement(unNom: departement.Nom)).EnleverEnseignant(new Enseignant(enseignant.NoEmploye));
        }

        #endregion MethodesEnseignant

        #region MethodesSerialisationXML
        
        /// <summary>
        /// Méthode de service permettant de charger les données du fichier XML.
        /// </summary>
        public void ChargerDonneesFichier()
        {
            if (File.Exists("Cegep.xml"))
            {
                XmlSerializer leFichierCegep = new XmlSerializer(typeof(Cegep));
                FileStream fichierLogique;

                fichierLogique = File.OpenRead("Cegep.xml");
                monCegep = (Cegep)leFichierCegep.Deserialize(fichierLogique);
                fichierLogique.Close();
            }
        }

        /// <summary>
        /// Méthode de service permettant de sauvegarder les données dans le fichier XML.
        /// </summary>
        public void SauvegarderDonneesFichier()
        {
            if (File.Exists("Cegep.xml"))
            {
                File.Delete("Cegep.xml");
            }
            XmlSerializer leFichierCegep = new XmlSerializer(typeof(Cegep));
            FileStream fichierLogique;

            using (fichierLogique = File.OpenWrite("Cegep.xml"))
            {
                leFichierCegep.Serialize(fichierLogique, monCegep);
            }
        }
        #endregion MethodesSerialisationXML
    }
}
