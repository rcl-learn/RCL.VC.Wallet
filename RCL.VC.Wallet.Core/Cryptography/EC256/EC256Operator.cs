#nullable disable

using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace RCL.VC.Wallet.Core
{
    internal class EC256Operator : IEC256Operator
    {
        public Keys GenerateKeyPair()
        {
            try
            {
                ECDsa ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);

                Keys keys = new Keys
                {
                    publicKey = ecdsa.ExportSubjectPublicKeyInfoPem(),
                    privateKey = ecdsa.ExportECPrivateKeyPem(),
                };

                return keys;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ECJwk GetPublicJwk(string publicKeyPem)
        {
            try
            {
                ECDsa ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
                ecdsa.ImportFromPem(publicKeyPem);
                ECParameters parameters = ecdsa.ExportParameters(false);

                string x = Base64UrlEncoder.Encode(parameters.Q.X) ;
                string y = Base64UrlEncoder.Encode(parameters.Q.Y);

                ECJwk ecJwk = new ECJwk
                {
                    crv = "P-256",
                    kty = "EC",
                    x = x,
                    y = y,
                };

                return ecJwk;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
