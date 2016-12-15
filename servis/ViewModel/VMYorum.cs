using servis.Model;
using System;
using System.Collections.Generic;

namespace servis.ViewModel
{
    public class VMYorum
    {
        public int Kimlik { get; set; }
        public string Metin { get; set; }
        public DateTime YapilmaTarihi { get; set; }
        public int Yapan_Kimlik { get; set; }
        public int YapildigiCevap_Kimlik { get; set; }

        public static VMYorum VeriyiIsle(Yorum ty)
        {
            VMYorum y = new VMYorum()
            {
                Kimlik = ty.Kimlik,
                Metin = ty.Metin,
                YapilmaTarihi = DateTime.Now,
                Yapan_Kimlik = ty.Yapan_Kimlik,
                YapildigiCevap_Kimlik = ty.YapildigiCevap_Kimlik
            };

            return y;
        }

        public static Yorum VeriyiIsle(VMYorum y)
        {
            Yorum ty = new Yorum()
            {
                Kimlik = y.Kimlik,
                Metin = y.Metin,
                YapilmaTarihi = DateTime.Now,
                Yapan_Kimlik = y.Yapan_Kimlik,
                YapildigiCevap_Kimlik = y.YapildigiCevap_Kimlik
            };

            return ty;
        }

        public static List<VMYorum> VeriyiIsle(List<Yorum> tyliste)
        {
            List<VMYorum> YorumListesi = new List<VMYorum>();

            foreach (var yorum in tyliste)
            {
                YorumListesi.Add(VeriyiIsle(yorum));
            }

            return YorumListesi;
        }

        public static List<Yorum> VeriyiIsle(List<VMYorum> cliste)
        {
            List<Yorum> YorumListesi = new List<Yorum>();

            foreach (var yorum in cliste)
            {
                YorumListesi.Add(VeriyiIsle(yorum));
            }

            return YorumListesi;
        }
    }
}