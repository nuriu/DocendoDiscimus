using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace servis.Model
{
    [DataContract]
    [Table("Cevap")]
    public class TCevap
    {
        public TCevap()
        {
            this.Yorumlar = new HashSet<TYorum>();
        }

        [DataMember]
        [Key]
        public int Kimlik { get; set; }

        [DataMember]
        public TKullanici Yazan { get; set; }

        [DataMember]
        public TSoru VerildigiSoru { get; set; }

        [DataMember]
        [Required]
        [StringLength(500)]
        public string Metin { get; set; }

        [DataMember]
        [Required]
        public DateTime CevaplamaTarihi { get; set; }

        public virtual ICollection<TYorum> Yorumlar { get; set; }
    }
}