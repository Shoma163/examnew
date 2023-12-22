using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace examnew
{
    public class Connection
    {
        public static NpgsqlConnection connection;
        public static ClassUser users;

        public static void Connect(string port, string host, string user, string pass, string database)
        {
            string cs = string.Format("Server = {0}; Port = {1}; User Id = {2}; Password = {3}; Database = {4}", port, host, user, pass, database);
            connection = new NpgsqlConnection(cs);
            connection.Open();
        }

        public static NpgsqlCommand GetCommand(string sql)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = sql;
            return command;
        }

        public static ObservableCollection<ClassUser> classUsers = new ObservableCollection<ClassUser>();
        public static ObservableCollection<ClassProduct> classProducts = new ObservableCollection<ClassProduct>();
        public static ObservableCollection<ClassCategory> classCategories = new ObservableCollection<ClassCategory>();

        public static void SelectUser()
        {
            NpgsqlCommand cmd = GetCommand("select \"Id\",\"Login\",\"Password\",\"FirstName\",\"LastName\",\"Patronymic\", \"Role\" from \"User\"");
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    classUsers.Add(new ClassUser(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
                }
            }
            reader.Close();
        }

        public static void SelectProduct()
        {
            NpgsqlCommand cmd = GetCommand("select \"Id\", \"Category\", \"Name\", \"Composition\", \"Photo\", \"Price\" from \"Product\"");
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    classProducts.Add(new ClassProduct(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                }
            }
            reader.Close();
        }

        public static void SelectCategory()
        {
            NpgsqlCommand cmd = GetCommand("select \"Name\" from \"Category\"");
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    classCategories.Add(new ClassCategory(reader.GetString(0)));
                }
            }
        }
    }
}
