#nullable disable

namespace RCL.VC.Wallet.Core
{
    public interface IDIDJWK
    {
        public string CreateDID(ECJwk jwk);
        public DIDDocument GetDIDDocument(string didJwk);
    }
}
