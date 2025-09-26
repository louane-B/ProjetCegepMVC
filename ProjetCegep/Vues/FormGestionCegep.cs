using System;
using System.Windows.Forms;
using ProjetCegep.Controleurs;
using ProjetCegep.DTOs;

/// <summary>
/// Namespace pour les classes de type Vue.
/// </summary>
namespace ProjetCegep.Vues
{
    /// <summary>
    /// Classe représentant la vue de l'application.
    /// </summary>
   public partial class FormGestionCegep : Form
   {
        #region Constructeur

        /// <summary>
        /// Constructeur du formulaire Gestion Cégep.
        /// </summary>
        public FormGestionCegep()
        {
            InitializeComponent();
            CegepControleur.Instance.ChargerDonneesFichier();
            RemplirListes();
        }

        #endregion Constructeur

        #region OngletEnsengants

        /// <summary>
        /// Méthode de service permettant de mettre à jour les différentes listes d'enseignants.
        /// </summary>
        /// <param name="unDepartement">Le département qui à été sélectionné.</param>
        public void AfficherListeEnseignantGestionEnseignant(DepartementDTO unDepartement)
        {
            lbxEnseignantsSaisie.Items.Clear();
            foreach (EnseignantDTO enseignant in CegepControleur.Instance.ObtenirListeEnseignant(unDepartement))
            {
                lbxEnseignantsSaisie.Items.Add(enseignant.NoEmploye + "  " + enseignant.Prenom + " " + enseignant.Nom);
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un enseignant dans un département qui a été sélectionné dans la liste.
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void BtnAjouterEnseignant_Click(object sender, EventArgs e)
        {
            DepartementDTO monDepartement = null, leDepartementAChercher;

            leDepartementAChercher = new DepartementDTO(nom:cbxDepartementEnseignant.Text);

            if(cbxDepartementEnseignant.Text != "")
               monDepartement = CegepControleur.Instance.ObtenirDepartement(leDepartementAChercher);

            if (monDepartement != null)
            {
                CegepControleur.Instance.AjouterEnseignant(monDepartement, new EnseignantDTO(int.Parse(edtNoEmploye.Text), edtNomEnseignant.Text, edtPrenomEnseignant.Text, edtAdresseEnseignant.Text, edtVilleEnseignant.Text, EdtProvinceEnseignant.Text, edtCodePostalEnseignant.Text, edtTelephoneEnseignant.Text, edtCourrielEnseignant.Text));
                MessageBox.Show("L'enseignant " + int.Parse(edtNoEmploye.Text) + "a été ajouté !!!");
                AfficherListeEnseignantGestionEnseignant(monDepartement);
            }
            else
            {
                MessageBox.Show("Erreur dans la sélection du département.");
            }
        }

        /// <summary>
        /// Méthode de service permettant d'afficher la liste des enseignants après avoir sélectionner un département dans la liste
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void CbxDepartementEnseignant_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartementDTO monDepartement, leDepartementAChercher;

            leDepartementAChercher = new DepartementDTO(nom:cbxDepartementEnseignant.Text);

            monDepartement = CegepControleur.Instance.ObtenirDepartement(leDepartementAChercher);

            AfficherListeEnseignantGestionEnseignant(monDepartement);
        }


        /// <summary>
        /// Méthode de service permettant de modifier un enseignant déjà dans la liste
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void BtnModifierEnseignant_Click(object sender, EventArgs e)
        {
            
            DepartementDTO monDepartement = null, leDepartementAChercher;
            EnseignantDTO unEnseignant;

            leDepartementAChercher = new DepartementDTO(nom:cbxDepartementEnseignant.Text);

            if (cbxDepartementEnseignant.Text != "")
                monDepartement = CegepControleur.Instance.ObtenirDepartement(leDepartementAChercher);

            if (monDepartement != null)
            {
                unEnseignant = CegepControleur.Instance.ObtenirEnseignant(monDepartement, new EnseignantDTO(no:int.Parse(edtNoEmploye.Text)));
                if(unEnseignant.Nom != edtNomEnseignant.Text || 
                   unEnseignant.Prenom != edtPrenomEnseignant.Text ||
                   unEnseignant.Adresse != edtAdresseEnseignant.Text ||
                   unEnseignant.Ville != edtVilleEnseignant.Text ||
                   unEnseignant.Province != EdtProvinceEnseignant.Text ||
                   unEnseignant.CodePostal != edtCodePostalEnseignant.Text ||
                   unEnseignant.Telephone != edtTelephoneEnseignant.Text ||
                   unEnseignant.Courriel != edtCourrielEnseignant.Text
                  )
                        if(CegepControleur.Instance.ModifierEnseignant(monDepartement, new EnseignantDTO(int.Parse(edtNoEmploye.Text), edtNomEnseignant.Text, edtPrenomEnseignant.Text, edtAdresseEnseignant.Text, edtVilleEnseignant.Text, EdtProvinceEnseignant.Text, edtCodePostalEnseignant.Text, edtTelephoneEnseignant.Text, edtCourrielEnseignant.Text)))
                            AfficherListeEnseignantGestionEnseignant(monDepartement);
            }
            else
            {
                MessageBox.Show("Erreur dans la sélection du département.");
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un enseignant de la liste de sont département
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void BtnSupprimerEnseignant_Click(object sender, EventArgs e)
        {
            
            DepartementDTO monDepartement=null, leDepartementAChercher;

            leDepartementAChercher = new DepartementDTO(nom:cbxDepartementEnseignant.Text);

            if (cbxDepartementEnseignant.Text != "")
                monDepartement = CegepControleur.Instance.ObtenirDepartement(leDepartementAChercher);

            if (monDepartement != null)
            {
                if (CegepControleur.Instance.ObtenirEnseignant(monDepartement, new EnseignantDTO(no: int.Parse(edtNoEmploye.Text))) != null)
                {
                    CegepControleur.Instance.SupprimerEnseignant(monDepartement, new EnseignantDTO(int.Parse(edtNoEmploye.Text)));
                    MessageBox.Show("L'enseignant " + int.Parse(edtNoEmploye.Text) + "a été supprimé !!!");
                    AfficherListeEnseignantGestionEnseignant(monDepartement);
                }
            }
            else
            {
                MessageBox.Show("Erreur dans la sélection du département.");
            }
        }

        #endregion OngletEnsengants
        
        #region OngletDepartements

        /// <summary>
        /// Méthode de service permettant d'ajouter un départemetn à la liste des départements du cégep
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void BtnAjouterDepartement_Click(object sender, EventArgs e)
        {
            DepartementDTO unDepartement;

            unDepartement = new DepartementDTO(edtNoDepartement.Text, edtNomDepartement.Text, edtDescriptionDepartement.Text);

            if (CegepControleur.Instance.AjouterDepartement(unDepartement))
            {
                RemplirListes();
                MessageBox.Show(unDepartement.Nom + "\n a bien été crée.");
            }
            else
            {
                MessageBox.Show("Le département existe déjà et n'a pas été crée.");
            }
            Refresh();
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un département de la liste des département du cégep
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void BtnSupprimerGestionDepartement_Click(object sender, EventArgs e)
        {
            DepartementDTO unDepartement;

            unDepartement = new DepartementDTO(nom:edtNomDepartement.Text);

            if (CegepControleur.Instance.SupprimerDepartement(unDepartement))
            {
                RemplirListes();
                MessageBox.Show(unDepartement.Nom + "\n a bien été enlevé.");
            }
            else
                MessageBox.Show("Le département entré n'est pas dans la liste et n'a pas pu être enlevé.");
            Refresh();
        }

        #endregion OngletDepartements

        #region OngletCegep

        /// <summary>
        /// Méthode de service permettant de créer un cégep avec le constructeur paramétré.
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void BtnAjouterCegep_Click(object sender, EventArgs e)
        {
            CegepControleur.Instance.CreerCegep(new CegepDTO(edtNomCegep.Text, edtAdresseCegep.Text, edtVilleCegep.Text, edtProvinceCegep.Text, edtCodePostalCegep.Text, edtTelephoneCegep.Text, edtCourrielCegep.Text));
            MessageBox.Show(edtNomCegep.Text + "\n a bien été crée.");
            
        }

        /// <summary>
        /// Méthode de service permettant de modifier les informations du cégep.
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void BtnModifierCegep_Click(object sender, EventArgs e)
        {
            if (CegepControleur.Instance.ModifierCegep(new CegepDTO(edtNomCegep.Text, edtAdresseCegep.Text, edtVilleCegep.Text, edtProvinceCegep.Text, edtCodePostalCegep.Text, edtTelephoneCegep.Text, edtCourrielCegep.Text)))
                MessageBox.Show(edtNomCegep.Text + "\n a bien été modifié.");
        }

        /// <summary>
        /// Méthode de service permettant de suprimmer l'objet cégep.
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void BtnSupprimerCegep_Click(object sender, EventArgs e)
        {
            string nomCegep = CegepControleur.Instance.ObtenirCegep().Nom;
            if (CegepControleur.Instance.SupprimerCegep())
            {
                MessageBox.Show(nomCegep + " a bien été supprimé.");
                RemplirListes();
            }
        }

        #endregion OngletCegep

        #region Utilitaires

        /// <summary>
        /// Méthode de service permettant de remplir les différentes listes du formulaire.
        /// </summary>
        public void RemplirListes()
        {
            lbxDepartement.Items.Clear();
            lbxDepartementInfoCegep.Items.Clear();
            cbxDepartementEnseignant.Items.Clear();
            if (CegepControleur.Instance.ObtenirCegep() != null)
                foreach (DepartementDTO departement in CegepControleur.Instance.ObtenirListeDepartement())
                {
                    lbxDepartement.Items.Add(departement.Nom);
                    lbxDepartementInfoCegep.Items.Add(departement.Nom);
                    cbxDepartementEnseignant.Items.Add(departement.Nom);
                }
        }

        /// <summary>
        /// Méthode de service permettant d'appeler le menu Quitter lors de la fermeture de l'application par le X.
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void FormGestionCegep_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuitterToolStripMenuItem_Click(this, null);
        }

        /// <summary>
        /// Méthode de service permettant d'enregistrer le cégep et les listes dans un fichier XML.  Par la suite, on quitte l'application 
        /// </summary>
        /// <param name="sender">Objet d'envoi.</param>
        /// <param name="e">Paramètres d'envoi.</param>
        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CegepControleur.Instance.SauvegarderDonneesFichier();
            Application.Exit();
        }

        #endregion Utilitaires
    }
}
