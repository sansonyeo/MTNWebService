using System;
using System.Collections.Generic;
using System.Data;

namespace MTNClient
{
    class DAL
    {
        WebServiceRef.WebService1 serviceObj;

        public DAL()
        {
            serviceObj = new WebServiceRef.WebService1();

        }
        public DataTable SelectCertificate(string certs_drive)
        {
            try
            {
                return serviceObj.SelectCertificates(certs_drive);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public bool[] InsertCertificate(List <WebServiceRef.Certificate> list)
        {
            try
            {
                return serviceObj.InsertCertificates(list.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
