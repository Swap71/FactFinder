using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FactFinder
{
    class Insurance
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
        public void Insurance_Fields__Mandatory()
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

            // IWebDriver driver;
            Thread.Sleep(2000);
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
        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtProvider']")).SendKeys(S290);



            string S291 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_SumInsur"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtSumInsured']")).Clear();
       //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtSumInsured']")).SendKeys(S291);


            string S292 = System.Configuration.ConfigurationManager.AppSettings["C_Insur_Prem_Amnt"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtPremium']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_ClientInsuranceRow_0_txtPremium']")).SendKeys(S292);


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
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtProvider']")).SendKeys(S295);


            string S296 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_SumInsur"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtSumInsured']")).Clear();
          //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtSumInsured']")).SendKeys(S296);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtPremium"]
            string S297 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Prem_Amnt"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtPremium']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_txtPremium']")).SendKeys(S297);


            string S298 = System.Configuration.ConfigurationManager.AppSettings["P_Insur_Pay_Freq"];
            SelectElement oSelection298 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_ddlPaymentFrequency']")));
            oSelection298.SelectByText(S298);
            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_ddlPaymentFrequency']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_InsurancesControl_PartnerInsuranceRow_0_ddlPaymentFrequency']")).SendKeys(S298);


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            /****************Express Insurance OK *****/



        }
    }
}
