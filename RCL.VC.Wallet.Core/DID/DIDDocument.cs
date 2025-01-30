#nullable disable

using System.Text.Json.Serialization;

namespace RCL.VC.Wallet.Core
{
    public class DIDDocument
    {
        [JsonPropertyName("@context")]
        [JsonPropertyOrder(1)]
        public List<string> context { get; set; }

        [JsonPropertyOrder(2)]
        public string id { get; set; }

        [JsonPropertyOrder(3)]
        public List<VerificationMethod> verificationMethod { get; set; }

        [JsonPropertyOrder(4)]
        public List<string> assertionMethod { get; set; }

        [JsonPropertyOrder(5)]
        public List<string> authentication { get; set; }
     
    }

    public class VerificationMethod
    {
        [JsonPropertyOrder(1)]
        public string id { get; set; }

        [JsonPropertyOrder(2)]
        public string type { get; set; }

        [JsonPropertyOrder(3)]
        public string controller { get; set; }

        [JsonPropertyOrder(4)]
        public ECJwk publicKeyJwk { get; set; }
    }
}
