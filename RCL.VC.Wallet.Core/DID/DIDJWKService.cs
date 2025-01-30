#nullable disable

using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace RCL.VC.Wallet.Core
{
    internal class DIDJwkService : IDIDJwkService
    {
        public string CreateDID(ECJwk publicJwk)
        {
            try
            {
                string jwkstr = JsonSerializer.Serialize(publicJwk);
                byte[] bytes = Encoding.UTF8.GetBytes(jwkstr);
                jwkstr = Encoding.UTF8.GetString(bytes);
                jwkstr = Base64UrlEncoder.Encode(jwkstr);
                return $"did:jwk:{jwkstr}";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DIDDocument GetDIDDocument(string didJwk)
        {
            DIDDocument didDocument = new DIDDocument();

            List<string> context = new List<string>
            {
                "https://www.w3.org/ns/did/v1",
                "https://w3id.org/security/suites/jws-2020/v1"
            };
            didDocument.context = context;

            didDocument.id = didJwk;

            string jwkstrEncoded = didJwk.Replace("did:jwk:", string.Empty);
            string jwkstrDecoded = Base64UrlEncoder.Decode(jwkstrEncoded);
            ECJwk jwk = JsonSerializer.Deserialize<ECJwk>(jwkstrDecoded);

            VerificationMethod verificationMethod = new VerificationMethod
            {
                id = $"{didJwk}#0",
                type = "JsonWebKey2020",
                controller = didJwk,
                publicKeyJwk = jwk
            };
            List<VerificationMethod> verificationMethods = new List<VerificationMethod>();
            verificationMethods.Add(verificationMethod);
            didDocument.verificationMethod = verificationMethods;

            List<string> methods = new List<string>
            {
                $"{didJwk}#0"
            };

            didDocument.assertionMethod = methods;
            didDocument.authentication = methods;

            return didDocument;

        }
    }
}
