using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diery.Access
{
    
    class Event
    {
        Entri a;
        public Event()
        {
            this.a = new Entri();
        }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Pictures { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }


        public List<Event> Evnts(string sql)
        {
            a.Connection();
            SqlDataReader reader = this.a.Reader(sql);
            List<Event> ev = new List<Event>();
            while (reader.Read())
            {
              Event e = new Event();
                e.Name = reader["Name"].ToString();
                e.Date = reader["Date"].ToString();
                e.Pictures = reader["Pictures"].ToString();
                e.Description = reader["Description"].ToString();
                e.Username = reader["Username"].ToString();
                ev.Add(e);
            }
           
            reader.Close();
            a.ConClose();
            return ev;
        }
        public List<Event> Alllist(string sql)
        {
            return Evnts(sql);
        }
        public List<string> Evant(string sql)
        {
            a.Connection();
            SqlDataReader reader = this.a.Reader(sql);
            List<string> leets = new List<string>();
            while (reader.Read())
            {
                Event e = new Event();
                leets.Add(e.Name = reader["Name"].ToString());
            }
            reader.Close();
            a.ConClose();
            return leets;
            
        }
        public List<string> EventNames()
        {
            return Evant("Select Name from Events where Username='" + Form1.Un + "'");
            
        }
    }


}
   
