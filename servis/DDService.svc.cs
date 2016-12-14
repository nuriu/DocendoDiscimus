﻿using servis.Model;
using servis.ViewModel;
using System.Linq;
using System.Data.Entity;
using System;
using System.Collections.Generic;

namespace servis
{
    public class DDService : IDDService
    {
        public DDDBEntities db = new DDDBEntities();

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
    }
}
