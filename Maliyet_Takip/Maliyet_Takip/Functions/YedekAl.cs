using System;
using System.Windows.Forms;

namespace Maliyet_Takip.Functions
{
    public class YedekAl
    {
        Mesajlar mesaj = new Mesajlar();
        Baglanti baglan = Baglanti.NesneVer();
        public bool Yedekle()
        {
            try
            {

                var dr = mesaj.EvetSeciliEvetHayir("Yedekleme işlemini onaylıyor musunuz?", "Uyarı");
                if (dr == DialogResult.Yes)
                {

                    string fileName = "Envanter_Takip.db"; // Kopyalamak istediğimiz dosya ve uzantısı
                    string sourcePath = Application.StartupPath + "\\"; // dosyamızın bulunduğu klasör konumu
                    string targetPath = Application.StartupPath + "\\yedek\\"; // dosyamızı kopyalamak istediğimiz klasörün konumu
                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName); // dosya ismi ve konumunu birleştirmek için kullanıyoruz
                    string destFile = System.IO.Path.Combine(targetPath, fileName); // kopyalama işleminde hedef dosya tanımlıyoruz ve tam isim ile kopyalamsını sağlıyoruz
                    if (!System.IO.Directory.Exists(targetPath)) // if ile kopyalamak istediğimiz dosya konumu doğru olup olmadığını veya öyle bir dosya varmı yokmu kontrol ediyoruz
                    {
                        System.IO.Directory.CreateDirectory(targetPath); // if ile kontrol ettiğimiz klasör yok ise oluşturuyoruz
                    }
                    if (System.IO.File.Exists(destFile))
                    {
                        System.IO.File.Delete(destFile);
                    }
                    System.IO.File.Copy(sourceFile, destFile, true);
                    mesaj.YeniKayit("Yedekleme işlemi başarıyla tamamlandı.");
                    return true;
                }
                else mesaj.Hata("Yedekleme işlemi iptal edildi.");
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
                return false;

            }

            return false;
        }

        public bool GeriAl()
        {
            try
            {

                var dr = mesaj.EvetSeciliEvetHayir("Yedek veritabanını geri yüklemek istediğinize emin misiniz?\nBu işlem Geri Alınamaz!!!", "Uyarı");
                if (dr == DialogResult.Yes)
                {

                    string fileName = "Envanter_Takip.db"; // Kopyalamak istediğimiz dosya ve uzantısı
                    string sourcePath = Application.StartupPath + "\\yedek\\";// dosyamızın bulunduğu klasör konumu
                    string targetPath = Application.StartupPath + "\\";  // dosyamızı kopyalamak istediğimiz klasörün konumu
                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName); // dosya ismi ve konumunu birleştirmek için kullanıyoruz
                    string destFile = System.IO.Path.Combine(targetPath, fileName); // kopyalama işleminde hedef dosya tanımlıyoruz ve tam isim ile kopyalamsını sağlıyoruz
                    //if (!System.IO.Directory.Exists(targetPath)) // if ile kopyalamak istediğimiz dosya konumu doğru olup olmadığını veya öyle bir dosya varmı yokmu kontrol ediyoruz
                    //{
                    //    System.IO.Directory.CreateDirectory(targetPath); // if ile kontrol ettiğimiz klasör yok ise oluşturuyoruz
                    //}
                    //baglan.bgl(false);
                    //if (System.IO.File.Exists(destFile))
                    //{
                    //    System.IO.File.Delete(destFile);
                    //}
                    System.IO.File.Copy(sourceFile, destFile, true);
                    mesaj.YeniKayit("Yedek başarıyla geri yüklendi.");
                    return true;
                }
                else mesaj.Hata("Geri Yükleme işlemi iptal edildi.");
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
                return false;

            }

            return false;
        }


    }
}
