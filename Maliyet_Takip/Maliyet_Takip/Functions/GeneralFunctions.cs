using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maliyet_Takip.Functions
{
    public static class GeneralFunctions
    {
        public static long GetRowId(this GridView tablo)
        {
            if (tablo.FocusedRowHandle > -1)
            {
                return (long)tablo.GetFocusedRowCellValue("Id");
            }

            return -1;
        }

        public static void ShowGridPreview(this GridControl grid)
        {
            if (!grid.IsPrintingAvailable)
            {
                Mesajlar mesaj = new Mesajlar();
                mesaj.Hata("Yazdırma Ekranı Açılamadı");
                mesaj = null;
                return;
            }

            grid.ShowPrintPreview();
        }
        public static void SagMenuGoster(this MouseEventArgs e, PopupMenu sagMenu)
        {
            if (e.Button != MouseButtons.Right) return;
            sagMenu.ShowPopup(Control.MousePosition);
        }


        public static List<string> YazicilariListele()
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().ToList();
        }

        public static string DefaultYazici()
        {
            var settings = new PrinterSettings();
            return settings.PrinterName;
        }

        public static void AppSettingsWrite(string key, string value)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void RowFocus(this GridView tablo, int rowhandle)
        {
            if (rowhandle <= 0) return;
            if (rowhandle == tablo.RowCount - 1)
                tablo.FocusedRowHandle = rowhandle;
            else
                tablo.FocusedRowHandle = rowhandle - 1;

        }
        public static void RowFocus(this GridView tablo, string aranacakKolon, object aranacakDeger)
        {
            var rowHandle = 0;
            for (int i = 0; i < tablo.RowCount; i++)
            {
                var bulunanDeger = tablo.GetRowCellValue(i, aranacakKolon);
                if (aranacakDeger.Equals(bulunanDeger)) rowHandle = i;

            }
            tablo.FocusedRowHandle = rowHandle;
        }
        public static string RandomDegerUret(int minValue, int count)
        {
            var random = new Random();
            const string karakterTablosu = "0123456789ABCDEFGHIJKLMNOPQRSTUWXVYZabcdefghijklmnopqrsdtuwxvz+-/.?";
            string sonuc = null;
            for (int i = 0; i < count; i++)
                sonuc += karakterTablosu[random.Next(minValue, karakterTablosu.Length - 1)].ToString();
            return sonuc;
        }

        public static long IdOlustur()
        {
            string SifirEkle(string deger)
            {
                if (deger.Length == 1)
                {
                    return "0" + deger;
                }
                return deger;
            }
            string UcBasamakYap(string deger)
            {
                switch (deger.Length)
                {
                    case 1:
                        return "00" + deger;
                    case 2:
                        return "0" + deger;

                }
                return deger;
            }
            string Id()
            {
                var yil = SifirEkle(DateTime.Now.Year.ToString());
                var ay = SifirEkle(DateTime.Now.Month.ToString());
                var gun = SifirEkle(DateTime.Now.Day.ToString());
                var saat = SifirEkle(DateTime.Now.Hour.ToString());
                var dakika = SifirEkle(DateTime.Now.Minute.ToString());
                var saniye = SifirEkle(DateTime.Now.Second.ToString());
                var miliSaniye = UcBasamakYap(DateTime.Now.Millisecond.ToString());
                var randomSayi = SifirEkle(new Random().Next(0, 99).ToString());
                return yil + ay + gun + saat + dakika + saniye + miliSaniye + randomSayi;
            }
            return long.Parse(Id());

        }

        public static SecureString ConvertToSecureString(this string value)
        {
            var secureString = new SecureString();
            if (value.Length > 0)
                value.ToCharArray().ForEach(x => secureString.AppendChar(x));
            secureString.MakeReadOnly();


            return secureString;
        }

        public static string ConvertToUnSecureString(this SecureString value)
        {
            var result = Marshal.SecureStringToBSTR(value);
            return Marshal.PtrToStringAuto(result);
        }

        public static string Encrypt(this string sifrelenecekVeri, string anahtar)
        {
            if (sifrelenecekVeri == null) return null;
            var sifrelenecekVeriToByte = Encoding.UTF8.GetBytes(sifrelenecekVeri);
            var anahtarToByte = Encoding.UTF8.GetBytes(anahtar);

            anahtarToByte = SHA256.Create().ComputeHash(anahtarToByte);

            byte[] sifreliVeri = null;

            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (var ms = new MemoryStream())
            {
                using (var aes = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(anahtarToByte, saltBytes, 1000);

                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);

                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(sifrelenecekVeriToByte, 0, sifrelenecekVeriToByte.Length);
                        cs.Close();
                    }

                    sifreliVeri = ms.ToArray();
                }
            }

            return Convert.ToBase64String(sifreliVeri);
        }

        public static string Decrypt(this string sifresiCozulecekVeri, string anahtar)
        {
            if (sifresiCozulecekVeri == null) return null;
            var sifresiCozulecekVeriToByte = Convert.FromBase64String(sifresiCozulecekVeri);
            var anahtarToByte = Encoding.UTF8.GetBytes(anahtar);

            anahtarToByte = SHA256.Create().ComputeHash(anahtarToByte);

            byte[] sifresiCozulmusVeri;
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (var ms = new MemoryStream())
            {
                using (var aes = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(anahtarToByte, saltBytes, 1000);

                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);
                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(sifresiCozulecekVeriToByte, 0, sifresiCozulecekVeriToByte.Length);
                        cs.Close();
                    }

                    sifresiCozulmusVeri = ms.ToArray();
                }
            }

            return Encoding.UTF8.GetString(sifresiCozulmusVeri);
        }
    }
}
