using Servis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servis
{
    public class DDService : IDDService
    {
        public DDDBEntities db = new DDDBEntities();

        public bool KullaniciGirisiYap(string kullaniciAdi, string parola)
        {
            bool durum = false;

            foreach (var kullanici in db.Kullanici)
            {
                if (kullaniciAdi == kullanici.KullaniciAdi && parola == kullanici.Parola)
                {
                    durum = true;
                    break;
                }
            }

            return durum;
        }

        public bool KullaniciKayitEt(string ePosta, string kullaniciAdi, string parola)
        {
            try
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
            catch
            {
                return false;
            }

            return true;
        }
    }
}
