using ProjetCegep.Modeles;

/// <summary>
/// Namespace pour les objets de type DTO.
/// </summary>
namespace ProjetCegep.DTOs
{
    /// <summary>
    /// Classe de DTO pour un département.
    /// </summary>
    public class DepartementDTO
    {
        /// <summary>
        /// Propriété représentant le numéro du département.
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// Propriété représentant le nom du département.
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="no"></param>
        /// <param name="nom"></param>
        /// <param name="description"></param>
        public DepartementDTO(string no="", string nom="", string description="")
        {
            No = no;
            Nom = nom;
            Description = description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leDepartement"></param>
        public DepartementDTO(Departement leDepartement)
        {
            No = leDepartement.No;
            Nom = leDepartement.Nom;
            Description = leDepartement.Description;
        }
    }
}
