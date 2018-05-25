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
    class Invest
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
        public void Investment_Fields__Mandatory()
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
            driver.FindElement(By.XPath(".//*[@id='ctl00_ctl00_cph1_cph1_hlAdvancedFacts']")).Click();

            Console.WriteLine("Investment Advanced");

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities']")).Click();
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities"]//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities"]

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtDateAcquired']")).Click();

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes"]
            //           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes']")).Click();

            //           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo']")).Click();
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo"]

            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlVehicleType']")).Click();

 /*****OK**/           string Inc208 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_VehicleType"];

            SelectElement oSelectionInc208 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlVehicleType']")));
            oSelectionInc208.SelectByText(Inc208);

            if (Inc208 == "Managed Fund" || Inc208 == "Stock")
            {
                string Inc211 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_Units"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtUnits']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtUnits']")).SendKeys(Inc211);

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
             //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtInvestmentassetCentrelinkValue']")).SendKeys(Inc217);

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
              //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtTrustee']")).SendKeys(Inc215);


                string Inc216 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_Beneficiaries"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtBeneficiaries']")).Clear();
             //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtBeneficiaries']")).SendKeys(Inc216);

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
             //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")).SendKeys(Inc220);

                string Inc2201 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_Shareholders"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtShareholders']")).Clear();
            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtShareholders']")).SendKeys(Inc2201);



                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbCompanyIncludeInAdviceNo']")).Click();

                //    SelectElement oSelectionInc221 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")));
                //   oSelectionInc221.SelectByText(Inc221);
                //    driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlAssetType"]

            }

            else
            {
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).Clear();
             //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).SendKeys("Test InvestMents");

                string Inc2091 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_OwnerType"];
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType"]
                SelectElement oSelectionInc2091 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType']")));
                oSelectionInc2091.SelectByText(Inc2091);


                string Inc2121 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_CurrentValue"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtCurrentValue']")).Clear();
             //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtCurrentValue']")).SendKeys(Inc2121);


                string Inc2131 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_PurchasePrice"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo']")).Click();





                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtPrice']")).Clear();
           //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtPrice']")).SendKeys(Inc2131);





            }


            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName']")).SendKeys("Test InvestMents");


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
 /****OK**/           }

            string Inc212 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_CurrentValue"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtCurrentValue']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtCurrentValue']")).SendKeys(Inc212);


            string Inc213 = System.Configuration.ConfigurationManager.AppSettings["C_Inv_PurchasePrice"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbLoanYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbSellNo']")).Click();





            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtPrice']")).Clear();
     //       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtPrice']")).SendKeys(Inc213);


            //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbTrustIncludeInAdviceYes']")).Click();

            //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_rbTrustCopyOfTrustYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_txtClientInvestmentAdviserNotes']")).Clear();
      //      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_txtClientInvestmentAdviserNotes']")).SendKeys("Test Adviser Notes");

            // }


/**OK********************/

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


/*****OK****/            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[1]/ul/li[2]/a")).Click();
            string S230 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Name"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtName']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtName']")).SendKeys(S230);


            string S231 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Owner"];

            SelectElement oSelection231 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlOwnerType']")));
            oSelection231.SelectByText(S231);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue"]
            string S232 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Esti"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtCurrentValue']")).Clear();
      //      driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtCurrentValue']")).SendKeys(S232);

            //  string S233 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];
            string S233 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Type"];
            SelectElement oSelection233 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_ddlAssetType']")));
            oSelection233.SelectByText(S233);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlAssetType"]

            string S234 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtDateAcquired']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtDateAcquired']")).SendKeys(S234);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount"]

            string S235 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PA"];



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtPurchaseAmount']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtPurchaseAmount']")).SendKeys(S235);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();
            string S236 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Inc"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();


            //    driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S236);


            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate"]

            string S237 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Matu"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtMaturityDate']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtMaturityDate']")).SendKeys(S237);
            //  driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
            // driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S236);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbdemedforcentrelinkNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbReInvestIncomeNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbRepayOnTPD']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientAssetRow_0_rbIsLoanAttachedNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[1]/ul/li[3]/a")).Click();


            /****/
 /****OK**/           string C225 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Descr"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtName']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtName']")).SendKeys(C225);


            string C226 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_LA"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtCurrentValue']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtCurrentValue']")).SendKeys(C226);



            string S224 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_LType"];

            SelectElement oSelection224 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlLoanType']")));
            oSelection224.SelectByText(S224);


            string S225 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_LN"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtProvider']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtProvider']")).SendKeys(S225);


            string S226 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_IType"];

            SelectElement oSelection226 = new SelectElement(driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlInterestType']")));
            oSelection226.SelectByText(S226);

            /*     string S227 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Freq"];

                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']")).Clear();
                 driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']")).SendKeys(S227);

                 */

            /******OK****/
/*****OK*/            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_rbRetainYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_rbRepayOnTrauma']")).Click();

            //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']


            string S229 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Freq"];

            SelectElement oSelection229 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_ddlPaymentFrequency']")));
            oSelection229.SelectByText(S229);






            string S228 = System.Configuration.ConfigurationManager.AppSettings["C_Lia_Repay"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtRepayment']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtRepayment']")).SendKeys(S228);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_rbRepayOnTPD']")).Click();

            /*****OK***/
            /**/
 /****OK*/           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_cbClientDrawLoanYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_rbClientChangeInFutureLiabiitiesNo']")).Click();



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/ul/li[2]/a")).Click();
            /******/


/****OK**/
            string IncP208 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_VehicleType"];

            SelectElement oSelectionIncP208 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_ddlVehicleType']")));
            oSelectionIncP208.SelectByText(IncP208);

            if (IncP208 == "Managed Fund" || IncP208 == "Stock")
            {
                string IncP211 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_Units"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtUnits']")).Clear();
      //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtUnits']")).SendKeys(IncP211);

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
         //       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtInvestmentassetCentrelinkValue']")).SendKeys(IncP217);

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
        //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtTrustee']")).SendKeys(IncP215);


                string IncP216 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_Beneficiaries"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtBeneficiaries']")).Clear();
       //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtBeneficiaries']")).SendKeys(IncP216);

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
        //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtNoOfEmployees']")).SendKeys(IncP220);

                string IncP2201 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_Shareholders"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtShareholders']")).Clear();
      //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtShareholders']")).SendKeys(IncP2201);



                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbCompanyIncludeInAdviceNo']")).Click();

                //    SelectElement oSelectionInc221 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtNoOfEmployees']")));
                //   oSelectionInc221.SelectByText(Inc221);
                //    driver.FindElement(By.XPath("//*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlAssetType"]

            }

            else
            {
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName"]
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtName']")).Clear();
       //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtName']")).SendKeys("Test InvestMents");

                string IncP2091 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_OwnerType"];
                //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_ddlOwnerType"]
                SelectElement oSelectionIncP2091 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_ddlOwnerType']")));
                oSelectionIncP2091.SelectByText(IncP2091);


                string IncP2121 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_CurrentValue"];
                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtCurrentValue']")).Clear();
       //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtCurrentValue']")).SendKeys(IncP2121);


                string IncP2131 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_PurchasePrice"];

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbLoanYes']")).Click();

                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_rbSellNo']")).Click();





                driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtPrice']")).Clear();
      //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtPrice']")).SendKeys(IncP2131);





            }


            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_ClientInvestmentRow_0_txtName"]
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtName']")).Clear();
     //       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerInvestmentRow_0_txtName']")).SendKeys("Test InvestMents");


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

     /***       string IncP212 = System.Configuration.ConfigurationManager.AppSettings["P_Inv_CurrentValue"];
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
            *******/
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

   /***OK******/         driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[6]/div[2]/div/div[2]/ul/li[2]/a")).Click();

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName"]


            string S2301 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Name"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName']")).SendKeys(S2301);


            string S2311 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Owner"];

            SelectElement oSelection2311 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlOwnerType']")));
            oSelection2311.SelectByText(S2311);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue"]
            string S2321 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Esti"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).Clear();
     //       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).SendKeys(S2321);

            //  string S233 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];
            string S2331 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Type"];
            SelectElement oSelection2331 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlAssetType']")));
            oSelection233.SelectByText(S233);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_ddlAssetType"]

            string S2341 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PD"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtDateAcquired']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtDateAcquired']")).SendKeys(S2341);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount"]

            string S2351 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_PA"];



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtPurchaseAmount']")).SendKeys(S2351);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();
            string S2361 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Inc"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_trassetrow']/table/tbody/tr[5]/td[1]/table/tbody/tr/td[1]/div/label[1]/span")).Click();


            //    driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).Clear();
            //   driver.FindElement(By.XPath("//*[@id='txtAnnualIncome']")).SendKeys(S236);


            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate"]

            string S2371 = System.Configuration.ConfigurationManager.AppSettings["P_Assets_Matu"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate']")).Clear();
//            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtMaturityDate']")).SendKeys(S2371);
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
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtName']")).SendKeys(P225);


            string P226 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_LA"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtCurrentValue']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtCurrentValue']")).SendKeys(P226);



            string P224 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_LType"];

            SelectElement oSelectionP224 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_ddlLoanType']")));
            oSelectionP224.SelectByText(P224);


            string P2251 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_LN"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtProvider']")).SendKeys(P2251);


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

 /*****OK**/           string S2401 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_TR"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtTermRemaining']")).Clear();
 //           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtTermRemaining']")).SendKeys(S2401);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_rbRepayOnTrauma']")).Click();


            string S2411 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_RA"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRedrawAmount']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRedrawAmount']")).SendKeys(S2411);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_rbRetainYes']")).Click();

            string S2421 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_Freq"];
            SelectElement oSelection2421 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_ddlPaymentFrequency']")));
            oSelection2421.SelectByText(S2421);



            string S2431 = System.Configuration.ConfigurationManager.AppSettings["P_Lia_Rep"];

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRepayment']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtRepayment']")).SendKeys(S2431);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_cbPartnerDrawLoanNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_AssetsLiabilitiesControl_rbPartnerChangeInFutureLiabiitiesYes']")).Click();


        /**OK***************/

 /***ok**/           driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click(); 

          //  Thread.Sleep(1000);

        }
    }


}
