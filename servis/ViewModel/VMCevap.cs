using servis.Model;
using System;
using System.Collections.Generic;

namespace servis.ViewModel
{
    public class VMCevap
    {
        public int Kimlik { get; set; }
        public string Metin { get; set; }
        public DateTime CevaplamaTarihi { get; set; }
        public Nullable<int> VerildigiSoru_Kimlik { get; set; }
        public Nullable<int> Yazan_Kimlik { get; set; }
        public bool OnayDurumu { get; set; }

        public static VMCevap VeriyiIsle(Cevap tc)
        {
            VMCevap c = new VMCevap()
            {
                Kimlik = tc.Kimlik,
                Metin = tc.Metin,
                CevaplamaTarihi = tc.CevaplamaTarihi,
                VerildigiSoru_Kimlik = tc.VerildigiSoru_Kimlik,
                Yazan_Kimlik = tc.Yazan_Kimlik,
                OnayDurumu = tc.OnayDurumu
            };

            return c;
        }

        public static Cevap VeriyiIsle(VMCevap c)
        {
            Cevap tc = new Cevap()
            {
                Kimlik = c.Kimlik,
                Metin = c.Metin,
                CevaplamaTarihi = c.CevaplamaTarihi,
                VerildigiSoru_Kimlik = c.VerildigiSoru_Kimlik,
                Yazan_Kimlik = c.Yazan_Kimlik,
                OnayDurumu = c.OnayDurumu
            };

            return tc;
        }

        public static List<VMCevap> VeriyiIsle(List<Cevap> tcliste)
        {
            List<VMCevap> CevapListesi = new List<VMCevap>();

            foreach (var Cevap in tcliste)
            {
                CevapListesi.Add(VeriyiIsle(Cevap));
            }

            return CevapListesi;
        }

        public static List<Cevap> VeriyiIsle(List<VMCevap> cliste)
        {
            List<Cevap> CevapListesi = new List<Cevap>();

            foreach (var Cevap in cliste)
            {
                CevapListesi.Add(VeriyiIsle(Cevap));
            }

            return CevapListesi;
        }
    }
}