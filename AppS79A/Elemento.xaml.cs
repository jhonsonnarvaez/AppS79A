using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using AppS79A.Models;
using System.IO;

namespace AppS79A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento(int Id)
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            idSeleccionado = Id;
        }
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre = ?, Usuario = ?, " +
                "Contrasenia = ? where Id = ?", nombre, usuario, contrasenia, id);
        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, Nombre.Text, Usuario.Text, Contrasenia.Text, idSeleccionado);
                DisplayAlert("Alerta", "Se actualizo correctamete", "ok");
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", "ERROR "+ex.Message, "ok");
            }
            

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, idSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamete", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR " + ex.Message, "ok");
            }
        }
    }
}