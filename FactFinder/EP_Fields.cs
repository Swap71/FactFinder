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
    class EP_Fields
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
        public void EP_Fields__Entry()
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

         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlAssetsLiabilities']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_hlEstatePlanning']")).Click();

            string S274 = System.Configuration.ConfigurationManager.AppSettings["C_EP_DOW"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientDateOfWill']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientDateOfWill']")).SendKeys(S274);


            string S275 = System.Configuration.ConfigurationManager.AppSettings["C_EP_DLR"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientLastReviewDate']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientLastReviewDate']")).SendKeys(S275);





            string S276 = System.Configuration.ConfigurationManager.AppSettings["C_EP_HON"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientWillHolder']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientWillHolder']")).SendKeys(S276);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientValidWillYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientTestamentaryTrustYes']")).Click();



            string Ss76 = System.Configuration.ConfigurationManager.AppSettings["C_EP_NOT"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientTrusteeName']")).Clear();
       //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientTrusteeName']")).SendKeys(Ss76);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHaveExecutorYes']")).Click();

            string Sp76 = System.Configuration.ConfigurationManager.AppSettings["C_EP_NOE"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientWillExecutor']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientWillExecutor']")).SendKeys(Sp76);




            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientNoLongerBeneficiaryNo']")).Click();

            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientContestWillNo']")).Click();

            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientExecUndResponsibilitiesYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientFuneralPlanNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientReceiveInheritanceYes']")).Click();

            string S277 = System.Configuration.ConfigurationManager.AppSettings["C_EP_Inher"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientReceiveInheritanceAmount']")).Clear();
       //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientReceiveInheritanceAmount']")).SendKeys(S277);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientDeFactoRelationsshipYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientChildrenFromDifferentNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientDesireToOmitNo']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientBeneficiariesVulnerableYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/div/div[1]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHavePOAYes']")).Click();

            string S284 = System.Configuration.ConfigurationManager.AppSettings["C_EP_POA_Name"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientPOAHolder']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientPOAHolder']")).SendKeys(S284);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientUnderstandPOAYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientStillAppropriateYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHaveGPOAYes']")).Click();

            string S278 = System.Configuration.ConfigurationManager.AppSettings["C_EP_GPOA_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAState']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAState']")).SendKeys(S278);


            string S279 = System.Configuration.ConfigurationManager.AppSettings["C_EP_GPOA_ED"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAExpiryDate']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAExpiryDate']")).SendKeys(S279);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientGPOARegisteredYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAPowerHolder']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientGPOAPowerHolder']")).SendKeys("Self");

            string S280 = System.Configuration.ConfigurationManager.AppSettings["C_EP_EPOAF_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEFPOAState']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEFPOAState']")).SendKeys(S280);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEFPOARegisteredYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEFPOAPowerHolder']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEFPOAPowerHolder']")).SendKeys("Son");

            string S281 = System.Configuration.ConfigurationManager.AppSettings["C_EP_EPOAM_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEMPOAState']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEMPOAState']")).SendKeys(S281);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEMPOARegisteredNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEMPOAPowerHolder']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEMPOAPowerHolder']")).SendKeys("SISTER");


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHaveEGPOAYes']")).Click();


            string S282 = System.Configuration.ConfigurationManager.AppSettings["C_EP_EPOAG_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEGPOAState']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEGPOAState']")).SendKeys(S282);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEGPOAPowerHolder']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEGPOAPowerHolder']")).SendKeys("Self");


            string S283 = System.Configuration.ConfigurationManager.AppSettings["C_EP_EPOAO_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEOPOAState']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEOPOAState']")).SendKeys(S283);




            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEGPOARegisteredND']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEOPOARegisteredNo']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEOPOAPowerHolder']")).Clear();
 //           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtClientEOPOAPowerHolder']")).SendKeys("Father");



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/div/div[1]/ul/li[3]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientEnduringPOAYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientGuardiansForChildrenYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();



            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/ul/li[2]/a")).Click();

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerDateOfWill"]
            string S285 = System.Configuration.ConfigurationManager.AppSettings["P_EP_DOW"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerDateOfWill']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerDateOfWill']")).SendKeys(S285);


            string S286 = System.Configuration.ConfigurationManager.AppSettings["P_EP_DLR"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerLastReviewDate']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerLastReviewDate']")).SendKeys(S286);





            string S287 = System.Configuration.ConfigurationManager.AppSettings["P_EP_HON"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillHolder']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillHolder']")).SendKeys(S287);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerValidWillYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerTestamentaryTrustYes']")).Click();


            string Ss87 = System.Configuration.ConfigurationManager.AppSettings["P_EP_NOT"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerTrusteeName']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerTrusteeName']")).SendKeys(Ss87);


            // driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbClientHaveExecutorYes']")).Click();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerHaveExecutorYes']")).Click();

            string Sp87 = System.Configuration.ConfigurationManager.AppSettings["P_EP_NOE"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillExecutor']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerWillExecutor']")).SendKeys(Sp87);




            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerNoLongerBeneficiaryNo']")).Click();

            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerContestWillNo']")).Click();

            driver.FindElement(By.XPath(" //*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerExecUndResponsibilitiesYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerFuneralPlanNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerReceiveInheritanceYes']")).Click();

            string S288 = System.Configuration.ConfigurationManager.AppSettings["P_EP_Inher"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerReceiveInheritanceAmount']")).Clear();
 //           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerReceiveInheritanceAmount']")).SendKeys(S288);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerDeFactoRelationsshipYes']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerChildrenFromDifferentNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerDesireToOmitNo']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerBeneficiariesVulnerableYes']")).Click();


            //////////

            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[1]/div[11]/div[2]/div/div[2]/ul/li[2]/a")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerHavePOAYes']")).Click();

            string Sa84 = System.Configuration.ConfigurationManager.AppSettings["P_EP_POA_Name"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerPOAHolder']")).Clear();
 //           driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerPOAHolder']")).SendKeys(Sa84);

            //*[@id="ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerPOAHolder"]



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerUnderstandPOAYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerStillAppropriateYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerHaveGPOAYes']")).Click();

            string Sa78 = System.Configuration.ConfigurationManager.AppSettings["P_EP_GPOA_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAState']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAState']")).SendKeys(Sa78);


            string Sa79 = System.Configuration.ConfigurationManager.AppSettings["P_EP_GPOA_ED"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAExpiryDate']")).Clear();
//            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAExpiryDate']")).SendKeys(Sa79);



            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerGPOARegisteredYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAPowerHolder']")).Clear();
   //         driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerGPOAPowerHolder']")).SendKeys("Self");

            string Sa80 = System.Configuration.ConfigurationManager.AppSettings["P_EP_EPOAF_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEFPOAState']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEFPOAState']")).SendKeys(Sa80);

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEFPOARegisteredYes']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEFPOAPowerHolder']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEFPOAPowerHolder']")).SendKeys("Son");

            string Sa81 = System.Configuration.ConfigurationManager.AppSettings["P_EP_EPOAM_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEMPOAState']")).Clear();
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEMPOAState']")).SendKeys(Sa81);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEMPOARegisteredNo']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEMPOAPowerHolder']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEMPOAPowerHolder']")).SendKeys("SISTER");


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerHaveEGPOAYes']")).Click();


            string Sa82 = System.Configuration.ConfigurationManager.AppSettings["P_EP_EPOAG_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEGPOAState']")).Clear();
  //          driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEGPOAState']")).SendKeys(Sa82);


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEGPOAPowerHolder']")).Clear();
     //       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEGPOAPowerHolder']")).SendKeys("Self");


            string Sa83 = System.Configuration.ConfigurationManager.AppSettings["P_EP_EPOAO_State"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEOPOAState']")).Clear();
    //        driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEOPOAState']")).SendKeys(Sa83);




            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEGPOARegisteredND']")).Click();

            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_cbPartnerEOPOARegisteredNo']")).Click();


            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEOPOAPowerHolder']")).Clear();
     //       driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsAdvanceControl_EstatePlanningControl_txtPartnerEOPOAPowerHolder']")).SendKeys("Father");


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
        }
    }
}
