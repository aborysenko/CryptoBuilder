using System;

using CryptoBuilder.Asn1.X509;
using CryptoBuilder.Math;
using CryptoBuilder.Utilities;
using CryptoBuilder.X509.Store;

namespace CryptoBuilder.Cms
{
    /**
    * a basic index for a signer.
    */
    public class SignerID
        : X509CertStoreSelector
    {
        public override int GetHashCode()
        {
            int code = Arrays.GetHashCode(this.SubjectKeyIdentifier);

			BigInteger serialNumber = this.SerialNumber;
			if (serialNumber != null)
            {
                code ^= serialNumber.GetHashCode();
            }

			X509Name issuer = this.Issuer;
            if (issuer != null)
            {
                code ^= issuer.GetHashCode();
            }

			return code;
        }

        public override bool Equals(
            object obj)
        {
			if (obj == this)
				return false;

			SignerID id = obj as SignerID;

			if (id == null)
				return false;

			return Arrays.AreEqual(SubjectKeyIdentifier, id.SubjectKeyIdentifier)
				&& Platform.Equals(SerialNumber, id.SerialNumber)
				&& IssuersMatch(Issuer, id.Issuer);
        }
    }
}
