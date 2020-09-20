using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DB_Modular_MariaDB.DBConnection
{
    class MariaDB_Connection
    {
        private string conn_config = null;
        private MySqlConnection server_conn = null;
        private MySqlCommand cmd = null;
        private MySqlDataReader reader = null;

        public MariaDB_Connection()
        {
            MariaConnect();
            //MariaClose();
        }

        public MariaDB_Connection(string query)
        {
            MariaConnect();
            //MariaClose();
        }

        public void MariaConnect()
        {
            conn_config = "Server=localhost; Port=3307; Database=test; Uid=root; Pwd=????";
            server_conn = new MySqlConnection(conn_config);
            cmd = server_conn.CreateCommand();

            try
            {
                server_conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void ExecuteQuery(string query)
        {
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetValue(i) + " ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }

        public void MariaClose()
        {
            server_conn.Close();
        }

    }

    
}
