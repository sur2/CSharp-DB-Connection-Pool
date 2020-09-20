using DB_Modular_MariaDB.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DB_Modular_MariaDB
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Console.WriteLine("Hello World!");

            DBConnectionPool connPool = DBConnectionPool.GetInstance();
            MariaDB_Connection mariadb_conn = connPool.get_conn();
            mariadb_conn.ExecuteQuery("select * from test");
            connPool.push_conn(mariadb_conn);
            MariaDB_Connection mariadb_conn2 = connPool.get_conn();
            mariadb_conn2.ExecuteQuery("select test_i from test");
        }
    }
}
