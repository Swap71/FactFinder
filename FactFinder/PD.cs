using iTextSharp.text.pdf;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FactFinder
{
    class PersonalDetails123
    {

        IWebDriver driver;


        [SetUp]
        public void startBrowser()
        {




            var browser = System.Configuration.ConfigurationManager.AppSettings["Browser"];
            var Path = System.Configuration.ConfigurationManager.AppSettings["Path"];

            switch (browser)
            {
                case "IE":


                    driver = new InternetExplorerDriver(Path);
                    break;

                case "FF":

                    driver = new FirefoxDriver(Path);
                    break;


                case "CR":


                    driver = new ChromeDriver(Path);
                    break;
            }



            var url = System.Configuration.ConfigurationManager.AppSettings["url"];
            Console.WriteLine(string.Format("URL is : ", url));
            driver.Navigate().GoToUrl(url);






            IWebElement element = driver.FindElement(By.XPath(".//*[@id='ctl00_memberslogin_Login1_UserName']"));

            


            string Str1 = System.Configuration.ConfigurationManager.AppSettings["Usename"];
            driver.FindElement(By.XPath("//*[@id='ctl00_memberslogin_Login1_UserName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_memberslogin_Login1_UserName']")).SendKeys(Str1);


            
            string Str2 = System.Configuration.ConfigurationManager.AppSettings["Password"];
            driver.FindElement(By.XPath("//*[@id='ctl00_memberslogin_Login1_Password']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_memberslogin_Login1_Password']")).SendKeys(Str2);


            //  wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@id, 'Name')]")));




            Thread.Sleep(1000);
            IWebElement element2 = driver.FindElement(By.XPath(".//*[@id='ctl00_memberslogin_Login1_LoginButton']"));
            element2.Click();
            //  driver.Navigate().GoToUrl("stellar11/User/dashboard.aspx");





            String A = driver.FindElement(By.XPath("//*[@id='ctl00_rwAgreement_C']/div")).Text;
            Console.WriteLine(A);

            if (!String.IsNullOrEmpty(A))
            {
                driver.FindElement(By.XPath(" //*[@id='ctl00_rwAgreement_C_btnAgree']")).Click();
            }




        }
        // }
        [Test]
        public void PD_Fields__Mandatory()
        {
           // IWebDriver driver;
            Thread.Sleep(2000);

            driver.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // Thread.Sleep(1000);


            //  driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_AdminLink']")).Click();
            driver.FindElement(By.XPath(".//*[@id='aspnetForm']/section[2]/section[1]/nav")).Click();
            Console.WriteLine("Black Ribbon");
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//a[contains(@title, 'Search client')]")).Click();

            //  wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@title, 'Management')]")));
            Console.WriteLine("Search client");

            Thread.Sleep(1000);

            Console.WriteLine("Clicked Search");



            //  driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_HyperLinkAdminPlanners']")).Click();
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_btnSearch']")).Click();
            Console.WriteLine("sEARCH");

            Thread.Sleep(1000);

            IWebElement element = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ClientName"));



           var C_USERNAME = System.Configuration.ConfigurationManager.AppSettings["C_USERNAME"];


            Console.WriteLine(string.Format("Given Name is : ", C_USERNAME));
            element.SendKeys(C_USERNAME);

            //  driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ClientName")).SendKeys("Jeff1");

            Console.WriteLine("Enter Search");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_btnSearch']")).Click();

            Console.WriteLine("Click on Search button");


            for (int i = 0; i <= 20; i++)
            {


                //    String ss = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAR_ctl00__" + i + "']/td[2]")).Text;
                String gn = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgUsers_ctl00__" + i + "']/td[4]")).Text;




                string s = System.Configuration.ConfigurationManager.AppSettings["C_USERNAME"];
                if (!String.IsNullOrEmpty(s))
                {

                    Console.WriteLine("C_Given Name is:" + gn);
                    String sn = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgUsers_ctl00__" + i + "']/td[5]")).Text;


                    string s1 = System.Configuration.ConfigurationManager.AppSettings["C_GIVEN NAME"];
                    if (!String.IsNullOrEmpty(s1))

                    {

                        Console.WriteLine("Given Name is:" + sn);


                        Console.WriteLine("Into Loop i is +" + i);


                        var im1 = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgUsers_ctl00__" + i + "']/td[7]"));


                        Console.WriteLine("i value chk is +" + i);

                        im1.Click();

                        break;
                    }
                }
            }

            Thread.Sleep(1000);



            driver.FindElement(By.XPath("//*[@id='hlFacts']")).Click();




            /**************OK PD Express**/
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlPersonalDetails']")).Click();


            Console.WriteLine("Click on Personal Details ");

            Thread.Sleep(1000);


            var pdf_filename = "D:\\PDF Test123.pdf";

            var reader = new PdfReader(pdf_filename);
            // {
            var fields = reader.AcroFields.Fields;

            /***  string val = reader.AcroFields.GetField("UserName");

              string val1 = reader.AcroFields.GetField("Password");***/

            string val = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.user");

            string val1 = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.1.PersonalDetails.user");

            string val2 = reader.AcroFields.GetField("SaveInputJSON.Date");

            string val3 = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.GivenNames");



            // SaveInputJSON.PersonalDetails.0.PersonalDetails.user
            // SaveInputJSON.PersonalDetails.1.PersonalDetails.user

            //    Response.Write("SaveInputJSON.ClientName" + " : " + val + " <br/");
            Console.WriteLine("Client+" + val);
            Console.WriteLine("Partner+" + val1);
            Console.WriteLine("Date+" + val2);
            Console.WriteLine("Date+" + val3);


           

            

           // string S1 = System.Configuration.ConfigurationManager.AppSettings["C_GIVEN NAME"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientGivenNames']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientGivenNames']")).SendKeys(val3);

            string S2 = System.Configuration.ConfigurationManager.AppSettings["C_SUR NAME"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientSurname']")).Clear();
            //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientSurname']")).SendKeys(S2);

            string val5 = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.DateOfBirth");

            Console.WriteLine("Date is" + val5);

            
           // string S6 = System.Configuration.ConfigurationManager.AppSettings["C_DOB"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientDateOfBirth']")).Clear();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientDateOfBirth']")).SendKeys(val5);

            //      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientDateOfBirth']")).SendKeys(S6);

            //    Console.WriteLine("Enter DOB");



            /*   SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.Gender
               SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.Gender

                   SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.Gender
                   SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.Gender*/


            string val6 = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.Gender");

            Console.WriteLine("Gender is" + val6);

            if(val6=="Male")
            {
               // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_rbClientGenderMale']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_rbClientGenderFemale']")).Click();
            }

            //  val6.Click();


        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_rbClientGenderMale']")).Click();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/div/div/div[1]/table/tbody/tr[5]/td")));

            string val4 = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.data.0.PersonalDetailsData.items.0.PersonalDetailsItem.MaritalStatus");

            Console.WriteLine("MS" + val4);
            //    SelectElement oSelection = new SelectElement(driver.FindElement(By.Id("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ddlClientMaritalStatus']")));
            SelectElement oSelection = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ddlClientMaritalStatus']")));

            //  string S7 = System.Configuration.ConfigurationManager.AppSettings["C_MS"];

            // string S7 = System.Configuration.ConfigurationManager.AppSettings["val4"];

            //   oSelection.SelectByText(val4);
            oSelection.SelectByValue(val4);

            /*      IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                  IWebElement ej = driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/div/div/div[1]/table/tbody/tr[5]/td"));
                  //     ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();"
                  //                                                        , element);



                  js.ExecuteScript("arguments[3].click();", ej);

                  Console.WriteLine("JS CHK ");*/
            Thread.Sleep(1000);

          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ClientTFN']")).Clear();


            string S8 = System.Configuration.ConfigurationManager.AppSettings["C_TFN"];


       //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ClientTFN']")).SendKeys(S8);

            Console.WriteLine("TFN");



         /*   driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            Console.WriteLine("Profile SAVE");*/


            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[2]/a")).Click();


            string S9 = System.Configuration.ConfigurationManager.AppSettings["C_MOB"];

            driver.FindElement(By.XPath("//*[@id='txtClientMobilePhone']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='txtClientMobilePhone']")).SendKeys(S9);

            string S10 = System.Configuration.ConfigurationManager.AppSettings["C_EMAIL"];


            driver.FindElement(By.XPath("//*[@id='txtClientEmail']")).Clear();
          //  driver.FindElement(By.XPath("//*[@id='txtClientEmail']")).SendKeys(S10);

            string S11 = System.Configuration.ConfigurationManager.AppSettings["C_SKYPE"];


           driver.FindElement(By.XPath("//*[@id='txtClientSkypeUsername']")).Clear();
          //  driver.FindElement(By.XPath("//*[@id='txtClientSkypeUsername']")).SendKeys(S11);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            Console.WriteLine("Contact SAVE");


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[3]/a")).Click();


            string S12 = System.Configuration.ConfigurationManager.AppSettings["C_ADDR1"];

            driver.FindElement(By.XPath("//*[@id='txtClientAddress1']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='txtClientAddress1']")).SendKeys(S12);


            string S13 = System.Configuration.ConfigurationManager.AppSettings["C_ADDR2"];

            driver.FindElement(By.XPath("//*[@id='txtClientAddress2']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='txtClientAddress2']")).SendKeys(S13);


            string S14 = System.Configuration.ConfigurationManager.AppSettings["C_SUBR"];


           driver.FindElement(By.XPath("//*[@id='txtClientSuburb']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='txtClientSuburb']")).SendKeys(S14);

            Thread.Sleep(1000);
            //*[@id="ddlClientState"]


            string S15 = System.Configuration.ConfigurationManager.AppSettings["C_STA"];

            SelectElement oSelection2 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ddlClientState']")));

            oSelection2.SelectByText(S15);


            string S16 = System.Configuration.ConfigurationManager.AppSettings["C_PC"];

            driver.FindElement(By.XPath("//*[@id='txtClientPostcode']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='txtClientPostcode']")).SendKeys(S16);


            string S17 = System.Configuration.ConfigurationManager.AppSettings["C_Cntry"];


            SelectElement oSelection3 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ddlClientCountry']")));

            oSelection3.SelectByText(S17);


        /*    driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            Console.WriteLine("Address SAVE");*/

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a")).Click();



            Thread.Sleep(2000);


            string S3 = System.Configuration.ConfigurationManager.AppSettings["P_GIVEN NAME"];
          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerGivenNames']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerGivenNames']")).SendKeys(S3);

            string S4 = System.Configuration.ConfigurationManager.AppSettings["P_SUR NAME"];

           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerSurname']")).Clear();
         ///   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerSurname']")).SendKeys(S4);

          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerDateOfBirth']")).Clear();


            string S5 = System.Configuration.ConfigurationManager.AppSettings["P_DOB"];

         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerDateOfBirth']")).SendKeys(S5);

            Console.WriteLine("Enter DOB");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_rbPartnerGenderFemale']")).Click();


            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div/div[1]/table/tbody/tr[5]/td")));


            //    SelectElement oSelection = new SelectElement(driver.FindElement(By.Id("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ddlClientMaritalStatus']")));
            SelectElement oSelection4 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ddlPartnerMaritalStatus']")));

            string S18 = System.Configuration.ConfigurationManager.AppSettings["C_MS"];


            oSelection4.SelectByText(S18);

            /*      IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                  IWebElement ej = driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/div/div/div[1]/table/tbody/tr[5]/td"));
                  //     ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();"
                  //                                                        , element);



                  js.ExecuteScript("arguments[3].click();", ej);

                  Console.WriteLine("JS CHK ");*/
            Thread.Sleep(1000);

         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_PartnerTFN']")).Clear();

            string S19 = System.Configuration.ConfigurationManager.AppSettings["P_TFN"];


        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_PartnerTFN']")).SendKeys(S19);

            Console.WriteLine("TFN");



        /*    driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            Console.WriteLine("Profile SAVE");*/


            Thread.Sleep(1000);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[2]/a")).Click();


            string S20 = System.Configuration.ConfigurationManager.AppSettings["P_MOB"];

          driver.FindElement(By.XPath("//*[@id='txtPartnerMobilePhone']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='txtPartnerMobilePhone']")).SendKeys(S20);


            string S21 = System.Configuration.ConfigurationManager.AppSettings["P_EMAIL"];


            driver.FindElement(By.XPath("//*[@id='txtPartnerEmail']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='txtPartnerEmail']")).SendKeys(S21);

            string S22 = System.Configuration.ConfigurationManager.AppSettings["P_SKYPE"];

            driver.FindElement(By.XPath("//*[@id='txtPartnerSkypeUsername']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='txtPartnerSkypeUsername']")).SendKeys(S22);

      /*      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            Console.WriteLine("Contact SAVE");*/

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[3]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div/div[3]/table/tbody[1]/tr[2]/td/div/label/span")).Click();

     /****       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            Console.WriteLine("Partner Contact SAVE");****/






            /******OK        Thread.Sleep(2000);****/
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlFinancialObjectives"]
            /*****************************
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlFinancialObjectives']")).Click();


                        //    Thread.Sleep(2000);
                        string S268 = System.Configuration.ConfigurationManager.AppSettings["C_FO_Type"];
                        SelectElement oSelection268 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_ddlFinancialObjectiveType']")));
                        oSelection268.SelectByText(S268);

                        string S269 = System.Configuration.ConfigurationManager.AppSettings["C_FO_Prio"];
                        SelectElement oSelection269 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_ddlPriorityType']")));
                        oSelection269.SelectByText(S269);



                     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtShortTerm']")).Clear();

                  //      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtShortTerm']")).SendKeys("Test Immediate");

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtMediumTerm']")).Clear();

                  //      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtMediumTerm']")).SendKeys("Test Medium-Long Term ");

                     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtLongTerm']")).Clear();

                    //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtLongTerm']")).SendKeys("Test Ongoing ");


                        driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/ul/li[2]/a")).Click();

                        //      String add = driver.FindElement(By.XPath("//*[@id='ctl00_trfinancialobjectiverow']")).Text;
                        //      Console.WriteLine("Add FO is available or not" + add);
                        //      if(add!="Add Financial Objective")

                        driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/div/div[2]/div/a")).Click();
                        //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/div
                        //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/div/div[2]/div
                        string S270 = System.Configuration.ConfigurationManager.AppSettings["P_FO_Type"];
                        SelectElement oSelection270 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ddlFinancialObjectiveType']")));
                        oSelection270.SelectByText(S270);


                        string S271 = System.Configuration.ConfigurationManager.AppSettings["P_FO_Prio"];
                        SelectElement oSelection271 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ddlPriorityType']")));
                        oSelection271.SelectByText(S271);
                        //*[@id="ctl00_ddlPriorityType"]



                      driver.FindElement(By.XPath("//*[@id='ctl00_txtShortTerm']")).Clear();

                  //      driver.FindElement(By.XPath("//*[@id='ctl00_txtShortTerm']")).SendKeys("Partner Immediate");

                      driver.FindElement(By.XPath("//*[@id='ctl00_txtMediumTerm']")).Clear();

                 //       driver.FindElement(By.XPath("//*[@id='ctl00_txtMediumTerm']")).SendKeys("Partner Medium-Long Term ");

                       driver.FindElement(By.XPath("//*[@id='ctl00_txtLongTerm']")).Clear();

                  //      driver.FindElement(By.XPath("//*[@id='ctl00_txtLongTerm']")).SendKeys("Partner Ongoing ");



                        Console.WriteLine("Add FO is available OK");
                        driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

    *************/

                    }
                }

            }



            //  }
            // }

