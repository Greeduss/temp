
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DbSupport
    {
       
            public static void AddModifyRapStatus(string idEpuap, string nazwaInstytucji, int idRaportu, string stanImportu)
            {
                if (CustomConfig.weryfikacjaNaStronie)
                {
                    SqlConnection sqlconn = new SqlConnection(CustomConfig.db_connectionString);
                    SqlCommand com = new SqlCommand("InsertormodifyRapStatus", sqlconn);
                    com.CommandType = CommandType.StoredProcedure;
                    //com.CommandText = "InsertormodifyRapStatus";//wstawic nazwę procedury  InsertormodifyRapStatus
                    sqlconn.Open();
                    com.Parameters.AddWithValue("id_epuap", idEpuap);
                    com.Parameters.AddWithValue("nazwaintytucji", nazwaInstytucji);
                    //com.Parameters.AddWithValue("NazwaRaportu", TypRaportu);
                    com.Parameters.AddWithValue("id_ReportType", 31);  //DO ZMIANY 
                    com.Parameters.AddWithValue("StanImportu", stanImportu);
                    //com.Connection = sqlconn;
                    com.ExecuteNonQuery();
                    sqlconn.Close();
                }
                else
                    return;
            }
        
    }
}
