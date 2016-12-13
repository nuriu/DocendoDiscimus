namespace servis.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    [Table("Kullanici")]
    public class Kullanici
    {
        [DataMember]
        [Key]
        public int Kimlik { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Eposta { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Isim { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Soyisim { get; set; }

        [DataMember]
        [Required]
        [StringLength(64)]
        public string Parola { get; set; }

        [DataMember]
        public bool KullaniciTuru { get; set; }

        [DataMember]
        [StringLength(250)]
        public string AvatarLink { get; set; }

        /*
        public virtual ICollection<Soru> SorduguSorular { get; set; }

        public virtual ICollection<Cevap> VerdigiCevaplar { get; set; }

        public virtual ICollection<Yorum> YaptigiYorumlar { get; set; }
        */
    }
}
