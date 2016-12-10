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
