using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistorialNavegación.Models
{
    class Historial
    {
        protected string path { get; set; }
        protected string query { get; set; }
        protected string name { get; set; }

        public DataTable GetDataTable()
        {
            using (SQLiteConnection cn = new SQLiteConnection("Data Source=" + path + ";Version=3;New=False;Compress=True;"))
            {
                try
                {
                    cn.Open();
                    SQLiteDataAdapter sd = new SQLiteDataAdapter(query, cn);
                    DataTable dt = new DataTable();
                    sd.Fill(dt);
                    return dt;
                }
                catch
                {
                    MessageBox.Show("Error al recopilar info del navegador " + name);
                }
            }
            return null;
        }
    }
}
