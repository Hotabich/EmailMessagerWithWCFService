﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;
using MainService.Model.Interfaces;
using MainService.Model.DbModels;

namespace MainService.Model.DBRepository
{
    public class DbRepository : IDbRepository
    {
        private string databaseName = @"../../../MainService/AppData/recipients.db";
        SQLiteConnection connection;
        public DbRepository()
        {
            if (!File.Exists(databaseName))
            {
                SQLiteConnection.CreateFile(databaseName);
            }
            connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            CreateTables();
        }

        private void CreateTables()
        {            
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
        public void AddRecipiant(int idList, string email)
        {
            string query = "INSERT INTO 'recipients'('recipient','idrecipientlist') VALUES('"+email+"','"+idList+"');";
            using (SQLiteCommand command=new SQLiteCommand(query,connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddRecipiantList(string listName)
        {
            string query = "INSERT INTO 'recipientsList'('listName') VALUES('" + listName +"');";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteRecipiant(int id)
        {
            string query = "DELETE FROM 'recipients' WHERE id="+id+";";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteRecipiantsList(int id)
        {
            string query = "DELETE FROM 'recipientsList' WHERE id=" + id + ";" + "DELETE FROM 'recipients' WHERE idrecipientlist=" + id + ";";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<RecipiantList> GetAllRecipiantsList()
        {
            List<RecipiantList> allRecipiant = new List<RecipiantList>();
            string query = "SELECT * FROM 'recipientsList';";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                DbDataReader reader = command.ExecuteReader();
                foreach (DbDataRecord item in reader)
                {
                    allRecipiant.Add(new RecipiantList(Convert.ToInt32(item["id"]), item["listName"].ToString()));
                }
                reader.Close();
                connection.Close();
            }
            return allRecipiant;
        }

        public List<Recipiant> GetRecipientsList(int id)
        {
            List<Recipiant> recipiantList = new List<Recipiant>();
            string query = "SELECT * FROM 'recipients' WHERE idrecipientlist="+id+";";
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                
                SQLiteDataReader reader = command.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    recipiantList.Add(new Recipiant(Convert.ToInt32(record["id"]), Convert.ToInt32(record["idrecipientlist"]), record["recipient"].ToString()));
                }
                connection.Close();
            }
            return recipiantList;
        }

        public void UpdateRecipiant(int id, int idList, string email)
        {
            string query = "UPDATE 'recipients' SET recipient="+email+ ", idrecipientlist="+idList+" WHERE id="+id+";";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
