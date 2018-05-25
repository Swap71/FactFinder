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
    class Pension
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
        public void Pensions()
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

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

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

        }
    }
}
