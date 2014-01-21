using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;

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

                Resultado = Convert.ToInt32(R.Value);

                return Resultado;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
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


        public static int EjecutaPaquete(string NombrePaquete, string RutaHojaExcel) {

            try
            {
                DTSExecResult r;

                Microsoft.SqlServer.Dts.Runtime.Application aplicacion = new Microsoft.SqlServer.Dts.Runtime.Application();
                Package paquete = aplicacion.LoadPackage(NombrePaquete, null);

                MessageBox.Show(paquete.Variables["RutaHojaExcel"].Value.ToString());
                paquete.Variables["RutaHojaExcel"].Value = RutaHojaExcel;
                MessageBox.Show(paquete.Variables["RutaHojaExcel"].Value.ToString());

                try
                {
                    r = paquete.Execute();
                    if(r == DTSExecResult.Failure || r == DTSExecResult.Canceled) {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }

                finally
                {
                    paquete = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

    }
}
