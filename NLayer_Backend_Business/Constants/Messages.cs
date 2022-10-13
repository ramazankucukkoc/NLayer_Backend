using System.Runtime.Serialization;

namespace NLayer_Backend_Business.Constants
{
    public static class Messages
    {
        public static string ProductAddded = "Ürün başarıyla eklendi.";
        public static string ProductDeleted = "Ürün başarıyla silindi.";
        public static string ProductUpdated = "Ürün başarıyla güncellendi.";

        public static string CategoryGetAll = "Kategoriler listesi başarıyla getirildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre Hatalı.";
        public static string SuccessfulLogin = "Login işlemi başarılı.";
        public static string UserAlreadyExists = "Bu Kullanıcı mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu.";

        public static string AuthorizationDenied = "Authorization denied";
    }
}
