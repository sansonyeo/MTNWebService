using System;
using System.Data;
using System.Linq;

namespace MTNServer
{
    public class DAL
    {
        public static DataTable SelectCertificates(string certs_drive)
        {
            DBHelper dbh = new DBHelper();
            string query = "select * from tb_certs where certs_drive = '" + certs_drive + "'";

            return dbh.GetDataTable(query);
        }

        public static bool[] InsertCertificates(Certificate[] list)
        {
            bool[] result = new bool[list.Count()];
            int[] nRtn = new int[2];

            DBHelper dbh = new DBHelper();

            int i = 0;

            foreach (Certificate c in list)
            {
                nRtn[0] = dbh.SetCertificateInfo(c.certs_full_filename, c.certs_name, c.certs_type, c.certs_not_after, c.certs_drive, c.certs_ca);
                nRtn[1] = dbh.SetCertificateByte(c.certs_full_filename, c.certs_byte_der, c.certs_byte_key);

                foreach (var rtn in nRtn)
                {
                    if (rtn < 0) result[i] = false;
                    else result[i] = true;
                }

                i++;
            }

            return result;
        }

    }
}