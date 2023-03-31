using DevExpress.XtraReports.UI;
using Maliyet_Takip.Functions;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;

namespace Maliyet_Takip.Forms.Rapors
{
    public partial class MaliyetRapor : DevExpress.XtraReports.UI.XtraReport
    {
        static string conStr = ConfigurationManager.ConnectionStrings["Isyurdu_Connection"].ToString();

        public MaliyetRapor(params object[] prm)
        {
            conStr = GeneralFunctions.Decrypt(conStr, "CTE");
            InitializeComponent();
            sqlDataSource1.Connection.ConnectionString = conStr;
            sqlDataSource2.Connection.ConnectionString = conStr;
            sqlDataSource3.Connection.ConnectionString = conStr;
            sqlDataSource4.Connection.ConnectionString = conStr;
            this.DataSource = prm[0];
            DetailReportDirekGiderler.DataSource = prm[1];
            DetailReportEndirekGiderler.DataSource = prm[2];
            DetailReportDigerGider.DataSource = prm[3];
        }

    }
}
