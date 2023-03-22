using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;

namespace SinemaProjesi
{
    public class TabloDoldur
    {
        public  static bool GridDoldur(DataGrid grd,string tabloName)
        {
            sbyte i= 0;
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
            SqlCommand komut = new SqlCommand("Select * From "+ tabloName ,baglanti);
            baglanti.Open();
            komut.Connection = baglanti;
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                baglanti.Dispose();
            }
            if (i > 0) return true; else return false;


        }

    }
}
