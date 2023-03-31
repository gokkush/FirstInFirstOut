using Maliyet_Takip.Entities;
using Maliyet_Takip.Enums;
using Maliyet_Takip.Forms.BaseForms;
using Maliyet_Takip.Interfaces;
using System;

namespace Maliyet_Takip.Functions
{
    public class ShowEditforms<TForm> : IBaseFormshow where TForm : BaseEditForm
    {
        public long ShowDialogeditForm(KartTuru kartTuru, int id)//, params object[] prm) 
        {
            //Yetki Kontrolü
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm._id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak ? frm._id : 0;
            }

        }

        public static long ShowDialogeditForm(KartTuru kartTuru, int id, params object[] prm)
        {
            //Yetki Kontrolü
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm._id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak ? frm._id : 0;
            }

        }
        public static void ShowDialogEditForm(long? id, params object[] prm)
        {
            //Yetki Kontrolü
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.Yukle();
                frm.ShowDialog();
            }

        }
        public static T ShowDialogEditForm<T>(params object[] prm) where T : IBaseEntity
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.Yukle();
                frm.ShowDialog();
                return (T)frm.ReturnEntity();
            }
        }

        public static long ShowDialogEditForm(int id, params object[] prm)
        {
            //Yetki Kontrolü
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm._id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak ? frm._id : 0;
            }

        }
        public static bool ShowDialogEditForm(IslemTuru islemTuru, params object[] prm)
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.BaseIslemTuru = islemTuru;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak;
            }

        }
        public static void ShowDialogEditForm()
        {
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {

                frm.Yukle();
                frm.ShowDialog();
            }

        }


        public long ShowDialogeditForm(KartTuru kartTuru, long id)
        {
            throw new NotImplementedException();
        }
    }
}
