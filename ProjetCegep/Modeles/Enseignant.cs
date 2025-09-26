using System;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace ProjetCegep.Modeles
{
    /// <summary>
    /// 
    /// </summary>
    public class Enseignant : Personne
    {
        /// <summary>
        /// 
        /// </summary>
        private int noEmploye;
        /// <summary>
        /// 
        /// </summary>
        public int NoEmploye
        {
            get { return noEmploye; }
            set { noEmploye = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Enseignant(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unNoEmploye"></param>
        /// <param name="unPrenom"></param>
        /// <param name="unNom"></param>
        /// <param name="uneAdresse"></param>
        /// <param name="uneVille"></param>
        /// <param name="uneProvince"></param>
        /// <param name="unCodePostal"></param>
        /// <param name="unTelephone"></param>
        /// <param name="unCourriel"></param>
        /// <param name="uneDateEmbauche"></param>
        public Enseignant(int unNoEmploye=0000000, string unPrenom="", string unNom="", string uneAdresse="", string uneVille="", string uneProvince="", string unCodePostal="", string unTelephone="", string unCourriel="")
        {
            NoEmploye = unNoEmploye;
            Prenom = unPrenom;
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            CodePostal = unCodePostal;
            Telephone = unTelephone;
            Courriel = unCourriel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Prenom + " " + Nom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is Enseignant) && NoEmploye.Equals((obj as Enseignant).NoEmploye);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return NoEmploye.GetHashCode();
        }
    }
}
