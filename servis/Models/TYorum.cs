using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace servis.Model
{
    [DataContract]
    [Table("Yorum")]
    public class TYorum
    {
        [DataMember]
        [Key]
        public int Kimlik { get; set; }

        [DataMember]
        public TKullanici Yapan { get; set; }

        [DataMember]
        public TCevap YapildigiCevap { get; set; }

        [DataMember]
        [Required]
        [StringLength(150)]
        public string Metin { get; set; }

        [DataMember]
        [Required]
        public DateTime YapilmaTarihi { get; set; }
    }
}