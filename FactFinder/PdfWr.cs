using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Configuration;
using System.Configuration;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using iTextSharp.text.pdf;
using System.IO;

namespace FactFinder
{
    class PdfWr1
    {
        IWebDriver driver;
        string Email = "Swapnil@Lan.com";
        string pobjFile;


        [Test]
     
        //  public string Setdropdown(string Guid, string pobjFile, string User, string ClientName, string ARID, string Email, string Contact, string Path, int TemplateId)
        public void SetField1()
        {



            string pdfTemplate = @"D:\\PDF Test1.pdf";
            string newFile = @"D:\\PDFTest1.pdf";

            PdfReader pdfReader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(
                newFile, FileMode.Create));
            AcroFields pdfFormFields = pdfStamper.AcroFields;


            //  string returnFile;

            //       AcroFields pdfFormFields = pdfStamper.AcroFields;
            pdfFormFields.SetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.Email", Email);

            pdfStamper.FormFlattening = false;
            pdfStamper.Close();










            /****
                        string pdfTemplate = pobjFile;


                        var pdf_filename = "D:\\PDF Test1.pdf";

                        PdfReader pdfReader = new PdfReader(pdfTemplate);

                     //   var pdfReader = new PdfReader(pdf_filename);
                      //   var pdfReader = new PdfReader();


                        PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(pdf_filename, FileMode.Create));***********/



            /*    string pdfTemplate = @"c:\Temp\PDF\fw4.pdf";
                string newFile = @"c:\Temp\PDF\completed_fw4.pdf";*/

        }
    }
}