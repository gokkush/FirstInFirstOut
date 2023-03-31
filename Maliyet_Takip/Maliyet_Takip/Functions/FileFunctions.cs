using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using Maliyet_Takip.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Maliyet_Takip.Functions
{
	public static class FileFunctions
	{

		public static void FormSablonKaydet(this string sablonAdi, int left, int top, int width, int height, FormWindowState windowState)
		{

			try
			{
				if (!Directory.Exists(Application.StartupPath + @"\SablonDosyalar"))
					Directory.CreateDirectory(Application.StartupPath + @"\SablonDosyalar");

				var settings = new XmlWriterSettings();
				settings.Indent = true;
				var writer = XmlWriter.Create(Application.StartupPath + $@"\SablonDosyalar\{sablonAdi}_location.xml", settings);
				//$ işareti string içine + kullanmadan parantezle değişken eklemeye
				//@ işareti \ gibi özel karakterleri yazdırmaya yarar.
				writer.WriteStartDocument();
				writer.WriteComment("PLACEMENT OF EXAMS PROJESİ ŞABLONLARIDIR.");
				writer.WriteStartElement("Tablo");
				writer.WriteStartElement("Location");
				writer.WriteAttributeString("Left", left.ToString());
				writer.WriteAttributeString("Top", top.ToString());
				writer.WriteEndElement();

				writer.WriteStartElement("FormSize");
				if (windowState == FormWindowState.Maximized)
				{
					writer.WriteAttributeString("Width", "-1");
					writer.WriteAttributeString("Height", "-1");

				}
				else
				{
					writer.WriteAttributeString("Width", width.ToString());
					writer.WriteAttributeString("Height", height.ToString());
				}
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndDocument();
				writer.Flush();
				writer.Close();


			}
			catch (Exception ex)
			{
				Mesajlar mesaj = new Mesajlar();
				mesaj.Hata(ex);
				mesaj = null;
			}
		}

		public static void FormSablonYukle(this string sablonAdi, XtraForm frm)
		{
			var list = new List<string>();
			try
			{
				if (File.Exists(Application.StartupPath + $@"\SablonDosyalar\{sablonAdi}_location.xml"))
				{
					var reader = XmlReader.Create(Application.StartupPath + $@"\SablonDosyalar\{sablonAdi}_location.xml");
					while (reader.Read())
					{
						if (reader.NodeType == XmlNodeType.Element && reader.Name == "Location")
						{
							list.Add(reader.GetAttribute(0));
							list.Add(reader.GetAttribute(1));
						}
						else if (reader.NodeType == XmlNodeType.Element && reader.Name == "FormSize")
						{
							list.Add(reader.GetAttribute(0));
							list.Add(reader.GetAttribute(1));
						}
					}
					reader.Close();
					reader.Dispose();
				}
			}
			catch (Exception ex)
			{
				Mesajlar mesaj = new Mesajlar();
				mesaj.Hata(ex);
				mesaj = null;
			}
			if (list.Count <= 0) return;

			frm.Location = new Point(int.Parse(list[0]), int.Parse(list[1]));
			if (list[2] == "-1" && list[3] == "-1")
				frm.WindowState = FormWindowState.Maximized;
			else
				frm.Size = new System.Drawing.Size(int.Parse(list[2]), int.Parse(list[3]));
		}

		public static void TabloSablonKaydet(this GridView tablo, string sablonAdi)
		{
			try
			{
				tablo.ClearColumnsFilter();
				if (!Directory.Exists(Application.StartupPath + @"\SablonDosyalar"))
					Directory.CreateDirectory(Application.StartupPath + @"\SablonDosyalar");
				tablo.SaveLayoutToXml(Application.StartupPath + $@"\SablonDosyalar\{sablonAdi}.xml");
			}
			catch (Exception ex)
			{
				Mesajlar mesaj = new Mesajlar();
				mesaj.Hata(ex);
				mesaj = null;
			}

		}

		public static void TabloSablonYukle(this GridView tablo, string sablonAdi)
		{
			try
			{
				if (File.Exists(Application.StartupPath + $@"\SablonDosyalar\{sablonAdi}.xml"))
					tablo.RestoreLayoutFromXml(Application.StartupPath + $@"\SablonDosyalar\{sablonAdi}.xml");

			}
			catch (Exception ex)
			{
				Mesajlar mesaj = new Mesajlar();
				mesaj.Hata(ex);
				mesaj = null;
			}
		}

		public static void TabloDisariAktar(this GridView tablo, DosyaTuru dosyaTuru, string dosyaFormati, string excelSayfaAdi)
		{
			Mesajlar mesaj = new Mesajlar();
			if (mesaj.TabloExportMesaj(dosyaFormati) != DialogResult.Yes) return;
			if (!Directory.Exists(Application.StartupPath + @"\Temp"))
				Directory.CreateDirectory(Application.StartupPath + @"\Temp");
			var dosyaAdi = Guid.NewGuid().ToString();
			var filePath = $@"{Application.StartupPath}\\Temp\{dosyaAdi}";

			switch (dosyaTuru)
			{
				case DosyaTuru.ExcelStandart:
					{
						var option = new XlsxExportOptionsEx
						{
							ExportType = DevExpress.Export.ExportType.Default,
							SheetName = excelSayfaAdi,
							TextExportMode = TextExportMode.Text,
						};

						filePath = filePath + ".xlsx";
						tablo.ExportToXlsx(filePath, option);
					}
					break;
				case DosyaTuru.ExcelFormat:
					{
						var option = new XlsxExportOptionsEx
						{
							ExportType = DevExpress.Export.ExportType.WYSIWYG,
							SheetName = excelSayfaAdi,
							TextExportMode = TextExportMode.Text,
						};

						filePath = filePath + ".xlsx";
						tablo.ExportToXlsx(filePath, option);
					}
					break;
				case DosyaTuru.ExcelFormatsiz:
					{
						var option = new CsvExportOptionsEx
						{
							ExportType = DevExpress.Export.ExportType.Default,
							TextExportMode = TextExportMode.Text,
						};

						filePath = filePath + ".csv";
						tablo.ExportToCsv(filePath, option);
					}
					break;
				case DosyaTuru.WordDosyasi:
					{
						filePath = filePath + ".docx";
						tablo.ExportToDocx(filePath);
					}
					break;
				case DosyaTuru.PdfDosyasi:
					{
						filePath = filePath + ".pdf";
						tablo.ExportToPdf(filePath);
					}
					break;
				case DosyaTuru.TxtDosyasi:
					{
						var option = new TextExportOptions
						{
							TextExportMode = TextExportMode.Text,
						};

						filePath = filePath + ".txt";
						tablo.ExportToText(filePath, option);
					}
					break;
			}
			if (!File.Exists(filePath))
			{
				mesaj.Hata("Tablo verileri dosyaya aktarılamadı.");
				return;
			}
			Process.Start(filePath);
		}
	}
}
