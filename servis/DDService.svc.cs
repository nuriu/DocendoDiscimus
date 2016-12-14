using servis.Model;
using System.Linq;
using System.Data.Entity;
using servis.Models.ViewModels;

namespace servis
{
    public class DDService : IDDService
    {
        public DDDBEntities db = new DDDBEntities();

        public Kullanici KullaniciBilgileriniGetir(int kimlik)
        {
            try
            {
                TKullanici kullanici = (from k in db.Kullanicilar where k.Kimlik == kimlik select k).SingleOrDefault();

                return Kullanici.VeriyiIsle(kullanici);
            }
            catch
            {
                return null;
            }
        }

        public bool KullaniciBilgileriniGuncelle(int kimlik, string ePosta, string isim, string soyisim, string parola, string avatarLink)
        {
            try
            {
                var kullanici = (from k in db.Kullanicilar where k.Kimlik == kimlik select k).SingleOrDefault();

                if (kullanici != null)
                {
                    kullanici.Eposta = ePosta;
                    kullanici.Isim = isim;
                    kullanici.Soyisim = soyisim;
                    kullanici.Parola = parola;
                    kullanici.AvatarLink = avatarLink;

                    db.Entry(kullanici).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Kullanici KullaniciGirisiYap(string kullaniciAdi, string parola)
        {
            try
            {
                var girisYapanKullanici = (from k in db.Kullanicilar where k.KullaniciAdi == kullaniciAdi && k.Parola == parola select k).SingleOrDefault();

                return Kullanici.VeriyiIsle(girisYapanKullanici);
            }
            catch
            {
                return null;
            }
        }

        public bool KullaniciKayitEt(string ePosta, string kullaniciAdi, string parola)
        {
            try
            {
                var kontrol = (from k in db.Kullanicilar where k.KullaniciAdi == kullaniciAdi select k).SingleOrDefault();

                if (kontrol == null)
                {
                    Kullanici kayitEdilecekKullanici = new Kullanici
                    {
                        Eposta = ePosta,
                        KullaniciAdi = kullaniciAdi,
                        Parola = parola
                    };

                    db.Kullanicilar.Add(Kullanici.VeriyiIsle(kayitEdilecekKullanici));
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
