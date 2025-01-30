#nullable disable

namespace RCL.VC.Wallet.Core
{
    public interface IEC256Operator
    {
        public Keys GenerateKeyPair();
        public ECJwk GetPublicJwk(string publicKeyPem);
    }
}
