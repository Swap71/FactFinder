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
    class PdfRr
    {

        IWebDriver driver;
        string Email = "Swap@Lan.com";
        string pobjFile;


        [Test]

        //  public string Setdropdown(string Guid, string pobjFile, string User, string ClientName, string ARID, string Email, string Contact, string Path, int TemplateId)
        public void GetField1()
        {


            var pdf_filename = "D:\\PDF Test1.pdf";

            var reader = new PdfReader(pdf_filename);
            {
                var fields = reader.AcroFields.Fields;

             
                string val = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.user");

                string val1 = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.1.PersonalDetails.user");

                string val2 = reader.AcroFields.GetField("SaveInputJSON.Date");

                //   pdfFormFields.SetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.Email", Email);
                //      pdfFormFields.SetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.MobilePhone", Contact);


                // SaveInputJSON.PersonalDetails.0.PersonalDetails.user
                // SaveInputJSON.PersonalDetails.1.PersonalDetails.user

                //    Response.Write("SaveInputJSON.ClientName" + " : " + val + " <br/");
                Console.WriteLine("Client+" + val);
                Console.WriteLine("Partner+" + val1);
                Console.WriteLine("Date+" + val2);




            }
        }
    }
}
