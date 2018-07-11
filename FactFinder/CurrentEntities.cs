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
//using AventStack.ExtentReports;
using RelevantCodes.ExtentReports;
using iTextSharp.xmp.impl;
using NUnit.Framework.Interfaces;

namespace FactFinder
{
    class CE
    {
        //try
        // {

        /*  public static ExtentReports report;
          public static ExtentTest test;*/


        public ExtentReports extent;
        public ExtentTest test;


        IWebDriver driver;


        [SetUp]
        public void startBrowser()
        {
            try
            {


                /****
                            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
                                string projectPath = new Uri(actualPath).LocalPath; // project path of your solution
                           // string projectPath = new Uri(actualPath)."C:/Users/Stellar/source/repos/FactFinder/FactFinder/"; // project path of your solution

                            string reportPath = projectPath + "Reports\\testreport.html";

                            // true if you want to append data to the report.  Replace existing report with new report.  False to create new report each time
                            extent = new ExtentReports(reportPath, false);
                            extent.AddSystemInfo("Host Name", "localhost")
                                .AddSystemInfo("Environment", "QA")
                                .AddSystemInfo("User Name", "testUser");

                            extent.LoadConfig(projectPath + "extent-config.xml");******/

                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
                string projectPath = new Uri(actualPath).LocalPath; // project path of your solution
                                                                    // string projectPath = new Uri(actualPath)."C:/Users/Stellar/source/repos/FactFinder/FactFinder/"; // project path of your solution

                string reportPath = projectPath + "Reports\\testreport.html";

                // true if you want to append data to the report.  Replace existing report with new report.  False to create new report each time
                extent = new ExtentReports(reportPath);









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
            catch (Exception e)
            {
                // Log.error("Report Category button element is not found.");

                // Taking screenshot for defect reporting

       //         Utils.captureScreenShot();

                // After doing my work, now i want to stop my test case

                throw (e);

            }

        }

        [Test]
        public void CurrentEntities()
        {
            try
            {

                //    test = extent.StartTest("StepLogsGeneartion");
                test = extent.StartTest("CurrentEntities");

                test.Log(LogStatus.Info, "START TEST1");
                test.Log(LogStatus.Info, "START TEST2");
                test.Log(LogStatus.Info, "START TEST3");



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

                var im2 = driver.FindElement(By.XPath("//*[@id='aspnetForm']/section[2]/section[2]/section[1]/section/section/section/section[1]/div[3]/div[3]/div[2]/div/div[1]/a"));

                //  im2.Click();

           //     Assert.IsNull(im2);

                Console.WriteLine("Assert");
                //  test = extent.StartTest("This test case is to test Add button feature");
                extent.EndTest(test);

            }
            catch (Exception e1)
            {
                // Log.error("Report Category button element is not found.");

                // Taking screenshot for defect reporting

                //    Utils.captureScreenShot();

                // After doing my work, now i want to stop my test case

                var status = TestContext.CurrentContext.Result.Outcome.Status;

                var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";

                var errorMessage = TestContext.CurrentContext.Result.Message;


                test.Log(LogStatus.Fail, status + errorMessage);

                throw (e1);
            }
        }

/**
       [TearDown]

        public void AfterClass()

        {

       /****     var status = TestContext.CurrentContext.Result.Outcome.Status;

                var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";

                var errorMessage = TestContext.CurrentContext.Result.Message;



                if (status == TestStatus.Failed)

                {

                    test.Log(LogStatus.Fail, status + errorMessage);

                }
                ****/
                //End test report
/**
                extent.EndTest(test);

               

           // }
  /**      }
        ***/
    //    [OneTimeTearDown]
    //    public void TearDown()
   //     {
            //StackTrace details for failed Testcases

          [OneTimeTearDown]

        public void EndReport()

        {

            //End Report

            extent.Flush();

            extent.Close();

        }
        
    }


/*
        extent.EndTest(test);
            test.Log(LogStatus.Info, "EndTest1");
            extent.Flush();
            test.Log(LogStatus.Info, "EndTest2");
            extent.Close();
            test.Log(LogStatus.Info, "EndTest3");*/
        }
   // }
   /* Catch(ArgumentNullException ex)
    {

    }*/

     //   test = extent.StartTest("DemoReportPass");
    //        Assert.IsTrue(false);
        //    test.Log(LogStatus.Fail, "Assert Pass as condition is false");


            /*        [TearDown]
                public static void CloseBrowser()
                {


                 /***   test = extent.StartTest("DemoReportPass");
                    Assert.IsTrue(true);
                    test.Log(LogStatus.Pass, "Assert Pass as consition is true");


                    // Close browser
                    //            Base.driver.Close();

                    // End test ans flush report
                    report.EndTest(test);
                    report.Flush();***/
            //     }*/
       
        
   // }
  //  }
//}

