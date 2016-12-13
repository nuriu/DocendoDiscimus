using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace servis.Model
{
    [DataContract]
    [Table("Yorum")]
    public class Yorum
    {
        [DataMember]
        [Key]
        public int Kimlik { get; set; }

        [DataMember]
        public Kullanici Yapan { get; set; }

        [DataMember]
        public Cevap YapildigiCevap { get; set; }

        [DataMember]
        [Required]
        [StringLength(150)]
        public string Metin { get; set; }
    }
}