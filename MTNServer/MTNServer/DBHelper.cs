using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace MTNServer
{
    public class DBHelper
    {
        SqlConnection connectionObj;
        public DBHelper()
        {
            connectionObj = new SqlConnection();
            connectionObj.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }
        private void ConnectionOpen()
        {
            connectionObj.Open();
        }
        private void ConnectionClose()
        {
            connectionObj.Close();
        }
        public DataTable GetDataTable(string query)
        {
            try
            {
                DataTable dt = new DataTable("Table");
                ConnectionOpen();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connectionObj);

                adapter.Fill(dt);
                ConnectionClose();
                return dt;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public int SetCertificateInfo(string certs_full_filename, string certs_name, string certs_type, DateTime? certs_not_after, 
            string certs_drive, string certs_ca)
        {
            int nReturn = 0;
            try
            {
                SqlCommand command = new SqlCommand("SP_CERTS_EXECUTE", connectionObj);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@CERTS_FULL_FILENAME", System.Data.SqlDbType.NVarChar).Value = certs_full_filename;
                command.Parameters.Add("@CERTS_NAME", System.Data.SqlDbType.NVarChar).Value = certs_name;
                command.Parameters.Add("@CERTS_TYPE", System.Data.SqlDbType.NVarChar).Value = certs_type;
                command.Parameters.Add("@CERTS_NOT_AFTER", System.Data.SqlDbType.DateTime).Value = certs_not_after;
                command.Parameters.Add("@CERTS_DRIVE", System.Data.SqlDbType.NVarChar).Value = certs_drive;
                command.Parameters.Add("@CERTS_CA", System.Data.SqlDbType.NVarChar).Value = certs_ca;
                command.Parameters.Add("@nReturn", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                ConnectionOpen();
                command.ExecuteNonQuery();
                nReturn = Convert.ToInt32(command.Parameters["@nReturn"].Value);
                ConnectionClose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                nReturn = -1;
            }

            return nReturn;
        }

        public int SetCertificateByte(string certs_full_filename, byte[] byteDer, byte[] byteKey)
        {
            int nReturn = 0;
            try
            {
                SqlCommand command = new SqlCommand("SP_CERTS_UPDATE", connectionObj);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@CERTS_FULL_FILENAME", System.Data.SqlDbType.NVarChar).Value = certs_full_filename;
                command.Parameters.Add("@CERTS_BYTE_DER", System.Data.SqlDbType.VarBinary).Value = byteDer;
                command.Parameters.Add("@CERTS_BYTE_KEY", System.Data.SqlDbType.VarBinary).Value = byteKey;
                command.Parameters.Add("@nReturn", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                ConnectionOpen();
                command.ExecuteNonQuery();
                nReturn = Convert.ToInt32(command.Parameters["@nReturn"].Value);
                ConnectionClose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                nReturn = -1;
            }

            return nReturn;
        }

    }
}