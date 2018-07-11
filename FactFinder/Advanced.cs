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
    class Advanced
    {

        IWebDriver driver;
        string Email;



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
        public void AdvancedCFactFinder()
        {
            Thread.Sleep(1000);
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

            //   Thread.Sleep(1000);

            Console.WriteLine("Clicked Search");



            //  driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_HyperLinkAdminPlanners']")).Click();
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_btnSearch']")).Click();
            Console.WriteLine("sEARCH");

            Thread.Sleep(1000);

            IWebElement element = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ClientName"));


            var C_USERNAME = System.Configuration.ConfigurationManager.AppSettings["C_USERNAME"];


            Console.WriteLine(string.Format("Given Name is : ", C_USERNAME));
            ///  Console.WriteLine(string.Format("Given Name is : ", val));
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


                    string s1 = System.Configuration.ConfigurationManager.AppSettings["C_USERNAME"];
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
            //       Assert.IsTrue(actualvalue.Contains(S92), actualvalue + "Not Equal");

            string S93 = System.Configuration.ConfigurationManager.AppSettings["C_DOB"];
            string actualvalue1 = driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientDateOfBirth']")).GetAttribute("Value");
            Console.WriteLine("actualvalue IS " + actualvalue1);
            //            Assert.IsTrue(actualvalue1.Contains(S93), actualvalue1 + "Not Equal");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientAdviserNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientAdviserNotes']")).SendKeys("Notes for Test");

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
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelative_0_txtName"]
            //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtName']")).Clear();
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
            /******OK******************************************/
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
            /******OK******************************************/
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
            // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerNearestRelativeRow_0_txtName']")).Clear();
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

            /******OK******************************************/
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

            /***Advance Reason for Advice******/
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


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/ul/li[2]/a")).Click();
            string S200 = System.Configuration.ConfigurationManager.AppSettings["P_RI_Type"];

            SelectElement oSelection200 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIncomeRow_0_ddlIncomeType']")));

            oSelection200.SelectByText(S200);


            //   driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[2]/ul/li[2]/a")).Click();

            string S201 = System.Configuration.ConfigurationManager.AppSettings["P_RI_Name"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIncomeRow_0_txtIncomeName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIncomeRow_0_txtIncomeName']")).SendKeys(S201);

            string S202 = System.Configuration.ConfigurationManager.AppSettings["P_RI_Gross"];


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIncomeRow_0_txtAnnualGrossIncomeAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIncomeRow_0_txtAnnualGrossIncomeAmount']")).SendKeys(S202);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[2]/ul/li[2]/a")).Click();


            string S203 = System.Configuration.ConfigurationManager.AppSettings["P_II_Name"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_txtIncomeItem']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_txtIncomeItem']")).SendKeys(S203);




            string S204 = System.Configuration.ConfigurationManager.AppSettings["P_II_Date"];
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_txtDateIncurred"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_txtDateIncurred']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_txtDateIncurred']")).SendKeys(S204);



            string S205 = System.Configuration.ConfigurationManager.AppSettings["P_II_Freq"];

            SelectElement oSelection205 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_ddlFrequency']")));
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_ddlFrequency"]
            oSelection205.SelectByText(S205);


            string S206 = System.Configuration.ConfigurationManager.AppSettings["P_II_Amnt"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_txtAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_txtAmount']")).SendKeys(S206);



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[2]/ul/li[3]/a")).Click();



            string S207 = System.Configuration.ConfigurationManager.AppSettings["P_RE_Name"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerExpenseRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerExpenseRow_0_txtDescription']")).SendKeys(S207);

            string S208 = System.Configuration.ConfigurationManager.AppSettings["P_RE_Freq"];

            SelectElement oSelection208 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerExpenseRow_0_ddlPaymentFrequency']")));
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_ddlFrequency"]
            oSelection208.SelectByText(S208);


            string S209 = System.Configuration.ConfigurationManager.AppSettings["P_RE_Amnt"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerExpenseRow_0_txtProjectedAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerExpenseRow_0_txtProjectedAmount']")).SendKeys(S209);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[2]/ul/li[4]/a")).Click();

            string S210 = System.Configuration.ConfigurationManager.AppSettings["P_IE_Name"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_txtExpenseItem']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_txtExpenseItem']")).SendKeys(S210);


            string S211 = System.Configuration.ConfigurationManager.AppSettings["P_IE_Date"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_txtDateIncurred']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_txtDateIncurred']")).SendKeys(S211);


            string S212 = System.Configuration.ConfigurationManager.AppSettings["P_IE_Freq"];

            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_ddlFrequency']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_ddlFrequency']")).SendKeys(S212);
            SelectElement oSelection212 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_ddlFrequency']")));
            oSelection212.SelectByText(S212);


            string S213 = System.Configuration.ConfigurationManager.AppSettings["P_IE_Amnt"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_txtAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_txtAmount']")).SendKeys(S213);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[2]/ul/li[5]/a")).Click();


            string S214 = System.Configuration.ConfigurationManager.AppSettings["P_Savings_Names"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerSavingRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerSavingRow_0_txtDescription']")).SendKeys(S214);




            string S215 = System.Configuration.ConfigurationManager.AppSettings["P_Savings_Amnt"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerSavingRow_0_txtProjectedAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerSavingRow_0_txtProjectedAmount']")).SendKeys(S215);

            string S216 = System.Configuration.ConfigurationManager.AppSettings["P_Savings_Freq"];
            SelectElement oSelection216 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerSavingRow_0_ddlPaymentFrequency']")));
            oSelection216.SelectByText(S216);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_cbPartnerChangeYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_txtPartnerChangeDetails']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_txtPartnerChangeDetails']")).SendKeys("Testing Purpose");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_cbPartnerComfortableNo']")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            /***************ok * ************/
            /*****OK****/
            /*****          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities']")).Click();
                      //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities"]//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities"]

                      //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities"]
                      string S218 = System.Configuration.ConfigurationManager.AppSettings["C_Invests_DP"];

                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtDateAcquired']")).Clear();
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtDateAcquired']")).SendKeys(S218);



                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities']")).Click();


                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtDateAcquired']")).Click();

                      //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes"]
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes']")).Click();

                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo']")).Click();
                      //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo"]

                  //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlVehicleType']")).Click();

                      string Inc208 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_VehicleType"];

                      SelectElement oSelectionInc208 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlVehicleType']")));
                      oSelectionInc208.SelectByText(Inc208);

                      //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName"]
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).Clear();
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).SendKeys("Test InvestMents");


                      string Inc209 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_OwnerType"];

                      SelectElement oSelectionInc209 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType']")));
                      oSelectionInc209.SelectByText(Inc209);

                      string S217 = System.Configuration.ConfigurationManager.AppSettings["C_Invests_CP"];

                      SelectElement oSelection217 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlCompanyPurpose']")));
                      oSelection217.SelectByText(S217);




                      string S219 = System.Configuration.ConfigurationManager.AppSettings["C_Invests_Emp"];

                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")).Clear();
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")).SendKeys(S219);


                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbCompanyIncludeInAdviceYes']")).Click();

                      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
                      ************************/
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtDateAcquired']")).Click();

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes"]
            //           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes']")).Click();

            //           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo']")).Click();
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo"]

            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlVehicleType']")).Click();

            string Inc208 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_VehicleType"];

            SelectElement oSelectionInc208 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlVehicleType']")));
            oSelectionInc208.SelectByText(Inc208);

            if (Inc208 == "Managed Fund" || Inc208 == "Stock")
            {
                string Inc211 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_Units"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtUnits']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtUnits']")).SendKeys(Inc211);

                string Inc2132 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_pa"];

                driver.FindElement(By.XPath("//*[@id='txtInvestmentfundstock']")).Clear();
                driver.FindElement(By.XPath("//*[@id='txtInvestmentfundstock']")).SendKeys(Inc2132);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbInvestmentfundstockReInvestIncomeYes']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbInvestmentfundstockassetRepayOnTPD']")).Click();


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbInvestmentfundstockassetRetainYes']")).Click();


            }

            else if (Inc208 == "Asset")
            {
                string Inc217 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_Centrelink"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtInvestmentassetCentrelinkValue']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtInvestmentassetCentrelinkValue']")).SendKeys(Inc217);

                string Inc218 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_AssetType"];
                SelectElement oSelectionInc218 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlAssetType']")));
                oSelectionInc218.SelectByText(Inc218);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbInvestmentfundstockassetRepayOnTrauma']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbInvestmentfundstockassetRetainNo']")).Click();
                //    driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlAssetType"]

            }
            else if (Inc208 == "Trust")
            {
                string Inc214 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_TrustType"];
                //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlTrustType']")).Clear();
                //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlTrustType']")).SendKeys(Inc214);

                SelectElement oSelectionInc214 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlTrustType']")));
                oSelectionInc214.SelectByText(Inc214);


                string Inc215 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_Trustee"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtTrustee']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtTrustee']")).SendKeys(Inc215);


                string Inc216 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_Beneficiaries"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtBeneficiaries']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtBeneficiaries']")).SendKeys(Inc216);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbTrustIncludeInAdviceYes']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbTrustCopyOfTrustYes']")).Click();
            }

            else if (Inc208 == "Investment Company")
            {

                string Inc219 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_CompanyPurpose"];
                SelectElement oSelectionInc219 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlCompanyPurpose']")));
                oSelectionInc219.SelectByText(Inc219);
                //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlCompanyPurpose']")).Clear();
                //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlCompanyPurpose']")).SendKeys(Inc219);

                string Inc220 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_NoOfEmployees"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")).SendKeys(Inc220);

                string Inc2201 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_Shareholders"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtShareholders']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtShareholders']")).SendKeys(Inc2201);



                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbCompanyIncludeInAdviceNo']")).Click();

                //    SelectElement oSelectionInc221 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")));
                //   oSelectionInc221.SelectByText(Inc221);
                //    driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlAssetType"]

            }

            else
            {
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).SendKeys("Test InvestMents");

                string Inc2091 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_OwnerType"];
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType"]
                SelectElement oSelectionInc2091 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType']")));
                oSelectionInc2091.SelectByText(Inc2091);


                string Inc2121 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_CurrentValue"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtCurrentValue']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtCurrentValue']")).SendKeys(Inc2121);


                string Inc2131 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_PurchasePrice"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo']")).Click();





                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtPrice']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtPrice']")).SendKeys(Inc2131);





            }


            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).SendKeys("Test InvestMents");


            string Inc209 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_OwnerType"];
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType"]
            SelectElement oSelectionInc209 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType']")));
            oSelectionInc209.SelectByText(Inc209);

            if (Inc209 == "Tenants in Common" || Inc209 == "Joint Tenants")
            {

                /****       string Inc210 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_OwnershipPercentClient"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtOwnershipPercentClient']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtOwnershipPercentClient']")).SendKeys(Inc210);
                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo"]


                       string Inc211 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_OwnershipPercentPartner"];
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtOwnershipPercentPartner']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtOwnershipPercentPartner']")).SendKeys(Inc210);
                       ******/
            }

            string Inc212 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_CurrentValue"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtCurrentValue']")).SendKeys(Inc212);


            string Inc213 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_PurchasePrice"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo']")).Click();





            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtPrice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtPrice']")).SendKeys(Inc213);


            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbTrustIncludeInAdviceYes']")).Click();

            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbTrustCopyOfTrustYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_txtClientInvestmentAdviserNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_txtClientInvestmentAdviserNotes']")).SendKeys("Test Adviser Notes");

            // }




            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();



            /*********
                        driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[1]/ul/li[2]/a")).Click();

                        string S220 = System.Configuration.ConfigurationManager.AppSettings["C_Assets_Owner"];

                        SelectElement oSelection220 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlOwnerType']")));
                        oSelection220.SelectByText(S220);


                        string S221 = System.Configuration.ConfigurationManager.AppSettings["C_Assets_PD"];

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtDateAcquired']")).Clear();
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtDateAcquired']")).SendKeys(S221);

                        string S222 = System.Configuration.ConfigurationManager.AppSettings["C_Assets_Deem"];

                        driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
                        driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S222);

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbdemedforcentrelinkYes']")).Click();

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbRetainYes']")).Click();

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbRepayOnTPD']")).Click();


                        string S223 = System.Configuration.ConfigurationManager.AppSettings["C_Assets_Type"];

                        SelectElement oSelection223 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlAssetType']")));
                        oSelection223.SelectByText(S223);



                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbdemedforcentrelinkYes']")).Click();

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbReInvestIncomeNo']")).Click();


                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbIsLoanAttachedYes']")).Click();

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_rbClientChangeInFutureAssetYes']")).Click();
                        driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();




                        ******/
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[1]/ul/li[2]/a")).Click();
            string S230 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Name"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtName']")).SendKeys(S230);


            string S231 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Owner"];

            SelectElement oSelection231 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlOwnerType']")));
            oSelection231.SelectByText(S231);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue"]
            string S232 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Esti"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtCurrentValue']")).SendKeys(S232);

            //  string S233 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];
            string S233 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Type"];
            SelectElement oSelection233 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlAssetType']")));
            oSelection233.SelectByText(S233);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlAssetType"]

            string S234 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtDateAcquired']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtDateAcquired']")).SendKeys(S234);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount"]

            string S235 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PA"];



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtPurchaseAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtPurchaseAmount']")).SendKeys(S235);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();
            string S236 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Inc"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();


            //    driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S236);


            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate"]

            string S237 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Matu"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtMaturityDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtMaturityDate']")).SendKeys(S237);
            //  driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
            // driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S236);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbdemedforcentrelinkNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbReInvestIncomeNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbRepayOnTPD']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbIsLoanAttachedNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[1]/ul/li[3]/a")).Click();


            /****/
            string C225 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Descr"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtName']")).SendKeys(C225);


            string C226 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_LA"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtCurrentValue']")).SendKeys(C226);



            string S224 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_LType"];

            SelectElement oSelection224 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlLoanType']")));
            oSelection224.SelectByText(S224);


            string S225 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_LN"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtProvider']")).SendKeys(S225);


            string S226 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_IType"];

            SelectElement oSelection226 = new SelectElement(driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlInterestType']")));
            oSelection226.SelectByText(S226);

            /*     string S227 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Freq"];

                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']")).Clear();
                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']")).SendKeys(S227);

                 */

            /******OK****/
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_rbRetainYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_rbRepayOnTrauma']")).Click();

            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']


            string S229 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Freq"];

            SelectElement oSelection229 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']")));
            oSelection229.SelectByText(S229);






            string S228 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Repay"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtRepayment']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtRepayment']")).SendKeys(S228);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_rbRepayOnTPD']")).Click();

            /*****OK***/
            /**/
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_cbClientDrawLoanYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_rbClientChangeInFutureLiabiitiesNo']")).Click();



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/ul/li[2]/a")).Click();
            /******/



            string IncP208 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_VehicleType"];

            SelectElement oSelectionIncP208 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_ddlVehicleType']")));
            oSelectionIncP208.SelectByText(IncP208);

            if (IncP208 == "Managed Fund" || IncP208 == "Stock")
            {
                string IncP211 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_Units"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtUnits']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtUnits']")).SendKeys(IncP211);

                string IncP2132 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_pa"];

                driver.FindElement(By.XPath("//*[@id='txtInvestmentfundstock']")).Clear();
                driver.FindElement(By.XPath("//*[@id='txtInvestmentfundstock']")).SendKeys(IncP2132);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbInvestmentfundstockReInvestIncomeYes']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbInvestmentfundstockassetRepayOnTPD']")).Click();


                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbInvestmentfundstockassetRetainYes']")).Click();


            }

            else if (IncP208 == "Asset")
            {
                string IncP217 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_Centrelink"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtInvestmentassetCentrelinkValue']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtInvestmentassetCentrelinkValue']")).SendKeys(IncP217);

                string IncP218 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_AssetType"];
                SelectElement oSelectionIncP218 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_ddlAssetType']")));
                oSelectionIncP218.SelectByText(IncP218);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbInvestmentfundstockassetRepayOnTrauma']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbInvestmentfundstockassetRetainNo']")).Click();
                //    driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlAssetType"]

            }
            else if (IncP208 == "Trust")
            {
                string IncP214 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_TrustType"];
                //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlTrustType']")).Clear();
                //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlTrustType']")).SendKeys(Inc214);

                SelectElement oSelectionIncP214 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_ddlTrustType']")));
                oSelectionIncP214.SelectByText(IncP214);


                string IncP215 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_Trustee"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtTrustee']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtTrustee']")).SendKeys(IncP215);


                string IncP216 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_Beneficiaries"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtBeneficiaries']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtBeneficiaries']")).SendKeys(IncP216);

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbTrustIncludeInAdviceYes']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbTrustCopyOfTrustYes']")).Click();
            }

            else if (IncP208 == "Investment Company")
            {

                string IncP219 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_CompanyPurpose"];
                SelectElement oSelectionIncP219 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_ddlCompanyPurpose']")));
                oSelectionIncP219.SelectByText(IncP219);
                //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlCompanyPurpose']")).Clear();
                //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlCompanyPurpose']")).SendKeys(Inc219);

                string IncP220 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_NoOfEmployees"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtNoOfEmployees']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtNoOfEmployees']")).SendKeys(IncP220);

                string IncP2201 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_Shareholders"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtShareholders']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtShareholders']")).SendKeys(IncP2201);



                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbCompanyIncludeInAdviceNo']")).Click();

                //    SelectElement oSelectionInc221 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")));
                //   oSelectionInc221.SelectByText(Inc221);
                //    driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlAssetType"]

            }
            //*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[2]/ul/li[2]/a
            else
            {
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtName']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtName']")).SendKeys("Test InvestMents");

                string IncP2091 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_OwnerType"];
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType"]
                SelectElement oSelectionIncP2091 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_ddlOwnerType']")));
                oSelectionIncP2091.SelectByText(IncP2091);


                string IncP2121 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_CurrentValue"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtCurrentValue']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtCurrentValue']")).SendKeys(IncP2121);


                string IncP2131 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_PurchasePrice"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbLoanYes']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbSellNo']")).Click();





                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtPrice']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtPrice']")).SendKeys(IncP2131);





            }


            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtName']")).SendKeys("Test InvestMents");


            string IncP209 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_OwnerType"];
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType"]
            SelectElement oSelectionIncP209 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_ddlOwnerType']")));
            oSelectionIncP209.SelectByText(Inc209);

            if (IncP209 == "Tenants in Common" || IncP209 == "Joint Tenants")
            {

                /***     string IncP210 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_OwnershipPercentClient"];

                     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtOwnershipPercentClient']")).Clear();
                     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtOwnershipPercentClient']")).SendKeys(IncP210);
                     //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo"]


                     string IncP211 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_OwnershipPercentPartner"];
                     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtOwnershipPercentPartner']")).Clear();
                     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtOwnershipPercentPartner']")).SendKeys(IncP210);
                     ******/
            }

            string IncP212 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_CurrentValue"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtCurrentValue']")).SendKeys(IncP212);


            string IncP213 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_PurchasePrice"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbLoanYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbSellNo']")).Click();





            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtPrice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtPrice']")).SendKeys(IncP213);


            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbTrustIncludeInAdviceYes']")).Click();

            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbTrustCopyOfTrustYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_txtPartnerInvestmentAdviserNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_txtPartnerInvestmentAdviserNotes']")).SendKeys("Test Adviser Notes");

            // }






            /*****************************************************************************
            string S238 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_LN"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider']")).SendKeys(S238);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider"]


            string S239 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_IT"];

            SelectElement oSelection239 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_ddlInterestType']")));
            oSelection239.SelectByText(S239);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_rbRetainYes']")).Click();



            string S240 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_TR"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtTermRemaining']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtTermRemaining']")).SendKeys(S240);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_rbRepayOnTrauma']")).Click();


            string S241 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_RA"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRedrawAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRedrawAmount']")).SendKeys(S241);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_rbRetainYes']")).Click();

            string S242 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_Freq"];
            SelectElement oSelection242 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_ddlPaymentFrequency']")));
            oSelection242.SelectByText(S242);



            string S243 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_Rep"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRepayment']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRepayment']")).SendKeys(S243);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_cbPartnerDrawLoanNo']")).Click();

//            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_rbClientChangeInFutureLiabiitiesYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
*****/



            /***     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbInvestmentfundstockassetSecurityForLoanYes']")).Click();

                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbInvestmentfundstockReInvestIncomeNo']")).Click();


                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbInvestmentfundstockassetRepayOnTPD']")).Click();****/

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[2]/ul/li[2]/a")).Click();

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName"]


            string S2301 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Name"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName']")).SendKeys(S2301);


            string S2311 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Owner"];

            SelectElement oSelection2311 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlOwnerType']")));
            oSelection2311.SelectByText(S2311);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue"]
            string S2321 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Esti"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).SendKeys(S2321);

            //  string S233 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];
            string S2331 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Type"];
            SelectElement oSelection2331 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlAssetType']")));
            oSelection233.SelectByText(S233);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlAssetType"]

            string S2341 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtDateAcquired']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtDateAcquired']")).SendKeys(S2341);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount"]

            string S2351 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PA"];



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount']")).SendKeys(S2351);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();
            string S2361 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Inc"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();


            //    driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S236);


            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate"]

            string S2371 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Matu"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate']")).SendKeys(S2371);
            //  driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
            // driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S236);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_rbdemedforcentrelinkNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_rbReInvestIncomeNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_rbRepayOnTPD']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_rbIsLoanAttachedNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[2]/ul/li[3]/a")).Click();



            string P225 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_Descr"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtName']")).SendKeys(P225);


            string P226 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_LA"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtCurrentValue']")).SendKeys(P226);



            string P224 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_LType"];

            SelectElement oSelectionP224 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_ddlLoanType']")));
            oSelectionP224.SelectByText(P224);


            string P2251 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_LN"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider']")).SendKeys(P2251);


            string P2261 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_IType"];

            SelectElement oSelectionP226 = new SelectElement(driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_ddlInterestType']")));
            oSelectionP226.SelectByText(P2261);


            /*******

            string S2381 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_LN"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider']")).SendKeys(S2381);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider"]


            string S2391 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_IT"];

            SelectElement oSelection2391 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_ddlInterestType']")));
            oSelection2391.SelectByText(S2391);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_rbRetainYes']")).Click();

            ****/

            string S2401 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_TR"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtTermRemaining']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtTermRemaining']")).SendKeys(S2401);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_rbRepayOnTrauma']")).Click();


            string S2411 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_RA"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRedrawAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRedrawAmount']")).SendKeys(S2411);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_rbRetainYes']")).Click();

            string S2421 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_Freq"];
            SelectElement oSelection2421 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_ddlPaymentFrequency']")));
            oSelection2421.SelectByText(S2421);



            string S2431 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_Rep"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRepayment']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRepayment']")).SendKeys(S2431);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_cbPartnerDrawLoanNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_rbPartnerChangeInFutureLiabiitiesYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlSuper']")).Click();




            string SC46 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_T"];
            SelectElement oSelectionSC46 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_ddlSuperFundType']")));
            oSelectionSC46.SelectByText(SC46);

            string S244 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_FT"];
            SelectElement oSelection244 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_ddlFundType']")));
            oSelection244.SelectByText(S244);

            string SC146 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_NAME"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtName']")).SendKeys(SC146);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtName"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtName']")).Click();

            string S245 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_UIO"];
            SelectElement oSelection245 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_ddlInvestmentOption']")));
            oSelection245.SelectByText(S245);


            string S246 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_DJ"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtDateJoined']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtDateJoined']")).SendKeys(S246);



            string S247 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_CY"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtContributionEmployer']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtContributionEmployer']")).SendKeys(S247);

            string S248 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_PY"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtContrSelfPrvYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtContrSelfPrvYear']")).SendKeys(S248);



            string S249 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_2PY"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtContrSelfPrv2Year']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtContrSelfPrv2Year']")).SendKeys(S249);




            string S250 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_TV"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtTransferValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtTransferValue']")).SendKeys(S250);


            string S251 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_MV"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtMaturityValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtMaturityValue']")).SendKeys(S251);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_rbReallocatedYes']")).Click();


            string S252 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_tya"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtClientNCCThisYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtClientNCCThisYear']")).SendKeys(S252);


            string S253 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_lya"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtClientNCCLastYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtClientNCCLastYear']")).SendKeys(S253);



            string S254 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_pya"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtClientNCCPrevYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtClientNCCPrevYear']")).SendKeys(S254);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[7]/div[2]/div[1]/ul/li[2]/a")).Click();

            /****         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbCGovernmentCoContributionYes']")).Click();

                     string S255 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_Contri"];
                     SelectElement oSelection255 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ddlCGovernmentCoContributionInvestment']")));
                     oSelection255.SelectByText(S255);
                 ****/
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbCGovernmentCoContributionNo']")).Click();



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbCBringForwardRuleNo']")).Click();



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbCTransitionalPhaseYes']")).Click();




            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[7]/div[2]/ul/li[2]/a")).Click();




            string SP46 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_T"];
            SelectElement oSelectionSP46 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlSuperFundType']")));
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlSuperFundType"]

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtName"]
            oSelectionSP46.SelectByText(SP46);

            string S256 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_FT"];
            SelectElement oSelection256 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlFundType']")));
            oSelection256.SelectByText(S256);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlFundType"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlFundType']")).Click();

            string SC256 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_NAME"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtName']")).SendKeys(SC256);


            string S257 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_UIO"];
            SelectElement oSelection257 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlInvestmentOption']")));
            oSelection257.SelectByText(S257);


            string S258 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_DJ"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtDateJoined']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtDateJoined']")).SendKeys(S258);



            string S259 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_CY"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContributionEmployer']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContributionEmployer']")).SendKeys(S259);

            string S2591 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_CY"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContrSelfCurrentYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContrSelfCurrentYear']")).SendKeys(S2591);


            string S260 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_PY"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContrSelfPrvYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContrSelfPrvYear']")).SendKeys(S260);



            string S261 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_2PY"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContrSelfPrv2Year']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContrSelfPrv2Year']")).SendKeys(S261);




            string S262 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_TV"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtTransferValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtTransferValue']")).SendKeys(S262);


            string S263 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_MV"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtMaturityValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtMaturityValue']")).SendKeys(S263);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_rbReallocatedYes']")).Click();


            string S264 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_tya"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtPartnerNCCThisYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtPartnerNCCThisYear']")).SendKeys(S264);


            string S265 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_lya"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtPartnerNCCLastYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtPartnerNCCLastYear']")).SendKeys(S265);



            string S266 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_pya"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtPartnerNCCPrevYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_txtPartnerNCCPrevYear']")).SendKeys(S266);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[7]/div[2]/div[2]/ul/li[2]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbPGovernmentCoContributionNo']")).Click();

            /**         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbPGovernmentCoContributionYes']")).Click();


                   //  Thread.Sleep(2000);
                     string S267 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_Contri"];
                     SelectElement oSelection267 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ddlPGovernmentCoContributionInvestment']")));
                     oSelection267.SelectByText(S267);
                 **/
            //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ddlPGovernmentCoContributionInvestment']")).Click();
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[7]/div[2]/div[1]/ul/li[2]/a

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbPBringForwardRuleYes']")).Click();



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbPTransitionalPhaseNo']")).Click();





            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            /**OK * ***********/

            Thread.Sleep(1000);

            /*******OK
                        //Advanced C Fact Finder
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();*****

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

                        /****OK***/

            //Esate Planning -Advanced 
            /*****            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();*****/


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlEstatePlanning']")).Click();

            string S274 = System.Configuration.ConfigurationManager.AppSettings["C_EP_DOW"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientDateOfWill']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientDateOfWill']")).SendKeys(S274);


            string S275 = System.Configuration.ConfigurationManager.AppSettings["C_EP_DLR"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientLastReviewDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientLastReviewDate']")).SendKeys(S275);





            string S276 = System.Configuration.ConfigurationManager.AppSettings["C_EP_HON"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientWillHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientWillHolder']")).SendKeys(S276);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientValidWillYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientTestamentaryTrustYes']")).Click();



            string Ss76 = System.Configuration.ConfigurationManager.AppSettings["C_EP_NOT"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientTrusteeName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientTrusteeName']")).SendKeys(Ss76);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHaveExecutorYes']")).Click();

            string Sp76 = System.Configuration.ConfigurationManager.AppSettings["C_EP_NOE"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientWillExecutor']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientWillExecutor']")).SendKeys(Sp76);




            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientNoLongerBeneficiaryNo']")).Click();

            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientContestWillNo']")).Click();

            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientExecUndResponsibilitiesYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientFuneralPlanNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientReceiveInheritanceYes']")).Click();

            string S277 = System.Configuration.ConfigurationManager.AppSettings["C_EP_Inher"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientReceiveInheritanceAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientReceiveInheritanceAmount']")).SendKeys(S277);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientDeFactoRelationsshipYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientChildrenFromDifferentNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientDesireToOmitNo']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientBeneficiariesVulnerableYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/div/div[1]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHavePOAYes']")).Click();

            string S284 = System.Configuration.ConfigurationManager.AppSettings["C_EP_POA_Name"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientPOAHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientPOAHolder']")).SendKeys(S284);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientUnderstandPOAYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientStillAppropriateYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHaveGPOAYes']")).Click();

            string S278 = System.Configuration.ConfigurationManager.AppSettings["C_EP_GPOA_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAState']")).SendKeys(S278);


            string S279 = System.Configuration.ConfigurationManager.AppSettings["C_EP_GPOA_ED"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAExpiryDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAExpiryDate']")).SendKeys(S279);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientGPOARegisteredYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAPowerHolder']")).SendKeys("Self");

            string S280 = System.Configuration.ConfigurationManager.AppSettings["C_EP_EPOAF_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEFPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEFPOAState']")).SendKeys(S280);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEFPOARegisteredYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEFPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEFPOAPowerHolder']")).SendKeys("Son");

            string S281 = System.Configuration.ConfigurationManager.AppSettings["C_EP_EPOAM_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEMPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEMPOAState']")).SendKeys(S281);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEMPOARegisteredNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEMPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEMPOAPowerHolder']")).SendKeys("SISTER");


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHaveEGPOAYes']")).Click();


            string S282 = System.Configuration.ConfigurationManager.AppSettings["C_EP_EPOAG_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEGPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEGPOAState']")).SendKeys(S282);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEGPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEGPOAPowerHolder']")).SendKeys("Self");


            string S283 = System.Configuration.ConfigurationManager.AppSettings["C_EP_EPOAO_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEOPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEOPOAState']")).SendKeys(S283);




            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEGPOARegisteredND']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEOPOARegisteredNo']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEOPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEOPOAPowerHolder']")).SendKeys("Father");



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/div/div[1]/ul/li[3]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEnduringPOAYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientGuardiansForChildrenYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/ul/li[2]/a")).Click();

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerDateOfWill"]
            string S285 = System.Configuration.ConfigurationManager.AppSettings["P_EP_DOW"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerDateOfWill']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerDateOfWill']")).SendKeys(S285);


            string S286 = System.Configuration.ConfigurationManager.AppSettings["P_EP_DLR"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerLastReviewDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerLastReviewDate']")).SendKeys(S286);





            string S287 = System.Configuration.ConfigurationManager.AppSettings["P_EP_HON"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillHolder']")).SendKeys(S287);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerValidWillYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerTestamentaryTrustYes']")).Click();


            string Ss87 = System.Configuration.ConfigurationManager.AppSettings["P_EP_NOT"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerTrusteeName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerTrusteeName']")).SendKeys(Ss87);


            // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHaveExecutorYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerHaveExecutorYes']")).Click();

            string Sp87 = System.Configuration.ConfigurationManager.AppSettings["P_EP_NOE"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillExecutor']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillExecutor']")).SendKeys(Sp87);




            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerNoLongerBeneficiaryNo']")).Click();

            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerContestWillNo']")).Click();

            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerExecUndResponsibilitiesYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerFuneralPlanNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerReceiveInheritanceYes']")).Click();

            string S288 = System.Configuration.ConfigurationManager.AppSettings["P_EP_Inher"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerReceiveInheritanceAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerReceiveInheritanceAmount']")).SendKeys(S288);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerDeFactoRelationsshipYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerChildrenFromDifferentNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerDesireToOmitNo']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerBeneficiariesVulnerableYes']")).Click();


            //////////

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/div/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerHavePOAYes']")).Click();

            string Sa84 = System.Configuration.ConfigurationManager.AppSettings["P_EP_POA_Name"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerPOAHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerPOAHolder']")).SendKeys(Sa84);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerPOAHolder"]



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerUnderstandPOAYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerStillAppropriateYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerHaveGPOAYes']")).Click();

            string Sa78 = System.Configuration.ConfigurationManager.AppSettings["P_EP_GPOA_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAState']")).SendKeys(Sa78);


            string Sa79 = System.Configuration.ConfigurationManager.AppSettings["P_EP_GPOA_ED"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAExpiryDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAExpiryDate']")).SendKeys(Sa79);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerGPOARegisteredYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAPowerHolder']")).SendKeys("Self");

            string Sa80 = System.Configuration.ConfigurationManager.AppSettings["P_EP_EPOAF_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEFPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEFPOAState']")).SendKeys(Sa80);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEFPOARegisteredYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEFPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEFPOAPowerHolder']")).SendKeys("Son");

            string Sa81 = System.Configuration.ConfigurationManager.AppSettings["P_EP_EPOAM_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEMPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEMPOAState']")).SendKeys(Sa81);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEMPOARegisteredNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEMPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEMPOAPowerHolder']")).SendKeys("SISTER");


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerHaveEGPOAYes']")).Click();


            string Sa82 = System.Configuration.ConfigurationManager.AppSettings["P_EP_EPOAG_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEGPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEGPOAState']")).SendKeys(Sa82);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEGPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEGPOAPowerHolder']")).SendKeys("Self");


            string Sa83 = System.Configuration.ConfigurationManager.AppSettings["P_EP_EPOAO_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEOPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEOPOAState']")).SendKeys(Sa83);




            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEGPOARegisteredND']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEOPOARegisteredNo']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEOPOAPowerHolder']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEOPOAPowerHolder']")).SendKeys("Father");


            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/div/div[2]/ul/li[3]/a
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/div/div[2]/ul/li[3]/a")).Click();
            //   driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEnduringPOANo']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerGuardiansForChildrenYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            /************************OK******/

            //        driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/ul/li[2]/a")).Click();


            /***/
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEnduringPOAYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerGuardiansForChildrenYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            /******Test****
                        //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerDateOfWill"]
                        string Sa85 = System.Configuration.ConfigurationManager.AppSettings["P_EP_DOW"];
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerDateOfWill']")).Clear();
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerDateOfWill']")).SendKeys(Sa85);


                        string Sa86 = System.Configuration.ConfigurationManager.AppSettings["P_EP_DLR"];
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerLastReviewDate']")).Clear();
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerLastReviewDate']")).SendKeys(Sa86);





                        string Sa87 = System.Configuration.ConfigurationManager.AppSettings["P_EP_HON"];
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillHolder']")).Clear();
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillHolder']")).SendKeys(Sa87);

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerValidWillYes']")).Click();

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerTestamentaryTrustYes']")).Click();


                        string Sz87 = System.Configuration.ConfigurationManager.AppSettings["P_EP_NOT"];
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerTrusteeName']")).Clear();
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerTrusteeName']")).SendKeys(Sz87);


                        // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHaveExecutorYes']")).Click();
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerHaveExecutorYes']")).Click();

                        string Sq87 = System.Configuration.ConfigurationManager.AppSettings["P_EP_NOE"];
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillExecutor']")).Clear();
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillExecutor']")).SendKeys(Sq87);




                        driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerNoLongerBeneficiaryNo']")).Click();

                        driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerContestWillNo']")).Click();

                        driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerExecUndResponsibilitiesYes']")).Click();


                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerFuneralPlanNo']")).Click();

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerReceiveInheritanceYes']")).Click();

                        string Se88 = System.Configuration.ConfigurationManager.AppSettings["P_EP_Inher"];
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerReceiveInheritanceAmount']")).Clear();
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerReceiveInheritanceAmount']")).SendKeys(Se88);


                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerDeFactoRelationsshipYes']")).Click();


                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerChildrenFromDifferentNo']")).Click();

                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerDesireToOmitNo']")).Click();


                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerBeneficiariesVulnerableYes']")).Click();


                        *******Test*****/





            /******Advanced AN*****
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAdditionalNotes']")).Click();
                      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[15]/div[2]/ul/li[2]/a")).Click();

                      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[15]/div[2]/div/div[2]/div/div/div[2]/div/label/span")).Click();
                      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
                      **OK*********/

            /**********Advance Insurance**/
            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlInsurances']")).Click();

            //            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlInsurances']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtPolicyNo']")).Clear();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtPolicyNo']")).SendKeys("1A12");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtPolicyPurpose']")).SendKeys("Test Your Insurance");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_trriskinsurancerow']/table/tbody/tr[3]/td[1]/div/label/span")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtCommencementDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtCommencementDate']")).SendKeys("01/03/2018");

            //  driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_ddlPremiumType"]
            string S299 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Risk_PremTyp"];
            SelectElement oSelection299 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_ddlPremiumType']")));
            oSelection299.SelectByText(S299);
            //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_trriskinsurancerow']/table/tbody/tr[7]/td[1]/div/label/span")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtRiskInsuranceNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtRiskInsuranceNotes']")).SendKeys("Testing....");


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/div/div[1]/ul/li[2]/a")).Click();


            string S300 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Priv_Features"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_txtFeatures']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_txtFeatures']")).SendKeys(S300);


            string S301 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Priv_Insurer"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_txtProvider']")).SendKeys(S301);


            string S302 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Priv_Premium"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_txtPremium']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_txtPremium']")).SendKeys(S302);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_ddlPaymentFrequency"]
            string S304 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Priv_Freq"];
            SelectElement oSelection304 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_ddlPaymentFrequency']")));
            oSelection304.SelectByText(S304);

            string S303 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Priv_Typ"];
            SelectElement oSelection303 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_ddlCoverTypeCode']")));
            oSelection303.SelectByText(S303);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_trhealthinsurancerow']/table/tbody/tr[3]/td[2]/div/label/span")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_txtHelthInsuranceNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_txtHelthInsuranceNotes']")).SendKeys("Ok");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/div/div[1]/ul/li[3]/a")).Click();


            string S305 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_GI_Typ"];
            SelectElement oSelection305 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_ddlInsuranceType']")));
            oSelection305.SelectByText(S305);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtProvider"]

            string S306 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_GI_Insurer"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtProvider']")).SendKeys(S306);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtPolicyNumber']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtPolicyNumber']")).SendKeys("S129L");


            string S307 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_GI_SumIns"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtSumInsured']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtSumInsured']")).SendKeys(S307);



            string S308 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_GI_Premium"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtPremium']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtPremium']")).SendKeys(S308);


            string S309 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_GI_Freq"];
            SelectElement oSelection309 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_ddlPaymentFrequency']")));
            oSelection309.SelectByText(S309);


            string S310 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_GI_Date"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtRenewalDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtRenewalDate']")).SendKeys(S310);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtGeneralInsuranceNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtGeneralInsuranceNotes']")).SendKeys("Test");


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/div/div[1]/ul/li[4]/a")).Click();

            string S311 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_BI_Typ"];
            SelectElement oSelection311 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_ddlInsuranceType']")));
            oSelection311.SelectByText(S311);

            string S312 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_BI_Insurer"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtProvider']")).SendKeys(S312);



            string S313 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_BI_SumIns"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtSumInsured']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtSumInsured']")).SendKeys(S313);


            string S314 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_BI_Premium"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtPremium']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtPremium']")).SendKeys(S314);


            string S315 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_BI_Freq"];
            SelectElement oSelection315 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_ddlPaymentFrequency']")));
            oSelection315.SelectByText(S315);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtRenewalDate"]

            string S316 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_BI_Date"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtRenewalDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtRenewalDate']")).SendKeys(S316);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtBusinessInsuranceNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtBusinessInsuranceNotes']")).SendKeys("Testing");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/ul/li[2]/a")).Click();

            /******/
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/ul/li[2]/a

            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlInsurances']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_txtPolicyNo']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_txtPolicyNo']")).SendKeys("1A12");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_txtPolicyPurpose']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_txtPolicyPurpose']")).SendKeys("Test Your Insurance");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_trriskinsurancerow']/table/tbody/tr[3]/td[1]/div/label/span")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_txtCommencementDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_txtCommencementDate']")).SendKeys("01/03/2018");

            //  driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_ddlPremiumType"]
            string I299 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Risk_PremTyp"];
            SelectElement oSelectionI99 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_ddlPremiumType']")));
            oSelectionI99.SelectByText(I299);
            //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_trriskinsurancerow']/table/tbody/tr[7]/td[1]/div/label/span")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_txtRiskInsuranceNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerRiskInsuranceRow_0_txtRiskInsuranceNotes']")).SendKeys("Testing....");


            // driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/div/div[1]/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/div/div[2]/ul/li[2]/a")).Click();

            string I300 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Priv_Features"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_txtFeatures']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_txtFeatures']")).SendKeys(I300);


            string I301 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Priv_Insurer"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_txtProvider']")).SendKeys(I301);


            string I302 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Priv_Premium"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_txtPremium']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_txtPremium']")).SendKeys(I302);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientHealthInsuranceRow_0_ddlPaymentFrequency"]
            string I304 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Priv_Freq"];
            SelectElement oSelectionI304 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_ddlPaymentFrequency']")));
            oSelectionI304.SelectByText(S304);

            string I303 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Priv_Typ"];
            SelectElement oSelectionI303 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_ddlCoverTypeCode']")));
            oSelectionI303.SelectByText(I303);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_trhealthinsurancerow']/table/tbody/tr[3]/td[2]/div/label/span")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_txtHelthInsuranceNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerHealthInsuranceRow_0_txtHelthInsuranceNotes']")).SendKeys("Ok");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            //     driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/div/div[1]/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/div/div[2]/ul/li[3]/a")).Click();


            string I305 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_GI_Typ"];
            SelectElement oSelectionI305 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_ddlInsuranceType']")));
            oSelectionI305.SelectByText(I305);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientGeneralInsuranceRow_0_txtProvider"]

            string I306 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_GI_Insurer"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtProvider']")).SendKeys(I306);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtPolicyNumber']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtPolicyNumber']")).SendKeys("S129L");


            string I307 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_GI_SumIns"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtSumInsured']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtSumInsured']")).SendKeys(I307);



            string I308 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_GI_Premium"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtPremium']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtPremium']")).SendKeys(I308);


            string I309 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_GI_Freq"];
            SelectElement oSelectionI309 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_ddlPaymentFrequency']")));
            oSelectionI309.SelectByText(I309);


            string I310 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_GI_Date"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtRenewalDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtRenewalDate']")).SendKeys(I310);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtGeneralInsuranceNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerGeneralInsuranceRow_0_txtGeneralInsuranceNotes']")).SendKeys("Test");


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/div/div[1]/ul/li[4]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/div/div[2]/ul/li[4]/a")).Click();

            string I311 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_BI_Typ"];
            SelectElement oSelectionI311 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_ddlInsuranceType']")));
            oSelectionI311.SelectByText(I311);

            string I312 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_BI_Insurer"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtProvider']")).SendKeys(I312);



            string I313 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_BI_SumIns"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtSumInsured']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtSumInsured']")).SendKeys(I313);


            string I314 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_BI_Premium"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtPremium']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtPremium']")).SendKeys(I314);


            string I315 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_BI_Freq"];
            SelectElement oSelectionI315 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_ddlPaymentFrequency']")));
            oSelectionI315.SelectByText(I315);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientBusinessInsuranceRow_0_txtRenewalDate"]

            string I316 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_BI_Date"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtRenewalDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtRenewalDate']")).SendKeys(S316);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtBusinessInsuranceNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_PartnerBusinessInsuranceRow_0_txtBusinessInsuranceNotes']")).SendKeys("Testing");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            Thread.Sleep(1000);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbMeetCurrentDebtYes"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlPensions']")).Click();


            string Pen1 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_FName"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtName']")).SendKeys(Pen1);

            string Pen2 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_Type"];
            SelectElement oSelectionPen2 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_ddlPensionType']")));
            oSelectionPen2.SelectByText(Pen2);

            string Pen3 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_CB"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtBalance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtBalance']")).SendKeys(Pen3);


            string Pen4 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_Freq"];
            SelectElement oSelectionPen4 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_ddlPaymentFrequency']")));
            oSelectionPen4.SelectByText(Pen4);

            string Pen5 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_Income"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtIncome']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtIncome']")).SendKeys(Pen5);

            string Pen6 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_FreeAmount"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtFreeAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtFreeAmount']")).SendKeys(Pen6);



            string Pen7 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_FreePercentage"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtFreePercentage']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtFreePercentage']")).SendKeys(Pen7);



            string Pen8 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_Investment"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtInvestment']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtInvestment']")).SendKeys(Pen8);



            string Pen9 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_ReturnOfCapital"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtReturnOfCapital']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtReturnOfCapital']")).SendKeys(Pen9);



            string Pen10 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_CommencementDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtCommencementDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtCommencementDate']")).SendKeys(Pen10);


            string Pen11 = System.Configuration.ConfigurationManager.AppSettings["C_Pen_Term"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtTerm']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_ClientPensionRow_0_txtTerm']")).SendKeys(Pen11);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[8]/div[2]/ul/li[2]/a")).Click();

            string Pen12 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_FName"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtName']")).SendKeys(Pen12);

            string Pen22 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_Type"];
            SelectElement oSelectionPen22 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_ddlPensionType']")));
            oSelectionPen22.SelectByText(Pen22);

            string Pen33 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_CB"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtBalance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtBalance']")).SendKeys(Pen33);


            string Pen44 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_Freq"];
            SelectElement oSelectionPen44 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_ddlPaymentFrequency']")));
            oSelectionPen44.SelectByText(Pen44);

            string Pen55 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_Income"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtIncome']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtIncome']")).SendKeys(Pen55);

            string Pen66 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_FreeAmount"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtFreeAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtFreeAmount']")).SendKeys(Pen66);



            string Pen77 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_FreePercentage"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtFreePercentage']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtFreePercentage']")).SendKeys(Pen77);



            string Pen88 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_Investment"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtInvestment']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtInvestment']")).SendKeys(Pen88);



            string Pen99 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_ReturnOfCapital"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtReturnOfCapital']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtReturnOfCapital']")).SendKeys(Pen99);



            string Pen100 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_CommencementDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtCommencementDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtCommencementDate']")).SendKeys(Pen100);


            string Pen110 = System.Configuration.ConfigurationManager.AppSettings["P_Pen_Term"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtTerm']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PensionsControl_PartnerPensionRow_0_txtTerm']")).SendKeys(Pen110);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlCurrentEntities']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CurrentEntitiesControl_cbClientHaveSMSFYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CurrentEntitiesControl_cbClientHaveCompanyNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CurrentEntitiesControl_cbClientHaveTrustYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CurrentEntitiesControl_cbClientHavePartnershipYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[10]/div[2]/ul/li[2]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CurrentEntitiesControl_cbPartnerHaveSMSFYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CurrentEntitiesControl_cbPartnerHaveCompanyNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CurrentEntitiesControl_cbPartnerHaveTrustYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CurrentEntitiesControl_cbPartnerHavePartnershipYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[10]/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            Thread.Sleep(1000);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbMeetCurrentDebtYes"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlContacts']")).Click();


            string Psc1 = System.Configuration.ConfigurationManager.AppSettings["C_PSC_Name"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_txtContactName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_txtContactName']")).SendKeys(Psc1);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_rbdContactAuthoritylinkYes']")).Click();


            string Psc2 = System.Configuration.ConfigurationManager.AppSettings["C_PSC_ContactType"];
            SelectElement oSelectionPsc2 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_ddlContactType']")));
            oSelectionPsc2.SelectByText(Psc2);




            string Psc3 = System.Configuration.ConfigurationManager.AppSettings["C_PSC_ContactEmail"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_txtContactEmail']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_txtContactEmail']")).SendKeys(Psc3);


            string Psc4 = System.Configuration.ConfigurationManager.AppSettings["C_PSC_ContactNumber"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_txtContactNumber']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_txtContactNumber']")).SendKeys(Psc4);



            string Psc5 = System.Configuration.ConfigurationManager.AppSettings["C_PSC_ContactRequirement"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_txtContactRequirement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_ClientContactRow_0_txtContactRequirement']")).SendKeys(Psc5);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_txtClientHowToWorkWith']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_txtClientHowToWorkWith']")).SendKeys("As Usual");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[12]/div[2]/ul/li[2]/a")).Click();

            string Psc11 = System.Configuration.ConfigurationManager.AppSettings["P_PSC_Name"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_txtContactName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_txtContactName']")).SendKeys(Psc11);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_rbdContactAuthoritylinkYes']")).Click();


            string Psc22 = System.Configuration.ConfigurationManager.AppSettings["P_PSC_ContactType"];
            SelectElement oSelectionPsc22 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_ddlContactType']")));
            oSelectionPsc22.SelectByText(Psc22);




            string Psc33 = System.Configuration.ConfigurationManager.AppSettings["P_PSC_ContactEmail"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_txtContactEmail']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_txtContactEmail']")).SendKeys(Psc33);


            string Psc44 = System.Configuration.ConfigurationManager.AppSettings["P_PSC_ContactNumber"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_txtContactNumber']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_txtContactNumber']")).SendKeys(Psc44);



            string Psc55 = System.Configuration.ConfigurationManager.AppSettings["P_PSC_ContactRequirement"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_txtContactRequirement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_PartnerContactRow_0_txtContactRequirement']")).SendKeys(Psc55);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_txtPartnerHowToWorkWith']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_ContactsControl_txtPartnerHowToWorkWith']")).SendKeys("Ok to Work");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            Thread.Sleep(1000);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbMeetCurrentDebtYes"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlCentreLink']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkDetailsControl_rbClaimingTaxYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkDetailsControl_rbHomeOwnerYes']")).Click();


            string CL1 = System.Configuration.ConfigurationManager.AppSettings["C_CN_GiftAssets"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkDetailsControl_txtValueGiftAssets']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkDetailsControl_txtValueGiftAssets']")).SendKeys(CL1);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkDetailsControl_rbVeteranYes']")).Click();

            string CL2 = System.Configuration.ConfigurationManager.AppSettings["C_CN_OtherSupport"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkDetailsControl_txtOtherSupport']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkDetailsControl_txtOtherSupport']")).SendKeys(CL2);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[14]/div[2]/div/div[1]/ul/li[2]/a")).Click();


            string CLAP1 = System.Configuration.ConfigurationManager.AppSettings["C_PSC_BenefitType"];
            SelectElement oSelectionclap = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkApplicablePaymentControl_CentreLinkApplicablePayment_0_ddlCreditLinkBenefitType']")));
            oSelectionclap.SelectByText(CLAP1);



            string CLAP2 = System.Configuration.ConfigurationManager.AppSettings["C_PSC_Status"];
            SelectElement oSelectionclap1 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkApplicablePaymentControl_CentreLinkApplicablePayment_0_ddlTaxStatus']")));
            oSelectionclap1.SelectByText(CLAP2);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkApplicablePaymentControl_CentreLinkApplicablePayment_0_trApplicablePayments']/td[3]/div/label/span")).Click();



            //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkDetailsControl_rbClaimingTaxYes']")).Click();

            //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_ClientCentreLinkDetailsControl_rbHomeOwnerYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[14]/div[2]/ul/li[2]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkDetailsControl_rbClaimingTaxYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkDetailsControl_rbHomeOwnerYes']")).Click();



            string CL11 = System.Configuration.ConfigurationManager.AppSettings["P_CN_GiftAssets"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkDetailsControl_txtValueGiftAssets']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkDetailsControl_txtValueGiftAssets']")).SendKeys(CL11);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkDetailsControl_rbVeteranYes']")).Click();

            string CL22 = System.Configuration.ConfigurationManager.AppSettings["P_CN_OtherSupport"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkDetailsControl_txtOtherSupport']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkDetailsControl_txtOtherSupport']")).SendKeys(CL22);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[14]/div[2]/div/div[2]/ul/li[2]/a")).Click();


            string CLAP12 = System.Configuration.ConfigurationManager.AppSettings["P_PSC_BenefitType"];
            SelectElement oSelectionclap2 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkApplicablePaymentControl_CentreLinkApplicablePayment_0_ddlCreditLinkBenefitType']")));
            oSelectionclap2.SelectByText(CLAP12);



            string CLAP22 = System.Configuration.ConfigurationManager.AppSettings["P_PSC_Status"];
            SelectElement oSelectionclap12 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkApplicablePaymentControl_CentreLinkApplicablePayment_0_ddlTaxStatus']")));
            oSelectionclap12.SelectByText(CLAP22);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_CentreLinkControl_PartnerCentreLinkApplicablePaymentControl_CentreLinkApplicablePayment_0_trApplicablePayments']/td[3]/div/label/span")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            Thread.Sleep(1000);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbMeetCurrentDebtYes"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAppendix']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_rbMeetCurrentDebtYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_rbPayDebtSoonYes']")).Click();


            string A19 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DebtRepay"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_txtAgeDebtRepaid']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_txtAgeDebtRepaid']")).SendKeys(A19);


            string A20 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_LifeDebt"];
            SelectElement oSelectionA20 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_ddlLifeStyleDebt']")));
            oSelectionA20.SelectByText(A20);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_rbOffsetOrRedrawYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_rbHomeLoanExtraRepaymentsYes']")).Click();


            string Aa21 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_ImediAccess"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_txtImmediateAccessTo']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_txtImmediateAccessTo']")).SendKeys(Aa21);




            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[1]/table/tbody/tr[7]/td")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_rbAddtlPaymentsYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_rbDirectSalIntoLoanNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_rbHomeLoadRepayChargesYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_txtHomeLoadRepayChargesAmt']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_txtHomeLoadRepayChargesAmt']")).SendKeys("Processing Fees");

            string A21 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_InterestFree"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_txtIntFreePeriod']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_txtIntFreePeriod']")).SendKeys(A21);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDebtControl_rbPayCCWithinIntFreePeriodYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_rbPreviousWithdrawnNo']")).Click();


            string A22 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_RetireAge"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtRetireAge']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtRetireAge']")).SendKeys(A22);


            string A23 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_RetireDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtRetireDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtRetireDate']")).SendKeys(A23);


            string A24 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Saving4Retire"];
            SelectElement oSelectionA24 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_ddlSavingPriority']")));
            oSelectionA24.SelectByText(A24);




            string A25 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_IncAfterTax"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtAnnualIncomeInRetirement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtAnnualIncomeInRetirement']")).SendKeys(A25);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_rbHaveSufficientFundsInRetirmentYes']")).Click();

            string A26 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_IncInRetire"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtSourcesOfIncomeInRetirment']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtSourcesOfIncomeInRetirment']")).SendKeys(A26);



            string A27 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_IncAssetsRetire"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtOtherAssets']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_txtOtherAssets']")).SendKeys(A27);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_rbHaveSufficientIncomeYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_rbChangeLifestyleNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_rbDownsizingNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_rbHigherRiskStrategyYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_rbLeaveMoneyYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_rbHaveMadeCommutationNo']")).Click();



            string A28 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_ProdName"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtName']")).SendKeys(A28);


            string A29 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_PenType"];
            SelectElement oSelectionA29 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_ddlPensionType']")));
            oSelectionA29.SelectByText(A29);


            string A30 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_PayFreq"];
            SelectElement oSelectionA30 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_ddlPaymentFrequency']")));
            oSelectionA30.SelectByText(A30);



            string A31 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_GrosInc"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtGrossAnnualIncome']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtGrossAnnualIncome']")).SendKeys(A31);



            string A32 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_AnnTaxFreeAmt"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtAnnualTaxFreeAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtAnnualTaxFreeAmount']")).SendKeys(A32);



            string A33 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_IniInvest"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtInitialInvestment']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtInitialInvestment']")).SendKeys(A33);



            string A34 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_RCV"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtResidualCapitalValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtResidualCapitalValue']")).SendKeys(A34);



            string A35 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_CDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtCommencementDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtCommencementDate']")).SendKeys(A35);



            string A36 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_CDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtTerm']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtTerm']")).SendKeys(A36);



            string A37 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_InveNumber"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtInvestorNumber']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtInvestorNumber']")).SendKeys(A37);




            string A38 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_EliServDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txteligibleservicedate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txteligibleservicedate']")).SendKeys(A38);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txteligibleservicedate"]

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_rbComplyingYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_rbRevisionaryNo']")).Click();


            string A39 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_RevBenific"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtRevisionaryBeneficiary']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtRevisionaryBeneficiary']")).SendKeys(A39);



            string A40 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DatePur"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtDateOfPurchase']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtDateOfPurchase']")).SendKeys(A40);




            string A41 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_AssetTest"];

            SelectElement oSelectionA41 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_ddlAssetTest']")));
            oSelectionA41.SelectByText(A41);


            string A42 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_MaturDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtMaturityDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtMaturityDate']")).SendKeys(A42);



            string A43 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_CurrentBalance"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtPensionCurrentBalance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtPensionCurrentBalance']")).SendKeys(A43);


            string A44 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_AnnuAmtPa"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtAnnuityAmountPa']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtAnnuityAmountPa']")).SendKeys(A44);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtAnnuityAmountPa"]


            string A45 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_IndexRate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtIndexationRate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtIndexationRate']")).SendKeys(A45);



            string A46 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_CurreUPP"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtCurrentUPP']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtCurrentUPP']")).SendKeys(A46);




            string A47 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_TaxDeduct"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtTaxDeductible']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtTaxDeductible']")).SendKeys(A47);


            string A48 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_CentreLink"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtCentreLink']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtCentreLink']")).SendKeys(A48);


            string A49 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_CGTExempt"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtCGTExempt']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtCGTExempt']")).SendKeys(A49);



            string A50 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Concessional"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtConcessional']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtConcessional']")).SendKeys(A50);



            string A51 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Post94Invalid"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtPost94Invalidity']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtPost94Invalidity']")).SendKeys(A51);



            string A52 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_TaxUnTaxed"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtTaxableElementUntaxed']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtTaxableElementUntaxed']")).SendKeys(A52);


            string A53 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Excessive"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtExcessive']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtExcessive']")).SendKeys(A53);



            string A54 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Rebateable"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtRebateablePortion']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtRebateablePortion']")).SendKeys(A54);


            string A55 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_InvestOptions"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtInvestmentOptions']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtInvestmentOptions']")).SendKeys(A55);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_rbAssetToBeRetainedYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbSmokerNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbHaveHeathIssuesNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtHeathComments']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtHeathComments']")).SendKeys("OK");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbRelyOnEmploymentYes']")).Click();


            string A56 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_FDepends"];

            SelectElement oSelectionA56 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_ddlIncomeDependance']")));
            oSelectionA56.SelectByText(A56);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtHowMaintainLifestyle']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtHowMaintainLifestyle']")).SendKeys("Through Savings");



            string A57 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TempIncReplace"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtTIIncomeReplacement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtTIIncomeReplacement']")).SendKeys(A57);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbTIProvideProvisionYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbTIHaveAccessNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbTICeaseWorkNo']")).Click();

            string A58 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_PermIncReplace"];
            //  SelectElement oSelectionA58 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtPDIncomeReplacement']")));
            //  oSelectionA58.SelectByText(A58);
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtPDIncomeReplacement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtPDIncomeReplacement']")).SendKeys(A58);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbPDProvideProvisionYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbPDCeaseWorkNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbPDMortgageFreeYes']")).Click();


            string A59 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_Provision"];
            SelectElement oSelectionA59 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_ddlUDLeaveLivingStandard']")));
            oSelectionA59.SelectByText(A59);


            string A60 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_UnExpIncReplace"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtUDIncomeReplacement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtUDIncomeReplacement']")).SendKeys(A60);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbUDFundsPaidYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbUDProvideProvisionYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbUDMortgageFreeYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_rbUDAccessToFundsYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[1]/td/div/div[1]/div/label/span[1]")).Click();



            string A61 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_AmntReq"];

            driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).SendKeys(A61);


            string A62 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_HM"];

            driver.FindElement(By.XPath("//*[@id='txtDeathHomeMortgage']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathHomeMortgage']")).SendKeys(A62);

            //*[@id="txtDeathOtherAmount"]
            string A63 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_Other"];

            driver.FindElement(By.XPath("//*[@id='txtDeathOtherAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathOtherAmount']")).SendKeys(A63);


            string A64 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_FuneralCost"];

            driver.FindElement(By.XPath("//*[@id='txtDeathFuneralCosts']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathFuneralCosts']")).SendKeys(A64);


            string A65 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_EmergencyFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathEmergencyFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathEmergencyFund']")).SendKeys(A65);


            string A66 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_EducationFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathEducationFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathEducationFund']")).SendKeys(A66);

            string A67 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_EstatePlanningFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathEstatePlanningFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathEstatePlanningFund']")).SendKeys(A67);


            string A68 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_ChildCareFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathChildCareFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathChildCareFund']")).SendKeys(A68);


            string A69 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_ProvisionforTax"];

            driver.FindElement(By.XPath("//*[@id='txtDeathProvisionforTax']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathProvisionforTax']")).SendKeys(A69);


            string A70 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_OtherFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathOtherFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathOtherFund']")).SendKeys(A70);


            string A71 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDReducedebt"];

            driver.FindElement(By.XPath("//*[@id='txtTPDReducedebt']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDReducedebt']")).SendKeys(A71);




            string A72 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaReducedebt"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaReducedebt']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaReducedebt']")).SendKeys(A72);



            string A73 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDHomeMortgage"];

            driver.FindElement(By.XPath("//*[@id='txtTPDHomeMortgage']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDHomeMortgage']")).SendKeys(A73);

            string A74 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaHomeMortgage"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaHomeMortgage']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaHomeMortgage']")).SendKeys(A74);


            string A75 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDOtherAmount"];

            driver.FindElement(By.XPath("//*[@id='txtTPDOtherAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDOtherAmount']")).SendKeys(A75);





            string A76 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_OtherAmount"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaOtherAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaOtherAmount']")).SendKeys(A76);



            string A77 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDMedicalLifestyleFund"];

            driver.FindElement(By.XPath("//*[@id='txtTPDMedicalLifestyleFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDMedicalLifestyleFund']")).SendKeys(A77);


            string A78 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaMedicalLifestyleFund"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaMedicalLifestyleFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaMedicalLifestyleFund']")).SendKeys(A78);


            string A79 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDEmergencyFund"];

            driver.FindElement(By.XPath("//*[@id='txtTPDEmergencyFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDEmergencyFund']")).SendKeys(A79);


            string A80 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaEmergencyFund"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaEmergencyFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaEmergencyFund']")).SendKeys(A80);



            string A81 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDRecoveryFund"];

            driver.FindElement(By.XPath("//*[@id='txtTPDRecoveryFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDRecoveryFund']")).SendKeys(A81);

            string A82 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaRecoveryFund"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaRecoveryFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaRecoveryFund']")).SendKeys(A82);



            string A83 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDHomePurchaseFund"];

            driver.FindElement(By.XPath("//*[@id='txtTPDHomePurchaseFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDHomePurchaseFund']")).SendKeys(A83);



            string A84 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaHomePurchaseFund"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaHomePurchaseFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaHomePurchaseFund']")).SendKeys(A84);


            string A85 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDEducation"];

            driver.FindElement(By.XPath("//*[@id='txtTPDEducation']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDEducation']")).SendKeys(A85);




            string A86 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaEducation"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaEducation']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaEducation']")).SendKeys(A86);


            string A87 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDEstatePlanning"];

            driver.FindElement(By.XPath("//*[@id='txtTPDEstatePlanning']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDEstatePlanning']")).SendKeys(A87);

            string A88 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaEstatePlanning"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaEstatePlanning']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaEstatePlanning']")).SendKeys(A88);

            string A89 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDChildCareFund"];

            driver.FindElement(By.XPath("//*[@id='txtTPDChildCareFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDChildCareFund']")).SendKeys(A89);

            string A90 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaChildCareFund"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaChildCareFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaChildCareFund']")).SendKeys(A90);

            string A91 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TPDOtherFund"];

            driver.FindElement(By.XPath("//*[@id='txtTPDOtherFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTPDOtherFund']")).SendKeys(A91);

            string A92 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_TraumaOtherFund"];

            driver.FindElement(By.XPath("//*[@id='txtTraumaOtherFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtTraumaOtherFund']")).SendKeys(A92);


            string A93 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_IncomeRequested"];

            driver.FindElement(By.XPath("//*[@id='txtIncomeRequested']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtIncomeRequested']")).SendKeys(A93);



            string A94 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_WaitingPeriod"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtWaitingPeriod']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtWaitingPeriod']")).SendKeys(A94);


            string A95 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_BenefitPeriod"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtBenefitPeriod']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtBenefitPeriod']")).SendKeys(A95);


            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();

            // String Control = driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType]")).Text;
            if ((driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")) == null))
            //     if ((Control == null))
            {
                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span
                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();
                //     String Control = driver.FindElement(By.XPath(" //*[@id'aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/th[2]/span")).Text;

                //      Console.WriteLine("Con is " + Control);
                //     driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();

                /**      if (!(Control.Contains("Accident Cover Type")))
                      {
                          driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();
                          Console.WriteLine("Accident Cover Clicked in Loop");
                      }**/

                /*    if ((driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']"))!=null))
                    {

                    }*/

            }
            /*******/
            string A96 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_AccidentCoverType"];

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();

            //  driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")).SendKeys(A96);


            string A97 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_AccruedSickLeaveDays"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtAccruedSickLeaveDays']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtAccruedSickLeaveDays']")).SendKeys(A97);


            string A98 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_AccruedLeaveDays"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtAccruedLeaveDays']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtAccruedLeaveDays']")).SendKeys(A98);


            string A99 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_OtherBenefits"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtOtherBenefits']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtOtherBenefits']")).SendKeys(A99);

            string A100 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_HazardousPursuits"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtHazardousPursuits']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtHazardousPursuits']")).SendKeys(A100);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[4]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixProfileControl_rbHowLongInvested40']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixProfileControl_rbLevelOfReturn50']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixProfileControl_rbPoorlyPerformingInvestment10']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixProfileControl_rbInvestmentMarkets40']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixProfileControl_rbTaxEfficiency20']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixProfileControl_rbPortfolioDecreased40']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixProfileControl_rbPurposeOfInvesting20']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            /*******/



            /**************Client Direct Property*******/
            // driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[4]/a")).Click();



            //     driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a")).Click();

            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a
            //      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/ul/li[2]/a")).Click();

            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/ul/li[2]/a")).Click();

            /*******Direct Property ****/
            //    driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/ul/li[1]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a")).Click();
            //driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[5]/a")).Click();
            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a")).Click();
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a
            string C1101 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDescription']")).SendKeys(C1101);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDescription"]
            string C1102 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_PropType"];
            SelectElement oSelectionC1102 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_ddlPropertyType']")));
            oSelectionC1102.SelectByText(C1102);

            string C102 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Owner"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOwner']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOwner']")).SendKeys(C102);


            string C103 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_PurchasePrice"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtPurchasePrice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtPurchasePrice']")).SendKeys(C103);


            string C104 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DatePurchased"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDatePurchased']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDatePurchased']")).SendKeys(C104);

            string C105 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_CurrentValue"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtCurrentValue']")).SendKeys(C105);

            string C106 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_ProjectedCapitalGrowth"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedCapitalGrowth']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedCapitalGrowth']")).SendKeys(C106);



            string C107 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_ActualRentalIncome"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtActualRentalIncome']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtActualRentalIncome']")).SendKeys(C107);

            string C108 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_ProjectedRentalIncome"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedRentalIncome']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedRentalIncome']")).SendKeys(C108);

            string C109 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DepreciationAllowance"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciationAllowance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciationAllowance']")).SendKeys(C109);


            string C110 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Depreciation"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciation']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciation']")).SendKeys(C110);


            string C111 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_AnnualExpenses"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtAnnulaExpenses']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtAnnulaExpenses']")).SendKeys(C111);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_rbdemedforcentrelinkYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_rbRetainYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_rbRepayOnTPD']")).Click();

            string C112 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Rates"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtRates']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtRates']")).SendKeys(C112);

            string C113 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_AgentFees"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtAgentFees']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtAgentFees']")).SendKeys(C113);

            string C114 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_LandTax"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtLandTax']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtLandTax']")).SendKeys(C114);

            string C115 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Insurance"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtInsurance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtInsurance']")).SendKeys(C115);

            string C116 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_InterestOnLoan"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtInterestOnLoan']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtInterestOnLoan']")).SendKeys(C116);


            string C117 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_BodyCorporate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtBodyCorporate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtBodyCorporate']")).SendKeys(C117);

            string C118 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_OtherTax"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOtherTax']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOtherTax']")).SendKeys(C118);


            string C119 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_OtherCosts"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOtherCosts']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOtherCosts']")).SendKeys(C119);
            string C120 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_MaintenanceRepairs"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtMaintenanceRepairs']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtMaintenanceRepairs']")).SendKeys(C120);


            //    driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[5]/div/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[5]/div/ul/li[2]/a")).Click();

            string C121 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Sell_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtDescription']")).SendKeys(C121);



            string C122 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Sell_ExpectedDateOfSale"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtExpectedDateOfSale']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtExpectedDateOfSale']")).SendKeys(C122);



            string C1221 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Sell_ExpectedSalePrice"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtExpectedSalePrice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtExpectedSalePrice']")).SendKeys(C1221);




            string C123 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Sell_AgentFees"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtAgentFees']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtAgentFees']")).SendKeys(C123);


            string C124 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Sell_LegalFees"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtLegalFees']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtLegalFees']")).SendKeys(C124);


            string C125 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Sell_SubdivisionCost"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtSubdivisionCost']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtSubdivisionCost']")).SendKeys(C125);

            string C126 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Sell_ProjectedDisposalCost"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtProjectedDisposalCost']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtProjectedDisposalCost']")).SendKeys(C126);


            string C127 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Sell_EstimatedCapitalGainsTax"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtEstimatedCapitalGainsTax']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtEstimatedCapitalGainsTax']")).SendKeys(C127);

            string C128 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Sell_OtherDisposalCosts"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtOtherDisposalCosts']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtOtherDisposalCosts']")).SendKeys(C128);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertySellingRow_0_txtNotes']")).SendKeys("Notes for Property");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            /************SMSFOK*****************/
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[6]/a")).Click();

            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[6]/a")).Click();


            string C129 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_FundName"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtFundName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtFundName']")).SendKeys(C129);

            string C130 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_CorporateTrusteeABN"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtCorporateTrusteeABN']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtCorporateTrusteeABN']")).SendKeys(C130);



            string C131 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_RegisteredAddress"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtRegisteredAddress']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtRegisteredAddress']")).SendKeys(C131);




            string C132 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_EstablishmentDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtEstablishmentDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtEstablishmentDate']")).SendKeys(C132);

            string C133 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_TypesFund"];
            SelectElement oSelectionA133 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_ddlSMSFType']")));
            oSelectionA133.SelectByText(C133);


            string C134 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_ReserveAccount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtReserveAccount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtReserveAccount']")).SendKeys(C134);


            string C135 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_LoansBorrowed"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtLoansBorrowed']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtLoansBorrowed']")).SendKeys(C135);


            string C136 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_TotalFunds"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtTotalFunds']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtTotalFunds']")).SendKeys(C136);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFFundRow_0_txtNotes']")).SendKeys("SMSF Notes");

            //    driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[6]/div/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[6]/div/ul/li[2]/a")).Click();


            string C137 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_MemberName"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFMemberRow_0_txtMemberName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFMemberRow_0_txtMemberName']")).SendKeys(C137);


            string A138 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_CurrentBalance"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFMemberRow_0_txtCurrentBalance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFMemberRow_0_txtCurrentBalance']")).SendKeys(A138);


            string A139 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_RegularContributions"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFMemberRow_0_txtRegularContributions']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFMemberRow_0_txtRegularContributions']")).SendKeys(A139);



            string A1400 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_P_A_Phase"];
            SelectElement oSelectionA1400 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFMemberRow_0_ddlPhaseType']")));
            oSelectionA1400.SelectByText(A1400);


            string A141 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_SMSF_TaxFreeComponent"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFMemberRow_0_txtTaxFreeComponent']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixSMSFControl_AppendixSMSFMemberRow_0_txtTaxFreeComponent']")).SendKeys(A141);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();



            /********BI*****************/
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[7]/a")).Click();
            // driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[7]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_rbHaveBusinessInterestYes']")).Click();


            string A142 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_BI_Entity"];
            SelectElement oSelectionA142 = new SelectElement(driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_ddlEntity']")));
            oSelectionA142.SelectByText(A142);



            string A143 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_BI_TradingName"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessTradingName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessTradingName']")).SendKeys(A143);


            string C144 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_BI_NatureOfBusiness"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtNatureOfBusiness']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtNatureOfBusiness']")).SendKeys(C144);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_rbInvlInRunningBusinessYes']")).Click();


            string C145 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_BI_BusinessStructure"];
            SelectElement oSelectionC145 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_ddlBusinessStructure']")));
            oSelectionC145.SelectByText(C145);

            string C146 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_BI_StructureRelationship"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtStructureRelationship']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtStructureRelationship']")).SendKeys(C146);


            string C147 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_BI_OperatingEntityName"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtOperatingEntityName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtOperatingEntityName']")).SendKeys(C147);



            string C148 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_BI_BusinessNetvalue"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessNetvalue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessNetvalue']")).SendKeys(C148);




            string C149 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_BI_ShareHolding"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessShareHolding']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessShareHolding']")).SendKeys(C149);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_rbDependentsInBusinessNo']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_rbHavePersGuantInBusinessYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtPersGuantInBusinessDetail']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtPersGuantInBusinessDetail']")).SendKeys("Mark Taylor as a Gurantor");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_rbHaveBusinessSuccPlanYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_rbHaveBusinessSuccIssueAddrYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessSuccInsLastReviewed']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessSuccInsLastReviewed']")).SendKeys("Two Weeks Back @ Office");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessSuccArrangDetail']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessSuccArrangDetail']")).SendKeys("Depends on Business Profit");


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessAdditionalNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessAdditionalNotes']")).SendKeys("Test Pupose");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            /******/
            // driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[8]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[8]/a")).Click();


            string C150 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Redund_RedundancyType"];
            SelectElement oSelectionA150 = new SelectElement(driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRedundancyControl_AppendixRedundancyRow_0_ddlRedundancyType']")));
            oSelectionA150.SelectByText(C150);



            string C151 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Redund_ETPDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRedundancyControl_AppendixRedundancyRow_0_txtETPDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRedundancyControl_AppendixRedundancyRow_0_txtETPDate']")).SendKeys(C151);

            string C152 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Redund_EligibleServiceDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRedundancyControl_AppendixRedundancyRow_0_txtEligibleServiceDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRedundancyControl_AppendixRedundancyRow_0_txtEligibleServiceDate']")).SendKeys(C152);


            string C153 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Redund_Amount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRedundancyControl_AppendixRedundancyRow_0_txtAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRedundancyControl_AppendixRedundancyRow_0_txtAmount']")).SendKeys(C153);
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[9]/a

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            //   driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[9]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[9]/a")).Click();


            string C154 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_AL_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtDescription']")).SendKeys(C154);

            string C155 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_AL_ETPDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtETPDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtETPDate']")).SendKeys(C155);


            string C156 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_AL_Amount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtAmount']")).SendKeys(C156);



            string C157 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Redund_LeaveType"];
            SelectElement oSelectionC157 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_ddlLeaveType']")));
            oSelectionC157.SelectByText(C157);

            //driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[10]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[10]/a")).Click();


            string C158 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_LSL_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtDescription']")).SendKeys(C158);



            string C159 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_LSL_ETPDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtETPDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtETPDate']")).SendKeys(C159);



            string C160 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_LSL_EligibleDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtEligibleDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtEligibleDate']")).SendKeys(C160);


            string C161 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_LSL_Amount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtAmount']")).SendKeys(C161);



            string C162 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_LSL_LeaveType"];
            SelectElement oSelectionC162 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_ddlLeaveType']")));
            oSelectionC162.SelectByText(C162);


            //    driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[11]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[11]/a")).Click();


            string C163 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DB_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBDescription']")).SendKeys(C163);


            string C164 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DB_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBAccuredMultiple']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBAccuredMultiple']")).SendKeys(C164);




            string C165 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DB_AccuralRate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBAccuralRate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBAccuralRate']")).SendKeys(C165);



            string C166 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DB_SuperSalary"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBSuperSalary']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBSuperSalary']")).SendKeys(C166);

            string C167 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DB_DBTaxFreeAmount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBTaxFreeAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBTaxFreeAmount']")).SendKeys(C167);


            string C168 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_DB_PaymentDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBBenefitPaymentDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBBenefitPaymentDate']")).SendKeys(C168);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();




            /******OK**/
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAppendix']")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/ul/li[2]/a")).Click();


            Thread.Sleep(1000);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbMeetCurrentDebtYes"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAppendix']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbMeetCurrentDebtYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbPayDebtSoonYes']")).Click();


            string P19 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DebtRepay"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_txtAgeDebtRepaid']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_txtAgeDebtRepaid']")).SendKeys(A19);


            string P20 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_LifeDebt"];
            SelectElement oSelectionP20 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_ddlLifeStyleDebt']")));
            oSelectionP20.SelectByText(P20);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbOffsetOrRedrawYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbHomeLoanExtraRepaymentsYes']")).Click();


            string P21 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_ImediAccess"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_txtImmediateAccessTo']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_txtImmediateAccessTo']")).SendKeys(P21);




            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[1]/table/tbody/tr[7]/td")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbAddtlPaymentsYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbDirectSalIntoLoanNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbHomeLoadRepayChargesYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_txtHomeLoadRepayChargesAmt']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_txtHomeLoadRepayChargesAmt']")).SendKeys("Processing Fees");

            string P211 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_InterestFree"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_txtIntFreePeriod']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_txtIntFreePeriod']")).SendKeys(P211);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDebtControl_rbPayCCWithinIntFreePeriodYes']")).Click();

            //     driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_rbPreviousWithdrawnNo']")).Click();


            string P22 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_RetireAge"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtRetireAge']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtRetireAge']")).SendKeys(A22);


            string P23 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_RetireDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtRetireDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtRetireDate']")).SendKeys(A23);


            string P24 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Saving4Retire"];
            SelectElement oSelectionP24 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_ddlSavingPriority']")));
            oSelectionP24.SelectByText(P24);




            string P25 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_IncAfterTax"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtAnnualIncomeInRetirement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtAnnualIncomeInRetirement']")).SendKeys(P25);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_rbHaveSufficientFundsInRetirmentYes']")).Click();

            string P26 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_IncInRetire"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtSourcesOfIncomeInRetirment']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtSourcesOfIncomeInRetirment']")).SendKeys(P26);



            string P27 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_IncAssetsRetire"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtOtherAssets']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_txtOtherAssets']")).SendKeys(A27);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_rbHaveSufficientIncomeYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_rbChangeLifestyleNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_rbDownsizingNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_rbHigherRiskStrategyYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_rbLeaveMoneyYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_rbHaveMadeCommutationNo']")).Click();



            string P28 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_ProdName"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtName']")).SendKeys(P28);


            string P29 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_PenType"];
            SelectElement oSelectionP29 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_ddlPensionType']")));
            oSelectionP29.SelectByText(P29);


            string P30 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_PayFreq"];
            SelectElement oSelectionP30 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_ddlPaymentFrequency']")));
            oSelectionP30.SelectByText(P30);



            string P31 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_GrosInc"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtGrossAnnualIncome']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtGrossAnnualIncome']")).SendKeys(P31);



            string P32 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_AnnTaxFreeAmt"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtAnnualTaxFreeAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtAnnualTaxFreeAmount']")).SendKeys(P32);



            string P33 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_IniInvest"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtInitialInvestment']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtInitialInvestment']")).SendKeys(P33);



            string P34 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_RCV"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtResidualCapitalValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtResidualCapitalValue']")).SendKeys(P34);



            string P35 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_CDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtCommencementDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtCommencementDate']")).SendKeys(P35);



            string P36 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_CDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtTerm']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtTerm']")).SendKeys(P36);



            string P37 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_InveNumber"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtInvestorNumber']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtInvestorNumber']")).SendKeys(P37);




            string P38 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_EliServDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txteligibleservicedate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txteligibleservicedate']")).SendKeys(P38);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txteligibleservicedate"]

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_rbComplyingYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_rbRevisionaryNo']")).Click();


            string P39 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_RevBenific"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtRevisionaryBeneficiary']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtRevisionaryBeneficiary']")).SendKeys(P39);



            string P40 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DatePur"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtDateOfPurchase']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtDateOfPurchase']")).SendKeys(P40);




            string P41 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_AssetTest"];

            SelectElement oSelectionP41 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_ddlAssetTest']")));
            oSelectionP41.SelectByText(P41);


            string P42 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_MaturDate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtMaturityDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtMaturityDate']")).SendKeys(P42);



            string P43 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_CurrentBalance"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtPensionCurrentBalance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtPensionCurrentBalance']")).SendKeys(P43);


            string P44 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_AnnuAmtPa"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtAnnuityAmountPa']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtAnnuityAmountPa']")).SendKeys(P44);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRetirementControl_AppendixPensionRow_0_txtAnnuityAmountPa"]


            string P45 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_IndexRate"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtIndexationRate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtIndexationRate']")).SendKeys(P45);



            string P46 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_CurreUPP"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtCurrentUPP']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtCurrentUPP']")).SendKeys(P46);




            string P47 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_TaxDeduct"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtTaxDeductible']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtTaxDeductible']")).SendKeys(P47);


            string P48 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_CentreLink"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtCentreLink']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtCentreLink']")).SendKeys(P48);


            string P49 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_CGTExempt"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtCGTExempt']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtCGTExempt']")).SendKeys(P49);



            string P50 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Concessional"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtConcessional']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtConcessional']")).SendKeys(P50);



            string P51 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Post94Invalid"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtPost94Invalidity']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtPost94Invalidity']")).SendKeys(P51);



            string P52 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_TaxUnTaxed"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtTaxableElementUntaxed']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtTaxableElementUntaxed']")).SendKeys(P52);


            string P53 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Excessive"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtExcessive']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtExcessive']")).SendKeys(P53);



            string P54 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Rebateable"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtRebateablePortion']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtRebateablePortion']")).SendKeys(P54);


            string P55 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_InvestOptions"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtInvestmentOptions']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_txtInvestmentOptions']")).SendKeys(P55);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRetirementControl_AppendixPensionRow_0_rbAssetToBeRetainedYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            //      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[3]/a")).Click();
            /****Partner Risk *****/
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[3]/a")).Click();
            //    driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbSmokerNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbHaveHeathIssuesNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHeathComments']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHeathComments']")).SendKeys("OK");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbRelyOnEmploymentYes']")).Click();


            string PR56 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_FDepends"];

            SelectElement oSelectionPR56 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_ddlIncomeDependance']")));
            oSelectionPR56.SelectByText(PR56);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHowMaintainLifestyle']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHowMaintainLifestyle']")).SendKeys("Through Savings");



            string PR57 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TempIncReplace"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtTIIncomeReplacement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtTIIncomeReplacement']")).SendKeys(PR57);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbTIProvideProvisionYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbTIHaveAccessNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbTICeaseWorkNo']")).Click();

            string PR58 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_PermIncReplace"];
            //  SelectElement oSelectionA58 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtPDIncomeReplacement']")));
            //  oSelectionA58.SelectByText(A58);
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtPDIncomeReplacement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtPDIncomeReplacement']")).SendKeys(PR58);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbPDProvideProvisionYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbPDCeaseWorkNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbPDMortgageFreeYes']")).Click();


            string PR59 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_Provision"];
            SelectElement oSelectionPR59 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_ddlUDLeaveLivingStandard']")));
            oSelectionPR59.SelectByText(PR59);


            string PR60 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_UnExpIncReplace"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtUDIncomeReplacement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtUDIncomeReplacement']")).SendKeys(PR60);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbUDFundsPaidYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbUDProvideProvisionYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbUDMortgageFreeYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbUDAccessToFundsYes']")).Click();


            //   driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[1]/td/div/div[1]/div/label/span[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[3]/table[2]/tbody/tr[1]/td/div/div[1]/div/label/span[1]")).Click();


            string PR61 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_AmntReq"];

            //*[@id="txtAmountRequiredPerYear"]
            //*[@id='txtAmountRequiredPerYear']
            //    string PR61 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDReducedebt"];

            /*** driver.FindElement(By.XPath("//*[@id='txtTPDReducedebt']")).Clear();
             driver.FindElement(By.XPath("//*[@id='txtTPDReducedebt']")).SendKeys(P71);****/


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtAmountRequiredPerYear']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtAmountRequiredPerYear']")).SendKeys(PR61);


            //    driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).SendKeys(PR61);


            string PR62 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_HM"];
            //*[@id="txtDeathHomeMortgage"]

            /* driver.FindElement(By.XPath("//*[@id='txtDeathHomeMortgage']")).Clear();
             driver.FindElement(By.XPath("//*[@id='txtDeathHomeMortgage']")).SendKeys(PR62);*/
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathHomeMortgage']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathHomeMortgage']")).SendKeys(PR62);


            //*[@id="txtDeathOtherAmount"]
            string PR63 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_Other"];

            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathOtherAmount']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathOtherAmount']")).SendKeys(PR63);


            /****      driver.FindElement(By.XPath("//*[@id='txtDeathOtherAmount']")).Clear();
                  driver.FindElement(By.XPath("//*[@id='txtDeathOtherAmount']")).SendKeys(PR63);****/





            string PR64 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_FuneralCost"];

            //    driver.FindElement(By.XPath("//*[@id='txtDeathFuneralCosts']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='txtDeathFuneralCosts']")).SendKeys(PR64);

            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathFuneralCosts']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathFuneralCosts']")).SendKeys(PR64);




            string PR65 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_EmergencyFund"];

            //  driver.FindElement(By.XPath("//*[@id='txtDeathEmergencyFund']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtDeathEmergencyFund']")).SendKeys(PR65);
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathEmergencyFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathEmergencyFund']")).SendKeys(PR65);



            string PR66 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_EducationFund"];

            //driver.FindElement(By.XPath("//*[@id='txtDeathEducationFund']")).Clear();
            //driver.FindElement(By.XPath("//*[@id='txtDeathEducationFund']")).SendKeys(PR66);

            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathEducationFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathEducationFund']")).SendKeys(PR66);


            string PR67 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_EstatePlanningFund"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathEstatePlanningFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathEstatePlanningFund']")).SendKeys(PR67);


            // driver.FindElement(By.XPath("//*[@id='txtDeathEstatePlanningFund']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtDeathEstatePlanningFund']")).SendKeys(PR67);


            string PR68 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_ChildCareFund"];




            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathChildCareFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathChildCareFund']")).SendKeys(PR68);



            /*   driver.FindElement(By.XPath("//*[@id='txtDeathChildCareFund']")).Clear();
               driver.FindElement(By.XPath("//*[@id='txtDeathChildCareFund']")).SendKeys(PR68);*/



            string PR69 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_ProvisionforTax"];

            // driver.FindElement(By.XPath("//*[@id='txtDeathProvisionforTax']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtDeathProvisionforTax']")).SendKeys(PR69);


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathProvisionforTax']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathProvisionforTax']")).SendKeys(PR69);






            string PR70 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_OtherFund"];

            // driver.FindElement(By.XPath("//*[@id='txtDeathOtherFund']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtDeathOtherFund']")).SendKeys(PR70);
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathOtherFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtDeathOtherFund']")).SendKeys(PR70);



            string PR71 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDReducedebt"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDReducedebt']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDReducedebt']")).SendKeys(PR71);



            // driver.FindElement(By.XPath("//*[@id='txtTPDReducedebt']")).Clear();
            // driver.FindElement(By.XPath("//*[@id='txtTPDReducedebt']")).SendKeys(PR71);




            string PR72 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaReducedebt"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaReducedebt']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaReducedebt']")).SendKeys(PR72);

            // driver.FindElement(By.XPath("//*[@id='txtTraumaReducedebt']")).Clear();
            // driver.FindElement(By.XPath("//*[@id='txtTraumaReducedebt']")).SendKeys(PR72);

            string PR73 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDHomeMortgage"];

            //   driver.FindElement(By.XPath("//*[@id='txtTPDHomeMortgage']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtTPDHomeMortgage']")).SendKeys(PR73);

            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDHomeMortgage']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDHomeMortgage']")).SendKeys(PR73);


            string PR74 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaHomeMortgage"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaHomeMortgage']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaHomeMortgage']")).SendKeys(PR74);



            //driver.FindElement(By.XPath("//*[@id='txtTraumaHomeMortgage']")).Clear();
            // driver.FindElement(By.XPath("//*[@id='txtTraumaHomeMortgage']")).SendKeys(PR74);


            string PR75 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDOtherAmount"];



            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDOtherAmount']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDOtherAmount']")).SendKeys(PR75);

            //    driver.FindElement(By.XPath("//*[@id='txtTPDOtherAmount']")).Clear();
            //      driver.FindElement(By.XPath("//*[@id='txtTPDOtherAmount']")).SendKeys(PR75);





            string PR76 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_OtherAmount"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaOtherAmount']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaOtherAmount']")).SendKeys(PR76);


            // driver.FindElement(By.XPath("//*[@id='txtTraumaOtherAmount']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtTraumaOtherAmount']")).SendKeys(PR76);



            string PR77 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDMedicalLifestyleFund"];



            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDMedicalLifestyleFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDMedicalLifestyleFund']")).SendKeys(PR77);


            // driver.FindElement(By.XPath("//*[@id='txtTPDMedicalLifestyleFund']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtTPDMedicalLifestyleFund']")).SendKeys(PR77);


            string PR78 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaMedicalLifestyleFund"];



            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaMedicalLifestyleFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaMedicalLifestyleFund']")).SendKeys(PR78);

            ///  driver.FindElement(By.XPath("//*[@id='txtTraumaMedicalLifestyleFund']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtTraumaMedicalLifestyleFund']")).SendKeys(PR78);


            string PR79 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDEmergencyFund"];



            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDEmergencyFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDEmergencyFund']")).SendKeys(PR79);

            //   driver.FindElement(By.XPath("//*[@id='txtTPDEmergencyFund']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtTPDEmergencyFund']")).SendKeys(PR79);


            string PR80 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaEmergencyFund"];

            //  driver.FindElement(By.XPath("//*[@id='txtTraumaEmergencyFund']")).Clear();
            // driver.FindElement(By.XPath("//*[@id='txtTraumaEmergencyFund']")).SendKeys(PR80);


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaEmergencyFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaEmergencyFund']")).SendKeys(PR80);



            string PR81 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDRecoveryFund"];



            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDRecoveryFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDRecoveryFund']")).SendKeys(PR81);


            //  driver.FindElement(By.XPath("//*[@id='txtTPDRecoveryFund']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtTPDRecoveryFund']")).SendKeys(PR81);

            string PR82 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaRecoveryFund"];




            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaRecoveryFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaRecoveryFund']")).SendKeys(PR82);

            // driver.FindElement(By.XPath("//*[@id='txtTraumaRecoveryFund']")).Clear();
            // driver.FindElement(By.XPath("//*[@id='txtTraumaRecoveryFund']")).SendKeys(PR82);



            string PR83 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDHomePurchaseFund"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDHomePurchaseFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDHomePurchaseFund']")).SendKeys(PR83);


            //   driver.FindElement(By.XPath("//*[@id='txtTPDHomePurchaseFund']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtTPDHomePurchaseFund']")).SendKeys(PR83);



            string PR84 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaHomePurchaseFund"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaHomePurchaseFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaHomePurchaseFund']")).SendKeys(PR84);


            //  driver.FindElement(By.XPath("//*[@id='txtTraumaHomePurchaseFund']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtTraumaHomePurchaseFund']")).SendKeys(PR84);


            string PR85 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDEducation"];



            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDEducation']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDEducation']")).SendKeys(PR85);


            //  driver.FindElement(By.XPath("//*[@id='txtTPDEducation']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtTPDEducation']")).SendKeys(PR85);




            string PR86 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaEducation"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaEducation']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaEducation']")).SendKeys(PR86);



            //driver.FindElement(By.XPath("//*[@id='txtTraumaEducation']")).Clear();
            //     driver.FindElement(By.XPath("//*[@id='txtTraumaEducation']")).SendKeys(PR86);


            string PR87 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDEstatePlanning"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDEstatePlanning']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDEstatePlanning']")).SendKeys(PR87);




            //     driver.FindElement(By.XPath("//*[@id='txtTPDEstatePlanning']")).Clear();
            //     driver.FindElement(By.XPath("//*[@id='txtTPDEstatePlanning']")).SendKeys(PR87);

            string PR88 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaEstatePlanning"];

            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaEstatePlanning']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaEstatePlanning']")).SendKeys(PR88);


            // driver.FindElement(By.XPath("//*[@id='txtTraumaEstatePlanning']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='txtTraumaEstatePlanning']")).SendKeys(PR88);

            string PR89 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDChildCareFund"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDChildCareFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDChildCareFund']")).SendKeys(PR89);


            //   driver.FindElement(By.XPath("//*[@id='txtTPDChildCareFund']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtTPDChildCareFund']")).SendKeys(PR89);

            string PR90 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaChildCareFund"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaChildCareFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaChildCareFund']")).SendKeys(PR90);


            // driver.FindElement(By.XPath("//*[@id='txtTraumaChildCareFund']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtTraumaChildCareFund']")).SendKeys(PR90);

            string PR91 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDOtherFund"];

            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDOtherFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTPDOtherFund']")).SendKeys(PR91);


            //    driver.FindElement(By.XPath("//*[@id='txtTPDOtherFund']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='txtTPDOtherFund']")).SendKeys(PR91);

            string PR92 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TraumaOtherFund"];


            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaOtherFund']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtTraumaOtherFund']")).SendKeys(PR92);


            //  driver.FindElement(By.XPath("//*[@id='txtTraumaOtherFund']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtTraumaOtherFund']")).SendKeys(PR92);


            string PR93 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_IncomeRequested"];




            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtIncomeRequested']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtIncomeRequested']")).SendKeys(PR93);


            //   driver.FindElement(By.XPath("//*[@id='txtIncomeRequested']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtIncomeRequested']")).SendKeys(PR93);



            string PR94 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_WaitingPeriod"];

            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtWaitingPeriod']")).Clear();
            driver.FindElement(By.XPath(".//input[@name='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtWaitingPeriod']")).SendKeys(PR94);


            // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtWaitingPeriod']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtWaitingPeriod']")).SendKeys(PR94);


            string PR95 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_BenefitPeriod"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtBenefitPeriod']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtBenefitPeriod']")).SendKeys(PR95);


            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();

            // String Control = driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType]")).Text;
            if ((driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")) == null))
            //     if ((Control == null))
            {

                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();


            }


            string PR97 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_AccruedSickLeaveDays"];

            //       driver.FindElement(By.XPath("//*[@id='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtAccruedSickLeaveDays']")).Clear();
            //       driver.FindElement(By.XPath("//*[@id='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtAccruedSickLeaveDays']")).SendKeys(PR97);
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtAccruedSickLeaveDays']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtAccruedSickLeaveDays']")).SendKeys(PR97);

            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtAccruedSickLeaveDays']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtAccruedSickLeaveDays']")).SendKeys(PR97);


            string PR98 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_AccruedLeaveDays"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtAccruedLeaveDays']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtAccruedLeaveDays']")).SendKeys(PR98);

            //   driver.FindElement(By.XPath("//*[@id='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtAccruedLeaveDays']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='ctl00$ctl00$cph1$cph1$CfactsAdvanceControl$AppendixControl$PartnerAppendixRiskControl$txtAccruedLeaveDays']")).SendKeys(PR98);


            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtAccruedLeaveDays']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtAccruedLeaveDays']")).SendKeys(PR98);


            string PR99 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_OtherBenefits"];



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtOtherBenefits']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtOtherBenefits']")).SendKeys(PR99);


            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtOtherBenefits']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtOtherBenefits']")).SendKeys(PR99);

            string PR100 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_HazardousPursuits"];


            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHazardousPursuit']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHazardousPursuits']")).SendKeys(PR100);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHazardousPursuits']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHazardousPursuits']")).SendKeys(PR100);
            /******************************************************************************************************************************************************************************/
            //   driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[4]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[4]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbHowLongInvested40']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbLevelOfReturn50']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbPoorlyPerformingInvestment10']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbInvestmentMarkets40']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbTaxEfficiency20']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbPortfolioDecreased40']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbPurposeOfInvesting20']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();





            /*****************************************************CHECK**************************************/
            /****Risk Profile OK***/
            /******/
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbHowLongInvested40']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbHowLongInvested40']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbLevelOfReturn50']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbPoorlyPerformingInvestment10']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbInvestmentMarkets40']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbTaxEfficiency20']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbPortfolioDecreased40']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixProfileControl_rbPurposeOfInvesting20']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            /*******************/

            /**************Direct Property*******/
            // driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[4]/a")).Click();



            //     driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a")).Click();

            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a
            //      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/ul/li[2]/a")).Click();

            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[5]/a")).Click();
            /**************************************OK***********/
            /******               driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/ul/li[2]/a")).Click();/****************/

            /*******Direct Property***/
            /*******/
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[5]/a")).Click();
            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a")).Click();
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[5]/a
            string P1101 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDescription']")).SendKeys(P1101);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDescription"]
            string P11011 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_PropType"];
            SelectElement oSelectionP11011 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_ddlPropertyType']")));
            oSelectionP11011.SelectByText(P11011);

            string P102 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Owner"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOwner']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOwner']")).SendKeys(P102);


            string P103 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_PurchasePrice"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtPurchasePrice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtPurchasePrice']")).SendKeys(P103);


            string P104 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DatePurchased"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDatePurchased']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDatePurchased']")).SendKeys(P104);

            string P105 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_CurrentValue"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtCurrentValue']")).SendKeys(P105);

            string P106 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_ProjectedCapitalGrowth"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedCapitalGrowth']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedCapitalGrowth']")).SendKeys(P106);



            string P107 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_ActualRentalIncome"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtActualRentalIncome']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtActualRentalIncome']")).SendKeys(P107);

            string P108 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_ProjectedRentalIncome"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedRentalIncome']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedRentalIncome']")).SendKeys(P108);

            string P109 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DepreciationAllowance"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciationAllowance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciationAllowance']")).SendKeys(P109);


            string P110 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Depreciation"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciation']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciation']")).SendKeys(P110);


            string P111 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_AnnualExpenses"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtAnnulaExpenses']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtAnnulaExpenses']")).SendKeys(P111);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_rbdemedforcentrelinkYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_rbRetainYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_rbRepayOnTPD']")).Click();

            string P112 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Rates"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtRates']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtRates']")).SendKeys(P112);

            string P113 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_AgentFees"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtAgentFees']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtAgentFees']")).SendKeys(P113);

            string P114 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_LandTax"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtLandTax']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtLandTax']")).SendKeys(P114);

            string P115 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Insurance"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtInsurance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtInsurance']")).SendKeys(P115);

            string P116 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_InterestOnLoan"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtInterestOnLoan']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtInterestOnLoan']")).SendKeys(P116);


            string P117 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_BodyCorporate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtBodyCorporate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtBodyCorporate']")).SendKeys(P117);

            string P118 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_OtherTax"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOtherTax']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOtherTax']")).SendKeys(P118);


            string P119 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_OtherCosts"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOtherCosts']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtOtherCosts']")).SendKeys(P119);
            string P120 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_MaintenanceRepairs"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtMaintenanceRepairs']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtMaintenanceRepairs']")).SendKeys(P120);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[5]/div/ul/li[2]/a")).Click();


            string P121 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Sell_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtDescription']")).SendKeys(P121);



            string P122 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Sell_ExpectedDateOfSale"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtExpectedDateOfSale']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtExpectedDateOfSale']")).SendKeys(P122);



            string P1221 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Sell_ExpectedSalePrice"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtExpectedSalePrice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtExpectedSalePrice']")).SendKeys(P1221);




            string P123 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Sell_AgentFees"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtAgentFees']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtAgentFees']")).SendKeys(P123);


            string P124 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Sell_LegalFees"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtLegalFees']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtLegalFees']")).SendKeys(P124);


            string P125 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Sell_SubdivisionCost"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtSubdivisionCost']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtSubdivisionCost']")).SendKeys(P125);

            string P126 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Sell_ProjectedDisposalCost"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtProjectedDisposalCost']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtProjectedDisposalCost']")).SendKeys(P126);


            string P127 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Sell_EstimatedCapitalGainsTax"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtEstimatedCapitalGainsTax']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtEstimatedCapitalGainsTax']")).SendKeys(P127);

            string P128 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Sell_OtherDisposalCosts"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtOtherDisposalCosts']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtOtherDisposalCosts']")).SendKeys(P128);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertySellingRow_0_txtNotes']")).SendKeys("Notes for Property");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            /*******************/
            /******/
            /************SMSFOK***/

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[6]/a")).Click();


            string P129 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_FundName"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtFundName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtFundName']")).SendKeys(P129);

            string P130 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_CorporateTrusteeABN"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtCorporateTrusteeABN']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtCorporateTrusteeABN']")).SendKeys(P130);



            string P131 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_RegisteredAddress"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtRegisteredAddress']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtRegisteredAddress']")).SendKeys(P131);




            string P132 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_EstablishmentDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtEstablishmentDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtEstablishmentDate']")).SendKeys(P132);

            string P133 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_TypesFund"];
            SelectElement oSelectionP133 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_ddlSMSFType']")));
            oSelectionP133.SelectByText(P133);


            string P134 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_ReserveAccount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtReserveAccount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtReserveAccount']")).SendKeys(P134);


            string P135 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_LoansBorrowed"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtLoansBorrowed']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtLoansBorrowed']")).SendKeys(P135);


            string P136 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_TotalFunds"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtTotalFunds']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtTotalFunds']")).SendKeys(P136);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFFundRow_0_txtNotes']")).SendKeys("SMSF Notes");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[6]/div/ul/li[2]/a")).Click();


            string P137 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_MemberName"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFMemberRow_0_txtMemberName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFMemberRow_0_txtMemberName']")).SendKeys(P137);


            string P138 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_CurrentBalance"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFMemberRow_0_txtCurrentBalance']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFMemberRow_0_txtCurrentBalance']")).SendKeys(P138);


            string P139 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_RegularContributions"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFMemberRow_0_txtRegularContributions']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFMemberRow_0_txtRegularContributions']")).SendKeys(P139);



            string P1400 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_P_A_Phase"];
            SelectElement oSelectionP1400 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFMemberRow_0_ddlPhaseType']")));
            oSelectionP1400.SelectByText(P1400);


            string P141 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_SMSF_TaxFreeComponent"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFMemberRow_0_txtTaxFreeComponent']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixSMSFControl_AppendixSMSFMemberRow_0_txtTaxFreeComponent']")).SendKeys(P141);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            /**********************/

            /********BI****/
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[7]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_rbHaveBusinessInterestYes']")).Click();


            string P142 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_BI_Entity"];
            SelectElement oSelectionP142 = new SelectElement(driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_ddlEntity']")));
            oSelectionP142.SelectByText(P142);



            string P143 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_BI_TradingName"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessTradingName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessTradingName']")).SendKeys(P143);


            string P144 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_BI_NatureOfBusiness"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtNatureOfBusiness']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtNatureOfBusiness']")).SendKeys(P144);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_rbInvlInRunningBusinessYes']")).Click();


            string P145 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_BI_BusinessStructure"];
            SelectElement oSelectionA145 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_ddlBusinessStructure']")));
            oSelectionA145.SelectByText(P145);

            string P146 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_BI_StructureRelationship"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtStructureRelationship']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtStructureRelationship']")).SendKeys(P146);


            string P147 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_BI_OperatingEntityName"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtOperatingEntityName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtOperatingEntityName']")).SendKeys(P147);



            string P148 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_BI_BusinessNetvalue"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessNetvalue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessNetvalue']")).SendKeys(P148);




            string P149 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_BI_ShareHolding"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessShareHolding']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessShareHolding']")).SendKeys(P149);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_rbDependentsInBusinessNo']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_rbHavePersGuantInBusinessYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtPersGuantInBusinessDetail']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtPersGuantInBusinessDetail']")).SendKeys("Mark Taylor as a Gurantor");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_rbHaveBusinessSuccPlanYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_rbHaveBusinessSuccIssueAddrYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessSuccInsLastReviewed']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessSuccInsLastReviewed']")).SendKeys("Two Weeks Back @ Office");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessSuccArrangDetail']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessSuccArrangDetail']")).SendKeys("Depends on Business Profit");


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessAdditionalNotes']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixBusinessControl_AppendixBusinessInterestRow_0_txtBusinessAdditionalNotes']")).SendKeys("Test Pupose");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            /*******/
            /***********************OK*****/
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[8]/a")).Click();



            string P150 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Redund_RedundancyType"];
            SelectElement oSelectionP150 = new SelectElement(driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRedundancyControl_AppendixRedundancyRow_0_ddlRedundancyType']")));
            oSelectionP150.SelectByText(P150);



            string P151 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Redund_ETPDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRedundancyControl_AppendixRedundancyRow_0_txtETPDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRedundancyControl_AppendixRedundancyRow_0_txtETPDate']")).SendKeys(P151);

            string P152 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Redund_EligibleServiceDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRedundancyControl_AppendixRedundancyRow_0_txtEligibleServiceDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRedundancyControl_AppendixRedundancyRow_0_txtEligibleServiceDate']")).SendKeys(P152);


            string P153 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Redund_Amount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRedundancyControl_AppendixRedundancyRow_0_txtAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRedundancyControl_AppendixRedundancyRow_0_txtAmount']")).SendKeys(P153);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[9]/a")).Click();


            string P154 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_AL_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtDescription']")).SendKeys(P154);

            string P155 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_AL_ETPDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtETPDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtETPDate']")).SendKeys(P155);


            string P156 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_AL_Amount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_txtAmount']")).SendKeys(P156);



            string P157 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Redund_LeaveType"];
            SelectElement oSelectionP157 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixAnnualLeaveControl_AppendixAnnualLeaveRow_0_ddlLeaveType']")));
            oSelectionP157.SelectByText(P157);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[10]/a")).Click();



            string P158 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_LSL_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtDescription']")).SendKeys(P158);



            string P159 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_LSL_ETPDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtETPDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtETPDate']")).SendKeys(P159);



            string P160 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_LSL_EligibleDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtEligibleDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtEligibleDate']")).SendKeys(P160);


            string P161 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_LSL_Amount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_txtAmount']")).SendKeys(P161);



            string P162 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_LSL_LeaveType"];
            SelectElement oSelectionP162 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixLongServiceLeaveControl_AppendixLongServiceLeaveRow_0_ddlLeaveType']")));
            oSelectionP162.SelectByText(P162);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[11]/a")).Click();



            string P163 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DB_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBDescription']")).SendKeys(P163);


            string P164 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DB_Description"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBAccuredMultiple']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBAccuredMultiple']")).SendKeys(P164);




            string P165 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DB_AccuralRate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBAccuralRate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBAccuralRate']")).SendKeys(P165);



            string P166 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DB_SuperSalary"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBSuperSalary']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBSuperSalary']")).SendKeys(P166);

            string P167 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DB_DBTaxFreeAmount"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBTaxFreeAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBTaxFreeAmount']")).SendKeys(P167);


            string P168 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DB_PaymentDate"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBBenefitPaymentDate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixDefinedControl_AppendixDefinedBenefitsRow_0_txtDBBenefitPaymentDate']")).SendKeys(P168);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            /*************************/

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAdditionalNotes']")).Click();


            IList<IWebElement> iframes = driver.FindElements(By.TagName("iframe"));
            //  driver.FindElements(By.TagName("iframe")).Text;
            int size = iframes.Count;
            Console.WriteLine("Frame SIZE IS :" + size);


            driver.SwitchTo().Frame(3);

            driver.FindElement(By.CssSelector("body")).Clear();
            IWebElement body1 = driver.FindElement(By.CssSelector("body"));
            Thread.Sleep(1000);
            Console.WriteLine("Frame 1");
            // body3.SendKeys("TESTING...Frames");
            //        body1.SendKeys("Clients Additioinal Notes for Testing....");
            string S1177 = System.Configuration.ConfigurationManager.AppSettings["C_AN"];
            body1.SendKeys(S1177);


            //   Console.WriteLine("Frame 4");

            driver.SwitchTo().DefaultContent();

            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[10]/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[15]/div[2]/ul/li[2]/a")).Click();

            IList<IWebElement> iframes2 = driver.FindElements(By.TagName("iframe"));
            //  driver.FindElements(By.TagName("iframe")).Text;
            int size2 = iframes2.Count;
            Console.WriteLine("Frame SIZE IS :" + size2);


            driver.SwitchTo().Frame(4);

            driver.FindElement(By.CssSelector("body")).Clear();
            IWebElement body22 = driver.FindElement(By.CssSelector("body"));
            Thread.Sleep(1000);
            Console.WriteLine("Frame 2");
            // body3.SendKeys("TESTING...Frames");
            //     body22.SendKeys("Partner Additioinal Notes for Testing....");
            string SP17 = System.Configuration.ConfigurationManager.AppSettings["P_AN"];

            body22.Clear();

            body22.SendKeys(SP17);



            //   Console.WriteLine("Frame 4");

            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            Console.WriteLine("Save Additional Notes");


        }
    }
}



