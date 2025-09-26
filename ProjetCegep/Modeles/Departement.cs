using System.Collections.Generic;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace ProjetCegep.Modeles
{
    /// <summary>
    /// 
    /// </summary>
    public class Departement
    {
        /// <summary>
        /// 
        /// </summary>
        private string no;
        /// <summary>
        /// 
        /// </summary>
        public string No
        {
            get { return no; }
            set { no = value; }
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
        private string description;
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private List<Etudiant> listeEtudiant;

        /// <summary>
        /// 
        /// </summary>
        public List<Enseignant> listeEnseignant;

        /// <summary>
        /// 
        /// </summary>
        private List<Cours> listeCours;

        /// <summary>
        /// 
        /// </summary>
        public Departement(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unNo"></param>
        /// <param name="unNom"></param>
        /// <param name="uneDescription"></param>
        public Departement(string unNo="", string unNom="", string uneDescription="")
        {
            No = unNo;
            Nom = unNom;
            Description = uneDescription;
            listeEtudiant = new List<Etudiant>();
            listeEnseignant = new List<Enseignant>();
            listeCours = new List<Cours>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Etudiant[] ObtenirListeEtudiant()
        {
            return listeEtudiant.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEtudiant"></param>
        /// <returns></returns>
        public Etudiant ObtenirEtudiant(Etudiant unEtudiant)
        {
            foreach (Etudiant etudiant in listeEtudiant)
            {
            if (etudiant.Equals(unEtudiant))
                return etudiant;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEtudiant"></param>
        /// <returns></returns>
        public bool SiEtudiantPresent(Etudiant unEtudiant)
        {
            foreach (Etudiant etudiant in listeEtudiant)
            {
            if (etudiant.Equals(unEtudiant))
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEtudiant"></param>
        /// <returns></returns>
        public bool AjouterEtudiant(Etudiant unEtudiant)
        {
            if (SiEtudiantPresent(unEtudiant))
            return false;
            listeEtudiant.Add(unEtudiant);
            return SiEtudiantPresent(unEtudiant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEtudiant"></param>
        /// <returns></returns>
        public bool EnleverEtudiant(Etudiant unEtudiant)
        {
            if (!SiEtudiantPresent(unEtudiant))
            return false;
            listeEtudiant.Remove(unEtudiant);
            return !SiEtudiantPresent(unEtudiant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObtenirNombreEtudiant()
        {
            return listeEtudiant.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SiAucunEtudiant()
        {
            return ObtenirNombreEtudiant() == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ViderListeEtudiant()
        {
            if (ObtenirNombreEtudiant() == 0)
            return false;
            listeEtudiant.Clear();
            return SiAucunEtudiant();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Enseignant[] ObtenirListeEnseignant()
        {
            return listeEnseignant.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEnseignant"></param>
        /// <returns></returns>
        public Enseignant ObtenirEnseignant(Enseignant unEnseignant)
        {
            foreach (Enseignant enseignant in listeEnseignant)
            {
            if (enseignant.Equals(unEnseignant))
                return enseignant;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEnseignant"></param>
        /// <returns></returns>
        public bool SiEnseignantPresent(Enseignant unEnseignant)
        {
            foreach (Enseignant enseignant in listeEnseignant)
            {
            if (enseignant.Equals(unEnseignant))
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEnseignant"></param>
        /// <returns></returns>
        public bool AjouterEnseignant(Enseignant unEnseignant)
        {
            if (SiEnseignantPresent(unEnseignant))
            return false;
            listeEnseignant.Add(unEnseignant);
            return SiEnseignantPresent(unEnseignant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEnseignant"></param>
        /// <returns></returns>
        public bool EnleverEnseignant(Enseignant unEnseignant)
        {
            if (!SiEnseignantPresent(unEnseignant))
            return false;
            listeEnseignant.Remove(unEnseignant);
            return !SiEnseignantPresent(unEnseignant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObtenirNombreEnseignant()
        {
            return listeEnseignant.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SiAucunEnseignant()
        {
            return ObtenirNombreEnseignant() == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ViderListeEnseignant()
        {
            if (ObtenirNombreEnseignant() == 0)
            return false;
            listeEnseignant.Clear();
            return SiAucunEnseignant();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Cours[] ObtenirListeCours()
        {
            return listeCours.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unCours"></param>
        /// <returns></returns>
        public Cours ObtenirCours(Cours unCours)
        {
            foreach (Cours cours in listeCours)
            {
            if (cours.Equals(unCours))
                return cours;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unCours"></param>
        /// <returns></returns>
        public bool SiCoursPresent(Cours unCours)
        {
            foreach (Cours cours in listeCours)
            {
            if (cours.Equals(unCours))
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unCours"></param>
        /// <returns></returns>
        public bool AjouterCours(Cours unCours)
        {
            if (SiCoursPresent(unCours))
            return false;
            listeCours.Add(unCours);
            return SiCoursPresent(unCours);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unCours"></param>
        /// <returns></returns>
        public bool EnleverCours(Cours unCours)
        {
            if (!SiCoursPresent(unCours))
            return false;
            listeCours.Remove(unCours);
            return !SiCoursPresent(unCours);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ObtenirNombreCours()
        {
            return listeCours.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SiAucunCours()
        {
            return ObtenirNombreEnseignant() == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ViderListeCours()
        {
            if (ObtenirNombreEnseignant() == 0)
                return false;
            listeEnseignant.Clear();
            return SiAucunEnseignant();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Nom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is Departement) && Nom.Equals((obj as Departement).Nom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Nom.Length;
        }
    }
}
