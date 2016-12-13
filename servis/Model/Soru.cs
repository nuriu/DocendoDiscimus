using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace servis.Model
{
    [DataContract]
    [Table("Soru")]
    public class Soru
    {
        [DataMember]
        [Key]
        public int Kimlik { get; set; }

        [DataMember]
        public Kullanici Soran { get; set; }

        [DataMember]
        [Required]
        [StringLength(100)]
        public string Baslik { get; set; }

        [DataMember]
        [Required]
        [StringLength(1500)]
        public string Metin { get; set; }

        [DataMember]
        public virtual ICollection<Cevap> Cevaplar { get; set; }
    }
}