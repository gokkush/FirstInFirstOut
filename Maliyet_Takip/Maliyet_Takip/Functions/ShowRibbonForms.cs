﻿using DevExpress.XtraBars.Ribbon;
using Maliyet_Takip.Enums;
using System;
using System.Windows.Forms;

namespace Maliyet_Takip.Functions
{
    public class ShowRibbonForms<TForm> where TForm : RibbonForm
    {
        public static void ShowForm(bool dialog, params object[] prm)
        {
            var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm);

            if (dialog)
            {
                using (frm)
                {
                    frm.ShowDialog();

                }

            }
            else
                frm.Show();
        }

        public static long ShowDialogForm(KartTuru kartTuru, params object[] prm)
        {

            var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm);


            using (frm)
            {
                frm.ShowDialog();
                return frm.DialogResult == DialogResult.OK ? (long)frm.Tag : 0;

            }

        }
    }
}
