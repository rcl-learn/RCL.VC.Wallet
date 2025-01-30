#nullable disable

namespace RCL.VC.Wallet.Core.Test
{
    [TestClass]
    public class CryptographyTest
    {
        private readonly IEC256OperatorService _ec256Operator;

        public CryptographyTest()
        {
            _ec256Operator = (IEC256OperatorService)DependencyResolver.ServiceProvider().GetService(typeof(IEC256OperatorService));
        }

        [TestMethod]
        public void GenerateKeyPairTest()
        {
            try
            {
                Keys  keys = GenerateEC256KeyPair();
                Assert.AreNotEqual(string.Empty,keys?.publicKey ?? string.Empty);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetJwkTest()
        {
            try
            {
                Keys keys = GenerateEC256KeyPair();
                ECJwk ecJwk = _ec256Operator.GetPublicJwk(keys.publicKey);
                Assert.AreNotEqual("", ecJwk?.x ?? string.Empty);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Assert.Fail();
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
