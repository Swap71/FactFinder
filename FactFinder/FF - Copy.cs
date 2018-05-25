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

namespace FactFinder
{
    class CFF
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
        public void ExpressCFactFinder()
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


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlDiscoveryNotes']")).Click();
            IList<IWebElement> iframes17 = driver.FindElements(By.TagName("iframe"));
            //  driver.FindElements(By.TagName("iframe")).Text;
            int size17 = iframes17.Count;
            Console.WriteLine("Frame SIZE IS :" + size17);

            driver.SwitchTo().Frame(1);

            driver.FindElement(By.CssSelector("body")).Clear();
            IWebElement body222 = driver.FindElement(By.CssSelector("body"));
            Thread.Sleep(1000);
            Console.WriteLine("Frame 1");
            // body3.SendKeys("TESTING...Frames");
            //     body22.SendKeys("Partner Additioinal Notes for Testing....");
            string SP172 = System.Configuration.ConfigurationManager.AppSettings["C_DN"];
            body222.SendKeys(SP172);
            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[1]/div[2]/ul/li[2]/a")).Click();

            driver.SwitchTo().Frame(2);



            driver.FindElement(By.CssSelector("body")).Clear();
            IWebElement body44 = driver.FindElement(By.CssSelector("body"));
            Thread.Sleep(1000);
            Console.WriteLine("Frame 2");
            // body3.SendKeys("TESTING...Frames");
            //    body4.SendKeys("Partner Discovery Notes for Testing....");
            string P17 = System.Configuration.ConfigurationManager.AppSettings["P_DN"];
            body44.SendKeys(P17);
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();




            /**************OK PD Express**/
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlPersonalDetails']")).Click();


            Console.WriteLine("Click on Personal Details ");

            Thread.Sleep(1000);

            string S1 = System.Configuration.ConfigurationManager.AppSettings["C_GIVEN NAME"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientGivenNames']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientGivenNames']")).SendKeys(S1);


          //  Assert("Swap","C_GIVEN NAME","Matrch");
         //   Assert.IsTrue(message1.Contains("SOA request"), message1 + " doesn't contains 'message.'");
         //   Assert.IsTrue(S1.Equals("Swap"), S1 + " doesn't contains 'message.'");
       /***     Assert.AreNotEqual(S1.Equals("Swap"), S1 + " doesn't contains 'message.'");
            String EP41 = driver.FindElement(By.CssSelector("body")).Text;
            Console.WriteLine("Frame 1");***/
            //    Assert.AreEqual(expectedResultEP1, EP41);
            Assert.AreEqual("Swap", S1);


            string S2 = System.Configuration.ConfigurationManager.AppSettings["C_SUR NAME"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientSurname']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientSurname']")).SendKeys(S2);

            string S6 = System.Configuration.ConfigurationManager.AppSettings["C_DOB"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientDateOfBirth']")).Clear();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtClientDateOfBirth']")).SendKeys(S6);

            Console.WriteLine("Enter DOB");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_rbClientGenderMale']")).Click();

            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/div/div/div[1]/table/tbody/tr[5]/td")));


            //    SelectElement oSelection = new SelectElement(driver.FindElement(By.Id("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ddlClientMaritalStatus']")));
            SelectElement oSelection = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ddlClientMaritalStatus']")));

            string S7 = System.Configuration.ConfigurationManager.AppSettings["C_MS"];

            oSelection.SelectByText(S7);

            /*      IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                  IWebElement ej = driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/div/div/div[1]/table/tbody/tr[5]/td"));
                  //     ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();"
                  //                                                        , element);



                  js.ExecuteScript("arguments[3].click();", ej);

                  Console.WriteLine("JS CHK ");*/
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ClientTFN']")).Clear();


            string S8 = System.Configuration.ConfigurationManager.AppSettings["C_TFN"];


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_ClientTFN']")).SendKeys(S8);

            Console.WriteLine("TFN");



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            Console.WriteLine("Profile SAVE");


            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[2]/a")).Click();


            string S9 = System.Configuration.ConfigurationManager.AppSettings["C_MOB"];

            driver.FindElement(By.XPath("//*[@id='txtClientMobilePhone']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtClientMobilePhone']")).SendKeys(S9);

            string S10 = System.Configuration.ConfigurationManager.AppSettings["C_EMAIL"];


            driver.FindElement(By.XPath("//*[@id='txtClientEmail']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtClientEmail']")).SendKeys(S10);

            string S11 = System.Configuration.ConfigurationManager.AppSettings["C_SKYPE"];


            driver.FindElement(By.XPath("//*[@id='txtClientSkypeUsername']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtClientSkypeUsername']")).SendKeys(S11);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            Console.WriteLine("Contact SAVE");


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[3]/a")).Click();


            string S12 = System.Configuration.ConfigurationManager.AppSettings["C_ADDR1"];

            driver.FindElement(By.XPath("//*[@id='txtClientAddress1']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtClientAddress1']")).SendKeys(S12);


            string S13 = System.Configuration.ConfigurationManager.AppSettings["C_ADDR2"];

            driver.FindElement(By.XPath("//*[@id='txtClientAddress2']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtClientAddress2']")).SendKeys(S13);


            string S14 = System.Configuration.ConfigurationManager.AppSettings["C_SUBR"];


            driver.FindElement(By.XPath("//*[@id='txtClientSuburb']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtClientSuburb']")).SendKeys(S14);

            Thread.Sleep(1000);
            //*[@id="ddlClientState"]


            string S15 = System.Configuration.ConfigurationManager.AppSettings["C_STA"];

            SelectElement oSelection2 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ddlClientState']")));

            oSelection2.SelectByText(S15);


            string S16 = System.Configuration.ConfigurationManager.AppSettings["C_PC"];

            driver.FindElement(By.XPath("//*[@id='txtClientPostcode']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtClientPostcode']")).SendKeys(S16);


            string S17 = System.Configuration.ConfigurationManager.AppSettings["C_Cntry"];


            SelectElement oSelection3 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ddlClientCountry']")));

            oSelection3.SelectByText(S17);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            Console.WriteLine("Address SAVE");

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a")).Click();



            Thread.Sleep(2000);


            string S3 = System.Configuration.ConfigurationManager.AppSettings["P_GIVEN NAME"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerGivenNames']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerGivenNames']")).SendKeys(S3);

            string S4 = System.Configuration.ConfigurationManager.AppSettings["P_SUR NAME"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerSurname']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerSurname']")).SendKeys(S4);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerDateOfBirth']")).Clear();


            string S5 = System.Configuration.ConfigurationManager.AppSettings["P_DOB"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_txtPartnerDateOfBirth']")).SendKeys(S5);

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


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_PersonalDetailsControl_PartnerTFN']")).SendKeys(S19);

            Console.WriteLine("TFN");



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            Console.WriteLine("Profile SAVE");


            Thread.Sleep(1000);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[2]/a")).Click();


            string S20 = System.Configuration.ConfigurationManager.AppSettings["P_MOB"];

            driver.FindElement(By.XPath("//*[@id='txtPartnerMobilePhone']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtPartnerMobilePhone']")).SendKeys(S20);


            string S21 = System.Configuration.ConfigurationManager.AppSettings["P_EMAIL"];


            driver.FindElement(By.XPath("//*[@id='txtPartnerEmail']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtPartnerEmail']")).SendKeys(S21);

            string S22 = System.Configuration.ConfigurationManager.AppSettings["P_SKYPE"];

            driver.FindElement(By.XPath("//*[@id='txtPartnerSkypeUsername']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtPartnerSkypeUsername']")).SendKeys(S22);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            Console.WriteLine("Contact SAVE");

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/ul/li[3]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[2]/div/div/div[3]/table/tbody[1]/tr[2]/td/div/label/span")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            Console.WriteLine("Partner Contact SAVE");






            /******OK        Thread.Sleep(2000);****/
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlFinancialObjectives"]

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlFinancialObjectives']")).Click();


            //    Thread.Sleep(2000);
            string S268 = System.Configuration.ConfigurationManager.AppSettings["C_FO_Type1"];
            SelectElement oSelection268 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_ddlFinancialObjectiveType']")));
            oSelection268.SelectByText(S268);

            string S269 = System.Configuration.ConfigurationManager.AppSettings["C_FO_Prio1"];
            SelectElement oSelection269 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_ddlPriorityType']")));
            oSelection269.SelectByText(S269);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtShortTerm']")).Clear();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtShortTerm']")).SendKeys("Test Immediate");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtMediumTerm']")).Clear();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtMediumTerm']")).SendKeys("Test Medium-Long Term ");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtLongTerm']")).Clear();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_ClientFinancialObjectiveRow_0_txtLongTerm']")).SendKeys("Test Ongoing ");


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/ul/li[2]/a")).Click();
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/ul/li[2]/a
            //      String add = driver.FindElement(By.XPath("//*[@id='ctl00_trfinancialobjectiverow']")).Text;
            //      Console.WriteLine("Add FO is available or not" + add);
            //      if(add!="Add Financial Objective")

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/div/div[2]/div/a")).Click();
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/div
            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[3]/div[2]/div/div[2]/div
            string S270 = System.Configuration.ConfigurationManager.AppSettings["P_FO_Type1"];
            SelectElement oSelection270 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ddlFinancialObjectiveType']")));
       //     SelectElement oSelection270 = new SelectElement(driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_ddlFinancialObjectiveType']")));
           oSelection270.SelectByText(S270);

           


            string S271 = System.Configuration.ConfigurationManager.AppSettings["P_FO_Prio1"];
            //  SelectElement oSelection271 = new SelectElement(driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_ddlPriorityType']")));
            SelectElement oSelection271 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ddlPriorityType']")));
            oSelection271.SelectByText(S271);

           


            



            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_txtShortTerm']")).Clear();

            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_txtShortTerm']")).SendKeys("Partner Immediate");

            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_txtMediumTerm']")).Clear();

            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_txtMediumTerm']")).SendKeys("Partner Medium-Long Term ");

            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_txtLongTerm']")).Clear();

            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_FinancialObjectivesControl_PartnerFinancialObjectiveRow_0_txtLongTerm']")).SendKeys("Partner Ongoing ");



            Console.WriteLine("Add FO is available OK");
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            /***************************Express Reason For Advice***************************************************/
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlReasonForAdvice']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_ClientReasonForAdviceRow_0_txtReasonForAdvice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_ClientReasonForAdviceRow_0_txtReasonForAdvice']")).SendKeys("For Systematic Investments 1");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_ClientReasonForAdviceRow_1_txtReasonForAdvice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_ClientReasonForAdviceRow_1_txtReasonForAdvice']")).SendKeys("For Systematic Investments 2");



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_ClientReasonForAdviceRow_2_txtReasonForAdvice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_ClientReasonForAdviceRow_2_txtReasonForAdvice']")).SendKeys("For Systematic Investments 3");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[4]/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_PartnerReasonForAdviceRow_0_txtReasonForAdvice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_PartnerReasonForAdviceRow_0_txtReasonForAdvice']")).SendKeys("Partner For Systematic Investments 1");


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_PartnerReasonForAdviceRow_1_txtReasonForAdvice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_PartnerReasonForAdviceRow_1_txtReasonForAdvice']")).SendKeys("Partner For Systematic Investments 2");



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_PartnerReasonForAdviceRow_2_txtReasonForAdvice']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_PartnerReasonForAdviceRow_2_txtReasonForAdvice']")).SendKeys("Partner For Systematic Investments 3");

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();





            /*****************************Incomes*****************/
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlIncomeExpenses']/span[2]")).Click();

            Console.WriteLine("Income & Expenses");

            string S23 = System.Configuration.ConfigurationManager.AppSettings["C_Incomes"];

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlIncomeExpenses"]
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlIncomeExpenses"]/span[2]
            SelectElement oSelection5 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientIncomeRow_0_ddlIncomeType']")));

            oSelection5.SelectByText(S23);


            string S24 = System.Configuration.ConfigurationManager.AppSettings["C_Occu"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientIncomeRow_0_txtIncomeName']")).Clear();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientIncomeRow_0_txtIncomeName']")).SendKeys(S24);


            string S25 = System.Configuration.ConfigurationManager.AppSettings["C_Gross"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientIncomeRow_0_txtAnnualGrossIncomeAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientIncomeRow_0_txtAnnualGrossIncomeAmount']")).SendKeys(S25);

            //         driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[1]/table[2]/tbody[2]/tr/td/a")).Click();

            string S26 = System.Configuration.ConfigurationManager.AppSettings["C_Desc"];
            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtDescription']")).SendKeys(S26);

            string S2611 = System.Configuration.ConfigurationManager.AppSettings["C_Freq"];

            SelectElement oSelection2611 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_ddlPaymentFrequency']")));
            oSelection2611.SelectByText(S2611);

            string S2511 = System.Configuration.ConfigurationManager.AppSettings["C_Amnt"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtProjectedAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtProjectedAmount']")).SendKeys(S2511);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/ul/li[2]/a")).Click();

            string S2521 = System.Configuration.ConfigurationManager.AppSettings["P_Incomes"];
            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_ddlIncomeType']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_ddlIncomeType']")).SendKeys(S2521);


            SelectElement oSelection2612 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_ddlIncomeType']")));
            oSelection2612.SelectByText(S2521);


            string S2522 = System.Configuration.ConfigurationManager.AppSettings["P_Occu"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_txtIncomeName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_txtIncomeName']")).SendKeys(S2522);



            string S2523 = System.Configuration.ConfigurationManager.AppSettings["P_Gross"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_txtAnnualGrossIncomeAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_txtAnnualGrossIncomeAmount']")).SendKeys(S2523);


            string S2524 = System.Configuration.ConfigurationManager.AppSettings["P_Desc"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_txtDescription']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_txtDescription']")).SendKeys(S2524);

            string S2712 = System.Configuration.ConfigurationManager.AppSettings["P_Freq"];

            SelectElement oSelection2712 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_ddlPaymentFrequency']")));
            oSelection2712.SelectByText(S2712);

            string S2525 = System.Configuration.ConfigurationManager.AppSettings["P_Amnt"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_txtProjectedAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_txtProjectedAmount']")).SendKeys(S2525);




            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();




            /****************Assets & Liabilities***/
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(" //*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();



            Console.WriteLine("Assets & Liabilities");


            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlVehicleType"]

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlAssetsLiabilities']")).Click();

            string S29 = System.Configuration.ConfigurationManager.AppSettings["C_VT1"];//*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlVehicleType"]
                                                                                        // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlVehicleType']")).Click();
            SelectElement oSelection7 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlVehicleType']")));
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_1_ddlVehicleType"]
            oSelection7.SelectByText(S29);

            string S30 = System.Configuration.ConfigurationManager.AppSettings["C_ALName1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtName']")).SendKeys(S30);

            string S31 = System.Configuration.ConfigurationManager.AppSettings["C_ALValue1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtCurrentValue']")).SendKeys(S31);

            // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlAssetsLiabilities']")).Click();

            /******* OPT2             driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[1]/table[1]/tbody[2]/tr/td/a")).Click();

                         string S32 = System.Configuration.ConfigurationManager.AppSettings["C_VT2"];
                         // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlVehicleType']")).Click();
                         //         SelectElement oSelection8 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_1_ddlVehicleType']")));
                         SelectElement oSelection8 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ddlVehicleType']")));

                         oSelection8.SelectByText(S32);

                                               string S33 = System.Configuration.ConfigurationManager.AppSettings["C_ALName2"];
                                               driver.FindElement(By.XPath("//*[@id='ctl00_txtName']")).Clear();
                         driver.FindElement(By.XPath("//*[@id='ctl00_txtName']")).SendKeys(S33);
                         // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_1_txtName']")).SendKeys(S33);

                         string S34 = System.Configuration.ConfigurationManager.AppSettings["C_ALValue2"];

                                               driver.FindElement(By.XPath("//*[@id='ctl00_txtCurrentValue']")).Clear();
                         //       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_1_txtCurrentValue']")).SendKeys(S34);
                         driver.FindElement(By.XPath("//*[@id='ctl00_txtCurrentValue']")).SendKeys(S34);
                         *****/

            string S35 = System.Configuration.ConfigurationManager.AppSettings["C_LName1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtName']")).SendKeys(S35);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_1_ddlVehicleType"]

            string S36 = System.Configuration.ConfigurationManager.AppSettings["C_LCB1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtCurrentValue']")).SendKeys(S36);




            string S37 = System.Configuration.ConfigurationManager.AppSettings["C_LIR1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtInterestRate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtInterestRate']")).SendKeys(S37);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[1]/table[2]/tbody[2]/tr/td/a")).Click();

            /****OPT2          string S38 = System.Configuration.ConfigurationManager.AppSettings["C_LName2"];

                                           driver.FindElement(By.XPath("//*[@id='ctl00_txtName']")).Clear();

                      //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_1_txtName']")).SendKeys(S38);
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_1_txtNam']")).SendKeys(S38);

                      //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_1_ddlVehicleType"]

                      string S39 = System.Configuration.ConfigurationManager.AppSettings["C_LCB2"];
                                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_1_txtCurrentValue']")).Clear();
                                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_1_txtCurrentValue']")).SendKeys(S39);




                                           string S40 = System.Configuration.ConfigurationManager.AppSettings["C_LIR2"];
                                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_1_txtInterestRate']")).Clear();
                                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_1_txtInterestRate']")).SendKeys(S40);

                 *****/

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/ul/li[2]/a")).Click();

            string S41 = System.Configuration.ConfigurationManager.AppSettings["P_VT1"];
            SelectElement oSelection9 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlVehicleType']")));
            oSelection9.SelectByText(S41);

            string S42 = System.Configuration.ConfigurationManager.AppSettings["P_ALName1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName']")).SendKeys(S42);

            string S43 = System.Configuration.ConfigurationManager.AppSettings["P_ALValue1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).SendKeys(S43);



            string S44 = System.Configuration.ConfigurationManager.AppSettings["P_LName1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtName']")).SendKeys(S44);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_1_ddlVehicleType"]



            string S45 = System.Configuration.ConfigurationManager.AppSettings["P_LCB1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtCurrentValue']")).SendKeys(S45);




            string S46 = System.Configuration.ConfigurationManager.AppSettings["P_LIR1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtInterestRate']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtInterestRate']")).SendKeys(S46);





            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            Console.WriteLine("Save ---Assets & Liabilities");/**************OK*********************/




            /****** Express Super OK*****/
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlSuper']")).Click();


            string S47 = System.Configuration.ConfigurationManager.AppSettings["C_SVT1"];
            SelectElement oSelection10 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_ClientSuperRow_0_ddlSuperFundType']")));

            oSelection10.SelectByText(S47);

            string S48 = System.Configuration.ConfigurationManager.AppSettings["C_PN1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_ClientSuperRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_ClientSuperRow_0_txtName']")).SendKeys(S48);

            string S49 = System.Configuration.ConfigurationManager.AppSettings["C_SCB1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_ClientSuperRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_ClientSuperRow_0_txtCurrentValue']")).SendKeys(S49);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[7]/div[2]/ul/li[2]/a")).Click();


            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[7]/div[2]/ul/li[2]/a

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_PartnerSuperRow_0_ddlSuperFundType"]
            string S50 = System.Configuration.ConfigurationManager.AppSettings["P_SVT1"];
            SelectElement oSelection11 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_PartnerSuperRow_0_ddlSuperFundType']")));

            oSelection11.SelectByText(S50);

            string S51 = System.Configuration.ConfigurationManager.AppSettings["P_PN1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_PartnerSuperRow_0_txtName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_PartnerSuperRow_0_txtName']")).SendKeys(S51);

            string S52 = System.Configuration.ConfigurationManager.AppSettings["P_SCB1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_PartnerSuperRow_0_txtCurrentValue']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_PartnerSuperRow_0_txtCurrentValue']")).SendKeys(S52);



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            Console.WriteLine("Save ---SUPER");

            Thread.Sleep(2000);/***************OOK Express Super**/

            /***************************Insurance***************************************************/
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlInsurances']")).Click();

            // driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[8]/div[2]/div/div[1]/table/tbody[2]/tr/td/a")).Click();
            //*[@id="ctl00_ddlInsuranceType"]

            /*         driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[8]/div[2]/div/div[1]/table/tbody[2]/tr/td/a")).Click();*/

            string Sc289 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Type"];

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_2_ddlInsuranceType"]
            SelectElement oSelectionc289 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_ddlInsuranceType']")));
            oSelectionc289.SelectByText(Sc289);
            //*[@id="ctl00_ddlInsuranceType"]
            //*[@id="ctl00_ddlInsuranceType"]
            //*[@id="ctl00_ddlInsuranceType"]


            string S290 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Pro_Name"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtProvider']")).SendKeys(S290);



            string S291 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_SumInsur"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtSumInsured']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtSumInsured']")).SendKeys(S291);


            string S292 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Prem_Amnt"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtPremium']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtPremium']")).SendKeys(S292);


            string S293 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Pay_Freq"];
            SelectElement oSelection293 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_ddlPaymentFrequency']")));
            oSelection293.SelectByText(S293);


            // driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[8]/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[8]/div[2]/ul/li[2]/a")).Click();

            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[8]/div[2]/div/div[2]/table/tbody[2]/tr/td/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[8]/div[2]/div/div[2]/table/tbody[2]/tr/td/a")).Click();

            //  string Sc289 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Type"];
            //   SelectElement oSelectionc289 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ddlInsuranceType']")));
            //    oSelectionc289.SelectByText(Sc289);

            string Sc294 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Type"];

            SelectElement oSelectionc294 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_ddlInsuranceType']")));
            oSelectionc294.SelectByText(Sc294);

            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_ddlInsuranceType']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_ddlInsuranceType']")).SendKeys(S294);


            string S295 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Pro_Name"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtProvider']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtProvider']")).SendKeys(S295);


            string S296 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_SumInsur"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtSumInsured']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtSumInsured']")).SendKeys(S296);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtPremium"]
            string S297 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Prem_Amnt"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtPremium']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtPremium']")).SendKeys(S297);


            string S298 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Pay_Freq"];
            SelectElement oSelection298 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_ddlPaymentFrequency']")));
            oSelection298.SelectByText(S298);
            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_ddlPaymentFrequency']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_ddlPaymentFrequency']")).SendKeys(S298);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            /****************Express Insurance OK *****/



            //eSTATE Planning - Express 

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlEstatePlanning']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_EstatePlanningControl_cbClientHaveWillYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_EstatePlanningControl_cbClientHaveFPOAYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_EstatePlanningControl_cbClientHaveMPOANo']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[9]/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_EstatePlanningControl_cbPartnerHaveWillYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_EstatePlanningControl_cbPartnerHaveFPOAND']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_EstatePlanningControl_cbPartnerHaveMPOAYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            /*****OK Estate Planning Express****/


            //Express AN
            /********OK**/
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlAdditionalNotes']")).Click();


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
            body1.Clear();

            body1.SendKeys(S1177);


            //   Console.WriteLine("Frame 4");

            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[10]/div[2]/ul/li[2]/a")).Click();

            /*
                        for (int i = 1; i < size; i++)
                        {
                            driver.SwitchTo().Frame(i);
                            //    String body2 = driver.FindElement(By.CssSelector("body")).GetAttribute("Value");
                            IWebElement body21 = driver.FindElement(By.CssSelector("body"));
                            //  body2.Text;
                            body21.SendKeys("TESTING...Frames" + i);
                            Console.WriteLine("Here is Data " + body21);
                            driver.SwitchTo().DefaultContent();
                        }*/

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
            Console.WriteLine("Save Additional Notes");/*****Express AN***/

            /*****************OK * **********/

            /******OK*************/



            // eXPRESS C-Fact Finder............Financial Objectives********
            /**     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlFinancialObjectives']")).Click();


                                  driver.SwitchTo().Frame(1);

                                       driver.FindElement(By.CssSelector("body")).Clear();
                                       IWebElement body17 = driver.FindElement(By.CssSelector("body"));
                                       Thread.Sleep(1000);
                                       Console.WriteLine("Frame 1");
                                       // body3.SendKeys("TESTING...Frames");
                                       //  body1.SendKeys("Clients Discovery Notes for Testing....");
                                       string C17 = System.Configuration.ConfigurationManager.AppSettings["C_DN"];
                                       body17.SendKeys(C17);


                                       //   Console.WriteLine("Frame 4");

                                       driver.SwitchTo().DefaultContent();
                                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


                                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[1]/div[2]/ul/li[2]/a")).Click();

                                       IList<IWebElement> iframes1 = driver.FindElements(By.TagName("iframe"));
                                       //  driver.FindElements(By.TagName("iframe")).Text;
                                       int size1 = iframes1.Count;
                                       Console.WriteLine("Frame SIZE IS :" + size1);*/
            /***
                          /**       for (int i = 1; i < size1; i++)
                 /****        {
                                    driver.SwitchTo().Frame(i);
                                      //    String body2 = driver.FindElement(By.CssSelector("body")).GetAttribute("Value");
                                      IWebElement body41 = driver.FindElement(By.CssSelector("body"));
                                      //  body2.Text;
                                      body41.SendKeys("TESTING...Frames" + i);
                                      Console.WriteLine("Here is Data " + body41);
                                      driver.SwitchTo().DefaultContent();

                         }***/
            /***                  driver.SwitchTo().Frame(2);


                             driver.FindElement(By.CssSelector("body")).Clear();
                             IWebElement body44 = driver.FindElement(By.CssSelector("body"));
                             Thread.Sleep(1000);
                             Console.WriteLine("Frame 2");
                             // body3.SendKeys("TESTING...Frames");
                             //    body4.SendKeys("Partner Discovery Notes for Testing....");
                             string P17 = System.Configuration.ConfigurationManager.AppSettings["P_DN"];
                             body44.SendKeys(P17);


                             //   Console.WriteLine("Frame 4");

                             driver.SwitchTo().DefaultContent();

                             driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[1]/div[2]/div/div[2]/div/div/div/div[2]/div/label/span")).Click();
                          //   driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[1]/div[2]/div/div[2]/div/div/div/div[2]/div/span")).Click();

                             driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


                             driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

                             driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[1]/div[2]/ul/li[2]/a")).Click();


                  //Personal Details Express

                  ///     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

                  /////     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities']")).Click();
                  *****/


            /********************************Advanced INCOMES & EXPENSES**************/
            driver.FindElement(By.XPath("//*[@id='hlFacts']")).Click();

            Console.WriteLine("Click on Fact Finder ");

            /*                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

                              Console.WriteLine("Click on Advance C Fact Finder "); // dIRECT GO TO eXPRESS & INCOMES & EXPENSES


                              driver.FindElement(By.XPath(" //*[@id='ctl00_txtDescription']")).Clear();
                                driver.FindElement(By.XPath("//*[@id='ctl00_txtDescription']")).SendKeys(S26);

                           Thread.Sleep(1000);

                                         string S27 = System.Configuration.ConfigurationManager.AppSettings["C_Freq"];


                                         //*[@id="ctl00_ddlPaymentFrequency"]

                                   IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                                         IWebElement ej = driver.FindElement(By.XPath("//*[@id='ctl00_ddlPaymentFrequency']"));
                                         //     ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();"
                                         //                                                        , element);



                                         js.ExecuteScript("arguments[3].click();", ej);

                                         Console.WriteLine("JS CHK ");

                              //       SelectElement oSelection6 = new SelectElement(driver.FindElement(By.XPath(" //*[@id'ctl00_ddlPaymentFrequency']")));

                              //     oSelection6.SelectByText(S27);

                              //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_ddlPaymentFrequency"]


                                     string S28 = System.Configuration.ConfigurationManager.AppSettings["C_Amnt"];


                                        driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtProjectedAmount']")).Clear();
                                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtProjectedAmount']")).SendKeys(S28);
      */




            /*****Advanced Super                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

                                  Thread.Sleep(1000);
                 /*****OK                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlPersonalDetails']")).Click();


                             wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='aspnetFor']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/div/div[1]/div/div[1]/table/tbody/tr[2]/td")));


                             String message1 = driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientGivenNames']")).Text;
                             Console.WriteLine("Message1 is :" + message1);
                             Thread.Sleep(2000);*/


            //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientGivenNames']")).Clear();

            //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientGivenNames']")).SendKeys("Test Name");

            //    IWebElement body4 = driver.FindElement(By.CssSelector("body"));


            //            driver.SwitchTo().Frame(1);
            /*      String EP41 = driver.FindElement(By.CssSelector("body")).Text;
                  Console.WriteLine("Frame 1");
                  Assert.AreEqual(expectedResultEP1, EP41);*/

            /****OK****************************************

                   string S92 = System.Configuration.ConfigurationManager.AppSettings["C_GIVEN NAME"];
                                string actualvalue = driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientGivenNames']")).GetAttribute("Value");
                                Console.WriteLine("actualvalue IS " + actualvalue);
                                //Assert.IsTrue(actualvalue.Contains("Client29MARCH"), actualvalue + " doesn't contains 'Mark1.'"); 
                                Assert.IsTrue(actualvalue.Contains(S92), actualvalue + "Not Equal");

                                string S93 = System.Configuration.ConfigurationManager.AppSettings["C_DOB"];
                                string actualvalue1 = driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientDateOfBirth']")).GetAttribute("Value");
                                Console.WriteLine("actualvalue IS " + actualvalue1);
                                Assert.IsTrue(actualvalue1.Contains(S93), actualvalue1 + "Not Equal");

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
                    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtName']")).Clear();
                                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtName']")).SendKeys(S95);



                            //     string S96 = ConfigurationManager.AppSettings["ADR1"];

                                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRAddress']")).Clear();
                                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRAddress']")).SendKeys("Unit 1");




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
            /******OK****************************************** string S102 = System.Configuration.ConfigurationManager.AppSettings["ContR"];


                                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRContactNumber']")).Clear();
                                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRContactNumber']")).SendKeys(S102);

                                  string S103 = System.Configuration.ConfigurationManager.AppSettings["RelR"];


                                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRRelationship']")).Clear();
                                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientNearestRelativeRow_0_txtNRRelationship']")).SendKeys("Cousine");


                                  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

                                  Console.WriteLine("Nearest Relartives SAVED");

                           driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[5]/a")).Click();
                           //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientHobbie']")).SendKeys("Cricket");

                               driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_txtClientHobbyNotes']")).SendKeys("Test Notes");


                               driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[6]/a")).Click();

                               string S104 = System.Configuration.ConfigurationManager.AppSettings["DepN"];

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
            /******OK******************************************           driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/div/div[1]/ul/li[7]/a")).Click();

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






                                                    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientAnniversaryRow_0_txtAnniversaryName']")).SendKeys("Stars");
                                                    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientAnniversaryRow_0_txtAnniversaryDate']")).SendKeys("18/04/1998");
                                                    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_ClientAnniversaryRow_0_txtDetails']")).SendKeys("Marriage Life");

                             //            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).SendKeys("Marriage Life");
                                                         //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a         

                             driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[2]/div[2]/ul/li[2]/a")).Click();

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

                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_PersonalDetailsControl_PartnerEmploymentRow_0_txtOccupation"]






                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlIncomeExpenses']")).Click();


                           driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[1]/ul/li[2]/a")).Click();


                                 string S189 = System.Configuration.ConfigurationManager.AppSettings["C_IR_INCOME_Name"];
                                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtIncomeItem']")).Clear();
                                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtIncomeItem']")).SendKeys(S189);



                                 string S190 = System.Configuration.ConfigurationManager.AppSettings["C_IR_INCOME_Date"];
                                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtDateIncurred']")).Clear();
                                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_ClientIrregularIncomeRow_0_txtDateIncurred']")).SendKeys(S189);

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

             ***************ok*************/
            /*****OK           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities']")).Click();
                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities"]//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities"]

                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities"]
                       string S218 = System.Configuration.ConfigurationManager.AppSettings["C_Invests_DP"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtDateAcquired']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtDateAcquired']")).SendKeys(S218);



                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities']")).Click();


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtDateAcquired']")).Click();


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes']")).Click();

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo']")).Click();

                       string S217 = System.Configuration.ConfigurationManager.AppSettings["C_Invests_CP"];

                       SelectElement oSelection217 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlCompanyPurpose']")));
                       oSelection217.SelectByText(S217);




                       string S219 = System.Configuration.ConfigurationManager.AppSettings["C_Invests_Emp"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")).SendKeys(S219);


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbCompanyIncludeInAdviceYes']")).Click();

                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


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



                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[1]/ul/li[3]/a")).Click();


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

            /******OK           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_rbRetainYes']")).Click();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_rbRepayOnTrauma']")).Click();

                    //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']


                       string S229 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Freq"];

                       SelectElement oSelection229 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']")));
                       oSelection229.SelectByText(S229);





           /*
                       string S228 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Retain"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlLoanType']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlLoanType']")).SendKeys(S227);

                       */

            /*****OK           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_cbClientDrawLoanYes']")).Click();

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_rbClientChangeInFutureLiabiitiesNo']")).Click();



                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/ul/li[2]/a")).Click();

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbInvestmentfundstockassetSecurityForLoanYes']")).Click();

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbInvestmentfundstockReInvestIncomeNo']")).Click();


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbInvestmentfundstockassetRepayOnTPD']")).Click();

                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[2]/ul/li[2]/a")).Click();

                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName"]


                       string S230 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Name"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName']")).SendKeys(S230);


                       string S231 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Owner"];

                       SelectElement oSelection231 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlOwnerType']")));
                       oSelection231.SelectByText(S231);

                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue"]
                       string S232 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Esti"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).SendKeys(S232);

                     //  string S233 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];
                       string S233 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Type"];
                       SelectElement oSelection233 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlAssetType']")));
                       oSelection233.SelectByText(S233);
                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlAssetType"]

                       string S234 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtDateAcquired']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtDateAcquired']")).SendKeys(S234);

                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount"]

                       string S235 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PA"];



                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount']")).SendKeys(S235);


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();
                       string S236 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Inc"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();


                   //    driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
                    //   driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S236);


                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate"]

                       string S237 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Matu"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate']")).SendKeys(S237);
                     //  driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
                      // driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S236);


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_rbdemedforcentrelinkNo']")).Click();

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_rbReInvestIncomeNo']")).Click();

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_rbRepayOnTPD']")).Click();

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_rbIsLoanAttachedNo']")).Click();

                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[2]/ul/li[3]/a")).Click();




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

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_rbPartnerChangeInFutureLiabiitiesYes']")).Click();

                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlSuper']")).Click();


                       string S244 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_FT"];
                       SelectElement oSelection244 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_ddlFundType']")));
                       oSelection244.SelectByText(S244);

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_ddlFundType']")).Click();

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

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbCGovernmentCoContributionYes']")).Click();

                       string S255 = System.Configuration.ConfigurationManager.AppSettings["C_Sup_Contri"];
                       SelectElement oSelection255 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ddlCGovernmentCoContributionInvestment']")));
                       oSelection255.SelectByText(S255);


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbCBringForwardRuleNo']")).Click();



                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbCTransitionalPhaseYes']")).Click();




                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[7]/div[2]/ul/li[2]/a")).Click();

                       string S256 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_FT"];
                       SelectElement oSelection256 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlFundType']")));
                       oSelection256.SelectByText(S256);
                       //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlFundType"]
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlFundType']")).Click();

                       string S257 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_UIO"];
                       SelectElement oSelection257 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_ddlInvestmentOption']")));
                       oSelection257.SelectByText(S257);


                       string S258 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_DJ"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtDateJoined']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtDateJoined']")).SendKeys(S258);



                       string S259 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_CY"];

                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContributionEmployer']")).Clear();
                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_PartnerSuperRow_0_txtContributionEmployer']")).SendKeys(S259);

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


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbPGovernmentCoContributionYes']")).Click();


                       Thread.Sleep(2000);
                       string S267 = System.Configuration.ConfigurationManager.AppSettings["P_Sup_Contri"];
                       SelectElement oSelection267 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ddlPGovernmentCoContributionInvestment']")));
                       oSelection267.SelectByText(S267);


                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbPBringForwardRuleYes']")).Click();



                       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_rbPTransitionalPhaseNo']")).Click();





                       driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
                      OK************/



            /*******OK
                        //Advanced C Fact Finder
                        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

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

                        ****OK***/

            //Esate Planning -Advanced 
            /*****            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();


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

            ************************OK******/

            //        driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/ul/li[2]/a")).Click();


            /*      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/ul/li[2]/a")).Click();

                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEnduringPOAYes']")).Click();


                  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerGuardiansForChildrenYes']")).Click();

                  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();*/

            /******Test
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





            /******Advanced AN
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();
                      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAdditionalNotes']")).Click();
                      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[15]/div[2]/ul/li[2]/a")).Click();

                      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[15]/div[2]/div/div[2]/div/div/div[2]/div/label/span")).Click();
                      driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
                      **OK*********/


            /***   for (int i = 1; i < size17; i++)
                   {
                       driver.SwitchTo().Frame(i);
                       //    String body2 = driver.FindElement(By.CssSelector("body")).GetAttribute("Value");
                       IWebElement body21 = driver.FindElement(By.CssSelector("body"));
                       //  body2.Text;
                       body21.SendKeys("TESTING...Frames" + i);
                       Console.WriteLine("Here is Data " + body21);
                       driver.SwitchTo().DefaultContent();
                   }**/



            /***Advance Reason for Advice******
              driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();


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

                ********OK***/


            /**********Advance Insurance
                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlInsurances']")).Click();

                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtPolicyNo']")).SendKeys("1A12");

                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtPolicyPurpose']")).SendKeys("Test Your Insurance");

                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_trriskinsurancerow']/table/tbody/tr[3]/td[1]/div/label/span")).Click();

                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtCommencementDate']")).Clear();
                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_txtCommencementDate']")).SendKeys("01/03/2018");

                         //  driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_ddlPremiumType"]
                                string S299 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Risk_PremTyp"];
                           SelectElement oSelection299 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_ddlPremiumType']")));
                           oSelection299.SelectByText(S299);
                           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_InsurancesControl_ClientRiskInsuranceRow_0_trriskinsurancerow']/table/tbody/tr[7]/td[1]/div/label/span")).Click();

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
                           //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_hlInsurances"]
                           //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_ReasonForAdviceControl_PartnerReasonForAdviceRow_1_txtReasonForAdvice"]

                           //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a
                           //   Thread.Sleep(2000);
                           /*******        driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/div/div[2]/ul/li[2]/a")).Click();*****/


            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAState']")).Click();  
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientLastReviewDate"]

            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ddlPGovernmentCoContributionInvestment']")).Click();

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_SuperControl_ClientSuperRow_0_txtContrSelfCurrentYear"]

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount"]
            //  driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtDateAcquired"]

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularExpenseRow_0_ddlFrequency"]

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerExpenseRow_0_txtProjectedAmount"]

            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_ddlFrequenc']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_ddlFrequenc']")).SendKeys(S205);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_IncomeExpensesControl_PartnerIrregularIncomeRow_0_txtAmount"]

            //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[2]/ul/li[2]/a
            /*       string S91 = ConfigurationManager.AppSettings["C_GIVEN NAME"];

                   Assert.IsTrue(message1.Contains(S91), message1 + " doesn't contains 'message.'");*/

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_SuperControl_ClientSuperRow_0_ddlSuperFundType"]


            //   .//*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtProjectedAmount"]

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_ddlPaymentFrequency"]
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientIncomeRow_0_ddlIncomeType"]

            /*      IWebElement element = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ClientName"));*/



            /***********

                        var C_USERNAME = ConfigurationManager.AppSettings["C_USERNAME"];
                        //     var C_USERNAME = System.Configuration.ConfigurationManager.AppSettings["Client15MARCH "];


                        Console.WriteLine(string.Format("Given Name is : "));
                        //    element.SendKeys(C_USERNAME);
                        /*        element.SendKeys("Client29MARCH");*/


            /******            PageFactory.InitElements(driver, eformData);

                        eformData.EnterClient(ACN2);

                        //  driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ClientName")).SendKeys("Jeff1");

                        Console.WriteLine("Enter Search");
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_btnSearch']")).Click();

                        Console.WriteLine("Click on Search button");

                        for (int i = 0; i <= 20; i++)
                        {


                            //    String ss = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAR_ctl00__" + i + "']/td[2]")).Text;
                            String gn = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgUsers_ctl00__" + i + "']/td[4]")).Text;


                         /*   PageFactory.InitElements(driver, eformData);

                            eformData.EnterClient(ACN2);*/

            /******               string s = ConfigurationManager.AppSettings["C_USERNAME"];
                       //    string s = "CM29";


                           if (!String.IsNullOrEmpty(s))
                           {

                               Console.WriteLine("C_Given Name is:" + gn);
                               String sn = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgUsers_ctl00__" + i + "']/td[5]")).Text;
                               //*[@id="ctl00_ctl00_cph1_cph1_rgUsers_ctl00__0"]/td[5]

                               string s1 = ConfigurationManager.AppSettings["C_GIVEN NAME"];***/
            /*****                  string s1 = "Client29MARCH";


                               if (!String.IsNullOrEmpty(s1))

                               {

                                   Console.WriteLine("Given Name is:" + sn);


                                   Console.WriteLine("Into Loop i is +" + i);


                                   var im1 = driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_rgUsers_ctl00__" + i + "']/td[7]"));


                                   Console.WriteLine("i value chk is +" + i);

                                   im1.Click();

                                //   break;
                            //   }
                       //    }
                   //    }

                    //   Thread.Sleep(4000);

               ***/

        }
    }
}




//  }
// }

