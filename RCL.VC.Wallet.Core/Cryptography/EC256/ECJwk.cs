#nullable disable

using System.Text.Json.Serialization;

namespace RCL.VC.Wallet.Core
{
    public class ECJwk
    {
        [JsonPropertyName("crv")]
        [JsonPropertyOrder(1)]
        public string crv { get; set; }

        [JsonPropertyName("kty")]
        [JsonPropertyOrder(2)]
        public string kty { get; set; }

        [JsonPropertyName("x")]
        [JsonPropertyOrder(3)]
        public string x { get; set; }

        [JsonPropertyName("y")]
        [JsonPropertyOrder(4)]
        public string y { get; set; }
    }
}
