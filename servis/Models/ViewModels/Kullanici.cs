using servis.Model;
using System.Collections.Generic;

namespace servis.Models.ViewModels
{
    public class Kullanici
    {
        public int Kimlik { get; set; }

        public string Eposta { get; set; }

        public string KullaniciAdi { get; set; }

        public string Isim { get; set; }

        public string Soyisim { get; set; }

        public string Parola { get; set; }

        public bool KullaniciTuru { get; set; }

        public string AvatarLink { get; set; }

        public static Kullanici VeriyiIsle(TKullanici tk)
        {
            Kullanici kullanici = new Kullanici()
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

        public static TKullanici VeriyiIsle(Kullanici k)
        {
            TKullanici TK = new TKullanici()
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

        public static List<Kullanici> VeriyiIsle(List<TKullanici> tkliste)
        {
            List<Kullanici> kullaniciListesi = new List<Kullanici>();

            foreach (var kullanici in tkliste)
            {
                kullaniciListesi.Add(VeriyiIsle(kullanici));
            }

            return kullaniciListesi;
        }

        public static List<TKullanici> VeriyiIsle(List<Kullanici> kliste)
        {
            List<TKullanici> kullaniciListesi = new List<TKullanici>();

            foreach (var kullanici in kliste)
            {
                kullaniciListesi.Add(VeriyiIsle(kullanici));
            }

            return kullaniciListesi;
        }
    }
}