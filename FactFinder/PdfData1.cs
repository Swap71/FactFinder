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


namespace FactFinder
{
    class PdfData1
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
        [Test]
        public void PDF()
        {
            Thread.Sleep(2000);
            /*        string title = driver.Title;
                    Console.WriteLine("Title of the web page is -> " + title);
                    Assert.IsTrue(title.Contains("My Dashboard"), title + " doesn't contains 'title.'");

                    */



            driver.Manage().Window.Maximize();

            /*        driver.FindElement(By.XPath("//*[@id='ctl00_HyperLink1']")).Click();
                    driver.FindElement(By.XPath(".//*[@id='hlFacts']")).Click();
                    driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

                    Console.WriteLine("PD1");

                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);*/


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
            /******/
            var pdf_filename = "D:\\PDF Test1.pdf";

            var reader = new PdfReader(pdf_filename);
            {
                var fields = reader.AcroFields.Fields;

                /***  string val = reader.AcroFields.GetField("UserName");

                  string val1 = reader.AcroFields.GetField("Password");***/

                /***/
                string val = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.0.PersonalDetails.user");

                string val1 = reader.AcroFields.GetField("SaveInputJSON.PersonalDetails.1.PersonalDetails.user");

                string val2 = reader.AcroFields.GetField("SaveInputJSON.Date");



                // SaveInputJSON.PersonalDetails.0.PersonalDetails.user
                // SaveInputJSON.PersonalDetails.1.PersonalDetails.user

                //    Response.Write("SaveInputJSON.ClientName" + " : " + val + " <br/");
                Console.WriteLine("Client+" + val);
                Console.WriteLine("Partner+" + val1);
                Console.WriteLine("Date+" + val2);

                /************/


                IWebElement element = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ClientName"));


                var C_USERNAME = System.Configuration.ConfigurationManager.AppSettings["C_USERNAME"];


                Console.WriteLine(string.Format("Given Name is : ", C_USERNAME));
                ///  Console.WriteLine(string.Format("Given Name is : ", val));
                element.SendKeys(val);

                //  driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ClientName")).SendKeys("Jeff1");

                Console.WriteLine("Enter Search");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_btnSearch']")).Click();

                Console.WriteLine("Click on Search button");


                for (int i = 0; i <= 20; i++)
                {


                    //    String ss = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAR_ctl00__" + i + "']/td[2]")).Text;
                    /*                String gn = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgUsers_ctl00__" + i + "']/td[4]")).Text;*/




                    string s = System.Configuration.ConfigurationManager.AppSettings["C_USERNAME"];
                    if (!String.IsNullOrEmpty(s))
                    {

                        /***          Console.WriteLine("C_Given Name is:" + gn);***/
                        /***                    String sn = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgUsers_ctl00__" + i + "']/td[5]")).Text;**/


                        string s1 = System.Configuration.ConfigurationManager.AppSettings[val];
                        if (String.IsNullOrEmpty(s1))

                        {

                            //                  Console.WriteLine("Given Name is:" + sn);


                            Console.WriteLine("Into Loop i is +" + i);


                            var im1 = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgUsers_ctl00__" + i + "']/td[7]"));


                            Console.WriteLine("i value chk is +" + i);

                            im1.Click();

                            break;
                        }
                    }
                }
                //  }
                Thread.Sleep(1000);


                driver.FindElement(By.XPath("//*[@id='hlFacts']")).Click();


                //    driver.FindElement(By.XPath("//*[@id='ctl00_HyperLink1']")).Click();
                //   driver.FindElement(By.XPath(".//*[@id='hlFacts']")).Click();
                driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

                Console.WriteLine("PD1");

                //   WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlPersonalDetails']")).Click();


                //       wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='aspnetFor']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/div/div[1]/div/div[1]/table/tbody/tr[2]/td")));


                String message1 = driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientGivenNames']")).Text;
                Console.WriteLine("Message1 is :" + message1);
                Thread.Sleep(2000);

                string S92 = System.Configuration.ConfigurationManager.AppSettings["C_GIVEN NAME"];
                string actualvalue = driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientGivenNames']")).GetAttribute("Value");
                Console.WriteLine("actualvalue IS " + actualvalue);
                //Assert.IsTrue(actualvalue.Contains("Client29MARCH"), actualvalue + " doesn't contains 'Mark1.'"); 
                /******            Assert.IsTrue(actualvalue.Contains(S92), actualvalue + "Not Equal");*************/
                
                string actualvalue1 = driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientDateOfBirth']")).GetAttribute("Value");
                Console.WriteLine("actualvalue 1 IS " + actualvalue1);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientDateOfBirth']")).Clear();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientDateOfBirth']")).SendKeys(val2);

               //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientDateOfBirth']")).SendKeys(actualvalue1);


                //       string actualvalue1 = driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientDateOfBirth']")).GetAttribute("Value");

                //            Assert.IsTrue(actualvalue1.Contains(S93), actualvalue1 + "Not Equal");

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientAdviserNotes']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientAdviserNotes']")).SendKeys("Notes for Test");
                /****
                string S94 = System.Configuration.ConfigurationManager.AppSettings["PCM"];

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[2]/a")).Click();
                SelectElement AdvPD1 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ddlClientContactMethod']")));

                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[4]/a


                // SelectElement oSelection11 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_PartnerSuperRow_0_ddlSuperFundType']")));

                AdvPD1.SelectByText(S94);



                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[4]/a")).Click();
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelative_0_txtName"]

                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[4]/a
                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/div/div[5]/div/a")).Click();
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtName"]
                Console.WriteLine("Add Nearest Relative");

                Thread.Sleep(2000);
                //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelative_0_txtName']")).SendKeys("Jeff Don");
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelative_0_txtName"]
                string S95 = System.Configuration.ConfigurationManager.AppSettings["Name"];

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtName"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtName']")).SendKeys(S95);



                //     string S96 = ConfigurationManager.AppSettings["ADR1"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRAddress']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRAddress']")).SendKeys("Unit 1");
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelative_0_txtNRAddress"]



                //      string S97 = ConfigurationManager.AppSettings["ADR2"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRAddress1']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRAddress1']")).SendKeys("Collins Street");


                string S98 = System.Configuration.ConfigurationManager.AppSettings["SubR"];


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRSuburb']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRSuburb']")).SendKeys("Melbourne");

                Thread.Sleep(1000);
                //*[@id="ddlClientState"]


                string S99 = System.Configuration.ConfigurationManager.AppSettings["StatR"];

                SelectElement oSelection29 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_ddlNRState']")));



                oSelection29.SelectByText(S99);


                string S100 = System.Configuration.ConfigurationManager.AppSettings["PostR"];

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_ddlNRCountry"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRPostCode']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRPostCode']")).SendKeys(S100);
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelative_0_txtNRPostCode"]

                /*         string S101 = System.Configuration.ConfigurationManager.AppSettings["CntR"];


                           SelectElement oSelection101 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_ddlNRCountry']")));
             //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_ddlNRCountry"]
             //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRPostCode"]
             //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_ddlNRCountry"]

             oSelection101.SelectByText(S101);
             */
                /******OK******************************************
                string S102 = System.Configuration.ConfigurationManager.AppSettings["ContR"];


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRContactNumber']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRContactNumber']")).SendKeys(S102);

                string S103 = System.Configuration.ConfigurationManager.AppSettings["RelR"];


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRRelationship']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRRelationship']")).SendKeys("Cousine");


                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                Console.WriteLine("Nearest Relartives SAVED");

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[5]/a")).Click();

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientHobbies"]

                //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientHobbie']")).Clear();
                //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientHobbie']")).SendKeys("Cricket");

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientHobbyNotes']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientHobbyNotes']")).SendKeys("Test Notes");


                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[6]/a")).Click();

                string S104 = System.Configuration.ConfigurationManager.AppSettings["DepN"];
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientDependantRow_0_txtDependantName"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientDependantRow_0_txtDependantName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientDependantRow_0_txtDependantName']")).SendKeys(S104);

                string S105 = System.Configuration.ConfigurationManager.AppSettings["DepRel"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientDependantRow_0_txtDependantRelationship']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientDependantRow_0_txtDependantRelationship']")).SendKeys(S105);

                string S106 = System.Configuration.ConfigurationManager.AppSettings["Depdob"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientDependantRow_0_txtDependantDateOfBirth']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientDependantRow_0_txtDependantDateOfBirth']")).SendKeys(S106);


                //    string S107 = ConfigurationManager.AppSettings["Depfin"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientDependantRow_0_cbDependantFinancialNo']")).Click();


                string S108 = System.Configuration.ConfigurationManager.AppSettings["Depgen"];


                SelectElement oSelection108 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientDependantRow_0_ddlDependantGender']")));

                oSelection108.SelectByText(S108);

                string S109 = System.Configuration.ConfigurationManager.AppSettings["Deptyp"];
                SelectElement oSelection109 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientSchoolRow_0_ddlSchoolType']")));
                oSelection109.SelectByText(S109);


                string S110 = System.Configuration.ConfigurationManager.AppSettings["Depn"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientSchoolRow_0_txtSchoolName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientSchoolRow_0_txtSchoolName']")).SendKeys(S110);



                string S111 = System.Configuration.ConfigurationManager.AppSettings["Depc"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientSchoolRow_0_txtSchoolCost']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientSchoolRow_0_txtSchoolCost']")).SendKeys(S111);


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_cbClientGovernmentAllwanceYes']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_cbClientStudyingFullTimeNo']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_cbClientHaveIllnessNo']")).Click();
                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
                //      driver.FindElement(By.XPath("//*[@id='aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a')).Click();
                /*     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientGivenNames']"));

                     string S91 = ConfigurationManager.AppSettings["C_GIVEN NAME"];
                     String Name = driver.FindElement(By.CssSelector("body")).Text;

                     Assert.AreEqual(S91, Name);*/

                // driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[7]/a")).Click();
                /******OK******************************************
                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[7]/a")).Click();

                string S112 = System.Configuration.ConfigurationManager.AppSettings["C_C_Occu"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtOccupation']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtOccupation']")).SendKeys(S112);



                string S113 = System.Configuration.ConfigurationManager.AppSettings["C_C_Pos"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtPosition']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtPosition']")).SendKeys(S113);


                string S114 = System.Configuration.ConfigurationManager.AppSettings["C_C_Emplo"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmployerName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmployerName']")).SendKeys(S114);


                string S115 = System.Configuration.ConfigurationManager.AppSettings["C_C_Stat"];
                SelectElement oSelection115 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_ddlEmploymentStatus']")));
                oSelection115.SelectByText(S115);

                string S116 = System.Configuration.ConfigurationManager.AppSettings["C_C_SDate"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtStartDate']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtStartDate']")).SendKeys(S116);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_cbChangeEmploymentNo']")).Click();

                string S117 = System.Configuration.ConfigurationManager.AppSettings["C_C_Leave"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtLeaveEntitlementDate']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtLeaveEntitlementDate']")).SendKeys(S117);


                string S118 = System.Configuration.ConfigurationManager.AppSettings["C_C_ALeave"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtAnnualLeave']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtAnnualLeave']")).SendKeys(S118);

                string S119 = System.Configuration.ConfigurationManager.AppSettings["C_C_LSLeave"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtLongServiceLeave']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtLongServiceLeave']")).SendKeys(S119);


                string S120 = System.Configuration.ConfigurationManager.AppSettings["C_C_SLeave"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtSickLeave']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtSickLeave']")).SendKeys(S120);

                string S121 = System.Configuration.ConfigurationManager.AppSettings["C_C_Other"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtOtherLeave']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtOtherLeave']")).SendKeys(S121);


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_cbTerminationPaymentNo']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_cbSignificantChangeYes']")).Click();

                string S122 = System.Configuration.ConfigurationManager.AppSettings["C_C_Adr1"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentAddress1']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentAddress1']")).SendKeys(S122);

                string S123 = System.Configuration.ConfigurationManager.AppSettings["C_C_Adr2"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentAddress2']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentAddress2']")).SendKeys(S123);


                string S124 = System.Configuration.ConfigurationManager.AppSettings["C_C_Subrb"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentSuburb']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentSuburb']")).SendKeys(S124);

                string S125 = System.Configuration.ConfigurationManager.AppSettings["C_C_State"];
                SelectElement oSelection125 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_ddlEmploymentState']")));

                oSelection125.SelectByText(S125);


                string S126 = System.Configuration.ConfigurationManager.AppSettings["C_C_Post"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentPostcode']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentPostcode']")).SendKeys(S126);

                string S127 = System.Configuration.ConfigurationManager.AppSettings["C_C_Cntry"];
                SelectElement oSelection127 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_ddlEmploymentCountry']")));

                oSelection127.SelectByText(S127);

                string S128 = System.Configuration.ConfigurationManager.AppSettings["C_C_Phone"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentPhone']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientEmploymentRow_0_txtEmploymentPhone']")).SendKeys(S128);



                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                Console.WriteLine("Save C Employment");

                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/div/div[3]/ul/li[2]/a")).Click();



                string S129 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_Occ"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentOccupation']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentOccupation']")).SendKeys(S129);


                string S130 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_Emplo"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentName']")).SendKeys(S130);


                string S131 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_Adr1"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentAddress1']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentAddress1']")).SendKeys(S131);

                string S132 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_Adr2"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentAddress2']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentAddress2']")).SendKeys(S132);


                string S133 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_Subrb"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentSuburb']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentSuburb']")).SendKeys(S133);



                string S134 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_State"];
                //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentState']")).Clear();
                //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentState']")).SendKeys(S134);
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentState"]


                SelectElement oSelection134 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentState']")));

                oSelection134.SelectByText(S134);





                string S135 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_Post"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentPostcode']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentPostcode']")).SendKeys(S135);



                string S136 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_Cntry"];
                //   driver.FindElement(By.XPath("//*[@id'ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentCountry']")).Clear();
                //    driver.FindElement(By.XPath("//*[@id'ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentCountry']")).SendKeys(S136);

                SelectElement oSelection136 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentCountry']")));

                oSelection136.SelectByText(S136);





                string S137 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_DateC"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentDateCommenced']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentDateCommenced']")).SendKeys(S137);


                string S138 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_Phone"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentPhone']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_txtPreviousEmploymentPhone']")).SendKeys(S138);



                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a

                Console.WriteLine("Save C Employment");

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[8]/a")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientAnniversaryRow_0_txtAnniversaryName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientAnniversaryRow_0_txtAnniversaryName']")).SendKeys("Stars");

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientAnniversaryRow_0_txtAnniversaryDate']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientAnniversaryRow_0_txtAnniversaryDate']")).SendKeys("18/04/1998");

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientAnniversaryRow_0_txtDetails']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientAnniversaryRow_0_txtDetails']")).SendKeys("Marriage Life");

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                //            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).SendKeys("Marriage Life");
                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a         

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a")).Click();
                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a




                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[2]/a")).Click();

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[2]/table/tbody/tr[1]/td/div/label/span")).Click();



                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[3]/a")).Click();

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[3]/div[1]/table/tbody[1]/tr[2]/td/div/label/span")).Click();


                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div[1]/div/div[3]/ul/li[2]/a")).Click();




                string S139 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Adr1"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousAddress1']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousAddress1']")).SendKeys(S139);


                string S140 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Adr2"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousAddress2']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousAddress2']")).SendKeys(S140);

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousAddress2"]

                string S141 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Subrb"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousSuburb']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousSuburb']")).SendKeys(S141);


                string S142 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_State"];
                SelectElement oSelection142 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_ddlPreviousState']")));

                oSelection142.SelectByText(S142);

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_ddlPreviousState"]

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousAddress1']")).Click();

                string S143 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Post"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousPostcode']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtPreviousPostcode']")).SendKeys(S143);


                string S144 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Cntry"];
                SelectElement oSelection144 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_ddlPreviousCountry']")));

                oSelection144.SelectByText(S144);

                string S145 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_DateC"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtDateCommenced']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousAddressRow_0_txtDateCommenced']")).SendKeys(S145);

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a")).Click();
                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a
                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[4]/a")).Click();

                string S146 = System.Configuration.ConfigurationManager.AppSettings["PName"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtName']")).SendKeys(S146);
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtName"]


                string S147 = System.Configuration.ConfigurationManager.AppSettings["PADR1"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRAddress']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRAddress']")).SendKeys(S147);


                string S148 = System.Configuration.ConfigurationManager.AppSettings["PADR2"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRAddress1']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRAddress1']")).SendKeys(S148);


                string S149 = System.Configuration.ConfigurationManager.AppSettings["PSubR"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRSuburb']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRSuburb']")).SendKeys(S149);


                string S150 = System.Configuration.ConfigurationManager.AppSettings["PStatR"];
                SelectElement oSelection150 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_ddlNRState']")));
                //                                new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_ddlNRState']
                oSelection150.SelectByText(S150);


                string S151 = System.Configuration.ConfigurationManager.AppSettings["PPostR"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRPostCode']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRPostCode']")).SendKeys(S151);

                string S152 = System.Configuration.ConfigurationManager.AppSettings["PCntR"];
                //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelative_0_ddlNRCountry']")).Clear();
                //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelative_0_txtNRPostCode']")).SendKeys(S152);
                //   string S150 = ConfigurationManager.AppSettings["PStatR"];
                /*****       SelectElement oSelection152 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControlRow_PersonalDetailsControl_PartnerNearestRelativeRow_0_ddlNRCountry']")));
              //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_ddlNRCountry"]
              //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_ddlNRCountry"]
                       oSelection152.SelectByText(S152);*/

                /******OK******************************************
                string S153 = System.Configuration.ConfigurationManager.AppSettings["PContR"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRContactNumber']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRContactNumber']")).SendKeys(S153);

                string S154 = System.Configuration.ConfigurationManager.AppSettings["PRelR"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRRelationship']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtNRRelationship']")).SendKeys(S154);



                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[5]/a")).Click();
                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[5]/a
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtPartnerHobbies']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtPartnerHobbies']")).SendKeys("Cricket,Chess,Travelling");

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[1]/a
                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a
                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[6]/a")).Click();
                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[6]/a

                //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div[2]/div[1]/a")).Click();


                string S155 = System.Configuration.ConfigurationManager.AppSettings["PDepN"];

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_txtDependantName"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_txtDependantName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_txtDependantName']")).SendKeys(S155);

                //    driver.FindElement(By.XPath("//*[@id='ctl00_txtDependantName']")).Clear();
                //    driver.FindElement(By.XPath("//*[@id='ctl00_txtDependantName']")).SendKeys(S155);

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_txtDependantName"]

                string S156 = System.Configuration.ConfigurationManager.AppSettings["PDepRel"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_txtDependantRelationship']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_txtDependantRelationship']")).SendKeys(S156);

                string S157 = System.Configuration.ConfigurationManager.AppSettings["PDepdob"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_txtDependantDateOfBirth']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_txtDependantDateOfBirth']")).SendKeys(S157);



                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_cbDependantFinancialNo']")).Click();



                string S158 = System.Configuration.ConfigurationManager.AppSettings["PDepgen"];
                SelectElement oSelection158 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_ddlDependantGender']")));

                oSelection158.SelectByText(S158);

                //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_ddlDependantGender']")).Clear();
                //              driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_ddlDependantGender']")).SendKeys(S158);


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerDependantRow_0_IsDependentClientPartnerrow']/td[2]/div/label/span")).Click();


                string S159 = System.Configuration.ConfigurationManager.AppSettings["PDeptyp"];

                SelectElement oSelection159 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerSchoolRow_0_ddlSchoolType']")));

                oSelection159.SelectByText(S159);


                //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerSchoolRow_0_ddlSchoolType']")).Clear();
                //            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerSchoolRow_0_ddlSchoolType']")).SendKeys(S159);

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerSchoolRow_0_ddlSchoolType"]

                string S160 = System.Configuration.ConfigurationManager.AppSettings["PDepn"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerSchoolRow_0_txtSchoolName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerSchoolRow_0_txtSchoolName']")).SendKeys(S160);



                string S161 = System.Configuration.ConfigurationManager.AppSettings["PDepc"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerSchoolRow_0_txtSchoolCost']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerSchoolRow_0_txtSchoolCost']")).SendKeys(S161);



                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[7]/a")).Click();

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div[3]/ul/li[1]/a")).Click();
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtOccupation"]
                string S162 = System.Configuration.ConfigurationManager.AppSettings["P_C_Occu"];
                // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtOccupation']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtOccupation']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtOccupation']")).SendKeys(S162);



                string S163 = System.Configuration.ConfigurationManager.AppSettings["P_C_Pos"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtPosition']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtPosition']")).SendKeys(S163);


                string S164 = System.Configuration.ConfigurationManager.AppSettings["P_C_Emplo"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmployerName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmployerName']")).SendKeys(S164);


                string S165 = System.Configuration.ConfigurationManager.AppSettings["P_C_Stat"];
                SelectElement oSelection165 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_ddlEmploymentStatus']")));
                oSelection165.SelectByText(S165);

                string S166 = System.Configuration.ConfigurationManager.AppSettings["P_C_SDate"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtStartDate']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtStartDate']")).SendKeys(S166);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_cbChangeEmploymentNo']")).Click();

                string S167 = System.Configuration.ConfigurationManager.AppSettings["P_C_Leave"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtLeaveEntitlementDate']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtLeaveEntitlementDate']")).SendKeys(S167);


                string S168 = System.Configuration.ConfigurationManager.AppSettings["P_C_ALeave"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtAnnualLeave']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtAnnualLeave']")).SendKeys(S168);

                string S169 = System.Configuration.ConfigurationManager.AppSettings["P_C_LSLeave"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtLongServiceLeave']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtLongServiceLeave']")).SendKeys(S169);


                string S170 = System.Configuration.ConfigurationManager.AppSettings["P_C_SLeave"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtSickLeave']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtSickLeave']")).SendKeys(S170);

                string S171 = System.Configuration.ConfigurationManager.AppSettings["P_C_Other"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtOtherLeave']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtOtherLeave']")).SendKeys(S171);


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_cbTerminationPaymentNo']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_cbSignificantChangeYes']")).Click();

                string S172 = System.Configuration.ConfigurationManager.AppSettings["P_C_Adr1"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentAddress1']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentAddress1']")).SendKeys(S172);

                string S173 = System.Configuration.ConfigurationManager.AppSettings["P_C_Adr2"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentAddress2']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentAddress2']")).SendKeys(S173);


                string S174 = System.Configuration.ConfigurationManager.AppSettings["P_C_Subrb"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentSuburb']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentSuburb']")).SendKeys(S174);

                string S175 = System.Configuration.ConfigurationManager.AppSettings["P_C_State"];
                SelectElement oSelection175 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_ddlEmploymentState']")));

                oSelection175.SelectByText(S175);


                string S176 = System.Configuration.ConfigurationManager.AppSettings["P_C_Post"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentPostcode']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentPostcode']")).SendKeys(S176);

                string S177 = System.Configuration.ConfigurationManager.AppSettings["P_C_Cntry"];
                SelectElement oSelection177 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_ddlEmploymentCountry']")));

                oSelection177.SelectByText(S177);

                string S178 = System.Configuration.ConfigurationManager.AppSettings["P_C_Phone"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentPhone']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtEmploymentPhone']")).SendKeys(S178);



                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                Console.WriteLine("Save P Employment");

                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div[3]/ul/li[2]/a")).Click();



                string S179 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Occ"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentOccupation']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentOccupation']")).SendKeys(S179);


                string S180 = System.Configuration.ConfigurationManager.AppSettings["C_Prev_Emplo"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentName']")).SendKeys(S180);


                string S181 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Adr1"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentAddress1']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentAddress1']")).SendKeys(S181);

                string S182 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Adr2"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentAddress2']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentAddress2']")).SendKeys(S182);


                string S183 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Subrb"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentSuburb']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentSuburb']")).SendKeys(S183);



                string S184 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_State"];
                //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentState']")).Clear();
                //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentState']")).SendKeys(S134);
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentState"]


                SelectElement oSelection184 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_ddlPreviousEmploymentState']")));

                oSelection184.SelectByText(S184);





                string S185 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Post"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentPostcode']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentPostcode']")).SendKeys(S185);



                string S186 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Cntry"];
                //   driver.FindElement(By.XPath("//*[@id'ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentCountry']")).Clear();
                //    driver.FindElement(By.XPath("//*[@id'ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientPreviousEmploymentRow_0_ddlPreviousEmploymentCountry']")).SendKeys(S136);

                SelectElement oSelection186 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_ddlPreviousEmploymentCountry']")));

                oSelection186.SelectByText(S186);





                string S187 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_DateC"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentDateCommenced']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentDateCommenced']")).SendKeys(S187);


                string S188 = System.Configuration.ConfigurationManager.AppSettings["P_Prev_Phone"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentPhone']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerPreviousEmploymentRow_0_txtPreviousEmploymentPhone']")).SendKeys(S188);



                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div[3]/ul/li[2]/a

                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a

                Console.WriteLine("Save Partner Prev Employment");
                //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[6]/a")).Click();





                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[8]/a")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerAnniversaryRow_0_txtAnniversaryName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerAnniversaryRow_0_txtAnniversaryName']")).SendKeys("Zumba");

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerAnniversaryRow_0_txtAnniversaryDate']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerAnniversaryRow_0_txtAnniversaryDate']")).SendKeys("24/10/1989");

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerAnniversaryRow_0_txtDetails']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerAnniversaryRow_0_txtDetails']")).SendKeys("Life");

                //
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerAnniversaryRow_0_tranniversaryrow"]/td[4]/div/label/spandriver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).SendKeys("Marriage Life");
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerAnniversaryRow_0_tranniversaryrow']/td[4]/div/label/span")).Click();

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                Thread.Sleep(1000);

                //Advanced C Fact Finder
                //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlFinancialObjectives']")).Click();

                string S272 = System.Configuration.ConfigurationManager.AppSettings["C_FO_Amnt"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtAmount']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtAmount']")).SendKeys(S272);



                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtClientIssuesToConsider']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtClientIssuesToConsider']")).SendKeys("Not @ ALL");

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtClientPreviousExperience']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtClientPreviousExperience']")).SendKeys("Never & I am new ");

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtClientPastInvestmentExperience"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtClientPastInvestmentExperience']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtClientPastInvestmentExperience']")).SendKeys("No");


                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/ul/li[2]/a")).Click();


                string S273 = System.Configuration.ConfigurationManager.AppSettings["P_FO_Amnt"];
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_txtAmount"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_txtAmount']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_txtAmount']")).SendKeys(S273);

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtClientIssuesToConsider"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtPartnerIssuesToConsider']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtPartnerIssuesToConsider']")).SendKeys("Not @ ALL");
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtPartnerIssuesToConsider"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtPartnerPreviousExperience']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtPartnerPreviousExperience']")).SendKeys("Never & I am new ");

                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtClientPastInvestmentExperience"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtPartnerPastInvestmentExperience']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_FinancialObjectivesControl_txtPartnerPastInvestmentExperience']")).SendKeys("No");




                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                Thread.Sleep(1000);

                /***Advance Reason for Advice******
                //       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlReasonForAdvice']")).Click();

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[4]/div[2]/div/div[1]/div[1]/div/table/tbody/tr/td[2]/div/label/span")).Click();


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_txtClientAdditionalNotes']")).Click();


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_cbClientHavePreferencesYes']")).Click();


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_txtClientPreferences']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_txtClientPreferences']")).SendKeys("Test 1");

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_txtClientAdviserNotes']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_txtClientAdviserNotes']")).SendKeys("Test PortFolio");



                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_cbClientHaveQues1Preferences1']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_cbClientHaveQues2Preferences2']")).Click();


                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[4]/div[2]/ul/li[2]/a")).Click();


                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[4]/div[2]/div/div[2]/div[1]/div/table/tbody/tr/td[2]/div/label/span")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_txtPartnerAdditionalNotes']")).Clear();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_txtPartnerAdditionalNotes']")).SendKeys("Ok....");


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_cbPartnerHavePreferencesNo']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_txtPartnerAdviserNotes']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_txtPartnerAdviserNotes']")).SendKeys("Created Scope as per Required");


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_cbPartnerHaveQues1Preferences1']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ReasonForAdviceControl_cbPartnerHaveQues2Preferences3']")).Click();

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();



                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlIncomeExpenses']")).Click();


                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[1]/ul/li[2]/a")).Click();


                string S189 = System.Configuration.ConfigurationManager.AppSettings["C_IR_INCOME_Name"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtIncomeItem']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtIncomeItem']")).SendKeys(S189);



                string S190 = System.Configuration.ConfigurationManager.AppSettings["C_IR_INCOME_Date"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtDateIncurred']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtDateIncurred']")).SendKeys(S190);

                string S191 = System.Configuration.ConfigurationManager.AppSettings["C_IR_INCOME_Freq"];
                //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtDateIncurred']")).Clear();
                // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtDateIncurred']")).SendKeys(S189);

                SelectElement oSelection191 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_ddlFrequency']")));

                oSelection191.SelectByText(S191);


                string S192 = System.Configuration.ConfigurationManager.AppSettings["C_IR_INCOME_Amnt"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtAmount']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtAmount']")).SendKeys(S192);


                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[1]/ul/li[3]/a")).Click();

                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[1]/ul/li[4]/a
                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[1]/ul/li[4]/a")).Click();

                string S193 = System.Configuration.ConfigurationManager.AppSettings["C_IR_Expenses_Name"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularExpenseRow_0_txtExpenseItem']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularExpenseRow_0_txtExpenseItem']")).SendKeys(S193);
                Console.WriteLine("OK 1");

                string S194 = System.Configuration.ConfigurationManager.AppSettings["C_IR_Expenses_Date"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularExpenseRow_0_txtDateIncurred']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularExpenseRow_0_txtDateIncurred']")).SendKeys(S194);

                string S195 = System.Configuration.ConfigurationManager.AppSettings["C_IR_Expenses_Freq"];
                SelectElement oSelection195 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularExpenseRow_0_ddlFrequency']")));

                oSelection195.SelectByText(S195);

                string S196 = System.Configuration.ConfigurationManager.AppSettings["C_IR_Expenses_Amnt"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularExpenseRow_0_txtAmount']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularExpenseRow_0_txtAmount']")).SendKeys(S196);



                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[1]/ul/li[5]/a")).Click();

                string S197 = System.Configuration.ConfigurationManager.AppSettings["C_Savings_Name"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientSavingRow_0_txtDescription']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientSavingRow_0_txtDescription']")).SendKeys(S197);


                string S198 = System.Configuration.ConfigurationManager.AppSettings["C_Savings_Amnt"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientSavingRow_0_txtProjectedAmount']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientSavingRow_0_txtProjectedAmount']")).SendKeys(S198);


                string S199 = System.Configuration.ConfigurationManager.AppSettings["C_Savings_Freq"];

                SelectElement oSelection199 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientSavingRow_0_ddlPaymentFrequency']")));

                oSelection199.SelectByText(S199);

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[1]/ul/li[5]/a")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_cbClientChangeNo']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_cbClientComfortableYes']")).Click();

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                Console.WriteLine("Client iNCOME,eXPENSES");
                ***/


            }
        }
    }

}