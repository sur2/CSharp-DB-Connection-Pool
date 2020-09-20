using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Modular_MariaDB.DBConnection
{
    class DBConnectionPool
    {
        Queue<MariaDB_Connection> conn_list = new Queue<MariaDB_Connection>();
        private static DBConnectionPool dbConnectionPool = null;

        public static DBConnectionPool GetInstance()
        {
            if (dbConnectionPool == null)
            {
                dbConnectionPool = new DBConnectionPool();
            }
            return dbConnectionPool;
        }

        public MariaDB_Connection get_conn()
        {
            MariaDB_Connection conn = null;
            lock (dbConnectionPool)
            {
                if (conn_list.Count() > 0)
                {
                    conn = conn_list.Dequeue();
                }
                else
                {
                    conn = new MariaDB_Connection();
                }
            }
            return conn;
        }
        public void push_conn(MariaDB_Connection conn)
        {
            lock (dbConnectionPool)
            {
                conn_list.Enqueue(conn);
            }
        }
    }
}
