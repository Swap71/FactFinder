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
    class Appen
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
        public void Appendix()
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
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtTIIncomeReplacement']")).SendKeys(A60);

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

            //driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")).Clear();
            // driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")).SendKeys(A96);


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
            /****Risk **/
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbSmokerNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbHaveHeathIssuesNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHeathComments']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHeathComments']")).SendKeys("OK");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbRelyOnEmploymentYes']")).Click();


            string P56 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_FDepends"];

            SelectElement oSelectionP56 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_ddlIncomeDependance']")));
            oSelectionP56.SelectByText(P56);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHowMaintainLifestyle']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtHowMaintainLifestyle']")).SendKeys("Through Savings");



            string P571 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TempIncReplace"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtTIIncomeReplacement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtTIIncomeReplacement']")).SendKeys(P571);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbTIProvideProvisionYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbTIHaveAccessNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbTICeaseWorkNo']")).Click();

            string P58 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_PermIncReplace"];
            //  SelectElement oSelectionA58 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_ClientAppendixRiskControl_txtPDIncomeReplacement']")));
            //  oSelectionA58.SelectByText(A58);
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtPDIncomeReplacement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtPDIncomeReplacement']")).SendKeys(P58);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbPDProvideProvisionYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbPDCeaseWorkNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbPDMortgageFreeYes']")).Click();


            string P59 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_Provision"];
            SelectElement oSelectionP59 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_ddlUDLeaveLivingStandard']")));
            oSelectionP59.SelectByText(P59);


            string P60 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_UnExpIncReplace"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtUDIncomeReplacement']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_txtTIIncomeReplacement']")).SendKeys(P60);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbUDFundsPaidYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbUDProvideProvisionYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbUDMortgageFreeYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixRiskControl_rbUDAccessToFundsYes']")).Click();


            //     driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[1]/td/div/div[1]/div/label/span[1]")).Click();
            //*[@id="txtAmountRequiredPerYear"]
            /****              driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[3]/table[2]/tbody/tr[1]/td/div/div[1]/div/label/span[1]")).Click();

                 //         driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[1]/td/div/div[1]/div/label/span[1]")).Click();



                      string B61 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_AmntReq"];

                      driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).Clear();
                      driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).SendKeys(B61);
                      //*[@id="txtAmountRequiredPerYear"]


                      string B62 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_HM"];

                      driver.FindElement(By.XPath("//*[@id='txtDeathHomeMortgage']")).Clear();
                      driver.FindElement(By.XPath("//*[@id='txtDeathHomeMortgage']")).SendKeys(B62);

                      //*[@id="txtDeathOtherAmount"]
            /******          string A63 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_Other"];

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

            //     }
            /*******/
            /***         string A96 = System.Configuration.ConfigurationManager.AppSettings["C_Appen_Risk_AccidentCoverType"];

                     driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")).Clear();
                     driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")).SendKeys(A96);


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

                  ***/
            /** &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&**/






















            /***/
            /******          wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[3]/table[2]/tbody/tr[2]/td[1]")));
                      // var image6 = driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']"))SendKeys("Hello");
                      driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).SendKeys("Hello");
                      //   image6.SendKeys("Hello");
                      */
            /*****8**
        
            string P61 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_AmntReq"];


            driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).SendKeys(A61);

            driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtAmountRequiredPerYear']")).SendKeys(P61);
            //*[@id="txtAmountRequiredPerYear"]


            /*****/
            /******8**
            string P62 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_HM"];



            driver.FindElement(By.XPath("//*[@id='txtDeathHomeMortgage']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathHomeMortgage']")).SendKeys(P62);

            //*[@id="txtDeathOtherAmount"]
            string P63 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_Other"];

            driver.FindElement(By.XPath("//*[@id='txtDeathOtherAmount']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathOtherAmount']")).SendKeys(P63);


            string P64 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_FuneralCost"];

            driver.FindElement(By.XPath("//*[@id='txtDeathFuneralCosts']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathFuneralCosts']")).SendKeys(P64);


            string P65 = System.Configuration.ConfigurationManager.AppSettings["V_Appen_Risk_EmergencyFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathEmergencyFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathEmergencyFund']")).SendKeys(P65);


            string P66 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_EducationFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathEducationFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathEducationFund']")).SendKeys(P66);

            string P67 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_EstatePlanningFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathEstatePlanningFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathEstatePlanningFund']")).SendKeys(P67);


            string P68 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_ChildCareFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathChildCareFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathChildCareFund']")).SendKeys(P68);


            string P69 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_ProvisionforTax"];

            driver.FindElement(By.XPath("//*[@id='txtDeathProvisionforTax']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathProvisionforTax']")).SendKeys(P69);


            string P70 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_OtherFund"];

            driver.FindElement(By.XPath("//*[@id='txtDeathOtherFund']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txtDeathOtherFund']")).SendKeys(P70);
            ************/
            /*****8***/
            string PR61 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_TPDReducedebt"];

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
                //*[@id="aspnetForm"]/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span
                //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();
                driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();
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
        ///    string PR96 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Risk_AccidentCoverType"];

            //  driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/div/div[3]/table[2]/tbody/tr[28]/td[1]/div/label/span")).Click();

            //  driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtAccidentCoverType']")).SendKeys(A96);


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

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[2]/ul/li[4]/a")).Click();
                //            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[13]/div[2]/div/div[1]/ul/li[4]/a")).Click();


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
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtPurchasePrice']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtPurchasePrice']")).SendKeys(P103);


                string P104 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DatePurchased"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDatePurchased']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDatePurchased']")).SendKeys(P104);

                string P105 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_CurrentValue"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtCurrentValue']")).Clear();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtCurrentValue']")).SendKeys(P105);

                string P106 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_ProjectedCapitalGrowth"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedCapitalGrowth']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedCapitalGrowth']")).SendKeys(P106);



                string P107 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_ActualRentalIncome"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtActualRentalIncome']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtActualRentalIncome']")).SendKeys(P107);

                string P108 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_ProjectedRentalIncome"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedRentalIncome']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtProjectedRentalIncome']")).SendKeys(P108);

                string P109 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_DepreciationAllowance"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciationAllowance']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciationAllowance']")).SendKeys(P109);


                string P110 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_Depreciation"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciation']")).Click();
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtDepreciation']")).SendKeys(P110);


                string P111 = System.Configuration.ConfigurationManager.AppSettings["P_Appen_AnnualExpenses"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AppendixControl_PartnerAppendixPropertyControl_AppendixPropertyOwningRow_0_txtAnnulaExpenses']")).Click();
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
            }
        }
    }


