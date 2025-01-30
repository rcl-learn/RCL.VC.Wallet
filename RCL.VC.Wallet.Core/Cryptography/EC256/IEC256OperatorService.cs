#nullable disable

namespace RCL.VC.Wallet.Core
{
    public interface IEC256OperatorService
    {
        public Keys GenerateKeyPair();
        public ECJwk GetPublicJwk(string publicKeyPem);
    }
}
