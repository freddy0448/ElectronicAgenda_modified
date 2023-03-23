///contrato
///solo puede tener declaraciones de eventos, metodos y propiedades

public interface IDataLayer
{
    protected void retrieveAllData();
    protected void edit(string row);
    protected void delete();
    protected void insertRow(string name, string lastName, string phoneNumber, string address, string email, string row);
    protected void insertRow(string name, string date, string hour, string address, string row);

    protected void search(string row);

}