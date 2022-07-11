using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AllCarsListed = "Arabalar listelendi.";
        public static string CarListedById = "Araba getirildi.";
        public static string AllCarsListedWithDetails = "Arabalar dto'ya göre listelendi.";
        public static string CarCountLimitExceeded = "Araba sayısı limitine ulaşıldı.";
        public static string CarImageCountLimitExceeded ="Her arabanın en fazla 5 resmi olabilir.";
       public static string AuthorizationDenied = "Erişim engellendi. Yetkiniz olmayabilir!";
        public static string UserRegistered="Kullanıcı kayıt oldu.";
        public static string UserAlreadyExists="Kullanıcı zaten var.";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError="Parola hatası";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string AccessTokenCreated="Token oluşturuldu.";
    }
}
