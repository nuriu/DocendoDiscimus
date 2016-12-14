using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace servis.Model
{
    [DataContract]
    [Table("Soru")]
    public class TSoru
    {
        public TSoru()
        {
            this.Cevaplar = new HashSet<TCevap>();
        }

        [DataMember]
        [Key]
        public int Kimlik { get; set; }

        [DataMember]
        public TKullanici Soran { get; set; }

        [DataMember]
        [Required]
        [StringLength(100)]
        public string Baslik { get; set; }

        [DataMember]
        [Required]
        [StringLength(1500)]
        public string Metin { get; set; }

        [DataMember]
        [Required]
        public DateTime SorulmaTarihi { get; set; }

        public virtual ICollection<TCevap> Cevaplar { get; set; }
    }
}