using Maliyet_Takip.Forms.AyarForms;
using Maliyet_Takip.Forms.BirimForms;
using Maliyet_Takip.Forms.CariForms;
using Maliyet_Takip.Forms.DonemForms;
using Maliyet_Takip.Forms.HareketForms.DepolarArasiSevkForms;
using Maliyet_Takip.Forms.HareketForms.HammaddeHareketForms;
using Maliyet_Takip.Forms.Kullanici;
using Maliyet_Takip.Forms.KullaniciForms;
using Maliyet_Takip.Forms.StokForms;
using Maliyet_Takip.Forms.UnvanForms;
using System;
using System.Windows.Forms;
using Maliyet_Takip.Forms.GiderForms;
using Maliyet_Takip.Forms.HareketForms.MamulHareketForms;
using Maliyet_Takip.Forms.MamulForms;

namespace Maliyet_Takip.Functions
{
    public class Formlar
    {



        //public void KargoListesi(bool Secim = false)
        //{
        //    Modul_Fatura.frmKargoListesi frm = new Modul_Fatura.frmKargoListesi(Secim);
        //    if (Secim) frm.ShowDialog();
        //    else
        //    {
        //        frm.MdiParent = Anaform.ActiveForm;
        //        frm.Show();
        //    }
        //}

        #region Kurum
        //public void KurumDegistir(int ID = -1, bool Ac = false)
        //{
        //    KurumEditForm frm = new KurumEditForm(ID, Ac);
        //    frm.ShowDialog();
        //}
        #endregion

        #region Ayar
        public void BaslangicAyarFormu()
        {
            AyarEditForm frm = new AyarEditForm();
            frm.ShowDialog();
        }
        #endregion

        #region Kullanicilar
        public void KullaniciSorguFormu(int ID = -1, bool Ac = false)
        {
            KullaniciSorguForm frm = new KullaniciSorguForm();
            frm.ShowDialog();
        }
        public void KullaniciListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (KullaniciListForm)Activator.CreateInstance(typeof(KullaniciListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (KullaniciListForm)Activator.CreateInstance(typeof(KullaniciListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void KullaniciEditFormu(int ID = -1, bool Ac = false)
        {
            KullaniciEditForm frm = new KullaniciEditForm(ID, Ac);
            frm.ShowDialog();
        }

        public void SifreDegistir(int ID = -1, bool Ac = false)
        {
            SifreDegistirEditForm frm = new SifreDegistirEditForm(ID, Ac);
            frm.ShowDialog();
        }

        #endregion

        #region Cariler

        public void CariListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (CariListForm)Activator.CreateInstance(typeof(CariListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (CariListForm)Activator.CreateInstance(typeof(CariListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void CariEditFormu(int ID = -1, bool Ac = false)
        {
            CariEditForm frm = new CariEditForm(ID, Ac);
            frm.ShowDialog();
        }


        #endregion

        #region Doınemler

        public void DonemlerListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (DonemListForm)Activator.CreateInstance(typeof(DonemListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (DonemListForm)Activator.CreateInstance(typeof(DonemListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void DonemlerEditFormu(int ID = -1, bool Ac = false)
        {
            DonemEditForm frm = new DonemEditForm(ID, Ac);
            frm.ShowDialog();
        }


        #endregion

        #region Giderler

        public void GiderlerListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (GiderListForm)Activator.CreateInstance(typeof(GiderListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (GiderListForm)Activator.CreateInstance(typeof(GiderListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void GiderlerEditFormu(int ID = -1, bool Ac = false)
        {
            GiderEditForm frm = new GiderEditForm(ID, Ac);
            frm.ShowDialog();
        }


        #endregion

        #region Maliyetler

        public void MaliyetOlusturmaListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (MaliyetOlusturmaListForm)Activator.CreateInstance(typeof(MaliyetOlusturmaListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (MaliyetOlusturmaListForm)Activator.CreateInstance(typeof(MaliyetOlusturmaListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void MaliyetOlusturmaEditFormu(int ID = -1, bool Ac = false)
        {
            MaliyetOlusturmaEditForm frm = new MaliyetOlusturmaEditForm(ID, Ac);
            frm.ShowDialog();
        }


        #endregion

        #region Birimler

        public void BirimlerListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (BirimListForm)Activator.CreateInstance(typeof(BirimListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (BirimListForm)Activator.CreateInstance(typeof(BirimListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void BirimlerEditFormu(int ID = -1, bool Ac = false)
        {
            BirimEditForm frm = new BirimEditForm(ID, Ac);
            frm.ShowDialog();
        }


        #endregion

        #region Unvanlar

        public void UnvanlarListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (UnvanListForm)Activator.CreateInstance(typeof(UnvanListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (UnvanListForm)Activator.CreateInstance(typeof(UnvanListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void UnvanlarEditFormu(int ID = -1, bool Ac = false)
        {
            UnvanEditForm frm = new UnvanEditForm(ID, Ac);
            frm.ShowDialog();
        }


        #endregion

        #region Mamul

        public void MamulGruplarListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (MamulGrupListForm)Activator.CreateInstance(typeof(MamulGrupListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (MamulGrupListForm)Activator.CreateInstance(typeof(MamulGrupListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void MamulGrupEditFormu(int ID = -1, bool Ac = false)
        {
            MamulGrupEditForm frm = new MamulGrupEditForm(ID, Ac);
            frm.ShowDialog();
        }

        public void MamullerListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (MamulListForm)Activator.CreateInstance(typeof(MamulListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (MamulListForm)Activator.CreateInstance(typeof(MamulListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void MamullerrEditFormu(int ID = -1, bool Ac = false)
        {
            MamulEditForm frm = new MamulEditForm(ID, Ac);
            frm.ShowDialog();
        }

        public void MamulSatisListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (MamulSatisSevkListForm)Activator.CreateInstance(typeof(MamulSatisSevkListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (MamulSatisSevkListForm)Activator.CreateInstance(typeof(MamulSatisSevkListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void MamulSatisEditFormu(int ID = -1, bool Ac = false)
        {
            MamulSatisEditForm frm = new MamulSatisEditForm(ID, Ac);
            frm.ShowDialog();
        }

        public void MamulSevkListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (MamulSevkListForm)Activator.CreateInstance(typeof(MamulSevkListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (MamulSevkListForm)Activator.CreateInstance(typeof(MamulSevkListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void MamulSevkEditFormu(int ID = -1, bool Ac = false)
        {
            MamulSevkEditForm frm = new MamulSevkEditForm(ID, Ac);
            frm.ShowDialog();
        }

        #endregion

        #region Stok

        public void StokGruplarListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (StokGrupListForm)Activator.CreateInstance(typeof(StokGrupListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (StokGrupListForm)Activator.CreateInstance(typeof(StokGrupListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void StokGrupEditFormu(int ID = -1, bool Ac = false)
        {
            StokGrupEditForm frm = new StokGrupEditForm(ID, Ac);
            frm.ShowDialog();
        }

        public void StoklarListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (StokListForm)Activator.CreateInstance(typeof(StokListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (StokListForm)Activator.CreateInstance(typeof(StokListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void StoklarEditFormu(int ID = -1, bool Ac = false)
        {
            StokEditForm frm = new StokEditForm(ID, Ac);
            frm.ShowDialog();
        }



        #endregion

        #region Hareket

        public void DepoListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (AnaDepoListForm)Activator.CreateInstance(typeof(AnaDepoListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (AnaDepoListForm)Activator.CreateInstance(typeof(AnaDepoListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }


        public void DepolarArasiSevkListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (DepolarArasiSevkListForm)Activator.CreateInstance(typeof(DepolarArasiSevkListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (DepolarArasiSevkListForm)Activator.CreateInstance(typeof(DepolarArasiSevkListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void DepolarArasiSevkEditFormu(int ID = -1, bool Ac = false)
        {
            DepolarArasiSevkEditForm frm = new DepolarArasiSevkEditForm(ID, Ac);
            frm.ShowDialog();
        }


        public void HammaddealisListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (HammaddeAlisListForm)Activator.CreateInstance(typeof(HammaddeAlisListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (HammaddeAlisListForm)Activator.CreateInstance(typeof(HammaddeAlisListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void HammaddeAlisEditFormu(int ID = -1, bool Ac = false)
        {
            HammaddeAlisEditForm frm = new HammaddeAlisEditForm(ID, Ac);
            frm.ShowDialog();
        }

        public void SayimYerListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (AnaDepoListForm)Activator.CreateInstance(typeof(AnaDepoListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (AnaDepoListForm)Activator.CreateInstance(typeof(AnaDepoListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }

        public void MamulSayimYerListFormu(bool ac = false)
        {
            if (!ac)
            {
                var frm = (MamulDepoListForm)Activator.CreateInstance(typeof(MamulDepoListForm));
                frm.MdiParent = Form.ActiveForm;

                frm.Yukle();
                frm.Show();
            }
            else
            {
                using (var frm = (MamulDepoListForm)Activator.CreateInstance(typeof(MamulDepoListForm)))
                {
                    frm.Yukle();
                    frm.ShowDialog();
                    frm.AktifPasifButonGoster = false;
                }
            }
        }
        #endregion
    }

}

