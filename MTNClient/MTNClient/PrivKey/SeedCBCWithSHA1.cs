using System;
using System.Security.Cryptography;
using Asn1;
using PnPeople.Security;

namespace MTNClient.PrivKey
{
    internal class SeedCBCWithSHA1 : IPrivateKey
    {
        /*
        node            30
        node 0          | 30
        node 0 0        | | 06 : 1.2.410.200004.1.15
        node 0 1        | | 30
        node 0 1 0      | | | 04 : Salt
        node 0 1 1      | | | 02 : Iter
        node 1          | 04 : DATA
        */
        public SeedCBCWithSHA1(Asn1Node node)
            : base(node)
        {
            this.Salt = this.m_origNode.Get<Asn1OctetString>(0, 1, 0).Data;
            this.Iter = this.m_origNode.Get<Asn1Integer    >(0, 1, 1).ToInt32();
            this.Data = this.m_origNode.Get<Asn1OctetString>(1      ).Data;
        }

        public override byte[] GetBytes()
        {
            this.m_origNode.Get<Asn1OctetString>(0, 1, 0).Data  = this.Salt;
            this.m_origNode.Get<Asn1Integer    >(0, 1, 1).Value = new Asn1Integer(this.Iter).Value;
            this.m_origNode.Get<Asn1OctetString>(1      ).Data  = this.Data;

            return this.m_origNode.GetBytes();
        }

        protected override SEED CreateSeed(byte[] password)
        {
            byte[] pdbBytes;

            using (var pdb = new PasswordDeriveBytes(password, this.Salt, "SHA1", this.Iter))
                pdbBytes = pdb.GetBytes(20);

            var seed = new SEED
            {
                ModType  = SEED.MODE.AI_CBC,
                KeyBytes = new byte[16],
                IV       = new byte[16]
            };

            Buffer.BlockCopy(pdbBytes, 0, seed.KeyBytes, 0, 16);

            using (var sha1 = new SHA1CryptoServiceProvider())
                Buffer.BlockCopy(sha1.ComputeHash(pdbBytes, 16, 4), 0, seed.IV, 0, 16);

            return seed;
        }
    }
}
