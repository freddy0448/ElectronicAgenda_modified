namespace ElectronicAgenda_modified.DataLayer.Core
{
    using Microsoft.Data.SqlClient;
    ///esta clase al ser abstracta, no puede ser instanciada y esta disenada para ser heredada por subclases que 
    ///implementaran o sobreescribiran los metodos, objetos, etc.
    ///son completamente implementadas o parcialmente implementadas
    ///puede tener constructor
    public abstract class principalDataLayer 
    {
        protected SqlConnection sqlConnection = new SqlConnection();
        protected  string connectionString = "Data Source=LAPTOP-6SLH18HM;Initial Catalog=final_project; Integrated Security=True";
        protected void closeConnection()
        {
            sqlConnection.Close();
        }

        
    }
}