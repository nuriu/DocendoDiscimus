using servis.Model;
using System.Collections.Generic;

namespace servis.ViewModel
{
    public class VMSoru
    {
        public int Kimlik { get; set; }
        public string Baslik { get; set; }
        public string Metin { get; set; }
        public System.DateTime SorulmaTarihi { get; set; }
        public int Soran_Kimlik { get; set; }

        public static VMSoru VeriyiIsle(Soru ts)
        {
            VMSoru Soru = new VMSoru()
            {
                Kimlik = ts.Kimlik,
                Baslik = ts.Baslik,
                Metin = ts.Metin,
                SorulmaTarihi = ts.SorulmaTarihi,
                Soran_Kimlik = ts.Soran_Kimlik
            };

            return Soru;
        }

        public static Soru VeriyiIsle(VMSoru s)
        {
            Soru TS = new Soru()
            {
                Kimlik = s.Kimlik,
                Baslik = s.Baslik,
                Metin = s.Metin,
                SorulmaTarihi = s.SorulmaTarihi,
                Soran_Kimlik = s.Soran_Kimlik
            };

            return TS;
        }

        public static List<VMSoru> VeriyiIsle(List<Soru> TSliste)
        {
            List<VMSoru> SoruListesi = new List<VMSoru>();

            foreach (var Soru in TSliste)
            {
                SoruListesi.Add(VeriyiIsle(Soru));
            }

            return SoruListesi;
        }

        public static List<Soru> VeriyiIsle(List<VMSoru> sliste)
        {
            List<Soru> SoruListesi = new List<Soru>();

            foreach (var Soru in sliste)
            {
                SoruListesi.Add(VeriyiIsle(Soru));
            }

            return SoruListesi;
        }
    }
}