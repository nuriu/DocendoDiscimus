using servis.Model;
using servis.ViewModel;
using System.Linq;
using System.Data.Entity;
using System;
using System.Collections.Generic;

namespace servis
{
    public class DDService : IDDService
    {
        public DDBEntities db = new DDBEntities();

        #region KULLANICI
        public VMKullanici KullaniciBilgileriniGetir(int kimlik)
        {
            try
            {
                var kullanici = (from k in db.Kullanici where k.Kimlik == kimlik select k).SingleOrDefault();

                return VMKullanici.VeriyiIsle(kullanici);
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
                var kullanici = (from k in db.Kullanici where k.Kimlik == kimlik select k).SingleOrDefault();

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

        public VMKullanici KullaniciGirisiYap(string kullaniciAdi, string parola)
        {
            try
            {
                var girisYapanKullanici = (from k in db.Kullanici where k.KullaniciAdi == kullaniciAdi && k.Parola == parola select k).SingleOrDefault();

                return VMKullanici.VeriyiIsle(girisYapanKullanici);
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
                var kontrol = (from k in db.Kullanici where k.KullaniciAdi == kullaniciAdi select k).SingleOrDefault();

                if (kontrol == null)
                {
                    Kullanici kayitEdilecekKullanici = new Kullanici
                    {
                        Eposta = ePosta,
                        KullaniciAdi = kullaniciAdi,
                        Parola = parola
                    };

                    db.Kullanici.Add(kayitEdilecekKullanici);
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region SORU
        public bool SoruEkle(int soran, string baslik, string metin)
        {
            try
            {
                Soru eklenecekSoru = new Soru
                {
                    Soran_Kimlik = soran,
                    Baslik = baslik,
                    Metin = metin,
                    SorulmaTarihi = DateTime.Now
                };

                db.Soru.Add(eklenecekSoru);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public VMSoru SoruBilgileriniGetir(int kimlik)
        {
            try
            {
                var soru = (from s in db.Soru where s.Kimlik == kimlik select s).SingleOrDefault();

                return VMSoru.VeriyiIsle(soru);
            }
            catch
            {
                return null;
            }
        }

        public List<VMSoru> SorulariGetir()
        {
            return VMSoru.VeriyiIsle(db.Soru.ToList());
        }

        public bool SoruyuFavorilereEkle(int kullaniciKimlik, int soruKimlik)
        {
            try
            {
                var kullanici = (from k in db.Kullanici where k.Kimlik == kullaniciKimlik select k).SingleOrDefault();
                var soru = (from s in db.Soru where s.Kimlik == soruKimlik select s).SingleOrDefault();

                if (kullanici != null && soru != null)
                {
                    FavoriSorular fs = new FavoriSorular
                    {
                        KullaniciKimlik = kullaniciKimlik,
                        SoruKimlik = soruKimlik
                    };

                    db.FavoriSorular.Add(fs);
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

        public bool SoruyuFavorilerdenKaldir(int kullaniciKimlik, int soruKimlik)
        {
            try
            {
                var kullanici = (from k in db.Kullanici where k.Kimlik == kullaniciKimlik select k).SingleOrDefault();
                var soru = (from s in db.Soru where s.Kimlik == soruKimlik select s).SingleOrDefault();

                if (kullanici != null && soru != null)
                {
                    FavoriSorular fs = new FavoriSorular
                    {
                        KullaniciKimlik = kullaniciKimlik,
                        SoruKimlik = soruKimlik
                    };

                    db.FavoriSorular.Remove(fs);
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

        public bool SoruFavorilerdeMi(int kullaniciKimlik, int soruKimlik)
        {
            try
            {
                var soru = (from fs in db.FavoriSorular where fs.SoruKimlik == soruKimlik && fs.KullaniciKimlik == kullaniciKimlik select fs).SingleOrDefault();

                if (soru != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region CEVAP
        public bool CevapEkle(int eklenecekSorununKimligi, int ekleyeninKimligi, string metin)
        {
            try
            {
                Cevap eklenecekCevap = new Cevap
                {
                    VerildigiSoru_Kimlik = eklenecekSorununKimligi,
                    Yazan_Kimlik = ekleyeninKimligi,
                    Metin = metin,
                    CevaplamaTarihi = DateTime.Now,
                    OnayDurumu = false
                };

                db.Cevap.Add(eklenecekCevap);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public VMCevap CevapBilgileriniGetir(int kimlik)
        {
            try
            {
                var cevap = (from c in db.Cevap where c.Kimlik == kimlik select c).SingleOrDefault();

                return VMCevap.VeriyiIsle(cevap);
            }
            catch
            {
                return null;
            }
        }

        public List<VMCevap> SorununCevaplariniGetir(int kimlik)
        {
            return VMCevap.VeriyiIsle((from c in db.Cevap where c.VerildigiSoru_Kimlik == kimlik select c).ToList());
        }

        public bool CevabiFavorilereEkle(int kullaniciKimlik, int cevapKimlik)
        {
            try
            {
                var kullanici = (from k in db.Kullanici where k.Kimlik == kullaniciKimlik select k).SingleOrDefault();
                var cevap = (from c in db.Cevap where c.Kimlik == cevapKimlik select c).SingleOrDefault();

                if (kullanici != null && cevap != null)
                {
                    FavoriCevaplar fc = new FavoriCevaplar
                    {
                        KullaniciKimlik = kullaniciKimlik,
                        CevapKimlik = cevapKimlik
                    };

                    db.FavoriCevaplar.Add(fc);
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

        public bool CevabiFavorilerdenKaldir(int kullaniciKimlik, int cevapKimlik)
        {
            try
            {
                var kullanici = (from k in db.Kullanici where k.Kimlik == kullaniciKimlik select k).SingleOrDefault();
                var cevap = (from c in db.Cevap where c.Kimlik == cevapKimlik select c).SingleOrDefault();

                if (kullanici != null && cevap != null)
                {
                    FavoriCevaplar fc = new FavoriCevaplar
                    {
                        KullaniciKimlik = kullaniciKimlik,
                        CevapKimlik = cevapKimlik
                    };

                    db.FavoriCevaplar.Remove(fc);
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

        public bool CevabiOna(int cevapKimlik)
        {
            try
            {
                var cevap = (from c in db.Cevap where c.Kimlik == cevapKimlik select c).SingleOrDefault();

                if (cevap != null)
                {
                    cevap.OnayDurumu = true;

                    db.Entry(cevap).State = EntityState.Modified;
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

        public bool CevapOnayiniKaldir(int cevapKimlik)
        {
            try
            {
                var cevap = (from c in db.Cevap where c.Kimlik == cevapKimlik select c).SingleOrDefault();

                if (cevap != null)
                {
                    cevap.OnayDurumu = false;

                    db.Entry(cevap).State = EntityState.Modified;
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

        public bool CevapFavorilerdeMi(int kullaniciKimlik, int cevapKimlik)
        {
            try
            {
                var cevap = (from fc in db.FavoriCevaplar where fc.CevapKimlik == cevapKimlik && fc.KullaniciKimlik == kullaniciKimlik select fc).SingleOrDefault();

                if (cevap != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region YORUM
        public bool YorumEkle(int eklenecekCevabinKimligi, int ekleyeninKimligi, string metin)
        {
            try
            {
                Yorum eklenecekYorum = new Yorum
                {
                    Yapan_Kimlik = ekleyeninKimligi,
                    YapildigiCevap_Kimlik = eklenecekCevabinKimligi,
                    YapilmaTarihi = DateTime.Now,
                    Metin = metin
                };

                db.Yorum.Add(eklenecekYorum);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public VMYorum YorumBilgileriniGetir(int kimlik)
        {
            try
            {
                var yorum = (from y in db.Yorum where y.Kimlik == kimlik select y).SingleOrDefault();

                return VMYorum.VeriyiIsle(yorum);
            }
            catch
            {
                return null;
            }
        }

        public List<VMYorum> CevabinYorumlariniGetir(int kimlik)
        {
            return VMYorum.VeriyiIsle((from y in db.Yorum where y.YapildigiCevap_Kimlik == kimlik select y).ToList());
        }
        #endregion
    }
}
