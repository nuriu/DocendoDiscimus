using servis.Model;
using servis.Models.ViewModels;
using System.ServiceModel;

namespace servis
{
    [ServiceContract]
    public interface IDDService
    {
        [OperationContract]
        bool KullaniciKayitEt(string ePosta, string kullaniciAdi, string parola);

        [OperationContract]
        Kullanici KullaniciGirisiYap(string kullaniciAdi, string parola);

        [OperationContract]
        Kullanici KullaniciBilgileriniGetir(int kimlik);

        [OperationContract]
        bool KullaniciBilgileriniGuncelle(int kimlik, string ePosta, string isim, string soyisim, string parola, string avatarLink);
    }
}
