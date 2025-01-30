#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCL.VC.Wallet.Data
{
    [Table(name: "rcl_learn_vc_wallet_holder_did")]
    public class HolderDID
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Holder Id")]
        public int holderId { get; set; }

        [Required]
        [Display(Name = "Holder Username")]
        public string holderUsername { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "DID")]
        public string did { get; set; }
    }
}