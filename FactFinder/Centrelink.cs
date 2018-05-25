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
    class Centrelink
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
        public void CentreLink()
        {

            Thread.Sleep(2000);
            /*        string title = driver.Title;
                    Console.WriteLine("Title of the web page is -> " + title);
                    Assert.IsTrue(title.Contains("My Dashboard"), title + " doesn't contains 'title.'");

                    */



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

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

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

           

        }
    }
}