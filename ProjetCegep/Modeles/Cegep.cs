using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace ProjetCegep.Modeles
{
    /// <summary>
    /// Classe représentant un Cégep.
    /// </summary>
    public class Cegep
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le nom du Cégep.
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété représentant le nom du Cégep.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /// <summary>
        /// Attribut représentant l'adresse du Cégep.
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété représentant l'adresse du Cégep.
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        /// <summary>
        /// Attribut représentant la ville du Cégep.
        /// </summary>
        private string ville;
        /// <summary>
        /// Propriété représentant la ville du Cégep.
        /// </summary>
        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }

        /// <summary>
        /// Attribut représentant la province du Cégep.
        /// </summary>
        private string province;
        /// <summary>
        /// Propriété représentant la province du Cégep.
        /// </summary>
        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        /// <summary>
        /// Attribut représentant le code postal du Cégep.
        /// </summary>
        private string codePostal;
        /// <summary>
        /// Propriété représentant le code postal du Cégep.
        /// </summary>
        public string CodePostal
        {
            get { return codePostal; }
            set { codePostal = value; }
        }

        /// <summary>
        /// Attribut représentant le telephone du Cégep.
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété représentant le telephone du Cégep.
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        /// <summary>
        /// Attribut représentant le courriel du Cégep.
        /// </summary>
        private string courriel;
        /// <summary>
        /// Propriété représentant le courriel du Cégep.
        /// </summary>
        public string Courriel
        {
            get { return courriel; }
            set { courriel = value; }
        }

        /// <summary>
        /// Attribut représentant la liste des départements du Cégep.
        /// </summary>
        public List<Departement> listeDepartement;

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur sans paramètre nécessaire pour la sérialisation XML.
        /// </summary>
        public Cegep(){}

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="unNom">Le nom du cégep</param>
        /// <param name="uneAdresse">L'adresse du cégep</param>
        /// <param name="uneVille">La ville du cégep</param>
        /// <param name="uneProvince">La province du cégep</param>
        /// <param name="unCodePostal">Le code postal du cégep</param>
        /// <param name="unTelephone">Le téléphone du cégep</param>
        /// <param name="unCourriel">Le courriel du cégep</param>
        public Cegep(string unNom="", string uneAdresse="", string uneVille="", string uneProvince="", string unCodePostal="", string unTelephone="", string unCourriel="")
        {
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            CodePostal = unCodePostal;
            Telephone = unTelephone;
            Courriel = unCourriel;
            listeDepartement = new List<Departement>();
        }

        #endregion Constructeurs

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des départements du cégep.
        /// </summary>
        /// <returns>Un tableau de départements</returns>
        public Departement[] ObtenirListeDepartement()
        {
            return listeDepartement.ToArray();
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un département.
        /// </summary>
        /// <param name="unDepartement">L'objet département que l'on veut avoir en fournissant les informations nécessaire dans le Equals.</param>
        /// <returns>Le département qui correspond ou null si l'on a rien trouvé.</returns>
        public Departement ObtenirDepartement(Departement unDepartement)
        {
            //foreach (Departement departement in listeDepartement)
            //{
            //    if (departement.Equals(unDepartement))
            //        return departement;
            //}
            //return null;

            return listeDepartement.Find(x => x.Equals(unDepartement));

        }

        /// <summary>
        /// Méthode de service permettant de vérifier si un département est présent dans la liste.
        /// </summary>
        /// <param name="unDepartement">Le département que l'on cherche. (Information du Equals)</param>
        /// <returns>Vrai si le département est trouvé, Faux sinon...</returns>
        public bool SiDepartementPresent(Departement unDepartement)
        {
            //foreach (Departement departement in listeDepartement)
            //{
            //    if (departement.Equals(unDepartement))
            //        return true;
            //}
            //return false;

            return listeDepartement.Exists(x => x.Equals(unDepartement));

        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un département à la liste.
        /// </summary>
        /// <param name="unDepartement">Le département à ajouter.</param>
        /// <returns>Vrai si le département s'est bien ajouté, Faux sinon...</returns>
        public bool AjouterDepartement(Departement unDepartement)
        {
            if (SiDepartementPresent(unDepartement))
                return false;
            listeDepartement.Add(unDepartement);
            return SiDepartementPresent(unDepartement);
        }

        /// <summary>
        /// Méthode de service permettant d'enlever un département à la liste.
        /// </summary>
        /// <param name="unDepartement">Le département à enlever.</param>
        /// <returns>Vrai si le département est bien enlevé, Faux sinon...</returns>
        public bool EnleverDepartement(Departement unDepartement)
        {
            if (!SiDepartementPresent(unDepartement))
                return false;
            listeDepartement.Remove(unDepartement);
            return !SiDepartementPresent(unDepartement);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le nombre de département du Cégep.
        /// </summary>
        /// <returns>Nombre de département.</returns>
        public int ObtenirNombreDepartement()
        {
            return listeDepartement.Count;
        }

        /// <summary>
        /// Méthode de service permettant de savoir si le Cégep a aucun département.
        /// </summary>
        /// <returns>Vrai si aucun département, Faux sinon...</returns>
        public bool SiAucunDepartement()
        {
            return ObtenirNombreDepartement() == 0;
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des département du Cégep.
        /// </summary>
        /// <returns>Vrai si la liste a été vidée, Faux sinon...</returns>
        public bool ViderListeDepartement()
        {
            if (ObtenirNombreDepartement() == 0)
                return false;
            listeDepartement.Clear();
            return SiAucunDepartement();
        }

        public int CalculerSommeEtudiant()
        {
            //int nbrEtudiant = 0;
            //foreach (Departement departement in ObtenirListeDepartement())
            //{
            //    nbrEtudiant += departement.ObtenirNombreEtudiant();
            //}

            //return nbrEtudiant;

            return ObtenirListeDepartement().Sum(x => x.ObtenirNombreEtudiant());
        }

        public double CalculerMoyenneEtudiantDepartement()
        {
            //int nbrEtudiant = 0;
            //foreach (Departement departement in ObtenirListeDepartement())
            //{
            //    nbrEtudiant += departement.ObtenirNombreEtudiant();
            //}

            //return nbrEtudiant / ObtenirNombreDepartement();

            return ObtenirListeDepartement().Average(x => x.ObtenirNombreEtudiant());
        }



        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Cegep.
        /// </summary>
        /// <returns>Version textuelle de l'objet Cegep.</returns>
        public override string ToString()
        {
            return Nom + "\n" + Adresse + "\n" + Ville + ", "
                    + Province + "\n" + CodePostal + "\n" + Telephone + "\n" + Courriel;
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Cegep.
        /// Deux objets Cegep sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is Cegep) && Nom.Equals((obj as Cegep).Nom);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Cegep.
        /// </summary>
        /// <returns>HashCode de l'objet Cegep.</returns>
        public override int GetHashCode()
        {
            return Nom.Length;
        }

        #endregion Overrides
    }
}
