using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servis
{
    [ServiceContract]
    public interface IDDService
    {
        [OperationContract]
        bool KullaniciKayitEt(string ePosta, string kullaniciAdi, string parola);

        [OperationContract]
        bool KullaniciGirisiYap(string kullaniciAdi, string parola);
    }
}
