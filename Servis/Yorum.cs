//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servis
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yorum
    {
        public int Kimlik { get; set; }
        public string Metin { get; set; }
        public int KullaniciKimligi { get; set; }
        public int CevapKimligi { get; set; }
    
        public virtual Cevap Cevap { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
