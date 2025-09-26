using System;
using System.Collections.Generic;

/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace ProjetCegep.Modeles
{
    /// <summary>
    /// Classe représentant un cours.
    /// </summary>
    public class Cours
    {
        #region AttributsProprietes

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
        private DateTime dateDebut;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDebut
        {
            get { return dateDebut; }
            set { dateDebut = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime dateFin;
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateFin
        {
            get { return dateFin; }
            set { dateFin = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Enseignant enseignant;

        /// <summary>
        /// 
        /// </summary>
        private List<Etudiant> listeEtudiant;

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// 
        /// </summary>
        public Cours(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unNo"></param>
        /// <param name="unNom"></param>
        /// <param name="uneDescription"></param>
        public Cours(string unNo, string unNom, string uneDescription)
        {
            No = unNo;
            Nom = unNom;
            Description = uneDescription;
            DateDebut = DateTime.Now;
            DateFin = new DateTime(1900, 1, 1);
            enseignant = new Enseignant();
            listeEtudiant = new List<Etudiant>();
        }

        #endregion Constructeurs

        #region MethodesService

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
        public Enseignant ObtenirEnseignant()
        {
            return enseignant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEnseignant"></param>
        /// <returns></returns>
        public bool InitialiserEnseignant(Enseignant unEnseignant)
        {
            enseignant = unEnseignant;
            return enseignant != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unEnseignant"></param>
        /// <returns></returns>
        public bool EnleverEnseignant(Enseignant unEnseignant)
        {
            enseignant = null;
            return enseignant == null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SiAucunEnseignant()
        {
            return enseignant == null;
        }

        #endregion MethodesService

        #region Overrides

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
            return (obj != null) && (obj is Cours) && Nom.Equals((obj as Cours).Nom);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Nom.Length;
        }

        #endregion Overrides
    }
}
