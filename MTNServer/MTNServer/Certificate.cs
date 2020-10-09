using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTNServer
{
    public class Certificate
    {
        public string certs_name;
        public string certs_type;
        public DateTime? certs_not_after;
        public string certs_drive;
        public string certs_ca;
        public string certs_full_filename;
        public byte[] certs_byte_der;
        public byte[] certs_byte_key;

        public Certificate()
        {
            certs_name = string.Empty;
            certs_type = string.Empty;
            certs_not_after = new DateTime();
            certs_drive = string.Empty;
            certs_ca = string.Empty;
            certs_full_filename = string.Empty;
            certs_byte_der = new byte[64]; // 64 -> 32
            certs_byte_key = new byte[64]; // 64 -> 32
        }

    }
}