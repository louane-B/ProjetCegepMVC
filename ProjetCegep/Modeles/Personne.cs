
/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace ProjetCegep.Modeles
{
    /// <summary>
    /// 
    /// </summary>
    public class Personne
    {
        /// <summary>
        /// 
        /// </summary>
        private string prenom;
        /// <summary>
        /// 
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string nom;
        /// <summary>
        /// 
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string adresse;
        /// <summary>
        /// 
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string ville;
        /// <summary>
        /// 
        /// </summary>
        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string province;
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string codePostal;
        /// <summary>
        /// 
        /// </summary>
        public string CodePostal
        {
            get { return codePostal; }
            set { codePostal = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string telephone;
        /// <summary>
        /// 
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string courriel;
        /// <summary>
        /// 
        /// </summary>
        public string Courriel
        {
            get { return courriel; }
            set { courriel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Personne(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unPrenom"></param>
        /// <param name="unNom"></param>
        /// <param name="uneAdresse"></param>
        /// <param name="uneVille"></param>
        /// <param name="uneProvince"></param>
        /// <param name="unCodePostal"></param>
        /// <param name="unTelephone"></param>
        /// <param name="unCourriel"></param>
        public Personne(string unPrenom="", string unNom="", string uneAdresse="", string uneVille="", string uneProvince="", string unCodePostal="", string unTelephone="", string unCourriel="")
        {
            Prenom = unPrenom;
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            CodePostal = unCodePostal;
            Telephone = unTelephone;
            Courriel = unCourriel;
        }
    }
}
