﻿using Servis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data.Entity;
using System.Text;

namespace Servis
{
    public class DDService : IDDService
    {
        public DDDBEntities db = new DDDBEntities();

        public Kullanici KullaniciBilgileriniGetir(int kimlik)
        {
            try
            {
                Kullanici kullanici = (from k in db.Kullanici where k.Kimlik == kimlik select k).SingleOrDefault();

                return kullanici;
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

        public int KullaniciGirisiYap(string kullaniciAdi, string parola)
        {
            try
            {
                int kontrol = (from k in db.Kullanici where k.KullaniciAdi == kullaniciAdi && k.Parola == parola select k.Kimlik).SingleOrDefault();

                return kontrol;
            }
            catch
            {
                return 0;
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
    }
}
