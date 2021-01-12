using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diery.Access
{
    class Entri
    {
         
        SqlConnection a;
        SqlCommand com;
        public Entri()
        {
            this.a = new SqlConnection(ConfigurationManager.ConnectionStrings["Dayeri"].ConnectionString);
            //a.Open();
        }
        public void Connection()
        {
            a.Open();
        }
        public void Execute(string sql)
        {
            this.com = new SqlCommand(sql, this.a);
            com.ExecuteNonQuery();
        }
        public SqlDataReader Reader(string sql)
        {
            
            this.com = new SqlCommand(sql, this.a);
            SqlDataReader reader = this.com.ExecuteReader();
            return reader;

        }

        public void ConClose()
        {
            this.a.Close();
        }
    }
}

