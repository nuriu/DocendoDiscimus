using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace servis.Model
{
    [DataContract]
    [Table("Cevap")]
    public class Cevap
    {
        [DataMember]
        [Key]
        public int Kimlik { get; set; }

        [DataMember]
        public Kullanici Yazan { get; set; }

        [DataMember]
        public Soru VerildigiSoru { get; set; }

        [DataMember]
        [Required]
        [StringLength(500)]
        public string Metin { get; set; }

        public virtual ICollection<Yorum> Yorumlar { get; set; }
    }
}