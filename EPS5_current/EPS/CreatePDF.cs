using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace EPS
{
    public class CreatePDF
    {
        public CreatePDF(List<ResultTest> listResult)
		{
			string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
			try
			{
                // Creating System.IO.FileStream object  appRootDir + "/PDFs/" + 
              // string dateNow= DateTime.Now.Year +"-"+ DateTime.Now.Month +"-"+ DateTime.Now.Day;
               
               using (FileStream fs = new FileStream(DateTime.Now.ToString().Replace("/","-").Replace(":","-") + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None))
				// Creating iTextSharp.text.Document object
				using (Document doc = new Document())
				// Creating iTextSharp.text.pdf.PdfWriter object
				// It helps to write the Document to the Specified FileStream
				using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
				{
					// Setting Encryption properties
					writer.SetEncryption(PdfWriter.STRENGTH40BITS, null, null, PdfWriter.ALLOW_COPY);
                    // Openning the Document _CriKomponenten
					doc.Open();
                   var Currentfont=  new Font(Font.FontFamily.HELVETICA, 10);
                    doc.Add(new Paragraph("EPS 200 protocol", new Font(Font.FontFamily.HELVETICA, 16)));
                    doc.Add(new Paragraph("Common rail injector test                                                                                                Date    " + DateTime.Now.ToString().Replace("/", "-") ,Currentfont));
                    doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------"));
                    doc.Add(new Paragraph("Responsible Name : " + Form1.setting.Name, Currentfont));
                    doc.Add(new Paragraph("Tel : " + Form1.setting.Tel + "                                       Checker : " + Form1.setting.Checker, Currentfont));
                    doc.Add(new Paragraph("Fax : " + Form1.setting.Fax, Currentfont));
                    doc.Add(new Paragraph("Email : " + Form1.setting.Email, Currentfont));
                   doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------"));
                   doc.Add(new Paragraph("Customer data", Currentfont));
                   doc.Add(new Paragraph("Name : " + Form1.customer.Name + "                                       Customer No : " + Form1.customer.CustomerNo, Currentfont));
                   doc.Add(new Paragraph("Tel : " + Form1.customer.Tel, Currentfont));
                   doc.Add(new Paragraph("Fax : " + Form1.customer.Fax, Currentfont));
                   doc.Add(new Paragraph("Email : " + Form1.customer.Email, Currentfont));
                   doc.Add(new Paragraph("----------------------------------------------------------------------------------------------------------------------------------"));
                   doc.Add(new Paragraph("Common rail injector", Currentfont));
                   doc.Add(new Paragraph("Type number :                 " + UCTestEPS._CriKomponenten.TypTeileNr, Currentfont));
                   doc.Add(new Paragraph("Manufacturer :                 " + UCTestEPS._CriKomponenten.Hersteller, Currentfont));
                   doc.Add(new Paragraph("Actuation profile :                 " + UCTestEPS._CriKomponenten.Ansteuerprofil, Currentfont));
                   doc.Add(new Paragraph("Description :                 " + UCTestEPS._CriKomponenten.Beschreibung, Currentfont));
                   //
                  // doc.Add(new Paragraph("  "));
                   doc.Add(new Paragraph("Measurement results"));
                   doc.Add(new Paragraph("  "));
                    PdfPTable table = new PdfPTable(new float[]{12,12,12,12,20,20,12});
                    table.WidthPercentage = 100;
                    PdfPCell cell = new PdfPCell(new Phrase("Measurement results", Currentfont));
                    cell.Colspan = 7;
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right 
                    var Currentfontsmal = new Font(Font.FontFamily.HELVETICA, 8);
                    table.AddCell(cell);

                    table.AddCell(new PdfPCell(new Phrase("Test Step", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("Actuation time", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("Pressure", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("Measurement time", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("Injected fuel quantity(mm³/H)", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("Return quantity(mm³/H)", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("Evaluation", Currentfontsmal)));

                    table.AddCell(new PdfPCell(new Phrase("", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("(μs)", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("(MPa)", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("(s)", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("Set value      Actual value", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("Set value      Actual value", Currentfontsmal)));
                    table.AddCell(new PdfPCell(new Phrase("", Currentfontsmal)));

                    foreach (var item in listResult)
                    {
                        table.AddCell(new PdfPCell(new Phrase(item.TestName, Currentfontsmal)));
                        table.AddCell(new PdfPCell(new Phrase(item.ActuationTime, Currentfontsmal)));
                        table.AddCell(new PdfPCell(new Phrase(item.Pressure, Currentfontsmal)));
                        table.AddCell(new PdfPCell(new Phrase(item.MeasurementTime, Currentfontsmal)));
                        table.AddCell(new PdfPCell(new Phrase(item.InjectedFuelQuantitySetValue + "               " + item.InjectedFuelQuantityActualValue, Currentfontsmal)));
                        table.AddCell(new PdfPCell(new Phrase(item.ReturnQuantitySetValue + "              " + item.ReturnQuantityActualValue, Currentfontsmal)));
                        table.AddCell(new PdfPCell(new Phrase(item.StrResul, Currentfontsmal)));
                     }
                  doc.Add(table);

					doc.Close();
				}

                Process myProcess = new Process();// appRootDir + "/PDFs/" 
                myProcess.StartInfo.FileName = "acroRd32.exe"; //not the full application path
                myProcess.StartInfo.Arguments = "/A \"page=1=OpenActions\" " + "ResultTest.pdf";
                myProcess.Start();
			}
			// Catching iTextSharp.text.DocumentException if any
			catch (DocumentException de)
			{
				throw de;
			}
			// Catching System.IO.IOException if any
			catch (IOException ioe)
			{
				throw ioe;
			}
		}
    }
}
//     doc.Open();
//PdfContentByte cb = writer.DirectContent;...
//cb.MoveTo(doc.PageSize.Width / 2, doc.PageSize.Height / 2);
//cb.LineTo(doc.PageSize.Width / 2, doc.PageSize.Height);
//cb.Stroke();
//cb.MoveTo(0, doc.PageSize.Height / 2);
//cb.LineTo(doc.PageSize.Width, doc.PageSize.Height / 2);
//cb.Stroke();
// PdfContentByte cb = writer.DirectContent;
//   cb.MoveTo(0,30f);
// cb.LineTo(doc.PageSize.Width, 30f);
// cb.Stroke();
//// cb.ClosePath();
//// cb.Stroke();
//doc.Add(new Header("", ""));
//var x = new PdfPTableBody();
// doc.Add();
// Closing the Document