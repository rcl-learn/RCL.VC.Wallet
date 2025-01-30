#nullable disable

using System.Text.Json;

namespace RCL.VC.Wallet.Core.Test
{
    [TestClass]
    public class DIDTest
    {
        private readonly IDIDJwkService _didJwk;
        private readonly IEC256OperatorService _ec256Operator;

        public DIDTest()
        {
            _didJwk = (IDIDJwkService)DependencyResolver.ServiceProvider().GetService(typeof(IDIDJwkService));
            _ec256Operator = (IEC256OperatorService)DependencyResolver.ServiceProvider().GetService(typeof (IEC256OperatorService));
        }


        [TestMethod]
        public void CreateDIDJWKTest()
        {
            try
            {
                string didJwk = CreateDIDJwk();
                Assert.IsNotNull(didJwk);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetDIDJWKDocument()
        {
            try
            {
                string didJwk = CreateDIDJwk();
                DIDDocument didDocument = _didJwk.GetDIDDocument(didJwk);
                string diddoc = JsonSerializer.Serialize(didDocument);
                Assert.IsNotNull(didDocument);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        private string CreateDIDJwk()
        {
            try
            {
                Keys keys = GenerateEC256KeyPair();
                ECJwk ecJwk = _ec256Operator.GetPublicJwk(keys.publicKey);
                string didJwk = _didJwk.CreateDID(ecJwk);

                return didJwk;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Keys GenerateEC256KeyPair()
        {
            try
            {
                Keys keys = _ec256Operator.GenerateKeyPair();
                return keys;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
