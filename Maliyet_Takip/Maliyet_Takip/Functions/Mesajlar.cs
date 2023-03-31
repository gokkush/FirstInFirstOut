using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maliyet_Takip.Functions
{
    public class Mesajlar
    {
        AnaForm MesajForm = new AnaForm();
        public void YeniKayit(string Mesaj)
        {
            MesajForm.Mesaj("Yeni Kayıt Girişi", Mesaj);

        }
        public void Guncelle(string Mesaj)
        {
            MesajForm.Mesaj("Güncelleme", Mesaj);

        }
        public DialogResult Guncelle()
        {
            return MessageBox.Show("Seçili kayıt değiştirilecektir.\n Güncelleme işlemini onaylıyor musunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }

        public DialogResult Sil()
        {
            return MessageBox.Show("Seçili Kayıt Kalıcı Olarak Silinecektir. \n Silme işlemini onaylıyor musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public DialogResult ZimmetGeriAl()
        {
            return MessageBox.Show("Seçili Donanım için . \n Zimmet Geri Alınacaktır. Onaylıyor musunuz?", "Zimmet Geri Alma İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public DialogResult TabloExportMesaj(string dosyaFormati)
        {
            return EvetSeciliEvetHayir($"İlgili Tablo, {dosyaFormati} olarak Dışarı aktarılacaktır. Onaylıyor musunuz?", "Aktarım Onayı");
        }
        public DialogResult EvetSeciliEvetHayir(string mesaj, string baslik)
        {
            return MessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        public void Sil(bool Sil)
        {
            MesajForm.Mesaj("Kayıt Silme", "Kayıt Silinmiştir!");

        }
        public void Guncelle(bool Guncelleme)
        {
            MesajForm.Mesaj("Kayıt Güncelleme", "Kayıt Güncellenmiştir!");

        }
        public void Hata(Exception Hata)
        {
            MesajForm.Mesaj("Hata Oluştu", Hata.Message);

        }
        public void Hata(string Hata)
        {
            MesajForm.Mesaj("UYARI", Hata);

        }

        public void FormAcilis(string FormAdi)
        {
            MesajForm.Mesaj("", FormAdi + " Formu Açıldı");
        }
        public void FormKapanis(string FormAdi)
        {
            MesajForm.Mesaj("", FormAdi + " Formu Kapatıldı");
        }
    }
}
