using CryptoBuilder.Asn1;

namespace CryptoBuilder.Asn1.Misc
{
    public class VerisignCzagExtension
        : DerIA5String
    {
        public VerisignCzagExtension(DerIA5String str)
			: base(str.GetString())
        {
        }

        public override string ToString()
        {
            return "VerisignCzagExtension: " + this.GetString();
        }
    }
}
