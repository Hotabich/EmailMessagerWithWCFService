using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using MainService.Model.Interfaces;

namespace MainService.Model.DBRepository
{
    public class DbRepository : IDbRepository
    {
        private string databaseName = @"../../../MainService/AppData/recipients.db";
        public DbRepository()
        {
           SQLiteConnection.CreateFile(databaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            string query = "PRAGMA foreign_keys=on;";
            string queryCreateTable = "CREATE TABLE IF NOT EXISTS recipientsList (id INTEGER NOT NULL PRIMARY KEY, listName TEXT NOT NULL); " +
                "CREATE TABLE IF NOT EXISTS recipients (id INTEGER NOT NULL PRIMARY KEY, recipient TEXT NOT NULL, idrecipientlist INTEGER NOT NULL, FOREIGN KEY(idrecipientlist) REFERENCES recipientsList(id));";
            SQLiteCommand commandPragma = new SQLiteCommand(query, connection);
            SQLiteCommand commandCreateTable =
                new SQLiteCommand(queryCreateTable, connection);
            connection.Open();
            commandPragma.ExecuteNonQuery();
            commandCreateTable.ExecuteNonQuery();
            connection.Close();
        }
        public void AddRecipiant(int id, int idList, string email)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipiant(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipiantsList(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllRecipiantsList()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRecipientsList(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipiant(int id, int idList, string email)
        {
            throw new NotImplementedException();
        }
    }
}
