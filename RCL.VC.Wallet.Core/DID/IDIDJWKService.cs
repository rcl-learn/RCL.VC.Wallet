#nullable disable

namespace RCL.VC.Wallet.Core
{
    public interface IDIDJwkService
    {
        public string CreateDID(ECJwk publicJwk);
        public DIDDocument GetDIDDocument(string didJwk);
    }
}
