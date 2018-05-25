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
    class IncExp
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
        public void INC_EXP_Fields__Mandatory()
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

       //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientIncomeRow_0_txtIncomeName']")).SendKeys(S24);


            string S25 = System.Configuration.ConfigurationManager.AppSettings["C_Gross"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientIncomeRow_0_txtAnnualGrossIncomeAmount']")).Clear();
       //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientIncomeRow_0_txtAnnualGrossIncomeAmount']")).SendKeys(S25);

            //         driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/div/div[1]/table[2]/tbody[2]/tr/td/a")).Click();

            string S26 = System.Configuration.ConfigurationManager.AppSettings["C_Desc"];
            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtDescription']")).Clear();
      //      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtDescription']")).SendKeys(S26);

            string S2611 = System.Configuration.ConfigurationManager.AppSettings["C_Freq"];

            SelectElement oSelection2611 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_ddlPaymentFrequency']")));
            oSelection2611.SelectByText(S2611);

            string S2511 = System.Configuration.ConfigurationManager.AppSettings["C_Amnt"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtProjectedAmount']")).Clear();
      //      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_ClientExpenseRow_0_txtProjectedAmount']")).SendKeys(S2511);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[5]/div[2]/ul/li[2]/a")).Click();

            string S2521 = System.Configuration.ConfigurationManager.AppSettings["P_Incomes"];
            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_ddlIncomeType']")).Clear();
            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_ddlIncomeType']")).SendKeys(S2521);


            SelectElement oSelection2612 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_ddlIncomeType']")));
            oSelection2612.SelectByText(S2521);


            string S2522 = System.Configuration.ConfigurationManager.AppSettings["P_Occu"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_txtIncomeName']")).Clear();
     //       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_txtIncomeName']")).SendKeys(S2522);



            string S2523 = System.Configuration.ConfigurationManager.AppSettings["P_Gross"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_txtAnnualGrossIncomeAmount']")).Clear();
      //      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerIncomeRow_0_txtAnnualGrossIncomeAmount']")).SendKeys(S2523);


            string S2524 = System.Configuration.ConfigurationManager.AppSettings["P_Desc"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_txtDescription']")).Clear();
       //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_txtDescription']")).SendKeys(S2524);

            string S2712 = System.Configuration.ConfigurationManager.AppSettings["P_Freq"];

            SelectElement oSelection2712 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_ddlPaymentFrequency']")));
            oSelection2712.SelectByText(S2712);

            string S2525 = System.Configuration.ConfigurationManager.AppSettings["P_Amnt"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_txtProjectedAmount']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_IncomeExpensesControl_PartnerExpenseRow_0_txtProjectedAmount']")).SendKeys(S2525);

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();




        }
    }

}
