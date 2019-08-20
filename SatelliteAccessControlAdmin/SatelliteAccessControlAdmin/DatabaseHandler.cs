using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace SatelliteAccessControlAdmin
{
    public class DatabaseHandler
    {
        //NB! Change the connection string as needed.
        MySqlConnection DbConnection = new MySqlConnection(@"Server=192.168.1.189; Database=SatelliteAccessControl; User Id=RfidUser; Password=satellite2019; ");   
        MySqlDataAdapter sqlDaAdapter; //Gets data from db and puts it in a DataTable Object
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();
        public string DbState = "Without connection";
        public bool isConnected;

        //Inserts a Person into the database. Returns a boolean status value.
        public bool insertPerson(string fName, string lName, string eMail, string phoneNum)
        {
            string query = "INSERT INTO person(FirstName, LastName, `E-Mail`, PhoneNumber) " +
                "VALUES('" + fName + "', '" + lName + "', '" + eMail + "', '" + phoneNum + "');";
            try
            {
                DbConnection.Open();
                sqlDaAdapter = new MySqlDataAdapter();
                sqlDaAdapter.InsertCommand = new MySqlCommand(query, DbConnection);
                sqlDaAdapter.InsertCommand.ExecuteNonQuery();
                DbState = "Value inserted";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        //Inserts an authorization into the database. Returns a boolean status value.
        public bool insertAuthorization(string personId, string RoomNumber, string StartDate, string EndDate)
        {
            string query = "INSERT INTO authorization(PersonId, RoomNumber, StartDate, EndDate)" +
                "VALUES(" + personId + ",'" + RoomNumber + "','" + StartDate + "','" + EndDate + "');";
            try
            {
                DbConnection.Open();
                sqlDaAdapter = new MySqlDataAdapter();
                sqlDaAdapter.InsertCommand = new MySqlCommand(query, DbConnection);
                sqlDaAdapter.InsertCommand.ExecuteNonQuery();
                DbState = "Value inserted";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        //Selects all persons in database. Returns a datatable containing all persons.
        public DataTable selectPersons()
        {
            dataTable.Clear();
            sqlDaAdapter = new MySqlDataAdapter();
            string query = "SELECT * FROM person;";
            try
            {
                DbConnection.Open();
                sqlDaAdapter.SelectCommand = new MySqlCommand(query, DbConnection);
                sqlDaAdapter.Fill(dataSet);
                sqlDaAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            DbConnection.Close();
            return dataTable;
        }

        //Selects all rooms in database. Returns a datatable containing all rooms.
        public DataTable selectRooms()
        {
            dataTable.Clear();
            sqlDaAdapter = new MySqlDataAdapter();
            string query = "SELECT * from room;";
            try
            {
                DbConnection.Open();
                sqlDaAdapter.SelectCommand = new MySqlCommand(query, DbConnection);
                sqlDaAdapter.Fill(dataSet);
                sqlDaAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            DbConnection.Close();
            return dataTable;
        }

        //Deletes a person in database using a peronId.
        public void deletePerson(string personId)
        {
            string query = "DELETE FROM person WHERE PersonId = " + personId + ";";
            try
            {
                DbConnection.Open();
                sqlDaAdapter = new MySqlDataAdapter();
                sqlDaAdapter.InsertCommand = new MySqlCommand(query, DbConnection);
                sqlDaAdapter.InsertCommand.ExecuteNonQuery();
                DbState = "Value deleted";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
