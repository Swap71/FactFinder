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
    class Ass_Lia
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
        public void ASS_Lia_Fields__Mandatory()
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
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtName']")).SendKeys(S30);

            string S31 = System.Configuration.ConfigurationManager.AppSettings["C_ALValue1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtCurrentValue']")).Clear();
       //     driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_0_txtCurrentValue']")).SendKeys(S31);

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
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtName']")).SendKeys(S35);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_1_ddlVehicleType"]

            string S36 = System.Configuration.ConfigurationManager.AppSettings["C_LCB1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtCurrentValue']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtCurrentValue']")).SendKeys(S36);




            string S37 = System.Configuration.ConfigurationManager.AppSettings["C_LIR1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtInterestRate']")).Clear();
        //    driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientLiabilityRow_0_txtInterestRate']")).SendKeys(S37);

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
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtName']")).SendKeys(S42);

            string S43 = System.Configuration.ConfigurationManager.AppSettings["P_ALValue1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerAssetRow_0_txtCurrentValue']")).SendKeys(S43);



            string S44 = System.Configuration.ConfigurationManager.AppSettings["P_LName1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtName']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtName']")).SendKeys(S44);
            //*[@id="ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_ClientAssetRow_1_ddlVehicleType"]



            string S45 = System.Configuration.ConfigurationManager.AppSettings["P_LCB1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtCurrentValue']")).Clear();
          //  driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtCurrentValue']")).SendKeys(S45);




            string S46 = System.Configuration.ConfigurationManager.AppSettings["P_LIR1"];
            driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtInterestRate']")).Clear();
         //   driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cph1_cph1_CfactsExpressControl_AssetsLiabilitiesControl_PartnerLiabilityRow_0_txtInterestRate']")).SendKeys(S46);





            driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a")).Click();

            Console.WriteLine("Save ---Assets & Liabilities");/**************OK*********************/



        }
    }

}

