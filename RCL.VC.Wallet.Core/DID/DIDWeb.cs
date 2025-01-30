#nullable disable

namespace RCL.VC.Wallet.Core
{
    public class DIDWeb : IDIDWeb
    {
        public DIDDocument CreateDocument(string didWeb, ECJwk rsaJwk)
        {
            DIDDocument didDocument = new DIDDocument();

            List<string> context = new List<string>
            {
                "https://www.w3.org/ns/did/v2",
                "https://w3id.org/security/suites/jws-2020/v1"
            };
            didDocument.context = context;

            didDocument.id = didWeb;

            VerificationMethod verificationMethod = new VerificationMethod
            {
                id = $"{didWeb}#key-1",
                type = "JsonWebKey2020",
                controller = didWeb,
                publicKeyJwk = rsaJwk
            };
            List<VerificationMethod> verificationMethods = new List<VerificationMethod>();
            verificationMethods.Add(verificationMethod);
            didDocument.verificationMethod = verificationMethods;

            List<string> methods = new List<string>
            {
                $"{didWeb}#key-1"
            };

            didDocument.assertionMethod = methods;
            didDocument.authentication = methods;

            return didDocument;
        }
    }
}
