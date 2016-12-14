using servis.Model;
using System.Collections.Generic;

namespace servis.ViewModel
{
    public class VMKullanici
    {
        public int Kimlik { get; set; }

        public string Eposta { get; set; }

        public string KullaniciAdi { get; set; }

        public string Isim { get; set; }

        public string Soyisim { get; set; }

        public string Parola { get; set; }

        public bool KullaniciTuru { get; set; }

        public string AvatarLink { get; set; }

        public static VMKullanici VeriyiIsle(Kullanici tk)
        {
            VMKullanici kullanici = new VMKullanici()
            {
                Kimlik = tk.Kimlik,
                Eposta = tk.Eposta,
                KullaniciAdi = tk.KullaniciAdi,
                Isim = tk.Isim,
                Soyisim = tk.Soyisim,
                Parola = tk.Parola,
                KullaniciTuru = tk.KullaniciTuru,
                AvatarLink = tk.AvatarLink
            };

            return kullanici;
        }

        public static Kullanici VeriyiIsle(VMKullanici k)
        {
            Kullanici TK = new Kullanici()
            {
                Kimlik = k.Kimlik,
                Eposta = k.Eposta,
                KullaniciAdi = k.KullaniciAdi,
                Isim = k.Isim,
                Soyisim = k.Soyisim,
                Parola = k.Parola,
                KullaniciTuru = k.KullaniciTuru,
                AvatarLink = k.AvatarLink
            };

            return TK;
        }

        public static List<VMKullanici> VeriyiIsle(List<Kullanici> tkliste)
        {
            List<VMKullanici> kullaniciListesi = new List<VMKullanici>();

            foreach (var kullanici in tkliste)
            {
                kullaniciListesi.Add(VeriyiIsle(kullanici));
            }

            return kullaniciListesi;
        }

        public static List<Kullanici> VeriyiIsle(List<VMKullanici> kliste)
        {
            List<Kullanici> kullaniciListesi = new List<Kullanici>();

            foreach (var kullanici in kliste)
            {
                kullaniciListesi.Add(VeriyiIsle(kullanici));
            }

            return kullaniciListesi;
        }
    }
}
