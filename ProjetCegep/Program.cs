using System;
using System.Windows.Forms;
using ProjetCegep.Vues;

/// <summary>
/// 
/// </summary>
namespace ProjetCegep
{
    /// <summary>
    /// 
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGestionCegep());
        }
    }
}
