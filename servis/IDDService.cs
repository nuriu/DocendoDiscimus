using servis.Model;
using servis.ViewModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace servis
{
    [ServiceContract]
    public interface IDDService
    {
        [OperationContract]
        bool KullaniciKayitEt(string ePosta, string kullaniciAdi, string parola);

        [OperationContract]
        VMKullanici KullaniciGirisiYap(string kullaniciAdi, string parola);

        [OperationContract]
        VMKullanici KullaniciBilgileriniGetir(int kimlik);

        [OperationContract]
        bool KullaniciBilgileriniGuncelle(int kimlik, string ePosta, string isim, string soyisim, string parola, string avatarLink);

        [OperationContract]
        bool SoruEkle(int soran, string baslik, string metin);

        [OperationContract]
        VMSoru SoruBilgileriniGetir(int kimlik);

        [OperationContract]
        List<VMSoru> SorulariGetir();

        [OperationContract]
        List<VMSoru> SoruAra(string baslik);

        [OperationContract]
        bool CevapEkle(int eklenecekSorununKimligi, int ekleyeninKimligi, string metin);

        [OperationContract]
        VMCevap CevapBilgileriniGetir(int kimlik);

        [OperationContract]
        List<VMCevap> SorununCevaplariniGetir(int kimlik);

        [OperationContract]
        bool YorumEkle(int eklenecekCevabinKimligi, int ekleyeninKimligi, string metin);

        [OperationContract]
        VMYorum YorumBilgileriniGetir(int kimlik);

        [OperationContract]
        List<VMYorum> CevabinYorumlariniGetir(int kimlik);

        [OperationContract]
        bool SoruyuFavorilereEkle(int kullaniciKimlik, int soruKimlik);

        [OperationContract]
        bool CevabiFavorilereEkle(int kullaniciKimlik, int cevapKimlik);

        [OperationContract]
        bool SoruyuFavorilerdenKaldir(int kullaniciKimlik, int soruKimlik);

        [OperationContract]
        bool CevabiFavorilerdenKaldir(int kullaniciKimlik, int cevapKimlik);

        [OperationContract]
        bool SoruFavorilerdeMi(int kullaniciKimlik, int soruKimlik);

        [OperationContract]
        bool CevapFavorilerdeMi(int kullaniciKimlik, int cevapKimlik);

        [OperationContract]
        bool CevabiOna(int cevapKimlik);

        [OperationContract]
        bool CevapOnayiniKaldir(int cevapKimlik);
    }
}
