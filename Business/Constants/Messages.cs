using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string FailAddedImageLimit = "resim limiti aşıldı";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Araçlar listelendi";
        public static string CustomerAdded = "MÜŞTERİ EKLENDİ";
        public static string ColorAdded = "Renk eklendi";
        public static string ImagesAdded;
        public static string CarImagesListed;
        public static string CarImageLimitExceded="resim limiti aşıldı";
        public static string CarImageCountOfCarError;
        public static string AuthorizationDenied = "yetkiniz yok";
        public static string UserRegistered;
        public static string SuccessfulLogin;
        public static string PasswordError ="aaasd";
        public static string AccessTokenCreated = "sdads";
        internal static string UserAlreadyExists;
        internal static string UserNotFound;
        internal static string NotExist;
        internal static string AddSingular;
    }
    public static class CarMessages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarsAdded = " Araç Resmi  eklendi";
        public static string CarUpdated = "Araç Bilgileri Güncellendi";
        public static string CarDeleted = "Araç Silindi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
    }
}
