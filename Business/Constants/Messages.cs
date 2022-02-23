using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages 
    {
        //public'ler Pascal Case, private cammelCase 
        public static string ProductAdded = "Product is added";
        public static string ProductNameInvalid = "Product Name is invalid";
        internal static string MaintenanceTime = "sistem bakımda"; 
        internal static string ProductsListed ="ürünler listelendi.";   
        internal static string ProductCountOfCategoryError = "bir kategoride en fazla 10 ürün olabilir.";
        internal static string ProductNameAlreadyExists ="Bu isimde zaten başka bir ürün var";
        internal static string CategoryLimitExceed = "Kategori limiti aşıldığı için yeni üürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
