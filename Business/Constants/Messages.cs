using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // Bu classı mesajları sürekli string olarak yazmamak için oluşturduk. Sürekli string olarak elle yazıp parametre göndermek pek sağlıklı bir yaklaşım değil. Bu şekilde kullanımı daha doğru.
        public static string CarAdded = "Araç Eklendi!";
        public static string InvalidCar = "Geçersiz";
        public static string CarDeleted = "Araç Silindi!";
        public static string RentalAccepted = "Araç kiralandı!";
        public static string RentalDeclined = "Kiralama Başarısız!";
        public static string CarInUse = "Araç Kullanımda!";

        // *** Burada şöyle güzel bir şey var. Public olan fieldlar pascalcase olurmuş diğerleri camelcase.
    }
}
