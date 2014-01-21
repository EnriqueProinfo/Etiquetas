using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EtiquetasMaster
{
    static class Datos
    {

        private static readonly string connString = Properties.Settings.Default.catalogosConnectionString;

        public static int CopiaReferencia(string origen, string nueva)
        {
            SqlConnection conn = new SqlConnection(connString);
            int Resultado = -1;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CopiaReferencia", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReferenciaOrigen", origen);
                cmd.Parameters.AddWithValue("@ReferenciaNueva", nueva);

                SqlParameter R = cmd.Parameters.Add("@Resultado",SqlDbType.Int);
                R.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return Resultado;
            }
            catch (Exception)
            {
                return 2;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

    }
}
